using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1813
{
    public class Test1813
    {
        public void Test()
        {
            Interface1813 solution = new Solution1813_4();
            string sentence1, sentence2;
            bool result, answer;
            int id = 0;

            // 1. 
            sentence1 = "My name is Haley"; sentence2 = "My Haley"; answer = true;
            result = solution.AreSentencesSimilar(sentence1, sentence2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            sentence2 = "My name is Haley"; sentence1 = "My Haley"; answer = true;
            result = solution.AreSentencesSimilar(sentence1, sentence2);
            Console.WriteLine($"{id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            sentence1 = "of"; sentence2 = "A lot of words"; answer = false;
            result = solution.AreSentencesSimilar(sentence1, sentence2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            sentence1 = "Eating right now"; sentence2 = "Eating"; answer = true;
            result = solution.AreSentencesSimilar(sentence1, sentence2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            sentence1 = "Eating right now"; sentence2 = "now"; answer = true;
            result = solution.AreSentencesSimilar(sentence1, sentence2);
            Console.WriteLine($"{id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            sentence1 = "Luky"; sentence2 = "Lucccky"; answer = false;
            result = solution.AreSentencesSimilar(sentence1, sentence2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            sentence1 = "eTUny i b R UFKQJ EZx JBJ Q xXz"; sentence2 = "eTUny i R EZx JBJ xXz"; answer = false;
            result = solution.AreSentencesSimilar(sentence1, sentence2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 6. 
            sentence1 = "B"; sentence2 = "ByI BMyQIqce b bARkkMaABi vlR RLHhqjNzCN oXvyK zRXR q ff B yHS OD KkvJA P JdWksnH"; answer = false;
            result = solution.AreSentencesSimilar(sentence1, sentence2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 7. 
            sentence1 = "C"; sentence2 = "CB B C"; answer = true;
            result = solution.AreSentencesSimilar(sentence1, sentence2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 8. 
            sentence1 = "aa aAa"; sentence2 = "aaA aAa"; answer = false;
            result = solution.AreSentencesSimilar(sentence1, sentence2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
