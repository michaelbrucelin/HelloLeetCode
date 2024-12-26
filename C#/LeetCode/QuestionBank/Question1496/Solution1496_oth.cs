using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1496
{
    public class Solution1496_oth : Interface1496
    {
        public bool IsPathCrossing(string path)
        {
            HashSet<int> set = new HashSet<int>() { 0 };
            int pos = 0;
            for (int i = 0; i < path.Length; i++)
            {
                switch (path[i])
                {
                    case 'N': pos += 10003; break;
                    case 'S': pos -= 10003; break;
                    case 'E': pos += 10004; break;
                    case 'W': pos -= 10004; break;
                    default: break;
                }

                if (set.Contains(pos)) return true;
                set.Add(pos);
            }

            return false;
        }
    }
}
