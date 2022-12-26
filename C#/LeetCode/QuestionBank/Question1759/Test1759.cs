using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.QuestionBank.Question1759
{
    public class Test1759
    {
        public void Test()
        {
            Interface1759 solution = new Solution1759();
            string s;
            int result, answer;
            int id = 0;

            // 1.
            s = "abbcccaa";
            answer = 13; result = solution.CountHomogenous(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 2.
            s = "xy";
            answer = 2; result = solution.CountHomogenous(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 3.
            s = "zzzzz";
            answer = 15; result = solution.CountHomogenous(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 4.
            s = "a";
            answer = 1; result = solution.CountHomogenous(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");

            // 5.
            s = "agikidwllqrniqspzgtwkjzemjrnozhqpfudtysdjgdhhhhhhhbimbncxuhnzfcmegtfomvbierfqqsqzyrjretqinxkbdkkfvzhppzhirnmexpjpyztvnuqtxtxehgabgdmiouoprzrzgsnellrkhfotvreyovtzjlnscncckiyoqnuiefjwblygalaecfwyhbfqiwgmabyzzeygwgprujwjpjdscfaqmkuvpdohbpsxoussbcdeulryewxmbnabglgrlmviqnwaqpxuafoqgvuevvjkhkpfwndrlxkcsrxeeqytbeecjzlkazbwxxcjbrnahvsabujxvofhbzfifxlnfwmrjikuvmosupvauxexwptagdgasnsmbpkrlvrfsvzjepcevlhvajugstxzogbqtrnzqbizwjzbiejgvcccrysjeexklpkezdlxytkijtguicdrkgwdjjlwjedlvxjvfumjmxswitkgvrfduuujjbtutkhweekqhzusxpohsvicbkjhxdvaecqvvaizifyznuqizruvwymjvbndpjpozlfzeryerjzrmfenqhuenczzjdmzzrdkkomaxbfolwycoskaqqoghbhkcsexfzlhsahjxwoqvbdhemmaksqcetlckxrttkneuwnpuvwautszkxeqqbzmguwezlgxssmkfwnwcgymwbbekebmfqtlvxsluwwtvwejrxkvvnblqbuhwewkzkabqplchqkykuijgkbcdpbkqdocdzcjjkufkamssnrdvdglbdpocvtfigknztqxgyxekcmuxbyztnvjytjphflxjbzamhzzkoczcgfsabhhymywrchdtunhrjpnquwqfbbxdryrcvzwvvmpmjcjdjhofeuoeuvuysgapburxseacneveclnupekqkcsloaodwrckdtomtlcchwmxrmcegrmsdbnoprahdovwohuufzfeftljubgwmigkvfdjxgcbiipsjimjiygmagjkgi";
            answer = 1072; result = solution.CountHomogenous(s);
            Console.WriteLine($"{++id,2}: {(result == answer) + ",",-6} result: {result}, answer: {answer}");
        }
    }
}
