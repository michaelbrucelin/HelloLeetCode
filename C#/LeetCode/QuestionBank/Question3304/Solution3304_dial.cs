using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3304
{
    public class Solution3304_dial : Interface3304
    {
        private static readonly char[] dial = ['\0', 'a', 'b', 'b', 'c', 'b', 'c', 'c', 'd', 'b', 'c', 'c', 'd', 'c', 'd', 'd', 'e', 'b', 'c', 'c', 'd', 'c', 'd', 'd', 'e', 'c',
            'd', 'd', 'e', 'd', 'e', 'e', 'f', 'b', 'c', 'c', 'd', 'c', 'd', 'd', 'e', 'c', 'd', 'd', 'e', 'd', 'e', 'e', 'f', 'c', 'd', 'd', 'e', 'd', 'e', 'e', 'f', 'd', 'e',
            'e', 'f', 'e', 'f', 'f', 'g', 'b', 'c', 'c', 'd', 'c', 'd', 'd', 'e', 'c', 'd', 'd', 'e', 'd', 'e', 'e', 'f', 'c', 'd', 'd', 'e', 'd', 'e', 'e', 'f', 'd', 'e', 'e',
            'f', 'e', 'f', 'f', 'g', 'c', 'd', 'd', 'e', 'd', 'e', 'e', 'f', 'd', 'e', 'e', 'f', 'e', 'f', 'f', 'g', 'd', 'e', 'e', 'f', 'e', 'f', 'f', 'g', 'e', 'f', 'f', 'g',
            'f', 'g', 'g', 'h', 'b', 'c', 'c', 'd', 'c', 'd', 'd', 'e', 'c', 'd', 'd', 'e', 'd', 'e', 'e', 'f', 'c', 'd', 'd', 'e', 'd', 'e', 'e', 'f', 'd', 'e', 'e', 'f', 'e',
            'f', 'f', 'g', 'c', 'd', 'd', 'e', 'd', 'e', 'e', 'f', 'd', 'e', 'e', 'f', 'e', 'f', 'f', 'g', 'd', 'e', 'e', 'f', 'e', 'f', 'f', 'g', 'e', 'f', 'f', 'g', 'f', 'g',
            'g', 'h', 'c', 'd', 'd', 'e', 'd', 'e', 'e', 'f', 'd', 'e', 'e', 'f', 'e', 'f', 'f', 'g', 'd', 'e', 'e', 'f', 'e', 'f', 'f', 'g', 'e', 'f', 'f', 'g', 'f', 'g', 'g',
            'h', 'd', 'e', 'e', 'f', 'e', 'f', 'f', 'g', 'e', 'f', 'f', 'g', 'f', 'g', 'g', 'h', 'e', 'f', 'f', 'g', 'f', 'g', 'g', 'h', 'f', 'g', 'g', 'h', 'g', 'h', 'h', 'i',
            'b', 'c', 'c', 'd', 'c', 'd', 'd', 'e', 'c', 'd', 'd', 'e', 'd', 'e', 'e', 'f', 'c', 'd', 'd', 'e', 'd', 'e', 'e', 'f', 'd', 'e', 'e', 'f', 'e', 'f', 'f', 'g', 'c',
            'd', 'd', 'e', 'd', 'e', 'e', 'f', 'd', 'e', 'e', 'f', 'e', 'f', 'f', 'g', 'd', 'e', 'e', 'f', 'e', 'f', 'f', 'g', 'e', 'f', 'f', 'g', 'f', 'g', 'g', 'h', 'c', 'd',
            'd', 'e', 'd', 'e', 'e', 'f', 'd', 'e', 'e', 'f', 'e', 'f', 'f', 'g', 'd', 'e', 'e', 'f', 'e', 'f', 'f', 'g', 'e', 'f', 'f', 'g', 'f', 'g', 'g', 'h', 'd', 'e', 'e',
            'f', 'e', 'f', 'f', 'g', 'e', 'f', 'f', 'g', 'f', 'g', 'g', 'h', 'e', 'f', 'f', 'g', 'f', 'g', 'g', 'h', 'f', 'g', 'g', 'h', 'g', 'h', 'h', 'i', 'c', 'd', 'd', 'e',
            'd', 'e', 'e', 'f', 'd', 'e', 'e', 'f', 'e', 'f', 'f', 'g', 'd', 'e', 'e', 'f', 'e', 'f', 'f', 'g', 'e', 'f', 'f', 'g', 'f', 'g', 'g', 'h', 'd', 'e', 'e', 'f', 'e',
            'f', 'f', 'g', 'e', 'f', 'f', 'g', 'f', 'g', 'g', 'h', 'e', 'f', 'f', 'g', 'f', 'g', 'g', 'h', 'f', 'g', 'g', 'h', 'g', 'h', 'h', 'i', 'd', 'e', 'e', 'f', 'e', 'f',
            'f', 'g', 'e', 'f', 'f', 'g', 'f', 'g', 'g', 'h', 'e', 'f', 'f', 'g', 'f', 'g', 'g', 'h', 'f', 'g', 'g', 'h', 'g', 'h', 'h', 'i', 'e', 'f', 'f', 'g', 'f', 'g', 'g',
            'h', 'f', 'g', 'g', 'h', 'g', 'h', 'h', 'i', 'f', 'g', 'g', 'h'];

        public char KthCharacter(int k)
        {
            return dial[k];
        }
    }
}
