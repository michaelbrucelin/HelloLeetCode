#### [方法四：数字电路设计优化](https://leetcode.cn/problems/single-number-ii/solutions/746993/zhi-chu-xian-yi-ci-de-shu-zi-ii-by-leetc-23t6/?orderBy=hot)

**思路与算法**

我们发现方法三中计算 bbb 的规则较为简单，而 aaa 的规则较为麻烦，因此可以将「同时计算」改为「分别计算」，即先计算出 bbb，再拿新的 bbb 值计算 aaa。

对于原始的真值表：

| (ai bi)(a\_i ~ b\_i)(ai bi) | xix\_ixi | 新的 (ai bi)(a\_i ~ b\_i)(ai bi) |
| --- | --- | --- |
| 000000 | 000 | 000000 |
| 000000 | 111 | 010101 |
| 010101 | 000 | 010101 |
| 010101 | 111 | 101010 |
| 101010 | 000 | 101010 |
| 101010 | 111 | 000000 |

我们将第一列的 bib\_ibi 替换新的 bib\_ibi 即可得到：

| (ai,(a\_i,(ai, 新的 bi)b\_i)bi) | xix\_ixi | 新的 aia\_iai |
| --- | --- | --- |
| 000000 | 000 | 000 |
| 010101 | 111 | 000 |
| 010101 | 000 | 000 |
| 000000 | 111 | 111 |
| 101010 | 000 | 111 |
| 101010 | 111 | 000 |

根据真值表可以设计出电路：

ai=ai′bi′xi+aibi′xi′=bi′(ai⊕xi) a\_i = a\_i'b\_i'x\_i + a\_ib\_i'x\_i' = b\_i'(a\_i \\oplus x\_i) ai\=ai′bi′xi+aibi′xi′\=bi′(ai⊕xi)

这样就与 bib\_ibi 的电路逻辑非常类似了。最终的转换规则即为：

{b = ~a & (b ˆx)a = ~b & (a ˆx) \\begin{cases} \\texttt{b = \\textasciitilde a \\& (b\\^ x)} \\\\ \\texttt{a = \\textasciitilde b \\& (a\\^ x)} \\end{cases} {b = ~a & (b ˆx)a = ~b & (a ˆx)

需要注意先计算 bbb，再计算 aaa。

**代码**

```cpp
class Solution {
public:
    int singleNumber(vector<int>& nums) {
        int a = 0, b = 0;
        for (int num: nums) {
            b = ~a & (b ^ num);
            a = ~b & (a ^ num);
        }
        return b;
    }
};
```

```java
class Solution {
    public int singleNumber(int[] nums) {
        int a = 0, b = 0;
        for (int num : nums) {
            b = ~a & (b ^ num);
            a = ~b & (a ^ num);
        }
        return b;
    }
}
```

```python
class Solution:
    def singleNumber(self, nums: List[int]) -> int:
        a = b = 0
        for num in nums:
            b = ~a & (b ^ num)
            a = ~b & (a ^ num)
        return b
```

```javascript
var singleNumber = function(nums) {
    let a = 0, b = 0;
    for (const num of nums) {
        b = ~a & (b ^ num);
        a = ~b & (a ^ num);
    }
    return b;
};
```

```go
func singleNumber(nums []int) int {
    a, b := 0, 0
    for _, num := range nums {
        b = (b ^ num) &^ a
        a = (a ^ num) &^ b
    }
    return b
}
```

```c
int singleNumber(int *nums, int numsSize) {
    int a = 0, b = 0;
    for (int i = 0; i < numsSize; i++) {
        b = ~a & (b ^ nums[i]);
        a = ~b & (a ^ nums[i]);
    }
    return b;
}
```

**复杂度分析**

-   时间复杂度：$O(n)$，其中 $n$ 是数组的长度。
-   空间复杂度：$O(1)$。
