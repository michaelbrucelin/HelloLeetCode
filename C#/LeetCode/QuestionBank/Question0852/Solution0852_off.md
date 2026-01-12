### [山脉数组的峰顶索引](https://leetcode.cn/problems/peak-index-in-a-mountain-array/solutions/828156/shan-mai-shu-zu-de-feng-ding-suo-yin-by-dtqvv/)

#### 前言

虽然题目描述中说明了「我们可以返回**任何**满足条件的下标 i」，但由于条件为：

$$arr_0<arr_1<\dots arr_{i-1}<arr_i>arr_{i+1}>\dots >arr_{n-1}$$

其中 $n$ 是数组 $arr$ 的长度，这说明 $arr_i$ 是数组中的最大值，并且是**唯一**的最大值。

因此，我们需要找出的下标 $i$ 一定是**唯一**的。

#### 方法一：枚举

**思路与算法**

我们可以对数组 $arr$ 进行一次遍历。

当我们遍历到下标 $i$ 时，如果有 $arr_{i-1}<arr_i>arr_{i+1}$，那么 $i$ 就是我们需要找出的下标。

更简单地，我们只需要让 $i$ 满足 $arr_i>arr_{i+1}$ 即可。在遍历的过程中，我们最先遍历到的满足 $arr_i>arr_{i+1}$ 的下标 $i$ 一定也满足 $arr_{i-1}<arr_i$。

**代码**

```C++
class Solution {
public:
    int peakIndexInMountainArray(vector<int>& arr) {
        int n = arr.size();
        int ans = -1;
        for (int i = 1; i < n - 1; ++i) {
            if (arr[i] > arr[i + 1]) {
                ans = i;
                break;
            }
        }
        return ans;
    }
};
```

```Java
class Solution {
    public int peakIndexInMountainArray(int[] arr) {
        int n = arr.length;
        int ans = -1;
        for (int i = 1; i < n - 1; ++i) {
            if (arr[i] > arr[i + 1]) {
                ans = i;
                break;
            }
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public int PeakIndexInMountainArray(int[] arr) {
        int n = arr.Length;
        int ans = -1;
        for (int i = 1; i < n - 1; ++i) {
            if (arr[i] > arr[i + 1]) {
                ans = i;
                break;
            }
        }
        return ans;
    }
}
```

```Python
class Solution:
    def peakIndexInMountainArray(self, arr: List[int]) -> int:
        n = len(arr)
        ans = -1

        for i in range(1, n - 1):
            if arr[i] > arr[i + 1]:
                ans = i
                break

        return ans
```

```JavaScript
var peakIndexInMountainArray = function(arr) {
    const n = arr.length;
    let ans = -1;

    for (let i = 1; i < n - 1; ++i) {
        if (arr[i] > arr[i + 1]) {
            ans = i;
            break;
        }
    }
    return ans;
};
```

```Go
func peakIndexInMountainArray(arr []int) int {
    for i := 1; ; i++ {
        if arr[i] > arr[i+1] {
            return i
        }
    }
}
```

```C
int peakIndexInMountainArray(int* arr, int arrSize) {
    int n = arrSize;
    int ans = -1;
    for (int i = 1; i < n - 1; ++i) {
        if (arr[i] > arr[i + 1]) {
            ans = i;
            break;
        }
    }
    return ans;
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是数组 $arr$ 的长度。我们最多需要对数组 $arr$ 进行一次遍历。
- 空间复杂度：$O(1)$。

#### 方法二：二分查找

**思路与算法**

记满足题目要求的下标 $i$ 为 $i_{ans}$。我们可以发现：

- 当 $i<i_{ans}$ 时，$arr_i<arr_{i+1}$ 恒成立；
- 当 $i\ge i_{ans}$ 时，$arr_i>arr_{i+1}$ 恒成立。

这与方法一的遍历过程也是一致的，因此 $i_{ans}$ 即为「最小的满足 $arr_i>arr_{i+1}$ 的下标 $i$」，我们可以用二分查找的方法来找出 $i_{ans}$。

**代码**

```C++
class Solution {
public:
    int peakIndexInMountainArray(vector<int>& arr) {
        int n = arr.size();
        int left = 1, right = n - 2, ans = 0;
        while (left <= right) {
            int mid = (left + right) / 2;
            if (arr[mid] > arr[mid + 1]) {
                ans = mid;
                right = mid - 1;
            }
            else {
                left = mid + 1;
            }
        }
        return ans;
    }
};
```

```Java
class Solution {
    public int peakIndexInMountainArray(int[] arr) {
        int n = arr.length;
        int left = 1, right = n - 2, ans = 0;
        while (left <= right) {
            int mid = (left + right) / 2;
            if (arr[mid] > arr[mid + 1]) {
                ans = mid;
                right = mid - 1;
            } else {
                left = mid + 1;
            }
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public int PeakIndexInMountainArray(int[] arr) {
        int n = arr.Length;
        int left = 1, right = n - 2, ans = 0;
        while (left <= right) {
            int mid = (left + right) / 2;
            if (arr[mid] > arr[mid + 1]) {
                ans = mid;
                right = mid - 1;
            } else {
                left = mid + 1;
            }
        }
        return ans;
    }
}
```

```Python
class Solution:
    def peakIndexInMountainArray(self, arr: List[int]) -> int:
        n = len(arr)
        left, right, ans = 1, n - 2, 0

        while left <= right:
            mid = (left + right) // 2
            if arr[mid] > arr[mid + 1]:
                ans = mid
                right = mid - 1
            else:
                left = mid + 1

        return ans
```

```JavaScript
var peakIndexInMountainArray = function(arr) {
    const n = arr.length;
    let left = 1, right = n - 2, ans = 0;

    while (left <= right) {
        const mid = Math.floor((left + right) /2 );
        if (arr[mid] > arr[mid + 1]) {
            ans = mid;
            right = mid - 1;
        } else {
            left = mid + 1;
        }
    }
    return ans;
};
```

```Go
func peakIndexInMountainArray(arr []int) int {
    return sort.Search(len(arr)-1, func(i int) bool { return arr[i] > arr[i+1] })
}
```

```C
int peakIndexInMountainArray(int* arr, int arrSize) {
    int n = arrSize;
    int left = 1, right = n - 2, ans = 0;
    while (left <= right) {
        int mid = (left + right) / 2;
        if (arr[mid] > arr[mid + 1]) {
            ans = mid;
            right = mid - 1;
        } else {
            left = mid + 1;
        }
    }
    return ans;
}
```

**复杂度分析**

- 时间复杂度：$O(\log n)$，其中 $n$ 是数组 $arr$ 的长度。我们需要进行二分查找的次数为 $O(\log n)$。
- 空间复杂度：$O(1)$。
