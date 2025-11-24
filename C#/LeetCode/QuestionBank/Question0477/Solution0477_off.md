### [汉明距离总和](https://leetcode.cn/problems/total-hamming-distance/solutions/798048/yi-ming-ju-chi-zong-he-by-leetcode-solut-t0ev/)

#### 方法一：逐位统计

在计算汉明距离时，我们考虑的是同一比特位上的值是否不同，而不同比特位之间是互不影响的。

对于数组 $nums$ 中的某个元素 $val$，若其二进制的第 $i$ 位为 $1$，我们只需统计 $nums$ 中有多少元素的第 $i$ 位为 $0$，即计算出了 $val$ 与其他元素在第 $i$ 位上的汉明距离之和。

具体地，若长度为 $n$ 的数组 $nums$ 的所有元素二进制的第 $i$ 位共有 $c$ 个 $1$，$n-c$ 个 $0$，则些元素在二进制的第 $i$ 位上的汉明距离之和为

$$c\cdot (n-c)$$

我们可以从二进制的最低位到最高位，逐位统计汉明距离。将每一位上得到的汉明距离累加即为答案。

具体实现时，对于整数 $val$ 二进制的第 $i$ 位，我们可以用代码 `(val >> i) & 1` 来取出其第 $i$ 位的值。此外，由于 $10^9<2^{30}$，我们可以直接从二进制的第 $0$ 位枚举到第 $29$ 位。

```C++
class Solution {
public:
    int totalHammingDistance(vector<int> &nums) {
        int ans = 0, n = nums.size();
        for (int i = 0; i < 30; ++i) {
            int c = 0;
            for (int val : nums) {
                c += (val >> i) & 1;
            }
            ans += c * (n - c);
        }
        return ans;
    }
};
```

```Java
class Solution {
    public int totalHammingDistance(int[] nums) {
        int ans = 0, n = nums.length;
        for (int i = 0; i < 30; ++i) {
            int c = 0;
            for (int val : nums) {
                c += (val >> i) & 1;
            }
            ans += c * (n - c);
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public int TotalHammingDistance(int[] nums) {
        int ans = 0, n = nums.Length;
        for (int i = 0; i < 30; ++i) {
            int c = 0;
            foreach (int val in nums) {
                c += (val >> i) & 1;
            }
            ans += c * (n - c);
        }
        return ans;
    }
}
```

```Go
func totalHammingDistance(nums []int) (ans int) {
    n := len(nums)
    for i := 0; i < 30; i++ {
        c := 0
        for _, val := range nums {
            c += val >> i & 1
        }
        ans += c * (n - c)
    }
    return
}
```

```Python
class Solution:
    def totalHammingDistance(self, nums: List[int]) -> int:
        n = len(nums)
        ans = 0
        for i in range(30):
            c = sum(((val >> i) & 1) for val in nums)
            ans += c * (n - c)
        return ans
```

```C
int totalHammingDistance(int* nums, int numsSize) {
    int ans = 0;
    for (int i = 0; i < 30; ++i) {
        int c = 0;
        for (int j = 0; j < numsSize; ++j) {
            c += (nums[j] >> i) & 1;
        }
        ans += c * (numsSize - c);
    }
    return ans;
}
```

```JavaScript
var totalHammingDistance = function(nums) {
    let ans = 0, n = nums.length;
    for (let i = 0; i < 30; ++i) {
        let c = 0;
        for (const val of nums) {
            c += (val >> i) & 1;
        }
        ans += c * (n - c);
    }
    return ans;
};
```

**复杂度分析**

- 时间复杂度：$O(n\cdot L)$。其中 $n$ 是数组 $nums$ 的长度，$L=30$。
- 空间复杂度：$O(1)$。
