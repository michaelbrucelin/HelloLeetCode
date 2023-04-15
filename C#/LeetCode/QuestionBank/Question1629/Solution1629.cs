using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1629
{
    public class Solution1629 : Interface1629
    {
        public char SlowestKey(int[] releaseTimes, string keysPressed)
        {
            int mtime = releaseTimes[0]; char mchar = keysPressed[0];
            for (int i = 1, dur; i < releaseTimes.Length; i++)
            {
                dur = releaseTimes[i] - releaseTimes[i - 1];
                if (dur > mtime)
                {
                    mchar = keysPressed[i]; mtime = dur;
                }
                else if (dur == mtime && keysPressed[i] > mchar)
                {
                    mchar = keysPressed[i];
                }
            }

            return mchar;
        }
    }
}
