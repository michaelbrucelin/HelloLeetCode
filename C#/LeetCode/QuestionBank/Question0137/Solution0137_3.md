#### [方法二：依次确定每一个二进制位](https://leetcode.cn/problems/single-number-ii/solutions/746993/zhi-chu-xian-yi-ci-de-shu-zi-ii-by-leetc-23t6/?orderBy=hot)

**思路与算法**

为了方便叙述，我们称「只出现了一次的元素」为「答案」。

由于数组中的元素都在 $int$（即 $32$ 位整数）范围内，因此我们可以依次计算答案的每一个二进制位是 $0$ 还是 $1$。

具体地，考虑答案的第 $i$ 个二进制位（$i$ 从 $0$ 开始编号），它可能为 $0$ 或 $1$。对于数组中非答案的元素，每一个元素都出现了 $3$ 次，对应着第 $i$ 个二进制位的 $3$ 个 $0$ 或 $3$ 个 $1$，无论是哪一种情况，它们的和都是 $3$ 的倍数（即和为 $0$ 或 $3$）。因此：

> 答案的第 $i$ 个二进制位就是数组中所有元素的第 $i$ 个二进制位之和除以 $3$ 的余数。

这样一来，对于数组中的每一个元素 $x$，我们使用位运算 $(x >> i) \& 1$ 得到 $x$ 的第 $i$ 个二进制位，并将它们相加再对 $3$ 取余，得到的结果一定为 $0$ 或 111，即为答案的第 $i$ 个二进制位。

**细节**

需要注意的是，如果使用的语言对「有符号整数类型」和「无符号整数类型」没有区分，那么可能会得到错误的答案。这是因为「有符号整数类型」（即 $int$ 类型）的第 $31$ 个二进制位（即最高位）是补码意义下的符号位，对应着 $-2^{31}$，而「无符号整数类型」由于没有符号，第 $31$ 个二进制位对应着 $2^{31}$。因此在某些语言（例如 `Python`）中需要对最高位进行特殊判断。

**代码**

```cpp
class Solution {
public:
    int singleNumber(vector<int>& nums) {
        int ans = 0;
        for (int i = 0; i < 32; ++i) {
            int total = 0;
            for (int num: nums) {
                total += ((num >> i) & 1);
            }
            if (total % 3) {
                ans |= (1 << i);
            }
        }
        return ans;
    }
};
```

```java
class Solution {
    public int singleNumber(int[] nums) {
        int ans = 0;
        for (int i = 0; i < 32; ++i) {
            int total = 0;
            for (int num: nums) {
                total += ((num >> i) & 1);
            }
            if (total % 3 != 0) {
                ans |= (1 << i);
            }
        }
        return ans;
    }
}
```

```python
class Solution:
    def singleNumber(self, nums: List[int]) -> int:
        ans = 0
        for i in range(32):
            total = sum((num >> i) & 1 for num in nums)
            if total % 3:
                # Python 这里对于最高位需要特殊判断
                if i == 31:
                    ans -= (1 << i)
                else:
                    ans |= (1 << i)
        return ans
```

```javascript
var singleNumber = function(nums) {
    let ans = 0;
    for (let i = 0; i < 32; ++i) {
        let total = 0;
        for (const num of nums) {
            total += ((num >> i) & 1);
        }
        if (total % 3 != 0) {
            ans |= (1 << i);
        }
    }
    return ans;
};
```

```go
func singleNumber(nums []int) int {
    ans := int32(0)
    for i := 0; i < 32; i++ {
        total := int32(0)
        for _, num := range nums {
            total += int32(num) >> i & 1
        }
        if total%3 > 0 {
            ans |= 1 << i
        }
    }
    return int(ans)
}
```

```c
int singleNumber(int *nums, int numsSize) {
    int ans = 0;
    for (int i = 0; i < 32; ++i) {
        int total = 0;
        for (int j = 0; j < numsSize; ++j) {
            total += ((nums[j] >> i) & 1);
        }
        if (total % 3) {
            ans |= (1u << i);
        }
    }
    return ans;
}
```

**复杂度分析**

-   时间复杂度：$O(n \log C)$，其中 $n$ 是数组的长度，$C$ 是元素的数据范围，在本题中 $\log C=\log 2^{32} = 32$，也就是我们需要遍历第 $0 \sim 31$ 个二进制位。
-   空间复杂度：$O(1)$。
