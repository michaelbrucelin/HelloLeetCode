### [找出数组的最大公约数](https://leetcode.cn/problems/find-greatest-common-divisor-of-array/solutions/951994/zhao-chu-shu-zu-de-zui-da-gong-yue-shu-b-brqd/)

#### 方法一：按要求计算

**思路与算法**

我们首先遍历数组 $nums$ 得到最大值与最小值后，再计算两者的最大公约数即可。

对于计算最大公约数的部分，$C++$ 与 $Python$ 的标准库中都有计算两个整数最大公约数的函数。

**最大公约数的求法**

计算两个整数最大公约数 $gcd(a,b)$ 的一种常见方法是欧几里得算法，即辗转相除法。其核心部分为：

$$gcd(a,b)=gcd(b,a \bmod  b).$$

**代码**

```C++
class Solution {
public:
    int findGCD(vector<int>& nums) {
        int mx = *max_element(nums.begin(), nums.end());
        int mn = *min_element(nums.begin(), nums.end());
        return gcd(mx, mn);
    }
};
```

```Python
import math

class Solution:
    def findGCD(self, nums: List[int]) -> int:
        mx, mn = max(nums), min(nums)
        return math.gcd(mx, mn)
```

```Java
class Solution {
    public int findGCD(int[] nums) {
        int mx = Integer.MIN_VALUE;
        int mn = Integer.MAX_VALUE;
        for (int num : nums) {
            mn = Math.min(mn, num);
            mx = Math.max(mx, num);
        }
        return gcd(mx, mn);
    }

    private int gcd(int a, int b) {
        while (b != 0) {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
}
```

```CSharp
public class Solution {
    public int FindGCD(int[] nums) {
        int mx = nums.Max();
        int mn = nums.Min();
        return Gcd(mx, mn);
    }

    private int Gcd(int a, int b) {
        while (b != 0) {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
}
```

```Go
func findGCD(nums []int) int {
    mx, mn := nums[0], nums[0]
    for _, num := range nums {
        mn = min(mn, num)
        mx = max(mx, num)
    }
    return gcd(mx, mn)
}

func gcd(a, b int) int {
    for b != 0 {
        a, b = b, a%b
    }
    return a
}
```

```C
int gcd(int a, int b) {
    while (b != 0) {
        int temp = b;
        b = a % b;
        a = temp;
    }
    return a;
}

int findGCD(int* nums, int numsSize) {
    int mx = nums[0];
    int mn = nums[0];
    for (int i = 1; i < numsSize; i++) {
        if (nums[i] > mx) {
            mx = nums[i];
        }
        if (nums[i] < mn) {
            mn = nums[i];
        }
    }
    return gcd(mx, mn);
}
```

```JavaScript
var findGCD = function(nums) {
    let mx = Math.max(...nums);
    let mn = Math.min(...nums);
    return gcd(mx, mn);
}

function gcd(a, b) {
    while (b !== 0) {
        [a, b] = [b, a % b];
    }
    return a;
}
```

```TypeScript
function findGCD(nums: number[]): number {
    let mx = Math.max(...nums);
    let mn = Math.min(...nums);
    return gcd(mx, mn);
}

function gcd(a: number, b: number): number {
    while (b !== 0) {
        [a, b] = [b, a % b];
    }
    return a;
}
```

```Rust
impl Solution {
    pub fn find_gcd(nums: Vec<i32>) -> i32 {
        let mx = *nums.iter().max().unwrap();
        let mn = *nums.iter().min().unwrap();
        Self::gcd(mx, mn)
    }

    fn gcd(a: i32, b: i32) -> i32 {
        if b == 0 { a } else { Self::gcd(b, a % b) }
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n+\log M)$，其中 $n$ 为 $nums$ 的长度，$M$ 为 $nums$ 的最大值。遍历数组寻找最大值与最小值的时间复杂度为 $O(n)$，计算最大公约数的时间复杂度为 $O(\log M)$。
- 空间复杂度：$O(1)$。
