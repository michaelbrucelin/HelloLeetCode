using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1093
{
    public class Solution1093_2 : Interface1093
    {
        /// <summary>
        /// 与Solution1093逻辑一样
        /// 多了一次遍历来计算平均值
        /// 计算平均值使用了S1/(C1+C2) + S/(C1+C2)的方式，这样做精度会降低，但是防溢出更强，试一下
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public double[] SampleStats(int[] count)
        {
            double[] result = new double[5];
            int cnt = 0, mode = -1;           // mode给初始值-1没有意义，只是欺骗ide的语法检测
            bool flag = true;                 // true表示还没有找到第一个值，false表示已经找到第一个值
            for (int i = 0; i < 256; i++)
            {
                if (count[i] == 0) continue;
                if (flag)
                {
                    result[0] = mode = i; flag = false;
                }
                else
                {
                    if (count[i] > count[mode]) mode = i;
                }
                result[1] = i;
                cnt += count[i];
            }
            result[4] = mode;
            for (int i = 0; i < 256; i++) result[2] += ((double)i) / cnt * count[i];

            if ((cnt & 1) != 0)
            {
                int id = (cnt >> 1) + 1, _cnt = 0;
                for (int i = 0; i < 256; i++)
                {
                    if ((_cnt += count[i]) >= id)
                    {
                        result[3] = i; break;
                    }
                }
            }
            else
            {
                int id = cnt >> 1, _cnt = 0; double val1 = -1, val2 = -1;
                for (int i = 0; i < 256; i++)
                {
                    _cnt += count[i];
                    if (val1 == -1 && _cnt >= id) val1 = i;
                    if (_cnt >= id + 1)
                    {
                        val2 = i; break;
                    }
                }
                result[3] = (val1 + val2) / 2;
            }

            return result;
        }
    }
}
