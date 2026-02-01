using LeetCode.Interview.Interview0801;
using LeetCode.LCP.LCP0030;
using LeetCode.LCR.LCR0002;
using LeetCode.LCS.LCS0001;
using LeetCode.QuestionBank.Question1553;
using LeetCode.Utilses;
using LeetCode.剑指_Offer.剑指_Offer_0058_1;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using TestXXXX = LeetCode.QuestionBank.Question1545.Test1545;
using UtilsXXXX = LeetCode.QuestionBank.Question0233.Utils0233;
// using TestXXXX = LeetCode.LCP.LCP0051.Test0051;
// using TestXXXX = LeetCode.LCR.LCR0063.Test0063;
// using TestXXXX = LeetCode.Interview.Interview0809.Test0809;

namespace LeetCode
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Random random = new Random();

            TestXXXX test = new();
            test.Test();
            //Utils.FmtMarkDown(Utils.QuestionType.QuestionBank, "1253", "off");
            //test.TestDivergentTraverse();
            //test.Look4Rules();
            //test.VerifyRules();
            //UtilsXXXX utils = new();
            //utils.Dial(10240);
            //utils.DialInt();
            //utils.Debug();

            //Utils.Dump(UtilsDial.DialPrime(1, 100000));

            //标量值
            //Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            //Console.WriteLine($"{++id,2}: In {sw.Elapsed}, {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            //Console.WriteLine($"{++id,2}: {(Math.Abs(result - answer) <= Math.Pow(10d, -5)) + ",",-6} result: {result}, answer: {answer}");
            //Console.WriteLine($"{++id,2}: In {sw.Elapsed}, {(Math.Abs(result - answer) <= Math.Pow(10d, -5)) + ",",-6} result: {result}, answer: {answer}");
            //数组
            //Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");                // 1d
            //Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result, false)}, answer: {Utils.ToString(answer, false)}");  // 2d
            //Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, true) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");          // ignore order
            //Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, precision) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
            //Console.WriteLine($"{++id,2}: In {sw.Elapsed}, {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
            //Console.WriteLine($"{++id,2}: In {sw.Elapsed}, {Utils.CompareArray(result, answer, true) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
            #region 比较两个链表
            /*
            List<int> _result, _answer;
            _result = link2list(result); _answer = link2list(answer);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(_result, _answer) + ",",-6} result: {Utils.ToString(_result)}, answer: {Utils.ToString(_answer)}");
            private List<int> link2list(ListNode head)
            {
                if (head == null) return [];
                List<int> list = [];
                ListNode ptr = head;
                while (ptr != null) { list.Add(ptr.val); ptr = ptr.next; }
                return list;
            }
            */
            #endregion
            #region 比较两个二叉树
            /*
            _result = tree2list(result); _answer = tree2list(answer);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(_result, _answer) + ",",-6} result: {Utils.ToString(_result)}, answer: {Utils.ToString(_answer)}");
            private List<int?> tree2list(TreeNode root)
            {
                if (root == null) return [null];
                List<int?> result = [];
                Queue<TreeNode> queue = new Queue<TreeNode>(); queue.Enqueue(root);
                TreeNode item;
                while (queue.Count > 0)
                {
                    item = queue.Dequeue();
                    if (item == null)
                    {
                        result.Add(null);
                    }
                    else
                    {
                        result.Add(item.val); queue.Enqueue(item.left); queue.Enqueue(item.right);
                    }
                }
                while (result[^1] == null) result.RemoveAt(result.Count - 1);

                return result;
            }
             */
            #endregion
            #region 字符串反序列化为二叉树
            /*
            TreeNode TreeBuilder(string input)
            {
                int?[] _nodes = input[1..^1].Split(',', StringSplitOptions.RemoveEmptyEntries)
                                            .Select(x => x.Replace(" ", "").ToLower())
                                            .Select(x => (int?)(x != "null" ? int.Parse(x) : null))
                                            .ToArray();
                if (_nodes[0] == null) return null;

                int p1 = 0, p2 = 1, n = _nodes.Length;
                TreeNode[] nodes = new TreeNode[n];
                for (int i = 0; i < n; i++) if (_nodes[i] != null) nodes[i] = new TreeNode(_nodes[i].Value);
                while (p2 < n)
                {
                    while (nodes[p1] == null) p1++;
                    if (nodes[p2] != null) nodes[p1].left = nodes[p2];
                    if (++p2 >= n) break;
                    if (nodes[p2] != null) nodes[p1].right = nodes[p2];
                    ++p2;
                    ++p1;
                }

                return nodes[0];
            }
             */
            #endregion

            //哑节点(dummy node)，也被称为哨兵节点
            //const double epsilon = 1e-5;                              // 0.00001
            //const int MOD = (int)1e9 + 7;                             // 1000000007, 10^9 + 7
            //const int MOD = (int)1e9 + 9;                             // 1000000009, 10^9 + 9
            //string question = "1234", testcase = "08", arg = "nums";
            //string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            //path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            //path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"Interview\Interview{question}\TestCases\TestCase{question}");
            //path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"LCP\LCP{question}\TestCases\TestCase{question}");
            //arg = File.ReadAllText($"{path}_{testcase}_{arg}.txt");
            //arg = File.ReadAllText($"{path}_{testcase}_{arg}.txt")[1..^1];
            //arg = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_{arg}.txt"));
            //arg = Utils.Str2NumArray_2d<int>(File.ReadAllText($"{path}_{testcase}_{arg}.txt"));
            //string raw = "[[0,1],[1,2]]";
            //Console.WriteLine(Utils.TestCase2CSharpDeclare(raw, Utils.TestCaseType.array_2d));
            //               0xAAAAAAAA      10101010101010101010101010101010
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

                //Console.WriteLine(int.MaxValue);      // 2147483647                               10位
                //Console.WriteLine(uint.MaxValue);     // 4294967295                               10位
                //Console.WriteLine(long.MaxValue);     // 9223372036854775807                      19位
                //Console.WriteLine(ulong.MaxValue);    // 18446744073709551615                     20位
                //Console.WriteLine(Int128.MaxValue);   // 170141183460469231731687303715884105727  39位
                //Console.WriteLine(UInt128.MaxValue);  // 340282366920938463463374607431768211455  39位

                //int[][] arr = new int[rcnt][];
                //for (int i = 0; i < rcnt; i++) arr[i] = new int[ccnt];
            }
        }
    }
}
