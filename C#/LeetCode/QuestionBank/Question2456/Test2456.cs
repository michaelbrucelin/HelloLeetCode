using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2456
{
    public class Test2456
    {
        public void Test()
        {
            Interface2456 solution = new Solution2456();
            string[] creators, ids; int[] views;
            IList<IList<string>> result, answer;
            int id = 0;

            // 1. 
            creators = ["alice", "bob", "alice", "chris"]; ids = ["one", "two", "three", "four"]; views = [5, 10, 5, 4];
            answer = [["alice", "one"], ["bob", "two"]];
            result = solution.MostPopularCreator(creators, ids, views);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, true) + ",",-6} result: {Utils.ToString(result, false)}, answer: {Utils.ToString(answer, false)}");

            // 2. 
            creators = ["alice", "alice", "alice"]; ids = ["a", "b", "c"]; views = [1, 2, 2];
            answer = [["alice", "b"]];
            result = solution.MostPopularCreator(creators, ids, views);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, true) + ",",-6} result: {Utils.ToString(result, false)}, answer: {Utils.ToString(answer, false)}");

            // 3. 
            creators = ["a", "a"]; ids = ["aa", "a"]; views = [5, 5];
            answer = [["a", "a"]];
            result = solution.MostPopularCreator(creators, ids, views);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, true) + ",",-6} result: {Utils.ToString(result, false)}, answer: {Utils.ToString(answer, false)}");

            // 4, 
            string question = "2456", testcase = "04";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            creators = Utils.Str2StrArray(File.ReadAllText($"{path}_{testcase}_creators.txt"));
            ids = Utils.Str2StrArray(File.ReadAllText($"{path}_{testcase}_ids.txt"));
            views = Utils.Str2NumArray<int>(File.ReadAllText($"{path}_{testcase}_views.txt"));
            answer = [["a", "a"]];
            result = solution.MostPopularCreator(creators, ids, views);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer, true) + ",",-6} result: {Utils.ToString(result, false)}, answer: {Utils.ToString(answer, false)}");
        }
    }
}
