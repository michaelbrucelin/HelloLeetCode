using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question2276
{
    public class Test2276
    {
        public void Test()
        {
            Interface2276 solution;
            string[] operations; int[][] args;
            int?[] answer;
            int result;
            int id1, id2;

            // 1. 
            id1 = 1; id2 = 0;
            solution = new CountIntervals2();
            operations = new string[] { "CountIntervals", "add", "add", "count", "add", "count" };
            args = Utils.Str2NumArray_2d<int>("[[],[2,3],[7,10],[],[5,8],[]]");
            answer = new int?[] { null, null, null, 6, null, 8 };
            for (int i = 1; i < operations.Length; i++)
            {
                switch (operations[i])
                {
                    case "add":
                        solution.Add(args[i][0], args[i][1]);
                        break;
                    case "count":
                        result = solution.Count();
                        Console.WriteLine($"{id1}-{++id2,2}: {(result == answer[i]) + ",",-6} result: {result}, answer: {answer[i]}");
                        break;
                    default:
                        break;
                }
            }

            // 2. 
            id1 = 2; id2 = 0;
            solution = new CountIntervals2();
            operations = new string[] { "CountIntervals", "add", "add", "add", "count", "count", "count", "add", "add", "add", "count", "add", "count", "add", "count", "count", "count", "count", "count", "add", "add", "add", "add", "count", "add", "count", "add", "count", "count", "add", "count", "count", "add", "count", "count", "count", "add", "add", "add", "count", "add", "add", "add", "add", "count", "add", "count", "count", "add", "add", "add", "add", "add", "count", "count", "add", "add", "count", "count", "count", "add", "add", "add", "add", "count", "add", "add", "add", "count", "count", "count", "count", "add", "count", "count", "add", "add", "count", "add", "count", "count", "add", "add", "count", "add", "add", "add", "count", "add", "add", "add", "add", "count", "count", "count", "add", "count", "add", "add", "count", "add", "add", "count", "add", "add", "add", "count", "add", "add", "add", "count", "count", "count", "add", "count", "add", "add", "add", "count", "add", "count", "count", "count", "add", "count", "count", "count", "add", "count", "count", "add", "count", "add" };
            args = Utils.Str2NumArray_2d<int>("[[],[365,897],[261,627],[781,884],[],[],[],[328,495],[224,925],[228,464],[],[416,451],[],[747,749],[],[],[],[],[],[740,757],[51,552],[20,896],[459,712],[],[383,670],[],[701,924],[],[],[392,591],[],[],[935,994],[],[],[],[398,525],[335,881],[243,517],[],[995,1000],[15,335],[430,490],[376,681],[],[733,841],[],[],[603,633],[974,978],[466,786],[241,753],[259,887],[],[],[410,514],[173,300],[],[],[],[805,957],[272,805],[723,858],[113,118],[],[426,987],[318,997],[741,978],[],[],[],[],[701,992],[],[],[562,766],[987,1000],[],[929,929],[],[],[926,931],[913,975],[],[930,962],[707,914],[688,757],[],[430,433],[452,683],[794,919],[799,991],[],[],[],[658,731],[],[328,686],[998,999],[],[455,938],[981,988],[],[92,699],[311,690],[916,920],[],[213,339],[605,961],[719,902],[],[],[],[129,833],[],[844,926],[940,956],[148,182],[],[163,885],[],[],[],[532,886],[],[],[],[306,906],[],[],[948,963],[],[116,853]]");
            answer = new int?[] { null, null, null, null, 637, 637, 637, null, null, null, 702, null, 702, null, 702, 702, 702, 702, 702, null, null, null, null, 906, null, 906, null, 906, 906, null, 906, 906, null, 966, 966, 966, null, null, null, 966, null, null, null, null, 977, null, 977, 977, null, null, null, null, null, 977, 977, null, null, 977, 977, 977, null, null, null, null, 986, null, null, null, 986, 986, 986, 986, null, 986, 986, null, null, 986, null, 986, 986, null, null, 986, null, null, null, 986, null, null, null, null, 986, 986, 986, null, 986, null, null, 986, null, null, 986, null, null, null, 986, null, null, null, 986, 986, 986, null, 986, null, null, null, 986, null, 986, 986, 986, null, 986, 986, 986, null, 986, 986, null, 986, null };
            for (int i = 1; i < operations.Length; i++)
            {
                switch (operations[i])
                {
                    case "add":
                        solution.Add(args[i][0], args[i][1]);
                        break;
                    case "count":
                        result = solution.Count();
                        Console.WriteLine($"{id1}-{++id2,2}: {(result == answer[i]) + ",",-6} result: {result}, answer: {answer[i]}");
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
