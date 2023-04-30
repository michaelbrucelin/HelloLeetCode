using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1238
{
    public class Solution1238 : Interface1238
    {
        /// <summary>
        /// 找规律
        /// n=1,    0    1
        /// n=2,   00   01   11   10
        /// n=3,  000  001  011  010  110  111  101  100
        /// n=4, 0000 0001 0011 0010 0110 0111 0101 0100 1100 1101 1111 1110 1010 1011 1001 1000
        /// n每增加1，就是先重复上一次的结果，然后将上一次的结果前面补一位并置为1，再将这组数据反序补充到结果即可
        /// 使用数学归纳法即可证明
        /// </summary>
        /// <param name="n"></param>
        /// <param name="start"></param>
        /// <returns></returns>
        public IList<int> CircularPermutation(int n, int start)
        {
            int len = 1 << n;
            int[] buffer = new int[len]; buffer[0] = 0; buffer[1] = 1;
            for (int i = 1, j = 2; i < n; j = 1 << ++i)
            {
                for (int k = 0; k < j; k++) buffer[j + k] = buffer[j - k - 1] | j;
            }

            int ptr = 0; for (; ptr < len && buffer[ptr] != start; ptr++) ;
            int[] result = new int[len];
            for (int i = 0; i < len - ptr; i++) result[i] = buffer[ptr + i];
            for (int i = len - ptr; i < len; i++) result[i] = buffer[ptr + i - len];

            return result;
        }
    }
}
