using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFWCoreLib.CoreFrame.Business;
using HIS_PublicManage.Dao;

namespace HIS_PublicManage.ObjectModel
{
    /// <summary>
    /// 频次算法
    /// </summary>
    public class FrequencyManagement: AbstractObjectModel
    {
        private string _cycleTime = "00:00:00";
        /// <summary>
        /// 周期时间点
        /// </summary>
        public string CycleTime
        {
            get { return _cycleTime; }
            set { _cycleTime = value; }
        }

        /// <summary>
        /// 获取频次时间点
        /// </summary>
        /// <param name="frequencyID">频次ID</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="firstCount">首次，无首次默认-1</param>
        /// <param name="lastCount">末次，无末次默认-1</param>
        /// <returns></returns>
        public List<FrequencyTiming> GetTiming(int frequencyID, DateTime beginTime,DateTime endTime, int firstCount, int lastCount)
        {
            List<FrequencyTiming> timingList = new List<FrequencyTiming>();

            if (beginTime > endTime) return timingList;

            string ExecuteCode = NewDao<IPublicManageDao>().GetExecuteCode(frequencyID);
            ExecuteCode = ExecuteCode == null ? "" : ExecuteCode;
            string[] codes = ExecuteCode.Split('@');
            string execType = codes[0];//执行类型
            switch (execType)
            {
                case "M"://间隔多少分钟执行（M@20）
                    int minute = Convert.ToInt32(codes[1]);
                    calculateTime(1, minute, beginTime, endTime, timingList, Guid.NewGuid().ToString(), true);
                    break;
                case "H"://间隔多少小时执行(H@2)
                    int hour = Convert.ToInt32(codes[1]);
                    calculateTime(2, hour, beginTime, endTime, timingList, Guid.NewGuid().ToString(), true);
                    break;
                case "D":
                    if (codes.Length == 2)//间隔多少天执行(D@1)
                    {
                        int day = Convert.ToInt32(codes[1]);
                        calculateTime(3, day, beginTime, endTime, timingList, Guid.NewGuid().ToString(), true);
                    }
                    else if (codes.Length == 4)//1天几次，每次时间点(D@1@3@1|10:30#1|12:30#1|20:00 一天三次)
                    {
                        int day= Convert.ToInt32(codes[1]);
                        int count= Convert.ToInt32(codes[2]);
                        string[] points = codes[3].Split('#');
                        List<string> strs = new List<string>();
                        foreach (string s in points)
                        {
                            if (!string.IsNullOrEmpty(s)) strs.Add(s);
                        }
                        string[] rePoints = strs.ToArray();

                        if (count == rePoints.Length)//避免执行代码错误
                        {
                            calculatePoint(day, count, rePoints, beginTime, endTime, timingList,firstCount,lastCount);
                        }
                    }
                    break;
                case "S"://立即执行，1次（S@1  立即执行一次）
                    FrequencyTiming ft = new FrequencyTiming();
                    ft.executeTime = beginTime;
                    ft.PeriodFlag = true;
                    ft.Identify=Guid.NewGuid().ToString();
                    timingList.Add(ft);
                    break;
            }
            return timingList;
        }

