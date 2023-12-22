### [最长递增子序列](https://leetcode.cn/problems/minimum-number-of-removals-to-make-mountain-array/solutions/2570598/zui-chang-di-zeng-zi-xu-lie-by-leetcode-2ipno/)

#### 前言

根据题目的要求，我们需要使用**最少**的删除次数，使得给定的数组 $nums$ 成为「山形状数组」。这等价于，我们需要找出数组 $nums$ 的一个**最长**的子序列，并且这个子序列是一个「山形状数组」。

因此，我们可以考虑枚举「山形状数组」的最高点。记数组 $nums$ 的长度为 $n$，并且枚举第 $i$ 个元素 $nums[i]$ 作为最高点，那么：

- $(1)$ 在数组的前缀部分 $nums[0 .. i]$，找出一个严格递增的子序列，并且以 $nums[i]$ 结束，对应着「山形状数组」的上升部分；
- $(2)$ 在数组的后缀部分 $nums[i .. n-1]$，找出一个严格递减的子序列，并且以 $nums[i]$ 开始，对应着「山形状数组」的下降部分。

由于我们需要找出最长的「山形状数组」，并且 $nums[0 .. i]$ 和 $nums[i .. n-1]$ 这两部分是互相独立的，那么我们只需要找出 $nums[0 .. i]$ 中以 $nums[i]$ 结束的最长严格递增子序列，以及 $nums[i .. n-1]$ 中以 $nums[i]$ 开始的最长严格递减子序列即可。

