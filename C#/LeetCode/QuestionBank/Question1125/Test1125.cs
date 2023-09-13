using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1125
{
    public class Test1125
    {
        public void Test()
        {
            Interface1125 solution = new Solution1125_2();
            string[] req_skills; List<IList<string>> people;
            int[] result, answer;
            int id = 0;

            // 1. 
            req_skills = new string[] { "java", "nodejs", "reactjs" };
            people = new List<IList<string>> { new List<string>() { "java" }, new List<string>() { "nodejs" }, new List<string>() { "nodejs", "reactjs" } };
            answer = new int[] { 0, 2 };
            result = solution.SmallestSufficientTeam(req_skills, people);
            Console.WriteLine($"{++id,2}: {IsCorrect(req_skills, people, result) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            req_skills = new string[] { "algorithms", "math", "java", "reactjs", "csharp", "aws" };
            people = new List<IList<string>> {
                new List<string>() { "algorithms", "math", "java" },
                new List<string>() { "algorithms","math","reactjs" },
                new List<string>() { "java", "csharp", "aws" },
                new List<string>() { "reactjs", "csharp" },
                new List<string>() { "csharp", "math" },
                new List<string>() { "aws", "java" }
            };
            answer = new int[] { 1, 2 };
            result = solution.SmallestSufficientTeam(req_skills, people);
            Console.WriteLine($"{++id,2}: {IsCorrect(req_skills, people, result) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            req_skills = new string[] { "gvp", "jgpzzicdvgxlfix", "kqcrfwerywbwi", "jzukdzrfgvdbrunw", "k" };
            people = new List<IList<string>> {
                new List<string>() {  }, new List<string>() {  }, new List<string>() {  }, new List<string>() {  },
                new List<string>() { "jgpzzicdvgxlfix" },
                new List<string>() { "jgpzzicdvgxlfix","k" },
                new List<string>() { "jgpzzicdvgxlfix","kqcrfwerywbwi" },
                new List<string>() { "gvp" },
                new List<string>() { "jzukdzrfgvdbrunw" },
                new List<string>() { "gvp", "kqcrfwerywbwi" }
            };
            answer = new int[] { 5, 8, 9 };
            result = solution.SmallestSufficientTeam(req_skills, people);
            Console.WriteLine($"{++id,2}: {IsCorrect(req_skills, people, result) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }

        private bool IsCorrect(string[] req_skills, IList<IList<string>> people, int[] select)
        {
            HashSet<string> res_skills = new HashSet<string>();
            foreach (int id in select) foreach (string skill in people[id])
                    res_skills.Add(skill);

            foreach (string skill in req_skills)
            {
                if (res_skills.Contains(skill))
                    res_skills.Remove(skill);
                else
                    return false;
            }

            return res_skills.Count == 0;
        }
    }
}
