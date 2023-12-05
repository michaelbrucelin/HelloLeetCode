using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1238
{
    public class Solution1238_err : Interface1238
    {
        /// <summary>
        /// 数学，找规律
        /// 构建的方式见Solution1238.md
        /// 
        /// 题目理解错了，是相邻两个数字的二进制表示只有1位不同，而不是相邻二进制表示中的1的数量相差1
        /// </summary>
        /// <param name="n"></param>
        /// <param name="start"></param>
        /// <returns></returns>
        public IList<int> CircularPermutation(int n, int start)
        {
            Dictionary<int, Queue<int>> helper = new Dictionary<int, Queue<int>>();
            int max = (1 << n), cnt;
            for (int i = start; i < max; i++)  // 为了保证下面第一个出队列的是start
            {
                cnt = BitCount(i); helper.TryAdd(cnt, new Queue<int>()); helper[cnt].Enqueue(i);
            }
            for (int i = 0; i < start; i++)
            {
                cnt = BitCount(i); helper.TryAdd(cnt, new Queue<int>()); helper[cnt].Enqueue(i);
            }

            List<int> result = new List<int>();
            int direction = 1, key = BitCount(start);
            while (true)
            {
                result.Add(helper[key].Dequeue());
                if (helper[key].Count == 0) helper.Remove(key);
                if (helper.ContainsKey(key + direction))
                {
                    key += direction;
                }
                else
                {
                    direction *= -1;
                    if (helper.ContainsKey(key + direction))
                        key += direction;
                    else
                        break;
                }
            }

            return result;
        }

        private int BitCount(int n)
        {
            int result = 0;

            while (n > 0)
            {
                result++; n &= n - 1;
            }

            return result;
        }
    }
}
