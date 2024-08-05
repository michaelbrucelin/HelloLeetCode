using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0600
{
    public class Solution0600_3 : Interface0600
    {
        /// <summary>
        /// 逻辑与Solution0600_2一样，将递归1:1翻译为迭代
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int FindIntegers(int n)
        {
            if (n < 3) return n + 1;

            int[] dial = new int[32];
            dial[0] = 2; dial[1] = 3;
            for (int i = 2; i < 32; i++) dial[i] = dial[i - 1] + dial[i - 2];

            List<int> bits = new List<int>();
            while (n > 0) { bits.Add(n & 1); n >>= 1; }

            return _FindIntegers(bits.Count - 1);

            int _FindIntegers(int right)
            {
                Dictionary<int, int> memory = new Dictionary<int, int>();
                Stack<int> stack = new Stack<int>();
                stack.Push(right);
                int item, _item;
                while (stack.Count > 0)
                {
                    item = _item = stack.Pop();
                    while (_item >= 0 && bits[_item] == 0) _item--;
                    if (memory.ContainsKey(_item))
                    {
                        memory.Add(item, memory[_item]);
                    }
                    else
                    {
                        if (_item < 0) { memory.Add(item, 1); memory.TryAdd(_item, 1); continue; }
                        if (_item == 0) { memory.Add(item, 2); memory.TryAdd(_item, 2); continue; }
                        if (bits[_item - 1] == 1)
                        {
                            memory.Add(item, dial[_item - 1] + (_item >= 2 ? dial[_item - 2] : 1));
                            memory.TryAdd(_item, dial[_item - 1] + (_item >= 2 ? dial[_item - 2] : 1));
                        }
                        else
                        {
                            if (memory.ContainsKey(_item - 2))
                            {
                                memory.Add(item, dial[_item - 1] + _FindIntegers(_item - 2));
                                memory.TryAdd(_item, dial[_item - 1] + _FindIntegers(_item - 2));
                            }
                            else
                            {
                                stack.Push(item); stack.Push(_item - 2);
                            }
                        }
                    }
                }

                return memory[right];
            }
        }
    }
}
