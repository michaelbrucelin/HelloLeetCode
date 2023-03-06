using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2062
{
    public class Solution2062_2 : Interface2062
    {
        /// <summary>
        /// 前缀和
        /// 预处理5个元音以及非元音的前缀和
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        public int CountVowelSubstrings(string word)
        {
            int result = 0, len = word.Length;
            Dictionary<char, int> map = new Dictionary<char, int>() { { 'a', 1 }, { 'e', 2 }, { 'i', 3 }, { 'o', 4 }, { 'u', 5 } };
            int[,] pre = new int[6, len + 1];

            int _r; for (int i = 0; i < len; i++)
            {
                _r = map.ContainsKey(word[i]) ? map[word[i]] : 0;
                for (int j = 0; j < 6; j++)
                {
                    pre[j, i + 1] = pre[j, i] + (j != _r ? 0 : 1);
                }
            }

            for (int i = 0; i < len - 4; i++) for (int j = i + 4; j < len; j++)
                {
                    if (pre[0, j + 1] - pre[0, i] == 0
                        && pre[1, j + 1] - pre[1, i] > 0
                        && pre[2, j + 1] - pre[2, i] > 0
                        && pre[3, j + 1] - pre[3, i] > 0
                        && pre[4, j + 1] - pre[4, i] > 0
                        && pre[5, j + 1] - pre[5, i] > 0) result++;
                }

            return result;
        }
    }
}
