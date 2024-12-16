using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1847
{
    public class Solution1847_err : Interface1847
    {
        /// <summary>
        /// 暴力查找
        /// 按照题目的数据量，大概率会TLE，先写出来，然后再优化
        /// 
        /// 题目理解错了，roomid不是连续的，这里假定roomid是从1开始连续的值了
        /// </summary>
        /// <param name="rooms"></param>
        /// <param name="queries"></param>
        /// <returns></returns>
        public int[] ClosestRoom(int[][] rooms, int[][] queries)
        {
            int rlen = rooms.Length, qlen = queries.Length;
            int[] result = new int[qlen];
            // Array.Fill(result, -1);
            for (int i = 0, cnt, prefer, size; i < qlen; i++)
            {
                result[i] = -1; prefer = queries[i][0] - 1; size = queries[i][1];
                if (prefer >= rlen)
                {
                    for (int j = rlen - 1; j >= 0; j--) if (rooms[j][1] >= size)
                        {
                            result[i] = j + 1; break;
                        }
                }
                else
                {
                    if (rooms[prefer][1] >= size)
                    {
                        result[i] = prefer + 1;
                    }
                    else
                    {
                        cnt = Math.Max(prefer, rlen - prefer);
                        for (int j = 1, _j; j <= cnt; j++)
                        {
                            if ((_j = prefer - j) >= 0)
                            {
                                if (rooms[_j][1] >= size) { result[i] = _j + 1; break; }
                            }
                            if ((_j = prefer + j) < rlen)
                            {
                                if (rooms[_j][1] >= size) { result[i] = _j + 1; break; }
                            }
                        }
                    }
                }
            }

            return result;
        }
    }
}
