using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1105
{
    public class Test1105
    {
        public void Test()
        {
            Interface1105 solution = new Solution1105_2();
            int[][] books; int shelfWidth;
            int result, answer;
            int id = 0;

            // 1. 
            books = new int[][] { new int[] { 1, 1 }, new int[] { 2, 3 }, new int[] { 2, 3 }, new int[] { 1, 1 }, new int[] { 1, 1 }, new int[] { 1, 1 }, new int[] { 1, 2 } };
            shelfWidth = 4;
            answer = 6;
            result = solution.MinHeightShelves(books, shelfWidth);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2. 
            books = new int[][] { new int[] { 1, 3 }, new int[] { 2, 4 }, new int[] { 3, 2 } };
            shelfWidth = 6;
            answer = 4;
            result = solution.MinHeightShelves(books, shelfWidth);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3. 
            books = new int[][] { new int[] { 2, 3 }, new int[] { 1, 1 }, new int[] { 1, 1 }, new int[] { 1, 1 }, new int[] { 1, 1 }, new int[] { 1, 2 }, new int[] { 2, 3 } };
            shelfWidth = 4;
            answer = 7;
            result = solution.MinHeightShelves(books, shelfWidth);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4. 
            // [[11,83],[170,4],[93,80],[155,163],[134,118],[75,14],[122,192],[123,154],[187,29],[160,64],[170,152],[113,179],[60,102],[28,187],[59,95],[187,97],[49,193],[67,126],[75,45],[130,160],[4,102],[116,171],[43,170],[96,188],[54,15],[167,183],[58,158],[59,55],[148,183],[89,95],[90,113],[51,49],[91,28],[172,103],[173,3],[131,78],[11,199],[77,200],[58,65],[77,30],[157,58],[18,194],[101,148],[22,197],[76,181],[21,176],[50,45],[80,174],[116,198],[138,9],[58,125],[163,102],[133,175],[21,39],[141,156],[34,185],[14,113],[11,34],[35,184],[16,132],[78,147],[85,170],[32,149],[46,94],[196,3],[155,90],[9,114],[117,119],[17,157],[94,178],[53,55],[103,142],[70,121],[9,141],[16,170],[92,137],[157,30],[94,82],[144,149],[128,160],[8,147],[153,198],[12,22],[140,68],[64,172],[86,63],[66,158],[23,15],[120,99],[27,165],[79,174],[46,19],[60,98],[160,172],[128,184],[63,172],[135,54],[40,4],[102,171],[29,125],[81,9],[111,197],[16,90],[22,150],[168,126],[187,61],[47,190],[54,110],[106,102],[55,47],[117,134],[33,107],[2,10],[18,62],[109,188],[113,37],[59,159],[120,175],[17,147],[112,195],[177,53],[148,173],[29,105],[196,32],[123,51],[29,19],[161,178],[148,2],[70,124],[126,9],[105,87],[41,121],[147,10],[78,167],[91,197],[22,98],[73,33],[148,194],[166,64],[33,138],[139,158],[160,19],[140,27],[103,109],[88,16],[99,181],[2,140],[50,188],[200,77],[73,84],[159,130],[115,199],[152,79],[1,172],[124,136],[117,138],[158,86],[193,150],[56,57],[150,133],[52,186],[21,145],[127,97],[108,110],[174,44],[199,169],[139,200],[66,48],[52,190],[27,86],[142,191],[191,79],[126,114],[125,100],[176,95],[104,79],[146,189],[144,78],[52,106],[74,74],[163,128],[34,181],[20,178],[15,107],[105,8],[66,142],[39,126],[95,59],[164,69],[138,18],[110,145],[128,200],[149,150],[149,93],[145,140],[90,170],[81,127],[57,151],[167,127],[95,89]]
            books = new int[][] { new int[] { 11, 83 }, new int[] { 170, 4 }, new int[] { 93, 80 }, new int[] { 155, 163 }, new int[] { 134, 118 }, new int[] { 75, 14 },
                                  new int[] { 122, 192 }, new int[] { 123, 154 }, new int[] { 187, 29 }, new int[] { 160, 64 }, new int[] { 170, 152 }, new int[] { 113, 179 },
                                  new int[] { 60, 102 }, new int[] { 28, 187 }, new int[] { 59, 95 }, new int[] { 187, 97 }, new int[] { 49, 193 }, new int[] { 67, 126 },
                                  new int[] { 75, 45 }, new int[] { 130, 160 }, new int[] { 4, 102 }, new int[] { 116, 171 }, new int[] { 43, 170 }, new int[] { 96, 188 },
                                  new int[] { 54, 15 }, new int[] { 167, 183 }, new int[] { 58, 158 }, new int[] { 59, 55 }, new int[] { 148, 183 }, new int[] { 89, 95 },
                                  new int[] { 90, 113 }, new int[] { 51, 49 }, new int[] { 91, 28 }, new int[] { 172, 103 }, new int[] { 173, 3 }, new int[] { 131, 78 }, new int[] { 11, 199 },
                                  new int[] { 77, 200 }, new int[] { 58, 65 }, new int[] { 77, 30 }, new int[] { 157, 58 }, new int[] { 18, 194 }, new int[] { 101, 148 }, new int[] { 22, 197 },
                                  new int[] { 76, 181 }, new int[] { 21, 176 }, new int[] { 50, 45 }, new int[] { 80, 174 }, new int[] { 116, 198 }, new int[] { 138, 9 }, new int[] { 58, 125 },
                                  new int[] { 163, 102 }, new int[] { 133, 175 }, new int[] { 21, 39 }, new int[] { 141, 156 }, new int[] { 34, 185 }, new int[] { 14, 113 }, new int[] { 11, 34 },
                                  new int[] { 35, 184 }, new int[] { 16, 132 }, new int[] { 78, 147 }, new int[] { 85, 170 }, new int[] { 32, 149 }, new int[] { 46, 94 }, new int[] { 196, 3 },
                                  new int[] { 155, 90 }, new int[] { 9, 114 }, new int[] { 117, 119 }, new int[] { 17, 157 }, new int[] { 94, 178 }, new int[] { 53, 55 }, new int[] { 103, 142 },
                                  new int[] { 70, 121 }, new int[] { 9, 141 }, new int[] { 16, 170 }, new int[] { 92, 137 }, new int[] { 157, 30 }, new int[] { 94, 82 }, new int[] { 144, 149 },
                                  new int[] { 128, 160 }, new int[] { 8, 147 }, new int[] { 153, 198 }, new int[] { 12, 22 }, new int[] { 140, 68 }, new int[] { 64, 172 }, new int[] { 86, 63 },
                                  new int[] { 66, 158 }, new int[] { 23, 15 }, new int[] { 120, 99 }, new int[] { 27, 165 }, new int[] { 79, 174 }, new int[] { 46, 19 }, new int[] { 60, 98 },
                                  new int[] { 160, 172 }, new int[] { 128, 184 }, new int[] { 63, 172 }, new int[] { 135, 54 }, new int[] { 40, 4 }, new int[] { 102, 171 }, new int[] { 29, 125 },
                                  new int[] { 81, 9 }, new int[] { 111, 197 }, new int[] { 16, 90 }, new int[] { 22, 150 }, new int[] { 168, 126 }, new int[] { 187, 61 }, new int[] { 47, 190 },
                                  new int[] { 54, 110 }, new int[] { 106, 102 }, new int[] { 55, 47 }, new int[] { 117, 134 }, new int[] { 33, 107 }, new int[] { 2, 10 }, new int[] { 18, 62 },
                                  new int[] { 109, 188 }, new int[] { 113, 37 }, new int[] { 59, 159 }, new int[] { 120, 175 }, new int[] { 17, 147 }, new int[] { 112, 195 }, new int[] { 177, 53 },
                                  new int[] { 148, 173 }, new int[] { 29, 105 }, new int[] { 196, 32 }, new int[] { 123, 51 }, new int[] { 29, 19 }, new int[] { 161, 178 }, new int[] { 148, 2 },
                                  new int[] { 70, 124 }, new int[] { 126, 9 }, new int[] { 105, 87 }, new int[] { 41, 121 }, new int[] { 147, 10 }, new int[] { 78, 167 }, new int[] { 91, 197 },
                                  new int[] { 22, 98 }, new int[] { 73, 33 }, new int[] { 148, 194 }, new int[] { 166, 64 }, new int[] { 33, 138 }, new int[] { 139, 158 }, new int[] { 160, 19 },
                                  new int[] { 140, 27 }, new int[] { 103, 109 }, new int[] { 88, 16 }, new int[] { 99, 181 }, new int[] { 2, 140 }, new int[] { 50, 188 }, new int[] { 200, 77 },
                                  new int[] { 73, 84 }, new int[] { 159, 130 }, new int[] { 115, 199 }, new int[] { 152, 79 }, new int[] { 1, 172 }, new int[] { 124, 136 }, new int[] { 117, 138 },
                                  new int[] { 158, 86 }, new int[] { 193, 150 }, new int[] { 56, 57 }, new int[] { 150, 133 }, new int[] { 52, 186 }, new int[] { 21, 145 }, new int[] { 127, 97 },
                                  new int[] { 108, 110 }, new int[] { 174, 44 }, new int[] { 199, 169 }, new int[] { 139, 200 }, new int[] { 66, 48 }, new int[] { 52, 190 }, new int[] { 27, 86 },
                                  new int[] { 142, 191 }, new int[] { 191, 79 }, new int[] { 126, 114 }, new int[] { 125, 100 }, new int[] { 176, 95 }, new int[] { 104, 79 }, new int[] { 146, 189 },
                                  new int[] { 144, 78 }, new int[] { 52, 106 }, new int[] { 74, 74 }, new int[] { 163, 128 }, new int[] { 34, 181 }, new int[] { 20, 178 }, new int[] { 15, 107 },
                                  new int[] { 105, 8 }, new int[] { 66, 142 }, new int[] { 39, 126 }, new int[] { 95, 59 }, new int[] { 164, 69 }, new int[] { 138, 18 }, new int[] { 110, 145 },
                                  new int[] { 128, 200 }, new int[] { 149, 150 }, new int[] { 149, 93 }, new int[] { 145, 140 }, new int[] { 90, 170 }, new int[] { 81, 127 }, new int[] { 57, 151 },
                                  new int[] { 167, 127 }, new int[] { 95, 89 } };
            shelfWidth = 200;
            answer = 15672;
            result = solution.MinHeightShelves(books, shelfWidth);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
