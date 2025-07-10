### [重新安排会议得到最多空余时间 II](https://leetcode.cn/problems/reschedule-meetings-for-maximum-free-time-ii/solutions/3712358/zhong-xin-an-pai-hui-yi-de-dao-zui-duo-k-tx57/)

#### 方法一：贪心

假设当前平移的会议为 $i$，那么平移的最优解有两种情况：

1. 如果会议 $i$ 可以移动到某个空余时间段，且该空余时间段不是会议 $i$ 左右两侧相邻的两个空余时间段，那么平移会议 $i$ 可以得到一个新的空余时间段，时长为会议 $i$ 和其左右两侧相邻空余时间段的时长之和
2. 否则，平移会议 $i$ 可以将其左右两侧相邻空间时间段进行合并

显然，重新安排会议后得到的最大空余时间必定为平移某个会议后，得到的新的空余时间段的最大值。

我们使用 $q[i]$ 记录会议 $i$ 是否适用于第一种情况，首先从左到右遍历会议，同时记录当前遍历到的会议 $i$ 左侧非相邻的空余时间段的最大时长 $t_1$，如果 $t_1\ge endTime[i]-startTime[i]$，那么说明会议 $i$ 左侧有满足第一种情况的空余时间段，记 $q[i]=true$。同样地，我们从右到左遍历会议，记下会议 $i$ 右侧是否有满足第一种情况的空余时间段。

我们枚举平移的会议 $i$，同时令 $left_i$ 表示左侧相邻会议的结束时间，$right_i$ 表示右侧相邻会议的开始时间，然后根据 $q[i]$ 的值判断平移会议 $i$ 属于哪个情况：

- 情况一：新的空余时间段的时长为 $right_i-left_i$
- 情况二：新的空余时间段的时长为 $right_i-left_i-(endTime[i]-startTime[i])$

返回所有枚举结果的最大值。

```C++
class Solution {
public:
    int maxFreeTime(int eventTime, vector<int>& startTime, vector<int>& endTime) {
        int n = startTime.size();
        vector<bool> q(n);
        for (int i = 0, t1 = 0, t2 = 0; i < n; i++) {
            if (endTime[i] - startTime[i] <= t1) {
                q[i] = true;
            }
            t1 = max(t1, startTime[i] - (i == 0 ? 0 : endTime[i - 1]));

            if (endTime[n - i - 1] - startTime[n - i - 1] <= t2) {
                q[n - i - 1] = true;
            }
            t2 = max(t2, (i == 0 ? eventTime : startTime[n - i]) - endTime[n - i - 1]);
        }

        int res = 0;
        for (int i = 0; i < n; i++) {
            int left = i == 0 ? 0 : endTime[i - 1];
            int right = i == n - 1 ? eventTime : startTime[i + 1];
            if (q[i]) {
                res = max(res, right - left);
            } else {
                res = max(res, right - left - (endTime[i] - startTime[i]));
            }
        }
        return res;
    }
};
```

```Go
func maxFreeTime(eventTime int, startTime []int, endTime []int) int {
    n := len(startTime)
    q := make([]bool, n)
    t1, t2 := 0, 0
    for i := 0; i < n; i++ {
        if endTime[i] - startTime[i] <= t1 {
            q[i] = true
        }
        if i == 0 {
            t1 = max(t1, startTime[i])
        } else {
            t1 = max(t1, startTime[i] - endTime[i - 1])
        }

        if endTime[n - i - 1] - startTime[n - i - 1] <= t2 {
            q[n - i - 1] = true
        }
        if i == 0 {
            t2 = max(t2, eventTime - endTime[n - 1])
        } else {
            t2 = max(t2, startTime[n - i] - endTime[n - i - 1])
        }
    }

    res := 0
    for i := 0; i < n; i++ {
        left := 0
        if i != 0 {
            left = endTime[i - 1]
        }
        right := eventTime
        if i != n - 1 {
            right = startTime[i + 1]
        }
        if q[i] {
            res = max(res, right - left)
        } else {
            res = max(res, right - left - (endTime[i] - startTime[i]))
        }
    }
    return res
}
```

