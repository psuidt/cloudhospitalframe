using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfwControls.HISControl.Orders.Controls.Entity
{
    //频次
    public class CardDataSourceFrequency
    {
        public int FrequencyId { get; set; }
        public string Name { get; set; }
        public string Caption { get; set; }
        //执行次数
        public int ExecNum { get; set; }
        //执行周期
        public int CycleDay { get; set; }

        public string Pym { get; set; }
        public string Wbm { get; set; }
        public string Szm { get; set; }

        public static void Calculate(string _caption, out int execNum, out int cycleDay)
        {
            string[] freq_s = _caption.Split(new char[] { '@' });
            if (freq_s.Length == 4 && freq_s[1] == "D")
            {
                execNum = freq_s[3].Split(',').Length;
                cycleDay = Convert.ToInt32(freq_s[2]);
            }
            else
            {
                execNum = 1;//执行次数
                cycleDay = 1;//执行周期
            }
        }
    }
}
