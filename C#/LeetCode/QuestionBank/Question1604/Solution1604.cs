using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1604
{
    public class Solution1604 : Interface1604
    {
        /// <summary>
        /// 排序 + 滑动窗口
        /// 直接将HH:MM转为分钟，可以HH*60+MM，也可以HH*100+MM，这里采用第一种
        /// </summary>
        /// <param name="keyName"></param>
        /// <param name="keyTime"></param>
        /// <returns></returns>
        public IList<string> AlertNames(string[] keyName, string[] keyTime)
        {
            Dictionary<string, List<int>> buffer = new Dictionary<string, List<int>>();
            int len = keyName.Length;
            for (int i = 0; i < len; i++)
            {
                string name = keyName[i];
                int minute = int.Parse(keyTime[i].Substring(0, 2)) * 60 + int.Parse(keyTime[i].Substring(3, 2));
                if (buffer.ContainsKey(name)) buffer[name].Add(minute); else buffer.Add(name, new List<int> { minute });
            }

            List<string> result = new List<string>();
            foreach (var kv in buffer)
            {
                List<int> minutes = kv.Value; minutes.Sort();
                for (int i = 0; i < minutes.Count - 2; i++)
                {
                    if (minutes[i + 2] - minutes[i] <= 60)
                    {
                        result.Add(kv.Key); break;
                    }
                }
            }

            result.Sort(StringComparer.Ordinal);
            return result;
        }

        /// <summary>
        /// GroupBy
        /// HH:00，需要补一个(HH-1):00（00:00除外），因为整点时间前后时间段都可计，然后按照Name，HH分组计数即可。
        /// 
        /// 注意审题，题目理解错了，以为只有HH:00 - (HH+1):00算一小时了，题目的意思是HH:MM - (HH+1):MM算一小时
        ///     请注意 "10:00" - "11:00" 视为一个小时时间范围内，而 "23:51" - "00:10" 不被视为一小时内，因为系统记录的是某一天内的使用情况。
        ///     题目中这句话是解释跨天。
        /// </summary>
        /// <param name="keyName"></param>
        /// <param name="keyTime"></param>
        /// <returns></returns>
        public IList<string> AlertNames_Error(string[] keyName, string[] keyTime)
        {
            Dictionary<string, Dictionary<int, int>> buffer = new Dictionary<string, Dictionary<int, int>>();
            int len = keyName.Length;
            for (int i = 0; i < len; i++)
            {
                string name = keyName[i];
                int hour = int.Parse(keyTime[i].Substring(0, 2)), minute = int.Parse(keyTime[i].Substring(3, 2));
                if (buffer.ContainsKey(name))
                {
                    if (buffer[name].ContainsKey(hour)) buffer[name][hour]++; else buffer[name].Add(hour, 1);
                }
                else
                {
                    buffer.Add(name, new Dictionary<int, int>() { { hour, 1 } });
                }

                if (hour != 0 && minute == 0)
                {
                    if (buffer[name].ContainsKey(hour - 1)) buffer[name][hour - 1]++; else buffer[name].Add(hour - 1, 1);
                }
            }

            List<string> result = new List<string>();
            foreach (var item in buffer) foreach (var time in item.Value)
                {
                    if (time.Value >= 3)
                    {
                        result.Add(item.Key); break;
                    }
                }

            result.Sort(StringComparer.Ordinal);
            return result;
        }
    }
}
