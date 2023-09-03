using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0599
{
    public class Solution0599_off : Interface0599
    {
        public string[] FindRestaurant(string[] list1, string[] list2)
        {
            Dictionary<string, int> dic1 = new Dictionary<string, int>();
            Dictionary<string, int> dic2 = new Dictionary<string, int>();
            for (int i = 0; i < list1.Length; i++) dic1.Add(list1[i], i);
            for (int i = 0; i < list2.Length; i++) dic2.Add(list2[i], i);
            if (dic1.Count > dic2.Count) (dic1, dic2) = (dic2, dic1);      // 小驱动大

            int sum = list1.Length + list2.Length, _sum;
            List<string> result = new List<string>();
            foreach (string s in dic1.Keys) if (dic2.ContainsKey(s))
                {
                    _sum = dic1[s] + dic2[s];
                    if (_sum < sum)
                    {
                        result.Clear(); result.Add(s); sum = _sum;
                    }
                    else if (_sum == sum)
                    {
                        result.Add(s);
                    }
                }

            return result.ToArray();
        }

        /// <summary>
        /// 与FindRestaurant()一样，但是只要hash化一个数组即可
        /// </summary>
        /// <param name="list1"></param>
        /// <param name="list2"></param>
        /// <returns></returns>
        public string[] FindRestaurant2(string[] list1, string[] list2)
        {
            if (list1.Length > list2.Length) (list1, list2) = (list2, list1);  // 小驱动大
            Dictionary<string, int> dic = new Dictionary<string, int>();
            for (int i = 0; i < list2.Length; i++) dic.Add(list2[i], i);

            int sum = list1.Length + list2.Length, _sum;
            List<string> result = new List<string>();
            string s; for (int i = 0; i < list1.Length && i <= sum; i++)
            {
                s = list1[i];
                if (dic.ContainsKey(s))
                {
                    _sum = i + dic[s];
                    if (_sum < sum)
                    {
                        result.Clear(); result.Add(s); sum = _sum;
                    }
                    else if (_sum == sum)
                    {
                        result.Add(s);
                    }
                }
            }

            return result.ToArray();
        }
    }
}
