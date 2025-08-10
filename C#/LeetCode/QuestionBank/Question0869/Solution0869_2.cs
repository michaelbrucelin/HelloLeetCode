using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0869
{
    public class Solution0869_2 : Interface0869
    {
        private static readonly HashSet<int> set = [1, 2, 4, 8, 61, 32, 64, 821, 652, 521, 4210, 8420, 9640, 9821, 86431, 87632, 66553,
            732110, 644221, 885422, 8765410, 9752210, 9444310, 8888630, 77766211, 55443332, 88766410, 877432211, 866554432, 987653210];

        /// <summary>
        /// Hash
        /// 逻辑与Solution0869一样，提前将Hash表预处理出来
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool ReorderedPowerOf2(int n)
        {
            int[] freq = new int[10];
            return set.Contains(gethashint(n));

            int gethashint(int x)  // 这里使用最大的字典序整数做为hash值
            {
                Array.Fill(freq, 0);
                while (x > 0) { freq[x % 10]++; x /= 10; }
                int y = 0;
                for (int i = 9; i >= 0; i--) for (int j = 0; j < freq[i]; j++) y = y * 10 + i;
                return y;
            }
        }
    }
}
