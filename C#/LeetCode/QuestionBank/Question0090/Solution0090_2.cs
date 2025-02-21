using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0090
{
    public class Solution0090_2 : Interface0090
    {
        /// <summary>
        /// 二进制枚举 + 标志位
        /// 逻辑同Solution0090，将BFS改为二进制枚举
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            IList<IList<int>> result = [[]];
            HashSet<string> set = new() { "" };
            int sup = 1 << nums.Length;
            List<int> item; string flag;
            for (int i = 0, mask = 0, j = 0; i < sup; i++)
            {
                item = new List<int>();
                mask = i; j = 0;
                while (mask > 0)
                {
                    if ((mask & 1) == 1) item.Add(nums[j]);
                    mask >>= 1; j++;
                }
                flag = ArrayFlag(item);
                if (!set.Contains(flag))
                {
                    result.Add(item); set.Add(flag);
                }
            }

            return result;

            string ArrayFlag(List<int> nums)
            {
                if (nums.Count == 0) return "";

                nums.Sort();
                StringBuilder sb = new StringBuilder();
                foreach (int num in nums) sb.Append($"{num},");

                return sb.ToString();
            }
        }

        /// <summary>
        /// 逻辑同SubsetsWithDup()，预先排序数组，计算flag时就不需要再次排序
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> SubsetsWithDup2(int[] nums)
        {
            IList<IList<int>> result = [[]];
            HashSet<string> set = new() { "" };
            Array.Sort(nums);
            int sup = 1 << nums.Length;
            List<int> item; string flag;
            for (int i = 0, mask = 0, j = 0; i < sup; i++)
            {
                item = new List<int>();
                mask = i; j = 0;
                while (mask > 0)
                {
                    if ((mask & 1) == 1) item.Add(nums[j]);
                    mask >>= 1; j++;
                }
                flag = ArrayFlag(item);
                if (!set.Contains(flag))
                {
                    result.Add(item); set.Add(flag);
                }
            }

            return result;

            string ArrayFlag(List<int> nums)
            {
                if (nums.Count == 0) return "";

                StringBuilder sb = new StringBuilder();
                foreach (int num in nums) sb.Append($"{num},");

                return sb.ToString();
            }
        }
    }
}
