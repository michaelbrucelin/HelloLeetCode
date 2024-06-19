using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2713
{
    public class Solution2713_2 : Interface2713
    {
        /// <summary>
        /// 逻辑同Solution2713，只是将递归1:1翻译为迭代
        /// 
        /// 逻辑没问题，TLE，参考测试用例04
        /// </summary>
        /// <param name="mat"></param>
        /// <returns></returns>
        public int MaxIncreasingCells(int[][] mat)
        {
            int rcnt = mat.Length, ccnt = mat[0].Length;
            int[,] memory = new int[rcnt, ccnt];
            Stack<(int r, int c)> stack = new Stack<(int r, int c)>();
            (int r, int c) item; bool flag; int _result;  // flag true 当前项计算出结果 false 当前项没有结果且已入栈
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++) if (memory[r, c] == 0)
                    {
                        stack.Push((r, c));
                        while (stack.Count > 0)
                        {
                            item = stack.Pop(); flag = true; _result = 0;
                            for (int _r = 0; _r < rcnt; _r++) if (mat[_r][item.c] > mat[item.r][item.c])
                                {
                                    if (memory[_r, item.c] == 0)
                                    {
                                        if (flag) { stack.Push(item); flag = false; }
                                        stack.Push((_r, item.c));
                                    }
                                    else if (flag)
                                    {
                                        _result = Math.Max(_result, memory[_r, item.c]);
                                    }
                                }
                            for (int _c = 0; _c < ccnt; _c++) if (mat[item.r][_c] > mat[item.r][item.c])
                                {
                                    if (memory[item.r, _c] == 0)
                                    {
                                        if (flag) { stack.Push(item); flag = false; }
                                        stack.Push((item.r, _c));
                                    }
                                    else if (flag)
                                    {
                                        _result = Math.Max(_result, memory[item.r, _c]);
                                    }
                                }

                            if (flag) memory[item.r, item.c] = _result + 1;
                        }
                    }

            int result = 0;
            foreach (int val in memory) result = Math.Max(result, val);
            return result;
        }
    }
}
