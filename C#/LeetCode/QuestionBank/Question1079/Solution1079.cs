using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1079
{
    public class Solution1079 : Interface1079
    {
        /// <summary>
        /// dfs
        /// 既然tiles长度最大为7，那么可以暴力枚举(dfs)解决
        /// </summary>
        /// <param name="tiles"></param>
        /// <returns></returns>
        public int NumTilePossibilities3(string tiles)
        {
            HashSet<string> result = new HashSet<string>();
            HashSet<int> visited = new HashSet<int>();  // HashSet foreach遍历时的顺序，就是值第一次添加到集合中的顺序，但是没有找到说明，这里先这么用
            for (int l = 1; l <= tiles.Length; l++)
                dfs(tiles, l, visited, result);

            return result.Count;
        }

        /// <summary>
        /// dfs
        /// </summary>
        /// <param name="tiles"></param>
        /// <param name="need">字串还需要几个字符</param>
        /// <param name="visited">tiles中已经使用的字符的掩码</param>
        /// <param name="result"></param>
        private void dfs(string tiles, int need, HashSet<int> visited, HashSet<string> result)
        {
            if (need > 0)
            {
                for (int i = 0; i < tiles.Length; i++)
                {
                    if (visited.Contains(i)) continue;
                    HashSet<int> _visited = new HashSet<int>(visited) { i };
                    dfs(tiles, need - 1, _visited, result);
                }
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                foreach (int i in visited) sb.Append(tiles[i]);
                result.Add(sb.ToString());
            }
        }

        /// <summary>
        /// dfs
        /// 与NumTilePossibilities()逻辑一样，NumTilePossibilities()利用了HashSet foreach遍历时的顺序，就是值第一次添加到集合中的顺序这个特性
        /// 但是并没有找到关于这点特性的说明，这里使用 bool[] mask + List<int> ids 来实现上述的特性
        /// </summary>
        /// <param name="tiles"></param>
        /// <returns></returns>
        public int NumTilePossibilities2(string tiles)
        {
            HashSet<string> result = new HashSet<string>();
            bool[] mask = new bool[tiles.Length];
            List<int> ids = new List<int>();
            for (int l = 1; l <= tiles.Length; l++)
                dfs2(tiles, l, mask, ids, result);

            return result.Count;
        }

        /// <summary>
        /// dfs
        /// </summary>
        /// <param name="tiles"></param>
        /// <param name="need">字串还需要几个字符</param>
        /// <param name="visited">tiles中已经使用的字符的掩码</param>
        /// <param name="result"></param>
        private void dfs2(string tiles, int need, bool[] mask, List<int> ids, HashSet<string> result)
        {
            if (need > 0)
            {
                for (int i = 0; i < tiles.Length; i++)
                {
                    if (mask[i]) continue;
                    bool[] _mask = mask.ToArray(); _mask[i] = true;
                    List<int> _ids = ids.ToList(); _ids.Add(i);
                    dfs2(tiles, need - 1, _mask, _ids, result);
                }
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < ids.Count; i++) sb.Append(tiles[ids[i]]);
                result.Add(sb.ToString());
            }
        }

        /// <summary>
        /// dfs
        /// 与NumTilePossibilities()逻辑一样，做了部分优化，即不需要分不同长度的字串去枚举
        /// </summary>
        /// <param name="tiles"></param>
        /// <returns></returns>
        public int NumTilePossibilities(string tiles)
        {
            HashSet<string> result = new HashSet<string>();
            HashSet<int> visited = new HashSet<int>();  // HashSet foreach遍历时的顺序，就是值第一次添加到集合中的顺序，但是没有找到说明，这里先这么用
            dfs3(tiles, tiles.Length, visited, result);

            return result.Count;
        }

        /// <summary>
        /// dfs
        /// </summary>
        /// <param name="tiles"></param>
        /// <param name="need">字串还需要几个字符</param>
        /// <param name="visited">tiles中已经使用的字符的掩码</param>
        /// <param name="result"></param>
        private void dfs3(string tiles, int need, HashSet<int> visited, HashSet<string> result)
        {
            if (need == 0) return;
            for (int i = 0; i < tiles.Length; i++)
            {
                if (visited.Contains(i)) continue;
                HashSet<int> _visited = new HashSet<int>(visited) { i };
                StringBuilder sb = new StringBuilder();
                foreach (int j in _visited) sb.Append(tiles[j]);
                result.Add(sb.ToString());
                dfs3(tiles, need - 1, _visited, result);
            }
        }
    }
}
