using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LeetCode.Utilses
{
    public static class UtilsLeetCode
    {
        public enum TestCaseType { array_2d };

        public static string TestCase2CSharpDeclare(string raw, TestCaseType type)
        {
            string declare = string.Empty;
            switch (type)
            {
                case TestCaseType.array_2d:
                    declare = $"new int[][]{{{raw[1..^1].Replace("]", "}").Replace("[", "new int[]{")}}}";
                    break;
                default:
                    break;
            }
            return declare;
        }

        /// <summary>
        /// 将以字符串形式给出的数字数组转成数字数组
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="raw"></param>
        /// <returns></returns>
        public static T[] Str2NumArray<T>(string raw) where T : INumber<T>
        {
            return raw[1..^1].Split(',').Select(s => T.Parse(s, CultureInfo.InvariantCulture.NumberFormat)).ToArray();
        }

        /// <summary>
        /// 将以字符串形式给出的二维数字数组转成二维数字数组
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="raw"></param>
        /// <returns></returns>
        public static T[][] Str2NumArray_2d<T>(string raw) where T : INumber<T>
        {
            return raw[2..^2].Split("],[").Select(str => str.Split(',').Select(s => T.Parse(s, CultureInfo.InvariantCulture.NumberFormat)).ToArray()).ToArray();
        }

        /// <summary>
        /// 本想写一个通用的，目前不可用，Utils0501中有可用的方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="raw"></param>
        /// <returns></returns>
        public static T Str2TreeNode<T>(string raw) where T : TreeNode_base
        {
            int?[] vals = raw[1..^1].Split(',').Select(s => (int?)(s == "null" ? null : int.Parse(s, CultureInfo.InvariantCulture.NumberFormat))).ToArray();
            if (vals.Length == 0 || vals[0] == null) return null;

            T root = (T)Activator.CreateInstance(typeof(T), (int)vals[0], null, null);
            Queue<T> queue = new Queue<T>(); queue.Enqueue(root);
            int ptr = 1, len = vals.Length;
            while (queue.Count > 0 && ptr < len)
            {
                T node = queue.Dequeue();
                if (node == null)
                {
                    // ptr += 2;
                }
                else
                {
                    if (ptr < len)
                    {
                        if (vals[ptr] == null)
                        {
                            queue.Enqueue(null);
                        }
                        else
                        {
                            T left = (T)Activator.CreateInstance(typeof(T), (int)vals[ptr], null, null);
                            node.left = left; queue.Enqueue(left);
                        }
                        ptr++;
                    }
                    if (ptr < len)
                    {
                        if (vals[ptr] == null)
                        {
                            queue.Enqueue(null);
                        }
                        else
                        {
                            T right = (T)Activator.CreateInstance(typeof(T), (int)vals[ptr], null, null);
                            node.right = right; queue.Enqueue(right);
                        }
                        ptr++;
                    }
                }
            }

            return root;
        }

        public enum QuestionType
        {
            [Display(Name = "Interview")]
            Interview,
            [Display(Name = "LCP")]
            LCP,
            [Display(Name = "QuestionBank")]
            QuestionBank,
            [Display(Name = "剑指 Offer")]
            剑指Offer,
            [Display(Name = "剑指 Offer II")]
            剑指Offer_II
        };

        /// <summary>
        /// 格式化使用chrome插件复制出来的markdown
        /// 由于复制出来的markdown中的LaTeX公式都是"3份"，所以这里进行批量的替换
        /// </summary>
        /// <param name="type"></param>
        /// <param name="question"></param>
        /// <param name="file"></param>
        public static void FmtMarkDown(QuestionType type, string question, string file)
        {
            string dir = type switch
            {
                QuestionType.Interview => @$"Interview\Interview{question}",
                QuestionType.LCP => @$"LCP\LCP{question}",
                QuestionType.QuestionBank => @$"QuestionBank\Question{question}",
                QuestionType.剑指Offer => @$"剑指 Offer\剑指 Offer {question}",
                QuestionType.剑指Offer_II => @$"剑指 Offer II\剑指 Offer II {question}",
                _ => throw new Exception("logic error")
            };
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"{dir}\Solution{question}_{file}.md");
            string context = File.ReadAllText(path);

            Dictionary<string, string> map = new Dictionary<string, string>()
            {
                { @"\[", "[" }, { @"\]", "]" }, { "−", "-" },
                { "<sup>", "^" }, { "</sup>", "" }, { "<sub>", "_" }, { "</sub>", "" },
                { " 161616 ", " $16$ " }, { " 161616，", " $16$，" }, { " 161616。", " $16$。" },
                { " 323232 ", " $32$ " }, { " 323232，", " $32$，" }, { " 323232。", " $32$。" },
                { " 646464 ", " $64$ " }, { " 646464，", " $64$，" }, { " 646464。", " $64$。" },
                { @"\\times", @"\times" }, { @"\\max", @"\max" }, { @"\\min", @"\min" }, { @"\\neq", @"\neq" }, { @"\\log", @"\log" }, { @"\\And", @"\And" }, { @"\\and", @"\and" },
                { @"\\mathcal", @"\mathcal" }, { @"\\{", @"\{" }, { @"\\}", @"\}" },
                { @"y&x=yy \And x = yy&x\=y", @"$y \And x = y$" }
            };
            foreach (var kv in map) context = context.Replace(kv.Key, kv.Value);

            HashSet<string> set = new HashSet<string>()
            {
                "arr", "nums", "dp", "mask", "key", "keys", "value", "values",
                "column", "col", "colsum", "row", "rowsum", "sum", "count", "cnt", "one", "two", "three",
                "upper", "lower", "result", "res", "answer", "ans",
                "sup", "sub", "next", "nxt",
                "dp[0]", "dp[1]", "dp[2]", "dp[mask]", "values[mask]",
                "nums[i]", "nums[j]", "nums[k]", "nums[m]", "nums[n]"
            };
            foreach (string str in set)
            {
                context = context.Replace($@"\\textit{{{str}}}", str);
                context = context.Replace($"{str}{str}{str}", $"${str}$");
            }

            for (int i = 'a'; i <= 'z'; i++)
            {
                char c = (char)i; context = context.Replace($"{c}{c}{c}", $"${c}$");
                c = (char)(i & (~32)); context = context.Replace($"{c}{c}{c}", $"${c}$");
            }

            for (int i = '0'; i <= '9'; i++)
            {
                char c = (char)i;
                context = context.Replace($" {c}{c}{c} ", $" ${c}$ ").Replace($" {c}{c}{c}：", $" ${c}$：").Replace($" {c}{c}{c}，", $" ${c}$，").Replace($" {c}{c}{c}。", $" ${c}$。");
                context = context.Replace($" -{c}-{c}-{c} ", $" $-{c}$ ").Replace($" -{c}-{c}-{c}：", $" $-{c}$：").Replace($" -{c}-{c}-{c}，", $" $-{c}$，").Replace($" -{c}-{c}-{c}。", $" $-{c}$。");
            }

            set = new HashSet<string>() { "1", "m", "n", "i", "j", "k" };
            foreach (string s in set)
            {
                context = context.Replace($"2{s}2^{s}2{s}", $"$2^{{{s}}}$").Replace($"2{s}-12^{s} - 12{s}-1", $"$2^{{{s}}} - 1$");

                context = context.Replace($"O({s})O({s})O({s})", $"$O({{{s}}})$");                                        // O(n)
                context = context.Replace(@$"O({s})\\mathcal{{O}}({s})O({s})", @$"$\mathcal{{O}}({{{s}}})$");
                context = context.Replace($"O(2{s})O(2^{s})O(2{s})", $"$O(2^{{{s}}})$");                                  // O(2^n)
                context = context.Replace(@$"O(2{s})\\mathcal{{O}}(2^{s})O(2{s})", @$"$\mathcal{{O}}(2^{{{s}}})$");
                context = context.Replace($"O(3{s})O(3^{s})O(3{s})", $"$O(3^{{{s}}})$");                                  // O(3^n)
                context = context.Replace(@$"O(3{s})\\mathcal{{O}}(3^{s})O(3{s})", @$"$\mathcal{{O}}(3^{{{s}}})$");
                context = context.Replace(@$"O({s}×2{s})O({s}\times 2^{s})O({s}×2{s})", $"$O({s}\\times 2^{{{s}}})$");  // O(n\times 2^n)
                context = context.Replace(@$"O({s}×2{s})O({s}\times 2^{s})O({s}×2{s})", $"$O({s}\\times 2^{{{s}}})$");
            }

            File.WriteAllText(path, context, Encoding.UTF8);
        }
    }
}
