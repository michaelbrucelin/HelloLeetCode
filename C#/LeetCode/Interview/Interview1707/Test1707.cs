using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview1707
{
    public class Test1707
    {
        public void Test()
        {
            Interface1707 solution = new Solution1707();
            string[] names, synonyms;
            string[] result, answer;
            int id = 0;

            // 1. 
            names = ["John(15)", "Jon(12)", "Chris(13)", "Kris(4)", "Christopher(19)"]; synonyms = ["(Jon,John)", "(John,Johnny)", "(Chris,Kris)", "(Chris,Christopher)"];
            answer = ["John(27)", "Chris(36)"];
            result = solution.TrulyMostPopular(names, synonyms);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, true) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}
