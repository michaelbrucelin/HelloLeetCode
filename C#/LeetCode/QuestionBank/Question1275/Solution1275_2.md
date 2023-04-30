#### [����һ��ģ��](https://leetcode.cn/problems/find-winner-on-a-tic-tac-toe-game/solutions/101698/zhao-chu-jing-zi-qi-de-huo-sheng-zhe-by-leetcode-s/)

���ǿ���ģ������ `move` �е�ÿһ�����ӡ�����ʹ���������� `A` �� `B` ���ÿλ��ҵ�ǰ�Ѿ����ӵ�λ�ã����ü��� `wins` ��������ų�һ��ֱ�ߵ�����������ų�һ�л�һ�и��� `3` �֣��ųɶԽ����� `2` �֣��ܼ� `8` �֣�����ĳλ�������ʱ������ö�� `wins` �е�ÿһ����������жϸ�����Ƿ�������������Щλ�á��������������һ������������һ�ʤ��

���ֱ�����������Ȼû����һ�ʤ����ô�������� `move` �ĳ��ȷ���ƽ�� `Draw` ����Ϸδ���� `Pending`��

```cpp
class Solution {
public:
    bool checkwin(unordered_set<int>& S, vector<vector<int>>& wins) {
        for (auto win: wins) {
            bool flag = true;
            for (auto pos: win) {
                if (!S.count(pos)) {
                    flag = false;
                    break;
                }
            }
            if (flag) {
                return true;
            }
        }
        return false;
    }

    string tictactoe(vector<vector<int>>& moves) {
        vector<vector<int>> wins = {
            {0, 1, 2},
            {3, 4, 5},
            {6, 7, 8},
            {0, 3, 6},
            {1, 4, 7},
            {2, 5, 8},
            {0, 4, 8},
            {2, 4, 6}
        };

        unordered_set<int> A, B;
        for (int i = 0; i < moves.size(); ++i) {
            int pos = moves[i][0] * 3 + moves[i][1];
            if (i % 2 == 0) {
                A.insert(pos);
                if (checkwin(A, wins)) {
                    return "A";
                }
            }
            else {
                B.insert(pos);
                if (checkwin(B, wins)) {
                    return "B";
                }
            }
        }

        return (moves.size() == 9 ? "Draw" : "Pending");
    }
};
```

```python
class Solution:
    def tictactoe(self, moves: List[List[int]]) -> str:
        wins = [
            [(0, 0), (0, 1), (0, 2)],
            [(1, 0), (1, 1), (1, 2)],
            [(2, 0), (2, 1), (2, 2)],
            [(0, 0), (1, 0), (2, 0)],
            [(0, 1), (1, 1), (2, 1)],
            [(0, 2), (1, 2), (2, 2)],
            [(0, 0), (1, 1), (2, 2)],
            [(0, 2), (1, 1), (2, 0)],
        ]

        def checkwin(S):
            for win in wins:
                flag = True
                for pos in win:
                    if pos not in S:
                        flag = False
                        break
                if flag:
                    return True
            return False

        A, B = set(), set()
        for i, (x, y) in enumerate(moves):
            if i % 2 == 0:
                A.add((x, y))
                if checkwin(A):
                    return "A"
            else:
                B.add((x, y))
                if checkwin(B):
                    return "B"
        
        return "Draw" if len(moves) == 9 else "Pending"
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(N^4)$������ $N$ �����̵ı߳����ڱ����� $N = 3$������ `wins` �д�ŵ��ų�һ��ֱ�ߵ��������������Ϊ $O(2N+2)=O(N)$������ÿһ������������Ҫ�������е��������ÿһ������� $N$ ��λ�ã����ʱ�临�Ӷ�Ϊ $O(N^2)$���������£����ӵ�����Ϊ $O(N^2)$�������ʱ�临�Ӷ�Ϊ $O(N^4)$��
-   �ռ临�Ӷȣ�$O(N^2)$������ `wins` ռ�õĿռ�Ϊ $O(N^2)$�������� `A` �� `B` ��������ռ�õĿռ�ҲΪ $O(N^2)$��
