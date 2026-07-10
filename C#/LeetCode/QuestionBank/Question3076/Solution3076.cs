using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3076
{
    public class Solution3076 : Interface3076
    {
        /// <summary>
        /// 暴力查找
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public string[] ShortestSubstrings(string[] arr)
        {
            int len = arr.Length;
            HashSet<string>[] sets = new HashSet<string>[len];
            PriorityQueue<string, string>[] minpqs = new PriorityQueue<string, string>[len];
            Comparer<string> comparer = Comparer<string>.Create((x, y) => x.Length != y.Length ? x.Length - y.Length : string.CompareOrdinal(x, y));
            List<string> buffer = new List<string>();
            for (int i = 0, _len; i < len; i++)
            {
                _len = arr[i].Length;
                sets[i] = new HashSet<string>();
                buffer.Clear();
                for (int l = 0; l < _len; l++) for (int r = l; r < _len; r++)
                    {
                        if (sets[i].Add(arr[i][l..(r + 1)])) buffer.Add(arr[i][l..(r + 1)]);
                    }
                minpqs[i] = new PriorityQueue<string, string>(buffer.Zip(buffer), comparer);
            }

            string[] result = new string[len];
            string substr;
            for (int i = 0; i < len; i++)
            {
                result[i] = "";
                while (minpqs[i].Count > 0)
                {
                    substr = minpqs[i].Dequeue();
                    for (int j = 0; j < len; j++) if (j != i)
                        {
                            if (sets[j].Contains(substr)) goto CONTINUE;
                        }
                    result[i] = substr;
                    goto NEXT;
                CONTINUE:;
                }
            NEXT:;
            }

            return result;
        }

        /// <summary>
        /// 逻辑完全同ShortestSubstrings()，只是将字符串Hash改为Int128来实现，题目限定字符串长度不超过20，所以不必考虑溢出
        /// 
        /// 逻辑必然没问题，但是哪里写错了，不改了，有时间再说
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public string[] ShortestSubstrings2(string[] arr)
        {
            int len = arr.Length;
            HashSet<Int128>[] sets = new HashSet<Int128>[len];
            PriorityQueue<(string, Int128), string>[] minpqs = new PriorityQueue<(string, Int128), string>[len];
            Comparer<string> comparer = Comparer<string>.Create((x, y) => x.Length != y.Length ? x.Length - y.Length : string.CompareOrdinal(x, y));
            List<((string, Int128), string)> buffer = new List<((string, Int128), string)>();
            Int128 i128; string substr;
            for (int i = 0, _len; i < len; i++)
            {
                _len = arr[i].Length;
                sets[i] = new HashSet<Int128>();
                buffer.Clear();
                for (int l = 0; l < _len; l++)
                {
                    i128 = 0;
                    for (int r = l; r < _len; r++)
                    {
                        i128 = i128 * 26 + arr[i][r] - 'a' + 1;
                        substr = arr[i][l..(r + 1)];
                        if (sets[i].Add(i128)) buffer.Add(((substr, i128), substr));
                    }
                }
                minpqs[i] = new PriorityQueue<(string, Int128), string>(buffer, comparer);
            }

            string[] result = new string[len];
            for (int i = 0; i < len; i++)
            {
                result[i] = "";
                while (minpqs[i].Count > 0)
                {
                    (substr, i128) = minpqs[i].Dequeue();
                    for (int j = 0; j < len; j++) if (j != i)
                        {
                            if (sets[j].Contains(i128)) goto CONTINUE;
                        }
                    result[i] = substr;
                    goto NEXT;
                CONTINUE:;
                }
            NEXT:;
            }

            return result;
        }
    }
}
