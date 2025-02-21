using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1349
{
    public class Solution1349 : Interface1349
    {
        /// <summary>
        /// DP
        /// 思路：每一行都是暴力解，行与行之间DP
        /// 1. 每一行如何暴力？
        ///     由于每一行不超过8个座位，所以一行的所有状态可以由一个int位图表示
        ///     每一行声明一个坏座位的掩码（即坏椅子位置为1，其余位置为0），这样对于每一个状态，与掩码与运算可以O(1)计算出坏座位是否安排了人
        ///     每一个状态，可以O(m)计算出有没有相邻座位坐人
        ///     每一个状态，可以快速算出一共坐了多少个人（计算二进制中1的个数）
        /// 2. 行与行之间如何DP？
        ///     第k行，如果k > 0，除了按照上面的暴力计算过程外，还需要考虑每个人左前方与右前方没有坐人时，上一行最多坐了多少人
        /// </summary>
        /// <param name="seats"></param>
        /// <returns></returns>
        public int MaxStudents(char[][] seats)
        {
            int rcnt = seats.Length, ccnt = seats[0].Length;
            int[] masks = new int[rcnt];
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++) { masks[r] <<= 1; if (seats[r][c] == '#') masks[r] |= 1; }

            int len = 1 << ccnt;
            int[] dp = new int[len], _dp = new int[len];
            (bool isTrue, int cnt) r_state;

            // 第一行
            Array.Fill(dp, -1);
            for (int state = 0; state < len; state++)
            {
                if ((state & masks[0]) > 0 || !(r_state = Verify(state)).isTrue) continue;
                dp[state] = r_state.cnt;
            }
            // 第二行至最后一行
            for (int r = 1, _mask = 0, _result = 0; r < rcnt; r++)
            {
                Array.Fill(_dp, -1);
                for (int state = 0; state < len; state++)
                {
                    if ((state & masks[r]) > 0 || !(r_state = Verify(state)).isTrue) continue;
                    _mask = masks[r - 1]; _mask |= state << 1; _mask |= state >> 1;             // 上一行针对当前状态的掩码
                    _result = r_state.cnt;
                    for (int _state = 0; _state < len; _state++)
                    {
                        if ((_state & _mask) > 0) continue;
                        _result = Math.Max(_result, r_state.cnt + dp[_state]);
                    }
                    _dp[state] = _result;
                }
                Array.Copy(_dp, dp, len);
            }

            return dp.Max();
        }

        /// <summary>
        /// 验证一行中：1. 有没有安排相邻的座位； 2. 一共安排了多少个座位
        /// </summary>
        /// <returns></returns>
        private (bool isTrue, int cnt) Verify(int state)
        {
            bool flag = false; int cnt = 0;
            while (state > 0)
            {
                if ((state & 1) == 1)
                {
                    if (flag) return (false, -1);
                    flag = true; cnt++;
                }
                else
                {
                    flag = false;
                }
                state >>= 1;
            }
            return (true, cnt);
        }
    }
}
