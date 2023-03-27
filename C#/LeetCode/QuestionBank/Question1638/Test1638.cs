using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1638
{
    public class Test1638
    {
        public void Test()
        {
            Interface1638 solution = new Solution1638_2();
            string s, t;
            int result, answer;
            int id = 0;

            // 1. 
            s = "aba"; t = "baba"; answer = 6;
            result = solution.CountSubstrings(s, t);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            s = "ab"; t = "bb"; answer = 3;
            result = solution.CountSubstrings(s, t);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            s = "a"; t = "a"; answer = 0;
            result = solution.CountSubstrings(s, t);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            s = "abe"; t = "bbc"; answer = 10;
            result = solution.CountSubstrings(s, t);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            s = "abbab"; t = "bbbbb"; answer = 33;
            result = solution.CountSubstrings(s, t);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 6. 
            s = "vjhtfhcrfaclevtzkfllzfnfguhatsklykqwevavpgxwrcacyejqludchuwcjaxnkbjfxregarwwnrjxanwuzmoykgzohxnwkopn";
            t = "stwdstsxgmlklnuroaaexmuqbhiluwunknlayikveybpyfccwfkycifhvhnlmkqqiuarojcifnlkxejpszctxojknzehmentkvzb";
            answer = 10419;
            result = solution.CountSubstrings(s, t);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 7. 
            s = "whzuufezhtyywiipldkuenpdnynsdsxthelyscqezxesoaayoasalnqwxmegzdvqcsvaahjwcscaninvjiiwxummebbmgohdpwqw";
            t = "wcpukrvhrebdahylbwsproflfbzveewbueaddhivvxwjdfzlktrctepvrxplslqdyzjuomjofbzdqohkjxgeyczlxzcxvmvescuy";
            answer = 10374;
            result = solution.CountSubstrings(s, t);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
