using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0633
{
    public class Utils0633
    {
        public void Dial()
        {
            int limit = (int)Math.Sqrt(int.MaxValue);
            List<int> list = new List<int>();
            for (int i = 0; i <= limit; i++) list.Add(i * i);
            Utils.Dump(list);
        }
    }
}
