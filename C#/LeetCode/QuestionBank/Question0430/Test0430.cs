using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0430
{
    public class Test0430
    {
        public void Test()
        {
            Interface0430 solution = new Solution0430();
            Node head;
            Node result, answer;
            int id = 0;

            // 1. 
            // head = [1, 2, 3, 4, 5, 6, null, null, null, 7, 8, 9, 10, null, null, 11, 12];
            // answer = [1, 2, 3, 7, 8, 11, 12, 9, 10, 4, 5, 6];

            // 2. 
            // head = [1, 2, null, 3];
            // answer = [1, 3, 2];

            // 3. 
            // head = [];
            // answer = [];

            // 4. 
            // head = [1, null, 2, null, 3, null];
            // answer = [1, 2, 3];

            // 5. 
            // head = [1, 2, 3, 4, 5, 6, null, null, null, 7, 8, null, null, 11, 12];
            // answer = [1, 2, 3, 7, 8, 11, 12, 4, 5, 6];
        }
    }
}
