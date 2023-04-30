using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2078
{
    public class Solution2078 : Interface2078
    {
        /// <summary>
        /// 暴力解
        /// 1. 两层循环
        ///     1.1. 第1层循环，从左向右一次固定起点
        ///     1.2. 第2层循环，从右向左找第一个不同的染色
        /// 优化
        /// 1. 记录已经找到解的起点
        ///     即如果蓝色为起点已经找到了一个解，则后面再遇到蓝色起点，跳过
        /// 2. 如果剩余的长度已经不足以产生更大的解，提前跳出循环
        ///     即如果已经找到了一个解为100，而新的起点到数组结尾总共才100项，就可以提前跳出循环了
        /// </summary>
        /// <param name="colors"></param>
        /// <returns></returns>
        public int MaxDistance(int[] colors)
        {
            int result = -1, len = colors.Length;
            int[] visited = new int[101];  // 题目保证了最多101种颜色
            for (int i = 0; i < len; i++)
            {
                if (len - 1 - i <= result) break;
                if (visited[colors[i]] != 0) continue;
                for (int j = len - 1; j > i; j--)
                {
                    if (colors[j] != colors[i])
                    {
                        result = Math.Max(result, j - i); break;
                    }
                }
                visited[colors[i]] = 1;
            }

            return result;
        }
    }
}
