using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2115
{
    public class Solution2115 : Interface2115
    {
        /// <summary>
        /// 暴力贪心
        /// </summary>
        /// <param name="recipes"></param>
        /// <param name="ingredients"></param>
        /// <param name="supplies"></param>
        /// <returns></returns>
        public IList<string> FindAllRecipes(string[] recipes, IList<IList<string>> ingredients, string[] supplies)
        {
            List<string> result = [];
            int len = recipes.Length;
            bool[] mask = new bool[len];
            HashSet<string> set = [.. supplies];
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < len; i++) if (!mask[i])
                    {
                        foreach (string ing in ingredients[i]) if (!set.Contains(ing)) goto CONTINUE;
                        mask[i] = true;
                        set.Add(recipes[i]);
                        result.Add(recipes[i]);
                        flag = true;
                    CONTINUE:;
                    }
            }

            return result;
        }
    }
}
