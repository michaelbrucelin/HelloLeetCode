### [重新安排会议得到最多空余时间 I](https://leetcode.cn/problems/reschedule-meetings-for-maximum-free-time-i/solutions/3712357/zhong-xin-an-pai-hui-yi-de-dao-zui-duo-k-wm8c/)

#### 方法一：贪心 + 前缀和

根据题意，平移一个会议可以将该会议左右两侧相邻的空余时间段进行合并，那么对 $k$ 个会议进行平移时，最多可以将 $k+1$ 个空余时间段进行合并（当且仅当 $k$ 个会议相邻）。当进行平移的 $k$ 个相邻的会议固定时，令合并的第一个空余时间段的开始时间为 $left$，合并的最后一个空余时间段的结束时间为 $right$，那么合并的 $k+1$ 个空余时间段的总长等于总时间间隔 $right-left$ 减去 $k$ 个会议的时间总长。

预计算 $n$ 个会议的时间前缀和 $sum$，方便后续计算相邻 $k$ 个会议的时间总长。然后枚举 $k$ 个相邻会议最右边的会议为 $i$，显然 $i\ge k-1$，那么 $k$ 个相邻会议为区间 $[i-k+1,i]$，我们计算以下几个值：

- $k$ 个会议时间总长 $sum[i+1]-sum[i-k+1]$
- 合并的第一个空余时间段的开始时间：
    $$left_i=\begin{cases}0 & if \enspace i\le k-1 \\ endTime[i-k] & if \enspace i >k-1 \end{cases}$$
- 最后一个空余时间段的结束时间：
    $$right_i=\begin{cases}eventTime & if \enspace i=n-1 \\ startTime[i+1] & if \enspace i \ne n-1\end{cases}$$

那么就可以计算合并的 $k+1$ 个空余时间段的总长 $right_i-left_i-(sum[i+1]-sum[i-k+1])$，最终返回所有枚举结果的最大值。

```C++
class Solution {
public:
    int maxFreeTime(int eventTime, int k, vector<int>& startTime, vector<int>& endTime) {
        int n = startTime.size(), res = 0;
        vector<int> sum(n + 1);
        for (int i = 0; i < n; i++) {
            sum[i + 1] = sum[i] + endTime[i] - startTime[i];
        }
        for (int i = k - 1; i < n; i++) {
            int right = i == n - 1 ? eventTime : startTime[i + 1];
            int left = i == k - 1 ? 0 : endTime[i - k];
            res = max(res, right - left - (sum[i + 1] - sum[i - k + 1]));
        }
        return res;
    }
};
```

```Go
func maxFreeTime(eventTime int, k int, startTime []int, endTime []int) int {
    n := len(startTime)
    res := 0
    sum := make([]int, n + 1)
    for i := 0; i < n; i++ {
        sum[i + 1] = sum[i] + endTime[i] - startTime[i]
    }
    for i := k - 1; i < n; i++ {
        var right int
        if i == n - 1 {
            right = eventTime
        } else {
            right = startTime[i + 1]
        }
        var left int
        if i == k - 1 {
            left = 0
        } else {
            left = endTime[i - k]
        }
        res = max(res, right - left - (sum[i + 1] - sum[i - k + 1]))
    }
    return res
}
```

```Python
class Solution:
    def maxFreeTime(self, eventTime: int, k: int, startTime: List[int], endTime: List[int]) -> int:
        n = len(startTime)
        res = 0
        total = [0] * (n + 1)
        for i in range(n):
            total[i + 1] = total[i] + endTime[i] - startTime[i]
        for i in range(k - 1, n):
            right = eventTime if i == n - 1 else startTime[i + 1]
            left = 0 if i == k - 1 else endTime[i - k]
            res = max(res, right - left - (total[i + 1] - total[i - k + 1]))
        return res
```

```Java
public class Solution {
    public int maxFreeTime(int eventTime, int k, int[] startTime, int[] endTime) {
        int n = startTime.length, res = 0;
        int[] sum = new int[n + 1];
        for (int i = 0; i < n; i++) {
            sum[i + 1] = sum[i] + endTime[i] - startTime[i];
        }
        for (int i = k - 1; i < n; i++) {
            int right = i == n - 1 ? eventTime : startTime[i + 1];
            int left = i == k - 1 ? 0 : endTime[i - k];
            res = Math.max(res, right - left - (sum[i + 1] - sum[i - k + 1]));
        }
        return res;
    }
}
```

