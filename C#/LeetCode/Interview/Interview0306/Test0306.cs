using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Interview.Interview0306
{
    public class Test0306
    {
        public void Test()
        {
            Interface0306 solution;
            int[] result, answer;
            int id1 = 0, id2;

            // 1. 
            id1++; id2 = 0;
            solution = new AnimalShelf();
            solution.Enqueue([0, 0]);
            solution.Enqueue([1, 0]);
            answer = [0, 0]; result = solution.DequeueCat();
            Console.WriteLine($"{id1}-{++id2,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
            answer = [-1, -1]; result = solution.DequeueDog();
            Console.WriteLine($"{id1}-{++id2,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
            answer = [1, 0]; result = solution.DequeueAny();
            Console.WriteLine($"{id1}-{++id2,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            Console.WriteLine(); id1++; id2 = 0;
            solution = new AnimalShelf();
            solution.Enqueue([0, 0]);
            solution.Enqueue([1, 0]);
            solution.Enqueue([2, 1]);
            answer = [2, 1]; result = solution.DequeueDog();
            Console.WriteLine($"{id1}-{++id2,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
            answer = [0, 0]; result = solution.DequeueCat();
            Console.WriteLine($"{id1}-{++id2,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
            answer = [1, 0]; result = solution.DequeueAny();
            Console.WriteLine($"{id1}-{++id2,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            Console.WriteLine(); id1++; id2 = 0;
            string question = "0306", testcase = "03";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"Interview\Interview{question}\TestCases\TestCase{question}");
            string[] opts = File.ReadAllText($"{path}_{testcase}_opts.txt")[1..^1].Split(',').Select(s => s[1..^1]).ToArray();
            string[] args = File.ReadAllText($"{path}_{testcase}_args.txt")[2..^2].Split("],[");
            string[] anss = File.ReadAllText($"{path}_{testcase}_answer.txt").Replace("null", "[null]")[2..^2].Split("],[");
            for (int i = 0; i < opts.Length; i++)
            {
                switch (opts[i])
                {
                    case "AnimalShelf": solution = new AnimalShelf(); break;
                    case "enqueue": solution.Enqueue(args[i][1..^1].Split(',').Select(int.Parse).ToArray()); break;
                    case "dequeueCat":
                        answer = anss[i][1..^1].Split(',').Select(int.Parse).ToArray();
                        result = solution.DequeueCat();
                        Console.WriteLine($"{id1}-{++id2,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
                        break;
                    case "dequeueDog":
                        answer = anss[i][1..^1].Split(',').Select(int.Parse).ToArray();
                        result = solution.DequeueDog();
                        Console.WriteLine($"{id1}-{++id2,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
                        break;
                    case "dequeueAny":
                        answer = anss[i].Split(',').Select(int.Parse).ToArray();
                        result = solution.DequeueAny();
                        Console.WriteLine($"{id1}-{++id2,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
                        break;
                    default: break;
                }
            }
        }
    }
}
