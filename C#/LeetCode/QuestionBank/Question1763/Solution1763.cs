using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1763
{
    public class Solution1763 : Interface1763
    {
        /// <summary>
        /// DFS，分治
        /// 1. 找出字符串中不美好的字符，以这些字符为分隔符将字符串拆分成更多的字符串
        /// 2. 然后在拆分出来的子字符串继续上面的步骤
        /// 辅助数据结构
        /// int[2,26]      第1维：大写存不存在，存在为1，不存在为0
        ///                第2维：小写存不存在，存在为1，不存在为0
        ///                第1维与第2维的位置异或一下就知道这个字母是不是“美好”的了
        /// List<int>[26]  字母出现的索引，大小写记录在一起
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public string LongestNiceSubstring(string s)
        {
            string result = string.Empty;
            dfs(s, 0, s.Length - 1, ref result);

            return result;
        }

        private void dfs(string s, int left, int right, ref string result)
        {
            if (left > right || right - left + 1 <= result.Length) return;

            int[,] mask = new int[2, 27];
            List<int>[] ids = new List<int>[27];
            for (int i = 1; i < 27; i++) ids[i] = new List<int>();

            for (int i = left; i <= right; i++)
            {
                mask[(s[i] >> 5) & 1, s[i] & 31] = 1;
                ids[s[i] & 31].Add(i);
            }

            List<int> set = new List<int>();
            for (int i = 1; i < 27; i++)
            {
                if (mask[0, i] != mask[1, i])
                    for (int j = 0; j < ids[i].Count; j++) set.Add(ids[i][j]);
            }

            if (set.Count == 0)
            {
                if (right - left + 1 > result.Length) result = s.Substring(left, right - left + 1);
            }
            else
            {
                dfs(s, left, set[0] - 1, ref result);
                for (int i = 0; i + 1 < set.Count; i++) dfs(s, set[i] + 1, set[i + 1] - 1, ref result);
                dfs(s, set[set.Count - 1] + 1, right, ref result);
            }
        }
    }
}
