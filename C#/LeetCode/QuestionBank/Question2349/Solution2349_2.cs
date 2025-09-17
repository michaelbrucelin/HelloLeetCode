using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2349
{
    public class Solution2349_2
    {
    }

    /// <summary>
    /// 两个字典
    /// 逻辑同Solution2349，将其中的SortedSet()换成 小顶堆+懒删除 的形式
    /// </summary>
    public class NumberContainers_2 : Interface2349
    {
        public NumberContainers_2()
        {
            idx2val = new Dictionary<int, int>();
            val2idx = new Dictionary<int, PriorityQueue<int, int>>();
        }

        private Dictionary<int, int> idx2val;
        private Dictionary<int, PriorityQueue<int, int>> val2idx;

        public void Change(int index, int number)
        {
            if (idx2val.ContainsKey(index)) idx2val[index] = number; else idx2val.Add(index, number);
            if (!val2idx.ContainsKey(number)) val2idx.Add(number, new PriorityQueue<int, int>());
            val2idx[number].Enqueue(index, index);
        }

        public int Find(int number)
        {
            if (!val2idx.ContainsKey(number)) return -1;
            while (val2idx[number].Count > 0 && idx2val[val2idx[number].Peek()] != number) val2idx[number].Dequeue();
            if (val2idx[number].Count > 0) return val2idx[number].Peek(); else val2idx.Remove(number);
            return -1;
        }
    }
}
