using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0732
{
    public class Test0732
    {
        public void Test()
        {
            Interface0732 solution;
            string[] opts; int[][] vals;
            int result; int[] answer;
            int ID, id;

            // 1. 
            ID = 1; id = 0;
            solution = new MyCalendarThree_debug();
            opts = ["book", "book", "book", "book", "book", "book"];
            vals = [[10, 20], [50, 60], [10, 40], [5, 15], [5, 10], [25, 55]];
            answer = [1, 1, 2, 3, 3, 3];
            for (int i = 0; i < vals.Length; i++)
            {
                result = solution.Book(vals[i][0], vals[i][1]);
                Console.WriteLine($"{ID},{++id,2}: {(result == answer[i]) + ",",-6} result: {result}, answer: {answer[i]}");
            }
        }
    }
}
