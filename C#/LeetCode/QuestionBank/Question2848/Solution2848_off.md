### [与车相交的点](https://leetcode.cn/problems/points-that-intersect-with-cars/solutions/2911873/yu-che-xiang-jiao-de-dian-by-leetcode-so-xlgq/)

#### 方法一：模拟

**思路与算法**

我们可以根据题目要求直接进行模拟。

首先遍历数组 $nums$ 得到坐标的最大值 $C$，然后使用一个数组 $count$ 表示每个坐标被覆盖的次数，它的下标范围是 $[1,C]$（大部分语言的数组下标都需要从 $0$ 开始，因此在代码中下标范围是 $[0,C]$）。

对于数组 $nums$ 中的每个元素 $(x,y)$，我们将数组 $count$ 中下标从 $x$ 到 $y$ 的元素均增加 $1$。最后数组 $count$ 中非零元素的数量即为答案。

**代码**

```C++
class Solution {
public:
    int numberOfPoints(vector<vector<int>>& nums) {
        int C = 0;
        for (const auto& interval: nums) {
            C = max(C, interval[1]);
        }

        vector<int> count(C + 1);
        for (const auto& interval: nums) {
            for (int i = interval[0]; i <= interval[1]; ++i) {
                ++count[i];
            }
        }

        int ans = 0;
        for (int i = 1; i <= C; ++i) {
            if (count[i]) {
                ++ans;
            }
        }
        return ans;
    }
};
```

```Java
class Solution {
    public int numberOfPoints(List<List<Integer>> nums) {
        int C = 0;
        for (List<Integer> interval : nums) {
            C = Math.max(C, interval.get(1));
        }

        int[] count = new int[C + 1];
        for (List<Integer> interval : nums) {
            for (int i = interval.get(0); i <= interval.get(1); ++i) {
                ++count[i];
            }
        }

        int ans = 0;
        for (int i = 1; i <= C; ++i) {
            if (count[i] > 0) {
                ++ans;
            }
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public int NumberOfPoints(IList<IList<int>> nums) {
        int C = 0;
        foreach (IList<int> interval in nums) {
            C = Math.Max(C, interval[1]);
        }

        int[] count = new int[C + 1];
        foreach (IList<int> interval in nums) {
            for (int i = interval[0]; i <= interval[1]; ++i) {
                ++count[i];
            }
        }

        int ans = 0;
        for (int i = 1; i <= C; ++i) {
            if (count[i] > 0) {
                ++ans;
            }
        }
        return ans;
    }
}
```

```Python
class Solution:
    def numberOfPoints(self, nums: List[List[int]]) -> int:
        C = max(y for _, y in nums)
        count = [0] * (C + 1)
        for x, y in nums:
            for i in range(x, y + 1):
                count[i] += 1
        
        ans = sum(1 for i in range(1, C + 1) if count[i] > 0)
        return ans
```

```Go
func numberOfPoints(nums [][]int) int {
    C := 0
    for _, interval := range nums {
        if interval[1] > C {
            C = interval[1]
        }
    }

    count := make([]int, C + 1)
    for _, interval := range nums {
        for i := interval[0]; i <= interval[1]; i++ {
            count[i]++
        }
    }

    ans := 0
    for i := 1; i <= C; i++ {
        if count[i] > 0 {
            ans++
        }
    }
    return ans
}
```

```C
int numberOfPoints(int** nums, int numsSize, int* numsColSize){
    int C = 0;
    for (int i = 0; i < numsSize; i++) {
        if (nums[i][1] > C) {
            C = nums[i][1];
        }
    }

    int count[C + 1];
    memset(count, 0, sizeof(count));
    for (int i = 0; i < numsSize; i++) {
        for (int j = nums[i][0]; j <= nums[i][1]; j++) {
            count[j]++;
        }
    }

    int ans = 0;
    for (int i = 1; i <= C; i++) {
        if (count[i] > 0) {
            ans++;
        }
    }
    return ans;
}
```

```JavaScript
var numberOfPoints = function(nums) {
    let C = 0;
    for (const interval of nums) {
        C = Math.max(C, interval[1]);
    }

    const count = new Array(C + 1).fill(0);
    for (const interval of nums) {
        for (let i = interval[0]; i <= interval[1]; i++) {
            count[i]++;
        }
    }

    let ans = 0;
    for (let i = 1; i <= C; i++) {
        if (count[i] > 0) {
            ans++;
        }
    }
    return ans;
};
```

