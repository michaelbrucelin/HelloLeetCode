using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1267
{
    public class Solution1267 : Interface1267
    {
        /// <summary>
        /// 二次哈希
        /// 1. 每一行1的坐标入hash表，如果数量大于1，全部加入结果hash表
        /// 2. 每一列1的坐标入hash表，如果数量大于1，全部加入结果hash表
        /// 假定grid有rcnt行，ccnt列，那么坐标(r,c)可以映射为r*ccnt+c，这里简单映射为(r<<8)+c，当然也可以直接使用值元组
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int CountServers(int[][] grid)
        {
            int rcnt = grid.Length, ccnt = grid[0].Length;
            HashSet<int> result = new HashSet<int>(), cache = new HashSet<int>();

            for (int r = 0; r < rcnt; r++)
            {
                cache.Clear();
                for (int c = 0; c < ccnt; c++) if (grid[r][c] == 1) cache.Add((r << 8) + c);
                if (cache.Count > 1) foreach (int key in cache) result.Add(key);
            }
            for (int c = 0; c < ccnt; c++)
            {
                cache.Clear();
                for (int r = 0; r < rcnt; r++) if (grid[r][c] == 1) cache.Add((r << 8) + c);
                if (cache.Count > 1) foreach (int key in cache) result.Add(key);
            }

            return result.Count;
        }

        /// <summary>
        /// 与CountServers()一样，只是将坐标映射改为了值元组，试一下效果
        /// </summary>
        /// <param name="grid"></param>
        /// <returns></returns>
        public int CountServers2(int[][] grid)
        {
            int rcnt = grid.Length, ccnt = grid[0].Length;
            HashSet<(int, int)> result = new HashSet<(int, int)>(), cache = new HashSet<(int, int)>();

            for (int r = 0; r < rcnt; r++)
            {
                cache.Clear();
                for (int c = 0; c < ccnt; c++) if (grid[r][c] == 1) cache.Add((r, c));
                if (cache.Count > 1) foreach (var key in cache) result.Add(key);
            }
            for (int c = 0; c < ccnt; c++)
            {
                cache.Clear();
                for (int r = 0; r < rcnt; r++) if (grid[r][c] == 1) cache.Add((r, c));
                if (cache.Count > 1) foreach (var key in cache) result.Add(key);
            }

            return result.Count;
        }
    }
}
