### [酿造药水需要的最少总时间](https://leetcode.cn/problems/find-the-minimum-amount-of-time-to-brew-potions/solutions/3800529/niang-zao-yao-shui-xu-yao-de-zui-shao-zo-ojii/)

#### 方法一：动态规划

**思路与算法**

题目要求每个药水都需要经过每个巫师酿造，每个巫师同时只能酿造一瓶药水并且每瓶药水只要开始被酿造后，中间不能暂停，必须经由每位巫师连续酿造。

首先第一瓶药水在时刻 $0$ 就开始被酿造，因此后续每位巫师酿造完该药水的时间是固定的，容易被计算出。但后续的药水开始时间并不明朗，我们不妨先允许酿造第 $j$ 瓶药水的过程不连续（但前 $j-1$ 瓶仍然要求连续），设第 $i$ 位巫师处理完第 $j$ 瓶药水的时间是 $times[i][j]$，那么有：

$$times[i][j]=max(times[i-1][j],times[i][j-1])+skill[i]\times mana[j]$$

经过一轮递推，第 $j$ 瓶药水的完成时间 $times[n-1][j]$ 被计算出，此时我们需要反向遍历更新前面巫师处理第 $j$ 瓶药水的完成时间，消除之前允许不连续酿造所产生的间隔。

在编写代码的过程中，$times$ 可以使用一维数组滚动优化。

**代码**

```C++
class Solution {
public:
    using ll = long long;
    long long minTime(vector<int>& skill, vector<int>& mana) {
        int n = skill.size(), m = mana.size();
        vector<ll> times(n);
        for (int j = 0; j < m; j++) {
            ll cur_time = 0;
            for (int i = 0; i < n; i++) {
                cur_time = max(cur_time, times[i]) + skill[i] * mana[j];
            }
            times[n - 1] = cur_time;
            for (int i = n - 2; i >= 0; i--) {
                times[i] = times[i + 1] - skill[i + 1] * mana[j];
            }
        }
        return times[n - 1];
    }
};
```

```Python
class Solution:
    def minTime(self, skill: List[int], mana: List[int]) -> int:
        n, m = len(skill), len(mana)
        times = [0] * n
        for j in range(m):
            cur_time = 0
            for i in range(n):
                cur_time = max(cur_time, times[i]) + skill[i] * mana[j]
            times[n - 1] = cur_time
            for i in range(n - 2, -1, -1):
                times[i] = times[i + 1] - skill[i + 1] * mana[j]
        return times[n - 1]
```

```Rust
impl Solution {
    pub fn min_time(skill: Vec<i32>, mana: Vec<i32>) -> i64 {
        let n = skill.len();
        let m = mana.len();
        let mut times = vec![0i64; n];

        for &mj in &mana {
            let mut cur_time: i64 = 0;
            for i in 0..n {
                cur_time = std::cmp::max(cur_time, times[i]) + skill[i] as i64 * mj as i64;
            }
            times[n - 1] = cur_time;
            for i in (0..n - 1).rev() {
                times[i] = times[i + 1] - skill[i + 1] as i64 * mj as i64;
            }
        }

        times[n - 1]
    }
}
```

```Java
class Solution {
    public long minTime(int[] skill, int[] mana) {
        int n = skill.length, m = mana.length;
        long[] times = new long[n];
        
        for (int j = 0; j < m; j++) {
            long curTime = 0;
            for (int i = 0; i < n; i++) {
                curTime = Math.max(curTime, times[i]) + (long)skill[i] * mana[j];
            }
            times[n - 1] = curTime;
            for (int i = n - 2; i >= 0; i--) {
                times[i] = times[i + 1] - (long)skill[i + 1] * mana[j];
            }
        }
        return times[n - 1];
    }
}
```

```CSharp
public class Solution {
    public long MinTime(int[] skill, int[] mana) {
        int n = skill.Length, m = mana.Length;
        long[] times = new long[n];
        
        for (int j = 0; j < m; j++) {
            long curTime = 0;
            for (int i = 0; i < n; i++) {
                curTime = Math.Max(curTime, times[i]) + (long)skill[i] * mana[j];
            }
            times[n - 1] = curTime;
            for (int i = n - 2; i >= 0; i--) {
                times[i] = times[i + 1] - (long)skill[i + 1] * mana[j];
            }
        }
        return times[n - 1];
    }
}
```

```Go
func minTime(skill []int, mana []int) int64 {
    n, m := len(skill), len(mana)
    times := make([]int64, n)
    
    for j := 0; j < m; j++ {
        var curTime int64 = 0
        for i := 0; i < n; i++ {
            if curTime < times[i] {
                curTime = times[i]
            }
            curTime += int64(skill[i]) * int64(mana[j])
        }
        times[n - 1] = curTime
        for i := n - 2; i >= 0; i-- {
            times[i] = times[i + 1] - int64(skill[i + 1]) * int64(mana[j])
        }
    }
    return times[n - 1]
}
```

```C
long long minTime(int* skill, int skillSize, int* mana, int manaSize) {
    long long* times = (long long*)malloc(skillSize * sizeof(long long));
    for (int i = 0; i < skillSize; i++) {
        times[i] = 0;
    }
    
    for (int j = 0; j < manaSize; j++) {
        long long cur_time = 0;
        for (int i = 0; i < skillSize; i++) {
            cur_time = (cur_time > times[i] ? cur_time : times[i]) + (long long)skill[i] * mana[j];
        }
        times[skillSize - 1] = cur_time;
        for (int i = skillSize - 2; i >= 0; i--) {
            times[i] = times[i + 1] - (long long)skill[i + 1] * mana[j];
        }
    }
    
    long long result = times[skillSize - 1];
    free(times);
    return result;
}
```

```JavaScript
var minTime = function(skill, mana) {
    const n = skill.length, m = mana.length;
    const times = new Array(n).fill(0);
    
    for (let j = 0; j < m; j++) {
        let curTime = 0;
        for (let i = 0; i < n; i++) {
            curTime = Math.max(curTime, times[i]) + skill[i] * mana[j];
        }
        times[n - 1] = curTime;
        for (let i = n - 2; i >= 0; i--) {
            times[i] = times[i + 1] - skill[i + 1] * mana[j];
        }
    }
    return times[n - 1];
};
```

```TypeScript
function minTime(skill: number[], mana: number[]): number {
    const n = skill.length, m = mana.length;
    const times: number[] = new Array(n).fill(0);
    
    for (let j = 0; j < m; j++) {
        let curTime = 0;
        for (let i = 0; i < n; i++) {
            curTime = Math.max(curTime, times[i]) + skill[i] * mana[j];
        }
        times[n - 1] = curTime;
        for (let i = n - 2; i >= 0; i--) {
            times[i] = times[i + 1] - skill[i + 1] * mana[j];
        }
    }
    return times[n - 1];
};
```

**复杂度分析**

- 时间复杂度：$O(nm)$，其中 $n$ 是 $skill$ 的长度，$m$ 是 $mana$ 的长度。
- 空间复杂度：$O(n)$。
