using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1622
{
    public class Test1622
    {
        public void Test()
        {
            Interface1622 solution;
            string _opts, _args, _answer;
            string[] opts; int[][] args;
            int result, answer; string[] answers;
            int id1 = 0, id2, cnt;

            // 1. 
            id1++;
            solution = new Fancy();
            _opts = "[\"Fancy\",\"append\",\"addAll\",\"append\",\"multAll\",\"getIndex\",\"addAll\",\"append\",\"multAll\",\"getIndex\",\"getIndex\",\"getIndex\"]";
            _args = "[[],[2],[3],[7],[2],[0],[3],[10],[2],[0],[1],[2]]";
            _answer = "[null,null,null,null,null,10,null,null,null,26,34,20]";
            opts = Utils.Str2StrArray(_opts);
            args = Utils.Str2NumArray_2d<int>(_args);
            answers = _answer[1..^1].Split(',');
            id2 = 0; cnt = opts.Length;
            for (int i = 0; i < cnt; i++) switch (opts[i])
                {
                    case "append": solution.Append(args[i][0]); break;
                    case "addAll": solution.AddAll(args[i][0]); break;
                    case "multAll": solution.MultAll(args[i][0]); break;
                    case "getIndex":
                        result = solution.GetIndex(args[i][0]);
                        answer = Convert.ToInt32(answers[i]);
                        Console.WriteLine($"{id1,2}-{++id2,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
                        break;
                    default: break;
                }

            // 2. 
            Console.WriteLine();
            id1++;
            solution = new Fancy();
            _opts = "[\"Fancy\",\"append\",\"append\",\"getIndex\",\"getIndex\",\"multAll\",\"append\",\"getIndex\",\"getIndex\"]";
            _args = "[[],[3],[2],[0],[0],[3],[2],[2],[2]]";
            _answer = "[null,null,null,3,3,null,null,2,2]";
            opts = Utils.Str2StrArray(_opts);
            args = Utils.Str2NumArray_2d<int>(_args);
            answers = _answer[1..^1].Split(',');
            id2 = 0; cnt = opts.Length;
            for (int i = 0; i < cnt; i++) switch (opts[i])
                {
                    case "append": solution.Append(args[i][0]); break;
                    case "addAll": solution.AddAll(args[i][0]); break;
                    case "multAll": solution.MultAll(args[i][0]); break;
                    case "getIndex":
                        result = solution.GetIndex(args[i][0]);
                        answer = Convert.ToInt32(answers[i]);
                        Console.WriteLine($"{id1,2}-{++id2,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
                        break;
                    default: break;
                }

            // 3. 
            Console.WriteLine();
            id1++;
            solution = new Fancy();
            string question = "1622", testcase = "03";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            opts = Utils.Str2StrArray(File.ReadAllText($"{path}_{testcase}_opts.txt"));
            args = Utils.Str2NumArray_2d<int>(File.ReadAllText($"{path}_{testcase}_args.txt"));
            answers = File.ReadAllText($"{path}_{testcase}_answer.txt")[1..^1].Split(',');
            id2 = 0; cnt = opts.Length;
            for (int i = 0; i < cnt; i++) switch (opts[i])
                {
                    case "append": solution.Append(args[i][0]); break;
                    case "addAll": solution.AddAll(args[i][0]); break;
                    case "multAll": solution.MultAll(args[i][0]); break;
                    case "getIndex":
                        result = solution.GetIndex(args[i][0]);
                        answer = Convert.ToInt32(answers[i]);
                        Console.WriteLine($"{id1,2}-{++id2,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
                        break;
                    default: break;
                }
        }
    }
}
