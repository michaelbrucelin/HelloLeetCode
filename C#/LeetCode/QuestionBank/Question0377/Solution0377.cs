using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0377
{
    public class Solution0377 : Interface0377
    {
        /// <summary>
        /// BFS
        /// 逻辑没问题，OLE，参考测试用例03
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int CombinationSum4(int[] nums, int target)
        {
            int result = 0;
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(0);
            int item;
            while (queue.Count > 0)
            {
                item = queue.Dequeue();
                foreach (int num in nums) switch (item + num - target)
                    {
                        case 0: result++; break;
                        case < 0: queue.Enqueue(item + num); break;
                        default: break;
                    }
            }

            return result;
        }

        /// <summary>
        /// 逻辑同CombinationSum4()，将Queue换成Map来优化空间复杂度
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int CombinationSum42(int[] nums, int target)
        {
            int result = 0;
            Dictionary<int, int> queue = new Dictionary<int, int>() { { 0, 1 } }, _queue;
            while (queue.Count > 0)
            {
                _queue = new Dictionary<int, int>();
                foreach (var kv in queue) foreach (int num in nums) switch (kv.Key + num - target)
                        {
                            case 0: result += kv.Value; break;
                            case < 0:
                                _queue.TryAdd(kv.Key + num, 0); _queue[kv.Key + num] += kv.Value;
                                break;
                            default: break;
                        }
                queue = _queue;
            }

            return result;
        }
    }
}
