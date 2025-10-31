### [数字小镇中的捣蛋鬼](https://leetcode.cn/problems/the-two-sneaky-numbers-of-digitville/solutions/3804527/shu-zi-xiao-zhen-zhong-de-dao-dan-gui-by-yivz/)

#### 方法一：哈希表

使用哈希表统计 $nums$ 中出现了两次的数字，返回结果。

```C++
class Solution {
public:
    vector<int> getSneakyNumbers(vector<int>& nums) {
        vector<int> res;
        unordered_map<int, int> count;
        for (int x : nums) {
            count[x]++;
            if (count[x] == 2) {
                res.push_back(x);
            }
        }
        return res;
    }
};
```

```Go
func getSneakyNumbers(nums []int) []int {
    res := []int{}
    count := make(map[int]int)
    for _, x := range nums {
        count[x]++
        if count[x] == 2 {
            res = append(res, x)
        }
    }
    return res
}
```

```Python
class Solution:
    def getSneakyNumbers(self, nums: List[int]) -> List[int]:
        res = []
        count = {}
        for x in nums:
            count[x] = count.get(x, 0) + 1
            if count[x] == 2:
                res.append(x)
        return res
```

```Java
class Solution {
    public int[] getSneakyNumbers(int[] nums) {
        List<Integer> res = new ArrayList<>();
        Map<Integer, Integer> count = new HashMap<>();
        for (int x : nums) {
            count.put(x, count.getOrDefault(x, 0) + 1);
            if (count.get(x) == 2) {
                res.add(x);
            }
        }
        return res.stream().mapToInt(i -> i).toArray();
    }
}
```

```TypeScript
function getSneakyNumbers(nums: number[]): number[] {
    const res: number[] = [];
    const count = new Map<number, number>();
    for (const x of nums) {
        count.set(x, (count.get(x) || 0) + 1);
        if (count.get(x) === 2) {
            res.push(x);
        }
    }
    return res;
}
```

```JavaScript
var getSneakyNumbers = function(nums) {
    const res = [];
    const count = new Map();
    for (const x of nums) {
        count.set(x, (count.get(x) || 0) + 1);
        if (count.get(x) === 2) {
            res.push(x);
        }
    }
    return res;
};
```

```CSharp
public class Solution {
    public int[] GetSneakyNumbers(int[] nums) {
        List<int> res = new List<int>();
        Dictionary<int, int> count = new Dictionary<int, int>();
        foreach (int x in nums) {
            if (!count.ContainsKey(x)) count[x] = 0;
            count[x]++;
            if (count[x] == 2) {
                res.Add(x);
            }
        }
        return res.ToArray();
    }
}
```

```C
int* getSneakyNumbers(int* nums, int numsSize, int* returnSize) {
    int* res = (int*)malloc(2 * sizeof(int));
    int* count = (int*)calloc(101, sizeof(int));
    *returnSize = 0;
    for (int i = 0; i < numsSize; i++) {
        int x = nums[i];
        count[x]++;
        if (count[x] == 2) {
            res[(*returnSize)++] = x;
        }
    }
    free(count);
    return res;
}
```

