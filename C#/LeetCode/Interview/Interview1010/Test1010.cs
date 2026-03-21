using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _StreamRank = LeetCode.Interview.Interview1010.StreamRank;

namespace LeetCode.Interview.Interview1010
{
    public class Test1010
    {
        public void Test()
        {
            Interface1010 solution;
            string[] opts; int[][] args; int n;
            int result; string[] answer;
            int id = 0, id1;

            // 1. 
            id++; id1 = 1;
            opts = ["StreamRank", "getRankOfNumber", "track", "getRankOfNumber"];
            args = [[], [1], [0], [0]];
            answer = ["null", "0", "null", "1"];
            n = opts.Length;
            solution = new _StreamRank();
            for (int i = 1; i < n; i++) switch (opts[i])
                {
                    case "track": solution.Track(args[i][0]); break;
                    case "getRankOfNumber":
                        result = solution.GetRankOfNumber(args[i][0]);
                        Console.WriteLine($"{id,2}-{id1++,2}: {(result == Convert.ToInt32(answer[i])) + ",",-6} result: {result}, answer: {answer[i]}");
                        break;
                    default: break;
                }

            // 2. 
            Console.WriteLine();
            id++; id1 = 1;
            opts = ["StreamRank", "track", "track", "track", "getRankOfNumber", "track", "getRankOfNumber", "track", "track", "getRankOfNumber", "getRankOfNumber",
                                  "track", "getRankOfNumber", "track", "getRankOfNumber", "track", "track", "getRankOfNumber", "track", "track", "track"];
            args = [[], [4], [3], [5], [8], [3], [2], [1], [5], [3], [5], [1], [9], [6], [3], [4], [1], [7], [9], [2], [9]];
            answer = ["null", "null", "null", "null", "3", "null", "0", "null", "null", "3", "6", "null", "7", "null", "4", "null", "null", "10", "null", "null", "null"];
            n = opts.Length;
            solution = new _StreamRank();
            for (int i = 1; i < n; i++) switch (opts[i])
                {
                    case "track": solution.Track(args[i][0]); break;
                    case "getRankOfNumber":
                        result = solution.GetRankOfNumber(args[i][0]);
                        Console.WriteLine($"{id,2}-{id1++,2}: {(result == Convert.ToInt32(answer[i])) + ",",-6} result: {result}, answer: {answer[i]}");
                        break;
                    default: break;
                }

            // 3. 
            Console.WriteLine();
            id++; id1 = 1;
            opts = ["StreamRank", "getRankOfNumber", "getRankOfNumber", "getRankOfNumber", "track", "getRankOfNumber", "track", "track", "getRankOfNumber", "track", "track",
                                  "getRankOfNumber", "getRankOfNumber", "track", "getRankOfNumber", "getRankOfNumber", "getRankOfNumber", "getRankOfNumber", "track", "track", "track"];
            args = [[], [8], [6], [8], [6], [7], [1], [8], [0], [0], [7], [2], [2], [6], [5], [8], [1], [4], [7], [6], [1]];
            answer = ["null", "0", "0", "0", "null", "1", "null", "null", "0", "null", "null", "2", "2", "null", "2", "6", "2", "2", "null", "null", "null"];
            n = opts.Length;
            solution = new _StreamRank();
            for (int i = 1; i < n; i++) switch (opts[i])
                {
                    case "track": solution.Track(args[i][0]); break;
                    case "getRankOfNumber":
                        result = solution.GetRankOfNumber(args[i][0]);
                        Console.WriteLine($"{id,2}-{id1++,2}: {(result == Convert.ToInt32(answer[i])) + ",",-6} result: {result}, answer: {answer[i]}");
                        break;
                    default: break;
                }
        }
    }
}
