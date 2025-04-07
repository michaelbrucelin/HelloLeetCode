using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0416
{
    public class Solution0416_3 : Interface0416
    {
        /// <summary>
        /// BFS
        /// 排列组合
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool CanPartition(int[] nums)
        {
            int len = nums.Length, sum = 0;
            for (int i = 0; i < len; i++) sum += nums[i];
            if ((sum & 1) != 0) return false;

            sum >>= 1;
            HashSet<int> set = new HashSet<int>();
            List<int> list = new List<int>();
            for (int i = 0, num = -1, cnt = -1; i < len; i++)
            {
                num = nums[i];
                if (num == sum || set.Contains(sum - num)) return true;
                cnt = list.Count;
                for (int j = 0, add = -1; j < cnt; j++)
                {
                    add = num + list[j];
                    if (!set.Contains(add)) { list.Add(add); set.Add(add); }
                }
                if (!set.Contains(num)) { list.Add(num); set.Add(num); }
            }

            return false;
        }
    }
}
