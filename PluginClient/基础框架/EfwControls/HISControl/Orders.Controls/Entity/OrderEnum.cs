using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfwControls.HISControl.Orders.Controls.Entity
{
    /// <summary>
    /// 医嘱类别
    /// </summary>
    public enum OrderCategory
    {
        /// <summary>
        /// 长期医嘱 
        /// </summary>
        长期医嘱 = 0,
        /// <summary>
        /// 临时医嘱
        /// </summary>
        临时医嘱 = 1      
    };
    /// <summary>
    /// 特殊医嘱类型
    /// </summary>
    public enum OrderType
    {
        交病人医嘱=1,
        自备医嘱=2,
        出院带药医嘱=3,
        说明性医嘱=4,
        出院医嘱=5,
        死亡医嘱=6,
        转科医嘱=7,
        作废医嘱=8
    };
    /// <summary>
    /// 医嘱状态
    /// </summary>
    public enum OrderStatus
    {
        医生新开=-1,
        医生保存=0,
        医生发送=1,
        已经转抄=2,
        医生停嘱=3,
        转抄停嘱=4,
        执行完毕=5,
        所有=10,
        有效医嘱=11
    }
    public enum ItemType
    {
        物资,
        西药,
        成药,
        草药,
        治疗,
        医技,
        手术,
        说明,
        护理,
        其他,
        出院,
        所有项目,
        长嘱新开,
        长嘱项目,
        临嘱新开
    }

    public struct WrongDecline
    {
        public int colid;
        public int rowid;
        public string err;
        public void SetData(int _colid, int _rowid, string code, params string[] content)
        {
            colid = _colid;
            rowid = _rowid;
            err = MessageShows.GetMessages(code, content);
        }
    }

    partial class MessageShows
    {
        public static string GetMessages(string code, params string[] content)
        {
            string returnString = "0";
            switch (code)
            {
                case "0": returnString = "0"; break;
                case "C01": returnString = "{0}数量不能为空"; break;
                case "C02": returnString = "{0}数量或付数不能小于零！"; break;
                case "C03": returnString = "非法单位，请重新输入"; break;
                case "C04": returnString = "非法用法，请重新输入"; break;
                case "C05": returnString = "频率不能为空"; break;
                case "C06": returnString = "非法频率，请重新输入"; break;

                case "S01": returnString = "医嘱名称为空，保存失败，请重新输入医嘱名称"; break;
                case "S02": returnString = "{0}的开嘱时间为空，保存失败，请重开医嘱"; break;
                case "S03": returnString = "{0}的用法为空，保存失败，请输入用法"; break;
                case "S04": returnString = "{0}的开嘱医生为空，保存失败，请重新开此条医嘱"; break;
                case "S05": returnString = "{0}的开嘱科室为空，保存失败，请重新开此条医嘱"; break;
                case "S06": returnString = "长期医嘱\n{0}保存成功！\n {1}重新保存！"; break;
                case "S07": returnString = "长期医嘱\n{0}保存成功！"; break;
                case "S08": returnString = "长期医嘱\n{0}重新保存！"; break;
                case "S09": returnString = "临时医嘱\n{0}保存成功！\n {1}重新保存！"; break;
                case "S10": returnString = "临时医嘱\n{0}保存成功！"; break;
                case "S11": returnString = "临时医嘱\n{0}重新保存！"; break;

                default: return string.Format(returnString, content);
            }
            return string.Format(returnString, content);
        }
    }
}
