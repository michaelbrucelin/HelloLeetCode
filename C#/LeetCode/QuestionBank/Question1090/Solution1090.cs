using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1090
{
    public class Solution1090 : Interface1090
    {
        /// <summary>
        /// 贪心
        /// 1. values与labels都按照values降序排序
        /// 2. 从values中第一个元素开始取，每次取，将对应的labels记录到字典中，下一次取的时候验证useLimit
        /// 
        /// 如果values的数目很大，而numWanted又较小时，不需要排序，直接遍历即可
        /// </summary>
        /// <param name="values"></param>
        /// <param name="labels"></param>
        /// <param name="numWanted"></param>
        /// <param name="useLimit"></param>
        /// <returns></returns>
        public int LargestValsFromLabels(int[] values, int[] labels, int numWanted, int useLimit)
        {
            int len = values.Length;
            PriorityQueue<(int value, int label), int> maxpq = new PriorityQueue<(int value, int label), int>();
            for (int i = 0; i < len; i++) maxpq.Enqueue((values[i], labels[i]), -values[i]);

            int result = 0;
            Dictionary<int, int> use = new Dictionary<int, int>();
            while (numWanted > 0 && maxpq.Count > 0)
            {
                var t = maxpq.Dequeue();
                if (use.ContainsKey(t.label))
                {
                    if (use[t.label] < useLimit)
                    {
                        result += t.value; numWanted--; use[t.label]++;
                    }
                }
                else
                {
                    result += t.value; numWanted--; use.Add(t.label, 1);
                }
            }

            return result;
        }

        /// <summary>
        /// 与LargestValsFromLabels()一样，不过没有使用优先级队列，直接原地排序数组
        /// 其实不必原地排序两个数组，只是生成一个排序后的索引数组用来获取数组中的元素即可
        /// </summary>
        /// <param name="values"></param>
        /// <param name="labels"></param>
        /// <param name="numWanted"></param>
        /// <param name="useLimit"></param>
        /// <returns></returns>
        public int LargestValsFromLabels2(int[] values, int[] labels, int numWanted, int useLimit)
        {
            int len = values.Length;
            int[] index = new int[len]; for (int i = 0; i < len; i++) index[i] = i;
            Array.Sort(index, (i, j) => values[j] - values[i]);

            int result = 0, id = -1, _id;
            Dictionary<int, int> use = new Dictionary<int, int>();
            while (numWanted > 0 && ++id < len)
            {
                _id = index[id];
                if (use.ContainsKey(labels[_id]))
                {
                    if (use[labels[_id]] < useLimit)
                    {
                        result += values[_id]; numWanted--; use[labels[_id]]++;
                    }
                }
                else
                {
                    result += values[_id]; numWanted--; use.Add(labels[_id], 1);
                }
            }

            return result;
        }
    }
}
