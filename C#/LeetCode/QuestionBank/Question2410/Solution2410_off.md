### [运动员和训练师的最大匹配数](https://leetcode.cn/problems/maximum-matching-of-players-with-trainers/solutions/1850596/yun-dong-yuan-he-xun-lian-shi-de-zui-da-3icgd/)

#### 方法一：排序 + 双指针 + 贪心

为了尽可能匹配最多数量的运动员，从贪心的角度考虑，应该按照运动员的能力值从小到大的顺序依次匹配每个运动员，且对于每个运动员，应该选择可以匹配这个运动员的能力值且能力值最小的训练师。证明如下。

假设有 $m$ 个运动员，能力值分别是 $players_1$ 到 $players_m$，有 $n$ 个训练师，能力值分别是 $trainers_1$ 到 $trainers_n$，满足 $players_i \le players_{i+1}$ 和 $trainers_j \le trainers_{j+1}$，其中 $1 \le i<m$，$1 \le j<n$。

假设在对前 $i-1$ 个运动员匹配训练师之后，可以满足第 $i$ 个运动员的能力值的最小的训练师是第 $j$ 个训练师，即 $trainers_j$ 是剩下的训练师中满足 $players_i \le trainers_j$ 的最小值，最优解是将第 $j$ 个训练师匹配第 $i$ 个运动员。如果不这样匹配，考虑如下两种情形：

- 如果 $i<m$ 且 $players_{i+1} \le trainers_j$ 也成立，则如果将第 $j$ 个训练师匹配第 $i+1$ 个运动员，且还有剩余的训练师，则可以将第 $j+1$ 个训练师匹配第 $i$ 个运动员，匹配的结果不会让更多的运动员被匹配；
- 如果 $j<n$，则如果将第 $j+1$ 个训练师匹配第 $i$ 个运动员，当 $players_{i+1} \le trainers_j$ 时，可以将第 $j$ 个训练师匹配第 $i+1$ 个运动员，匹配的结果不会让更多的运动员被匹配；当 $players_{i+1}>trainers_j$ 时，第 $j$ 个训练师无法匹配任何运动员，因此剩下的可用的训练师少了一个，因此匹配的结果不会让更多的运动员被匹配，甚至可能因为少了一个可用的训练师而导致更少的运动员被匹配。

基于上述分析，可以使用贪心的方法尽可能满足最多数量的运动员。

首先对数组 $players$ 和 $trainers$ 排序，然后从小到大遍历 $players$ 中的每个元素，对于每个元素找到能满足该元素的 $trainers$ 中的最小的元素。具体而言，令 $i$ 是 $players$ 的下标，$j$ 是 $trainers$ 的下标，初始时 $i$ 和 $j$ 都为 $0$，进行如下操作。

对于每个元素 $players[i]$，找到**未被使用的**最小的 $j$ 使得 $players[i] \le trainers[j]$，则 $trainers[j]$ 可以满足 $players[i]$。由于 $players$ 和 $trainers$ 已经排好序，因此整个过程只需要对数组 $players$ 和 $trainers$ 各遍历一次。当两个数组之一遍历结束时，说明所有的运动员都匹配到了训练师，或者所有的训练师都已经匹配或尝试匹配运动员（可能有些训练师无法匹配任何运动员），此时匹配到训练师的运动员数量即为最大匹配书。

```Java
class Solution {
    public int matchPlayersAndTrainers(int[] players, int[] trainers) {
        Arrays.sort(players);
        Arrays.sort(trainers);
        int m = players.length, n = trainers.length;
        int count = 0;
        for (int i = 0, j = 0; i < m && j < n; i++, j++) {
            while (j < n && players[i] > trainers[j]) {
                j++;
            }
            if (j < n) {
                count++;
            }
        }
        return count;
    }
}
```

```CSharp
public class Solution {
    public int MatchPlayersAndTrainers(int[] players, int[] trainers) {
        Array.Sort(players);
        Array.Sort(trainers);
        int m = players.Length, n = trainers.Length;
        int count = 0;
        for (int i = 0, j = 0; i < m && j < n; i++, j++) {
            while (j < n && players[i] > trainers[j]) {
                j++;
            }
            if (j < n) {
                count++;
            }
        }
        return count;
    }
}
```

```JavaScript
var matchPlayersAndTrainers = function(players, trainers) {
    players.sort((a, b) => a - b);
    trainers.sort((a, b) => a - b);
    const m = players.length, n = trainers.length;
    let count = 0;
    for (let i = 0, j = 0; i < m && j < n; i++, j++) {
        while (j < n && players[i] > trainers[j]) {
            j++;
        }
        if (j < n) {
            count++;
        }
    }
    return count;
};
```

```C++
class Solution {
public:
    int matchPlayersAndTrainers(vector<int>& players, vector<int>& trainers) {
        sort(players.begin(), players.end());
        sort(trainers.begin(), trainers.end());
        int m = players.size(), n = trainers.size();
        int count = 0;
        for (int i = 0, j = 0; i < m && j < n; i++, j++) {
            while (j < n && players[i] > trainers[j]) {
                j++;
            }
            if (j < n) {
                count++;
            }
        }
        return count;
    }
};
```

```Go
func matchPlayersAndTrainers(players []int, trainers []int) (ans int) {
    sort.Ints(players)
    sort.Ints(trainers)
    m, n := len(players), len(trainers)
    for i, j := 0, 0; i < m && j < n; i++ {
        for j < n && players[i] > trainers[j] {
            j++
        }
        if j < n {
            ans++
            j++
        }
    }
    return
}
```

```Python
class Solution:
    def matchPlayersAndTrainers(self, players: List[int], trainers: List[int]) -> int:
        players.sort()
        trainers.sort()
        m, n = len(players), len(trainers)
        i = j = count = 0

        while i < m and j < n:
            while j < n and players[i] > trainers[j]:
                j += 1
            if j < n:
                count += 1
            i += 1
            j += 1
        
        return count
```

```C
int cmp(int* a, int* b) {
    return *a - *b;
}

int matchPlayersAndTrainers(int* players, int playersSize, int* trainers, int trainersSize) {
    qsort(players, playersSize, sizeof(int), cmp);
    qsort(trainers, trainersSize, sizeof(int), cmp);
    int m = playersSize, n = trainersSize;
    int count = 0;
    for (int i = 0, j = 0; i < m && j < n; i++, j++) {
        while (j < n && players[i] > trainers[j]) {
            j++;
        }
        if (j < n) {
            count++;
        }
    }
    return count;
}
```

**复杂度分析**

- 时间复杂度：$O(m\log m+n\log n)$，其中 $m$ 和 $n$ 分别是数组 $players$ 和 $trainers$ 的长度。对两个数组排序的时间复杂度是 $O(m\log m+n\log n)$，遍历数组的时间复杂度是 $O(m+n)$，因此总时间复杂度是 $O(m\log m+n\log n)$。
- 空间复杂度：$O(\log m+\log n)$，其中 $m$ 和 $n$ 分别是数组 $players$ 和 $trainers$ 的长度。空间复杂度主要是排序的额外空间开销。
