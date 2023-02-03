using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0278
{
    public class VersionControl
    {
        private static readonly Random random = new Random();

        public bool IsBadVersion(int version)
        {
            return random.Next(2) != 0;
        }
    }
}
