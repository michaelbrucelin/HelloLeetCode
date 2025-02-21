using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0832
{
    public class Solution0832 : Interface0832
    {
        /// <summary>
        /// 模拟
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public int[][] FlipAndInvertImage(int[][] image)
        {
            int n = image.Length;
            for (int r = 0, left = 0, right = 0; r < n; r++)
            {
                left = -1; right = n;
                while (++left < --right)
                {
                    int num = image[r][left]; image[r][left] = image[r][right]; image[r][right] = num;
                }
                for (int c = 0; c < n; c++) image[r][c] ^= 1;
            }

            return image;
        }

        /// <summary>
        /// 模拟
        /// 将交换变量改为位运算
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public int[][] FlipAndInvertImage2(int[][] image)
        {
            int n = image.Length;
            for (int r = 0, left = 0, right = 0; r < n; r++)
            {
                left = -1; right = n;
                while (++left < --right)
                {
                    image[r][left] ^= image[r][right]; image[r][right] ^= image[r][left]; image[r][left] ^= image[r][right];
                }
                for (int c = 0; c < n; c++) image[r][c] ^= 1;
            }

            return image;
        }

        /// <summary>
        /// 模拟
        /// 优化，交换变量与取反可以一步完成
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public int[][] FlipAndInvertImage3(int[][] image)
        {
            int n = image.Length;
            for (int r = 0, left = 0, right = 0; r < n; r++)
            {
                left = -1; right = n;
                while (++left < --right)
                {
                    int num = image[r][left]; image[r][left] = image[r][right] ^ 1; image[r][right] = num ^ 1;
                }
                image[r][left] ^= 1 - left + right;  // if(left == right) image[r][left] ^= 1
            }

            return image;
        }
    }
}
