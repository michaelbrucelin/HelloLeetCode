using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1925
{
    public class Utils1925
    {
        public void Dial()
        {
            int[] dic = new int[250];
            for (int i = 1; i <= 250; i++) dic[i - 1] = CountTriples(i);
            Utils.Dump(dic);
        }

        private int CountTriples(int n)
        {
            int[] square = new int[n];
            for (int i = 1; i <= n; i++) square[i - 1] = i * i;
            HashSet<int> set = new HashSet<int>(square);

            int result = 0;
            for (int i = 0; i < n - 2; i++) for (int j = i + 1; j < n - 1; j++)
                {
                    if (set.Contains(square[i] + square[j])) result += 2;
                }

            return result;
        }
    }
}