        /// <summary>
        /// 获取频次时间点
        /// </summary>
        /// <param name="frequencyID">频次ID</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <param name="firstCount">首次，无首次默认-1</param>
        /// <param name="lastCount">末次，无末次默认-1</param>
        /// <returns></returns>
        public List<FrequencyTiming> GetTimingRef(int frequencyID, DateTime beginTime,ref DateTime endTime, int firstCount, int lastCount)
        {
            List<FrequencyTiming> timingList = new List<FrequencyTiming>();
            if (beginTime > endTime) return timingList;
            if (beginTime.AddMonths(3) < endTime) return timingList;

            string ExecuteCode = frequencyID>0?NewDao<IPublicManageDao>().GetExecuteCode(frequencyID): "D@1@1@1|10:30";
            ExecuteCode = ExecuteCode == null ? "" : ExecuteCode;
            string[] codes = ExecuteCode.Split('@');
            string execType = codes[0];//执行类型
            switch (execType)
            {
                case "M"://间隔多少分钟执行（M@20）
                    int minute = Convert.ToInt32(codes[1]);
                    calculateTime(1, minute, beginTime, endTime, timingList, Guid.NewGuid().ToString(), true);
                    endTime = timingList.Last<FrequencyTiming>().executeTime.AddMinutes(minute);
                    break;
                case "H"://间隔多少小时执行(H@2)
                    int hour = Convert.ToInt32(codes[1]);
                    calculateTime(2, hour, beginTime, endTime, timingList, Guid.NewGuid().ToString(), true);
                    endTime = timingList.Last<FrequencyTiming>().executeTime.AddHours(hour);
                    break;
                case "D":
                    if (codes.Length == 2)//间隔多少天执行(D@1)
                    {
                        int day = Convert.ToInt32(codes[1]);
                        //D天N次的  需要将结束时间定到D天之后，但是如果结束时间-开始时间>D 则不作处理
                        if (day > 1)
                        {
                            TimeSpan timeSpan = DateTime.Parse(endTime.ToString("yyyy-MM-dd HH:mm:ss")) - DateTime.Parse(beginTime.ToString("yyyy-MM-dd 23:59:59"));
                            decimal dDays = timeSpan.Days+((timeSpan.Hours+ timeSpan.Milliseconds+ timeSpan.Seconds)>0?1:0) ;
                            int iPriod = Convert.ToInt32(Math.Ceiling(dDays/day));
                            endTime = Convert.ToDateTime(beginTime.AddDays(iPriod * day-1).ToString("yyyy-MM-dd 23:59:59"));
                        }
                        calculateTime(3, day, beginTime, endTime, timingList, Guid.NewGuid().ToString(), true);
                    }
                    else if (codes.Length == 4)//1天几次，每次时间点(D@1@3@1|10:30#1|12:30#1|20:00 一天三次)
                    {
                        int day = Convert.ToInt32(codes[1]);
                        int count = Convert.ToInt32(codes[2]);
                        string[] points = codes[3].Split('#');
                        List<string> strs = new List<string>();
                        foreach (string s in points)
                        {
                            if (!string.IsNullOrEmpty(s)) strs.Add(s);
                        }
                        string[] rePoints = strs.ToArray();

                        //D天N次的  需要将结束时间定到D天之后，但是如果结束时间-开始时间>D 则不作处理
                        if (day > 1)
                        {
                            TimeSpan timeSpan = DateTime.Parse(endTime.ToString("yyyy-MM-dd HH:mm:ss")) - DateTime.Parse(beginTime.ToString("yyyy-MM-dd HH:mm:ss"));
                            decimal dDays = timeSpan.Days + ((timeSpan.Hours + timeSpan.Milliseconds + timeSpan.Seconds) > 0 ? 1 : 0);
                            int iPriod = Convert.ToInt32(Math.Ceiling(dDays / day));
                            endTime = Convert.ToDateTime(beginTime.AddDays(iPriod * day).ToString("yyyy-MM-dd 00:00:00"));
                        }
                        if (count == rePoints.Length)//避免执行代码错误
                        {
                            calculatePoint(day, count, rePoints, beginTime, endTime, timingList, firstCount, lastCount);
                        }
                    }
                    break;
                case "S"://立即执行，1次（S@1  立即执行一次）
                    FrequencyTiming ft = new FrequencyTiming();
                    ft.executeTime = beginTime;
                    ft.PeriodFlag = true;
                    ft.Identify = Guid.NewGuid().ToString();
                    timingList.Add(ft);
                    break;
            }
            return timingList;
        }

