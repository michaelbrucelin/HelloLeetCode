using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0907
{
    public class Test0907
    {
        public void Test()
        {
            Interface0907 solution = new Solution0907_2();
            int[] arr;
            int result, answer;
            int id = 0;

            // 1.
            arr = new int[] { 3, 1, 2, 4 };
            answer = 17;
            result = solution.SumSubarrayMins(arr);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            // 2.
            arr = new int[] { 11, 81, 94, 43, 3 };
            answer = 444;
            result = solution.SumSubarrayMins(arr);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            // 3.
            arr = new int[] { 1, 2, 3, 4 };
            answer = 20;
            result = solution.SumSubarrayMins(arr);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            // 4.
            arr = new int[] { 71, 55, 82, 55 };
            answer = 593;
            result = solution.SumSubarrayMins(arr);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            // 5.
            arr = new int[] { 14013, 29422, 27865, 18325, 15852, 26234, 21796, 9378, 27992, 1637, 3517, 17366, 12642, 6409, 25651, 15236, 20242, 4157, 7960, 12538, 25112, 29727, 9963, 24145, 14082, 17467, 20120, 24469, 13421, 6623, 16750, 17593, 27366, 1161, 15589, 2657, 27589, 18988, 11287, 15481, 10575, 23429, 18188, 24755, 12877, 24262, 181, 673, 9010, 14118, 6628, 7283, 16869, 22113, 19953, 18461, 8374, 23978, 21791, 10966, 15889, 28656, 17046, 9156, 8853, 6491, 11306, 4539, 24212, 26597, 690, 3364, 20200, 18279, 19715, 15127, 14462, 27910, 13583, 29578, 172, 23783, 6988, 29359, 25524, 7926, 8985, 17488, 9987, 8408, 18985, 1412, 7205, 7257, 3342, 5227, 1517, 27869, 23915, 21252 };
            answer = 8648330;
            result = solution.SumSubarrayMins(arr);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");

            // 6. 万恶的溢出
            string question = "0907", testcase = "05";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            arr = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_arr.txt"));
            answer = 667452382; result = solution.SumSubarrayMins(arr);
            Console.WriteLine($"{++id,2}: {result == answer}, result: {result}, answer: {answer}");
        }
    }
}
