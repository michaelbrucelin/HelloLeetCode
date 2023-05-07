using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2148
{
    public class Solution2148_api : Interface2148
    {
        public int CountElements(int[] nums)
        {
            return nums.Where((num, id) => nums.Where((_num, _id) => _id != id).Any(_num => _num < num) &&
                                           nums.Where((_num, _id) => _id != id).Any(_num => _num > num))
                       .Count();
        }
    }
}