```Python
class Solution:
    def maxFreeTime(self, eventTime: int, startTime: list[int], endTime: list[int]) -> int:
        n = len(startTime)
        q = [False] * n
        t1 = 0
        t2 = 0
        for i in range(n):
            if endTime[i] - startTime[i] <= t1:
                q[i] = True
            t1 = max(t1, startTime[i] - (0 if i == 0 else endTime[i - 1]))

            if endTime[n - i - 1] - startTime[n - i - 1] <= t2:
                q[n - i - 1] = True
            t2 = max(t2, (eventTime if i == 0 else startTime[n - i]) - endTime[n - i - 1])

        res = 0
        for i in range(n):
            left = 0 if i == 0 else endTime[i - 1]
            right = eventTime if i == n - 1 else startTime[i + 1]
            if q[i]:
                res = max(res, right - left)
            else:
                res = max(res, right - left - (endTime[i] - startTime[i]))
        return res
```

```Java
class Solution {
    public int maxFreeTime(int eventTime, int[] startTime, int[] endTime) {
        int n = startTime.length;
        boolean[] q = new boolean[n];
        for (int i = 0, t1 = 0, t2 = 0; i < n; i++) {
            if (endTime[i] - startTime[i] <= t1) {
                q[i] = true;
            }
            t1 = Math.max(t1, startTime[i] - (i == 0 ? 0 : endTime[i - 1]));

            if (endTime[n - i - 1] - startTime[n - i - 1] <= t2) {
                q[n - i - 1] = true;
            }
            t2 = Math.max(t2, (i == 0 ? eventTime : startTime[n - i]) - endTime[n - i - 1]);
        }

        int res = 0;
        for (int i = 0; i < n; i++) {
            int left = i == 0 ? 0 : endTime[i - 1];
            int right = i == n - 1 ? eventTime : startTime[i + 1];
            if (q[i]) {
                res = Math.max(res, right - left);
            } else {
                res = Math.max(res, right - left - (endTime[i] - startTime[i]));
            }
        }
        return res;
    }
}
```

```TypeScript
function maxFreeTime(eventTime: number, startTime: number[], endTime: number[]): number {
    const n = startTime.length;
    const q: boolean[] = new Array(n).fill(false);
    let t1 = 0, t2 = 0;
    for (let i = 0; i < n; i++) {
        if (endTime[i] - startTime[i] <= t1) {
            q[i] = true;
        }
        t1 = Math.max(t1, startTime[i] - (i === 0 ? 0 : endTime[i - 1]));

        if (endTime[n - i - 1] - startTime[n - i - 1] <= t2) {
            q[n - i - 1] = true;
        }
        t2 = Math.max(t2, (i === 0 ? eventTime : startTime[n - i]) - endTime[n - i - 1]);
    }

    let res = 0;
    for (let i = 0; i < n; i++) {
        const left = i === 0 ? 0 : endTime[i - 1];
        const right = i === n - 1 ? eventTime : startTime[i + 1];
        if (q[i]) {
            res = Math.max(res, right - left);
        } else {
            res = Math.max(res, right - left - (endTime[i] - startTime[i]));
        }
    }
    return res;
}
```

```JavaScript
var maxFreeTime = function(eventTime, startTime, endTime) {
    const n = startTime.length;
    const q = new Array(n).fill(false);
    let t1 = 0, t2 = 0;
    for (let i = 0; i < n; i++) {
        if (endTime[i] - startTime[i] <= t1) {
            q[i] = true;
        }
        t1 = Math.max(t1, startTime[i] - (i === 0 ? 0 : endTime[i - 1]));

        if (endTime[n - i - 1] - startTime[n - i - 1] <= t2) {
            q[n - i - 1] = true;
        }
        t2 = Math.max(t2, (i === 0 ? eventTime : startTime[n - i]) - endTime[n - i - 1]);
    }

    let res = 0;
    for (let i = 0; i < n; i++) {
        const left = i === 0 ? 0 : endTime[i - 1];
        const right = i === n - 1 ? eventTime : startTime[i + 1];
        if (q[i]) {
            res = Math.max(res, right - left);
        } else {
            res = Math.max(res, right - left - (endTime[i] - startTime[i]));
        }
    }
    return res;
};
```

```CSharp
public class Solution {
    public int MaxFreeTime(int eventTime, int[] startTime, int[] endTime) {
        int n = startTime.Length;
        bool[] q = new bool[n];
        int t1 = 0, t2 = 0;
        for (int i = 0; i < n; i++) {
            if (endTime[i] - startTime[i] <= t1) {
                q[i] = true;
            }
            t1 = Math.Max(t1, startTime[i] - (i == 0 ? 0 : endTime[i - 1]));

            if (endTime[n - i - 1] - startTime[n - i - 1] <= t2) {
                q[n - i - 1] = true;
            }
            t2 = Math.Max(t2, (i == 0 ? eventTime : startTime[n - i]) - endTime[n - i - 1]);
        }

        int res = 0;
        for (int i = 0; i < n; i++) {
            int left = i == 0 ? 0 : endTime[i - 1];
            int right = i == n - 1 ? eventTime : startTime[i + 1];
            if (q[i]) {
                res = Math.Max(res, right - left);
            } else {
                res = Math.Max(res, right - left - (endTime[i] - startTime[i]));
            }
        }
        return res;
    }
}
```

