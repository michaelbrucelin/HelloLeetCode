using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0824
{
    public class Test0824
    {
        public void Test()
        {
            Interface0824 solution = new Solution0824_api();
            string sentence;
            string result, answer;
            int id = 0;

            // 1. 
            sentence = "I speak Goat Latin";
            answer = "Imaa peaksmaaa oatGmaaaa atinLmaaaaa";
            result = solution.ToGoatLatin(sentence);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            sentence = "The quick brown fox jumped over the lazy dog";
            answer = "heTmaa uickqmaaa rownbmaaaa oxfmaaaaa umpedjmaaaaaa overmaaaaaaa hetmaaaaaaaa azylmaaaaaaaaa ogdmaaaaaaaaaa";
            result = solution.ToGoatLatin(sentence);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            sentence = "Each word consists of lowercase and uppercase letters only";
            answer = "Eachmaa ordwmaaa onsistscmaaaa ofmaaaaa owercaselmaaaaaa andmaaaaaaa uppercasemaaaaaaaa etterslmaaaaaaaaa onlymaaaaaaaaaa";
            result = solution.ToGoatLatin(sentence);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
