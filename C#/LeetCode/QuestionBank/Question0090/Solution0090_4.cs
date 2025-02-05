using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0090
{
    public class Solution0090_4 : Interface0090
    {
        /// <summary>
        /// 排列组合
        /// 将相同的数字先组合，然后针对这些组合再组合
        /// [1,2,2,3,3,3]
        /// [], [1], [2] [2,2], [3] [3,3] [3,3,3]
        /// 从Solution0090到Solution0090_3，基本没有优化效果，数学优化才是降维打击，数学才是算法的精髓
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            Dictionary<int, int> freq = new Dictionary<int, int>();
            foreach (int num in nums) if (freq.ContainsKey(num)) freq[num]++; else freq.Add(num, 1);

            IList<IList<int>> result = [[]];
            List<int> item;
            foreach (var kv in freq) for (int i = 0, cnt = result.Count; i < cnt; i++)
                {
                    item = new List<int>(result[i]);
                    for (int j = 0; j < kv.Value; j++)
                    {
                        item.Add(kv.Key);
                        result.Add(item.ToList());
                    }
                }

            return result;
        }

        /// <summary>
        /// 逻辑同SubsetsWithDup()，将字典改为数组
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> SubsetsWithDup2(int[] nums)
        {
            int[] freq = new int[21];
            foreach (int num in nums) freq[num + 10]++;

            IList<IList<int>> result = [[]];
            List<int> item;
            for (int id = 0, num = -10; id < 21; id++, num++) if (freq[id] > 0) for (int i = 0, cnt = result.Count; i < cnt; i++)
                    {
                        item = new List<int>(result[i]);
                        for (int j = 0; j < freq[id]; j++)
                        {
                            item.Add(num);
                            result.Add(item.ToList());
                        }
                    }

            return result;
        }
    }
}
