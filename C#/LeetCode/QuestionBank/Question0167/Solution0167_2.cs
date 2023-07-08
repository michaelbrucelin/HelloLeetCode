using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0167
{
    public class Solution0167_2 : Interface0167
    {
        /// <summary>
        /// 双指针
        /// 1个指针从左向右，另一个指针从右向左，右侧的指针始终停留在第一个使左右指针和小于target的位置
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSum(int[] numbers, int target)
        {
            int i = 0, j = numbers.Length - 1, add;
            while (i < j)
            {
                add = numbers[i] + numbers[j];
                if (add > target) j--;
                else if (add < target) i++;
                else return new int[] { i + 1, j + 1 };
            }

            throw new Exception("logic error.");
        }
    }
}
