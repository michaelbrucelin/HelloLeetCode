using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2530
{
    public class Test2530
    {
        public void Test()
        {
            Interface2530 solution = new Solution2530();
            int[] nums; int k;
            long result, answer;
            int id = 0;

            // 1. 
            nums = new int[] { 10, 10, 10, 10, 10 }; k = 5;
            answer = 50;
            result = solution.MaxKelements(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = new int[] { 1, 10, 3, 3, 3 }; k = 3;
            answer = 17;
            result = solution.MaxKelements(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = new int[] { 756902131, 995414896, 95906472, 149914376, 387433380, 848985151 }; k = 6;
            answer = 3603535575;
            result = solution.MaxKelements(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            nums = new int[] { 597189039, 57948756, 143524875, 379494516, 862193035, 868775043, 395597119, 275046118, 306907315, 257034002, 476132995, 69495282, 395493151, 354621370, 365510017, 520479568, 219063577, 159958079, 113409455, 170145739, 687892872, 881301934, 723211517, 276655363, 635301113, 440291651, 961908086, 821028930, 821879600, 82879805, 850787822, 547409867, 813461937, 866639644, 512259589, 130847041, 973334294, 114942610, 233744177, 941195642, 888940360, 983125701, 533826303, 726965368, 516401603, 312579605, 182667172, 447853195, 275822190, 338282009 };
            k = 62126;
            answer = 36767245672;
            result = solution.MaxKelements(nums, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
