### [两个线段获得的最多奖品](https://leetcode.cn/problems/maximize-win-from-two-segments/solutions/2909094/liang-ge-xian-duan-huo-de-de-zui-duo-jia-24uu/)

#### 方法一：二分查找

**思路与算法**

由于题目给定的数组按照非递减排序，且数组中第 $i$ 个元素表示第 $i$ 个奖品的坐标位置（位置可以重复），可以选择长度为 $k$ 两个线段，求两个线段可以覆盖奖品的最大数量。当然根据贪心法则，肯定是这两个线段尽量不要有重叠部分，这样才能使得覆盖的奖品数量尽可能的多。此时我们假设第二条线段的右侧刚好覆盖第 $i$ 个奖品所在的位置，第二条线段的左侧刚好覆盖第 $j$ 个奖品所在的位置，此时第一条线段右端点一定刚好处于第 $j-1,j-2, \cdots ,0$ 个礼物的位置，即两条线段不存在重叠部分这样才能保证覆盖的奖品尽可能的多。

假设我们知道第二条线段覆盖的右端点刚好为 $prizePositions[i]$，此时由于线段长度为 $k$，则此时该线段左端点为 $prizePositions[i]-k$，由于每个奖品的位置坐标已排序，此时可以通过二分找到最左侧可以覆盖的奖品为 $prizePositions[j]$，此时只需知道位于 $prizePositions[j]$ 左侧的第一条线段可以覆盖奖品奖品的最大数量，即可知道以 $prizePositions[i]$ 为第二条线段右端点时可以覆盖奖品的最大数量，依次枚举第二条线段的右端点即可知道全局最优解。

我们用 $dp[i]$ 表示右端点不超过 $prizePositions[i]$，一条长度为 $k$ 的线段最多可以覆盖的奖品的最大数量，可以推导如下：

- 如果不选择位于 $prizePositions[i]$ 处的奖品，则 $dp[i]=dp[i-1]$；
- 如果选择位于 $prizePositions[i]$ 处的奖品，则通过二分查找找到线段最左侧可以覆盖的奖品位置 $prizePositions[j]$，则此时 $dp[i]=i-j+1$；
- 我们取二者的最大值，可以得到动态规划递推公式如下：
    $dp[i]=max(dp[i-1],i-j+1)$

我们依次枚举第二条线段的最右侧端点 $prizePositions[i]$，此时第二条线段覆盖最左侧的奖品为 $prizePositions[j]$，则此时最多可以覆盖的奖品数量为：

$$i-j+1+dp[j-1]$$

此时 $dp[j-1]$ 表示第一条线段右端点不超过 $prizePositions[j-1]$ 时最多可以覆盖的奖品数量。枚举过程中取最大值即为最终结果，返回即可。

**代码**

```C++
class Solution {
public:
    int maximizeWin(vector<int>& prizePositions, int k) {
        int n = prizePositions.size();
        vector<int> dp(n + 1);
        int ans = 0;
        for (int i = 0; i < n; i++) {
            int x = lower_bound(prizePositions.begin(), prizePositions.end(), prizePositions[i] - k) - prizePositions.begin();
            ans = max(ans, i - x + 1 + dp[x]);
            dp[i + 1] = max(dp[i], i - x + 1);
        }
        return ans;
    }
};
```

```Java
class Solution {
    public long minEnd(int n, int x) {
        int bitCount = 128 - Long.numberOfLeadingZeros(n) - Long.numberOfLeadingZeros(x);
        long res = x;
        long m = n - 1;
        int j = 0;
        for (int i = 0; i < bitCount; ++i) {
            if (((res >> i) & 1) == 0) {
                if (((m >> j) & 1) == 1) {
                    res |= (1L << i);
                }
                j++;
            }
        }
        return res;
    }
}
```

```Go
func maximizeWin(prizePositions []int, k int) int {
    n := len(prizePositions)
    dp := make([]int, n+1)
    ans := 0
    for i := 0; i < n; i++ {
        x := sort.SearchInts(prizePositions, prizePositions[i]-k)
        ans = max(ans, i - x + 1 + dp[x])
        dp[i + 1] = max(dp[i], i - x + 1)
    }
    return ans
}
```

```Python
class Solution:
    def maximizeWin(self, prizePositions: List[int], k: int) -> int:
        n = len(prizePositions)
        dp = [0] * (n + 1)
        ans = 0
        for i in range(n):
            x = bisect.bisect_left(prizePositions, prizePositions[i] - k)
            ans = max(ans, i - x + 1 + dp[x])
            dp[i + 1] = max(dp[i], i - x + 1)
        return ans
```

```C
int lower_bound(int* arr, int size, int val) {
    int low = 0, high = size;
    while (low < high) {
        int mid = (low + high) / 2;
        if (arr[mid] < val) {
            low = mid + 1;
        } else {
            high = mid;
        }
    }
    return low;
}

int maximizeWin(int* prizePositions, int prizePositionsSize, int k) {
    int* dp = (int*)calloc(prizePositionsSize + 1, sizeof(int));
    int ans = 0;
    for (int i = 0; i < prizePositionsSize; i++) {
        int x = lower_bound(prizePositions, prizePositionsSize, prizePositions[i] - k);
        ans = fmax(ans, i - x + 1 + dp[x]);
        dp[i + 1] = fmax(dp[i], i - x + 1);
    }
    free(dp);
    return ans;
}
```

