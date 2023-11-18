using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1436
{
    public class Solution1436_2 : Interface1436
    {
        /// <summary>
        /// 注意，只有一条线路，所以无论从起点开始，还是中途上路，都到达同一个终点
        /// </summary>
        /// <param name="paths"></param>
        /// <returns></returns>
        public string DestCity(IList<IList<string>> paths)
        {
            HashSet<string> start = new HashSet<string>(), end = new HashSet<string>();
            foreach (var path in paths)
            {
                start.Add(path[0]); end.Remove(path[0]);
                if (!start.Contains(path[1])) end.Add(path[1]);
            }

            return end.First();
        }
    }
}
