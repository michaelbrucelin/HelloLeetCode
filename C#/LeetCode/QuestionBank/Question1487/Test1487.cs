using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1487
{
    public class Test1487
    {
        public void Test()
        {
            Interface1487 solution = new Solution1487();
            string[] names;
            string[] result, answer;
            int id = 0;

            // 1. 
            names = new string[] { "pes", "fifa", "gta", "pes(2019)" };
            answer = new string[] { "pes", "fifa", "gta", "pes(2019)" };
            result = solution.GetFolderNames(names);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 2. 
            names = new string[] { "gta", "gta(1)", "gta", "avalon" };
            answer = new string[] { "gta", "gta(1)", "gta(2)", "avalon" };
            result = solution.GetFolderNames(names);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 3. 
            names = new string[] { "onepiece", "onepiece(1)", "onepiece(2)", "onepiece(3)", "onepiece" };
            answer = new string[] { "onepiece", "onepiece(1)", "onepiece(2)", "onepiece(3)", "onepiece(4)" };
            result = solution.GetFolderNames(names);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 4. 
            names = new string[] { "wano", "wano", "wano", "wano" };
            answer = new string[] { "wano", "wano(1)", "wano(2)", "wano(3)" };
            result = solution.GetFolderNames(names);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 5. 
            names = new string[] { "kaido", "kaido(1)", "kaido", "kaido(1)" };
            answer = new string[] { "kaido", "kaido(1)", "kaido(2)", "kaido(1)(1)" };
            result = solution.GetFolderNames(names);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 6. 
            names = new string[] { "gta", "gta(3)", "gta", "avalon" };
            answer = new string[] { "gta", "gta(3)", "gta(1)", "avalon" };
            result = solution.GetFolderNames(names);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 7. 
            names = new string[] { "gta", "gta(03)", "gta", "avalon" };
            answer = new string[] { "gta", "gta(03)", "gta(1)", "avalon" };
            result = solution.GetFolderNames(names);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 8. 
            names = new string[] { "gta", "gta(1)", "gta(1)", "gta", "avalon" };
            answer = new string[] { "gta", "gta(1)", "gta(1)(1)", "gta(2)", "avalon" };
            result = solution.GetFolderNames(names);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");

            // 9. 
            names = new string[] { "kaido", "kaido(1)", "kaido", "kaido(1)", "kaido(2)" };
            answer = new string[] { "kaido", "kaido(1)", "kaido(2)", "kaido(1)(1)", "kaido(2)(1)" };
            result = solution.GetFolderNames(names);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ArrayToString(result)}, answer: {Utils.ArrayToString(answer)}");
        }
    }
}