```JavaScript
var maximizeWin = function(prizePositions, k) {
    const n = prizePositions.length;
    const dp = new Array(n + 1).fill(0);
    let ans = 0;
    for (let i = 0; i < n; i++) {
        let x = binarySearch(prizePositions, prizePositions[i] - k);
        ans = Math.max(ans, i - x + 1 + dp[x]);
        dp[i + 1] = Math.max(dp[i], i - x + 1);
    }
    return ans;
};

const binarySearch = (arr, target) => {
    let left = 0;
    let right = arr.length - 1;
    while (left <= right) {
        let mid = Math.floor((left + right) / 2);
        if (arr[mid] < target) {
            left = mid + 1;
        } else {
            right = mid - 1;
        }
    }
    return left;
}
```

```TypeScript
function maximizeWin(prizePositions: number[], k: number): number {
    const n = prizePositions.length;
    const dp: number[] = new Array(n + 1).fill(0);
    let ans = 0;
    for (let i = 0; i < n; i++) {
        let x = binarySearch(prizePositions, prizePositions[i] - k);
        ans = Math.max(ans, i - x + 1 + dp[x]);
        dp[i + 1] = Math.max(dp[i], i - x + 1);
    }
    return ans;
};

const binarySearch = (arr: number[], target: number):number => {
    let left = 0;
    let right = arr.length - 1;
    while (left <= right) {
        let mid = Math.floor((left + right) / 2);
        if (arr[mid] < target) {
            left = mid + 1;
        } else {
            right = mid - 1;
        }
    }
    return left;
}
```

```Rust
impl Solution {
    pub fn maximize_win(prize_positions: Vec<i32>, k: i32) -> i32 {
        let n = prize_positions.len();
        let mut dp = vec![0; n + 1];
        let mut ans = 0;
        for i in 0..n {
            let x = Self::binarySearch(&prize_positions, prize_positions[i] - k);
            ans = ans.max(i as i32 - x as i32 + 1 + dp[x]);
            dp[i + 1] = dp[i].max(i as i32 - x as i32 + 1);
        }
        ans
    }

    fn binarySearch(arr: &Vec<i32>, target: i32) -> usize {
        let mut left = 0;
        let mut right = arr.len();
        while left < right {
            let mid = left + (right - left) / 2;
            if arr[mid] < target {
                left = mid + 1;
            } else {
                right = mid;
            }
        }
        left
    }
}
```

**复杂度分析**

- 时间复杂度：$O(nlogn)$，其中 $n$ 表示给定数组的长度。每次遍历时都需要进行二分查找，二分查找的时间复杂度为 $O(logn)$，一共需要进行 $n$ 次二分查找，需要的时间为 $O(nlogn)$。
- 空间复杂度：$O(n)$，其中 $n$ 表示给定数组的长度。需要存储每个取 $k$ 长度的最大值，需要的空间为 $O(n)$。

#### 方法二：双指针

**思路与算法**

根据解法一可以知道，两条线段不存在重叠部分一定可以保证最优解。同样的思路与方法我们可以使用双指针枚举第二条线段的右端点。

为了计算方便我们可以强制每条线段的左右端点刚好覆盖在某个奖品上，因为对于没有覆盖在奖品上的部分可以忽略。假设第二条线段覆盖的右端点刚好为 $prizePositions[right]$，设当前线段可以覆盖的最左侧奖品位置为 $prizePositions[left]$，由于线段长度为 $k$ 且奖品位置有序，此时一定满足 $prizePositions[right]-prizePositions[left] \le k$，此时第二条线段覆盖的奖品数量则为 $right-left+1$，若已知处于 $prizePositions[left]$ 左侧的线段可以覆盖奖品的最大数量，即可求出以 $prizePositions[right]$ 为第二条线段的右终点时可以覆盖的最大奖品数量。

设 $dp[right]$ 表示右端点不超过 $prizePositions[right]$ 的线段可以覆盖最大奖品数量，可以得到推论如下：

- 如果不选择位于 $prizePositions[right]$ 处的奖品，线段的右端点一定不超过 $prizePositions[right-1]$，当前可以覆盖奖品的最大数量即为：$dp[right-1]$，此时 $dp[right]=dp[right-1]$；
- 如果选择位于 $prizePositions[right]$ 处的奖品，由于线段长度为 $k$，需要移动左侧指针 $left$，使得满足 $prizePositions[right]-prizePositions[left] \le k$ 为止，当前可以覆盖的最大奖品数量即为：$right-left+1$，此时 $dp[right]=right-left+1$；
- 取二者的最大值即为右端点不超过 $prizePositions[right]$ 时，可以覆盖的最大奖品数量，递推公式如下：
$dp[right]=max(dp[right-1],right-left+1)$

