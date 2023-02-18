using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1237
{
    public class CustomFunction
    {
        public CustomFunction(int function_id)
        {
            this.function_id = function_id;
        }

        private int function_id;

        public int f(int x, int y)
        {
            switch (function_id)
            {
                case 1:
                    return x + y;
                case 2:
                    return x * y;
                case 3:
                    return x * x + y;
                case 4:
                    return x + y * y;
                case 5:
                    return x * x + y * y;
                case 6:
                    return (x + y) * (x + y);
                case 7:
                    return x * x * x + y * y * y;
                case 8:
                    return x * x * y;
                case 9:
                    return x * y * y;
                default:
                    return 0;
            }
        }
    }
}
