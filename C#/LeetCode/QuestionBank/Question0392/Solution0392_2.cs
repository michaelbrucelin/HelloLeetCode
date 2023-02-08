using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0392
{
    public class Solution0392_2 : Interface0392
    {
        /// <summary>
        /// 预处理
        /// 进阶中提到由大量个s需要检查是否是t的子序列，很容易想到的就是像KMP那样提前预处理出来一个“数据”，来给双指针提速
        /// 这里构造这样的数据结构：Dictionary<char, List<int>>，记录t中每一个字符从前向后出现的索引位置
        ///     例如：t = "abcabbcabc"  { a:[0,3,7], b:[1,4,5,8], c:[2,6,9] }
        ///                0123456789
        /// 这样使用二分法可以迅速的找出每一个字符的下一个位置
        /// 
        /// 也可以构造：Dictionary<char, Stack<int>>，但是每次查询都需要重复复制出来一份这个数据，这里就不写了
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool IsSubsequence(string s, string t)
        {
            Dictionary<char, List<int>> dic = new Dictionary<char, List<int>>();
            for (int i = 0; i < t.Length; i++)
            {
                char c = t[i];
                if (dic.ContainsKey(c)) dic[c].Add(i); else dic.Add(c, new List<int>() { i });
            }

            for (int i = 0, pre = -1; i < s.Length; i++)
            {
                char c = s[i];
                if (!dic.ContainsKey(c)) return false;
                int id = BinarySearch(dic[c], pre);
                if (id != -1) pre = id; else return false;
            }

            return true;
        }

        private int BinarySearch(List<int> list, int target)
        {
            int result = -1, low = 0, high = list.Count - 1, mid;
            while (low <= high)
            {
                mid = low + ((high - low) >> 1);
                if (list[mid] > target)
                {
                    result = list[mid]; high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }

            return result;
        }
    }
}
