using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2511
{
    public class Solution2511 : Interface2511
    {
        /// <summary>
        /// 分析
        /// 就是在找1与-1之间0的最大数量，遍历两次
        ///     第1次从前向后遍历，找出1与-1之间的0的数量
        ///     第2次从后向前遍历，找出-1与1之间的0的数量
        /// </summary>
        /// <param name="forts"></param>
        /// <returns></returns>
        public int CaptureForts(int[] forts)
        {
            int result = 0;
            int cnt = 0, len = forts.Length; bool flag = false;
            for (int i = 0; i < len; i++)
            {
                switch (forts[i])
                {
                    case 1: flag = true; cnt = 0; break;
                    case 0: if (flag) cnt++; break;
                    case -1: result = Math.Max(result, cnt); flag = false; cnt = 0; break;
                    default: break;
                }
            }
            for (int i = len - 1; i >= 0; i--)
            {
                switch (forts[i])
                {
                    case 1: flag = true; cnt = 0; break;
                    case 0: if (flag) cnt++; break;
                    case -1: result = Math.Max(result, cnt); flag = false; cnt = 0; break;
                    default: break;
                }
            }

            return result;
        }

        /// <summary>
        /// 同CaptureForts()，改为1次遍历
        /// </summary>
        /// <param name="forts"></param>
        /// <returns></returns>
        public int CaptureForts2(int[] forts)
        {
            int result = 0;
            int cnt = 0, len = forts.Length; int flag = 0;
            for (int i = 0; i < len; i++)
            {
                switch (forts[i])
                {
                    case 1:
                        if (flag == -1) result = Math.Max(result, cnt);
                        flag = 1; cnt = 0;
                        break;
                    case 0:
                        cnt++;
                        break;
                    case -1:
                        if (flag == 1) result = Math.Max(result, cnt);
                        flag = -1; cnt = 0;
                        break;
                    default:
                        break;
                }
            }

            return result;
        }
    }
}