```Rust
impl Solution {
    pub fn get_sneaky_numbers(nums: Vec<i32>) -> Vec<i32> {
        let mut res = Vec::new();
        let mut count = std::collections::HashMap::new();
        for x in nums {
            let c = count.entry(x).or_insert(0);
            *c += 1;
            if *c == 2 {
                res.push(x);
            }
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$。
- 空间复杂度：$O(n)$。

#### 方法二：位运算

我们将 $nums$ 的所有数字和 $0$ 到 $n-1$ 的所有数字进行异或，那么计算结果为两个额外多出现一次的数字的异或值 $y$。那么两个数字最低不相同的位为 $lowBit=y\&-y$，利用 $lowBit$ 将 $nums$ 的所有数字和 $0$ 到 $n-1$ 的所有数字分成两部分，然后分别计算这两部分数字的异或值，即为结果。

```C++
class Solution {
public:
    vector<int> getSneakyNumbers(vector<int>& nums) {
        int n = (int)nums.size() - 2;
        int y = 0;
        for (int x : nums) {
            y ^= x;
        }
        for (int i = 0; i < n; i++) {
            y ^= i;
        }
        int lowBit = y & (-y);
        int x1 = 0, x2 = 0;
        for (int x : nums) {
            if (x & lowBit) {
                x1 ^= x;
            } else {
                x2 ^= x;
            }
        }
        for (int i = 0; i < n; i++) {
            if (i & lowBit) {
                x1 ^= i;
            } else {
                x2 ^= i;
            }
        }
        return {x1, x2};
    }
};
```

```Go
func getSneakyNumbers(nums []int) []int {
    n := len(nums) - 2
    y := 0
    for _, x := range nums {
        y ^= x
    }
    for i := 0; i < n; i++ {
        y ^= i
    }
    lowBit := y & -y
    x1, x2 := 0, 0
    for _, x := range nums {
        if x&lowBit != 0 {
            x1 ^= x
        } else {
            x2 ^= x
        }
    }
    for i := 0; i < n; i++ {
        if i&lowBit != 0 {
            x1 ^= i
        } else {
            x2 ^= i
        }
    }
    return []int{x1, x2}
}
```

```Python
class Solution:
    def getSneakyNumbers(self, nums: List[int]) -> List[int]:
        n = len(nums) - 2
        y = 0
        for x in nums:
            y ^= x
        for i in range(n):
            y ^= i
        lowBit = y & -y
        x1 = x2 = 0
        for x in nums:
            if x & lowBit:
                x1 ^= x
            else:
                x2 ^= x
        for i in range(n):
            if i & lowBit:
                x1 ^= i
            else:
                x2 ^= i
        return [x1, x2]
