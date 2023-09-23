using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1993
{
    public class Test1993
    {
        public void Test()
        {
            Interface1993 solution;
            (Func<int, int, bool> func, int num, int user, bool answer)[] args;
            bool result, answer;
            int id;

            // 1. 
            id = 0;
            solution = new LockingTree(new int[] { -1, 0, 0, 1, 1, 2, 2 });
            args = new (Func<int, int, bool> func, int num, int user, bool answer)[] {
                (solution.Lock, 2, 2, true), (solution.Unlock, 2, 3, false), (solution.Unlock, 2, 2, true),
                (solution.Lock, 4, 5, true), (solution.Upgrade, 0, 1, true), (solution.Lock, 0, 1, false)
            };
            for (int i = 0; i < args.Length; i++)
            {
                result = args[i].func(args[i].num, args[i].user);
                answer = args[i].answer;
                Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            }
        }
    }
}
