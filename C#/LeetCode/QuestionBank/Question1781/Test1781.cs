using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1781
{
    public class Test1781
    {
        public void Test()
        {
            Interface1781 solution = new Solution1781();
            string s;
            int result, answer;
            int id = 0;

            // 1.
            s = "aabcb";
            answer = 5; result = solution.BeautySum(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2.
            s = "aabcbaa";
            answer = 17; result = solution.BeautySum(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3.
            s = "ijsdbwhuazvpvjwlybbcixgjinktzppoyymekuzkdrkspzsdlnuybsuaskzmpxcvlbwjkfoedahjcraueqcaawgltmnoppteaalmfvwzuqzfcpidfpnvpkpttgutyvcqlrthinasmmhkobmxxurzqztfwmjgkcmzwamntaavdfsqvllrtlpphcotrghfduuvxmswaskvasvwooxxbzxcbdpdehvbclsafcsgttgkiyqvxjrqvfzfyoipwnazxgnpoaimjxaujxqbpgleqbihbfurefittctpwqpkhrmwxrptdzyqsmlvkomnfogyyjedkddgpeqclcbzvpkprktraqoitmvpbdzcmkudefyyjmcazwgpishhyqygzppkluldpcswunjwuerxfspeuqupvmgwnwtderbtnuruwawwhrauqlmjlvfqsnvhbydoorvjsaajkrczhsfxfxapvvvqhlqvylxtmxqxhmxxutgdtqmyzyxeucdo";
            answer = 1097844; result = solution.BeautySum(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
