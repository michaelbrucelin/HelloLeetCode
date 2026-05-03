using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0385
{
    public class Test0385
    {
        public void Test()
        {
            Interface0385 solution = new Solution();
            string s;
            NestedInteger result, answer;
            int id = 0;

            // 1. 
            s = "324";
            answer = new NestedInteger(324);
            result = solution.Deserialize(s);

            // 2. 
            s = "[123,[456,[789]]]";
            NestedInteger ni789 = new NestedInteger(); ni789.Add(new NestedInteger(789));
            NestedInteger ni456 = new NestedInteger(); ni456.Add(new NestedInteger(456)); ni456.Add(ni789);
            answer = new NestedInteger(); answer.Add(new NestedInteger(123)); answer.Add(ni456);
            result = solution.Deserialize(s);

            // 3. 
            s = "[123,[456,789]]";
            ni789 = new NestedInteger(789);
            ni456 = new NestedInteger(456);
            NestedInteger ni456789 = new NestedInteger(); ni456789.Add(ni456); ni456789.Add(ni789);
            answer = new NestedInteger(); answer.Add(new NestedInteger(123)); answer.Add(ni456789);
            result = solution.Deserialize(s);
        }
    }
}
