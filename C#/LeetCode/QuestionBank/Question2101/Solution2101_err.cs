using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2101
{
    public class Solution2101_err : Interface2101
    {
        /// <summary>
        /// 暴力查找
        /// 思路类似于BFS
        /// 从数组中随便取一项，做为一个集合Set
        ///     然后外层循环遍历集合中的每一项，内层循环遍历数组中其余的项，只要与其相交，便将这一项从数组中移除，并添加到集合中
        /// 
        /// 答案是错误的，炸弹引爆是单向的，这里当成双向的了
        /// 即A可以引爆B，但是B不能引爆A是可能发生的，而这里当成只要A可以引爆B，B就一定可以引爆A
        /// </summary>
        /// <param name="bombs"></param>
        /// <returns></returns>
        public int MaximumDetonation(int[][] bombs)
        {
            int result = 1;
            List<int[]> bom = bombs.ToList(), set = new List<int[]>();
            long dist;
            while (bom.Count > result)
            {
                set.Add(bom[bom.Count - 1]); bom.RemoveAt(bom.Count - 1);
                for (int i = 0; i < set.Count; i++) for (int j = bom.Count - 1; j >= 0; j--)
                    {
                        dist = 1L * (set[i][0] - bom[j][0]) * (set[i][0] - bom[j][0])
                             + 1L * (set[i][1] - bom[j][1]) * (set[i][1] - bom[j][1]);
                        if (dist <= 1L * set[i][2] * set[i][2] || dist <= 1L * bom[j][2] * bom[j][2])
                        {
                            set.Add(bom[j]); bom.RemoveAt(j);
                        }
                    }
                result = Math.Max(result, set.Count);
                set.Clear();
            }

            return result;
        }
    }
}
