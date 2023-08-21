using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2337
{
    public class Solution2337 : Interface2337
    {
        /// <summary>
        /// 模拟
        /// 具体分析见Solution2337.md
        /// 
        /// 逻辑没问题，国际版提交通过了，国内版提交TLE，而且没有打印出超时的测试用例
        /// </summary>
        /// <param name="start"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public bool CanChange(string start, string target)
        {
            int len = target.Length;
            char[] chars = start.ToCharArray();
            for (int i = 0, j; i < len; i++)
            {
                if (chars[i] == target[i]) continue;
                switch ((chars[i], target[i]))
                {
                    case ('L', 'R'):
                    case ('R', 'L'):
                    case ('L', '_'):
                    case ('_', 'R'): return false;
                    case ('_', 'L'):
                        j = i; while (++j < len) if (chars[j] == 'L') break; else if (chars[j] == 'R') return false;
                        if (j == len) return false;
                        Swap(chars, i, j);
                        break;
                    case ('R', '_'):
                        j = i; while (++j < len) if (chars[j] == '_') break; else if (chars[j] == 'L') return false;
                        if (j == len) return false;
                        Swap(chars, i, j);
                        break;
                    default:
                        break;
                }
            }

            return true;
        }

        private void Swap(char[] chars, int i, int j)
        {
            chars[i] = (char)(chars[i] ^ chars[j]);
            chars[j] = (char)(chars[i] ^ chars[j]);
            chars[i] = (char)(chars[i] ^ chars[j]);
        }
    }
}
