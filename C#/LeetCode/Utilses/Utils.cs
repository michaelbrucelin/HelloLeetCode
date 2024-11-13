using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Utilses
{
    public static class Utils
    {
        static Utils()
        {
            random = new Random();
        }

        private static readonly Random random;
        public static readonly string chars_0 = "0123456789";
        public static readonly string chars_a = "abcdefghijklmnopqrstuvwxyz";
        public static readonly string chars_A = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public static readonly string chars_0a = "0123456789abcdefghijklmnopqrstuvwxyz";
        public static readonly string chars_0A = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public static readonly string chars_aA = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public static readonly string chars_0aA = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        [Flags]
        public enum GenStrChars
        {
            digit = 1 << 0,
            lower = 1 << 1,
            upper = 1 << 2
        }

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
            raw = raw.Replace(" ", "");
            if (raw.Length == 0) return new T[] { };

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
            raw = raw.Replace(" ", "");
            if (raw.Length == 0) return new T[][] { };

            return raw[2..^2].Split("],[")
                             .Select(str => str.Length == 0 ? new T[] { } : str.Split(',').Select(s => T.Parse(s, CultureInfo.InvariantCulture.NumberFormat)).ToArray())
                             .ToArray();
        }

        /// <summary>
        /// 将以字符串形式给出的二维数字数组转成二维字符数组
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="raw"></param>
        /// <returns></returns>
        public static char[][] Str2CharArray_2d(string raw)
        {
            raw = raw.Replace(" ", "").Replace("\"", "");
            if (raw.Length == 0) return new char[][] { };

            return raw[2..^2].Split("],[")
                             .Select(str => str.Length == 0 ? new char[] { } : str.Split(',').Select(s => s[0]).ToArray())
                             .ToArray();
        }

        /// <summary>
        /// 将以字符串形式给出的二维数字数组转成二维字符串数组
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="raw"></param>
        /// <returns></returns>
        public static string[][] Str2StrArray_2d(string raw)
        {
            raw = raw.Replace(" ", "").Replace("\"", "");
            if (raw.Length == 0) return new string[][] { };

            return raw[2..^2].Split("],[")
                             .Select(str => str.Length == 0 ? new string[] { } : str.Split(',').Select(s => s).ToArray())
                             .ToArray();
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

        /// <summary>
        /// 比较两个一维数组是否相等
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list1"></param>
        /// <param name="list2"></param>
        /// <returns></returns>
        public static bool CompareArray<T>(IList<T> list1, IList<T> list2, bool ignoreOrder = false) where T : IComparable
        {
            if (list1.Count != list2.Count) return false;

            if (ignoreOrder)
            {
                list1 = list1.OrderBy(t => t).ToList();
                list2 = list2.OrderBy(t => t).ToList();
            }

            for (int i = 0; i < list1.Count; i++)
                if (list1[i].CompareTo(list2[i]) != 0) return false;

            return true;
        }

        /// <summary>
        /// 比较两个一维数组是否相等，浮点型，指定精度
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list1"></param>
        /// <param name="list2"></param>
        /// <returns></returns>
        public static bool CompareArray<T>(IList<T> list1, IList<T> list2, T precision, bool ignoreOrder = false) where T : INumber<T>
        {
            if (list1.Count != list2.Count) return false;

            if (ignoreOrder)
            {
                list1 = list1.OrderBy(t => t).ToList();
                list2 = list2.OrderBy(t => t).ToList();
            }

            for (int i = 0; i < list1.Count; i++)
            {// if (list1[i].CompareTo(list2[i]) != 0) return false;
                if (list1[i] == list2[i]) continue;
                else if (list1[i] > list2[i])
                {
                    if (list1[i] - list2[i] > precision) return false;
                }
                else  // if (list1[i] < list2[i])
                {
                    if (list2[i] - list1[i] > precision) return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 比较两个二维数组是否相等
        /// TODO：忽略顺序的那部分没有完成，主要是没有想清楚怎么忽略顺序
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list1"></param>
        /// <param name="list2"></param>
        /// <returns></returns>
        public static bool CompareArray<T>(IList<IList<T>> list1, IList<IList<T>> list2, bool ignoreOrder = false) where T : IComparable
        {
            if (list1.Count != list2.Count) return false;

            if (ignoreOrder)
            {
                //for (int i = 0; i < list1.Count; i++)
                //{
                //    list1[i] = list1[i].OrderBy(t => t).ToList();
                //    list2[i] = list2[i].OrderBy(t => t).ToList();
                //}
            }

            for (int i = 0; i < list1.Count; i++)
            {
                if (!Enumerable.SequenceEqual(list1[i], list2[i])) return false;
            }

            return true;
        }

        public static void Dump(object element)
        {
            ObjectDumper.Write(element, 0);
        }

        public static void Dump(object element, int depth)
        {
            ObjectDumper.Write(element, depth, Console.Out);
        }

        public static void Dump(object element, int depth, TextWriter log)
        {
            ObjectDumper.Write(element, depth, log);
        }

        public static void Dump<T>(IEnumerable<T> list, int width = 0)
        {
            Console.WriteLine(ToString<T>(list), width);
        }

        public static void Dump<T>(IEnumerable<T> list, int start, int len, int width = 0)
        {
            Console.WriteLine(ToString(list, start, len, width));
        }

        public static void Dump<T>(IList<T> list, int width = 0)
        {
            Console.WriteLine(ToString(list), width);
        }

        public static void Dump<T>(IList<T> list, int start, int len, int width = 0)
        {
            Console.WriteLine(ToString(list, start, len, width));
        }

        public static void Dump<T>(IList<IList<T>> list, bool multiline = true)
        {
            Dump<T>(list, 0, multiline);
        }

        public static void Dump<T>(IList<IList<T>> list, int width, bool multiline = true)
        {
            Console.WriteLine(ToString(list, width, multiline));
        }

        public static void Dump<T>(T[,] arr, bool multiline = true)
        {
            Dump(arr, 0, multiline);
        }

        public static void Dump<T>(T[,] arr, int width, bool multiline = true)
        {
            Console.WriteLine(ToString(arr, width, multiline));
        }

        public static void Dump<TKey, TValue>(Dictionary<TKey, TValue> dic)
        {
            Console.WriteLine(ToString<TKey, TValue>(dic));
        }

        public static string ToString<T>(IEnumerable<T> list, int width = 0)
        {
            return ToString<T>(new List<T>(list), width);
        }

        public static string ToString<T>(IEnumerable<T> list, int start, int len, int width = 0)
        {
            return ToString<T>(new List<T>(list), start, len, width);
        }

        /// <summary>
        /// 将一维数组转为字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string ToString<T>(IList<T> list, int width = 0)
        {
            if (list == null) return "null";
            if (list.Count == 0) return "[ ]";
            if (list.Count == 1) return $"[ {list[0]} ]";

            StringBuilder sb = new StringBuilder();

            sb.Append("[ ");
            sb.Append(list[0].ToString().PadLeft(width, ' '));
            for (int i = 1; i < Math.Min(8, list.Count); i++)
                sb.Append($", {list[i].ToString().PadLeft(width, ' ')}");
            if (list.Count > 8) sb.Append(", ...");
            sb.Append(" ]");

            return sb.ToString();
        }

        /// <summary>
        /// 将一维数组转为字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="start"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static string ToString<T>(IList<T> list, int start, int len, int width = 0)
        {
            if (list == null) return "null";
            if (len == 0) return "[ ]";
            if (len == 1) return $"[ {list[start].ToString().PadLeft(width, ' ')} ]";

            StringBuilder sb = new StringBuilder();

            sb.Append("[ ");
            sb.Append(list[start].ToString().PadLeft(width, ' '));
            for (int i = start + 1; i < Math.Min(8, len); i++)
                sb.Append($", {list[i].ToString().PadLeft(width, ' ')}");
            if (list.Count > 8) sb.Append(", ...");
            sb.Append(" ]");

            return sb.ToString();
        }

        /// <summary>
        /// 将二维数组转为字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string ToString<T>(IList<IList<T>> list, bool multiline = true)
        {
            if (list == null) return "null";
            if (list.Count == 0) return "[ ]";
            if (list.Count == 1) return $"[ {ToString(list[0])} ]";

            StringBuilder sb = new StringBuilder();

            sb.Append("[ ");
            sb.Append($"{ToString(list[0])}, "); if (multiline) sb.Append(Environment.NewLine);
            for (int i = 1; i < list.Count - 1; i++)
            {
                if (multiline) sb.Append("  "); sb.Append($"{ToString(list[i])}, "); if (multiline) sb.Append(Environment.NewLine);
            }
            if (multiline) sb.Append("  "); sb.Append($"{ToString(list[list.Count - 1])}");
            sb.Append(" ]");

            return sb.ToString();
        }

        /// <summary>
        /// 将二维数组转为字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string ToString<T>(IList<IList<T>> list, int width, bool multiline = true)
        {
            if (list == null) return "null";
            if (list.Count == 0) return "[ ]";
            if (list.Count == 1) return $"[ {ToString(list[0])} ]";

            StringBuilder sb = new StringBuilder();

            sb.Append("[ ");
            sb.Append($"{ToString(list[0], width)}, "); if (multiline) sb.Append(Environment.NewLine);
            for (int i = 1; i < list.Count - 1; i++)
            {
                if (multiline) sb.Append("  "); sb.Append($"{ToString(list[i], width)}, "); if (multiline) sb.Append(Environment.NewLine);
            }
            if (multiline) sb.Append("  "); sb.Append($"{ToString(list[list.Count - 1], width)}");
            sb.Append(" ]");

            return sb.ToString();
        }

        /// <summary>
        /// 将二维数组转为字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static string ToString<T>(T[,] arr, bool multiline = true)
        {
            return ToString(arr, multiline);
        }

        /// <summary>
        /// 将二维数组转为字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arr"></param>
        /// <returns></returns>
        public static string ToString<T>(T[,] arr, int width, bool multiline = true)
        {
            if (arr == null) return "null";
            if (arr.Length == 0) return "[ ]";

            StringBuilder sb = new StringBuilder();

            sb.Append("[");
            for (int row = 0; row < arr.GetLength(0) - 1; row++)
            {
                if (multiline) sb.Append("  "); sb.Append("[ ");
                for (int col = 0; col < arr.GetLength(1) - 1; col++) sb.Append($"{arr[row, col].ToString().PadLeft(width, ' ')}, "); sb.Append(arr[row, arr.GetLength(1) - 1].ToString().PadLeft(width, ' '));
                sb.Append(" ],"); if (multiline) sb.Append(Environment.NewLine);
            }
            if (multiline) sb.Append("  "); sb.Append("[ ");
            for (int col = 0; col < arr.GetLength(1) - 1; col++) sb.Append($"{arr[arr.GetLength(0) - 1, col].ToString().PadLeft(width, ' ')}, "); sb.Append(arr[arr.GetLength(0) - 1, arr.GetLength(1) - 1].ToString().PadLeft(width, ' '));
            sb.Append(" ] ]");
            sb.Remove(1, 1);

            return sb.ToString();
        }

        /// <summary>
        /// 将字典转为字符串
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="dic"></param>
        /// <returns></returns>
        public static string ToString<TKey, TValue>(Dictionary<TKey, TValue> dic)
        {
            if (dic == null) return "";
            return $"{{{string.Join(',', dic.Select(kv => $"{{{kv.Key},{kv.Value}}}"))}}}";
        }

        /// <summary>
        /// 生成随机测试用例，整数数组
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string GenerateRandomIntArray(int length, int min, int max)
        {
            int[] array = new int[length];
            for (int i = 0; i < length; i++)
                array[i] = random.Next(min, max + 1);

            return ToString(array);
        }

        /// <summary>
        /// 生成随机测试用例，二维整数数组
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string GenerateRandomIntArray(int row, int col, int min, int max, bool multiline)
        {
            int[,] array = new int[row, col];
            for (int i = 0; i < row; i++) for (int j = 0; j < col; j++)
                    array[i, j] = random.Next(min, max + 1);

            return ToString(array, 0, multiline);
        }

        /// <summary>
        /// 生成随机测试用例，字符串数组
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string GenerateRandomStringArray(int length, int min_len, int max_len, string chars)
        {
            string[] array = new string[length];
            for (int i = 0; i < length; i++)
                array[i] = GetRandomString(chars, random.Next(min_len, max_len + 1));

            return ToString(array);
        }

        /// <summary>
        /// 生成随机测试用例，字符串数组
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string GenerateRandomStringArray(int length, int min_len, int max_len, GenStrChars flag)
        {
            string[] array = new string[length];
            for (int i = 0; i < length; i++)
                array[i] = GetRandomString(flag, random.Next(min_len, max_len + 1));

            return ToString(array);
        }

        /// <summary>
        /// 生成随机字符串
        /// </summary>
        /// <param name="chars"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string GetRandomString(string chars, int length)
        {
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        /// <summary>
        /// 生成随机字符串
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string GetRandomString(GenStrChars flag, int length)
        {
            string chars = "";
            if ((flag & GenStrChars.digit) == GenStrChars.digit) chars = $"{chars}{chars_0}";
            if ((flag & GenStrChars.lower) == GenStrChars.lower) chars = $"{chars}{chars_a}";
            if ((flag & GenStrChars.upper) == GenStrChars.upper) chars = $"{chars}{chars_A}";

            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        /// <summary>
        /// 乱序数组
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static T[] ShuffleArray<T>(IList<T> list)
        {
            return list.OrderBy(i => random.Next()).ToArray();
        }

        /// <summary>
        /// 乱序字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ShuffleString(string str)
        {
            return new string(str.OrderBy(i => random.Next()).ToArray());
        }

        /// <summary>
        /// 使用指定的分隔字符将字符串分割为字符串数组，与string.Split()不同的是，这里保留分隔符作为数组独立的项
        /// </summary>
        /// <param name="s"></param>
        /// <param name="delims"></param>
        /// <returns></returns>
        public static IEnumerable<string> SplitAndKeep(string s, char[] delims)
        {
            int start = 0, index;

            while ((index = s.IndexOfAny(delims, start)) != -1)
            {
                if (index - start > 0) yield return s.Substring(start, index - start);
                yield return s.Substring(index, 1);
                start = index + 1;
            }

            if (start < s.Length) yield return s.Substring(start);
        }

        ///// <summary>
        ///// Question0025里面有写，稍后统一
        ///// </summary>
        ///// <param name="arrayString"></param>
        ///// <returns></returns>
        //public static SinglyListNode GetTreeNodeFromArray(string arrayString)
        //{

        //}

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
