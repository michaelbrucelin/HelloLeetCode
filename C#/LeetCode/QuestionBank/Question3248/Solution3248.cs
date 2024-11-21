using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question3248
{
    public class Solution3248 : Interface3248
    {
        public int FinalPositionOfSnake(int n, IList<string> commands)
        {
            int r = 0, c = 0;
            foreach (string cmd in commands) switch (cmd)
                {
                    case "UP": r--; break;
                    case "RIGHT": c++; break;
                    case "DOWN": r++; break;
                    case "LEFT": c--; break;
                    default: break;
                }

            return r * n + c;
        }

        public int FinalPositionOfSnake2(int n, IList<string> commands)
        {
            int r = 0, c = 0;
            foreach (string cmd in commands) switch (cmd[0])
                {
                    case 'U': r--; break;
                    case 'R': c++; break;
                    case 'D': r++; break;
                    case 'L': c--; break;
                    default: break;
                }

            return r * n + c;
        }
    }
}
