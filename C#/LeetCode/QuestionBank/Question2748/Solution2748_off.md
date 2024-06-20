### [美丽下标对的数目](https://leetcode.cn/problems/number-of-beautiful-pairs/solutions/2815256/mei-li-xia-biao-dui-de-shu-mu-by-leetcod-b4jo/)

#### 方法一：暴力枚举

**思路与算法**  
暴力枚举 $\textit{nums}[i]$ 和 $\textit{nums}[j]$，判断是否是美丽下标对。

**代码**

```C++
class Solution {
public:
    int countBeautifulPairs(vector<int> &nums) {
        int res = 0, n = nums.size();
        for (int i = 0; i < n; i++) {
            while (nums[i] >= 10) {
                nums[i] /= 10;
            }
            for (int j = i + 1; j < n; j++) {
                if (gcd(nums[i], nums[j] % 10) == 1) {
                    res++;
                }
            }
        }
        return res;
    }
};
```

```Java
class Solution {
    public int countBeautifulPairs(int[] nums) {
        int res = 0, n = nums.length;
        for (int i = 0; i < n; i++) {
            while (nums[i] >= 10) {
                nums[i] /= 10;
            }
            for (int j = i + 1; j < n; j++) {
                if (gcd(nums[i], nums[j] % 10) == 1) {
                    res++;
                }
            }
        }
        return res;
    }

    private int gcd(int a, int b) {
        return b == 0 ? a : gcd(b, a % b);
    }
}
```

```Python
class Solution:
    def countBeautifulPairs(self, nums: List[int]) -> int:
        n = len(nums)
        res = 0
        for i in range(n):
            while nums[i] >= 10:
                nums[i] //= 10
            for j in range(i + 1, n):
                if gcd(nums[i] , nums[j] % 10) == 1:
                    res += 1
        return res
```

```JavaScript
var countBeautifulPairs = function(nums) {
    let res = 0;
    let n = nums.length;

    for (let i = 0; i < n; i++) {
        while (nums[i] >= 10) {
            nums[i] = Math.floor(nums[i] / 10);
        }
        for (let j = i + 1; j < n; j++) {
            if (gcd(nums[i], nums[j] % 10) === 1) {
                res++;
            }
        }
    }
    return res;
};

function gcd(a, b) {
    return b === 0 ? a : gcd(b, a % b);
}
```

```TypeScript
function countBeautifulPairs(nums: number[]): number {
    let res = 0;
    let n = nums.length;

    for (let i = 0; i < n; i++) {
        while (nums[i] >= 10) {
            nums[i] = Math.floor(nums[i] / 10);
        }
        for (let j = i + 1; j < n; j++) {
            if (gcd(nums[i], nums[j] % 10) === 1) {
                res++;
            }
        }
    }
    return res;
};

function gcd(a, b) {
    return b === 0 ? a : gcd(b, a % b);
};
```

```Go
func countBeautifulPairs(nums []int) int {
    res := 0
    n := len(nums)
    for i := 0; i < n; i++ {
        for nums[i] >= 10 {
            nums[i] /= 10
        }
        for j := i + 1; j < n; j++ {
            if gcd(nums[i], nums[j] % 10) == 1 {
                res++
            }
        }
    }
    return res
}

func gcd(a, b int) int {
    for b != 0 {
        a, b = b, a % b
    }
    return a
}
```

```CSharp
public class Solution {
    public int CountBeautifulPairs(int[] nums) {
        int res = 0, n = nums.Length;
        for (int i = 0; i < n; i++) {
            while (nums[i] >= 10) {
                nums[i] /= 10;
            }
            for (int j = i + 1; j < n; j++) {
                if (GCD(nums[i], nums[j] % 10) == 1) {
                    res++;
                }
            }
        }
        return res;
    }

    private int GCD(int a, int b) {
        return b == 0 ? a : GCD(b, a % b);
    }
}
```

```C
int gcd(int a, int b) {
    return b == 0 ? a : gcd(b, a % b);
}

int countBeautifulPairs(int* nums, int numsSize){
    int res = 0, n = numsSize;
    for (int i = 0; i < n; i++) {
        while (nums[i] >= 10) {
            nums[i] /= 10;
        }
        for (int j = i + 1; j < n; j++) {
            if (gcd(nums[i], nums[j] % 10) == 1) {
                res++;
            }
        }
    }

    return res;
}
```

