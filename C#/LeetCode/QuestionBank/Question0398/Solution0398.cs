using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0398
{
    public class Solution0398
    {
    }

    /// <summary>
    /// 字典
    /// </summary>
    public class Solution : Interface0398
    {
        public Solution(int[] nums)
        {
            db = new Dictionary<int, List<int>>();
            random = new Random();
            int len = nums.Length;
            for (int i = 0, num; i < len; i++)
            {
                num = nums[i];
                if (db.TryGetValue(num, out List<int> list)) list.Add(i); else db.Add(num, [i]);
            }
        }

        private Dictionary<int, List<int>> db;
        private Random random;

        public int Pick(int target)
        {
            return db[target][random.Next(0, db[target].Count)];
        }
    }
}
