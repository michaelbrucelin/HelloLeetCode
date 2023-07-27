using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1528
{
    public class Solution1528_api : Interface1528
    {
        public string RestoreString(string s, int[] indices)
        {
            return s.ToCharArray()
                    .Select((c, id) => (c, id))
                    .OrderBy(t => indices[t.id])
                    .Select(t => t.c.ToString())
                    .Aggregate((c1, c2) => $"{c1}{c2}");
        }

        public string RestoreString2(string s, int[] indices)
        {
            return s.ToCharArray()
                    .Zip(indices)
                    .OrderBy(t => t.Second)
                    .Select(t => t.First.ToString())
                    .Aggregate((c1, c2) => $"{c1}{c2}");
        }
    }
}
