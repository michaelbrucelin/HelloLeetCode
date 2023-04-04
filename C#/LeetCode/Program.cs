using LeetCode.Interview.Interview1617;
using LeetCode.QuestionBank.Question1000;
using LeetCode.LCP.LCP0030;
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

            Test1000 test = new();
            test.Test();
            //test.TestDivergentTraverse();
            //test.Look4Rules();
            //test.VerifyRules();
            //Utils0401 utils = new();
            //utils.Dial();

            //Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            //Console.WriteLine($"{++id,2}: In {sw.Elapsed}, {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            //Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");
            //Console.WriteLine($"{++id,2}: In {sw.Elapsed}, {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");
            //Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, false) + ",",-6} result: {Utils.ArrayToString(result, false)}, answer: {Utils.ArrayToString(answer, false)}");
            //Console.WriteLine($"{++id,2}: In {sw.Elapsed}, {Utils.CompareArray(result, answer, false) + ",",-6} result: {Utils.ArrayToString(result, false)}, answer: {Utils.ArrayToString(answer, false)}");

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
                //Console.WriteLine(Convert.ToString(1, 2));   // 1
                //Console.WriteLine(Convert.ToString((-1), 2));  // 11111111111111111111111111111111
                //Console.WriteLine(Convert.ToString((-1) >> 4, 2));  // 11111111111111111111111111111111

                //Enumerable.Range(0, 16).MyForEach(i => Console.WriteLine($"{i:D2}"));  // 00 01 ... 15

                //Console.WriteLine(int.MaxValue);    // 2147483647            10位
                //Console.WriteLine(uint.MaxValue);   // 4294967295            10位
                //Console.WriteLine(long.MaxValue);   // 9223372036854775807   19位
                //Console.WriteLine(ulong.MaxValue);  // 18446744073709551615  20位
            }

            {
                //Console.WriteLine($"Q: {('Q' >> 1) & 3}");
                //Console.WriteLine($"W: {('W' >> 1) & 3}");
                //Console.WriteLine($"E: {('E' >> 1) & 3}");
                //Console.WriteLine($"R: {('R' >> 1) & 3}");
            }

            {
                // 将字符串拆分为数组，同时保留拆分符号
                //string str = "{a,b}{c,{d,e}{f,g}}";
                //string[] strs;
                //int id = 0;
                //Console.WriteLine($"======== {++id} ========");
                //strs = Regex.Split(str, @","); for (int i = 0; i < strs.Length; i++) Console.WriteLine($"{i}\t{strs[i]}");
                //Console.WriteLine($"======== {++id} ========");
                //strs = Regex.Split(str, @"(,)"); for (int i = 0; i < strs.Length; i++) Console.WriteLine($"{i}\t{strs[i]}");
                //Console.WriteLine($"======== {++id} ========");
                //strs = Regex.Split(str, @",{}"); for (int i = 0; i < strs.Length; i++) Console.WriteLine($"{i}\t{strs[i]}");
                //Console.WriteLine($"======== {++id} ========");
                //strs = Regex.Split(str, @"([,{}])"); for (int i = 0; i < strs.Length; i++) Console.WriteLine($"{i}\t{strs[i]}");
                //Console.WriteLine($"======== {++id} ========");
                //strs = Regex.Split(str, @"(?=>[,{}])"); for (int i = 0; i < strs.Length; i++) Console.WriteLine($"{i}\t{strs[i]}");
                //Console.WriteLine($"======== {++id} ========");
                //strs = Utils.SplitAndKeep(str, new char[] { ',', '{', '}' }).ToArray();
                //for (int i = 0; i < strs.Length; i++) Console.WriteLine($"{i}\t{strs[i]}");
            }

            {
                //Console.WriteLine(int.Parse("03"));        // 3，不异常
                //Console.WriteLine(Convert.ToInt32("03"));  // 3，不异常
                //Console.WriteLine($"10 % 4 = {10 % 4}");
                //Console.WriteLine($"10 % 4 = {Math.DivRem(10, 4).Quotient},{Math.DivRem(10, 4).Remainder}");
                //Console.WriteLine($"10 %-4 = {10 % -4}");
                //Console.WriteLine($"10 %-4 = {Math.DivRem(10, -4).Quotient},{Math.DivRem(10, -4).Remainder}");
            }

            {
                // LinkedList不是环形链表
                //LinkedList<int> list = new LinkedList<int>();
                //for (int i = 0; i < 8; i++) list.AddLast(i);
                //var ptr = list.First;
                //for (int i = 0; i < 18; i++)
                //{
                //    Console.WriteLine(ptr.Value); ptr = ptr.Next;
                //}
            }

            {
                //StringBuilder sb = new StringBuilder();
                //sb.Append("abc");
                //sb.Append("xyz");
                //Console.WriteLine($"sb.length: {sb.Length}");  // 6
            }

            {
                //Dictionary<int, int> dic = new Dictionary<int, int>();
                //for (int i = 0; i < 10; i++) dic.Add(i, i);
                //Console.WriteLine(dic.Count);
                //foreach (int key in dic.Keys) Console.WriteLine(key);
                //foreach (int key in dic.Keys) if ((key & 1) != 0) dic.Remove(key);  // 字典可以正确地在foreach中被移除
                //Console.WriteLine(dic.Count);
                //foreach (int key in dic.Keys) Console.WriteLine(key);

                //List<int> list = new List<int>();
                //for (int i = 0; i < 10; i++) list.Add(i);
                //Console.WriteLine(list.Count);
                //foreach (int key in list) Console.WriteLine(key);
                //foreach (int key in list) if ((key & 1) != 0) list.Remove(key);     // 列表在foreach中不可以被移除，会异常
                //Console.WriteLine(list.Count);
                //foreach (int key in list) Console.WriteLine(key);
            }

            {
                //Console.WriteLine("abcdefg"[1..^1]);  // bcdef
                //string[] strs = new string[10];       // 默认值是null
                //Console.WriteLine(strs[1] == null);
            }

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

            {
                // List.Remove()只Remove掉第一个匹配的值，如果列表中不存在匹配的值，也不会异常
                //List<int> list = new List<int>();
                //list.AddRange(Enumerable.Range(0, 10));
                //Utils.PrintArray(list);                  // [ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 ]
                //list.AddRange(Enumerable.Range(5, 10));
                //Utils.PrintArray(list);                  // [ 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 ]
                //list.Remove(7);
                //Utils.PrintArray(list);                  // [ 0, 1, 2, 3, 4, 5, 6, 8, 9, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 ]
                //list.Remove(100);
                //Utils.PrintArray(list);
            }

            {
                //List<int> list = Enumerable.Range(0, 100).ToList();
                //Console.WriteLine(list[^1]);
                //Console.WriteLine(list[^10]);
            }

            {
                //// SelectMany
                //string[][] strs = new string[][] {
                //    new string[] { "A1" },
                //    new string[] { "B1", "B2" },
                //    new string[] { "C1", "C2", "C3" }
                //};
                //var flat1 = strs.SelectMany(arr => arr);
                //Console.WriteLine("break point1");

                ////var flat2 = strs.Select((row, rid) => new { rid, row })
                ////                .SelectMany(item => item.row.Select((val, cid) => (val, cid)), (item, element) => new { element.val, item.rid, element.cid });
                //var flat2 = strs.Select((row, rid) => (row, rid))
                //                .SelectMany(item => item.row.Select((val, cid) => (val, cid)), (item, element) => (element.val, item.rid, element.cid));
                //Console.WriteLine("break point2");
            }

            {
                // char数组的默认值  '\0'
                //char[] chars = new char[16];
                //if (chars[0] == '\0') Console.WriteLine("yes");
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

            {
                //bool[] arr = new bool[10];  // 默认值是false
                //Console.WriteLine(arr[8]);

                //char[] arr = new char[10];    // 默认值是0
                //Console.WriteLine(arr[8]);
                //Console.WriteLine((int)arr[8]);
                //Console.WriteLine(arr[8] == null);  // 没有意义的比较，int永远不为null
            }

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
