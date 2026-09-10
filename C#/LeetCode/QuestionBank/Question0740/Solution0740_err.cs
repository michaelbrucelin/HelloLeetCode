using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0740
{
    public class Solution0740_err : Interface0740
    {
        /// <summary>
        /// 排序 + 分类讨论
        /// 排序后，如果有连续的值，这组连续的值只有两种选择的可能：0,2,4... 或 1,3,5...
        /// 
        /// 思路是错误的，参考测试用例03
        /// 例如 9 1 1 9，如果隔位取值，怎样取结果都是10，但是直接取两端的结果是18
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int DeleteAndEarn(int[] nums)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();
            for (int i = 0, num, len = nums.Length; i < len; i++)
            {
                if (map.TryGetValue(num = nums[i], out int sum)) map[num] = sum + num; else map.Add(num, num);
            }
            int idx = 0, cnt = map.Count;
            KeyValuePair<int, int>[] arr = new KeyValuePair<int, int>[cnt];
            foreach (KeyValuePair<int, int> kv in map) arr[idx++] = kv;
            Array.Sort(arr, (x, y) => x.Key - y.Key);

            int result = 0, sum1, sum2, p1 = 0, p2;
            while (p1 < cnt)
            {
                sum1 = sum2 = 0; p2 = p1;
                while (p2 + 1 < cnt && arr[p2 + 1].Key == arr[p2].Key + 1) p2++;
                for (int i = p1 + 0; i <= p2; i += 2) sum1 += arr[i].Value;
                for (int i = p1 + 1; i <= p2; i += 2) sum2 += arr[i].Value;
                result += Math.Max(sum1, sum2);
                p1 = p2 + 1;
            }

            return result;
        }
    }
}
