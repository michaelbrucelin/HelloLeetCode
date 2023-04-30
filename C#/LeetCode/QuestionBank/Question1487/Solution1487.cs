using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1487
{
    public class Solution1487 : Interface1487
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="names"></param>
        /// <returns></returns>
        public string[] GetFolderNames(string[] names)
        {
            int len = names.Length;
            string[] result = new string[len];
            Dictionary<string, int> buffer = new Dictionary<string, int>();
            string _name; int _i; for (int i = 0; i < len; i++)
            {
                _name = names[i];
                if (!buffer.ContainsKey(_name))
                {
                    result[i] = _name; buffer.Add(_name, 1);
                }
                else
                {
                    _i = buffer[_name]; while (buffer.ContainsKey($"{_name}({_i})")) _i++;
                    result[i] = $"{_name}({_i})"; buffer.Add($"{_name}({_i})", 1); buffer[_name] = _i + 1;
                }
            }

            return result;
        }
    }
}