```C
int maxFreeTime(int eventTime, int* startTime, int startTimeSize, int* endTime, int endTimeSize) {
    int n = startTimeSize;
    bool* q = (bool*)calloc(n, sizeof(bool));
    int t1 = 0, t2 = 0;
    for (int i = 0; i < n; i++) {
        if (endTime[i] - startTime[i] <= t1) {
            q[i] = true;
        }
        t1 = fmax(t1, startTime[i] - (i == 0 ? 0 : endTime[i - 1]));

        if (endTime[n - i - 1] - startTime[n - i - 1] <= t2) {
            q[n - i - 1] = true;
        }
        t2 = fmax(t2, (i == 0 ? eventTime : startTime[n - i]) - endTime[n - i - 1]);
    }

    int res = 0;
    for (int i = 0; i < n; i++) {
        int left = i == 0 ? 0 : endTime[i - 1];
        int right = i == n - 1 ? eventTime : startTime[i + 1];
        if (q[i]) {
            res = fmax(res, right - left);
        } else {
            res = fmax(res, right - left - (endTime[i] - startTime[i]));
        }
    }
    free(q);
    return res;
}
```

```Rust
impl Solution {
    pub fn max_free_time(event_time: i32, start_time: Vec<i32>, end_time: Vec<i32>) -> i32 {
        let n = start_time.len();
        let mut q = vec![false; n];
        let mut t1 = 0;
        let mut t2 = 0;
        for i in 0..n {
            if end_time[i] - start_time[i] <= t1 {
                q[i] = true;
            }
            t1 = t1.max(start_time[i] - if i == 0 { 0 } else { end_time[i - 1] });

            let j = n - i - 1;
            if end_time[j] - start_time[j] <= t2 {
                q[j] = true;
            }
            t2 = t2.max(if i == 0 { event_time } else { start_time[n - i] } - end_time[j]);
        }

        let mut res = 0;
        for i in 0..n {
            let left = if i == 0 { 0 } else { end_time[i - 1] };
            let right = if i == n - 1 { event_time } else { start_time[i + 1] };
            if q[i] {
                res = res.max(right - left);
            } else {
                res = res.max(right - left - (end_time[i] - start_time[i]));
            }
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是所有会议的数目。
- 空间复杂度：$O(n)$。

#### 方法二：贪心 + 优化

方法一中使用了 $q[i]$ 来判断会议 $i$ 平移的最优解，如果我们在枚举会议 $i$ 的过程中对会议 $i$ 平移的两种情况进行计算，那么就可以去掉数组 $q$。具体过程如下：

- 枚举平移的会议，将该会议左右两侧相邻的空余时间段进行合并，计算得到的新的空余时间段的时长。
- 从左到右枚举平移的会议，同时用 $t_1$ 记录当前遍历到的会议左侧非相邻的空余时间段的最大时长，如果当前会议时长小于等于 $t_1$，那么说明该会议可以平移到 $t_1$ 对应的空余时间段，计算平移后得到的新的空余时间段的时长。
- 从右到左枚举平移的会议，同时用 $t_2$ 记录当前遍历到的会议右侧非相邻的空余时间段的最大时长，如果当前会议时长小于等于 $t_2$，那么说明该会议可以平移到 $t_2$ 对应的空余时间段，计算平移后得到的新的空余时间段的时长。

返回以上所有新的空余时间段时长的最大值。

```C++
class Solution {
public:
    int maxFreeTime(int eventTime, vector<int>& startTime, vector<int>& endTime) {
        int n = startTime.size(), res = 0;
        for (int i = 0, t1 = 0, t2 = 0; i < n; i++) {
            int left1 = i == 0 ? 0 : endTime[i - 1];
            int right1 = i == n - 1 ? eventTime : startTime[i + 1];
            if (endTime[i] - startTime[i] <= t1) {
                res = max(res, right1 - left1);
            }
            t1 = max(t1, startTime[i] - (i == 0 ? 0 : endTime[i - 1]));

            res = max(res, right1 - left1 - (endTime[i] - startTime[i]));

            int left2 = i == n - 1 ? 0 : endTime[n - i - 2];
            int right2 = i == 0 ? eventTime : startTime[n - i];
            if (endTime[n - i - 1] - startTime[n - i - 1] <= t2) {
                res = max(res, right2 - left2);
            }
            t2 = max(t2, (i == 0 ? eventTime : startTime[n - i]) - endTime[n - i - 1]);
        }
        return res;
    }
};
```

```Go
func maxFreeTime(eventTime int, startTime []int, endTime []int) int {
    n := len(startTime)
    q := make([]bool, n)
    t1, t2 := 0, 0
    for i := 0; i < n; i++ {
        if endTime[i] - startTime[i] <= t1 {
            q[i] = true
        }
        if i == 0 {
            t1 = max(t1, startTime[i])
        } else {
            t1 = max(t1, startTime[i] - endTime[i - 1])
        }

        if endTime[n - i - 1] - startTime[n - i - 1] <= t2 {
            q[n - i - 1] = true
        }
        if i == 0 {
            t2 = max(t2, eventTime - endTime[n - 1])
        } else {
            t2 = max(t2, startTime[n - i] - endTime[n - i - 1])
        }
    }

    res := 0
    for i := 0; i < n; i++ {
        left := 0
        if i != 0 {
            left = endTime[i - 1]
        }
        right := eventTime
        if i != n - 1 {
            right = startTime[i + 1]
        }
        if q[i] {
            res = max(res, right - left)
        } else {
            res = max(res, right - left - (endTime[i] - startTime[i]))
        }
    }
    return res
}
```

```Python
class Solution:
    def maxFreeTime(self, eventTime: int, startTime: list[int], endTime: list[int]) -> int:
        n = len(startTime)
        q = [False] * n
        t1 = 0
        t2 = 0
        for i in range(n):
            if endTime[i] - startTime[i] <= t1:
                q[i] = True
            t1 = max(t1, startTime[i] - (0 if i == 0 else endTime[i - 1]))

            if endTime[n - i - 1] - startTime[n - i - 1] <= t2:
                q[n - i - 1] = True
            t2 = max(t2, (eventTime if i == 0 else startTime[n - i]) - endTime[n - i - 1])

        res = 0
        for i in range(n):
            left = 0 if i == 0 else endTime[i - 1]
            right = eventTime if i == n - 1 else startTime[i + 1]
            if q[i]:
                res = max(res, right - left)
            else:
                res = max(res, right - left - (endTime[i] - startTime[i]))
        return res