```Rust
impl Solution {
    pub fn count_beautiful_pairs(nums: Vec<i32>) -> i32 {
        let mut res = 0;
        let n = nums.len() as i32;
        for i in 0..n {
            let mut x = nums[i as usize];
            while x >= 10 {
                x /= 10;
            }
            for j in (i + 1)..n {
                if Self::gcd(x, nums[j as usize] % 10) == 1 {
                    res += 1;
                }
            }
        }
        res
    }

    fn gcd(mut a: i32, mut b: i32) -> i32 {
        while b != 0 {
            let temp = b;
            b = a % b;
            a = temp;
        }
        a
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n \times (n + \log C))$，其中 $n$ 是数组的长度，$C$ 是 $\textit{nums}[i]$ 的最大值。
- 空间复杂度：$O(1)$。

#### 方法二：哈希表

**思路与算法**

用一个数组 $\textit{cnt}[y]$ 来表示第一个数字为 $y$ 的元素个数。

遍历数组，求出元素的最后一个数字，再枚举 $1$ 到 $9$， 根据对应 $\textit{cnt}[y]$ 计算美丽下标对个数。同时再求出元素的第一个数字，来更新 $\textit{cnt}$。

最后返回结果即可。

**代码**

```C++
class Solution {
public:
    int countBeautifulPairs(vector<int> &nums) {
        int res = 0, cnt[10]{};
        for (int x: nums) {
            for (int y = 1; y <= 9; y++) {
                if (gcd(x % 10, y) == 1) {
                    res += cnt[y];
                }
            }
            while (x >= 10) {
                x /= 10;
            }
            cnt[x]++;
        }
        return res;
    }
};
```

```Java
class Solution {
    public int countBeautifulPairs(int[] nums) {
        int res = 0;
        int[] cnt = new int[10];
        for (int x : nums) {
            for (int y = 1; y <= 9; y++) {
                if (gcd(x % 10, y) == 1) {
                    res += cnt[y];
                }
            }
            while (x >= 10) {
                x /= 10;
            }
            cnt[x]++;
        }
        return res;
    }

    private int gcd(int a, int b) {
        return b == 0 ? a : gcd(b, a % b);
    }
}
```

```Python
class Solution:
    def countBeautifulPairs(self, nums: List[int]) -> int:
        res = 0
        cnt = [0] * 10
        for x in nums:
            for y in range(1, 10):
                if gcd(x % 10, y) == 1:
                    res += cnt[y]
            while x >= 10:
                x //= 10
            cnt[x] += 1
        return res
```

```JavaScript
var countBeautifulPairs = function(nums) {
    let res = 0;
    let cnt = new Array(10).fill(0);

    for (let x of nums) {
        for (let y = 1; y <= 9; y++) {
            if (gcd(x % 10, y) === 1) {
                res += cnt[y];
            }
        }
        while (x >= 10) {
            x = Math.floor(x / 10);
        }
        cnt[x]++;
    }
    return res;
};

function gcd(a, b) {
    return b === 0 ? a : gcd(b, a % b);
}
```

```TypeScript
function countBeautifulPairs(nums: number[]): number {
    let res = 0;
    let cnt = new Array(10).fill(0);

    for (let x of nums) {
        for (let y = 1; y <= 9; y++) {
            if (gcd(x % 10, y) === 1) {
                res += cnt[y];
            }
        }
        while (x >= 10) {
            x = Math.floor(x / 10);
        }
        cnt[x]++;
    }
    return res;
};

function gcd(a, b) {
    return b === 0 ? a : gcd(b, a % b);
};
```

```Go
func countBeautifulPairs(nums []int) int {
    res := 0
    cnt := make([]int, 10)
    for _, x := range nums {
        for y := 1; y < 10; y++ {
            if gcd(x % 10, y) == 1 {
                res += cnt[y]
            }
        }
        for x >= 10 {
            x /= 10
        }
        cnt[x]++
    }
    return res
}

func gcd(a, b int) int {
    for b != 0 {
        a, b = b, a % b
    }
    return a
}
```

```CSharp
public class Solution {
    public int CountBeautifulPairs(int[] nums) {
        int res = 0;
        int[] cnt = new int[10];
        foreach (int x in nums) {
            for (int y = 1; y <= 9; y++) {
                if (GCD(x % 10, y) == 1) {
                    res += cnt[y];
                }
            }
            int x2 = x;
            while (x2 >= 10) {
                x2 /= 10;
            }
            cnt[x2]++;
        }
        return res;
    }

    private int GCD(int a, int b) {
        return b == 0 ? a : GCD(b, a % b);
    }
}
```

```C
int gcd(int a, int b) {
    return b == 0 ? a : gcd(b, a % b);
}

int countBeautifulPairs(int* nums, int numsSize){
    int res = 0;
    int cnt[10] = {0};

    for (int i = 0; i < numsSize; i++) {
        int x = nums[i];
        for (int y = 1; y <= 9; y++) {
            if (gcd(x % 10, y) == 1) {
                res += cnt[y];
            }
        }
        while (x >= 10) {
            x /= 10;
        }
        cnt[x]++;
    }

    return res;
}
```

```Rust
impl Solution {
    pub fn count_beautiful_pairs(nums: Vec<i32>) -> i32 {
        let mut res = 0;
        let mut cnt = [0; 10];
        for x in nums {
            for y in 1..=9 {
                if Self::gcd(x % 10, y) == 1 {
                    res += cnt[y as usize];
                }
            }
            let mut x = x;
            while x >= 10 {
                x /= 10;
            }
            cnt[x as usize] += 1;
        }

        res
    }

    fn gcd(mut a: i32, mut b: i32) -> i32 {
        while b != 0 {
            let temp = b;
            b = a % b;
            a = temp;
        }
        a
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n \times (10 + \log C))$，其中 $n$ 是数组的长度，$C$ 是 $\textit{nums}[i]$ 的最大值。
- 空间复杂度：$O(10)$。
