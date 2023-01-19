using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1825
{
    public class Test1825
    {
        public void Test()
        {
            Interface1825 solution;
            int result, answer;
            int id;

            // 1. 
            // ["MKAverage","addElement","addElement","calculateMKAverage","addElement","calculateMKAverage","addElement","addElement","addElement","calculateMKAverage"]
            // [[3,1],[3],[1],[],[10],[],[5],[5],[5],[]]
            id = 0;
            solution = new MKAverage_3(3, 1);
            solution.AddElement(3);
            solution.AddElement(1);
            answer = -1; result = solution.CalculateMKAverage(); Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            solution.AddElement(10);
            answer = 3; result = solution.CalculateMKAverage(); Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
            solution.AddElement(5);
            solution.AddElement(5);
            solution.AddElement(5);
            answer = 5; result = solution.CalculateMKAverage(); Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            // ["MKAverage","addElement","addElement","addElement","addElement","addElement","addElement","calculateMKAverage"]
            // [[6,1],[3],[1],[12],[5],[3],[4],[]]
            id = 0; Console.WriteLine();
            solution = new MKAverage_3(6, 1);
            solution.AddElement(3);
            solution.AddElement(1);
            solution.AddElement(12);
            solution.AddElement(5);
            solution.AddElement(3);
            solution.AddElement(4);
            answer = 3; result = solution.CalculateMKAverage(); Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            id = 0; Console.WriteLine();
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @"QuestionBank\Question1825\TestCases\TestCase1825_3_data2.txt");
            string[] data = File.ReadAllText(path).Split(',').Select(s => s.Trim(new char[] { '[', ']' })).ToArray();
            int m = Convert.ToInt32(data[0]), k = Convert.ToInt32(data[1]);
            Interface1825 solution2 = new MKAverage_2(m, k);
            Interface1825 solution3 = new MKAverage_3(m, k);
            int error_cnt = 0;
            for (int i = 2; i < 88888; i++)
            {
                string s = data[i];
                if (s.Length == 0)
                {
                    answer = solution2.CalculateMKAverage();
                    result = solution3.CalculateMKAverage();
                    if (result != answer) error_cnt++;
                }
                else
                {
                    int val = Convert.ToInt32(s);
                    solution2.AddElement(val);
                    solution3.AddElement(val);
                }
            }
            Console.WriteLine($"一共有{error_cnt}处错误。");
            solution2.ShowInfo();
            solution3.ShowInfo();
        }
    }
}
