### [得到更多分数的最少关卡数目](https://leetcode.cn/problems/minimum-levels-to-gain-more-points/solutions/2844225/de-dao-geng-duo-fen-shu-de-zui-shao-guan-t8lf/)

#### 方法一：前缀和

**思路与算法**

根据题意可以知道，每次通过简单关卡玩家得 $1$ 分，通过困难关卡，玩家失去 $1$ 分，当 $Alice$ 从第 $i$ 个关卡结束时，此时 $Bob$ 从第 $i+1$ 个关卡开始完成剩余得关卡。经分析可知道，由于通过每个关卡的得分是确定的，因此通过 $n$ 个关卡的游戏总得分也是固定的。假设通过 $n$ 个关卡的游戏总得分为 $tot$，此时 $Alice$ 完成了前 $i$ 个关卡的得分为 $pre$，$Bob$ 的得分即为 $tot-pre$，若使的 $Alice$ 得分多于 $Bob$ 的得分，则 $tot-pre<pre$，此时满足 $2 \times pre>tot$ 即可。

经过以上分析，我们首先计算出游戏的总得分 $tot$，当 $possible[i]=1$ 时，$tot$ 加 $1$，当 $possible[i]=0$ 时，$tot$ 减 $1$，然后依次遍历 $i$ 计算出前 $i$ 个关卡的得分 $pre$，当满足 $2 \times pre>tot$ 则返回 $i+1$ 即可，如不存在满足条件的 $i$，则返回 $-1$。

**代码**

```C++
class Solution {
public:
    int minimumLevels(vector<int>& possible) {
        int n = possible.size();
        int tot = accumulate(possible.begin(), possible.end(), 0) * 2 - n;
        int pre = 0;
        for (int i = 0; i < n - 1; i++) {
            pre += possible[i] == 1 ? 1 : -1;
            if (2 * pre > tot) {
                return i + 1;
            }
        }
        return -1;
    }
};
```

```Java
class Solution {
    public int minimumLevels(int[] possible) {
        int n = possible.length;
        int tot = 0;
        for (int x : possible) {
            tot += x == 1 ? 1 : -1;
        }
        int pre = 0;
        for (int i = 0; i < n - 1; i++) {
            pre += possible[i] == 1 ? 1 : -1;
            if (2 * pre > tot) {
                return i + 1;
            }
        }
        return -1;
    }
}
```

```CSharp
public class Solution {
    public int MinimumLevels(int[] possible) {
        int n = possible.Length;
        int tot = 0;
        foreach (int x in possible) {
            tot += x == 1 ? 1 : -1;
        }
        int pre = 0;
        for (int i = 0; i < n - 1; i++) {
            pre += possible[i] == 1 ? 1 : -1;
            if (2 * pre > tot) {
                return i + 1;
            }
        }
        return -1;
    }
}
```

```Go
func minimumLevels(possible []int) int {
    n := len(possible)
    tot := 0
    for _, v := range possible {
        tot += v
    }
    tot = tot * 2 - n
    pre := 0
    for i := 0; i < n - 1; i++ {
        if possible[i] == 1 {
            pre++
        } else {
            pre--
        }
        if 2*pre > tot {
            return i + 1
        }
    }
    return -1
}
```

```Python
class Solution:
    def minimumLevels(self, possible: List[int]) -> int:
        n = len(possible)
        tot = sum(possible) * 2 - n
        pre = 0
        for i in range(n - 1):
            pre += 1 if possible[i] == 1 else -1
            if 2 * pre > tot:
                return i + 1
        return -1
```

```C
int minimumLevels(int* possible, int possibleSize) {
    int tot = 0;
    for (int i = 0; i < possibleSize; i++) {
        tot += possible[i] == 1 ? 1 : -1;
    }
    int pre = 0;
    for (int i = 0; i < possibleSize - 1; i++) {
        pre += possible[i] == 1 ? 1 : -1;
        if (2 * pre > tot) {
            return i + 1;
        }
    }
    return -1;
}
```

```JavaScript
var minimumLevels = function(possible) {
    const n = possible.length;
    const tot = possible.reduce((a, b) => a + b, 0) * 2 - n;
    let pre = 0;
    for (let i = 0; i < n - 1; i++) {
        pre += possible[i] == 1 ? 1 : -1;
        if (2 * pre > tot) {
            return i + 1;
        }
    }
    return -1;
};
```

```TypeScript
function minimumLevels(possible: number[]): number {
    const n = possible.length;
    const tot = possible.reduce((a, b) => a + b, 0) * 2 - n;
    let pre = 0;
    for (let i = 0; i < n - 1; i++) {
        pre += possible[i] === 1 ? 1 : -1;
        if (2 * pre > tot) {
            return i + 1;
        }
    }
    return -1;
};
```

```Rust
impl Solution {
    pub fn minimum_levels(possible: Vec<i32>) -> i32 {
        let n = possible.len() as i32;
        let tot: i32 = possible.iter().sum::<i32>() * 2 - n;
        let mut pre = 0;
        for (i, &val) in possible.iter().enumerate().take(n as usize - 1) {
            pre += if val == 1 { 1 } else { -1 };
            if 2 * pre > tot {
                return (i + 1) as i32;
            }
        }
        -1
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 表示给定数组的长度。遍历两次 $possible$ 数组即可。
- 空间复杂度：$O(1)$。
