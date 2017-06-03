using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;

namespace EfwControls.Common
{
    /// <summary>
    /// 异步处理数据
    /// </summary>
    public class AsynProcessing : IDisposable
    {
        public AsynProcessing()
        {
        }

        //在DataGrid控件上自动增加一个"正在加载数据..."的文本
        public void Invoke(Control dataControl, Action callback)
        {
            Label loading = null;
            Control p = dataControl.Parent;
            if (p != null)
            {
                if (!p.Controls.ContainsKey("label_loading"))
                {
                    loading = new Label();
                    loading.AutoSize = true;
                    loading.BorderStyle = BorderStyle.FixedSingle;
                    loading.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    loading.ForeColor = Color.Blue;
                    loading.Name = "label_loading";
                    loading.Text = "正在加载数据...";
                    loading.BackColor = Color.White;
                    p.Controls.Add(loading);

                    loading.Location = new Point(dataControl.Location.X + 10, dataControl.Location.Y + 10);
                    loading.BringToFront();
                }
                else
                {
                    loading = p.Controls.Find("label_loading", false)[0] as Label;
                    loading.Visible = true;
                }
            }


            ThreadPool.QueueUserWorkItem(new WaitCallback(
                delegate(object para)
                {
                    try
                    {
                        loading.Invoke((MethodInvoker)delegate() { loading.Visible = true; });
                        callback();
                        loading.Invoke((MethodInvoker)delegate() { loading.Visible = false; });
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show("请求数据失败！\n" + err.Message);
                        //MessageBoxEx.Show("请求数据失败！\n" + err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                ));
        }

        public void Invoke(Action callback)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(
                delegate(object para)
                {
                    try
                    {
                        //loading.Invoke((MethodInvoker)delegate() { loading.Visible = true; });
                        callback();
                        //loading.Invoke((MethodInvoker)delegate() { loading.Visible = false; });
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show("请求数据失败！\n" + err.Message);
                        //MessageBoxEx.Show("请求数据失败！\n" + err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                ));
        }

        #region IDisposable 成员
        //中间件连接必须手动释放，不然容易超过连接数创建连接失败
        public void Dispose()
        {
            GC.SuppressFinalize(this);//不需要再调用本对象的Finalize方法
        }

        #endregion
    }
}
