### [统计和小于目标的下标对数目](https://leetcode.cn/problems/count-pairs-whose-sum-is-less-than-target/solutions/2477425/tong-ji-he-xiao-yu-mu-biao-de-xia-biao-d-dxmt/)

#### 方法一：枚举

**思路与算法**

根据意义要求，给定数字 $tagret$，找到所有满足 $j < i$ 且 $nums[i] + nums[j] < target$，可以直接枚举所有的下标对 $(i,j)$，检测该下标对对应的元素之和是否满足小于等于 $target$ 即可。

**代码**

```c++
class Solution {
public:
    int countPairs(vector<int>& nums, int target) {
        int res = 0;
        for (int i = 0; i < nums.size(); i++) {
            for (int j = i + 1; j < nums.size(); j++) {
                if (nums[i] + nums[j] < target) {
                    res++;
                }
            }
        }
        return res;
    }
};
```

```c
int countPairs(int* nums, int numsSize, int target) {
    int res = 0;
    for (int i = 0; i < numsSize; i++) {
        for (int j = i + 1; j < numsSize; j++) {
            if (nums[i] + nums[j] < target) {
                res++;
            }
        }
    }
    return res;
}
```

```java
class Solution {
    public int countPairs(List<Integer> nums, int target) {
        int res = 0;
        for (int i = 0; i < nums.size(); i++) {
            for (int j = i + 1; j < nums.size(); j++) {
                if (nums.get(i) + nums.get(j) < target) {
                    res++;
                }
            }
        }
        return res;
    }
}
```

```csharp
public class Solution {
    public int CountPairs(IList<int> nums, int target) {
        int res = 0;
        for (int i = 0; i < nums.Count; i++) {
            for (int j = i + 1; j < nums.Count; j++) {
                if (nums[i] + nums[j] < target) {
                    res++;
                }
            }
        }
        return res;
    }
}
```

```python
class Solution:
    def countPairs(self, nums: List[int], target: int) -> int:
        return sum(x + y < target for x, y in combinations(nums, 2))
```

```go
func countPairs(nums []int, target int) int {
    res := 0
    for i := 0; i < len(nums); i++ {
        for j := i + 1; j < len(nums); j++ {
            if nums[i] + nums[j] < target {
                res++
            }
        }
    }
    return res
}
```

```javascript
var countPairs = function(nums, target) {
    let res = 0;
    for (let i = 0; i < nums.length; i++) {
        for (let j = i + 1; j < nums.length; j++) {
            if (nums[i] + nums[j] < target) {
                res++;
            }
        }
    }
    return res;
};
```

**复杂度分析**

-   时间复杂度：$O(n^2)$，其中 $n$ 表示数组 $nums$ 的长度。一共最多有 $n^2$ 个下标对，因此遍历所有的下标对需要的时间为 $O(n^2)$。
-   空间复杂度：$O(1)$。

#### 方法二：二分查找

**思路与算法**

根据题目要求，我们只需找到满足要求的两个不同的下标对 $(i,j)$ 即可，此时只需要满足 $i \neq j$，因此对数组进行排序不影响最终的统计数目。将数组进行排序后，为了避免重复计算，对于给定的下标 $i$，只需要找到连续子数组 nums[0,⋯ ,i-1]nums[0,\cdots, i-1]nums[0,⋯,i-1] 中满足 $nums[i] + nums[j] < target$ 的下标 $j$ 的数目。我们可以依次枚举下标 $i$，并统计与当前下标 $i$ 的匹配要求的下标 $j$ 的数目。我们此时可以使用二分查找，找到区间 $[0,i-1]$ 中最小的下标 $k$，此时 $k$ 满足 $nums[k] + nums[i] \ge target$。由于数组为有序状态，则处于区间 $j \in [0,k-1]$ 的下标此时一定满足 $nums[i] + nums[j] < target$，此时符合要求的下标数目为 $k$。按照上述过程枚举所有的下标，并统计满足要求的下标数目之和即可。

**代码**

```c++
class Solution {
public:
    int countPairs(vector<int>& nums, int target) {
        sort(nums.begin(), nums.end());
        int res = 0;
        for (int i = 1; i < nums.size(); i++) {
            int k = lower_bound(nums.begin(), nums.begin() + i, target - nums[i]) - nums.begin();
            res += k;
        }
        return res;
    }
};
```

