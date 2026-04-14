using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1451
{
    public class Solution1451 : Interface1451
    {
        /// <summary>
        /// 双指针 + 自定义排序
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string ArrangeWords(string text)
        {
            List<(string, int)> buffer = [];
            int p1 = 0, p2 = 0, id = 0, len = text.Length;
            while (p1 < len)
            {
                while (p2 < len && text[p2] != ' ') p2++;
                buffer.Add((text[p1..p2], id++));
                p1 = ++p2;
            }
            buffer.Sort((x, y) => x.Item1.Length != y.Item1.Length ? x.Item1.Length - y.Item1.Length : x.Item2 - y.Item2);

            int cnt = buffer.Count;
            StringBuilder sb = new StringBuilder();
            sb.Append(buffer[0].Item1[0].ToString().ToUpper());
            sb.Append(buffer[0].Item1[1..]);
            for (int i = 1; i < cnt; i++) sb.Append($" {buffer[i].Item1.ToLower()}");

            return sb.ToString();
        }
    }
}
