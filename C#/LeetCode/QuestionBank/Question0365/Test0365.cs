using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0365
{
    public class Test0365
    {
        public void Test()
        {
            Interface0365 solution = new Solution0365();
            int jug1Capacity,  jug2Capacity,  targetCapacity;
            bool result, answer;
            int id = 0;

            // 1. 
            jug1Capacity = 3; jug2Capacity = 5; targetCapacity = 4;
            answer = true;
            result = solution.CanMeasureWater(jug1Capacity, jug2Capacity, targetCapacity);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            jug1Capacity = 2; jug2Capacity = 6; targetCapacity = 5;
            answer = false;
            result = solution.CanMeasureWater(jug1Capacity, jug2Capacity, targetCapacity);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            jug1Capacity = 1; jug2Capacity = 2; targetCapacity = 3;
            answer = true;
            result = solution.CanMeasureWater(jug1Capacity, jug2Capacity, targetCapacity);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            jug1Capacity = 1; jug2Capacity = 1; targetCapacity = 12;
            answer = false;
            result = solution.CanMeasureWater(jug1Capacity, jug2Capacity, targetCapacity);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            jug1Capacity =104597; jug2Capacity =104623; targetCapacity =123;
            answer = true;
            result = solution.CanMeasureWater(jug1Capacity, jug2Capacity, targetCapacity);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
