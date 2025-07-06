using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0071
{
    public class Solution0071 : Interface0071
    {
        /// <summary>
        /// 从前向后逐级解析
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string SimplifyPath(string path)
        {
            string[] dirs = path.Split('/', StringSplitOptions.RemoveEmptyEntries);
            List<int> list = new List<int>();
            int len = dirs.Length;
            for (int i = 0; i < len; i++) switch (dirs[i])
                {
                    case "/": break;
                    case ".": break;
                    case "..": if (list.Count > 0) list.RemoveAt(list.Count - 1); break;
                    default: list.Add(i); break;
                }

            StringBuilder sb = new StringBuilder();
            foreach (int id in list) sb.Append($"/{dirs[id]}");

            return sb.Length == 0 ? "/" : sb.ToString();
        }
    }
}