```

```Java
class Solution {
    public int maxFreeTime(int eventTime, int[] startTime, int[] endTime) {
        int n = startTime.length;
        boolean[] q = new boolean[n];
        for (int i = 0, t1 = 0, t2 = 0; i < n; i++) {
            if (endTime[i] - startTime[i] <= t1) {
                q[i] = true;
            }
            t1 = Math.max(t1, startTime[i] - (i == 0 ? 0 : endTime[i - 1]));

            if (endTime[n - i - 1] - startTime[n - i - 1] <= t2) {
                q[n - i - 1] = true;
            }
            t2 = Math.max(t2, (i == 0 ? eventTime : startTime[n - i]) - endTime[n - i - 1]);
        }

        int res = 0;
        for (int i = 0; i < n; i++) {
            int left = i == 0 ? 0 : endTime[i - 1];
            int right = i == n - 1 ? eventTime : startTime[i + 1];
            if (q[i]) {
                res = Math.max(res, right - left);
            } else {
                res = Math.max(res, right - left - (endTime[i] - startTime[i]));
            }
        }
        return res;
    }
}
```

```TypeScript
function maxFreeTime(eventTime: number, startTime: number[], endTime: number[]): number {
    const n = startTime.length;
    const q: boolean[] = new Array(n).fill(false);
    let t1 = 0, t2 = 0;
    for (let i = 0; i < n; i++) {
        if (endTime[i] - startTime[i] <= t1) {
            q[i] = true;
        }
        t1 = Math.max(t1, startTime[i] - (i === 0 ? 0 : endTime[i - 1]));

        if (endTime[n - i - 1] - startTime[n - i - 1] <= t2) {
            q[n - i - 1] = true;
        }
        t2 = Math.max(t2, (i === 0 ? eventTime : startTime[n - i]) - endTime[n - i - 1]);
    }

    let res = 0;
    for (let i = 0; i < n; i++) {
        const left = i === 0 ? 0 : endTime[i - 1];
        const right = i === n - 1 ? eventTime : startTime[i + 1];
        if (q[i]) {
            res = Math.max(res, right - left);
        } else {
            res = Math.max(res, right - left - (endTime[i] - startTime[i]));
        }
    }
    return res;
}
```

```JavaScript
var maxFreeTime = function(eventTime, startTime, endTime) {
    const n = startTime.length;
    const q = new Array(n).fill(false);
    let t1 = 0, t2 = 0;
    for (let i = 0; i < n; i++) {
        if (endTime[i] - startTime[i] <= t1) {
            q[i] = true;
        }
        t1 = Math.max(t1, startTime[i] - (i === 0 ? 0 : endTime[i - 1]));

        if (endTime[n - i - 1] - startTime[n - i - 1] <= t2) {
            q[n - i - 1] = true;
        }
        t2 = Math.max(t2, (i === 0 ? eventTime : startTime[n - i]) - endTime[n - i - 1]);
    }

    let res = 0;
    for (let i = 0; i < n; i++) {
        const left = i === 0 ? 0 : endTime[i - 1];
        const right = i === n - 1 ? eventTime : startTime[i + 1];
        if (q[i]) {
            res = Math.max(res, right - left);
        } else {
            res = Math.max(res, right - left - (endTime[i] - startTime[i]));
        }
    }
    return res;
};
```

```CSharp
public class Solution {
    public int MaxFreeTime(int eventTime, int[] startTime, int[] endTime) {
        int n = startTime.Length;
        bool[] q = new bool[n];
        int t1 = 0, t2 = 0;
        for (int i = 0; i < n; i++) {
            if (endTime[i] - startTime[i] <= t1) {
                q[i] = true;
            }
            t1 = Math.Max(t1, startTime[i] - (i == 0 ? 0 : endTime[i - 1]));

            if (endTime[n - i - 1] - startTime[n - i - 1] <= t2) {
                q[n - i - 1] = true;
            }
            t2 = Math.Max(t2, (i == 0 ? eventTime : startTime[n - i]) - endTime[n - i - 1]);
        }

        int res = 0;
        for (int i = 0; i < n; i++) {
            int left = i == 0 ? 0 : endTime[i - 1];
            int right = i == n - 1 ? eventTime : startTime[i + 1];
            if (q[i]) {
                res = Math.Max(res, right - left);
            } else {
                res = Math.Max(res, right - left - (endTime[i] - startTime[i]));
            }
        }
        return res;
    }
}
```

```C
int maxFreeTime(int eventTime, int* startTime, int startTimeSize, int* endTime, int endTimeSize) {
    int n = startTimeSize;
    bool* q = (bool*)calloc(n, sizeof(bool));
    int t1 = 0, t2 = 0;
    for (int i = 0; i < n; i++) {
        if (endTime[i] - startTime[i] <= t1) {
            q[i] = true;
        }
        t1 = fmax(t1, startTime[i] - (i == 0 ? 0 : endTime[i - 1]));

        if (endTime[n - i - 1] - startTime[n - i - 1] <= t2) {
            q[n - i - 1] = true;
        }
        t2 = fmax(t2, (i == 0 ? eventTime : startTime[n - i]) - endTime[n - i - 1]);
    }

    int res = 0;
    for (int i = 0; i < n; i++) {
        int left = i == 0 ? 0 : endTime[i - 1];
        int right = i == n - 1 ? eventTime : startTime[i + 1];
        if (q[i]) {
            res = fmax(res, right - left);
        } else {
            res = fmax(res, right - left - (endTime[i] - startTime[i]));
        }
    }
    free(q);
    return res;
}
```

```Rust
impl Solution {
    pub fn max_free_time(event_time: i32, start_time: Vec<i32>, end_time: Vec<i32>) -> i32 {
        let n = start_time.len();
        let mut q = vec![false; n];
        let mut t1 = 0;
        let mut t2 = 0;
        for i in 0..n {
            if end_time[i] - start_time[i] <= t1 {
                q[i] = true;
            }
            t1 = t1.max(start_time[i] - if i == 0 { 0 } else { end_time[i - 1] });

            let j = n - i - 1;
            if end_time[j] - start_time[j] <= t2 {
                q[j] = true;
            }
            t2 = t2.max(if i == 0 { event_time } else { start_time[n - i] } - end_time[j]);
        }

        let mut res = 0;
        for i in 0..n {
            let left = if i == 0 { 0 } else { end_time[i - 1] };
            let right = if i == n - 1 { event_time } else { start_time[i + 1] };
            if q[i] {
                res = res.max(right - left);
            } else {
                res = res.max(right - left - (end_time[i] - start_time[i]));
            }
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是所有会议的数目。
- 空间复杂度：$O(1)$。