```

```Java
class Solution {
    public int[] getSneakyNumbers(int[] nums) {
        int n = nums.length - 2;
        int y = 0;
        for (int x : nums) {
            y ^= x;
        }
        for (int i = 0; i < n; i++) {
            y ^= i;
        }
        int lowBit = y & -y;
        int x1 = 0, x2 = 0;
        for (int x : nums) {
            if ((x & lowBit) != 0) {
                x1 ^= x;
            } else {
                x2 ^= x;
            }
        }
        for (int i = 0; i < n; i++) {
            if ((i & lowBit) != 0) {
                x1 ^= i;
            } else {
                x2 ^= i;
            }
        }
        return new int[]{x1, x2};
    }
}
```

```TypeScript
function getSneakyNumbers(nums: number[]): number[] {
    const n = nums.length - 2;
    let y = 0;
    for (const x of nums) {
        y ^= x;
    }
    for (let i = 0; i < n; i++) {
        y ^= i;
    }
    const lowBit = y & -y;
    let x1 = 0, x2 = 0;
    for (const x of nums) {
        if (x & lowBit) {
            x1 ^= x;
        } else {
            x2 ^= x;
        }
    }
    for (let i = 0; i < n; i++) {
        if (i & lowBit) {
            x1 ^= i;
        } else {
            x2 ^= i;
        }
    }
    return [x1, x2];
}
```

```JavaScript
function getSneakyNumbers(nums) {
    const n = nums.length - 2;
    let y = 0;
    for (const x of nums) {
        y ^= x;
    }
    for (let i = 0; i < n; i++) {
        y ^= i;
    }
    const lowBit = y & -y;
    let x1 = 0, x2 = 0;
    for (const x of nums) {
        if (x & lowBit) {
            x1 ^= x;
        } else {
            x2 ^= x;
        }
    }
    for (let i = 0; i < n; i++) {
        if (i & lowBit) {
            x1 ^= i;
        } else {
            x2 ^= i;
        }
    }
    return [x1, x2];
}
```

```CSharp
public class Solution {
    public int[] GetSneakyNumbers(int[] nums) {
        int n = nums.Length - 2;
        int y = 0;
        foreach (int x in nums) {
            y ^= x;
        }
        for (int i = 0; i < n; i++) {
            y ^= i;
        }
        int lowBit = y & -y;
        int x1 = 0, x2 = 0;
        foreach (int x in nums) {
            if ((x & lowBit) != 0) {
                x1 ^= x;
            } else {
                x2 ^= x;
            }
        }
        for (int i = 0; i < n; i++) {
            if ((i & lowBit) != 0) {
                x1 ^= i;
            } else {
                x2 ^= i;
            }
        }
        return new int[] { x1, x2 };
    }
}
```

```C
int* getSneakyNumbers(int* nums, int numsSize, int* returnSize) {
    int n = numsSize - 2;
    int y = 0;
    for (int i = 0; i < numsSize; i++) {
        y ^= nums[i];
    }
    for (int i = 0; i < n; i++) {
        y ^= i;
    }
    int lowBit = y & -y;
    int x1 = 0, x2 = 0;
    for (int i = 0; i < numsSize; i++) {
        if (nums[i] & lowBit) {
            x1 ^= nums[i];
        } else {
            x2 ^= nums[i];
        }
    }
    for (int i = 0; i < n; i++) {
        if (i & lowBit) {
            x1 ^= i;
        } else {
            x2 ^= i;
        }
    }
    int* res = (int*)malloc(2 * sizeof(int));
    res[0] = x1;
    res[1] = x2;
    *returnSize = 2;
    return res;
}
```

```Rust
impl Solution {
    pub fn get_sneaky_numbers(nums: Vec<i32>) -> Vec<i32> {
        let n = nums.len() as i32 - 2;
        let mut y = 0;
        for &x in &nums {
            y ^= x;
        }
        for i in 0..n {
            y ^= i;
        }
        let low_bit = y & -y;
        let mut x1 = 0;
        let mut x2 = 0;
        for &x in &nums {
            if x & low_bit != 0 {
                x1 ^= x;
            } else {
                x2 ^= x;
            }
        }
        for i in 0..n {
            if i & low_bit != 0 {
                x1 ^= i;
            } else {
                x2 ^= i;
            }
        }
        vec![x1, x2]
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$。
- 空间复杂度：$O(1)$。

#### 方法三：数学

令两个额外多出现一次的数字为 $x_1$ 和 $x_2$。nums 的和与平方和分别为 $sum$ 和 $squaredSum$，从 $0$ 到 $n-1$ 的整数和与平方和分别为 $\frac{n(n-1)}{2}$ 和 $\frac{n(n-1)(2n-1)}{6}$。记 $sum_2=sum-\frac{n(n-1)}{2}$ 和 $squaredSum_2=squaredSum-\frac{n(n-1)(2n-1)}{2}$，那么有以下方程：

$$\begin{cases}x_1+x_2=sum_2 \\ x_1^2+x_2^2=squaredSum_2\end{cases}$$

解得：

$$\begin{cases}x_1=\frac{sum_2-\sqrt{2\times squaredSum_2-sum_2^2}}{2} \\ x_2=\frac{sum_2+\sqrt{2\times squaredSum_2-sum_2^2}}{2}\end{cases}$$

```C++
class Solution {
public:
    vector<int> getSneakyNumbers(vector<int>& nums) {
        int n = (int)nums.size() - 2;
        int sum = 0, squaredSum = 0;
        for (int x : nums) {
            sum += x;
            squaredSum += x * x;
        }
        int sum2 = sum - n * (n - 1) / 2;
        int squaredSum2 = squaredSum - n * (n - 1) * (2 * n - 1) / 6;
        int x1 = (sum2 - sqrt(2 * squaredSum2 - sum2 * sum2)) / 2;
        int x2 = (sum2 + sqrt(2 * squaredSum2 - sum2 * sum2)) / 2;
        return {x1, x2};
    }
};
```

```Go
func getSneakyNumbers(nums []int) []int {
    n := len(nums) - 2
    sum, squaredSum := 0.0, 0.0
    for _, x := range nums {
        sum += float64(x)
        squaredSum += float64(x * x)
    }
    sum2 := sum - float64(n * (n - 1) / 2)
    squaredSum2 := squaredSum - float64(n * (n - 1) * (2 * n - 1) / 6)
    x1 := (sum2 - math.Sqrt(2 * squaredSum2 - sum2 * sum2)) / 2
    x2 := (sum2 + math.Sqrt(2 * squaredSum2 - sum2 * sum2)) / 2
    return []int{int(x1), int(x2)}
}
```

```Python
class Solution:
    def getSneakyNumbers(self, nums: List[int]) -> List[int]:
        n = len(nums) - 2
        sum_ = sum(nums)
        squared_sum = sum(x*x for x in nums)
        sum2 = sum_ - n*(n-1)//2
        squared_sum2 = squared_sum - n*(n-1)*(2*n-1)//6
        x1 = (sum2 - math.sqrt(2*squared_sum2 - sum2*sum2)) / 2
        x2 = (sum2 + math.sqrt(2*squared_sum2 - sum2*sum2)) / 2
        return [int(x1), int(x2)]
```

```Java
class Solution {
    public int[] getSneakyNumbers(int[] nums) {
        int n = nums.length - 2;
        double sum = 0, squaredSum = 0;
        for (int x : nums) {
            sum += x;
            squaredSum += x * x;
        }
        double sum2 = sum - n * (n - 1) / 2.0;
        double squaredSum2 = squaredSum - n * (n - 1) * (2 * n - 1) / 6.0;
        int x1 = (int)((sum2 - Math.sqrt(2 * squaredSum2 - sum2 * sum2)) / 2);
        int x2 = (int)((sum2 + Math.sqrt(2 * squaredSum2 - sum2 * sum2)) / 2);
        return new int[]{x1, x2};
    }
}
```

```TypeScript
function getSneakyNumbers(nums: number[]): number[] {
    const n = nums.length - 2;
    let sum = 0, squaredSum = 0;
    for (const x of nums) {
        sum += x;
        squaredSum += x * x;
    }
    const sum2 = sum - n * (n - 1) / 2;
    const squaredSum2 = squaredSum - n * (n - 1) * (2 * n - 1) / 6;
    const x1 = (sum2 - Math.sqrt(2 * squaredSum2 - sum2 * sum2)) / 2;
    const x2 = (sum2 + Math.sqrt(2 * squaredSum2 - sum2 * sum2)) / 2;
    return [Math.floor(x1), Math.floor(x2)];
}
```

```JavaScript
function getSneakyNumbers(nums) {
    const n = nums.length - 2;
    let sum = 0, squaredSum = 0;
    for (const x of nums) {
        sum += x;
        squaredSum += x * x;
    }
    const sum2 = sum - n * (n - 1) / 2;
    const squaredSum2 = squaredSum - n * (n - 1) * (2 * n - 1) / 6;
    const x1 = (sum2 - Math.sqrt(2 * squaredSum2 - sum2 * sum2)) / 2;
    const x2 = (sum2 + Math.sqrt(2 * squaredSum2 - sum2 * sum2)) / 2;
    return [Math.floor(x1), Math.floor(x2)];
}
```

```CSharp
public class Solution {
    public int[] GetSneakyNumbers(int[] nums) {
        int n = nums.Length - 2;
        double sum = 0, squaredSum = 0;
        foreach (int x in nums) {
            sum += x;
            squaredSum += x * x;
        }
        double sum2 = sum - n * (n - 1) / 2.0;
        double squaredSum2 = squaredSum - n * (n - 1) * (2 * n - 1) / 6.0;
        int x1 = (int)((sum2 - Math.Sqrt(2 * squaredSum2 - sum2 * sum2)) / 2);
        int x2 = (int)((sum2 + Math.Sqrt(2 * squaredSum2 - sum2 * sum2)) / 2);
        return new int[]{x1, x2};
    }
}
```

```C
int* getSneakyNumbers(int* nums, int numsSize, int* returnSize) {
    int n = numsSize - 2;
    double sum = 0, squaredSum = 0;
    for (int i = 0; i < numsSize; i++) {
        sum += nums[i];
        squaredSum += nums[i] * nums[i];
    }
    double sum2 = sum - n * (n - 1) / 2.0;
    double squaredSum2 = squaredSum - n * (n - 1) * (2 * n - 1) / 6.0;
    int x1 = (int)((sum2 - sqrt(2 * squaredSum2 - sum2 * sum2)) / 2);
    int x2 = (int)((sum2 + sqrt(2 * squaredSum2 - sum2 * sum2)) / 2);
    int* res = (int*)malloc(2 * sizeof(int));
    res[0] = x1;
    res[1] = x2;
    *returnSize = 2;
    return res;
}
```

```Rust
impl Solution {
    pub fn get_sneaky_numbers(nums: Vec<i32>) -> Vec<i32> {
        let n = nums.len() as i32 - 2;
        let sum: f64 = nums.iter().map(|&x| x as f64).sum();
        let squared_sum: f64 = nums.iter().map(|&x| (x*x) as f64).sum();
        let sum2 = sum - (n * (n - 1) / 2) as f64;
        let squared_sum2 = squared_sum - (n * (n - 1) * (2 * n - 1) / 6) as f64;
        let x1 = (sum2 - ((2.0 * squared_sum2 - sum2 * sum2).sqrt())) / 2.0;
        let x2 = (sum2 + ((2.0 * squared_sum2 - sum2 * sum2).sqrt())) / 2.0;
        vec![x1 as i32, x2 as i32]
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$。
- 空间复杂度：$O(1)$。
