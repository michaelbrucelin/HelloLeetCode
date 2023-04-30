using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0832
{
    public class Solution0832_api : Interface0832
    {
        public int[][] FlipAndInvertImage(int[][] image)
        {
            return image.Select(arr => arr.Reverse().Select(i => i ^ 1).ToArray()).ToArray();
        }
    }
}
