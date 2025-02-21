using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0832
{
    public class Solution0832_2 : Interface0832
    {
        /// <summary>
        /// 分析
        /// 横向翻转的时候
        ///     如果对称的元素不等，不需要操作
        ///     如果对称的元素相等，两个元素直接取反即可
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
                    if (image[r][left] == image[r][right])
                        image[r][left] = image[r][right] = image[r][left] ^ 1;
                }
                image[r][left] ^= 1 - left + right;  // if(left == right) image[r][left] ^= 1
            }

            return image;
        }

        /// <summary>
        /// 与FlipAndInvertImage()一样
        /// 将if-else改为位运算，据说这样CPU执行更快，没有验证
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public int[][] FlipAndInvertImage2(int[][] image)
        {
            int n = image.Length;
            for (int r = 0, left = 0, right = 0, diff = 0; r < n; r++)
            {
                left = -1; right = n;
                while (++left < --right)
                {
                    diff = Math.Abs(image[r][left] - image[r][right]);
                    image[r][left] ^= 1 - diff;
                    image[r][right] ^= 1 - diff;
                }
                image[r][left] ^= 1 - left + right;
            }

            return image;
        }
    }
}
