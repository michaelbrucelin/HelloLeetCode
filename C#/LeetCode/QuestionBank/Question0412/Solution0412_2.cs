using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0412
{
    public class Solution0412_2 : Interface0412
    {
        public IList<string> FizzBuzz(int n)
        {
            string[] result = new string[n];
            for (int i = 1; i <= n; i++)
            {
                switch (i)
                {
                    case > 0 when i % 3 == 0 && i % 5 == 0:
                        result[i - 1] = "FizzBuzz";
                        break;
                    case > 0 when i % 3 == 0:
                        result[i - 1] = "Fizz";
                        break;
                    case > 0 when i % 5 == 0:
                        result[i - 1] = "Buzz";
                        break;
                    default:
                        result[i - 1] = i.ToString();
                        break;
                }
            }

            return result;
        }

        public IList<string> FizzBuzz2(int n)
        {
            string[] result = new string[n];
            for (int i = 1; i <= n; i++)
            {
                result[i - 1] = i switch
                {
                    { } when i % 3 == 0 && i % 5 == 0 => "FizzBuzz",
                    { } when i % 3 == 0 => "Fizz",
                    { } when i % 5 == 0 => "Buzz",
                    _ => i.ToString()
                };
            }

            return result;
        }

        public IList<string> FizzBuzz3(int n)
        {
            return Enumerable.Range(1, n)
                             .Select(i => i switch
                             {
                                 { } when i % 3 == 0 && i % 5 == 0 => "FizzBuzz",
                                 { } when i % 3 == 0 => "Fizz",
                                 { } when i % 5 == 0 => "Buzz",
                                 _ => i.ToString()
                             }).ToArray();
        }
    }
}
