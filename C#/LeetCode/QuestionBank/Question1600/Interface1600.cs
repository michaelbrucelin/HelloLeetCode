using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1600
{
    /// <summary>
    /// Your ThroneInheritance object will be instantiated and called as such:
    /// ThroneInheritance obj = new ThroneInheritance(kingName);
    /// obj.Birth(parentName,childName);
    /// obj.Death(name);
    /// IList<string> param_3 = obj.GetInheritanceOrder();
    /// </summary>
    public interface Interface1600
    {
        // public ThroneInheritance(string kingName)

        public void Birth(string parentName, string childName);

        public void Death(string name);

        public IList<string> GetInheritanceOrder();
    }
}
