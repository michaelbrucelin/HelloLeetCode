using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview1619
{
    public class Solution1619 : Interface1619
    {
        /// <summary>
        /// BFS
        /// </summary>
        /// <param name="land"></param>
        /// <returns></returns>
        public int[] PondSizes(int[][] land)
        {
            List<int> result = new List<int>();
            Queue<(int r, int c)> queue = new Queue<(int r, int c)>();
            int rcnt = land.Length, ccnt = land[0].Length, cnt, size;
            (int r, int c) pos;
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++)
                {
                    if (land[r][c] != 0) continue;
                    size = 0;
                    queue.Enqueue((r, c));
                    while ((cnt = queue.Count) > 0)
                    {
                        for (int i = 0; i < cnt; i++)
                        {
                            pos = queue.Dequeue();
                            if (land[pos.r][pos.c] != 0) continue;
                            size++; land[pos.r][pos.c] = -1;
                            for (int _r = -1; _r <= 1; _r++) for (int _c = -1; _c <= 1; _c++)
                                {
                                    int __r = pos.r + _r, __c = pos.c + _c;
                                    if (__r >= 0 && __r < rcnt && __c >= 0 && __c < ccnt)
                                    {
                                        if (land[__r][__c] == 0) queue.Enqueue((__r, __c));
                                    }
                                }
                        }
                    }

                    result.Add(size);
                }

            result.Sort();
            return result.ToArray();
        }
    }
}
