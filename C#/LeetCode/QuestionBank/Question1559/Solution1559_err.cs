using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1559
{
    public class Solution1559_err : Interface1559
    {
        /// <summary>
        /// 并查集
        /// 换一种思路
        /// 1. 先用并查集分组，每一组是相邻的相同字母的集合
        /// 2. 再在每一组内部找圈，下面是找圈的步骤
        ///     2.1. 按照每一个位置的行分组，按照列分组
        ///     2.2. 删除分组内删除只有一个元素的行，删除只有一个元素的列
        ///     2.3. 余下的元素大于等于4
        ///     2.4. 余下的元素按照行排序连续无中断，按照列排序连续无中断
        ///         2,3,4,5,6 即连续无中断 2,3,5,6,7 即有中断，4断了
        ///     满足上面条件，即这一组有圈，证明比较简单，有点拓扑的味道
        ///         每一行至少两个元素，可以向横向移动，最终移动为两列
        ///         列同理，形成矩形
        /// 写着玩的，生产还是使用DFS吧
        /// 
        /// 核心思路是对的，但是需要递归，参考测试用例03
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public bool ContainsCycle(char[][] grid)
        {
            int rcnt = grid.Length, ccnt = grid[0].Length;
            (int, int)[,] uf = new (int, int)[rcnt, ccnt];
            int[,] rank = new int[rcnt, ccnt];
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++) uf[r, c] = (r, c);
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++)
                {
                    if (r - 1 >= 0 && grid[r - 1][c] == grid[r][c]) union(r, c, r - 1, c);
                    if (c - 1 >= 0 && grid[r][c - 1] == grid[r][c]) union(r, c, r, c - 1);
                }

            Dictionary<(int, int), List<(int, int)>> groups = new Dictionary<(int, int), List<(int, int)>>();
            for (int r = 0, _r, _c; r < rcnt; r++) for (int c = 0; c < ccnt; c++)
                {
                    (_r, _c) = find(r, c);
                    groups.TryAdd((_r, _c), new List<(int, int)>());
                    groups[(_r, _c)].Add((r, c));
                }
            Dictionary<int, int> rmap = new Dictionary<int, int>(), cmap = new Dictionary<int, int>();
            List<int> rlist = new List<int>(), clist = new List<int>();
            foreach (List<(int, int)> group in groups.Values) if (group.Count >= 4)
                {
                    rmap.Clear(); cmap.Clear();
                    foreach ((int r, int c) in group)
                    {
                        rmap.TryAdd(r, 0); rmap[r]++;
                        cmap.TryAdd(c, 0); cmap[c]++;
                    }
                    rlist.Clear(); clist.Clear();
                    foreach (int r in rmap.Keys) if (rmap[r] > 1) rlist.Add(r);
                    foreach (int c in cmap.Keys) if (cmap[c] > 1) clist.Add(c);
                    if (rlist.Count > 1 && clist.Count > 1)
                    {
                        rlist.Sort(); clist.Sort();
                        for (int i = 1; i < rlist.Count; i++) if (rlist[i] - rlist[i - 1] > 1) goto CONTINUE;
                        for (int i = 1; i < clist.Count; i++) if (clist[i] - clist[i - 1] > 1) goto CONTINUE;
                        return true;
                    }
                CONTINUE:;
                }

            return false;

            (int, int) find(int r, int c)
            {
                if (uf[r, c] != (r, c)) uf[r, c] = find(uf[r, c].Item1, uf[r, c].Item2);
                return uf[r, c];
            }

            void union(int r1, int c1, int r2, int c2)
            {
                (r1, c1) = find(r1, c1);
                (r2, c2) = find(r2, c2);
                if (r1 == r2 && c1 == c2) return;
                switch (rank[r1, c1] - rank[r2, c2])
                {
                    case > 0: uf[r2, c2] = (r1, c1); break;
                    case < 0: uf[r1, c1] = (r2, c2); break;
                    default: uf[r2, c2] = (r1, c1); rank[r1, c1]++; break;
                }
            }
        }
    }
}
