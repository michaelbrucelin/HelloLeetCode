using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1157
{
    public class Solution1157_2
    {
    }

    /// <summary>
    /// “前缀和”
    /// 将数组以前缀和的形式处理为每个元素出现次数的字典，这样可以更快的统计出任意分段每个元素出现的次数
    /// 
    /// 提交会内存溢出，参考测试用例02
    /// </summary>
    public class MajorityChecker_2 : Interface1157
    {
        public MajorityChecker_2(int[] arr)
        {
            pre = new Dictionary<int, int>[arr.Length + 1];
            pre[0] = new Dictionary<int, int>();
            Dictionary<int, int> freq = new Dictionary<int, int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (freq.ContainsKey(arr[i])) freq[arr[i]]++; else freq.Add(arr[i], 1);
                pre[i + 1] = new Dictionary<int, int>(freq);
            }
        }

        private Dictionary<int, int>[] pre;

        public int Query(int left, int right, int threshold)
        {
            foreach (int key in pre[right + 1].Keys)
            {
                int cnt = pre[right + 1][key] - (pre[left].ContainsKey(key) ? pre[left][key] : 0);
                if (cnt >= threshold) return key;
            }

            return -1;
        }
    }
}
