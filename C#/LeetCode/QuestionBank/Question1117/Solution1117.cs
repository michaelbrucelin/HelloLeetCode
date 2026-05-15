using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1117
{
    public class Solution1117
    {
    }

    /// <summary>
    /// 阅读理解题
    /// </summary>
    public class H2O
    {
        public H2O()
        {
            hcnt = ocnt = 0;
        }

        private int hcnt, ocnt;

        public void Hydrogen(Action releaseHydrogen)
        {
            if (hcnt < 2) hcnt++;
            if (hcnt == 2 && ocnt == 1)
            {
                releaseHydrogen(); releaseHydrogen();
                hcnt = ocnt = 0;
            }
        }

        public void Oxygen(Action releaseOxygen)
        {
            if (ocnt < 1) ocnt++;
            if (hcnt == 2)
            {
                releaseOxygen();
                hcnt = ocnt = 0;
            }
        }
    }
}
