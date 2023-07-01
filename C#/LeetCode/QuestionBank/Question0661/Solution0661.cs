using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0661
{
    public class Solution0661 : Interface0661
    {
        /// <summary>
        /// 暴力解
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public int[][] ImageSmoother(int[][] img)
        {
            int rcnt = img.Length, ccnt = img[0].Length;
            int[][] result = new int[rcnt][];
            for (int i = 0; i < rcnt; i++) result[i] = new int[ccnt];
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++)
                {
                    int sum = 0, cnt = 0;
                    for (int _r = -1; _r <= 1; _r++) for (int _c = -1; _c <= 1; _c++)
                        {
                            int R = r + _r, C = c + _c;
                            if (R >= 0 && R < rcnt && C >= 0 && C < ccnt)
                            {
                                sum += img[R][C]; cnt++;
                            }
                        }
                    result[r][c] = sum / cnt;
                }

            return result;
        }

        /// <summary>
        /// 原地暴力解
        /// 低8位存原值，8-15位存灰度值
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public int[][] ImageSmoother2(int[][] img)
        {
            int rcnt = img.Length, ccnt = img[0].Length;
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++)
                {
                    int sum = 0, cnt = 0;
                    for (int _r = -1; _r <= 1; _r++) for (int _c = -1; _c <= 1; _c++)
                        {
                            int R = r + _r, C = c + _c;
                            if (R >= 0 && R < rcnt && C >= 0 && C < ccnt)
                            {
                                sum += img[R][C] & 255; cnt++;
                            }
                        }
                    img[r][c] |= (sum / cnt) << 8;
                }
            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++)
                {
                    img[r][c] >>= 8;
                }

            return img;
        }
    }
}
