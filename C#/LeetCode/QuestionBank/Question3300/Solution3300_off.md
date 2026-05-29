### [替换为数位和以后的最小元素](https://leetcode.cn/problems/minimum-element-after-replacement-with-digit-sum/solutions/3968292/ti-huan-wei-shu-wei-he-yi-hou-de-zui-xia-5van/)

#### 方法一：数学

对于一个元素 $x$，可以按照以下步骤来求得每个数位的和 $dig$：

- 取 $x$ 的个位即 $x \bmod 10$，加入到 $dig$ 中。
- 去掉 $x$ 的个位，即将 $x$ 更新为 $\lfloor\dfrac{x}{10}\rfloor $，这样的话能够使得 $x$ 的十位变为个位，百位变为十位，以此类推。
- 直到 $x$ 为 $0$ 便可停止计算。

最后使用计算出的 $dig$ 来更新答案 $ans$ 即可。

注意到 $nums$ 中的每一个元素都不超过 $10^4$，初始 $ans$ 取一个大于 $36=4\times 9$ 的数即可。

```C++
class Solution {
public:
    int minElement(vector<int>& nums) {
        int ans = 37;
        for (int num : nums) {
            int dig = 0;
            while(num){
                dig += num % 10;
                num /= 10;
            }
            ans = min(ans, dig);
        }
        return ans;
    }
};
```

```Go
func minElement(nums []int) int {
    ans := 37
    for _, num := range nums {
        dig := 0
        n := num
        for n > 0 {
            dig += n % 10
            n /= 10
        }
        if dig < ans {
            ans = dig
        }
    }
    return ans
}
```

```Python
class Solution:
    def minElement(self, nums: List[int]) -> int:
        ans = 37
        for num in nums:
            dig = 0
            while num > 0:
                dig += num % 10
                num //= 10
            ans = min(ans, dig)
        return ans
```

```Java
class Solution {
    public int minElement(int[] nums) {
        int ans = 37;
        for (int num : nums) {
            int dig = 0;
            while (num > 0) {
                dig += num % 10;
                num /= 10;
            }
            ans = Math.min(ans, dig);
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public int MinElement(int[] nums) {
        int ans = 37;
        foreach (int num in nums) {
            int dig = 0;
            int n = num;
            while (n > 0) {
                dig += n % 10;
                n /= 10;
            }
            ans = Math.Min(ans, dig);
        }
        return ans;
    }
}
```

```C
int minElement(int* nums, int numsSize) {
    int ans = 37;
    for (int i = 0; i < numsSize; i++) {
        int num = nums[i];
        int dig = 0;
        while (num > 0) {
            dig += num % 10;
            num /= 10;
        }
        if (dig < ans) {
            ans = dig;
        }
    }
    return ans;
}
```

```JavaScript
function minElement(nums) {
    let ans = 37;
    for (const num of nums) {
        let dig = 0;
        let n = num;
        while (n > 0) {
            dig += n % 10;
            n = Math.floor(n / 10);
        }
        ans = Math.min(ans, dig);
    }
    return ans;
}
```

```TypeScript
function minElement(nums: number[]): number {
    let ans = 37;
    for (const num of nums) {
        let dig = 0;
        let n = num;
        while (n > 0) {
            dig += n % 10;
            n = Math.floor(n / 10);
        }
        ans = Math.min(ans, dig);
    }
    return ans;
}
```

```Rust
impl Solution {
    pub fn min_element(nums: Vec<i32>) -> i32 {
        let mut ans = 37;
        for num in nums {
            let mut dig = 0;
            let mut n = num;
            while n > 0 {
                dig += n % 10;
                n /= 10;
            }
            ans = ans.min(dig);
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n\log D)$，其中 $n$ 是数组 $nums$ 的长度，$D=max(nums[i])$。
- 空间复杂度：$O(1)$。
