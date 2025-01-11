using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0699
{
    public class Solution0699 : Interface0699
    {
        /// <summary>
        /// 线段树
        /// </summary>
        /// <param name="positions"></param>
        /// <returns></returns>
        public IList<int> FallingSquares(int[][] positions)
        {
            const int LEFT = 1;
            const int RIGHT = (int)(1e8 + 1e6);
            Dictionary<int, int[]> tree = new Dictionary<int, int[]>();  // value[0]: height, value[1]: lazy

            int len = positions.Length;
            int[] result = new int[len];

            return result;

            void Update(int left, int right, int val, int Left, int Right, int idx)
            {

            }
        }
    }
}
