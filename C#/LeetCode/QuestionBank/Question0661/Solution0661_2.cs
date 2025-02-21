using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0661
{
    public class Solution0661_2 : Interface0661
    {
        /// <summary>
        /// 滑动窗口
        /// 1. 先每一行滑动窗口计算出连续三项的和记录下来
        /// 2. 再纵向滑动窗口计算灰度值
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public int[][] ImageSmoother(int[][] img)
        {
            int rcnt = img.Length, ccnt = img[0].Length;
            int[][] rsum = new int[rcnt][];
            for (int r = 0, win; r < rcnt; r++)
            {
                win = img[r][0]; rsum[r] = new int[ccnt];
                for (int c = 0; c < ccnt; c++)
                {
                    if (c - 2 >= 0) win -= img[r][c - 2];
                    if (c + 1 < ccnt) win += img[r][c + 1];
                    rsum[r][c] = win;
                }
            }

            int[][] result = new int[rcnt][];
            for (int i = 0; i < rcnt; i++) result[i] = new int[ccnt];
            for (int c = 0, win = 0, cnt = 0, _cnt = 0; c < ccnt; c++)
            {
                win = rsum[0][c];
                for (int r = 0; r < rcnt; r++)
                {
                    if (r - 2 >= 0) win -= rsum[r - 2][c];
                    if (r + 1 < rcnt) win += rsum[r + 1][c];
                    cnt = 9; _cnt = 3;
                    if (r - 1 < 0) { cnt -= 3; _cnt -= 1; }
                    if (r + 1 == rcnt) { cnt -= 3; _cnt -= 1; }
                    if (c - 1 < 0) cnt -= _cnt;
                    if (c + 1 == ccnt) cnt -= _cnt;
                    result[r][c] = win / cnt;
                }
            }

            return result;
        }

        /// <summary>
        /// 滑动窗口 + 原地
        /// 1. 先每一行滑动窗口计算出连续三项的和记录下来
        /// 2. 再纵向滑动窗口计算灰度值
        /// 3. 低8位存原值及结果，8-17位存第1步的和
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public int[][] ImageSmoother2(int[][] img)
        {
            int rcnt = img.Length, ccnt = img[0].Length;
            for (int r = 0, win; r < rcnt; r++)
            {
                win = img[r][0];
                for (int c = 0; c < ccnt; c++)
                {
                    if (c - 2 >= 0) win -= img[r][c - 2] & 255;
                    if (c + 1 < ccnt) win += img[r][c + 1] & 255;
                    img[r][c] |= win << 8;
                }
            }

            for (int c = 0, win = 0, cnt = 0, _cnt = 0; c < ccnt; c++)
            {
                win = img[0][c] >> 8;
                for (int r = 0; r < rcnt; r++)
                {
                    if (r - 2 >= 0) win -= img[r - 2][c] >> 8;
                    if (r + 1 < rcnt) win += img[r + 1][c] >> 8;
                    cnt = 9; _cnt = 3;
                    if (r - 1 < 0) { cnt -= 3; _cnt -= 1; }
                    if (r + 1 == rcnt) { cnt -= 3; _cnt -= 1; }
                    if (c - 1 < 0) cnt -= _cnt;
                    if (c + 1 == ccnt) cnt -= _cnt;
                    img[r][c] = ((img[r][c] >> 8) << 8) | (win / cnt);
                }
            }

            for (int r = 0; r < rcnt; r++) for (int c = 0; c < ccnt; c++)
                {
                    img[r][c] &= 255;
                }

            return img;
        }
    }
}
