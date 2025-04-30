### [统计位数为偶数的数字](https://leetcode.cn/problems/find-numbers-with-even-number-of-digits/solutions/101807/tong-ji-wei-shu-wei-ou-shu-de-shu-zi-by-leetcode-s/)

#### 方法一：枚举 + 字符串

**思路**

我们枚举数组 $nums$ 中的整数，并依次判断每个整数 $x$ 是否包含偶数个数字。
一种简单的方法是使用语言内置的整数转字符串函数，将 $x$ 转换为字符串后，判断其长度是否为偶数即可。

```C++
class Solution {
public:
    int findNumbers(vector<int>& nums) {
        int ans = 0;
        for (int num: nums) {
            if (to_string(num).size() % 2 == 0) {
                ++ans;
            }
        }
        return ans;
    }
};
```

```C++
// C++17
class Solution {
public:
    int findNumbers(vector<int>& nums) {
        return accumulate(nums.begin(), nums.end(), 0, [](int ans, int num) {
            return ans + (to_string(num).size() % 2 == 0);
        });
    }
};
```

```Python
class Solution:
    def findNumbers(self, nums: List[int]) -> int:
        return sum(1 for num in nums if len(str(num)) % 2 == 0)
```

```Java
class Solution {
    public int findNumbers(int[] nums) {
        int ans = 0;
        for (int num : nums) {
            if (String.valueOf(num).length() % 2 == 0) {
                ans++;
            }
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public int FindNumbers(int[] nums) {
        int ans = 0;
        foreach (int num in nums) {
            if (num.ToString().Length % 2 == 0) {
                ans++;
            }
        }
        return ans;
    }
}
```

```Go
func findNumbers(nums []int) int {
    ans := 0
    for _, num := range nums {
        if len(strconv.Itoa(num)) % 2 == 0 {
            ans++
        }
    }
    return ans
}
```

```C
int findNumbers(int* nums, int numsSize) {
    int ans = 0;
    for (int i = 0; i < numsSize; ++i) {
        char str[16];
        sprintf(str, "%d", nums[i]);
        if (strlen(str) % 2 == 0) {
            ans++;
        }
    }
    return ans;
}
```

```JavaScript
var findNumbers = function(nums) {
    let ans = 0;
    for (let num of nums) {
        if (num.toString().length % 2 === 0) {
            ans++;
        }
    }
    return ans;
};
```

```TypeScript
function findNumbers(nums: number[]): number {
    let ans = 0;
    for (let num of nums) {
        if (num.toString().length % 2 === 0) {
            ans++;
        }
    }
    return ans;
};
```

```Rust
impl Solution {
    pub fn find_numbers(nums: Vec<i32>) -> i32 {
        let mut ans = 0;
        for &num in &nums {
            if num.to_string().len() % 2 == 0 {
                ans += 1;
            }
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(N)$，其中 $N$ 是数组 $nums$ 的长度。这里假设将整数转换为字符串的时间复杂度为 $O(1)$。
- 空间复杂度：$O(1)$。

#### 方法二：枚举 + 数学

**思路**

我们也可以使用语言内置的以 $10$ 为底的对数函数 $\log_{10}()$ 来得到整数 $x$ 包含的数字个数。
一个包含 $k$ 个数字的整数 $x$ 满足不等式 $10^{k-1} \le x < 10^k$。将不等式取对数，得到 $k-1 \le \log_{10}(x) < k$，因此我们可以用 $k = \lfloor\log_{10}(x)+1\rfloor$ 得到 $x$ 包含的数字个数 $k$，其中 $\lfloor a \rfloor$ 表示将 $a$ 进行下取整，例如 $\lfloor 5.2 \rfloor = 5$。

```C++
class Solution {
public:
    int findNumbers(vector<int>& nums) {
        int ans = 0;
        for (int num: nums) {
            if ((int)(log10(num) + 1) % 2 == 0) {
                ++ans;
            }
        }
        return ans;
    }
};
```

```C++
// C++17
class Solution {
public:
    int findNumbers(vector<int>& nums) {
        return accumulate(nums.begin(), nums.end(), 0, [](int ans, int num) {
            return ans + ((int)(log10(num) + 1) % 2 == 0);
        });
    }
};
```

```Python
class Solution:
    def findNumbers(self, nums: List[int]) -> int:
        return sum(1 for num in nums if int(math.log10(num) + 1) % 2 == 0)
```

```Java
class Solution {
    public int findNumbers(int[] nums) {
        int ans = 0;
        for (int num : nums) {
            if ((int) (Math.log10(num) + 1) % 2 == 0) {
                ans++;
            }
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public int FindNumbers(int[] nums) {
        int ans = 0;
        foreach (int num in nums) {
            if ((int) (Math.Log10(num) + 1) % 2 == 0) {
                ans++;
            }
        }
        return ans;
    }
}
```

```Go
func findNumbers(nums []int) int {
    ans := 0
    for _, num := range nums {
        if int(math.Log10(float64(num)) + 1) % 2 == 0 {
            ans++
        }
    }
    return ans
}
```

```C
int findNumbers(int* nums, int numsSize) {
    int ans = 0;
    for (int i = 0; i < numsSize; ++i) {
        if ((int)(log10(nums[i]) + 1) % 2 == 0) {
            ans++;
        }
    }
    return ans;
}
```

```JavaScript
var findNumbers = function(nums) {
    let ans = 0;
    for (let num of nums) {
        if (Math.floor(Math.log10(num) + 1) % 2 === 0) {
            ans++;
        }
    }
    return ans;
};
```

```TypeScript
function findNumbers(nums: number[]): number {
    let ans = 0;
    for (let num of nums) {
        if (Math.floor(Math.log10(num) + 1) % 2 === 0) {
            ans++;
        }
    }
    return ans;
};
```

```Rust
impl Solution {
    pub fn find_numbers(nums: Vec<i32>) -> i32 {
        let mut ans = 0;
        for &num in &nums {
            let digits = (num as f64).log10().floor() as i32 + 1;
            if digits % 2 == 0 {
                ans += 1;
            }
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(N)$，其中 $N$ 是数组 $nums$ 的长度。
- 空间复杂度：$O(1)$。