```TypeScript
function numberOfPoints(nums: number[][]): number {
    let C = 0;
    for (const interval of nums) {
        C = Math.max(C, interval[1]);
    }

    const count = new Array(C + 1).fill(0);
    for (const interval of nums) {
        for (let i = interval[0]; i <= interval[1]; i++) {
            count[i]++;
        }
    }

    let ans = 0;
    for (let i = 1; i <= C; i++) {
        if (count[i] > 0) {
            ans++;
        }
    }
    return ans;
};
```

```Rust
impl Solution {
    pub fn number_of_points(nums: Vec<Vec<i32>>) -> i32 {
        let mut C = 0;
        for interval in &nums {
            C = C.max(interval[1]);
        }

        let mut count = vec![0; (C + 1) as usize];
        for interval in &nums {
            for i in interval[0]..=interval[1] {
                count[i as usize] += 1;
            }
        }

        let mut ans = 0;
        for i in 1..=C {
            if count[i as usize] > 0 {
                ans += 1;
            }
        }

        ans
    }
}
```

```Cangjie
class Solution {
    func numberOfPoints(nums: ArrayList<ArrayList<Int64>>): Int64 {
        var C = 0
        for (interval in nums) {
            C = max(C, interval[1])
        }
        var count = Array<Int64>(C + 1, item: 0)
        for (interval in nums) {
            for (i in interval[0]..=interval[1]) {
                count[i]++
            }
        }
        var ans = 0
        for (i in 1..=C) {
            if (count[i] != 0) {
                ans++
            }
        }
        
        return ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(nC)$，其中 $n$ 是数组 $nums$ 的长度，$C$ 是数组 $nums$ 的元素范围。
- 空间复杂度：$O(C)$，即为数组 $count$ 需要的空间。

#### 方法二：差分数组

**思路与算法**

在方法一中，对于每一辆汽车我们都需要 $O(C)$ 的时间更新数组 $count$。注意到我们一定是对数组 $count$ 的连续一段增加一个相同的值 $1$，因此可以使用[差分](https://leetcode.cn/link/?target=https%3A%2F%2Foi-wiki.org%2Fbasic%2Fprefix-sum%2F%23%E5%B7%AE%E5%88%86)的思想优化时间复杂度。

具体地，我们令数组 $diff$ 中的每个元素是数组 $count$ 中相邻两个元素的差值，即：

$$diff[i]=\left\{\begin{array}{lr}count[i], & if \quad i=0 \\ count[i]−count[i−1], & ​if \quad i>0\end{array}\right.​$$

如果我们维护数组 $diff$，那么 $count[i]$ 可以通过从 $diff[0]$ 累加到 $diff[i]$ 方便地求出。

当我们需要将数组 $count$ 中下标从 $x$ 到 $y$ 的元素均增加 $1$ 时，对应到数组 $diff$，只需要将 $diff[x]$ 增加 $1$，并将 $diff[y+1]$ 减少 $1$，时间复杂度从 $O(C)$ 降低至 $O(1)$。

最后只需要对数组 $diff$ 求一遍前缀和，就还原出了数组 $count$，其中非零元素的数量即为答案。

**代码**

```C++
class Solution {
public:
    int numberOfPoints(vector<vector<int>>& nums) {
        int C = 0;
        for (const auto& interval: nums) {
            C = max(C, interval[1]);
        }

        vector<int> diff(C + 2);
        for (const auto& interval: nums) {
            ++diff[interval[0]];
            --diff[interval[1] + 1];
        }

        int ans = 0, count = 0;
        for (int i = 1; i <= C; ++i) {
            count += diff[i];
            if (count) {
                ++ans;
            }
        }
        return ans;
    }
};
```

```Java
class Solution {
    public int numberOfPoints(List<List<Integer>> nums) {
        int C = 0;
        for (List<Integer> interval : nums) {
            C = Math.max(C, interval.get(1));
        }

        int[] diff = new int[C + 2];
        for (List<Integer> interval : nums) {
            ++diff[interval.get(0)];
            --diff[interval.get(1) + 1];
        }

        int ans = 0, count = 0;
        for (int i = 1; i <= C; ++i) {
            count += diff[i];
            if (count > 0) {
                ++ans;
            }
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public int NumberOfPoints(IList<IList<int>> nums) {
        int C = 0;
        foreach (IList<int> interval in nums) {
            C = Math.Max(C, interval[1]);
        }

        int[] diff = new int[C + 2];
        foreach (IList<int> interval in nums) {
            ++diff[interval[0]];
            --diff[interval[1] + 1];
        }

        int ans = 0, count = 0;
        for (int i = 1; i <= C; ++i) {
            count += diff[i];
            if (count > 0) {
                ++ans;
            }
        }
        return ans;
    }
}
```

```Python
class Solution:
    def numberOfPoints(self, nums: List[List[int]]) -> int:
        C = max(y for _, y in nums)
        diff = [0] * (C + 2)
        for x, y in nums:
            diff[x] += 1
            diff[y + 1] -= 1
        
        ans = count = 0
        for i in range(1, C + 1):
            count += diff[i]
            if count > 0:
                ans += 1
        return ans
```

```Go
func numberOfPoints(nums [][]int) int {
    C := 0
    for _, interval := range nums {
        if interval[1] > C {
            C = interval[1]
        }
    }

    diff := make([]int, C + 2)
    for _, interval := range nums {
        diff[interval[0]]++
        diff[interval[1] + 1]--
    }

    ans, count := 0, 0
    for i := 1; i <= C; i++ {
        count += diff[i]
        if count > 0 {
            ans++
        }
    }

    return ans
}
```

```C
int numberOfPoints(int** nums, int numsSize, int* numsColSize){
    int C = 0;
    for (int i = 0; i < numsSize; i++) {
        if (nums[i][1] > C) {
            C = nums[i][1];
        }
    }

    int diff[C + 2];
    memset(diff, 0, sizeof(diff));
    for (int i = 0; i < numsSize; i++) {
        diff[nums[i][0]]++;
        diff[nums[i][1] + 1]--;
    }

    int ans = 0, count = 0;
    for (int i = 1; i <= C; i++) {
        count += diff[i];
        if (count > 0) {
            ans++;
        }
    }

    return ans;
}
```

```JavaScript
var numberOfPoints = function(nums) {
    let C = 0;
    for (const interval of nums) {
        C = Math.max(C, interval[1]);
    }

    const diff = new Array(C + 2).fill(0);
    for (const interval of nums) {
        diff[interval[0]]++;
        diff[interval[1] + 1]--;
    }

    let ans = 0, count = 0;
    for (let i = 1; i <= C; i++) {
        count += diff[i];
        if (count > 0) {
            ans++;
        }
    }

    return ans;
};
```

```TypeScript
function numberOfPoints(nums: number[][]): number {
    let C = 0;
    for (const interval of nums) {
        C = Math.max(C, interval[1]);
    }

    const diff = new Array(C + 2).fill(0);
    for (const interval of nums) {
        diff[interval[0]]++;
        diff[interval[1] + 1]--;
    }

    let ans = 0, count = 0;
    for (let i = 1; i <= C; i++) {
        count += diff[i];
        if (count > 0) {
            ans++;
        }
    }

    return ans;
};
```

```Rust
impl Solution {
    pub fn number_of_points(nums: Vec<Vec<i32>>) -> i32 {
        let mut C = 0;
        for interval in &nums {
            C = C.max(interval[1]);
        }

        let mut diff = vec![0; (C + 2) as usize];
        for interval in &nums {
            diff[interval[0] as usize] += 1;
            diff[(interval[1] + 1) as usize] -= 1;
        }

        let mut ans = 0;
        let mut count = 0;
        for i in 1..=C {
            count += diff[i as usize];
            if count > 0 {
                ans += 1;
            }
        }

        ans
    }
}
```

```Cangjie
class Solution {
    func numberOfPoints(nums: ArrayList<ArrayList<Int64>>): Int64 {
        var C = 0
        for (interval in nums) {
            C = max(C, interval[1])
        }
        var diff = Array<Int64>(C + 2, item: 0)
        for (interval in nums) {
            diff[interval[0]]++
            diff[interval[1] + 1]--
        }

        var ans = 0
        var count = 0
        for (i in 1..= C) {
            count += diff[i]
            if (count != 0) {
                ans++
            }
        }
        return ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n+C)$，其中 $n$ 是数组 $nums$ 的长度，$C$ 是数组 $nums$ 的元素范围。
- 空间复杂度：$O(C)$，即为数组 $diff$ 需要的空间。