```c
static int cmp(const void *a, const void *b) {
    return *(int *)a - *(int *)b;
}

int binarySearch(const int *arr, int lo, int hi, int target) {
    int res = hi + 1;
    while (lo <= hi) {
        int mid = lo + (hi - lo) / 2;
        if (arr[mid] >= target) {
            res = mid;
            hi = mid - 1;
        } else {
            lo = mid + 1;
        }
    }
    return res;
}

int countPairs(int* nums, int numsSize, int target) {
    qsort(nums, numsSize, sizeof(int), cmp);
    int res = 0;
    for (int i = 1; i < numsSize; i++) {
        res += binarySearch(nums, 0, i - 1, target - nums[i]);
    }
    return res;
}
```

```java
class Solution {
    public int countPairs(List<Integer> nums, int target) {
        Collections.sort(nums);
        int res = 0;
        for (int i = 1; i < nums.size(); i++) {
            int k = binarySearch(nums, 0, i - 1, target - nums.get(i));
            res += k;
        }
        return res;
    }

    public int binarySearch(List<Integer> nums, int lo, int hi, int target) {
        int res = hi + 1;
        while (lo <= hi) {
            int mid = lo + (hi - lo) / 2;
            if (nums.get(mid) >= target) {
                res = mid;
                hi = mid - 1;
            } else {
                lo = mid + 1;
            }
        }
        return res;
    }
}
```

```csharp
public class Solution {
    public int CountPairs(IList<int> nums, int target) {
        ((List<int>) nums).Sort();
        int res = 0;
        for (int i = 1; i < nums.Count; i++) {
            int k = BinarySearch(nums, 0, i - 1, target - nums[i]);
            res += k;
        }
        return res;
    }

    public int BinarySearch(IList<int> nums, int lo, int hi, int target) {
        int res = hi + 1;
        while (lo <= hi) {
            int mid = lo + (hi - lo) / 2;
            if (nums[mid] >= target) {
                res = mid;
                hi = mid - 1;
            } else {
                lo = mid + 1;
            }
        }
        return res;
    }
}
```

```python
class Solution:
    def countPairs(self, nums: List[int], target: int) -> int:
        nums.sort()
        return sum(bisect_left(nums, target - nums[i], 0, i) for i in range(1, len(nums)))
```

```go
func countPairs(nums []int, target int) int {
    sort.Ints(nums)
    res := 0
    for i := 1; i < len(nums); i++ {
        res += sort.SearchInts(nums[0:i], target - nums[i])
    }
    return res
}
```

```javascript
var countPairs = function(nums, target) {
    function binarySearch(nums, lo, hi, target) {
        let res = hi + 1;
        while (lo <= hi) {
            const mid = lo + Math.floor((hi - lo) / 2);
            if (nums[mid] >= target) {
                res = mid;
                hi = mid - 1;
            } else {
                lo = mid + 1;
            }
        }
        return res;
    }
    nums.sort((a, b) => a - b);
    let res = 0;
    for (let i = 0; i < nums.length; i++) {
        res += binarySearch(nums, 0, i - 1, target - nums[i]);
    }
    return res;
};
```

**复杂度分析**

-   时间复杂度：$O(n \log n)$，其中 $n$ 表示数组 $nums$ 的长度。排序需要的时间复为 $O(n \log n)$，每次进行二分查找需要的时间为 $O(\log n)$，一共需要进行 $n$ 次二分查找，因此总的时间复杂度为 $O(n\log n)$。
-   空间复杂度：$O(\log n)$，其中 $n$ 表示数组 $nums$ 的长度。排序需要的空间为 $O(\log n)$，除此以外不需要额外的空间。

#### 方法三：双指针

**思路与算法**

