using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2456
{
    public class Solution2456_err : Interface2456
    {
        /// <summary>
        /// Hash
        /// 
        /// 题目求的是字典序最小的id，这里是id（索引）最小的id
        /// </summary>
        /// <param name="creators"></param>
        /// <param name="ids"></param>
        /// <param name="views"></param>
        /// <returns></returns>
        public IList<IList<string>> MostPopularCreator(string[] creators, string[] ids, int[] views)
        {
            Dictionary<string, (int, string, int)> map = new Dictionary<string, (int, string, int)>();
            int len = ids.Length;
            for (int i = 0; i < len; i++)
            {
                if (map.TryGetValue(creators[i], out var val))
                {
                    if (views[i] > val.Item3)
                    {
                        map[creators[i]] = (val.Item1 + views[i], ids[i], views[i]);
                    }
                    else
                    {
                        map[creators[i]] = (val.Item1 + views[i], val.Item2, val.Item3);
                    }
                }
                else
                {
                    map.Add(creators[i], (views[i], ids[i], views[i]));
                }
            }

            IList<IList<string>> result = new List<IList<string>>();
            int max = -1;
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
