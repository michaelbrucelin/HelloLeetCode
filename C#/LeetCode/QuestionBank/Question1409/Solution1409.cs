using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1409
{
    public class Solution1409 : Interface1409
    {
        /// <summary>
        /// 暴力模拟
        /// </summary>
        /// <param name="queries"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public int[] ProcessQueries(int[] queries, int m)
        {
            List<int> list = new List<int>();
            for (int i = 1; i <= m; i++) list.Add(i);

            int len = queries.Length;
            int[] result = new int[len];
            for (int i = 0; i < len; i++) for (int j = 0; j < m; j++) if (list[j] == queries[i])
                    {
                        result[i] = j;
                        list.RemoveAt(j);
                        list.Insert(0, queries[i]);
                        break;
                    }

            return result;
        }

        /// <summary>
        /// 逻辑完全同ProcessQueries()，换一种“类插入排序”的操作方式
        /// </summary>
        /// <param name="queries"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public int[] ProcessQueries2(int[] queries, int m)
        {
            List<int> list = new List<int>();
            for (int i = 1; i <= m; i++) list.Add(i);

            int len = queries.Length;
            int[] result = new int[len];
            for (int i = 0; i < len; i++) for (int j = 0; j < m; j++) if (list[j] == queries[i])
                    {
                        result[i] = j;
                        for (int k = j; k > 0; k--) list[k] = list[k - 1];
                        list[0] = queries[i];
                        break;
                    }

            return result;
        }

        /// <summary>
        /// 逻辑完全同ProcessQueries()，将列表改为链表试一下
        /// </summary>
        /// <param name="queries"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public int[] ProcessQueries3(int[] queries, int m)
        {
            LinkedList<int> list = new LinkedList<int>();
            for (int i = 1; i <= m; i++) list.AddLast(i);

            int len = queries.Length;
            int[] result = new int[len];
            LinkedListNode<int> ptr;
            for (int i = 0, j = 0; i < len; i++, j = 0)
            {
                ptr = list.First;
                while (ptr.Value != queries[i]) { ptr = ptr.Next; j++; }
                result[i] = j;
                list.Remove(ptr);
                list.AddFirst(ptr);
            }

            return result;
        }
    }
}
