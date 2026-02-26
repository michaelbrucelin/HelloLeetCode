using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1268
{
    public class Test1268
    {
        public void Test()
        {
            Interface1268 solution = new Solution1268();
            string[] products; string searchWord;
            IList<IList<string>> result, answer;
            int id = 0;

            // 1. 
            products = ["mobile", "mouse", "moneypot", "monitor", "mousepad"]; searchWord = "mouse";
            answer = [["mobile", "moneypot", "monitor"], ["mobile", "moneypot", "monitor"], ["mouse", "mousepad"], ["mouse", "mousepad"], ["mouse", "mousepad"]];
            result = solution.SuggestedProducts(products, searchWord);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result, false)}, answer: {Utils.ToString(answer, false)}");

            // 2. 
            products = ["havana"]; searchWord = "havana";
            answer = [["havana"], ["havana"], ["havana"], ["havana"], ["havana"], ["havana"]];
            result = solution.SuggestedProducts(products, searchWord);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result, false)}, answer: {Utils.ToString(answer, false)}");

            // 3. 
            products = ["bags", "baggage", "banner", "box", "cloths"]; searchWord = "bags";
            answer = [["baggage", "bags", "banner"], ["baggage", "bags", "banner"], ["baggage", "bags"], ["bags"]];
            result = solution.SuggestedProducts(products, searchWord);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result, false)}, answer: {Utils.ToString(answer, false)}");

            // 4. 
            products = ["havana"]; searchWord = "tatiana";
            answer = [[], [], [], [], [], [], []];
            result = solution.SuggestedProducts(products, searchWord);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result, false)}, answer: {Utils.ToString(answer, false)}");

            // 5. 
            string question = "1268", testcase = "05", arg = "products";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            products = Utils.Str2NumArray<string>(File.ReadAllText($"{path}_{testcase}_{arg}.txt"));
            //arg = Utils.Str2NumArray_2d<int>(File.ReadAllText($"{path}_{testcase}_{arg}.txt"));
            searchWord = "tyqcpfvorznmxxdzsnkjnrrzpfgknvqvderckuzdqqgaqejetbnuniwwjbdchviotvdticwxwcliylrpvrokbcguhnfvpd";
        }
    }
}