        private void calculateTime(int type, int intervalNum, DateTime beginTime, DateTime endTime, List<FrequencyTiming> timingList,string guid,bool firstFlag)
        {
            FrequencyTiming ft = new FrequencyTiming();
            ft.executeTime = beginTime;
            ft.PeriodFlag = firstFlag;
            ft.Identify = guid;
            timingList.Add(ft);

            DateTime newTime = beginTime;
            if (type == 1)//间隔分钟
            {
                newTime = beginTime.AddMinutes(Convert.ToDouble(intervalNum));
            }
            else if (type == 2)//间隔小时
            {
                newTime = beginTime.AddHours(Convert.ToDouble(intervalNum));
            }
            else if (type == 3)//间隔天
            {
                newTime = beginTime.AddDays(Convert.ToDouble(intervalNum));
            }
            if (newTime < endTime)
                calculateTime(type, intervalNum, newTime, endTime, timingList,guid,false);
        }
        private void calculatePoint(int day, int count, string[] points, DateTime beginTime, DateTime endTime, List<FrequencyTiming> timingList, int firstCount, int lastCount)
        {
            List<FrequencyTiming> _timingList = new List<FrequencyTiming>();
            DateTime newTime = Convert.ToDateTime(beginTime.Date.ToString("yyyy-MM-dd") + " " + CycleTime);//从0点开始算
            newTime = newTime.AddDays(Convert.ToDouble(day));

            DateTime date = beginTime.Date;
            bool PeriodFlag = true;//首次设执行周期
            string guid = Guid.NewGuid().ToString();
            for (int i = 0; i < count; i++)
            {
                int index = Convert.ToInt32(points[i].Split('|')[0]);
                string time = points[i].Split('|')[1].ToString().Trim() + ":00";
                DateTime thistime = Convert.ToDateTime(date.AddDays(index - 1).ToString("yyyy-MM-dd") + " " + time);
                if (thistime >= beginTime && thistime<=newTime && thistime <= endTime)
                {
                    FrequencyTiming ft = new FrequencyTiming();
                    ft.executeTime = thistime;
                    ft.PeriodFlag = PeriodFlag;
                    PeriodFlag = false;
                    ft.Identify = guid;
                    _timingList.Add(ft);                    
                }
            }

            timingList.AddRange(_timingList);

            #region 处理首次
            if (firstCount != -1)//首次
            {
                timingList.Clear();
                //List<FrequencyTiming> FT = _timingList.FindAll(x => x.GroupID == orderCheck.GroupID)

                if (_timingList.Count > firstCount)//首次小于正常频次
                {
                    _timingList.RemoveRange(firstCount, _timingList.Count - firstCount);
                }
                else if (_timingList.Count < firstCount)//首次大于正常频次
                {
                    int num = firstCount - _timingList.Count;
                    string _guid = _timingList.Count == 0 ? Guid.NewGuid().ToString() : _timingList[0].Identify;
                    for (int i = 1; i <= num; i++)
                    {
                        FrequencyTiming ft = new FrequencyTiming();
                        ft.executeTime = newTime.AddSeconds(-1*i);
                        ft.PeriodFlag = PeriodFlag;
                        PeriodFlag = false;
                        ft.Identify = _guid;
                        _timingList.Add(ft);
                    }
                }

                timingList.AddRange(_timingList);
                firstCount = -1;
            }
            #endregion

            if (newTime < endTime)//继续计算
                calculatePoint(day, count, points, newTime, endTime, timingList,-1,lastCount);
            else//末次
            {
                #region 处理末次
                if (lastCount != -1)//设置了末次
                {
                    timingList.RemoveRange(timingList.Count - _timingList.Count , _timingList.Count);

                    if (_timingList.Count > lastCount)//末次小于正常频次
                    {
                        _timingList.RemoveRange(lastCount, _timingList.Count - lastCount);
                    }
                    else if(_timingList.Count < lastCount)//末次大于正常频次
                    {
                        int num = lastCount - _timingList.Count;
                        string _guid = _timingList.Count == 0 ? Guid.NewGuid().ToString() : _timingList[0].Identify;
                        for (int i = 1; i <= num; i++)
                        {
                            FrequencyTiming ft = new FrequencyTiming();
                            ft.executeTime = endTime.AddSeconds(-1*i);
                            ft.PeriodFlag = false;
                            ft.Identify = _guid;
                            _timingList.Add(ft);
                        }
                    }

                    timingList.AddRange(_timingList);
                    lastCount = -1;
                }
                #endregion
            }
        }
        /// <summary>
        /// 获取执行次数
        /// </summary>
        /// <param name="frequencyID">频次ID</param>
        /// <param name="beginTime">开始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns></returns>
        public int GetExecCount(int frequencyID, DateTime beginTime, DateTime endTime)
        {
            return GetTiming(frequencyID, beginTime, endTime, -1, -1).Count;
        }
    }

    /// <summary>
    /// 频次时间点
    /// </summary>
    public class FrequencyTiming
    {
        /// <summary>
        /// 执行时间
        /// </summary>
        public DateTime executeTime { get; set; }
        /// <summary>
        /// 是否周期首次
        /// </summary>
        public bool PeriodFlag { get; set; }

        /// <summary>
        /// 周期标识
        /// </summary>
        public string Identify { get; set; }
    }
}
