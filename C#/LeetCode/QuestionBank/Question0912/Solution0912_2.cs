using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0912
{
    public class Solution0912_2 : Interface0912
    {
        /// <summary>
        /// 基数排序
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int[] SortArray(int[] nums)
        {
            List<int>[] pos = new List<int>[10], neg = new List<int>[10];
            List<int>[] _pos = new List<int>[10], _neg = new List<int>[10];
            for (int i = 0; i < 10; i++) { pos[i] = []; neg[i] = []; }

            // >=0
            bool flag = false; int radix = 1, radix_next = 10;
            foreach (int num in nums) if (num >= 0)
                {
                    pos[num % 10].Add(num); if (num >= radix_next) flag = true;
                }
            while (flag)
            {
                flag = false; radix *= 10; radix_next *= 10;
                for (int i = 0; i < 10; i++) _pos[i] = [];
                for (int i = 0; i < 10; i++) foreach (int num in pos[i])
                    {
                        _pos[num / radix % 10].Add(num); if (num >= radix_next) flag = true;
                    }
                for (int i = 0; i < 10; i++) pos[i] = _pos[i];
            }
            // <0
            flag = false; radix = 1; radix_next = 10;
            foreach (int num in nums) if (num < 0)
                {
                    neg[(-num) % 10].Add(-num); if (-num >= radix_next) flag = true;
                }
            while (flag)
            {
                flag = false; radix *= 10; radix_next *= 10;
                for (int i = 0; i < 10; i++) _neg[i] = [];
                for (int i = 0; i < 10; i++) foreach (int num in neg[i])
                    {
                        _neg[num / radix % 10].Add(num); if (num >= radix_next) flag = true;
                    }
                for (int i = 0; i < 10; i++) neg[i] = _neg[i];
            }

            int p = 0;
            for (int i = 9; i >= 0; i--) for (int j = neg[i].Count - 1; j >= 0; j--) nums[p++] = -neg[i][j];
            for (int i = 0; i < 10; i++) for (int j = 0; j < pos[i].Count; j++) nums[p++] = pos[i][j];
            return nums;
        }
    }
}
