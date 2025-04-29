### [统计最大元素出现至少 K 次的子数组](https://leetcode.cn/problems/count-subarrays-where-max-element-appears-at-least-k-times/solutions/3652653/tong-ji-zui-da-yuan-su-chu-xian-zhi-shao-348l/)

#### 方法一：滑动窗口 + 乘法原理

**思路与算法**

令 $mx$ 表示 $nums$ 中的最大元素，题目要求我们统计有多少个子数组包含至少 $k$ 个 $mx$。

不难发现，如果一个子数组包含至少 $k$ 个 $mx$，那么所有包含这个子数组的子数组都包含至少 $k$ 个 $mx$。我们可以使用滑动窗口来求解这个问题。

我们使用 $pos[i]$ 表示第 $i$ 个 $mx$ 出现的位置，两个指针 $left$ 和 $right$ 表示 $pos$ 上的滑动窗口。对于每一个 $left$，可以得到 $right=left+k-1$，即滑动窗口中存在 $k$ 个 $mx$。

通过确保每个滑动窗口对答案的贡献互相独立，我们就可以使用乘法原理来统计答案。具体来说，左端点位于 $(pos[left-1],pos[left]]$，右端点位于 $[pos[right],n]$ 的子数组都属于我们当前统计的滑动窗口的贡献，即为 $(pos[left]-pos[left-1]) \times (n-pos[right])$。

**代码**

```C++
class Solution {
public:
    long long countSubarrays(vector<int>& nums, int k) {
        int n = nums.size();
        int mx = *max_element(nums.begin(), nums.end());
        vector<long long> pos{-1};
        for (int i = 0; i < n; i++) {
            if (nums[i] == mx) {
                pos.push_back(i);
            }
        }
        int left = 1, right = k;
        long long ans = 0;
        while (right < pos.size()) {
            ans += (pos[left] - pos[left - 1]) * (n - pos[right]);
            left++, right++;
        }
        return ans;
    }
};
```

```Python
class Solution:
    def countSubarrays(self, nums: List[int], k: int) -> int:
        n = len(nums)
        mx = max(nums)
        pos = [-1]
        for i in range(n):
            if nums[i] == mx:
                pos.append(i)
        left, right = 1, k
        ans = 0
        while right < len(pos):
            ans += (pos[left] - pos[left - 1]) * (n - pos[right])
            left += 1
            right += 1
        return ans

```

```Java
class Solution {
    public long countSubarrays(int[] nums, int k) {
        int n = nums.length;
        int mx = Arrays.stream(nums).max().getAsInt();
        List<Integer> pos = new ArrayList<>();
        pos.add(-1);
        for (int i = 0; i < n; i++) {
            if (nums[i] == mx) {
                pos.add(i);
            }
        }
        int left = 1, right = k;
        long ans = 0;
        while (right < pos.size()) {
            ans += (long)(pos.get(left) - pos.get(left - 1)) * (n - pos.get(right));
            left++;
            right++;
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public long CountSubarrays(int[] nums, int k) {
        int n = nums.Length;
        int mx = nums.Max();
        List<int> pos = new List<int> { -1 };
        for (int i = 0; i < n; i++) {
            if (nums[i] == mx) {
                pos.Add(i);
            }
        }
        int left = 1, right = k;
        long ans = 0;
        while (right < pos.Count) {
            ans += (long)(pos[left] - pos[left - 1]) * (n - pos[right]);
            left++;
            right++;
        }
        return ans;
    }
}
```

```Go
func countSubarrays(nums []int, k int) int64 {
    n := len(nums)
    mx := nums[0]
    for _, v := range nums {
        if v > mx {
            mx = v
        }
    }
    pos := []int{-1}
    for i, v := range nums {
        if v == mx {
            pos = append(pos, i)
        }
    }
    left, right := 1, k
    var ans int64 = 0
    for right < len(pos) {
        ans += int64(pos[left]-pos[left-1]) * int64(n-pos[right])
        left++
        right++
    }
    return ans
}
```

```C
long long countSubarrays(int* nums, int n, int k) {
    int mx = INT_MIN;
    for (int i = 0; i < n; i++) {
        if (nums[i] > mx) {
            mx = nums[i];
        }
    }

    int pos[100005];
    int pSize = 0;
    pos[pSize++] = -1;
    for (int i = 0; i < n; i++) {
        if (nums[i] == mx) {
            pos[pSize++] = i;
        }
    }

    int left = 1, right = k;
    long long ans = 0;
    while (right < pSize) {
        ans += (long long)(pos[left] - pos[left - 1]) * (n - pos[right]);
        left++;
        right++;
    }

    return ans;
}
```

```JavaScript
var countSubarrays = function(nums, k) {
    const n = nums.length;
    const mx = Math.max(...nums);
    const pos = [-1];
    for (let i = 0; i < n; i++) {
        if (nums[i] === mx) {
            pos.push(i);
        }
    }
    let left = 1, right = k;
    let ans = 0;
    while (right < pos.length) {
        ans += (pos[left] - pos[left - 1]) * (n - pos[right]);
        left++;
        right++;
    }
    return ans;
};
```

```TypeScript
function countSubarrays(nums: number[], k: number): number {
    const n = nums.length;
    const mx = Math.max(...nums);
    const pos: number[] = [-1];
    for (let i = 0; i < n; i++) {
        if (nums[i] === mx) {
            pos.push(i);
        }
    }
    let left = 1, right = k;
    let ans = 0;
    while (right < pos.length) {
        ans += (pos[left] - pos[left - 1]) * (n - pos[right]);
        left++;
        right++;
    }
    return ans;
}
```

