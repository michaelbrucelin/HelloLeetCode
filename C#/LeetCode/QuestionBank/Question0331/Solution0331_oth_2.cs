using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0331
{
    public class Solution0331_oth_2 : Interface0331
    {
        public bool IsValidSerialization(string preorder)
        {
            bool[] order = preorder.Split(',').Select(s => s[0] != '#').ToArray();
            List<bool> list = new List<bool>();
            foreach (bool item in order)
            {
                list.Add(item);
                while (list.Count >= 3 && !list[^1] && !list[^2] && list[^3])
                {
                    list.RemoveAt(list.Count - 1); list.RemoveAt(list.Count - 1); list.RemoveAt(list.Count - 1);
                    list.Add(false);
                }
            }

            return list.Count == 1 && !list[0];
        }
    }
}
