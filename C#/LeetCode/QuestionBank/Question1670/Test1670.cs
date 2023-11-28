using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1670
{
    public class Test1670
    {
        public void Test()
        {
            Interface1670 solution;
            int result, answer;
            int id1, id2;

            // 1. 
            solution = new FrontMiddleBackQueue_2();
            id1 = 1; id2 = 0;
            solution.PushFront(1);
            solution.PushBack(2);
            solution.PushMiddle(3);
            solution.PushMiddle(4);

            answer = 1; result = solution.PopFront(); Console.WriteLine($"{id1}-{++id2,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            answer = 3; result = solution.PopMiddle(); Console.WriteLine($"{id1}-{++id2,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            answer = 4; result = solution.PopMiddle(); Console.WriteLine($"{id1}-{++id2,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            answer = 2; result = solution.PopBack(); Console.WriteLine($"{id1}-{++id2,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            answer = -1; result = solution.PopFront(); Console.WriteLine($"{id1}-{++id2,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            Console.WriteLine();
            solution = new FrontMiddleBackQueue_2();
            id1 = 2; id2 = 0;
            solution.PushMiddle(493299);
            answer = 493299; result = solution.PopMiddle(); Console.WriteLine($"{id1}-{++id2,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            solution.PushMiddle(75427);
            answer = 75427; result = solution.PopMiddle(); Console.WriteLine($"{id1}-{++id2,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            solution.PushFront(753523);
            solution.PushMiddle(677444);
            solution.PushMiddle(431158);
            answer = 431158; result = solution.PopMiddle(); Console.WriteLine($"{id1}-{++id2,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            answer = 677444; result = solution.PopMiddle(); Console.WriteLine($"{id1}-{++id2,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            solution.PushBack(47949);
            answer = 753523; result = solution.PopMiddle(); Console.WriteLine($"{id1}-{++id2,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            Console.WriteLine();
            solution = new FrontMiddleBackQueue_2();
            id1 = 3; id2 = 0;
            solution.PushFront(888438);
            solution.PushMiddle(772690);
            solution.PushMiddle(375192);
            solution.PushFront(411268);
            solution.PushFront(885613);
            solution.PushMiddle(508187);
            answer = 508187; result = solution.PopMiddle(); Console.WriteLine($"{id1}-{++id2,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            answer = 772690; result = solution.PopMiddle(); Console.WriteLine($"{id1}-{++id2,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            solution.PushMiddle(111498);
            solution.PushMiddle(296008);
            answer = 885613; result = solution.PopFront(); Console.WriteLine($"{id1}-{++id2,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
