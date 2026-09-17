### [找两个和为目标值且不重叠的子数组](https://leetcode.cn/problems/find-two-non-overlapping-sub-arrays-each-with-target-sum/solutions/4022631/zhao-liang-ge-he-wei-mu-biao-zhi-qie-bu-8bl1h/)

#### 方法一：前缀和 + 动态规划 + 哈希表

**思路与算法**

题目要求我们找到两个互不重叠的、和都等于 $target$ 的子数组，且它们的长度之和最小。

首先，我们可以使用前缀和来快速求出哪些子数组的和为 $target$。令 $s[i]$ 表示前缀和，即 $s[i]=\sum\limits_{k=0}^{i}arr[k]$。对于某一个 $i$，如果能找到一个 $j$，使得 $s[i]-target=s[j]$，那么 $arr[j+1\dots i]$ 就是一个和为 $target$ 的子数组。

为了找到这样的 $j$，我们可以用哈希表把每一个前缀和最后一次出现的位置都保存下来，这样对于每一个 $s[i]$ 只需要查看哈希表中之前 $s[i]-target$ 出现的位置，也就是最后一次出现 $s[i]-target$ 的位置即可。

接下来，我们还需要知道前 $j$ 个数中和为 $target$ 的子数组的最小长度，这可以使用动态规划解决。令 $dp[j]$ 为这个最小长度，那么以第 $i$ 个数结尾的答案为 $dp[j]+i-j$，即两个子数组的长度之和。

为什么哈希表只需要保存前缀和 **最后一次** 出现的位置？对于第二个子数组来说，最后一次出现的位置一定离 $i$ 更近，使得其长度更小。对于第一个子数组，随着其可选择的元素增多，和为 $arr$ 的子数组的长度要么不变，要么减小，不会扩大。

实现时，由于前面的值不会再被用到，我们可以不用另外开辟数组，而是把 $arr$ 当作 $dp$ 数组使用。

**实现**

```C++
class Solution {
public:
    int minSumOfLengths(vector<int>& arr, int target) {
        unordered_map<int, int> pos;
        pos[0] = -1;
        int n = arr.size();
        int s = 0;
        int ans = n + 1;
        int minL = n;
        for (int i = 0; i < n; i++) {
            s += arr[i];
            if (pos.count(s - target)) {
                int j = pos[s - target];
                int l = i - j;
                ans = min(ans, l + (j == -1 ? n : arr[j]));
                minL = min(minL, l);
            }
            arr[i] = minL;
            pos[s] = i;
        }

        return ans == n + 1 ? -1 : ans;
    }
};
```

```Java
class Solution {
    public int minSumOfLengths(int[] arr, int target) {
        Map<Integer, Integer> pos = new HashMap<>();
        pos.put(0, -1);
        int n = arr.length, s = 0, ans = n + 1, minL = n;
        for (int i = 0; i < n; i++) {
            s += arr[i];
            if (pos.containsKey(s - target)) {
                int j = pos.get(s - target), len = i - j;
                ans = Math.min(ans, len + (j == -1 ? n : arr[j]));
                minL = Math.min(minL, len);
            }
            arr[i] = minL;
            pos.put(s, i);
        }
        return ans == n + 1 ? -1 : ans;
    }
}
```

```Python
class Solution:
    def minSumOfLengths(self, arr: List[int], target: int) -> int:
        pos = {0: -1}
        n = len(arr)
        s = ans = 0
        ans = n + 1
        min_l = n
        for i, x in enumerate(arr):
            s += x
            if s - target in pos:
                j = pos[s - target]
                length = i - j
                ans = min(ans, length + (n if j == -1 else arr[j]))
                min_l = min(min_l, length)
            arr[i] = min_l
            pos[s] = i
        return -1 if ans == n + 1 else ans
```

```Go
func minSumOfLengths(arr []int, target int) int {
    pos := map[int]int{0: -1}
    n, s, ans, minL := len(arr), 0, 0, 0
    ans, minL = n+1, n
    for i, x := range arr {
        s += x
        if j, ok := pos[s-target]; ok {
            length := i - j
            prev := n
            if j != -1 { prev = arr[j] }
            if length+prev < ans { ans = length + prev }
            if length < minL { minL = length }
        }
        arr[i] = minL
        pos[s] = i
    }
    if ans == n+1 { return -1 }
    return ans
}
```

```CSharp
public class Solution {
    public int MinSumOfLengths(int[] arr, int target) {
        var pos = new Dictionary<int, int> { [0] = -1 };
        int n = arr.Length, s = 0, ans = n + 1, minL = n;
        for (int i = 0; i < n; i++) {
            s += arr[i];
            if (pos.TryGetValue(s - target, out int j)) {
                int length = i - j;
                ans = Math.Min(ans, length + (j == -1 ? n : arr[j]));
                minL = Math.Min(minL, length);
            }
            arr[i] = minL;
            pos[s] = i;
        }
        return ans == n + 1 ? -1 : ans;
    }
}
```

