### [构造奇偶一致的数组 I](https://leetcode.cn/problems/construct-uniform-parity-array-i/solutions/4018999/gou-zao-qi-ou-yi-zhi-de-shu-zu-i-by-leet-pkx8/)

#### 方法一：数学分析

**思路与算法**

本题只需要进行简单的奇偶性分析即可得到答案。

我们记数组 $nums_1$ 的长度为 $n$，题目要求构造 $nums_2$ 使得其中所有元素的奇偶性相同（全为奇数或全为偶数）。

考虑以下两种情况：

1. $nums_1$ 全为奇数或全为偶数：此时直接令 $nums_2[i]=nums_1[i]$（即对所有下标 $i$ 都使用第一种操作），得到的 $nums_2$ 与原数组相同，自然满足条件。
2. $nums_1$ 中既有奇数也有偶数：由于偶数减奇数得奇数，我们可以任选 $nums_1$ 中的一个奇数 $x$，然后按以下方式构造 $nums_2$：
    - 若 $nums_1[i]$ 为奇数，则 $nums_2[i]=nums_1[i]$（第一种操作）。
    - 若 $nums_1[i]$ 为偶数，则 $nums_2[i]=nums_1[i]-x$（第二种操作，选择 $j$ 满足 $nums_1[j]=x$）。

此时 $nums_2$ 中的所有元素均为奇数，满足题目要求。

综上所述，对于任意满足题目条件的输入，我们总可以构造出合法的 $nums_2$，因此答案恒为 $true$。

**代码**

```C++
class Solution {
public:
    bool uniformArray(vector<int>& nums1) {
        return true;
    }
};
```

```Go
func uniformArray(nums1 []int) bool {
    return true
}
```

```Python
class Solution:
    def uniformArray(self, nums1: list[int]) -> bool:
        return True
```

```Java
class Solution {
    public boolean uniformArray(int[] nums1) {
        return true;
    }
}
```

```TypeScript
function uniformArray(nums1: number[]): boolean {
    return true;
}
```

```JavaScript
var uniformArray = function(nums1) {
    return true;
};
```

```CSharp
public class Solution {
    public bool UniformArray(int[] nums1) {
        return true;
    }
}
```

```C
bool uniformArray(int* nums1, int nums1Size) {
    return true;
}
```

```Rust
impl Solution {
    pub fn uniform_array(nums1: Vec<i32>) -> bool {
        true
    }
}
```

**复杂度分析**

- 时间复杂度：$O(1)$。直接返回结果，不依赖输入规模。
- 空间复杂度：$O(1)$。仅使用常数级额外空间。
