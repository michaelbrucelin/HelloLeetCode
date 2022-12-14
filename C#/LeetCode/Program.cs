using LeetCode.Interview.Interview1709;
using LeetCode.QuestionBank.Question0260;
using LeetCode.LCP.LCP0030;
using LeetCode.剑指_Offer.剑指_Offer_0053_1;
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

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            Test0260 test = new();
            test.Test();
            //test.TestDivergentTraverse();
            //test.Look4Rules();
            //test.VerifyRules();

            //Utils0754 utils = new Utils0754();
            //utils.GetReachNumbers();

            //Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            //Console.WriteLine($"{++id,2}: In {stopwatch.Elapsed}, {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            //Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");
            //Console.WriteLine($"{++id,2}: In {stopwatch.Elapsed}, {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            {
                //Console.WriteLine(Convert.ToString(-1, 2));
                //Console.WriteLine(Convert.ToString(-2, 2));
                //Console.WriteLine(Convert.ToString(-3, 2));

                //Console.WriteLine(Convert.ToString(-2, 2));
                //Console.WriteLine(Convert.ToString((-2 >> 0), 2));
                //Console.WriteLine(Convert.ToString(((-2 >> 0) & 1), 2));
                //Console.WriteLine(Convert.ToString((-2 >> 1), 2));
                //Console.WriteLine(Convert.ToString(((-2 >> 1) & 1), 2));
                //Console.WriteLine(Convert.ToString((-2 >> 2), 2));
                //Console.WriteLine(Convert.ToString(((-2 >> 2) & 1), 2));
            }

            //const int MOD = 1000000007;
            //string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            //path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @"QuestionBank\Question1971\TestCases\TestCase1971_04.txt");

            //Console.WriteLine(Utils.GenerateRandomStringArray(50, 1, 100, Utils.GenStrChars.lower));
            //Console.WriteLine(Utils.GetRandomString("()", 1234));
            //Console.WriteLine(Utils.GetRandomString(Utils.GenStrChars.lower, 1000));
            //Console.WriteLine(Utils.GenerateRandomIntArray(100, 1, 10000));
            //Utils.PrintArray(Utils.ShuffleArray(Enumerable.Range(0, 10).ToArray()));

            {
                //int n = 8257285, index = 4828516, maxSum = 850015631;
                ////Console.WriteLine((n - index) * (n - index) + (index + 1) * (index + 1));
                ////Console.WriteLine((maxSum + (((n - index) * (n - index) + (index + 1) * (index + 1) - n - 1) >> 1)) / n);
                //Console.WriteLine((maxSum + ((1L * (n - index) * (n - index) + 1L * (index + 1) * (index + 1) - n - 1) >> 1)) / n);
                //Console.WriteLine((int)((maxSum + ((1L * (n - index) * (n - index) + 1L * (index + 1) * (index + 1) - n - 1) >> 1)) / n));
            }

            {
                //Dictionary<int, int> dic = new Dictionary<int, int>();
                //dic.Add(1, 1);
                //dic.Add(100, 100);
                //dic.Add(2, 2);
                //foreach (var kv in dic) Console.WriteLine(kv.Key);

                //SortedDictionary<int, int> sdic = new SortedDictionary<int, int>();
                //sdic.Add(1, 1);
                //sdic.Add(100, 100);
                //sdic.Add(2, 2);
                //foreach (var kv in sdic) Console.WriteLine(kv.Key);
            }

            //const int MOD = 1000000007;
            //long x = 1147483647;  // int x = 1147483647;  溢出
            //Console.WriteLine(x * x % MOD);

            //Console.WriteLine(int.MaxValue);  // 2147483647
            //Console.WriteLine("abcdefg".IndexOf("de", 4));
            //foreach (int i in Enumerable.Range(19968, 100)) Console.Write(Convert.ToChar(i));

            //Stack<int> stack = new Stack<int>();
            //stack.Push(10);
            //stack.Push(20);
            //stack.Push(100);
            //for (int i = 0; i < 100; i++)
            //{
            //    Console.Write($"{stack.Peek()}  ");
            //    stack.Peek()--;  // 不支持这样操作
            //}

            //HashSet<int[]> hash = new HashSet<int[]>();
            //hash.Add(new int[] { 1, 2, 3 });
            //hash.Add(new int[] { 1, 2, 3 });
            //hash.Add(new int[] { 1, 2, 3 });
            //Console.WriteLine($"hash.Count is: {hash.Count}");

            //StringBuilder sb = new StringBuilder();
            //sb.Append("hello"); sb.Append(','); sb.Append(' '); sb.Append("world"); sb.Append(".");
            //for (int i = 0; i < sb.Length; i++) Console.WriteLine(sb[i]);

            //string[][] strs = new string[][] { new string[] { "A1" }, new string[] { "B1", "B2" }, new string[] { "C1", "C2", "C3" } };
            //var flat = strs.SelectMany(arr => arr);
            //Console.WriteLine();

            // Console.WriteLine("wjAC".CompareTo("Zpi"));
            // Console.WriteLine(StringComparer.Ordinal.Compare("wjAC", "Zpi"));
            // Console.WriteLine(StringComparer.Ordinal.Compare("abc", "ABC"));
            // Console.WriteLine(string.Compare("abc", "ABC"));

            //char c = 'A';
            //Console.WriteLine((char)(c ^ 32));

            //int[] arr = new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
            //Utils.PrintArray(arr);  // [ 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 ]
            //Array.Sort(arr, 3, 4);
            //Utils.PrintArray(arr);  // [ 9, 8, 7, 3, 4, 5, 6, 2, 1, 0 ]

            //HashSet<int>[,] states = new HashSet<int>[3, 3];
            //states[1, 1].Add(1024);
            //Console.WriteLine(1024);

            //var list = PatternSplit("aa..*d");
            //Utils.ArrayToString(list.Select(item => item.pattern).ToArray());
            //Console.WriteLine(Utils.ArrayToString(PatternSplit("aa..*d")));

            //Console.WriteLine(Math.Floor((2 - 3) / 2d));

            //C#中的指针
            //unsafe
            //{
            //    int x = 10, y = 100;
            //    int* addx = &x;
            //}

            //Console.WriteLine(Utils.GenerateRandomIntArray(30, 0, 1000));

            //List<int> list = Enumerable.Range(0, 10).ToList();
            //Console.WriteLine(list[-1]);

            // 检查整型是否溢出
            //int x = int.MaxValue;
            //Console.WriteLine(x);
            //Console.WriteLine($"checked(x-1): {checked(x - 1)}");
            //Console.WriteLine($"checked(x+1): {checked(x + 1)}");

            //int[] helper = new int[26];
            //Array.Fill(helper, -100);
            //Console.WriteLine(helper[3]);

            //SortedList<int, int> list = new SortedList<int, int>();
            //list.Add(5, 5);
            //list.Add(4, 4);
            //list.Add(1, 1);
            //list.Add(2, 2);
            //list.Add(0, 0);
            //list.Add(2, 2);  // 报错
            //Console.WriteLine($"{list.Values[0]}, {list.Values[1]}, {list.Values[2]}, {list.Values[3]}, {list.Values[4]}");

            //bool[] arr = new bool[10];  // 默认值是false
            //Console.WriteLine(arr[8]);

            //(int a, int b)[] tuples = new (int, int)[10];
            //Console.WriteLine($"a={tuples[0].a}, b={tuples[0].b}");  // 值元组有默认值，默认值为0

            //Tuple<int, int, int> tuple = new Tuple<int, int, int>(1, 2, 3);
            //Console.WriteLine(tuple.ToString());

            //(int, int, int) tuple2 = (1, 2, 3);
            //Console.WriteLine(tuple2.ToString());

            //HashSet<int> hashset = new HashSet<int>();
            //hashset.Add(10);
            //hashset.Add(6);
            //hashset.Add(8);
            //hashset.Add(10);
            //foreach (int i in hashset) Console.WriteLine(i);

            //SortedSet<int> sortedset = new SortedSet<int>();
            //sortedset.Add(10);
            //sortedset.Add(6);
            //sortedset.Add(8);
            //sortedset.Add(10);
            //foreach (int i in sortedset) Console.WriteLine(i);

            //Stack<int> stack = new Stack<int>();
            //stack.Push(3);
            //stack.Push(2);
            //stack.Push(1);
            //stack.Push(9);
            //List<int> list = new List<int>(stack);
            //Utils.PrintArray(list);

            //int[] arr1 = new int[] { 1, 3, 5, 7, 9 };
            //int[] arr2 = new int[] { 0, 2, 4, 6, 8 };
            //Console.WriteLine(arr1[0]);
            //Console.WriteLine(arr2[0]);
            //(arr1, arr2) = (arr2, arr1);
            //Console.WriteLine(arr1[0]);
            //Console.WriteLine(arr2[0]);
        }

        private static List<(int type, string pattern)> PatternSplit(string pattern)
        {
            List<(int type, string pattern)> patterns = new List<(int, string)>();
            List<char> buffer = new List<char>();
            for (int i = 0; i < pattern.Length; i++)
            {
                switch (pattern[i])
                {
                    case '.':
                        if (buffer.Count > 0) { patterns.Add((1, new string(buffer.ToArray()))); buffer = new List<char>(); }
                        if (i + 1 < pattern.Length && pattern[i + 1] == '*') { patterns.Add((4, ".*")); i++; }
                        else patterns.Add((3, "."));
                        break;
                    case '*':
                        if (buffer.Count == 0) throw new Exception("Invalid Input.");  // 题目不允许 * 前面没有其他字符
                        string item = $"{buffer.Last()}*";
                        buffer.RemoveAt(buffer.Count - 1);
                        if (buffer.Count > 0) { patterns.Add((1, new string(buffer.ToArray()))); buffer = new List<char>(); }
                        patterns.Add((2, item));
                        break;
                    default:  // 小写字母
                        buffer.Add(pattern[i]);
                        break;
                }
            }
            if (buffer.Count > 0) patterns.Add((1, new string(buffer.ToArray())));

            return patterns;
        }
    }
}
