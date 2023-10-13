using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1488
{
    public class Solution1488 : Interface1488
    {
        /// <summary>
        /// 贪心
        /// 示例：1 2 0 0 2 1
        /// 使用Dictionary<int, int>记录“满”的湖，使用List记录“空”的湖
        /// 遍历rains
        ///     下雨，看对应的湖当前状态
        ///         当前为空，将<湖, id>加入Dictionary中
        ///         当前为满
        ///             如果List非空，找一天用于排水，同时将这个id从List中移除，并更新Dictionary中湖的id，如果找不到，无解
        ///                 这里使用贪心法，找出这个湖两次下雨之间最小的可用id，为什么使用最小是可靠的，不难证明，证明从略
        ///                 List单调递增，可以使用二分法查找可用的id
        ///             如果List为空，无解
        ///     不下雨
        ///         将这一天的id加到List中
        /// 这里面的List，在移除元素时，时间复杂度为O(n)，如果使用HashSet，又无法使用二分查找，，如果C#中有Java中的TreeSet就好了
        /// 据说下面的方案.Net Core中时O(logN)的，不确定
        /// floor   for SortedSet<long>: sortedSet.GetViewBetween(long.MinValue, num).Max
        /// ceiling for SortedSet<long>: sortedSet.GetViewBetween(num, long.MaxValue).Min
        /// </summary>
        /// <param name="rains"></param>
        /// <returns></returns>
        public int[] AvoidFlood(int[] rains)
        {
            int len = rains.Length;
            int[] result = new int[len];
            Dictionary<int, int> dic = new Dictionary<int, int>();
            List<int> list = new List<int>();
            for (int i = 0, rain; i < len; i++)
            {
                rain = rains[i];
                if (rain > 0)
                {
                    if (dic.ContainsKey(rain))
                    {
                        int id = BinarySearch(list, dic[rain], i);
                        if (id == -1) return new int[0];
                        result[list[id]] = rain;
                        dic[rain] = i;
                        list.RemoveAt(id);
                    }
                    else
                    {
                        dic.Add(rain, i);
                    }
                    result[i] = -1;
                }
                else
                {
                    list.Add(i);
                }
            }
            for (int i = 0; i < len; i++) if (result[i] == 0) result[i] = 1;

            return result;
        }

        private int BinarySearch(List<int> list, int left, int right)
        {
            int result = right, l = 0, r = list.Count - 1, mid;
            while (l <= r)
            {
                mid = l + ((r - l) >> 1);
                if (list[mid] > left)
                {
                    result = mid; r = mid - 1;
                }
                else
                {
                    l = mid + 1;
                }
            }

            return result < right ? result : -1;
        }
    }
}
