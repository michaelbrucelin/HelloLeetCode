using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2349
{
    public class Solution2349
    {
    }

    /// <summary>
    /// 两个字典
    /// </summary>
    public class NumberContainers : Interface2349
    {
        public NumberContainers()
        {
            idx2val = new Dictionary<int, int>();
            val2idx = new Dictionary<int, SortedSet<int>>();
        }

        private Dictionary<int, int> idx2val;
        private Dictionary<int, SortedSet<int>> val2idx;

        public void Change(int index, int number)
        {
            if (idx2val.ContainsKey(index))
            {
                int _number = idx2val[index];
                if (val2idx[_number].Count > 1) val2idx[_number].Remove(index); else val2idx.Remove(_number);
                idx2val[index] = number;
                if (val2idx.ContainsKey(number)) val2idx[number].Add(index); else val2idx.Add(number, [index]);
            }
            else
            {
                idx2val.Add(index, number);
                if (val2idx.ContainsKey(number)) val2idx[number].Add(index); else val2idx.Add(number, [index]);
            }
        }

        public int Find(int number)
        {
            if (val2idx.ContainsKey(number)) return val2idx[number].First();
            return -1;
        }
    }
}
