using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.LCR.LCR0152
{
    public class Solution0152 : Interface0152
    {
        /// <summary>
        /// 模拟
        /// 1. 仅知道后续遍历的序列，无法还原原二叉树，唯一确定的是最后一个值是根
        /// 2. 如果可以还原为二叉查找树，则除最后一个元素外，前面元素可以分为前后两部分
        ///     前面部分都小于根
        ///     后面部分都大于根
        /// </summary>
        /// <param name="postorder"></param>
        /// <returns></returns>
        public bool VerifyTreeOrder(int[] postorder)
        {
            if (postorder.Length < 3) return true;
            return VerifyTreeOrder(postorder, 0, postorder.Length - 1);

            static bool VerifyTreeOrder(int[] postorder, int left, int right)
            {
                if (left >= right) return true;
                int mid = left;
                while (mid < right && postorder[mid] < postorder[right]) mid++;  // 题目限定postorder中没有重复值
                for (int i = mid; i < right; i++) if (postorder[i] < postorder[right]) return false;

                return VerifyTreeOrder(postorder, left, mid - 1) && VerifyTreeOrder(postorder, mid, right - 1);
            }
        }
    }
}