求解最长严格递增/递减子序列是一个非常经典的问题，读者可以参考「[300. 最长递增子序列](https://leetcode.cn/problems/longest-increasing-subsequence/description/)」，在 $O(n^2)$ 或者 $O(n \log n)$ 的时间内求出给定数组中，以每一个元素结尾的最长严格递增子序列的长度。

对于严格递减子序列的部分，我们可以把数组 $nums$ 进行反转，这样就从求解后缀的最长严格递减子序列，变成求解前缀的最长严格递增子序列了。

记 $pre[i]$ 和 $suf[i]$ 分别表示上文 $(1)$ 和 $(2)$ 中找出的最长子序列的长度，只要 $pre[i]$ 和 $suf[i]$ 均大于 $1$，就可以拼接成一个以 $nums[i]$ 为最高点的「山形状数组」，长度为 $L = pre[i] + suf[i] - 1$，需要的删除次数为 $n - L$。

下面给出的两种方法与「300. 最长递增子序列」的[官方题解](https://leetcode.cn/problems/longest-increasing-subsequence/solutions/147667/zui-chang-shang-sheng-zi-xu-lie-by-leetcode-soluti/)中的两种方法一致：将其中的代码封装成函数 $getLISArray$，用于求解所有的 $pre[i]$ 和 $suf[i]$，并枚举 $i$ 以得出最终的答案。

#### 方法一：动态规划

##### 代码

```c++
class Solution {
public:
    int minimumMountainRemovals(vector<int>& nums) {
        int n = nums.size();
        vector<int> pre = getLISArray(nums);
        vector<int> suf = getLISArray({nums.rbegin(), nums.rend()});
        reverse(suf.begin(), suf.end());

        int ans = 0;
        for (int i = 0; i < n; ++i) {
            if (pre[i] > 1 && suf[i] > 1) {
                ans = max(ans, pre[i] + suf[i] - 1);
            }
        }

        return n - ans;
    }

    vector<int> getLISArray(const vector<int>& nums) {
        int n = nums.size();
        vector<int> dp(n, 1);
        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < i; ++j) {
                if (nums[j] < nums[i]) {
                    dp[i] = max(dp[i], dp[j] + 1);
                }
            }
        }
        return dp;
    }
};
```

```java
class Solution {
    public int minimumMountainRemovals(int[] nums) {
        int n = nums.length;
        int[] pre = getLISArray(nums);
        int[] reversed = reverse(nums);
        int[] suf = getLISArray(reversed);
        suf = reverse(suf);

        int ans = 0;
        for (int i = 0; i < n; ++i) {
            if (pre[i] > 1 && suf[i] > 1) {
                ans = Math.max(ans, pre[i] + suf[i] - 1);
            }
        }

        return n - ans;
    }

    public int[] getLISArray(int[] nums) {
        int n = nums.length;
        int[] dp = new int[n];
        Arrays.fill(dp, 1);
        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < i; ++j) {
                if (nums[j] < nums[i]) {
                    dp[i] = Math.max(dp[i], dp[j] + 1);
                }
            }
        }
        return dp;
    }

    public int[] reverse(int[] nums) {
        int n = nums.length;
        int[] reversed = new int[n];
        for (int i = 0; i < n; i++) {
            reversed[i] = nums[n - 1 - i];
        }
        return reversed;
    }
}
```

```csharp
public class Solution {
    public int MinimumMountainRemovals(int[] nums) {
        int n = nums.Length;
        int[] pre = GetLISArray(nums);
        int[] reversed = Reverse(nums);
        int[] suf = GetLISArray(reversed);
        suf = Reverse(suf);

        int ans = 0;
        for (int i = 0; i < n; ++i) {
            if (pre[i] > 1 && suf[i] > 1) {
                ans = Math.Max(ans, pre[i] + suf[i] - 1);
            }
        }

        return n - ans;
    }

    public int[] GetLISArray(int[] nums) {
        int n = nums.Length;
        int[] dp = new int[n];
        Array.Fill(dp, 1);
        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < i; ++j) {
                if (nums[j] < nums[i]) {
                    dp[i] = Math.Max(dp[i], dp[j] + 1);
                }
            }
        }
        return dp;
    }

    public int[] Reverse(int[] nums) {
        int n = nums.Length;
        int[] reversed = new int[n];
        for (int i = 0; i < n; i++) {
            reversed[i] = nums[n - 1 - i];
        }
        return reversed;
    }
}
```

```python
class Solution:
    def minimumMountainRemovals(self, nums: List[int]) -> int:
        pre = self.getLISArray(nums)
        suf = self.getLISArray(nums[::-1])[::-1]
        ans = 0

        for pre_i, suf_i in zip(pre, suf):
            if pre_i > 1 and suf_i > 1:
                ans = max(ans, pre_i + suf_i - 1)
        
        return len(nums) - ans

    def getLISArray(self, nums: List[int]) -> List[int]:
        n = len(nums)
        dp = [1] * n

        for i in range(n):
            for j in range(i):
                if nums[j] < nums[i]:
                    dp[i] = max(dp[i], dp[j] + 1)

        return dp
```

```go
func minimumMountainRemovals(nums []int) int {
    n := len(nums)
    pre := getLISArray(nums)
    suf := getLISArray(reversed(nums))
    suf = reversed(suf)

    ans := 0
    for i := 0; i < n; i++ {
        if pre[i] > 1 && suf[i] > 1 {
            ans = max(ans, pre[i] + suf[i] - 1)
        }
    }
    return n - ans
}

func getLISArray(nums []int) []int {
    n := len(nums)
    dp := make([]int, n)
    for i := 0; i < n; i++ {
        dp[i] = 1
        for j := 0; j < i; j++ {
            if nums[j] < nums[i] {
                dp[i] = max(dp[i], dp[j] + 1)
            }
        }
    }
    return dp
}

func reversed(nums []int) []int {
    n := len(nums)
    ans := make([]int, n)
    for i := 0; i < n; i++ {
        ans[i] = nums[n - 1 - i]
    }
    return ans
}
```

```c
int *getLISArray(const int* nums, int numsSize) {
    int *dp = (int *)malloc(sizeof(int) * numsSize);
    for (int i = 0; i < numsSize; i++) {
        dp[i] = 1;
    }
    for (int i = 0; i < numsSize; ++i) {
        for (int j = 0; j < i; ++j) {
            if (nums[j] < nums[i]) {
                dp[i] = fmax(dp[i], dp[j] + 1);
            }
        }
    }
    return dp;
}

void reverse(int *nums, int numsSize) {
    for (int i = 0, j = numsSize - 1; i < j; i++, j--) {
        int tmp = nums[i];
        nums[i] = nums[j];
        nums[j] = tmp;
    }
}

int minimumMountainRemovals(int* nums, int numsSize) {
    int n = numsSize;
    int *pre = getLISArray(nums, numsSize);
    reverse(nums, numsSize);
    int *suf = getLISArray(nums, numsSize);
    reverse(suf, numsSize);

    int ans = 0;
    for (int i = 0; i < n; ++i) {
        if (pre[i] > 1 && suf[i] > 1) {
            ans = fmax(ans, pre[i] + suf[i] - 1);
        }
    }
    free(pre);
    free(suf);
    return n - ans;
}
```

```javascript
var minimumMountainRemovals = function(nums) {
    const n = nums.length;
    const pre = getLISArray(nums)
    let suf = getLISArray(nums.reverse());
    suf.reverse();

    let ans = 0;
    for (let i = 0; i < n; ++i) {
        if (pre[i] > 1 && suf[i] > 1) {
            ans = Math.max(ans, pre[i] + suf[i] - 1);
        }
    }

    return n - ans;
};

var getLISArray = function(nums) {
    const n = nums.length;
    const dp = new Array(n).fill(1);
    for (let i = 0; i < n; ++i) {
        for (let j = 0; j < i; ++j) {
            if (nums[j] < nums[i]) {
                dp[i] = Math.max(dp[i], dp[j] + 1);
            }
        }
    }
    return dp;
}
```

#### 复杂度分析

- 时间复杂度：$O(n^2)$，其中 $n$ 是数组 $nums$ 的长度。
- 空间复杂度：$O(n)$。

#### 方法二：二分查找

##### 代码

```c++
class Solution {
public:
    int minimumMountainRemovals(vector<int>& nums) {
        int n = nums.size();
        vector<int> pre = getLISArray(nums);
        vector<int> suf = getLISArray({nums.rbegin(), nums.rend()});
        reverse(suf.begin(), suf.end());

        int ans = 0;
        for (int i = 0; i < n; ++i) {
            if (pre[i] > 1 && suf[i] > 1) {
                ans = max(ans, pre[i] + suf[i] - 1);
            }
        }

        return n - ans;
    }

    vector<int> getLISArray(const vector<int>& nums) {
        int n = nums.size();
        vector<int> dp(n), seq;
        for (int i = 0; i < n; ++i) {
            auto it = lower_bound(seq.begin(), seq.end(), nums[i]);
            if (it == seq.end()) {
                seq.push_back(nums[i]);
                dp[i] = seq.size();
            }
            else {
                *it = nums[i];
                dp[i] = it - seq.begin() + 1;
            }
        }
        return dp;
    }
};
```

```java
class Solution {
    public int minimumMountainRemovals(int[] nums) {
        int n = nums.length;
        int[] pre = getLISArray(nums);
        int[] reversed = reverse(nums);
        int[] suf = getLISArray(reversed);
        suf = reverse(suf);

        int ans = 0;
        for (int i = 0; i < n; ++i) {
            if (pre[i] > 1 && suf[i] > 1) {
                ans = Math.max(ans, pre[i] + suf[i] - 1);
            }
        }

        return n - ans;
    }

    public int[] getLISArray(int[] nums) {
        int n = nums.length;
        int[] dp = new int[n];
        List<Integer> seq = new ArrayList<Integer>();
        for (int i = 0; i < n; ++i) {
            int index = binarySearch(seq, nums[i]);
            if (index == seq.size()) {
                seq.add(nums[i]);
                dp[i] = seq.size();
            } else {
                seq.set(index, nums[i]);
                dp[i] = index + 1;
            }
        }
        return dp;
    }

    public int[] reverse(int[] nums) {
        int n = nums.length;
        int[] reversed = new int[n];
        for (int i = 0; i < n; i++) {
            reversed[i] = nums[n - 1 - i];
        }
        return reversed;
    }

    public int binarySearch(List<Integer> seq, int target) {
        int low = 0, high = seq.size();
        while (low < high) {
            int mid = low + (high - low) / 2;
            if (seq.get(mid) >= target) {
                high = mid;
            } else {
                low = mid + 1;
            }
        }
        return low;
    }
}
```

```csharp
public class Solution {
    public int MinimumMountainRemovals(int[] nums) {
        int n = nums.Length;
        int[] pre = GetLISArray(nums);
        int[] reversed = Reverse(nums);
        int[] suf = GetLISArray(reversed);
        suf = Reverse(suf);

        int ans = 0;
        for (int i = 0; i < n; ++i) {
            if (pre[i] > 1 && suf[i] > 1) {
                ans = Math.Max(ans, pre[i] + suf[i] - 1);
            }
        }

        return n - ans;
    }

    public int[] GetLISArray(int[] nums) {
        int n = nums.Length;
        int[] dp = new int[n];
        IList<int> seq = new List<int>();
        for (int i = 0; i < n; ++i) {
            int index = BinarySearch(seq, nums[i]);
            if (index == seq.Count) {
                seq.Add(nums[i]);
                dp[i] = seq.Count;
            } else {
                seq[index] = nums[i];
                dp[i] = index + 1;
            }
        }
        return dp;
    }

    public int[] Reverse(int[] nums) {
        int n = nums.Length;
        int[] reversed = new int[n];
        for (int i = 0; i < n; i++) {
            reversed[i] = nums[n - 1 - i];
        }
        return reversed;
    }

    public int BinarySearch(IList<int> seq, int target) {
        int low = 0, high = seq.Count;
        while (low < high) {
            int mid = low + (high - low) / 2;
            if (seq[mid] >= target) {
                high = mid;
            } else {
                low = mid + 1;
            }
        }
        return low;
    }
}
```

```python
class Solution:
    def minimumMountainRemovals(self, nums: List[int]) -> int:
        pre = self.getLISArray(nums)
        suf = self.getLISArray(nums[::-1])[::-1]
        ans = 0

        for pre_i, suf_i in zip(pre, suf):
            if pre_i > 1 and suf_i > 1:
                ans = max(ans, pre_i + suf_i - 1)
        
        return len(nums) - ans

    def getLISArray(self, nums: List[int]) -> List[int]:
        dp, seq = list(), list()

        for i, num in enumerate(nums):
            it = bisect_left(seq, num)
            if it == len(seq):
                seq.append(num)
                dp.append(len(seq))
            else:
                seq[it] = num
                dp.append(it + 1)

        return dp
```

```go
func minimumMountainRemovals(nums []int) int {
    n := len(nums)
    pre := getLISArray(nums)
    suf := getLISArray(reversed(nums))
    suf = reversed(suf)

    ans := 0
    for i := 0; i < n; i++ {
        if pre[i] > 1 && suf[i] > 1 {
            ans = max(ans, pre[i] + suf[i] - 1)
        }
    }
    return n - ans
}

func getLISArray(nums []int) []int {
    n := len(nums)
    dp := make([]int, n)
    var seq []int
    for i := 0; i < n; i++ {
        it := sort.SearchInts(seq, nums[i])
        if it == len(seq) {
            seq = append(seq, nums[i])
            dp[i] = len(seq)
        } else {
            seq[it] = nums[i]
            dp[i] = it + 1
        }
    }
    return dp
}

func reversed(nums []int) []int {
    n := len(nums)
    ans := make([]int, n)
    for i := 0; i < n; i++ {
        ans[i] = nums[n - 1 - i]
    }
    return ans
}
```

```c
int binarySearch(const int *seq, int seqSize, int target) {
    int low = 0, high = seqSize;
    while (low < high) {
        int mid = low + (high - low) / 2;
        if (seq[mid] >= target) {
            high = mid;
        } else {
            low = mid + 1;
        }
    }
    return low;
}

int *getLISArray(const int* nums, int numsSize) {
    int *dp = (int *)malloc(sizeof(int) * numsSize);
    for (int i = 0; i < numsSize; i++) {
        dp[i] = 1;
    }
    int seq[numsSize], pos = 0;
    for (int i = 0; i < numsSize; ++i) {
        int index = binarySearch(seq, pos, nums[i]);
        if (index == pos) {
            seq[pos++] = nums[i];
            dp[i] = pos;
        } else {
            seq[index] = nums[i];
            dp[i] = index + 1;
        }
    }
    return dp;
}

void reverse(int *nums, int numsSize) {
    for (int i = 0, j = numsSize - 1; i < j; i++, j--) {
        int tmp = nums[i];
        nums[i] = nums[j];
        nums[j] = tmp;
    }
}

int minimumMountainRemovals(int* nums, int numsSize) {
    int n = numsSize;
    int *pre = getLISArray(nums, numsSize);
    reverse(nums, numsSize);
    int *suf = getLISArray(nums, numsSize);
    reverse(suf, numsSize);

    int ans = 0;
    for (int i = 0; i < n; ++i) {
        if (pre[i] > 1 && suf[i] > 1) {
            ans = fmax(ans, pre[i] + suf[i] - 1);
        }
    }
    free(pre);
    free(suf);
    return n - ans;
}
```

```javascript
var minimumMountainRemovals = function(nums) {
    const n = nums.length;
    const pre = getLISArray(nums)
    let suf = getLISArray(nums.reverse());
    suf.reverse();

    let ans = 0;
    for (let i = 0; i < n; ++i) {
        if (pre[i] > 1 && suf[i] > 1) {
            ans = Math.max(ans, pre[i] + suf[i] - 1);
        }
    }

    return n - ans;
};

var getLISArray = function(nums) {
    const n = nums.length;
    const dp = new Array(n).fill(1);
    const seq = new Array();
    for (let i = 0; i < n; ++i) {
        let index = binarySearch(seq, nums[i]);
        if (index == seq.length) {
            seq.push(nums[i]);
            dp[i] = seq.length;
        } else {
            seq[index] = nums[i];
            dp[i] = index + 1;
        }
    }
    console.log(dp);
    return dp;
}

var binarySearch = function(seq, target) {
    let low = 0, high = seq.length;
    while (low < high) {
        let mid = low + Math.floor((high - low) / 2);
        if (seq[mid] >= target) {
            high = mid;
        } else {
            low = mid + 1;
        }
    }
    return low;
} 
```

#### 复杂度分析

- 时间复杂度：$O(n \log n)$，其中 $n$ 是数组 $nums$ 的长度。
- 空间复杂度：$O(n)$。