```C
typedef struct {
    int id;
    int pos;
    UT_hash_handle hh;
} HashEntry;

int minSumOfLengths(int* arr, int arrSize, int target) {
    int n = arrSize, s = 0, ans = n + 1, minL = n;
    HashEntry *prefixes = NULL, *entry, *tmp;
    entry = malloc(sizeof(HashEntry));
    entry->id = 0;
    entry->pos = -1;
    HASH_ADD_INT(prefixes, id, entry);

    for (int i = 0; i < n; i++) {
        s += arr[i];
        int key = s - target;
        HASH_FIND_INT(prefixes, &key, entry);
        if (entry != NULL) {
            int j = entry->pos, length = i - j;
            int prev = j == -1 ? n : arr[j];
            if (length + prev < ans) ans = length + prev;
            if (length < minL) minL = length;
        }
        arr[i] = minL;
        HASH_FIND_INT(prefixes, &s, entry);
        if (entry == NULL) {
            entry = malloc(sizeof(HashEntry));
            entry->id = s;
            HASH_ADD_INT(prefixes, id, entry);
        }
        entry->pos = i;
    }

    HASH_ITER(hh, prefixes, entry, tmp) {
        HASH_DEL(prefixes, entry);
        free(entry);
    }
    return ans == n + 1 ? -1 : ans;
}
```

```JavaScript
var minSumOfLengths = function(arr, target) {
    const pos = new Map([[0, -1]]);
    const n = arr.length;
    let s = 0, ans = n + 1, minL = n;
    for (let i = 0; i < n; i++) {
        s += arr[i];
        if (pos.has(s - target)) {
            const j = pos.get(s - target), length = i - j;
            ans = Math.min(ans, length + (j === -1 ? n : arr[j]));
            minL = Math.min(minL, length);
        }
        arr[i] = minL;
        pos.set(s, i);
    }
    return ans === n + 1 ? -1 : ans;
};
```

```TypeScript
function minSumOfLengths(arr: number[], target: number): number {
    const pos = new Map<number, number>([[0, -1]]);
    const n = arr.length;
    let s = 0, ans = n + 1, minL = n;
    for (let i = 0; i < n; i++) {
        s += arr[i];
        if (pos.has(s - target)) {
            const j = pos.get(s - target)!;
            const length = i - j;
            ans = Math.min(ans, length + (j === -1 ? n : arr[j]));
            minL = Math.min(minL, length);
        }
        arr[i] = minL;
        pos.set(s, i);
    }
    return ans === n + 1 ? -1 : ans;
}
```

```Rust
impl Solution {
    pub fn min_sum_of_lengths(mut arr: Vec<i32>, target: i32) -> i32 {
        let n = arr.len();
        let mut pos = std::collections::HashMap::new();
        pos.insert(0, -1i32);
        let (mut s, mut ans, mut min_l) = (0, (n + 1) as i32, n as i32);
        for i in 0..n {
            s += arr[i];
            if let Some(&j) = pos.get(&(s - target)) {
                let len = i as i32 - j;
                ans = ans.min(len + if j == -1 { n as i32 } else { arr[j as usize] });
                min_l = min_l.min(len);
            }
            arr[i] = min_l;
            pos.insert(s, i as i32);
        }
        if ans == (n + 1) as i32 { -1 } else { ans }
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是数组 $arr$ 的长度。只需要遍历数组一次。
- 空间复杂度：$O(n)$。哈希表需要 $O(n)$ 的空间。

#### 方法二：滑动窗口 $+$ 动态规划

**思路与算法**

我们可以使用滑动窗口替代前缀和来求解和为 $target$ 的子数组。具体来说，我们一直右移右边界来扩展窗口，直到窗口内的和大于 $target$，则右移左边界来缩小窗口。

由于滑动窗口需要用到前面的值，我们无法再像方法一一样将 $arr$ 数组作为 $dp$ 数组使用。

**实现**

```C++
class Solution {
public:
    int minSumOfLengths(vector<int>& arr, int target) {
        int n = arr.size();
        int ans = n + 1;
        int s = 0;
        vector<int> dp(n + 1, n);
        for (int l = 0, r = 0; r < n; r++) {
            s += arr[r];
            while (s > target) {
                s -= arr[l++];
            }
            dp[r + 1] = dp[r];
            if (s == target) {
                ans = min(ans, r - l + 1 + dp[l]);
                dp[r + 1] = min(dp[r], r - l + 1);
            }
        }
        return ans == n + 1 ? -1 : ans;
    }
};
```

```Java
class Solution {
    public int minSumOfLengths(int[] arr, int target) {
        int n = arr.length, ans = n + 1, sum = 0;
        int[] dp = new int[n + 1];
        Arrays.fill(dp, n);
        for (int l = 0, r = 0; r < n; r++) {
            sum += arr[r];
            while (sum > target) sum -= arr[l++];
            dp[r + 1] = dp[r];
            if (sum == target) {
                ans = Math.min(ans, r - l + 1 + dp[l]);
                dp[r + 1] = Math.min(dp[r], r - l + 1);
            }
        }
        return ans == n + 1 ? -1 : ans;
    }
}
```

```Python
class Solution:
    def minSumOfLengths(self, arr: List[int], target: int) -> int:
        n, ans, total = len(arr), len(arr) + 1, 0
        dp = [n] * (n + 1)
        left = 0
        for right, x in enumerate(arr):
            total += x
            while total > target:
                total -= arr[left]
                left += 1
            dp[right + 1] = dp[right]
            if total == target:
                ans = min(ans, right - left + 1 + dp[left])
                dp[right + 1] = min(dp[right], right - left + 1)
        return -1 if ans == n + 1 else ans