```TypeScript
function maxFreeTime(eventTime: number, k: number, startTime: number[], endTime: number[]): number {
    let n = startTime.length, res = 0;
    let sum: number[] = new Array(n + 1).fill(0);
    for (let i = 0; i < n; i++) {
        sum[i + 1] = sum[i] + endTime[i] - startTime[i];
    }
    for (let i = k - 1; i < n; i++) {
        let right = i === n - 1 ? eventTime : startTime[i + 1];
        let left = i === k - 1 ? 0 : endTime[i - k];
        res = Math.max(res, right - left - (sum[i + 1] - sum[i - k + 1]));
    }
    return res;
}
```

```JavaScript
var maxFreeTime = function(eventTime, k, startTime, endTime) {
    let n = startTime.length, res = 0;
    let sum = new Array(n + 1).fill(0);
    for (let i = 0; i < n; i++) {
        sum[i + 1] = sum[i] + endTime[i] - startTime[i];
    }
    for (let i = k - 1; i < n; i++) {
        let right = i === n - 1 ? eventTime : startTime[i + 1];
        let left = i === k - 1 ? 0 : endTime[i - k];
        res = Math.max(res, right - left - (sum[i + 1] - sum[i - k + 1]));
    }
    return res;
};
```

```CSharp
public class Solution {
    public int MaxFreeTime(int eventTime, int k, int[] startTime, int[] endTime) {
        int n = startTime.Length, res = 0;
        int[] sum = new int[n + 1];
        for (int i = 0; i < n; i++) {
            sum[i + 1] = sum[i] + endTime[i] - startTime[i];
        }
        for (int i = k - 1; i < n; i++) {
            int right = i == n - 1 ? eventTime : startTime[i + 1];
            int left = i == k - 1 ? 0 : endTime[i - k];
            res = Math.Max(res, right - left - (sum[i + 1] - sum[i - k + 1]));
        }
        return res;
    }
}
```

```C
int maxFreeTime(int eventTime, int k, int* startTime, int startSize, int* endTime, int endSize) {
    int n = startSize;
    int res = 0;
    int* sum = (int*)calloc(n + 1, sizeof(int));
    for (int i = 0; i < n; i++) {
        sum[i + 1] = sum[i] + endTime[i] - startTime[i];
    }
    for (int i = k - 1; i < n; i++) {
        int right = (i == n - 1) ? eventTime : startTime[i + 1];
        int left = (i == k - 1) ? 0 : endTime[i - k];
        int val = right - left - (sum[i + 1] - sum[i - k + 1]);
        res = fmax(res, val);
    }
    free(sum);
    return res;
}
```

```Rust
impl Solution {
    pub fn max_free_time(event_time: i32, k: i32, start_time: Vec<i32>, end_time: Vec<i32>) -> i32 {
        let n = start_time.len();
        let k = k as usize;
        let mut res = 0;
        let mut sum = vec![0; n + 1];
        for i in 0..n {
            sum[i + 1] = sum[i] + end_time[i] - start_time[i];
        }
        for i in (k - 1)..n {
            let right = if i == n - 1 { event_time } else { start_time[i + 1] };
            let left = if i == k - 1 { 0 } else { end_time[i - k] };
            res = res.max(right - left - (sum[i + 1] - sum[i - k + 1]));
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是所有会议的数目。
- 空间复杂度：$O(n)$。

#### 方法二：贪心 + 滑动窗口

方法一中，我们使用了会议时长的前缀和数组来计算 $k$ 个相邻会议的时间总长，这里同样可以使用滑动窗口来计算 $k$ 个相邻会议的时间总长。具体地，我们使用 $t$ 来计算窗口内会议的时间总长，依次将会议 $i$ 加入窗口：

- 将 $i$ 加入窗口中，计算 $t=t+endTime[i]-startTime[i]$
- 根据方法一计算 $left_i$ 和 $right_i$，那么窗口内的会议平移时，合并的空余时间段的总长为 $right_i-left_i-t$
- 如果窗口的会议数量等于 $k$，即 $i\ge k-1$ 时，需要将会议 $i-k+1$ 移出窗口，保证后续加入会议时窗口内会议的数量小于等于 $k$，计算$$t=t-(endTime[i-k+1]-startTime[i-k+1])$$

返回合并的空余时间段总长的最大值。

```C++
class Solution {
public:
    int maxFreeTime(int eventTime, int k, vector<int>& startTime, vector<int>& endTime) {
        int n = startTime.size(), res = 0, t = 0;
        for (int i = 0; i < n; i++) {
            t += endTime[i] - startTime[i];
            int left = i <= k - 1 ? 0 : endTime[i - k];
            int right = i == n - 1 ? eventTime : startTime[i + 1];
            res = max(res, right - left - t);
            if (i >= k - 1) {
                t -= endTime[i - k + 1] - startTime[i - k + 1];
            }
        }
        return res;
    }
};
```

```Go
func maxFreeTime(eventTime int, k int, startTime []int, endTime []int) int {
    n := len(startTime)
    res := 0
    t := 0
    for i := 0; i < n; i++ {
        t += endTime[i] - startTime[i]
        var left int
        if i <= k - 1 {
            left = 0
        } else {
            left = endTime[i - k]
        }
        var right int
        if i == n - 1 {
            right = eventTime
        } else {
            right = startTime[i + 1]
        }
        if right - left - t > res {
            res = right - left - t
        }
        if i >= k - 1 {
            t -= endTime[i - k + 1] - startTime[i - k + 1]
        }
    }
    return res
}
```

```Python
class Solution:
    def maxFreeTime(self, eventTime: int, k: int, startTime: List[int], endTime: List[int]) -> int:
        n = len(startTime)
        res = 0
        t = 0
        for i in range(n):
            t += endTime[i] - startTime[i]
            left = 0 if i <= k - 1 else endTime[i - k]
            right = eventTime if i == n - 1 else startTime[i + 1]
            res = max(res, right - left - t)
            if i >= k - 1:
                t -= endTime[i - k + 1] - startTime[i - k + 1]
        return res
