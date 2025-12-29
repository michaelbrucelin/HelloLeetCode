using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0756
{
    public class Solution0756 : Interface0756
    {
        /// <summary>
        /// BFS + 迭代
        /// 逐层分析所有的可能
        /// 
        /// TLE，参考测试用例04，猜测是产生了大量重复值导致的
        /// 去除重复的可能性后通过了，见PyramidTransition2()
        /// </summary>
        /// <param name="bottom"></param>
        /// <param name="allowed"></param>
        /// <returns></returns>
        public bool PyramidTransition(string bottom, IList<string> allowed)
        {
            List<int>[,] map = new List<int>[6, 6];
            for (int i = 0, r, c, t; i < allowed.Count; i++)
            {
                r = allowed[i][0] - 'A'; c = allowed[i][1] - 'A'; t = allowed[i][2] - 'A';
                if (map[r, c] == null) map[r, c] = [t]; else map[r, c].Add(t);
            }

            int initcnt = bottom.Length, cnt;
            int[] init = new int[initcnt];
            for (int i = 0; i < initcnt; i++) init[i] = bottom[i] - 'A';
            Queue<int[]> queue = new Queue<int[]>();
            queue.Enqueue(init);
            while (--initcnt > 0 && (cnt = queue.Count) > 0) for (int i = 0; i < cnt; i++)
                {
                    int[] level = queue.Dequeue();
                    int len = level.Length;
                    int[] _init = new int[len - 1]; Array.Fill(_init, -1);
                    List<int[]> tops = [_init];
                    for (int j = 1; j < len; j++)
                    {
                        if (map[level[j - 1], level[j]] == null) break;
                        List<int> next = map[level[j - 1], level[j]];
                        int topscnt = tops.Count, nextcnt = next.Count;
                        for (int k = 0; k < topscnt; k++) tops[k][j - 1] = next[0];
                        for (int _i = 1; _i < nextcnt; _i++) for (int _j = 0; _j < topscnt; _j++)
                            {
                                int[] newtop = [.. tops[_j]]; newtop[j - 1] = next[_i]; tops.Add(newtop);
                            }
                    }
                    foreach (int[] item in tops) if (item[^1] != -1) queue.Enqueue(item);
                }

            return queue.Count > 0;
        }

        /// <summary>
        /// 逻辑与PyramidTransition()相同，针对队列做了去重
        /// </summary>
        /// <param name="bottom"></param>
        /// <param name="allowed"></param>
        /// <returns></returns>
        public bool PyramidTransition2(string bottom, IList<string> allowed)
        {
            List<int>[,] map = new List<int>[6, 6];
            for (int i = 0, r, c, t; i < allowed.Count; i++)
            {
                r = allowed[i][0] - 'A'; c = allowed[i][1] - 'A'; t = allowed[i][2] - 'A';
                if (map[r, c] == null) map[r, c] = [t]; else map[r, c].Add(t);
            }

            int initcnt = bottom.Length, cnt;
            int[] init = new int[initcnt];
            for (int i = 0; i < initcnt; i++) init[i] = bottom[i] - 'A';
            Queue<int[]> queue = new Queue<int[]>(); HashSet<int> set = new HashSet<int>();
            queue.Enqueue(init);
            while (--initcnt > 0 && (cnt = queue.Count) > 0)
            {
                set.Clear();
                for (int i = 0; i < cnt; i++)
                {
                    int[] level = queue.Dequeue();
                    int len = level.Length;
                    int[] _init = new int[len - 1]; Array.Fill(_init, -1);
                    List<int[]> tops = [_init];
                    for (int j = 1; j < len; j++)
                    {
                        if (map[level[j - 1], level[j]] == null) break;
                        List<int> next = map[level[j - 1], level[j]];
                        int topscnt = tops.Count, nextcnt = next.Count;
                        for (int k = 0; k < topscnt; k++) tops[k][j - 1] = next[0];
                        for (int _i = 1; _i < nextcnt; _i++) for (int _j = 0; _j < topscnt; _j++)
                            {
                                int[] newtop = [.. tops[_j]]; newtop[j - 1] = next[_i]; tops.Add(newtop);
                            }
                    }
                    foreach (int[] item in tops) if (item[^1] != -1)
                        {
                            int itemhash = ArrayHash(item);
                            if (!set.Contains(itemhash)) { queue.Enqueue(item); set.Add(itemhash); }
                        }
                }
            }

            return queue.Count > 0;

            int ArrayHash(int[] arr)
            {
                int result = 0;
                for (int i = 0; i < arr.Length; i++) result = result * 10 + arr[i];
                return result;
            }
        }
    }
}
