using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using System.Reflection;
using Newtonsoft.Json.Linq;

namespace Temperature.Controls
{
    public partial class temperaturebrower : UserControl
    {
        string htmltemplate;
        string temperaturehtml;
        TemplateHelper thelper;

        public temperaturebrower()
        {
            InitializeComponent();
            webBrowser.ScriptErrorsSuppressed = true;

            htmltemplate = Application.StartupPath + "\\htmltemplate";
            temperaturehtml = htmltemplate + "\\Temperature";
        }

        private bool _isContextMenuShow = true;
        [Description("是否显示浏览器内容菜单")]
        public bool IsContextMenuShow
        {
            get { return _isContextMenuShow; }
            set { _isContextMenuShow = value; }
        }



        /// <summary>
        /// 显示Web界面
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="jsondata"></param>
        private void ShowView(string filename, List<JsonData> jsondata)
        {

            string url = temperaturehtml + "\\" + filename;

            thelper = new TemplateHelper(temperaturehtml);
            if (jsondata != null)
            {
                foreach (JsonData key in jsondata)
                {
                    thelper.Put(key.DataId, key.JsonValue);
                }
            }
            thelper.Put("path", htmltemplate.Replace("\\", "/"));
            string html = thelper.BuildString(filename);
            webBrowser.IsWebBrowserContextMenuEnabled = _isContextMenuShow;
            webBrowser.DocumentText = html;

            // 弹出网页源文件
            //System.Windows.Forms.Form windowBrowserSource = new System.Windows.Forms.Form();
            //System.Windows.Forms.RichTextBox browserSourceText = new System.Windows.Forms.RichTextBox();
            //browserSourceText.Margin = new System.Windows.Forms.Padding(0);
            //browserSourceText.Dock = System.Windows.Forms.DockStyle.Fill;
            //browserSourceText.Text = webBrowser.DocumentText;
            //windowBrowserSource.Controls.Add(browserSourceText);
            //windowBrowserSource.Show();
        }

        /// <summary>
        /// 显示Web界面
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="jsondata"></param>
        public void ShowView(List<JsonData> jsondata)
        {
            ShowView("Temperature.html", jsondata);
        }

        /// <summary>
        /// 判断文书编辑状态（返回bool）
        /// </summary>
        /// <returns></returns>
        public bool GetEditState()
        {
            NSoup.Nodes.Document doc = NSoup.NSoupClient.Parse(webBrowser.Document.Body.InnerHtml);
            var editState = doc.Select("#editState input");
            if (editState.Count > 0 && editState[0].Attr("value") == "false")
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 获取界面的数据（返回Json数据）
        /// </summary>
        /// <returns></returns>
        public List<JsonData> GetViewData()
        {
            List<JsonData> list = new List<JsonData>();
            NSoup.Nodes.Document doc = NSoup.NSoupClient.Parse(webBrowser.Document.Body.InnerHtml);
            var ret = doc.Select("#datastorage input");
            for (int i = 0; i < ret.Count; i++)
            {
                if (ret[i].Attr("acceptflag") == "true")//只有属性acceptflag设置为true才保存到数据库
                {
                    JsonData data = new JsonData();
                    data.DataId = ret[i].Attr("id");
                    data.JsonValue = ret[i].Attr("value");
                    list.Add(data);
                }
            }
            return list;
        }

        /// <summary>
        /// 显示打印预览界面
        /// </summary>
        public void PrintPreview()
        {
            webBrowser.ShowPrintPreviewDialog();
        }
        /// <summary>
        /// 直接打印
        /// </summary>
        public void Print()
        {
            webBrowser.Print();
        }
        /// <summary>
        /// 页面设置
        /// </summary>
        public void PageSettings()
        {
            webBrowser.ShowPageSetupDialog();
        }

        public static List<T> ToList<T>(string json)
        {
            object data = JsonConvert.DeserializeObject(json);
            if (data is JArray)
            {
                PropertyInfo[] pros = typeof(T).GetProperties();
                List<T> list = new List<T>();
                for (int i = 0; i < (data as JArray).Count; i++)
                {
                    T obj = (T)Activator.CreateInstance(typeof(T));
                    object _data = (data as JArray)[i];
                    for (int k = 0; k < pros.Length; k++)
                    {
                        object val = convertVal(pros[k].PropertyType, (_data as JObject)[pros[k].Name]);
                        pros[k].SetValue(obj, val, null);
                    }
                    list.Add(obj);
                }
                return list;
            }

            return null;
        }

        public static string ToJson(DataRow[] drs, string idName, string valueName)
        {
            if (drs.Length > 1)
            {
                char[] a = { '[', ']' };
                string JSONstring = "[";

                foreach (DataRow dr in drs)
                {
                    JSONstring += dr[valueName].ToString().TrimStart(a).TrimEnd(a) + ",";

                }

                JSONstring = JSONstring.TrimEnd(',');
                JSONstring += "]";

                return JSONstring;
            }
            else
            {
                string JSONstring = drs[0][valueName].ToString();

                return JSONstring;
            }
        }

        #region  值转换
        private static object convertVal(Type t, object data)
        {
            object val = null;
            if (t == typeof(Int32))
                val = Convert.ToInt32(data);
            else if (t == typeof(DateTime))
                val = Convert.ToDateTime(data);
            else if (t == typeof(Decimal))
                val = Convert.ToDecimal(data);
            else if (t == typeof(Boolean))
                val = Convert.ToBoolean(data);
            else if (t == typeof(String))
                val = Convert.ToString(data).Trim();
            else if (t == typeof(Guid))
                val = new Guid(data.ToString());
            else if (t == typeof(byte[]))
                if (data != null && data.ToString().Length > 0)
                {
                    val = Convert.FromBase64String(data.ToString());
                }
                else
                {
                    val = null;
                }
            else
                val = data;
            return val;
        }
        #endregion
    }

    /// <summary>
    /// 数据交互对象
    /// </summary>
    public class JsonData
    {
        private string _dataId = "";
        public string DataId
        {
            get { return _dataId; }
            set { _dataId = value; }
        }

        private string _jsonValue = "";
        public string JsonValue
        {
            get { return _jsonValue; }
            set { _jsonValue = value; }
        }
    }

}
