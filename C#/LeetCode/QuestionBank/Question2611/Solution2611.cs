using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2611
{
    public class Solution2611 : Interface2611
    {
        /// <summary>
        /// 排序 + 贪心（鸡兔同笼）
        /// 吃掉“收益”大的奶酪即可，下面以：reward1 = [1,1,3,4], reward2 = [4,4,1,1], k = 2，为例
        /// 1. 计算每一块奶酪的收益，即reward1 - reward2
        ///     [-3, -3, 2, 3] --> [0, 1, 2, 3]
        /// 2. 收益降序排序
        ///     [3, 2, -3, -3] --> [3, 2, 0, 1]
        /// 3. 那么优先吃前两块，即id为3, 2这两块蛋糕即可
        ///     这里面有个小技巧，即不需要真的得到id的排序后数组，直接将reward2累加，然后在加上前k个收益即可
        ///     这里就是(4+4+1+1) + (3+2)
        /// </summary>
        /// <param name="reward1"></param>
        /// <param name="reward2"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public int MiceAndCheese(int[] reward1, int[] reward2, int k)
        {
            int len = reward1.Length;
            if (k == len) return reward1.Sum();

            int[] reward = new int[len];
            for (int i = 0; i < len; i++) reward[i] = reward1[i] - reward2[i];
            Array.Sort(reward, (i, j) => j - i);

            int result = reward2.Sum();
            for (int i = 0; i < k; i++) result += reward[i];

            return result;
        }
    }
}
