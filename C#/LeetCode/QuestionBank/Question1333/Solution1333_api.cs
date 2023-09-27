using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1333
{
    public class Solution1333_api : Interface1333
    {
        public IList<int> FilterRestaurants(int[][] restaurants, int veganFriendly, int maxPrice, int maxDistance)
        {
            return restaurants.Where(arr => (!(veganFriendly == 1 && arr[2] == 0)) && maxPrice >= arr[3] && maxDistance >= arr[4])
                              .OrderByDescending(arr => arr[1]).ThenByDescending(arr => arr[0])
                              .Select(arr => arr[0])
                              .ToArray();
        }
    }
}
