using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Solution = LeetCode.QuestionBank.Question3408.TaskManager_3;

namespace LeetCode.QuestionBank.Question3408
{
    public class Test3408
    {
        public void Test()
        {
            Interface3408 solution;
            string _funcs, _args, _answer;
            string[] funcs, answer;
            int[][] inits, args;
            int result;
            int id = 0, _id;

            // 1. 
            id++; _id = 1;
            _funcs = @"[""TaskManager"",""add"",""edit"",""execTop"",""rmv"",""add"",""execTop""]";
            _args = @"[[[[1,101,10],[2,102,20],[3,103,15]]],[4,104,5],[102,8],[],[101],[5,105,15],[]]";
            _answer = "[null,null,null,3,null,null,5]";
            funcs = _funcs[1..^1].Split(',').Select(x => x[1..^1]).Skip(1).ToArray();
            inits = Utils.Str2NumArray_2d<int>(_args[2..(_args.IndexOf("]]]") + 2)]);
            args = Utils.Str2NumArray_2d<int>($"[{_args[(_args.IndexOf("]]]") + 4)..]}");
            answer = _answer[1..^1].Split(',').Skip(1).ToArray();
            solution = new Solution(inits);
            for (int i = 0; i < funcs.Length; i++) switch (funcs[i])
                {
                    case "add":
                        solution.Add(args[i][0], args[i][1], args[i][2]);
                        break;
                    case "edit":
                        solution.Edit(args[i][0], args[i][1]);
                        break;
                    case "rmv":
                        solution.Rmv(args[i][0]);
                        break;
                    case "execTop":
                        result = solution.ExecTop();
                        Console.WriteLine($"{id}.{_id++}: {(result == int.Parse(answer[i])) + ",",-6} result: {result}, answer: {answer[i]}");
                        break;
                    default:
                        break;
                }

            // 2. 
            id++; _id = 1;
            string question = "3408", testcase = "02";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            _funcs = File.ReadAllText($"{path}_{testcase}_funcs.txt");
            _args = File.ReadAllText($"{path}_{testcase}_args.txt");
            _answer = File.ReadAllText($"{path}_{testcase}_answer.txt");
            funcs = _funcs[1..^1].Split(',').Select(x => x[1..^1]).Skip(1).ToArray();
            inits = Utils.Str2NumArray_2d<int>(_args[2..(_args.IndexOf("]]]") + 2)]);
            args = Utils.Str2NumArray_2d<int>($"[{_args[(_args.IndexOf("]]]") + 4)..]}");
            answer = _answer[1..^1].Split(',').Skip(1).ToArray();
            solution = new Solution(inits);
            bool all_true = true;
            for (int i = 0; i < funcs.Length; i++) switch (funcs[i])
                {
                    case "add":
                        solution.Add(args[i][0], args[i][1], args[i][2]);
                        break;
                    case "edit":
                        solution.Edit(args[i][0], args[i][1]);
                        break;
                    case "rmv":
                        solution.Rmv(args[i][0]);
                        break;
                    case "execTop":
                        _id++;
                        result = solution.ExecTop();
                        if (result != int.Parse(answer[i]))
                        {
                            Console.WriteLine($"{id}.{_id}: {"false,",-6} result: {result}, answer: {answer[i]}");
                            all_true = false;
                        }
                        break;
                    default:
                        break;
                }
            Console.WriteLine($"id: {id}, total_result: {all_true}.");

            // 3. 
            id++; _id = 1;
            question = "3408"; testcase = "03";
            _funcs = File.ReadAllText($"{path}_{testcase}_funcs.txt");
            _args = File.ReadAllText($"{path}_{testcase}_args.txt");
            _answer = File.ReadAllText($"{path}_{testcase}_answer.txt");
            funcs = _funcs[1..^1].Split(',').Select(x => x[1..^1]).Skip(1).ToArray();
            inits = Utils.Str2NumArray_2d<int>(_args[2..(_args.IndexOf("]]]") + 2)]);
            args = Utils.Str2NumArray_2d<int>($"[{_args[(_args.IndexOf("]]]") + 4)..]}");
            answer = _answer[1..^1].Split(',').Skip(1).ToArray();
            solution = new Solution(inits);
            all_true = true;
            for (int i = 0; i < funcs.Length; i++) switch (funcs[i])
                {
                    case "add":
                        solution.Add(args[i][0], args[i][1], args[i][2]);
                        break;
                    case "edit":
                        solution.Edit(args[i][0], args[i][1]);
                        break;
                    case "rmv":
                        solution.Rmv(args[i][0]);
                        break;
                    case "execTop":
                        _id++;
                        result = solution.ExecTop();
                        if (result != int.Parse(answer[i]))
                        {
                            Console.WriteLine($"{id}.{_id}: {"false,",-6} result: {result}, answer: {answer[i]}");
                            all_true = false;
                        }
                        break;
                    default:
                        break;
                }
            Console.WriteLine($"id: {id}, total_result: {all_true}.");
        }
    }
}
