using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0415
{
    public class Test0415
    {
        public void Test()
        {
            Interface0415 solution = new Solution0415_2();
            string num1, num2;
            string result, answer;
            int id = 0;

            // 1. 
            num1 = "11"; num2 = "123"; answer = "134";
            result = solution.AddStrings(num1, num2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            num1 = "456"; num2 = "77"; answer = "533";
            result = solution.AddStrings(num1, num2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            num1 = "0"; num2 = "0"; answer = "0";
            result = solution.AddStrings(num1, num2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            num1 = "1"; num2 = "9"; answer = "10";
            result = solution.AddStrings(num1, num2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5. 
            num1 = "11111111111111111111111111111111"; num2 = "999999999999999999999999999999"; answer = "12111111111111111111111111111110";
            result = solution.AddStrings(num1, num2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 6. 
            num1 = "0"; num2 = "0"; answer = "0";
            result = solution.AddStrings(num1, num2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 7. 
            num1 = "1"; num2 = "999999999999999999"; answer = "1000000000000000000";
            result = solution.AddStrings(num1, num2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 8. 
            num1 = "541982060092168498451651518198198811908139417398912951912143650537206598519205603455602369504575450387573146280";
            num2 = "2051051984893020654984520306549848916006549848916502309848949802089489489032009849815020984891339487";
            answer = "541982060094219550436544538853183332214689266314919501761060152847055548321295092944634379354390471372464485767";
            result = solution.AddStrings(num1, num2);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
