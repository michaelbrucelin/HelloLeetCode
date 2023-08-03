using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0722
{
    public class Solution0722_2 : Interface0722
    {
        /// <summary>
        /// 逻辑与Solution0722一样，但是不提前把所有行拼接为一个大字符串，而是借助C#的迭代器操作字符串数组
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public IList<string> RemoveComments(string[] source)
        {
            List<string> result = new List<string>();
            StringBuilder line = new StringBuilder();
            var iterator = GetCharFromStrArr(source).GetEnumerator();
            while (iterator.MoveNext())
            {
                switch (iterator.Current)
                {
                    case '\n':
                        if (line.Length > 0) { result.Add(line.ToString()); line.Clear(); }
                        break;
                    case '/':
                        char last = '/';
                        if (iterator.MoveNext()) switch (iterator.Current)
                            {
                                case '/':
                                    if (line.Length > 0) { result.Add(line.ToString()); line.Clear(); }
                                    while (iterator.Current != '\n') iterator.MoveNext();
                                    break;
                                case '*':
                                    bool flag = false;
                                    while (iterator.MoveNext())
                                    {
                                        if (flag && iterator.Current == '/') break; else flag = iterator.Current == '*';
                                    }
                                    break;
                                case '\n':
                                    line.Append(last); result.Add(line.ToString()); line.Clear();
                                    break;
                                default:
                                    line.Append(last); line.Append(iterator.Current);
                                    break;
                            }
                        else line.Append(last);
                        break;
                    default:
                        line.Append(iterator.Current);
                        break;
                }
            }

            return result;
        }

        private IEnumerable<char> GetCharFromStrArr(string[] strs)
        {
            for (int i = 0; i < strs.Length; i++)
            {
                for (int j = 0; j < strs[i].Length; j++)
                    yield return strs[i][j];
                yield return '\n';
            }
        }
    }
}
