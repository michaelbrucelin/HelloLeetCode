using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1805
{
    public class Test1805
    {
        public void Test()
        {
            Interface1805 solution = new Solution1805();
            string word;
            int result, answer;
            int id = 0;

            // 1. 
            word = "a123bc34d8ef34"; answer = 3;
            result = solution.NumDifferentIntegers(word);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            word = "leet1234code234"; answer = 2;
            result = solution.NumDifferentIntegers(word);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            word = "a1b01c001"; answer = 1;
            result = solution.NumDifferentIntegers(word);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            word = "00a1b01c001"; answer = 2;
            result = solution.NumDifferentIntegers(word);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            word = "a1b01c001d00"; answer = 2;
            result = solution.NumDifferentIntegers(word);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 6. 
            word = "00a1b01c001d00"; answer = 2;
            result = solution.NumDifferentIntegers(word);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 7.
            word = "167278959591294"; answer = 1;
            result = solution.NumDifferentIntegers(word);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 8. 
            word =
"2393706880236110407059624696967828762752651982730115221690437821508229419410771541532394006597463715513741725852432559057224478815116557380260390432211227579663571046845842281704281749571110076974264971989893607137140456254346955633455446057823738757323149856858154529105301197388177242583658641529908583934918768953462557716z97438020429952944646288084173334701047574188936201324845149110176716130267041674438237608038734431519439828191344238609567530399189316846359766256507371240530620697102864238792350289978450509162697068948604722646739174590530336510475061521094503850598453536706982695212493902968251702853203929616930291257062173c79487281900662343830648295410";
            answer = 3;
            result = solution.NumDifferentIntegers(word);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
