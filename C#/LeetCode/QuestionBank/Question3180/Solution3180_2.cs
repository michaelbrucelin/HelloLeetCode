using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3180
{
    public class Solution3180_2 : Interface3180
    {
        /// <summary>
        /// 排序 + BFS
        /// 类似于计算所有的组合，大概率会MLE
        /// 
        /// 提交没有MLE，通过了
        /// </summary>
        /// <param name="rewardValues"></param>
        /// <returns></returns>
        public int MaxTotalReward(int[] rewardValues)
        {
            Array.Sort(rewardValues);
            HashSet<int> set = new HashSet<int>() { 0 }, _set = new HashSet<int>();
            foreach (int val in rewardValues)
            {
                _set.Clear();
                foreach (int _val in set) if (val > _val) _set.Add(val + _val);
                set.UnionWith(_set);
            }

            return set.Max();
        }
    }
}
