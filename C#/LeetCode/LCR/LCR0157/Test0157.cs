using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0157
{
    public class Test0157
    {
        public void Test()
        {
            Interface0157 solution = new Solution0157_2();
            string goods;
            string[] result, answer;
            int id = 0;

            // 1. 
            goods = "agew";
            answer = ["aegw", "aewg", "agew", "agwe", "aweg", "awge", "eagw", "eawg", "egaw", "egwa", "ewag", "ewga", "gaew", "gawe", "geaw", "gewa", "gwae", "gwea", "waeg", "wage", "weag", "wega", "wgae", "wgea"];
            result = solution.GoodsOrder(goods);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, true) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}
