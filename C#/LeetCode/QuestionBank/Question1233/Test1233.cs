using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1233
{
    public class Test1233
    {
        public void Test()
        {
            Interface1233 solution = new Solution1233_3();
            string[] folder;
            IList<string> result, answer;
            int id = 0;

            // 1. 
            folder = ["/a", "/a/b", "/c/d", "/c/d/e", "/c/f"];
            answer = ["/a", "/c/d", "/c/f"];
            result = solution.RemoveSubfolders(folder);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            folder = ["/a", "/a/b/c", "/a/b/d"];
            answer = ["/a"];
            result = solution.RemoveSubfolders(folder);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            folder = ["/a/b/c", "/a/b/ca", "/a/b/d"];
            answer = ["/a/b/c", "/a/b/ca", "/a/b/d"];
            result = solution.RemoveSubfolders(folder);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}
