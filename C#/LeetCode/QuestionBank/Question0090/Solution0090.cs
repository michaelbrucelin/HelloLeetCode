using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0090
{
    public class Solution0090 : Interface0090
    {
        /// <summary>
        /// BFS + 标志位
        /// 标志位 = 数组排序后拼接字符串
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public IList<IList<int>> SubsetsWithDup(int[] nums)
        {
            IList<IList<int>> result = [[]];
            HashSet<string> set = new() { "" };
            List<int> item; string flag;
            foreach (int num in nums) for (int i = 0, cnt = result.Count; i < cnt; i++)
                {
                    item = new List<int>(result[i]) { num };
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
            List<int> item; string flag;
            foreach (int num in nums) for (int i = 0, cnt = result.Count; i < cnt; i++)
                {
                    item = new List<int>(result[i]) { num };
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
