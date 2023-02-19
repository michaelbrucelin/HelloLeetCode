using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question0401
{
    public class Solution0401 : Interface0401
    {
        /// <summary>
        /// 组合
        /// 小时是由1, 2, 4, 8这4个数字中的几个组合而来，4次背包
        /// 分钟是由1, 2, 4, 8， 16， 32这6个数字中的几个组合而来，6次背包
        /// 简化
        /// 把小时与分钟连在一起分析，10次背包
        /// </summary>
        /// <param name="turnedOn"></param>
        /// <returns></returns>
        public IList<string> ReadBinaryWatch(int turnedOn)
        {
            throw new NotImplementedException();
        }
    }
}
