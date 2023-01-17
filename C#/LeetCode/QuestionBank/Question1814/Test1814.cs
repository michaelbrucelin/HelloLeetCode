using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1814
{
    public class Test1814
    {
        public void Test()
        {
            Interface1814 solution = new Solution1814_3();
            int[] nums;
            int result, answer;
            int id = 0;

            // 1. 
            nums = new int[] { 1 }; answer = 0;
            result = solution.CountNicePairs(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            nums = new int[] { 42, 11, 1, 97 }; answer = 2;
            result = solution.CountNicePairs(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            nums = new int[] { 13, 10, 35, 24, 76 }; answer = 4;
            result = solution.CountNicePairs(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            nums = new int[] { 1377, 3228, 6894, 2280, 4895, 5559, 4184, 8765, 9783, 1410, 9784, 6895, 4512, 4760, 3437, 1437, 5595, 6976, 7800, 5178, 3400, 4937, 8248, 8284, 8000, 2189, 9384, 3468, 4140, 932, 322, 1182 };
            answer = 0;
            result = solution.CountNicePairs(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            nums = new int[] { 9274, 3134, 7804, 8095, 7193, 173, 2011, 2184, 9516, 3862, 81, 1448, 7068, 9258, 3802, 2766, 9595, 4491, 2719, 6626, 7020, 1762, 2314, 779, 702, 5387, 4091, 5060, 25, 1633, 7237, 1503, 4831, 3635, 2099, 3272, 4364, 9936, 7183, 651, 6483, 5809, 1141, 94, 5905, 6161, 7497, 1620, 3066, 2364, 3701, 9763, 266, 8333, 1512, 6011, 5522, 2417, 7331, 4506, 6010, 3810, 2393, 4975, 4161, 1587, 9011, 1595, 8697, 9711, 9799, 7159, 5887, 6955, 3788, 8142, 5234, 920, 2515, 6083, 9400, 5624, 2772, 5903, 2044, 4236, 4768, 5623, 6177, 3717, 8434, 5432, 4695, 7070, 5306, 2015, 7298, 157, 665, 1460 };
            answer = 18;
            result = solution.CountNicePairs(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 6. 
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @"QuestionBank\Question1814\TestCases\TestCase1814_06.txt");
            string nums_str = File.ReadAllText(path);
            nums = nums_str.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(s => Convert.ToInt32(s)).ToArray();
            answer = 599959993;
            result = solution.CountNicePairs(nums);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
