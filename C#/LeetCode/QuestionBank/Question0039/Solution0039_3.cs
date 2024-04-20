using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0039
{
    public class Solution0039_3 : Interface0039
    {
        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="candidates"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            List<IList<int>> result = new List<IList<int>>();

            Array.Sort(candidates);
            HashSet<string> visited = new HashSet<string>();
            Queue<(List<int> list, int sum)> queue = new Queue<(List<int> list, int sum)>();
            queue.Enqueue((new List<int>(), 0));
            (List<int> list, int sum) item; int _sum; List<int> _list;
            while (queue.Count > 0)
            {
                item = queue.Dequeue();
                foreach (int candidate in candidates)
                {
                    if ((_sum = item.sum + candidate) > target) break;
                    _list = new List<int>(item.list) { candidate };
                    if (_sum == target)
                        result.Add(new List<int>(item.list) { candidate });
                    else
                        queue.Enqueue((_list, _sum));
                }
            }

            return result.DistinctBy(x => string.Join(',', x.OrderBy(x => x))).ToList();
        }
    }
}
