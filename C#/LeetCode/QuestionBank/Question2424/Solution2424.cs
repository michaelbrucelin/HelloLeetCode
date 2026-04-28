using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2424
{
    public class Solution2424
    {
    }

    /// <summary>
    /// 树状数组 + 二分
    /// 使用数组表示每一项是否上传，上传为1，未上传为0，则前n项和为n就表示前n项全部上传
    /// 如果前n项全部上传，那么前[1..n-1]项也全部上传，所以可以二分查找
    /// 使用树状数组表示每一项是否上传的数组，可以O(1)的计算前n项的和
    /// </summary>
    public class LUPrefix : Interface2424
    {
        public LUPrefix(int n)
        {
            fenwick = new int[n + 1];
            this.n = n;
            cnt = 0;
        }

        private int[] fenwick;
        private int n;
        private int cnt;

        public void Upload(int video)
        {
            fenwick_add(video, 1);
            cnt++;
        }

        public int Longest()
        {
            int result = 0, left = 1, right = cnt, mid;
            while (left <= right)
            {
                mid = left + ((right - left) >> 1);
                if (fenwick_sum(mid) == mid)
                {
                    result = mid; left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return result;
        }

        private void fenwick_add(int idx, int val)
        {
            while (idx <= n)
            {
                fenwick[idx] += val;
                idx += idx & (-idx);
            }
        }

        private int fenwick_sum(int idx)
        {
            int result = 0;
            while (idx > 0)
            {
                result += fenwick[idx];
                idx -= idx & (-idx);
            }
            return result;
        }
    }
}
