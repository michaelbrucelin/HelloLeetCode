using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0393
{
    public class Solution0393 : Interface0393
    {
        /// <summary>
        /// 遍历
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool ValidUtf8(int[] data)
        {
            int follow = 0, len = data.Length;
            for (int i = 0; i < len; i++)
            {
                if (follow == 0)
                {
                    follow = GetFollow(data[i]);
                    if (follow == -1) return false;
                }
                else
                {
                    if ((data[i] & 192) != 128) return false;
                    follow--;
                }
            }

            return follow == 0;

            static int GetFollow(int x)
            {
                if ((x & 128) == 0) return 0;
                if ((x & 224) == 192) return 1;
                if ((x & 240) == 224) return 2;
                if ((x & 248) == 240) return 3;
                return -1;
            }
        }
    }
}
