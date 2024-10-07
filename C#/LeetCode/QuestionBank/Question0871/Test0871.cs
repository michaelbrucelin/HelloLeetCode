using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0871
{
    public class Test0871
    {
        public void Test()
        {
            Interface0871 solution = new Solution0871();
            int target, startFuel; int[][] stations;
            int result, answer;
            int id = 0;

            // 1. 
            target = 1; startFuel = 1; stations = [];
            answer = 0;
            result = solution.MinRefuelStops(target, startFuel, stations);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            target = 100; startFuel = 1; stations = [[10, 100]];
            answer = -1;
            result = solution.MinRefuelStops(target, startFuel, stations);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            target = 100; startFuel = 10; stations = [[10, 60], [20, 30], [30, 30], [60, 40]];
            answer = 2;
            result = solution.MinRefuelStops(target, startFuel, stations);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            target = 100; startFuel = 25; stations = [[25, 25], [50, 25], [75, 25]];
            answer = 3;
            result = solution.MinRefuelStops(target, startFuel, stations);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            target = 200; startFuel = 50; stations = [[25, 25], [50, 100], [100, 100], [150, 40]];
            answer = 2;
            result = solution.MinRefuelStops(target, startFuel, stations);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 6. 
            target = 1000; startFuel = 83; stations = [[25, 27], [36, 187], [140, 186], [378, 6], [492, 202], [517, 89], [579, 234], [673, 86], [808, 53], [954, 49]];
            answer = -1;
            result = solution.MinRefuelStops(target, startFuel, stations);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 7. 
            target = 1000000; startFuel = 963424; stations = [[107810, 303794], [132454, 367407], [276008, 367809], [411448, 281643], [432104, 192221], [642124, 418708], [649201, 462743], [740907, 475682], [814355, 151762], [852827, 105731]];
            answer = 1;
            result = solution.MinRefuelStops(target, startFuel, stations);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
