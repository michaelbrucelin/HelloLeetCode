using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0041
{
    public class Solution0041 : Interface0041
    {
        /// <summary>
        /// 位图
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FirstMissingPositive(int[] nums)
        {
            List<long> maps = [];
            foreach (int num in nums) setmap(num);
            int result = 0;
            while (checkmap(++result)) ;
            return result;

            void setmap(int x)
            {
                if (x <= 0) return;
                int id = x / 64, offset = x % 64;
                while (maps.Count <= id) maps.Add(0L);
                maps[id] |= 1L << offset;
            }

            bool checkmap(int x)
            {
                if (x <= 0) return false;
                int id = x / 64;
                if (id >= maps.Count) return false;
                int offset = x % 64;
                return ((maps[id] >> offset) & 1) == 1;
            }
        }

        /// <summary>
        /// 离散版
        /// 逻辑同FirstMissingPositive()，将列表换成字典
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int FirstMissingPositive2(int[] nums)
        {
            Dictionary<int, long> maps = new Dictionary<int, long>();
            foreach (int num in nums) setmap(num);
            int result = 0;
            while (checkmap(++result)) ;
            return result;

            void setmap(int x)
            {
                if (x <= 0) return;
                int id = x / 64, offset = x % 64;
                if (!maps.ContainsKey(id)) maps.Add(id, 1L << offset); else maps[id] |= 1L << offset;
            }

            bool checkmap(int x)
            {
                if (x <= 0) return false;
                int id = x / 64;
                if (!maps.ContainsKey(id)) return false;
                int offset = x % 64;
                return ((maps[id] >> offset) & 1) == 1;
            }
        }
    }
}
