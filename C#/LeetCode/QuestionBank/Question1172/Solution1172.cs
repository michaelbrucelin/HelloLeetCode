using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1172
{
    public class Solution1172
    {
    }

    /// <summary>
    /// 用List<Stack<int>>存储数据
    /// 如果capacity == 1，就使用List<int>存储数据
    /// 1. push()操作，可能会慢，因为不清楚可以push的位置
    ///     可以使用有序集合记录可以push的位置，如果有序集合为空，就需要创建一个新的栈
    ///     之所以没有使用优先级队列，是因为如果最后一个栈空，这里设计将其移除，这时需要将其id从优先级队列中移除
    /// 2. pop()操作，不会慢，直接从最后一个栈中弹出元素即可
    /// 3. popAtStack(int index)操作，不会慢，因为知道从哪个栈中移除元素
    /// </summary>
    public class DinnerPlates : Interface1172
    {
        public DinnerPlates(int capacity)
        {
            if (capacity > 1)
            {
                istack = true;
                stack = new List<Stack<int>>();
                this.capacity = capacity;
            }
            else
            {
                istack = false;
                list = new List<int>();
            }
            pos = new SortedSet<int>();
        }

        private List<Stack<int>> stack;
        private List<int> list;
        private SortedSet<int> pos;
        private bool istack;
        private int capacity;

        public int Pop()
        {
            return istack ? Pop_Stack() : Pop_List();
        }

        public int PopAtStack(int index)
        {
            return istack ? PopAt_Stack(index) : PopAt_List(index);
        }

        public void Push(int val)
        {
            if (istack) Push_Stack(val); else Push_List(val);
        }

        private int Pop_Stack()
        {
            if (stack.Count == 0) return -1;

            int id = stack.Count - 1;
            int result = stack[id].Pop();   // 当前设计是实时收缩，所以一定不会是空栈
            if (stack[id].Count == capacity - 1)
            {
                pos.Add(id);
            }
            else if (stack[id].Count == 0)  // 实时收缩，性能并不一定好，这里只是练习
            {
                pos.Remove(id); stack.RemoveAt(id);
                while (stack.Count > 0 && stack[^1].Count == 0)
                {
                    stack.RemoveAt(stack.Count - 1); pos.Remove(stack.Count - 1);
                }
            }

            return result;
        }

        private int Pop_List()
        {
            if (list.Count == 0) return -1;

            int id = list.Count - 1;
            int result = list[id];
            list.RemoveAt(id);
            while (--id >= 0 && pos.Contains(id))
            {
                list.RemoveAt(id); pos.Remove(id);
            }

            return result;
        }

        private int PopAt_Stack(int index)
        {
            if (stack.Count <= index || stack[index].Count == 0) return -1;
            if (index == stack.Count - 1) return Pop();

            int result = stack[index].Pop();
            if (stack[index].Count == capacity - 1)
            {
                pos.Add(index);
            }

            return result;
        }

        private int PopAt_List(int index)
        {
            if (list.Count <= index) return -1;
            if (index == list.Count - 1) return Pop();

            int result = list[index];
            pos.Add(index);

            return result;
        }

        private void Push_Stack(int val)
        {
            if (pos.Count > 0)
            {
                int id = pos.First();
                stack[id].Push(val);
                if (stack[id].Count == capacity) pos.Remove(id);
            }
            else
            {
                stack.Add(new Stack<int>());
                int id = stack.Count - 1;
                stack[id].Push(val);
                pos.Add(id);  // 如果capacity == 1，直接降为数组处理，所以这里一定不会满栈
            }
        }

        private void Push_List(int val)
        {
            if (pos.Count > 0)
            {
                int id = pos.First();
                list[id] = val;
                pos.Remove(id);
            }
            else
            {
                list.Add(val);
            }
        }
    }
}
