using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0821
{
    public class Solution0821 : Interface0821
    {
        /// <summary>
        /// 分析
        /// 1. 先遍历一次获取s中全部c的位置，放入数组pos中
        /// 2. 一个指针遍历s，一个指针遍历pos即可
        /// </summary>
        /// <param name="s"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public int[] ShortestToChar(string s, char c)
        {
            int len = s.Length;
            List<int> pos = new List<int>() { -len - 1 };
            for (int i = 0; i < len; i++) if (s[i] == c) pos.Add(i);
            pos.Add((len << 1) + 1);

            int[] result = new int[len];
            for (int i = 0, j = 1; i < len; i++)  // i遍历s，j遍历pos
            {
                if (i < pos[j])
                {
                    result[i] = Math.Min(i - pos[j - 1], pos[j] - i);
                }
                else  // if (i == pos[j])
                {
                    result[i] = 0; j++;
                }
            }

            return result;
        }

        /// <summary>
        /// 本质上ShortestToChar()一样，都是先获取pos
        /// 但是既然有了pos数组，就可以直接构造出结果数组，而不需要每一个位置都去判断
        /// </summary>
        /// <param name="s"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public int[] ShortestToChar2(string s, char c)
        {
            int len = s.Length;
            List<int> pos = new List<int>();
            for (int i = 0; i < len; i++) if (s[i] == c) pos.Add(i);

            int[] result = new int[len];
            for (int i = 0; i < pos[0]; i++) result[i] = pos[0] - i;
            for (int j = 0, l, r; j < pos.Count - 1; j++)
            {
                l = pos[j]; r = pos[j + 1];
                while (l <= r)
                {
                    result[l] = l - pos[j]; l++;
                    result[r] = pos[j + 1] - r; r--;
                }
            }
            for (int i = pos[^1] + 1; i < len; i++) result[i] = i - pos[^1];

            return result;
        }
    }
}