```

```Go
func minSumOfLengths(arr []int, target int) int {
    n, ans, sum := len(arr), len(arr)+1, 0
    dp := make([]int, n+1)
    for i := range dp { dp[i] = n }
    left := 0
    for right, x := range arr {
        sum += x
        for sum > target { sum -= arr[left]; left++ }
        dp[right+1] = dp[right]
        if sum == target {
            length := right - left + 1
            if length+dp[left] < ans { ans = length + dp[left] }
            if length < dp[right+1] { dp[right+1] = length }
        }
    }
    if ans == n+1 { return -1 }
    return ans
}
```

```CSharp
public class Solution {
    public int MinSumOfLengths(int[] arr, int target) {
        int n = arr.Length, ans = n + 1, sum = 0, left = 0;
        int[] dp = Enumerable.Repeat(n, n + 1).ToArray();
        for (int right = 0; right < n; right++) {
            sum += arr[right];
            while (sum > target) sum -= arr[left++];
            dp[right + 1] = dp[right];
            if (sum == target) {
                int length = right - left + 1;
                ans = Math.Min(ans, length + dp[left]);
                dp[right + 1] = Math.Min(dp[right], length);
            }
        }
        return ans == n + 1 ? -1 : ans;
    }
}
```

```C
int minSumOfLengths(int* arr, int arrSize, int target) {
    int n = arrSize, ans = n + 1, sum = 0, left = 0;
    int *dp = malloc((n + 1) * sizeof(int));
    for (int i = 0; i <= n; i++) dp[i] = n;
    for (int right = 0; right < n; right++) {
        sum += arr[right];
        while (sum > target) sum -= arr[left++];
        dp[right + 1] = dp[right];
        if (sum == target) {
            int length = right - left + 1;
            if (length + dp[left] < ans) ans = length + dp[left];
            if (length < dp[right + 1]) dp[right + 1] = length;
        }
    }
    free(dp);
    return ans == n + 1 ? -1 : ans;
}
```

```JavaScript
var minSumOfLengths = function(arr, target) {
    const n = arr.length;
    let ans = n + 1, sum = 0, left = 0;
    const dp = Array(n + 1).fill(n);
    for (let right = 0; right < n; right++) {
        sum += arr[right];
        while (sum > target) sum -= arr[left++];
        dp[right + 1] = dp[right];
        if (sum === target) {
            const length = right - left + 1;
            ans = Math.min(ans, length + dp[left]);
            dp[right + 1] = Math.min(dp[right], length);
        }
    }
    return ans === n + 1 ? -1 : ans;
};
```

```TypeScript
function minSumOfLengths(arr: number[], target: number): number {
    const n = arr.length;
    let ans = n + 1, sum = 0, left = 0;
    const dp = Array(n + 1).fill(n) as number[];
    for (let right = 0; right < n; right++) {
        sum += arr[right];
        while (sum > target) sum -= arr[left++];
        dp[right + 1] = dp[right];
        if (sum === target) {
            const length = right - left + 1;
            ans = Math.min(ans, length + dp[left]);
            dp[right + 1] = Math.min(dp[right], length);
        }
    }
    return ans === n + 1 ? -1 : ans;
}
```

```Rust
impl Solution {
    pub fn min_sum_of_lengths(arr: Vec<i32>, target: i32) -> i32 {
        let n = arr.len();
        let (mut ans, mut sum, mut left) = ((n + 1) as i32, 0, 0usize);
        let mut dp = vec![n as i32; n + 1];
        for right in 0..n {
            sum += arr[right];
            while sum > target { sum -= arr[left]; left += 1; }
            dp[right + 1] = dp[right];
            if sum == target {
                let len = right - left + 1;
                ans = ans.min(len as i32 + dp[left]);
                dp[right + 1] = dp[right].min(len as i32);
            }
        }
        if ans == (n + 1) as i32 { -1 } else { ans }
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$。在遍历一次 $arr$ 的过程中进行滑动窗口和动态规划。
- 空间复杂度：$O(n)$。dp 数组需要 $O(n)$ 空间。
