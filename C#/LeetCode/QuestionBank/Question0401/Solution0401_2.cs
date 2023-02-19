using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0401
{
    public class Solution0401_2 : Interface0401
    {
        /// <summary>
        /// 二进制遍历
        /// 遍历0-11的二进制中1的数量，可以得到可能的小时
        /// 遍历0-59的二进制中1的数量，可以得到可能的分钟
        /// 简化
        /// 把小时与分钟连在一起分析，那么遍历0-1023二进制中1的数量，如果数量正确，再分析二进制高4位（小时）与低4位（分钟）的有效性
        /// </summary>
        /// <param name="turnedOn"></param>
        /// <returns></returns>
        public IList<string> ReadBinaryWatch(int turnedOn)
        {
            throw new NotImplementedException();
        }
    }
}
