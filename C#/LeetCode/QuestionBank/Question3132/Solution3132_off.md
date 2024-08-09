### [找出与数组相加的整数 II](https://leetcode.cn/problems/find-the-integer-added-to-array-ii/solutions/2869612/zhao-chu-yu-shu-zu-xiang-jia-de-zheng-sh-8k7t/)

#### 方法一：排序 + 枚举三种情况

**思路与算法**

我们首先将数组 $nums_1$ 和 $nums_2$ 中的元素都升序排序。记它们的长度分别是 $m$ 和 $n$，那么我们本质上需要找到一个长度为 $n$ 的序列：

$$0 \le id_0,id_1, \cdots ,id_{n-1}<m$$

它是严格递增的，并且对于每一个 $i (0 \le i<n)$，$nums_2[i]-nums_1[id_i]$ 的值都是相同的。在本题中，由于 $m=n+2$，那么 $id_0$ 必然等于 ${0,1,2}$ 其中的一个。这样一来，我们就可以对 $id_0$ 进行枚举了。

当我们确定了 $id_0$ 后，由于两个数组已经是有序的，我们就可以使用双指针的方法得到 $id_1, \cdots ,id_{n-1}$。具体地，两个指针 $left$ 和 $right$ 分别指向 $nums_1$ 和 $nums_2$ 中的元素下标，它们的初始值分别为 $id_0+1$ 和 $1$。在双指针遍历的过程中，如果有：

$$nums_1[left]-nums_2[right]=nums_1[id_0]-nums_2[0]$$

那么我们就找到了 $id_{right}=left$，我们可以将 $left$ 和 $right$ 均增加 $1$，否则只将 $left$ 增加 $1$。

当 $left$ 遍历完成后，如果 $right=n$，说明我们找到了 $id_0,id_1, \cdots ,id_{n-1}$，题目中需要求出的 $x$ 即为 $nums_2[0]-nums_1[id_0]$。由于我们需要求出最小的 $x$，而 $nums_1$ 是有序的，因此可以按照 ${2,1,0}$ 的顺序枚举 $id_0$，这样在找到 $x$ 时一定得到的就是最小的 $x$。

**代码**

```C++
class Solution {
public:
    int minimumAddedInteger(vector<int>& nums1, vector<int>& nums2) {
        int m = nums1.size(), n = nums2.size();
        sort(nums1.begin(), nums1.end());
        sort(nums2.begin(), nums2.end());
        for (int i: {2, 1, 0}) {
            int left = i + 1, right = 1;
            while (left < m && right < n) {
                if (nums1[left] - nums2[right] == nums1[i] - nums2[0]) {
                    ++right;
                }
                ++left;
            }
            if (right == n) {
                return nums2[0] - nums1[i];
            }
        }
        // 本题不会有无解的情况
        return 0;
    }
};
```

```Java
class Solution {
    public int minimumAddedInteger(int[] nums1, int[] nums2) {
        int m = nums1.length, n = nums2.length;
        Arrays.sort(nums1);
        Arrays.sort(nums2);
        for (int i: new int[]{2, 1, 0}) {
            int left = i + 1, right = 1;
            while (left < m && right < n) {
                if (nums1[left] - nums2[right] == nums1[i] - nums2[0]) {
                    ++right;
                }
                ++left;
            }
            if (right == n) {
                return nums2[0] - nums1[i];
            }
        }
        // 本题不会有无解的情况
        return 0;
    }
}
```

```CSharp
public class Solution {
    public int MinimumAddedInteger(int[] nums1, int[] nums2) {
        int m = nums1.Length, n = nums2.Length;
        Array.Sort(nums1);
        Array.Sort(nums2);
        foreach (int i in new int[]{2, 1, 0}) {
            int left = i + 1, right = 1;
            while (left < m && right < n) {
                if (nums1[left] - nums2[right] == nums1[i] - nums2[0]) {
                    ++right;
                }
                ++left;
            }
            if (right == n) {
                return nums2[0] - nums1[i];
            }
        }
        // 本题不会有无解的情况
        return 0;
    }
}
```

