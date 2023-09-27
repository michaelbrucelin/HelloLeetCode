using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1333
{
    public class Solution1333 : Interface1333
    {
        /// <summary>
        /// 遍历
        /// 为什么难度是中等？
        /// </summary>
        /// <param name="restaurants"></param>
        /// <param name="veganFriendly"></param>
        /// <param name="maxPrice"></param>
        /// <param name="maxDistance"></param>
        /// <returns></returns>
        public IList<int> FilterRestaurants(int[][] restaurants, int veganFriendly, int maxPrice, int maxDistance)
        {
            List<int[]> buffer = new List<int[]>();
            foreach (var arr in restaurants)
            {
                if ((!(veganFriendly == 1 && arr[2] == 0)) && maxPrice >= arr[3] && maxDistance >= arr[4])
                    buffer.Add(arr);
            }
            buffer = buffer.OrderByDescending(arr => arr[1]).ThenByDescending(arr => arr[0]).ToList();

            int[] result = new int[buffer.Count];
            for (int i = 0; i < buffer.Count; i++) result[i] = buffer[i][0];

            return result;
        }
    }
}
