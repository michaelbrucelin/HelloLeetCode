using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1108
{
    public class Solution1108_api : Interface1108
    {
        public string DefangIPaddr(string address)
        {
            return address.Replace(".", "[.]");
        }

        public string DefangIPaddr2(string address)
        {
            return string.Join("[.]", address.Split('.'));
        }
    }
}
