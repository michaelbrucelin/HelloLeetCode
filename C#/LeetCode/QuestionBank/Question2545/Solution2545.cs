using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2545
{
    public class Solution2545 : Interface2545
    {
        /// <summary>
        /// 原地冒泡
        /// 由于最多250项，所以冒泡排序的时间复杂度就够用，这里不考虑数组是引用类型，就当数组是值类型，类C原地进行替换
        /// </summary>
        /// <param name="score"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[][] SortTheStudents(int[][] score, int k)
        {
            int rcnt = score.Length, ccnt = score[0].Length;
            for (int top = 0; top < rcnt; top++) for (int r = rcnt - 1; r > top; r--) if (score[r][k] > score[r - 1][k])
                    {
                        for (int c = 0; c < ccnt; c++) (score[r][c], score[r - 1][c]) = (score[r - 1][c], score[r][c]);
                    }

            return score;
        }

        /// <summary>
        /// 逻辑同SortTheStudents()，把数组当成引用类型来看待
        /// </summary>
        /// <param name="score"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int[][] SortTheStudents2(int[][] score, int k)
        {
            int rcnt = score.Length, ccnt = score[0].Length;
            for (int top = 0; top < rcnt; top++) for (int r = rcnt - 1; r > top; r--) if (score[r][k] > score[r - 1][k])
                    {
                        (score[r], score[r - 1]) = (score[r - 1], score[r]);
                    }

            return score;
        }
    }
}
