### [找出与数组相加的整数 I](https://leetcode.cn/problems/find-the-integer-added-to-array-i/solutions/2869610/zhao-chu-yu-shu-zu-xiang-jia-de-zheng-sh-b1ei/)

#### 方法一：遍历

**思路与算法**

根据题意，我们需要找到一个整数 $x$，使得 $nums_1$ 中的每个数都与 $x$ 相加后，变得与 $nums_2$ 中的数字相同。显然，$nums_1$ 中最大的数字与 $x$ 相加后依然是最大的，因此：$x=max(nums_2)-max(nums_1)$。

**代码**

```Python
class Solution:
    def addedInteger(self, nums1: List[int], nums2: List[int]) -> int:
        return max(nums2) - max(nums1)
```

```C++
class Solution {
public:
    int addedInteger(vector<int>& nums1, vector<int>& nums2) {
        return (*max_element(nums2.begin(), nums2.end()) 
            - *max_element(nums1.begin(), nums1.end()));
    }
};
```

```Java
class Solution {
    public int addedInteger(int[] nums1, int[] nums2) {
        return Arrays.stream(nums2).min().getAsInt() - Arrays.stream(nums1).min().getAsInt();
    }
}
```

```CSharp
public class Solution {
    public int AddedInteger(int[] nums1, int[] nums2) {
        return nums2.Min() - nums1.Min();
    }
}
```

```C
int addedInteger(int* nums1, int nums1Size, int* nums2, int nums2Size) {
    int maxVal1 = 0, maxVal2 = 0;
    for (int i = 0; i < nums1Size; i++) {
        maxVal1 = fmax(maxVal1, nums1[i]);
    }
    for (int i = 0; i < nums2Size; i++) {
        maxVal2 = fmax(maxVal2, nums2[i]);
    }
    return maxVal2 - maxVal1;
}
```

```Go
func addedInteger(nums1 []int, nums2 []int) int {
    maxVal1, maxVal2  := 0, 0

    for _, num := range nums1 {
        if num > maxVal1 {
            maxVal1 = num
        }
    }
    for _, num := range nums2 {
        if num > maxVal2 {
            maxVal2 = num
        }
    }
    return maxVal2 - maxVal1
}
```

```JavaScript
var addedInteger = function(nums1, nums2) {
    return Math.max(...nums2) - Math.max(...nums1);
};
```

```TypeScript
function addedInteger(nums1: number[], nums2: number[]): number {
    return Math.max(...nums2) - Math.max(...nums1);
};
```

```Rust
impl Solution {
    pub fn added_integer(nums1: Vec<i32>, nums2: Vec<i32>) -> i32 {
        let max_num1 = *nums1.iter().max().unwrap_or(&i32::MIN);
        let max_num2 = *nums2.iter().max().unwrap_or(&i32::MAX);
        max_num2 - max_num1
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是 $nums_1$ 和 $nums_2$ 的长度。
- 空间复杂度：$O(1)$。
