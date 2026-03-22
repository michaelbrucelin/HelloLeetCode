using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1998
{
    public class Solution1998 : Interface1998
    {
        /// <summary>
        /// 并查集 + 堆排序
        /// 并查集找出可以互换位置的组，每个组内部排序，看结果和整体排序的结果是否一致即可
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool GcdSort(int[] nums)
        {
            int len = nums.Length;
            int[] uf = new int[len], height = new int[len];
            for (int i = 1; i < len; i++) uf[i] = i;
            

            throw new NotImplementedException();

            static int gcd(int x, int y)
            {
                if (x == y) return x;

                int move = 0;
                while (x != y) switch ((x & 1, y & 1))
                    {
                        case (0, 0): x >>= 1; y >>= 1; move++; break;
                        case (0, 1): x >>= 1; break;
                        case (1, 0): y >>= 1; break;
                        default:  // (1, 1)
                            if (x > y) x = (x - y) >> 1; else y = (y - x) >> 1;
                            break;
                    }

                return x << move;
            }

            void union(int x, int y)
            {
                x = find(x); y = find(y);
                if (x == y) return;
                if (height[x] == height[y])
                {
                    uf[y] = x; height[x]++;
                }
                else
                {
                    if (height[x] > height[y]) uf[y] = x; else uf[x] = y;
                }
            }

            int find(int x)
            {
                int f = x;
                while (uf[f] != f) f = uf[f];
                int i = x, j;
                while (uf[i] != f)
                {
                    j = uf[i]; uf[i] = f; i = j;
                }

                return f;
            }
        }
    }
}
