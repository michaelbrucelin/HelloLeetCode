using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0096
{
    public class Utils0096
    {
        public void Dial(int n)
        {
            int[] dial = new int[n + 1];
            Solution0096_2 solution = new Solution0096_2();
            for (int i = 0; i <= n; i++) dial[i] = solution.NumTrees(i);
            Utils.Dump(dial);
        }
    }
}
