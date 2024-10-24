### [找到连续赢 K 场比赛的第一位玩家](https://leetcode.cn/problems/find-the-first-player-to-win-k-games-in-a-row/solutions/2959288/zhao-dao-lian-xu-ying-k-chang-bi-sai-de-mfoc3/)

#### 方法一：双指针

**思路与算法**

由于比赛输了的玩家会排到队列末尾，因此如果前面一直没有人是赢家（连续赢下 $k$ 次），那么 $skills$ 值最高的那个玩家就是赢家。因此，我们从前到后去遍历 $i$，判断它能否连续赢下 $k$ 次。若能，则直接返回答案，否则继续遍历，直到末尾。若仍没找到，则返回 $skills$ 值最高的那个玩家。

需要注意的是，如果 $i$ 不为 $0$，那么第 $i$ 个玩家最少已经赢了一次（与 $i$ 进行比赛的上一个玩家，输掉后排到末尾）。我们用 $cnt$ 来表示当前玩家赢得次数，初始值为 $0$，然后每次遍历下一个 $i$ 时，赋值为 $1$。

另外，玩家 $i$ 后面那些输掉比赛的玩家一定不是赢家，因为要么玩家 $i$ 是赢家，要么玩家 $i$ 后面还有一个 $skills$ 值更高的玩家，并且与玩家 $i$ 相隔不超过 $k$（或者 $k-1$）。

**代码**

```C++
class Solution {
public:
    int findWinningPlayer(vector<int>& skills, int k) {
        int n = skills.size();
        int cnt = 0;
        int i = 0, last_i = 0;
        while (i < n) {
            int j = i + 1; 
            while (j < n && skills[j] < skills[i] && cnt < k) {
                j++;
                cnt++;
            }
            if (cnt == k) {
                return i;
            }
            cnt = 1;
            last_i = i;
            i = j;
        }
        return last_i;
    }
};
```

```Python
class Solution:
    def findWinningPlayer(self, skills: List[int], k: int) -> int:
        n = len(skills)
        cnt = 0
        i, last_i = 0, 0
        while i < n:
            j = i + 1
            while j < n and skills[j] < skills[i] and cnt < k:
                cnt += 1
                j += 1
            if cnt == k:
                return i
            cnt = 1
            last_i = i
            i = j
        return last_i
```

```Java
class Solution {
    public int findWinningPlayer(int[] skills, int k) {
        int n = skills.length;
        int cnt = 0;
        int i = 0, last_i = 0;

        while (i < n) {
            int j = i + 1; 
            while (j < n && skills[j] < skills[i] && cnt < k) {
                j++;
                cnt++;
            }
            if (cnt == k) {
                return i;
            }
            cnt = 1;
            last_i = i;
            i = j;
        }
        return last_i;
    }
}
```

```CSharp
public class Solution {
    public int FindWinningPlayer(int[] skills, int k) {
        int n = skills.Length;
        int cnt = 0;
        int i = 0, last_i = 0;

        while (i < n) {
            int j = i + 1; 
            while (j < n && skills[j] < skills[i] && cnt < k) {
                j++;
                cnt++;
            }
            if (cnt == k) {
                return i;
            }
            cnt = 1;
            last_i = i;
            i = j;
        }
        return last_i;
    }
}
```

```Go
func findWinningPlayer(skills []int, k int) int {
    n := len(skills)
    cnt := 0
    i, lastI := 0, 0

    for i < n {
        j := i + 1
        for j < n && skills[j] < skills[i] && cnt < k {
            j++
            cnt++
        }
        if cnt == k {
            return i
        }
        cnt = 1
        lastI = i
        i = j
    }
    return lastI
}
```

```C
int findWinningPlayer(int* skills, int skillsSize, int k) {
    int cnt = 0;
    int i = 0, last_i = 0;

    while (i < skillsSize) {
        int j = i + 1; 
        while (j < skillsSize && skills[j] < skills[i] && cnt < k) {
            j++;
            cnt++;
        }
        if (cnt == k) {
            return i;
        }
        cnt = 1;
        last_i = i;
        i = j;
    }
    return last_i;
}
```

```JavaScript
var findWinningPlayer = function(skills, k) {
    const n = skills.length;
    let cnt = 0;
    let i = 0, last_i = 0;

    while (i < n) {
        let j = i + 1; 
        while (j < n && skills[j] < skills[i] && cnt < k) {
            j++;
            cnt++;
        }
        if (cnt === k) {
            return i;
        }
        cnt = 1;
        last_i = i;
        i = j;
    }
    return last_i;
};
```

```TypeScript
function findWinningPlayer(skills: number[], k: number): number {
    const n = skills.length;
    let cnt = 0;
    let i = 0, last_i = 0;

    while (i < n) {
        let j = i + 1; 
        while (j < n && skills[j] < skills[i] && cnt < k) {
            j++;
            cnt++;
        }
        if (cnt === k) {
            return i;
        }
        cnt = 1;
        last_i = i;
        i = j;
    }
    return last_i;
};
```

```Rust
impl Solution {
    pub fn find_winning_player(skills: Vec<i32>, k: i32) -> i32 {
        let n = skills.len();
        let mut cnt = 0;
        let mut i = 0;
        let mut last_i = 0;

        while i < n {
            let mut j = i + 1;
            while j < n && skills[j] < skills[i] && cnt < k {
                j += 1;
                cnt += 1;
            }
            if cnt == k {
                return i as i32;
            }
            cnt = 1;
            last_i = i as i32;
            i = j;
        }
        last_i 
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是 $skills$ 的长度。由于每个元素最多遍历一次，因此总体的时间复杂度为 $O(n)$。
- 空间复杂度：$O(1)$，只使用了若干个变量。
