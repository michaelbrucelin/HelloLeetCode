using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1945
{
    public class Test1945
    {
        public void Test()
        {
            Interface1945 solution = new Solution1945_3();
            string s; int k;
            int result, answer;
            int id = 0;

            // 1.
            s = "iiii"; k = 1; answer = 36;
            result = solution.GetLucky(s, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2.
            s = "leetcode"; k = 2; answer = 6;
            result = solution.GetLucky(s, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            s = "zbax"; k = 2; answer = 8;
            result = solution.GetLucky(s, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4.
            s = "fypjtickihbubugmanmkqhmnalllmdxcrbkdzwvlhaatxlngpixyhqaksfkaxwanvrligxzrlgaj"; k = 3; answer = 9;
            result = solution.GetLucky(s, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5.
            s = "ofmlmndopfqchsunznscyyotxtfjwwgnskoixwbnemubsgceuwjvcajzzqvwjrfwhectooruevppfkskwsttbxzatpnjhjyppyzj"; k = 1; answer = 511;
            result = solution.GetLucky(s, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 6.
            s = "ofmlmndopfqchsunznscyyotxtfjwwgnskoixwbnemubsgceuwjvcajzzqvwjrfwhectooruevppfkskwsttbxzatpnjhjyppyzj"; k = 2; answer = 7;
            result = solution.GetLucky(s, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 7.
            s = "ofmlmndopfqchsunznscyyotxtfjwwgnskoixwbnemubsgceuwjvcajzzqvwjrfwhectooruevppfkskwsttbxzatpnjhjyppyzj"; k = 3; answer = 7;
            result = solution.GetLucky(s, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 8.
            s = "ofmlmndopfqchsunznscyyotxtfjwwgnskoixwbnemubsgceuwjvcajzzqvwjrfwhectooruevppfkskwsttbxzatpnjhjyppyzj"; k = 10; answer = 7;
            result = solution.GetLucky(s, k);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