根据题目要求，我们只需找到满足要求的两个不同的下标对 $(i,j)$ 即可。设当前数组的长度为 $n$，将数组进行排序后，对于给定的下标 $i$，只需要找到连续子数组 $nums[i + 1,\cdots, n-1]$ 中满足 $nums[i] + nums[j] < target$ 的下标 $j$ 的数目。如果 $i < j$ 且满足 $nums[i] + nums[j] < target$ 时，则此时 $i$ 与区间 $[i + 1, j]$ 之间的下标都能组成合法的下标对，我们可以参考题目「[三数之和](https://leetcode.cn/problems/3sum/solutions/284681/san-shu-zhi-he-by-leetcode-solution/)」中的「双指针」思想，每次固定左 $i$ 时，此时 $nums[j]$ 需要缩小，$j$ 需要往前移动，直到找到满足 $nums[i] + nums[j] < target$ 为止，此时满足题意且含有下标 $i$ 的下标对数目为 $j - i$，按照上述策略找到所有符合要求的下标对即可。

**双指针**遍历过程如下：

-   初始化时 $i$ 指向数组最左侧，$j$ 指向数组最右侧，此时 $i = 0, j = n - 1$；
-   如果 $nums[i] + nums[j] \ge target$，此时需要缩小 $nums[j]$，将 $j$ 往前移动，直到满足 $nums[i] + nums[j] < target$ 为止，此时有 $j - i$ 个合法的下标对，将其加入到结果中，然后将 $i$ 往后移动一个位置。
-   重复上述过程直到 $j = i$ 结束。

**代码**

```c++
class Solution {
public:
    int countPairs(vector<int>& nums, int target) {
        sort(nums.begin(), nums.end());
        int res = 0;
        for (int i = 0, j = nums.size() - 1; i < j; i++) {
            while (i < j && nums[i] + nums[j] >= target) {
                j--;
            }
            res += j - i;
        }
        return res;
    }
};
```

```c
static int cmp(const void *a, const void *b) {
    return *(int *)a - *(int *)b;
}

int countPairs(int* nums, int numsSize, int target) {
    qsort(nums, numsSize, sizeof(int), cmp);
    int res = 0;
    for (int i = 0, j = numsSize - 1; i < j; i++) {
        while (i < j && nums[i] + nums[j] >= target) {
            j--;
        }
        res += j - i;
    }
    return res;
}
```

```java
class Solution {
    public int countPairs(List<Integer> nums, int target) {
        Collections.sort(nums);
        int res = 0;
        for (int i = 0, j = nums.size() - 1; i < j; i++) {
            while (i < j && nums.get(i) + nums.get(j) >= target) {
                j--;
            }
            res += j - i;
        }
        return res;
    }
}
```

```csharp
public class Solution {
    public int CountPairs(IList<int> nums, int target) {
        ((List<int>) nums).Sort();
        int res = 0;
        for (int i = 0, j = nums.Count - 1; i < j; i++) {
            while (i < j && nums[i] + nums[j] >= target) {
                j--;
            }
            res += j - i;
        }
        return res;
    }
}
```

```python
class Solution:
    def countPairs(self, nums: List[int], target: int) -> int:
        nums.sort()
        i, j = 0, len(nums) - 1
        res = 0
        while i < j:
            while i < j and nums[i] + nums[j] >= target:
                j -= 1
            res += j - i
            i += 1
        return res
```

```go
func countPairs(nums []int, target int) int {
    sort.Ints(nums)
    res := 0
    for i, j := 0, len(nums) - 1; i < j; i++ {
        for i < j &&  nums[i] + nums[j] >= target {
            j--
        }
        res += j - i
    }
    return res
}
```

```javascript
var countPairs = function(nums, target) {
    nums.sort((a, b) => a - b);
    let res = 0;
    for (let i = 0, j = nums.length - 1; i < j; i++) {
        while (i < j && nums[i] + nums[j] >= target) {
            j--;
        }
        res += j - i;
    }
    return res;
};
```

**复杂度分析**

-   时间复杂度：$O(n \log n)$，其中 $n$ 表示数组 $nums$ 的长度。排序需要的时间复为 $O(n \log n)$，双指针遍历需要的时间为 $O(n)$，因此总的时间复杂度为 $O(n\log n)$。
-   空间复杂度：$O(\log n)$，其中 $n$ 表示数组 $nums$ 的长度。排序需要的空间为 $O(\log n)$，除此以外不需要额外的空间。
