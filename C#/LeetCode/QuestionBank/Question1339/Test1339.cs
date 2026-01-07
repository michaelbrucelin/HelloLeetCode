using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1339
{
    public class Test1339
    {
        public void Test()
        {
            Interface1339 solution = new Solution1339_2();
            TreeNode root;
            int result, answer;
            int id = 0;

            // 1. 
            root = TreeBuilder("[1,2,3,4,5,6]");
            answer = 110;
            result = solution.MaxProduct(root);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            root = TreeBuilder("[1,null,2,3,4,null,null,5,6]");
            answer = 90;
            result = solution.MaxProduct(root);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            root = TreeBuilder("[2,3,9,10,7,8,6,5,4,11,1]");
            answer = 1025;
            result = solution.MaxProduct(root);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            root = TreeBuilder("[1,1]");
            answer = 1;
            result = solution.MaxProduct(root);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            string question = "1339", testcase = "05", arg = "root";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            root = TreeBuilder(File.ReadAllText($"{path}_{testcase}_{arg}.txt")[1..^1]);
            answer = 763478770;
            result = solution.MaxProduct(root);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }

        /// <summary>
        /// 方法有逻辑错误，但是没找出来，反例见测试用例05
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private TreeNode TreeBuilder(string input)
        {
            int?[] _nodes = input[1..^1].Split(',', StringSplitOptions.RemoveEmptyEntries)
                                        .Select(x => x.Replace(" ", "").ToLower())
                                        .Select(x => (int?)(x != "null" ? int.Parse(x) : null))
                                        .ToArray();
            if (_nodes[0] == null) return null;

            int p1 = 0, p2 = 1, n = _nodes.Length;
            TreeNode[] nodes = new TreeNode[n];
            for (int i = 0; i < n; i++) if (_nodes[i] != null) nodes[i] = new TreeNode(_nodes[i].Value);
            while (p2 < n)
            {
                while (nodes[p1] == null) p1++;
                if (nodes[p2] != null) nodes[p1].left = nodes[p2];
                if (++p2 >= n) break;
                if (nodes[p2] != null) nodes[p1].right = nodes[p2];
                ++p2;
                ++p1;
            }

            return nodes[0];
        }
    }
}
