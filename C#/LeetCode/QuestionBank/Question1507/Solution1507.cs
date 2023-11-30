using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1507
{
    public class Solution1507 : Interface1507
    {
        private static readonly Dictionary<string, string> map = new Dictionary<string, string>()
        {
            {"Jan","01"}, {"Feb","02"}, {"Mar","03"}, {"Apr","04"}, {"May","05"}, {"Jun","06"}, {"Jul","07"}, {"Aug","08"}, {"Sep","09"}, {"Oct","10"}, {"Nov","11"}, {"Dec","12"}
        };

        public string ReformatDate(string date)
        {
            if (date.Length == 13)
                return $"{date.Substring(9, 4)}-{map[date.Substring(5, 3)]}-{date.Substring(0, 2)}";
            else
                return $"{date.Substring(8, 4)}-{map[date.Substring(4, 3)]}-0{date.Substring(0, 1)}";
        }
    }
}