```Rust
impl Solution {
    pub fn count_subarrays(nums: Vec<i32>, k: i32) -> i64 {
        let n = nums.len();
        let mx = *nums.iter().max().unwrap();
        let mut pos = vec![-1];
        for (i, &v) in nums.iter().enumerate() {
            if v == mx {
                pos.push(i as i32);
            }
        }
        let mut left = 1;
        let mut right = k as usize;
        let mut ans: i64 = 0;
        while right < pos.len() {
            ans += (pos[left] - pos[left - 1]) as i64 * (n as i32 - pos[right]) as i64;
            left += 1;
            right += 1;
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是 $nums$ 的长度。先遍历一次数组找到所有 $mx$ 出现的位置，再遍历一次数组来计数所有满足条件的子数组。
- 空间复杂度：$O(n)$。我们需要保存所有 $mx$ 出现的位置。

#### 方法二：滑动窗口

**思路与算法**

我们使用两个指针 $left$ 和 $right$ 表示 $nums$ 上的滑动窗口，并且使用 $cnt$ 计数滑动窗口中 $mx$ 的数量。首先，我们不断右移 $right$，直到 $cnt=k$。然后，我们右移 $left$，同时更新 $cnt$ 的数量，直到 $cnt<k$。那么，在左指针移动过程中，滑动窗口的所有子数组，即右端点为 $right$ 且左端点小于 $left$ 的子数组，都包含至少 $k$ 个 $mx$，因此我们可以把答案增加 $left$。我们重复这个过程，直到 $right$ 到达数组的末尾。

对于任一时刻的 $right$，当我们右移 $left$ 直到 $cnt<k$ 时，$\\{[i,r]|0\\leq i<k\\$ 的所有子数组都满足条件，因此对于每一个 $right$，都会对答案贡献 $left$。

**代码**

```C++
class Solution {
public:
    long long countSubarrays(vector<int>& nums, int k) {
        int mx = *max_element(nums.begin(), nums.end());
        long long ans = 0;
        int cnt = 0, left = 0;
        for (int x : nums) {
            if (x == mx) {
                cnt++;
            }
            while (cnt == k) {
                if (nums[left] == mx) {
                    cnt--;
                }
                left++;
            }
            ans += left;
        }
        return ans;
    }
};
```

```Python
class Solution:
    def countSubarrays(self, nums: List[int], k: int) -> int:
        mx = max(nums)
        ans = 0
        cnt = 0
        left = 0
        for x in nums:
            if x == mx:
                cnt += 1
            while cnt == k:
                if nums[left] == mx:
                    cnt -= 1
                left += 1
            ans += left
        return ans

```

```Java
class Solution {
    public long countSubarrays(int[] nums, int k) {
        int mx = Arrays.stream(nums).max().getAsInt();
        long ans = 0;
        int cnt = 0, left = 0;
        for (int x : nums) {
            if (x == mx) {
                cnt++;
            }
            while (cnt == k) {
                if (nums[left] == mx) {
                    cnt--;
                }
                left++;
            }
            ans += left;
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public long CountSubarrays(int[] nums, int k) {
        int mx = nums.Max();
        long ans = 0;
        int cnt = 0, left = 0;
        foreach (int x in nums) {
            if (x == mx) {
                cnt++;
            }
            while (cnt == k) {
                if (nums[left] == mx) {
                    cnt--;
                }
                left++;
            }
            ans += left;
        }
        return ans;
    }
}
```

```Go
func countSubarrays(nums []int, k int) int64 {
    mx := nums[0]
    for _, v := range nums {
        if v > mx {
            mx = v
        }
    }
    var ans int64 = 0
    cnt := 0
    left := 0
    for _, x := range nums {
        if x == mx {
            cnt++
        }
        for cnt == k {
            if nums[left] == mx {
                cnt--
            }
            left++
        }
        ans += int64(left)
    }
    return ans
}
```

```C
long long countSubarrays(int* nums, int n, int k) {
    int mx = INT_MIN;
    for (int i = 0; i < n; i++) {
        if (nums[i] > mx) {
            mx = nums[i];
        }
    }
    long long ans = 0;
    int cnt = 0, left = 0;
    for (int right = 0; right < n; right++) {
        if (nums[right] == mx) {
            cnt++;
        }
        while (cnt == k) {
            if (nums[left] == mx) {
                cnt--;
            }
            left++;
        }
        ans += left;
    }
    return ans;
}
```

```JavaScript
var countSubarrays = function(nums, k) {
    const mx = Math.max(...nums);
    let ans = 0, cnt = 0, left = 0;
    for (const x of nums) {
        if (x === mx) {
            cnt++;
        }
        while (cnt === k) {
            if (nums[left] === mx) {
                cnt--;
            }
            left++;
        }
        ans += left;
    }
    return ans;
};
```

```TypeScript
function countSubarrays(nums: number[], k: number): number {
    const mx = Math.max(...nums);
    let ans = 0, cnt = 0, left = 0;
    for (const x of nums) {
        if (x === mx) {
            cnt++;
        }
        while (cnt === k) {
            if (nums[left] === mx) {
                cnt--;
            }
            left++;
        }
        ans += left;
    }
    return ans;
}
```

```Rust
impl Solution {
    pub fn count_subarrays(nums: Vec<i32>, k: i32) -> i64 {
        let mx = *nums.iter().max().unwrap();
        let mut ans: i64 = 0;
        let mut cnt = 0;
        let mut left = 0;

        for &x in &nums {
            if x == mx {
                cnt += 1;
            }
            while cnt == k {
                if nums[left] == mx {
                    cnt -= 1;
                }
                left += 1;
            }
            ans += left as i64;
        }

        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是 $nums$ 的长度。只需要遍历一次数组即可计数所有满足条件的子数组。
- 空间复杂度：$O(1)$。
