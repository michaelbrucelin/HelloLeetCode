using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1092
{
    public class Solution1092 : Interface1092
    {
        /// <summary>
        /// 分析
        /// 本质上就是把str1中的字符按顺序插入到str2中，具体见Solution1092.md
        /// 
        /// 逻辑是错误的，参考测试用例5
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        public string ShortestCommonSupersequence(string str1, string str2)
        {
            string r1 = _ShortestCommonSupersequence(str1, str2);
            string r2 = _ShortestCommonSupersequence(str2, str1);

            return r1.Length <= r2.Length ? r1 : r2;
        }
        private string _ShortestCommonSupersequence(string str1, string str2)
        {
            // if (str1.Length > str2.Length) (str1, str2) = (str2, str1);  // 小驱动大
            int len1 = str1.Length, len2 = str2.Length;
            List<int>[] pos = new List<int>[26];
            for (int i = 0; i < 26; i++) pos[i] = new List<int>();
            for (int i = 0; i < len2; i++) pos[str2[i] - 'a'].Add(i);

            string result = $"{str1}{str2}";
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < len1; i++)
            {
                sb.Clear(); sb.Append(str1[0..i]);
                int p1 = i, p2 = 0, _p2; for (; p1 < len1 && p2 < len2; p1++)
                {
                    _p2 = FindNextPos(pos[str1[p1] - 'a'], p2);
                    if (_p2 != -1)
                    {
                        sb.Append(str2[p2..(_p2 + 1)]); p2 = _p2 + 1;
                    }
                    else
                    {
                        sb.Append(str1[p1]);
                    }
                }
                if (p1 < len1) sb.Append(str1[p1..]);
                if (p2 < len2) sb.Append(str2[p2..]);
                if (sb.Length < result.Length) result = sb.ToString();
            }

            return result;
        }

        private int FindNextPos(List<int> list, int target)
        {
            int result = -1, left = 0, right = list.Count - 1, mid;
            while (left <= right)
            {
                mid = left + ((right - left) >> 1);
                if (list[mid] >= target)
                {
                    result = list[mid]; right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return result;
        }
    }
}
