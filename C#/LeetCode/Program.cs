using LeetCode.Interview.Interview1617;
using LeetCode.QuestionBank.Question1156;
using LeetCode.LCP.LCP0033;
using LeetCode.剑指_Offer.剑指_Offer_0058_1;
using LeetCode.剑指_Offer_II.剑指_Offer_II_0031;
using System;
using System.Collections.Generic;
using LeetCode.Utilses;
using System.Linq;
using System.Text.RegularExpressions;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading;
using System.IO;
using System.Reflection;
using System.Threading.Channels;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            //Random random = new Random();

            Test1156 test = new();
            test.Test();
            //test.TestDivergentTraverse();
            //test.Look4Rules();
            //test.VerifyRules();
            //Utils2427 utils = new();
            //utils.Dial(1000);

            //标量值
            //Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            //Console.WriteLine($"{++id,2}: In {sw.Elapsed}, {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            //Console.WriteLine($"{++id,2}: {(Math.Abs(result - answer) <= Math.Pow(10d, -5)) + ",",-6} result: {result}, answer: {answer}");
            //Console.WriteLine($"{++id,2}: In {sw.Elapsed}, {(Math.Abs(result - answer) <= Math.Pow(10d, -5)) + ",",-6} result: {result}, answer: {answer}");
            //数组
            //Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");
            //Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, precision) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");
            //Console.WriteLine($"{++id,2}: In {sw.Elapsed}, {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");
            //Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, false) + ",",-6} result: {Utils.ArrayToString(result, false)}, answer: {Utils.ArrayToString(answer, false)}");
            //Console.WriteLine($"{++id,2}: In {sw.Elapsed}, {Utils.CompareArray(result, answer, false) + ",",-6} result: {Utils.ArrayToString(result, false)}, answer: {Utils.ArrayToString(answer, false)}");

            //哑节点(dummy node)，也被称为哨兵节点
            //const int MOD = 1000000007;
            //string question = "1234", testcase = "08";
            //string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            //path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}_{testcase}.txt");
            //arg = File.ReadAllText(path);
            //string raw = "[[0,1],[1,2]]";
            //Console.WriteLine(UtilsLeetCode.TestCase2CSharpDeclare(raw, UtilsLeetCode.TestCaseType.array_2d));
            //const int M1 = 0x55555555;  // 01010101010101010101010101010101
            //const int M2 = 0x33333333;  // 00110011001100110011001100110011
            //const int M4 = 0x0f0f0f0f;  // 00001111000011110000111100001111
            //const int M8 = 0x00ff00ff;  // 00000000111111110000000011111111
            //const int MX = 0x0000ffff;  // 00000000000000001111111111111111

            //Console.WriteLine(Utils.GenerateRandomStringArray(4, 100, 100, Utils.GenStrChars.lower));
            //Console.WriteLine(Utils.GenerateRandomStringArray(4, 8, 16, "abcd"));
            //Console.WriteLine(Utils.GetRandomString("ab", 100000));
            //Console.WriteLine(Utils.GetRandomString(Utils.GenStrChars.lower, 1000));
            //Console.WriteLine(Utils.GenerateRandomIntArray(10000, 1, 10000));
            //Console.WriteLine(Utils.GenerateRandomIntArray(100, 100, 0, 1, true));
            //Utils.PrintArray(Utils.ShuffleArray(Enumerable.Range(0, 10).ToArray()));

            {
                //Console.WriteLine(Convert.ToString(1, 2));          // 1
                //Console.WriteLine(Convert.ToString((-1), 2));       // 11111111111111111111111111111111
                //Console.WriteLine(Convert.ToString((-1) >> 4, 2));  // 11111111111111111111111111111111

                //Enumerable.Range(0, 16).MyForEach(i => Console.WriteLine($"{i:D2}"));  // 00 01 ... 15

                //Console.WriteLine(int.MaxValue);    // 2147483647            10位
                //Console.WriteLine(uint.MaxValue);   // 4294967295            10位
                //Console.WriteLine(long.MaxValue);   // 9223372036854775807   19位
                //Console.WriteLine(ulong.MaxValue);  // 18446744073709551615  20位
            }
        }
    }
}
