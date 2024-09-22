using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2326
{
    public class Solution2326 : Interface2326
    {
        /// <summary>
        /// 模拟，状态机
        /// 定义上、右、下、左四个边界分别为up, right, down, left
        /// 1. 向右，r取[up, up]，    c取[left, right]， 完后，up++；
        /// 2. 向下，r取[up, down]，  c取[right, right]，完后，right--；
        /// 3. 向左，r取[down, down]，c取[right, left]， 完后，down--；
        /// 4. 向上，r取[down, up]，  c取[left, left]，  完后，left++；
        /// 1, 2, 3, 4这4个步骤循环执行即可
        /// 由于C#中没有指针，所以可以考虑将up, right, down, left放入数组，这样就方便定义状态机了
        /// </summary>
        /// <param name="m"></param>
        /// <param name="n"></param>
        /// <param name="head"></param>
        /// <returns></returns>
        public int[][] SpiralMatrix(int m, int n, ListNode head)
        {
            int[][] result = new int[m][];
            for (int i = 0; i < m; i++) result[i] = new int[n];
            int[] border = [0, n - 1, m - 1, 0];  // up, right, down, left
            Func<int, int, bool> leo = (x, y) => x <= y, geo = (x, y) => x >= y;
            Func<int, int> lea = x => x + 1, gea = x => x - 1;
            Queue<(int r1, int r2, Func<int, int, bool> ro, Func<int, int> ra, int c1, int c2, Func<int, int, bool> co, Func<int, int> ca, int id, int icr)> queue
                = new Queue<(int r1, int r2, Func<int, int, bool> ro, Func<int, int> ra, int c1, int c2, Func<int, int, bool> co, Func<int, int> ca, int id, int icr)>();
            queue.Enqueue((0, 0, leo, lea, 3, 1, leo, lea, 0, 1));
            queue.Enqueue((0, 2, leo, lea, 1, 1, leo, lea, 1, -1));
            queue.Enqueue((2, 2, leo, lea, 1, 3, geo, gea, 2, -1));
            queue.Enqueue((2, 0, geo, gea, 3, 3, leo, lea, 3, 1));
            int cnt = 0, total = m * n;
            (int r1, int r2, Func<int, int, bool> ro, Func<int, int> ra, int c1, int c2, Func<int, int, bool> co, Func<int, int> ca, int id, int icr) p;
            while (cnt < total)
            {
                p = queue.Dequeue();
                for (int r = border[p.r1]; p.ro(r, border[p.r2]); r = p.ra(r)) for (int c = border[p.c1]; p.co(c, border[p.c2]); c = p.ca(c))
                    {
                        if (head != null)
                        {
                            result[r][c] = head.val; head = head.next;
                        }
                        else
                        {
                            result[r][c] = -1;
                        }
                        cnt++;
                    }
                border[p.id] += p.icr;
                queue.Enqueue(p);
            }

            return result;
        }
    }
}
