using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0518
{
    public class Solution0518 : Interface0518
    {
        /// <summary>
        /// BFS
        /// 将数组序列化为字符串来去除重复的组合
        /// 效率不高，容易MLE，可以考虑DFS+回溯来优化空间复杂度
        /// 本质上就是求排列组合中的组合
        /// 
        /// 逻辑没问题，还没MLE，先TLE了，参考测试用例04
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="coins"></param>
        /// <returns></returns>
        public int Change(int amount, int[] coins)
        {
            if (amount == 0) return 1;

            HashSet<string> result = new HashSet<string>();
            HashSet<string> visited = new HashSet<string>();
            Array.Sort(coins);
            Queue<(int amount, int[] key)> queue = new Queue<(int amount, int[] key)>();
            int len = coins.Length, cnt, _amount; string _visit;
            queue.Enqueue((0, new int[len])); visited.Add(string.Join(',', queue.Peek().key));
            (int amount, int[] key) item;
            while ((cnt = queue.Count) > 0) for (int i = 0; i < cnt; i++)
                {
                    item = queue.Dequeue();
                    for (int j = 0; j < len; j++)
                    {
                        _amount = item.amount + coins[j];
                        if (_amount < amount)
                        {
                            int[] _key = item.key.ToArray();
                            _key[j]++;
                            if (!visited.Contains(_visit = string.Join(',', _key)))
                            {
                                queue.Enqueue((_amount, _key)); visited.Add(_visit);
                            }
                        }
                        else
                        {
                            item.key[j]++;
                            if (_amount == amount) result.Add(string.Join(',', item.key));
                            break;
                        }
                    }
                }

            return result.Count;
        }
    }
}
