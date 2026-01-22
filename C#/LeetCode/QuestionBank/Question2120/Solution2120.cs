using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2120
{
    public class Solution2120 : Interface2120
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="n"></param>
        /// <param name="startPos"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public int[] ExecuteInstructions(int n, int[] startPos, string s)
        {
            Dictionary<char, (int, int)> move = new Dictionary<char, (int, int)> { { 'L', (0, -1) }, { 'R', (0, 1) }, { 'U', (-1, 0) }, { 'D', (1, 0) } };
            int len = s.Length;
            int[] result = new int[len];
            for (int i = 0, r, c; i < len; i++)
            {
                (r, c) = (startPos[0], startPos[1]);
                for (int j = i; j < len; j++)
                {
                    r += move[s[j]].Item1; c += move[s[j]].Item2;
                    if (r >= 0 && r < n && c >= 0 && c < n) result[i]++; else break;
                }
            }

            return result;
        }

        /// <summary>
        /// 逻辑完全同ExecuteInstructions()，将Hash改为数组
        /// 数次测试证明，数组的速度还是远远大于Hash的速度
        /// </summary>
        /// <param name="n"></param>
        /// <param name="startPos"></param>
        /// <param name="s"></param>
        /// <returns></returns>
        public int[] ExecuteInstructions2(int n, int[] startPos, string s)
        {
            (int, int)[] move = new (int, int)[18];
            move['L' - 'D'] = (0, -1);
            move['R' - 'D'] = (0, 1);
            move['U' - 'D'] = (-1, 0);
            move['D' - 'D'] = (1, 0);
            int len = s.Length;
            int[] result = new int[len];
            for (int i = 0, r, c; i < len; i++)
            {
                (r, c) = (startPos[0], startPos[1]);
                for (int j = i; j < len; j++)
                {
                    r += move[s[j] - 'D'].Item1; c += move[s[j] - 'D'].Item2;
                    if (r >= 0 && r < n && c >= 0 && c < n) result[i]++; else break;
                }
            }

            return result;
        }
    }
}
