using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0384
{
    public class Solution0384
    {
    }

    public class Solution
    {
        public Solution(int[] nums)
        {
            this.nums = [.. nums];
            random = new Random();
        }

        private int[] nums;
        private Random random;

        public int[] Reset()
        {
            return [.. nums];
        }

        public int[] Shuffle()
        {
            int[] shuffle = [.. nums];
            // random.Shuffle(shuffle);
            for (int i = shuffle.Length - 1, j; i > 0; i--)
            {
                j = random.Next(i + 1);
                (shuffle[i], shuffle[j]) = (shuffle[j], shuffle[i]);
            }

            return shuffle;
        }
    }
}
