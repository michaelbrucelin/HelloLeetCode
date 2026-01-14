using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0950
{
    public class Test0950
    {
        public void Test()
        {
            Interface0950 solution = new Solution0950();
            int[] deck;
            int[] result, answer;
            int id = 0;

            // 1. 
            deck = [17, 13, 11, 2, 3, 5, 7];
            answer = [2, 13, 3, 11, 5, 17, 7];
            result = solution.DeckRevealedIncreasing(deck);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}
