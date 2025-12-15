using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3606
{
    public class Test3606
    {
        public void Test()
        {
            Interface3606 solution = new Solution3606();
            string[] code, businessLine; bool[] isActive;
            IList<string> result, answer;
            int id = 0;

            // 1. 
            code = ["SAVE20", "", "PHARMA5", "SAVE@20"]; businessLine = ["restaurant", "grocery", "pharmacy", "restaurant"]; isActive = [true, true, true, true];
            answer = ["PHARMA5", "SAVE20"];
            result = solution.ValidateCoupons(code, businessLine, isActive);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            code = ["GROCERY15", "ELECTRONICS_50", "DISCOUNT10"]; businessLine = ["grocery", "electronics", "invalid"]; isActive = [false, true, true];
            answer = ["ELECTRONICS_50"];
            result = solution.ValidateCoupons(code, businessLine, isActive);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            code = ["MI", "b_"]; businessLine = ["pharmacy", "pharmacy"]; isActive = [true, true];
            answer = ["MI", "b_"];
            result = solution.ValidateCoupons(code, businessLine, isActive);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 4. 
            code = ["uV", "Pm", "Bk", "OY", "Wm"]; businessLine = ["restaurant", "invalid", "electronics", "restaurant", "invalid"]; isActive = [true, true, false, true, false];
            answer = ["OY", "uV"];
            result = solution.ValidateCoupons(code, businessLine, isActive);
            Console.WriteLine($"{++id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");
        }
    }
}
