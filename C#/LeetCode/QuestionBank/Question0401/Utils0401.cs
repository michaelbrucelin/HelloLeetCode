using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0401
{
    public class Utils0401
    {
        public void Dial()
        {
            Interface0401 solution = new Solution0401();
            for (int i = 0; i <= 10; i++) Console.WriteLine($"{i}\t{Utils.ArrayToString(solution.ReadBinaryWatch(i))}");
        }
    }
}