```

```Java
public class Solution {
    public int maxFreeTime(int eventTime, int k, int[] startTime, int[] endTime) {
        int n = startTime.length, res = 0, t = 0;
        for (int i = 0; i < n; i++) {
            t += endTime[i] - startTime[i];
            int left = i <= k - 1 ? 0 : endTime[i - k];
            int right = i == n - 1 ? eventTime : startTime[i + 1];
            res = Math.max(res, right - left - t);
            if (i >= k - 1) {
                t -= endTime[i - k + 1] - startTime[i - k + 1];
            }
        }
        return res;
    }
}
```

```TypeScript
function maxFreeTime(eventTime: number, k: number, startTime: number[], endTime: number[]): number {
    let n = startTime.length, res = 0, t = 0;
    for (let i = 0; i < n; i++) {
        t += endTime[i] - startTime[i];
        let left = i <= k - 1 ? 0 : endTime[i - k];
        let right = i === n - 1 ? eventTime : startTime[i + 1];
        res = Math.max(res, right - left - t);
        if (i >= k - 1) {
            t -= endTime[i - k + 1] - startTime[i - k + 1];
        }
    }
    return res;
}
```

```JavaScript
var maxFreeTime = function(eventTime, k, startTime, endTime) {
    let n = startTime.length, res = 0, t = 0;
    for (let i = 0; i < n; i++) {
        t += endTime[i] - startTime[i];
        let left = i <= k - 1 ? 0 : endTime[i - k];
        let right = i === n - 1 ? eventTime : startTime[i + 1];
        res = Math.max(res, right - left - t);
        if (i >= k - 1) {
            t -= endTime[i - k + 1] - startTime[i - k + 1];
        }
    }
    return res;
};
```

```CSharp
public class Solution {
    public int MaxFreeTime(int eventTime, int k, int[] startTime, int[] endTime) {
        int n = startTime.Length, res = 0, t = 0;
        for (int i = 0; i < n; i++) {
            t += endTime[i] - startTime[i];
            int left = i <= k - 1 ? 0 : endTime[i - k];
            int right = i == n - 1 ? eventTime : startTime[i + 1];
            res = Math.Max(res, right - left - t);
            if (i >= k - 1) {
                t -= endTime[i - k + 1] - startTime[i - k + 1];
            }
        }
        return res;
    }
}
```

```C
int maxFreeTime(int eventTime, int k, int* startTime, int startSize, int* endTime, int endSize) {
    int n = startSize;
    int res = 0, t = 0;
    for (int i = 0; i < n; i++) {
        t += endTime[i] - startTime[i];
        int left = (i <= k - 1) ? 0 : endTime[i - k];
        int right = (i == n - 1) ? eventTime : startTime[i + 1];
        if (right - left - t > res) res = right - left - t;
        if (i >= k - 1) {
            t -= endTime[i - k + 1] - startTime[i - k + 1];
        }
    }
    return res;
}
```

```Rust
impl Solution {
    pub fn max_free_time(event_time: i32, k: i32, start_time: Vec<i32>, end_time: Vec<i32>) -> i32 {
        let n = start_time.len();
        let k = k as usize;
        let mut res: i32 = 0;
        let mut t: i32 = 0;

        for i in 0..n {
            t += end_time[i] - start_time[i];
            let left = if i <= k - 1 { 0 } else { end_time[i - k] };
            let right = if i == n - 1 { event_time } else { start_time[i + 1] };
            res = res.max(right - left - t);
            if i >= k - 1 {
                t -= end_time[i - k + 1] - start_time[i - k + 1];
            }
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是所有会议的数目。
- 空间复杂度：$O(1)$。
