using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2383
{
    public class Solution2383 : Interface2383
    {
        public int MinNumberOfHours(int initialEnergy, int initialExperience, int[] energy, int[] experience)
        {
            int result = 0;
            for (int i = 0; i < energy.Length; i++)
            {
                if (initialEnergy <= energy[i])
                {
                    result += energy[i] - initialEnergy + 1; initialEnergy = 1;
                }
                else
                {
                    initialEnergy -= energy[i];
                }

                if (initialExperience <= experience[i])
                {
                    result += experience[i] - initialExperience + 1; initialExperience = (experience[i] << 1) + 1;
                }
                else
                {
                    initialExperience += experience[i];
                }
            }

            return result;
        }

        public int MinNumberOfHours2(int initialEnergy, int initialExperience, int[] energy, int[] experience)
        {
            int result = Math.Max(0, energy.Sum() - initialEnergy + 1);
            for (int i = 0; i < energy.Length; i++)
            {
                if (initialExperience <= experience[i])
                {
                    result += experience[i] - initialExperience + 1; initialExperience = (experience[i] << 1) + 1;
                }
                else
                {
                    initialExperience += experience[i];
                }
            }

            return result;
        }
    }
}
