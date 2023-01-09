#### [方法二：双指针](https://leetcode.cn/problems/merge-sorted-array/solutions/666608/he-bing-liang-ge-you-xu-shu-zu-by-leetco-rrb0/)

**算法**

方法一没有利用数组 $nums1$ 与 $nums2$ 已经被排序的性质。为了利用这一性质，我们可以使用双指针方法。这一方法将两个数组看作队列，每次从两个数组头部取出比较小的数字放到结果中。如下面的动画所示：

![](./assets/img/Solution0088_4_01.gif)

我们为两个数组分别设置一个指针 $p_1$ 与 $p_2$ 来作为队列的头部指针。代码实现如下：

```cpp
class Solution {
public:
    void merge(vector<int>& nums1, int m, vector<int>& nums2, int n) {
        int p1 = 0, p2 = 0;
        int sorted[m + n];
        int cur;
        while (p1 < m || p2 < n) {
            if (p1 == m) {
                cur = nums2[p2++];
            } else if (p2 == n) {
                cur = nums1[p1++];
            } else if (nums1[p1] < nums2[p2]) {
                cur = nums1[p1++];
            } else {
                cur = nums2[p2++];
            }
            sorted[p1 + p2 - 1] = cur;
        }
        for (int i = 0; i != m + n; ++i) {
            nums1[i] = sorted[i];
        }
    }
};
```

```java
class Solution {
    public void merge(int[] nums1, int m, int[] nums2, int n) {
        int p1 = 0, p2 = 0;
        int[] sorted = new int[m + n];
        int cur;
        while (p1 < m || p2 < n) {
            if (p1 == m) {
                cur = nums2[p2++];
            } else if (p2 == n) {
                cur = nums1[p1++];
            } else if (nums1[p1] < nums2[p2]) {
                cur = nums1[p1++];
            } else {
                cur = nums2[p2++];
            }
            sorted[p1 + p2 - 1] = cur;
        }
        for (int i = 0; i != m + n; ++i) {
            nums1[i] = sorted[i];
        }
    }
}
```

```python
class Solution:
    def merge(self, nums1: List[int], m: int, nums2: List[int], n: int) -> None:
        """
        Do not return anything, modify nums1 in-place instead.
        """
        sorted = []
        p1, p2 = 0, 0
        while p1 < m or p2 < n:
            if p1 == m:
                sorted.append(nums2[p2])
                p2 += 1
            elif p2 == n:
                sorted.append(nums1[p1])
                p1 += 1
            elif nums1[p1] < nums2[p2]:
                sorted.append(nums1[p1])
                p1 += 1
            else:
                sorted.append(nums2[p2])
                p2 += 1
        nums1[:] = sorted
```

```go
func merge(nums1 []int, m int, nums2 []int, n int) {
    sorted := make([]int, 0, m+n)
    p1, p2 := 0, 0
    for {
        if p1 == m {
            sorted = append(sorted, nums2[p2:]...)
            break
        }
        if p2 == n {
            sorted = append(sorted, nums1[p1:]...)
            break
        }
        if nums1[p1] < nums2[p2] {
            sorted = append(sorted, nums1[p1])
            p1++
        } else {
            sorted = append(sorted, nums2[p2])
            p2++
        }
    }
    copy(nums1, sorted)
}
```

```javascript
var merge = function(nums1, m, nums2, n) {
    let p1 = 0, p2 = 0;
    const sorted = new Array(m + n).fill(0);
    var cur;
    while (p1 < m || p2 < n) {
        if (p1 === m) {
            cur = nums2[p2++];
        } else if (p2 === n) {
            cur = nums1[p1++];
        } else if (nums1[p1] < nums2[p2]) {
            cur = nums1[p1++];
        } else {
            cur = nums2[p2++];
        }
        sorted[p1 + p2 - 1] = cur;
    }
    for (let i = 0; i != m + n; ++i) {
        nums1[i] = sorted[i];
    }
};
```

```c
void merge(int* nums1, int nums1Size, int m, int* nums2, int nums2Size, int n) {
    int p1 = 0, p2 = 0;
    int sorted[m + n];
    int cur;
    while (p1 < m || p2 < n) {
        if (p1 == m) {
            cur = nums2[p2++];
        } else if (p2 == n) {
            cur = nums1[p1++];
        } else if (nums1[p1] < nums2[p2]) {
            cur = nums1[p1++];
        } else {
            cur = nums2[p2++];
        }
        sorted[p1 + p2 - 1] = cur;
    }
    for (int i = 0; i != m + n; ++i) {
        nums1[i] = sorted[i];
    }
}
```

**复杂度分析**

-   时间复杂度：$O(m+n)$。 指针移动单调递增，最多移动 $m+n$ 次，因此时间复杂度为 $O(m+n)$。
-   空间复杂度：$O(m+n)$。 需要建立长度为 $m+n$ 的中间数组 $sorted$。
