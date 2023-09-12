using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1462
{
    public class Test1462
    {
        public void Test()
        {
            Interface1462 solution = new Solution1462_4();
            int numCourses; int[][] prerequisites, queries;
            IList<bool> result, answer;
            int id = 0;

            // 1.
            numCourses = 2;
            prerequisites = UtilsLeetCode.Str2NumArray_2d<int>("[[1,0]]");
            queries = UtilsLeetCode.Str2NumArray_2d<int>("[[0,1],[1,0]]");
            answer = new List<bool>() { false, true };
            result = solution.CheckIfPrerequisite(numCourses, prerequisites, queries);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 2. 
            numCourses = 2;
            prerequisites = UtilsLeetCode.Str2NumArray_2d<int>("");
            queries = UtilsLeetCode.Str2NumArray_2d<int>("[[1,0],[0,1]]");
            answer = new List<bool>() { false, false };
            result = solution.CheckIfPrerequisite(numCourses, prerequisites, queries);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 3. 
            numCourses = 3;
            prerequisites = UtilsLeetCode.Str2NumArray_2d<int>("[[1,2],[1,0],[2,0]]");
            queries = UtilsLeetCode.Str2NumArray_2d<int>("[[1,0],[1,2]]");
            answer = new List<bool>() { true, true };
            result = solution.CheckIfPrerequisite(numCourses, prerequisites, queries);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");
        }
    }
}
