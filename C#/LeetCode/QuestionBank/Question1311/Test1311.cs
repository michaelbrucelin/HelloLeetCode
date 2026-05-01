using LeetCode.Utilses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1311
{
    public class Test1311
    {
        public void Test()
        {
            Interface1311 solution = new Solution1311();
            IList<IList<string>> watchedVideos; int[][] friends; int id, level;
            IList<string> result, answer;
            int _id = 0;

            // 1. 
            watchedVideos = [["A", "B"], ["C"], ["B", "C"], ["D"]]; friends = [[1, 2], [0, 3], [0, 3], [1, 2]]; id = 0; level = 1;
            answer = ["B", "C"];
            result = solution.WatchedVideosByFriends(watchedVideos, friends, id, level);
            Console.WriteLine($"{++_id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 2. 
            watchedVideos = [["A", "B"], ["C"], ["B", "C"], ["D"]]; friends = [[1, 2], [0, 3], [0, 3], [1, 2]]; id = 0; level = 2;
            answer = ["D"];
            result = solution.WatchedVideosByFriends(watchedVideos, friends, id, level);
            Console.WriteLine($"{++_id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)}, answer: {Utils.ToString(answer)}");

            // 3. 
            string question = "1311", testcase = "03";
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = Path.Combine(Directory.GetParent(path).Parent.Parent.FullName, @$"QuestionBank\Question{question}\TestCases\TestCase{question}");
            watchedVideos = Utils.Str2StrIList_2d(File.ReadAllText($"{path}_{testcase}_watchedVideos.txt"));
            friends = Utils.Str2NumArray_2d<int>(File.ReadAllText($"{path}_{testcase}_friends.txt"));
            id = 20; level = 2;
            answer = Utils.Str2StrList(File.ReadAllText($"{path}_{testcase}_answer.txt"));
            result = solution.WatchedVideosByFriends(watchedVideos, friends, id, level);
            Console.WriteLine($"{++_id,2}: {Utils.CompareArray(result, answer) + ",",-6} result: {Utils.ToString(result)[..10]}, answer: {Utils.ToString(answer)[..10]}");
        }
    }
}
