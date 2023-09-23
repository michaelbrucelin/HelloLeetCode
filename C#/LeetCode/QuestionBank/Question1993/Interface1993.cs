using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1993
{
    /// <summary>
    /// Your LockingTree object will be instantiated and called as such:
    /// LockingTree obj = new LockingTree(parent);
    /// bool param_1 = obj.Lock(num,user);
    /// bool param_2 = obj.Unlock(num,user);
    /// bool param_3 = obj.Upgrade(num,user);
    /// </summary>
    public interface Interface1993
    {
        public bool Lock(int num, int user);

        public bool Unlock(int num, int user);

        public bool Upgrade(int num, int user);
    }
}
