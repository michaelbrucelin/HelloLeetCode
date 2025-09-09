using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2327
{
    public class Solution2327_2 : Interface2327
    {
        /// <summary>
        /// 链表
        /// 逻辑完全同Solution2327，仔细看Solution2327中的数组操作，如果换成链表操作数会少得多，但是内存消耗会大一些
        /// </summary>
        /// <param name="n"></param>
        /// <param name="delay"></param>
        /// <param name="forget"></param>
        /// <returns></returns>
        public int PeopleAwareOfSecret(int n, int delay, int forget)
        {
            const int MOD = (int)1e9 + 7;
            LinkedList<int> list = new LinkedList<int>();
            list.AddFirst(1);
            for (int i = 1; i < forget; i++) list.AddLast(0);

            int temp; LinkedListNode<int> ptr;
            while (--n > 0)
            {
                temp = 0;
                ptr = list.Last;
                for (int i = forget; i > delay; i--)
                {
                    ptr = ptr.Previous;
                    temp = (temp + ptr.Value) % MOD;
                }
                list.RemoveLast();
                list.AddFirst(temp);
            }

            int result = 0;
            ptr = list.First;
            while (ptr != null)
            {
                result = (result + ptr.Value) % MOD;
                ptr = ptr.Next;
            }
            return result;
        }

        /// <summary>
        /// 逻辑同PeopleAwareOfSecret，节省点内存
        /// </summary>
        /// <param name="n"></param>
        /// <param name="delay"></param>
        /// <param name="forget"></param>
        /// <returns></returns>
        public int PeopleAwareOfSecret2(int n, int delay, int forget)
        {
            const int MOD = (int)1e9 + 7;
            LinkedList<int> list = new LinkedList<int>();
            list.AddFirst(1);
            for (int i = 1; i < forget; i++) list.AddLast(0);

            int temp; LinkedListNode<int> ptr;
            while (--n > 0)
            {
                temp = 0;
                ptr = list.Last;
                for (int i = forget; i > delay; i--)
                {
                    ptr = ptr.Previous;
                    temp = (temp + ptr.Value) % MOD;
                }
                ptr = list.Last;
                list.RemoveLast();
                ptr.Value = temp;
                list.AddFirst(ptr);
            }

            int result = 0;
            ptr = list.First;
            while (ptr != null)
            {
                result = (result + ptr.Value) % MOD;
                ptr = ptr.Next;
            }
            return result;
        }
    }
}