依次枚举第二条线段的最右侧端点 $prizePositions[right]$，此时第二条线段覆盖最左侧的奖品为 $prizePositions[left]$，则此时最多可以覆盖的奖品数量为：

$$right-left+1+dp[left-1]$$

此时 $dp[left-1]$ 表示第一条线段右端点不超过 $prizePositions[left-1]$ 时最多可以覆盖的奖品数量。枚举过程中取最大值即为最终结果，返回即可。

**代码**

```C++
class Solution {
public:
    int maximizeWin(vector<int>& prizePositions, int k) {
        int n = prizePositions.size();
        vector<int> dp(n + 1);
        int ans = 0;
        for (int left = 0, right = 0; right < n; right++) {
            while (prizePositions[right] - prizePositions[left] > k) {
                left++;
            }
            ans = max(ans, right - left + 1 + dp[left]);
            dp[right + 1] = max(dp[right], right - left + 1);
        }
        return ans;
    }
};
```

```Java
class Solution {
    public int maximizeWin(int[] prizePositions, int k) {
        int n = prizePositions.length;
        int[] dp = new int[n + 1];
        int ans = 0;
        for (int left = 0, right = 0; right < n; right++) {
            while (prizePositions[right] - prizePositions[left] > k) {
                left++;
            }
            ans = Math.max(ans, right - left + 1 + dp[left]);
            dp[right + 1] = Math.max(dp[right], right - left + 1);
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public int MaximizeWin(int[] prizePositions, int k) {
        int n = prizePositions.Length;
        int[] dp = new int[n + 1];
        int ans = 0;
        for (int left = 0, right = 0; right < n; right++) {
            while (prizePositions[right] - prizePositions[left] > k) {
                left++;
            }
            ans = Math.Max(ans, right - left + 1 + dp[left]);
            dp[right + 1] = Math.Max(dp[right], right - left + 1);
        }
        return ans;
    }
}
```

```Go
func maximizeWin(prizePositions []int, k int) int {
    n := len(prizePositions)
    dp := make([]int, n+1)
    ans := 0
    for left, right := 0, 0; right < n; right++ {
        for prizePositions[right] - prizePositions[left] > k {
            left++
        }
        ans = max(ans, right - left + 1 + dp[left])
        dp[right+1] = max(dp[right], right - left + 1)
    }

    return ans
}
```

```Python
class Solution:
    def maximizeWin(self, prizePositions: List[int], k: int) -> int:
        n = len(prizePositions)
        dp = [0] * (n + 1)
        ans, left = 0, 0
        for right, x in enumerate(prizePositions):
            while x - prizePositions[left] > k:
                left += 1
            ans = max(ans, right - left + 1 + dp[left])
            dp[right + 1] = max(dp[right], right - left + 1)

        return ans
```

```C
int maximizeWin(int* prizePositions, int prizePositionsSize, int k) {
    int n = prizePositionsSize;
    int *dp = calloc(n + 1, sizeof(int));
    int ans = 0;
    for (int left = 0, right = 0; right < n; right++) {
        while (prizePositions[right] - prizePositions[left] > k) {
            left++;
        }
        ans = fmax(ans, right - left + 1 + dp[left]);
        dp[right + 1] = fmax(dp[right], right - left + 1);
    }
    return ans;
}
```

```JavaScript
var maximizeWin = function(prizePositions, k) {
    const n = prizePositions.length;
    const dp = new Array(n + 1).fill(0);
    let ans = 0;

    for (let left = 0, right = 0; right < n; right++) {
        while (prizePositions[right] - prizePositions[left] > k) {
            left++;
        }
        ans = Math.max(ans, right - left + 1 + dp[left]);
        dp[right + 1] = Math.max(dp[right], right - left + 1);
    }

    return ans;
};
```

```TypeScript
function maximizeWin(prizePositions: number[], k: number): number {
    const n = prizePositions.length;
    const dp = new Array(n + 1).fill(0);
    let ans = 0;

    for (let left = 0, right = 0; right < n; right++) {
        while (prizePositions[right] - prizePositions[left] > k) {
            left++;
        }
        ans = Math.max(ans, right - left + 1 + dp[left]);
        dp[right + 1] = Math.max(dp[right], right - left + 1);
    }
    return ans;
};
```

```Rust
impl Solution {
    pub fn maximize_win(prize_positions: Vec<i32>, k: i32) -> i32 {
        let n = prize_positions.len();
        let mut dp = vec![0; n + 1];
        let mut ans = 0;
        let mut left = 0;
        for right in 0..n {
            while prize_positions[right] - prize_positions[left] > k {
                left += 1;
            }
            ans = ans.max(right as i32 - left as i32 + 1 + dp[left]);
            dp[right + 1] = dp[right].max(right as i32 - left as i32 + 1);
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 表示给定数组的长度。双指针遍历需要的时间为 $O(n)$。
- 空间复杂度：$O(n)$，其中 $n$ 表示给定数组的长度。需要存储每个取 $k$ 长度的最大值，需要的空间为 $O(n)$。
