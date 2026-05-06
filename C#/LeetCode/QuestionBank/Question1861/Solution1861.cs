using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1861
{
    public class Solution1861 : Interface1861
    {
        /// <summary>
        /// 模拟
        /// 
        /// 队列可以换成指针，好好想想，这里不写了
        /// </summary>
        /// <param name="boxGrid"></param>
        /// <returns></returns>
        public char[][] RotateTheBox(char[][] boxGrid)
        {
            int rcnt = boxGrid.Length, ccnt = boxGrid[0].Length;
            char[][] result = new char[ccnt][];
            for (int c = 0; c < ccnt; c++) result[c] = new char[rcnt];
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++) result[c][rcnt - r - 1] = boxGrid[r][c];

            (rcnt, ccnt) = (ccnt, rcnt);
            Queue<(int, int)> queue = new Queue<(int, int)>();
            for (int c = 0, _r, _c; c < ccnt; c++)
            {
                queue.Clear();
                for (int r = rcnt - 1; r >= 0; r--)
                {
                    switch (result[r][c])
                    {
                        case '.': queue.Enqueue((r, c)); break;
                        case '*': queue.Clear(); break;
                        case '#':
                            if (queue.Count > 0)
                            {
                                (_r, _c) = queue.Dequeue();
                                result[_r][_c] = '#';
                                queue.Enqueue((r, c));
                                result[r][c] = '.';
                            }
                            break;
                        default: break;
                    }
                }
            }

            return result;
        }
    }
}