```Python
class Solution:
    def minimumAddedInteger(self, nums1: List[int], nums2: List[int]) -> int:
        m, n = len(nums1), len(nums2)
        nums1.sort()
        nums2.sort()
        for i in [2, 1, 0]:
            left, right = i + 1, 1
            while left < m and right < n:
                if nums1[left] - nums2[right] == nums1[i] - nums2[0]:
                    right += 1
                left += 1
            if right == n:
                return nums2[0] - nums1[i]
        # 本题不会有无解的情况
        return 0
```

```C
int compare(const void *a, const void *b) {
    return (*(int*)a - *(int*)b);
}

int minimumAddedInteger(int* nums1, int nums1Size, int* nums2, int nums2Size) {
    qsort(nums1, nums1Size, sizeof(int), compare);
    qsort(nums2, nums2Size, sizeof(int), compare);
    for (int i = 2; i >= 0; --i) {
        int left = i + 1, right = 1;
        while (left < nums1Size && right < nums2Size) {
            if (nums1[left] - nums2[right] == nums1[i] - nums2[0]) {
                ++right;
            }
            ++left;
        }
        if (right == nums2Size) {
            return nums2[0] - nums1[i];
        }
    }
    return 0;
}
```

```Go
func minimumAddedInteger(nums1 []int, nums2 []int) int {
    sort.Ints(nums1)
    sort.Ints(nums2)
    for i := 2; i >= 0; i-- {
        left, right := i + 1, 1
        for left < len(nums1) && right < len(nums2) {
            if nums1[left] - nums2[right] == nums1[i] - nums2[0] {
                right++
            }
            left++
        }
        if right == len(nums2) {
            return nums2[0] - nums1[i]
        }
    }
    return 0
}
```

```JavaScript
var minimumAddedInteger = function(nums1, nums2) {
    nums1.sort((a, b) => a - b);
    nums2.sort((a, b) => a - b);
    for (let i = 2; i >= 0; i--) {
        let left = i + 1, right = 1;
        while (left < nums1.length && right < nums2.length) {
            if (nums1[left] - nums2[right] === nums1[i] - nums2[0]) {
                right++;
            }
            left++;
        }
        if (right === nums2.length) {
            return nums2[0] - nums1[i];
        }
    }
    return 0;
};
```

```TypeScript
function minimumAddedInteger(nums1: number[], nums2: number[]): number {
    nums1.sort((a, b) => a - b);
    nums2.sort((a, b) => a - b);
    for (let i = 2; i >= 0; i--) {
        let left = i + 1, right = 1;
        while (left < nums1.length && right < nums2.length) {
            if (nums1[left] - nums2[right] === nums1[i] - nums2[0]) {
                right++;
            }
            left++;
        }
        if (right === nums2.length) {
            return nums2[0] - nums1[i];
        }
    }
    return 0;
};
```

```Rust
impl Solution {
    pub fn minimum_added_integer(nums1: Vec<i32>, nums2: Vec<i32>) -> i32 {
        let mut nums1 = nums1;
        let mut nums2 = nums2;
        nums1.sort();
        nums2.sort();
        for i in (0..=2).rev() {
            let (mut left, mut right) = (i as usize + 1, 1);
            while left < nums1.len() && right < nums2.len() {
                if nums1[left] - nums2[right] == nums1[i as usize] - nums2[0] {
                    right += 1;
                }
                left += 1;
            }
            if right == nums2.len() {
                return nums2[0] - nums1[i as usize];
            }
        }
        0
    }
}
```

**复杂度分析**

- 时间复杂度：$O(nlogn)$，其中 $n$ 是数组 $nums_2$ 的长度。
- 空间复杂度：$O(logn)$，即为排序需要使用的栈空间。
