using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2456
{
    public class Solution2456 : Interface2456
    {
        /// <summary>
        /// Hash
        /// </summary>
        /// <param name="creators"></param>
        /// <param name="ids"></param>
        /// <param name="views"></param>
        /// <returns></returns>
        public IList<IList<string>> MostPopularCreator(string[] creators, string[] ids, int[] views)
        {
            Dictionary<string, (long, string, int)> map = new Dictionary<string, (long, string, int)>();
            int len = ids.Length;
            for (int i = 0; i < len; i++)
            {
                if (map.TryGetValue(creators[i], out var val))
                {
                    switch (views[i] - val.Item3)
                    {
                        case > 0: map[creators[i]] = (val.Item1 + views[i], ids[i], views[i]); break;
                        case < 0: map[creators[i]] = (val.Item1 + views[i], val.Item2, val.Item3); break;
                        default: map[creators[i]] = (val.Item1 + views[i], (string.CompareOrdinal(val.Item2, ids[i]) <= 0 ? val.Item2 : ids[i]), val.Item3); break;
                    }
                }
                else
                {
                    map.Add(creators[i], (views[i], ids[i], views[i]));
                }
            }

            IList<IList<string>> result = new List<IList<string>>();
            long max = -1;
            foreach (string creator in map.Keys) switch (map[creator].Item1 - max)
                {
                    case > 0:
                        max = map[creator].Item1;
                        result.Clear();
                        result.Add([creator, map[creator].Item2]);
                        break;
                    case < 0:
                        break;
                    default:
                        result.Add([creator, map[creator].Item2]);
                        break;
                }

            return result;
        }
    }
}
