using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3233
{
    public class Utils3233
    {
        public void Dial()
        {
            List<int> list = GetPrimes((int)1e9);
            StringBuilder sb = new StringBuilder();
            sb.Append("[ ");
            sb.Append(list[0].ToString().PadLeft(0, ' '));
            for (int i = 1; i < list.Count; i++)
                sb.Append($", {list[i].ToString().PadLeft(0, ' ')}");
            sb.Append(" ]");

            Console.WriteLine(sb.ToString());

            List<int> GetPrimes(int n)
            {
                List<int> result = new List<int>();
                bool[] mask = new bool[n + 1]; Array.Fill(mask, true);
                for (int i = 2; i <= n; i++)
                {
                    if (mask[i]) result.Add(i);
                    for (int j = 0; j < result.Count && i * result[j] <= n; j++)
                    {
                        mask[i * result[j]] = false;
                        if (i % result[j] == 0) break;
                    }
                }

                return result;
            }
        }
    }
}
