### [按奇偶排序数组](https://leetcode.cn/problems/sort-array-by-parity/solutions/1449791/an-qi-ou-pai-xu-shu-zu-by-leetcode-solut-gpmm/)

#### 方法一：两次遍历

**思路**

新建一个数组 $res$ 用来保存排序完毕的数组。遍历两次 $nums$，第一次遍历时把所有偶数依次追加到 $res$ 中，第二次遍历时把所有奇数依次追加到 $res$ 中。

**代码**

```python
class Solution:
    def sortArrayByParity(self, nums: List[int]) -> List[int]:
        return [num for num in nums if num % 2 == 0] + [num for num in nums if num % 2 == 1]
```

```cpp
class Solution {
public:
    vector<int> sortArrayByParity(vector<int>& nums) {
        vector<int> res;
        for (auto & num : nums) {
            if (num % 2 == 0) {
                res.push_back(num);
            }
        }
        for (auto & num : nums) {
            if (num % 2 == 1) {
                res.push_back(num);
            }
        }
        return res;
    }
};
```

```java
class Solution {
    public int[] sortArrayByParity(int[] nums) {
        int n = nums.length, index = 0;
        int[] res = new int[n];
        for (int num : nums) {
            if (num % 2 == 0) {
                res[index++] = num;
            }
        }
        for (int num : nums) {
            if (num % 2 == 1) {
                res[index++] = num;
            }
        }
        return res;
    }
}
```

```csharp
public class Solution {
    public int[] SortArrayByParity(int[] nums) {
        int n = nums.Length, index = 0;
        int[] res = new int[n];
        foreach (int num in nums) {
            if (num % 2 == 0) {
                res[index++] = num;
            }
        }
        foreach (int num in nums) {
            if (num % 2 == 1) {
                res[index++] = num;
            }
        }
        return res;
    }
}
```

```c
int* sortArrayByParity(int* nums, int numsSize, int* returnSize) {
    int *res = (int *)malloc(sizeof(int) * numsSize), index = 0;
    for (int i = 0; i < numsSize; i++) {
        if (nums[i] % 2 == 0) {
            res[index++] = nums[i];
        }
    }
    for (int i = 0; i < numsSize; i++) {
        if (nums[i] % 2 == 1) {
            res[index++] = nums[i];
        }
    }
    *returnSize = numsSize;
    return res;
}
```

```go
func sortArrayByParity(nums []int) []int {
    ans := make([]int, 0, len(nums))
    for _, num := range nums {
        if num%2 == 0 {
            ans = append(ans, num)
        }
    }
    for _, num := range nums {
        if num%2 == 1 {
            ans = append(ans, num)
        }
    }
    return ans
}
```

```javascript
var sortArrayByParity = function(nums) {
    let n = nums.length, index = 0;
    const res = new Array(n).fill(0);
    for (const num of nums) {
        if (num % 2 === 0) {
            res[index++] = num;
        }
    }
    for (const num of nums) {
        if (num % 2 === 1) {
            res[index++] = num;
        }
    }
    return res;
};
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 为数组 $nums$ 的长度。需遍历 $nums$ 两次。
- 空间复杂度：$O(1)$。结果不计入空间复杂度。

#### 方法二：双指针 + 一次遍历

**思路**

记数组 $nums$ 的长度为 $n$。方法一需要遍历两次 $nums$，第一次遍历时遇到奇数会跳过，第二次遍历时遇到偶数会跳过，这部分可以优化。

新建一个长度为 $n$ 的数组 $res$ 用来保存排完序的数组。遍历一遍 $nums$，遇到偶数则从 $res$ 左侧开始替换元素，遇到奇数则从 $res$ 右侧开始替换元素。遍历完成后，$res$ 就保存了排序完毕的数组。

**代码**

```python
class Solution:
    def sortArrayByParity(self, nums: List[int]) -> List[int]:
        n = len(nums)
        res, left, right = [0] * n, 0, n - 1
        for num in nums:
            if num % 2 == 0:
                res[left] = num
                left += 1
            else:
                res[right] = num
                right -= 1
        return res
```

```cpp
class Solution {
public:
    vector<int> sortArrayByParity(vector<int>& nums) {
        int n = nums.size();
        vector<int> res(n);
        int left = 0, right = n - 1;
        for (auto & num : nums) {
            if (num % 2 == 0) {
                res[left++] = num;
            } else {
                res[right--] = num;
            }
        }
        return res;
    }
};
```

```java
class Solution {
    public int[] sortArrayByParity(int[] nums) {
        int n = nums.length;
        int[] res = new int[n];
        int left = 0, right = n - 1;
        for (int num : nums) {
            if (num % 2 == 0) {
                res[left++] = num;
            } else {
                res[right--] = num;
            }
        }
        return res;
    }
}
```

```csharp
public class Solution {
    public int[] SortArrayByParity(int[] nums) {
        int n = nums.Length;
        int[] res = new int[n];
        int left = 0, right = n - 1;
        foreach (int num in nums) {
            if (num % 2 == 0) {
                res[left++] = num;
            } else {
                res[right--] = num;
            }
        }
        return res;
    }
}
```

```c
int* sortArrayByParity(int* nums, int numsSize, int* returnSize) {
    int *res = (int *)malloc(sizeof(int) * numsSize);
    int left = 0, right = numsSize - 1;
    for (int i = 0; i < numsSize; i++) {
        if (nums[i] % 2 == 0) {
            res[left++] = nums[i];
        } else {
            res[right--] = nums[i];
        }
    }
    *returnSize = numsSize;
    return res;
}
```

```go
func sortArrayByParity(nums []int) []int {
    n := len(nums)
    ans := make([]int, n)
    left, right := 0, n-1
    for _, num := range nums {
        if num%2 == 0 {
            ans[left] = num
            left++
        } else {
            ans[right] = num
            right--
        }
    }
    return ans
}
```

```javascript
var sortArrayByParity = function(nums) {
    const n = nums.length;
    const res = new Array(n).fill(0);
    let left = 0, right = n - 1;
    for (const num of nums) {
        if (num % 2 === 0) {
            res[left++] = num;
        } else {
            res[right--] = num;
        }
    }
    return res;
};
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 为数组 $nums$ 的长度。只需遍历 $nums$ 一次。
- 空间复杂度：$O(1)$。结果不计入空间复杂度。

#### 方法三：原地交换

**思路**

记数组 $nums$ 的长度为 $n$。先从 $nums$ 左侧开始遍历，如果遇到的是偶数，就表示这个元素已经排好序了，继续从左往右遍历，直到遇到一个奇数。然后从 $nums$ 右侧开始遍历，如果遇到的是奇数，就表示这个元素已经排好序了，继续从右往左遍历，直到遇到一个偶数。交换这个奇数和偶数的位置，并且重复两边的遍历，直到在中间相遇，$nums$ 排序完毕。

**代码**

```python
class Solution:
    def sortArrayByParity(self, nums: List[int]) -> List[int]:
        left, right = 0, len(nums) - 1
        while left < right:
            while left < right and nums[left] % 2 == 0:
                left += 1
            while left < right and nums[right] % 2 == 1:
                right -= 1
            if left < right:
                nums[left], nums[right] = nums[right], nums[left]
                left += 1
                right -= 1
        return nums
```

```cpp
class Solution {
public:
    vector<int> sortArrayByParity(vector<int>& nums) {
        int left = 0, right = nums.size() - 1;
        while (left < right) {
            while (left < right and nums[left] % 2 == 0) {
                left++;
            }
            while (left < right and nums[right] % 2 == 1) {
                right--;
            }
            if (left < right) {
                swap(nums[left++], nums[right--]);
            }
        }
        return nums;
    }
};
```

```java
class Solution {
    public int[] sortArrayByParity(int[] nums) {
        int left = 0, right = nums.length - 1;
        while (left < right) {
            while (left < right && nums[left] % 2 == 0) {
                left++;
            }
            while (left < right && nums[right] % 2 == 1) {
                right--;
            }
            if (left < right) {
                int temp = nums[left];
                nums[left] = nums[right];
                nums[right] = temp;
                left++;
                right--;
            }
        }
        return nums;
    }
}
```

```csharp
public class Solution {
    public int[] SortArrayByParity(int[] nums) {
        int left = 0, right = nums.Length - 1;
        while (left < right) {
            while (left < right && nums[left] % 2 == 0) {
                left++;
            }
            while (left < right && nums[right] % 2 == 1) {
                right--;
            }
            if (left < right) {
                int temp = nums[left];
                nums[left] = nums[right];
                nums[right] = temp;
                left++;
                right--;
            }
        }
        return nums;
    }
}
```

```c
int* sortArrayByParity(int* nums, int numsSize, int* returnSize) {
    int left = 0, right = numsSize - 1;
    while (left < right) {
        while (left < right && nums[left] % 2 == 0) {
            left++;
        }
        while (left < right && nums[right] % 2 == 1) {
            right--;
        }
        if (left < right) {
            int tmp = nums[left];
            nums[left] = nums[right];
            nums[right] = tmp;
            left++;
            right--;
        }
    }
    *returnSize = numsSize;
    return nums;
}
```

```go
func sortArrayByParity(nums []int) []int {
    left, right := 0, len(nums)-1
    for left < right {
        for left < right && nums[left]%2 == 0 {
            left++
        }
        for left < right && nums[right]%2 == 1 {
            right--
        }
        if left < right {
            nums[left], nums[right] = nums[right], nums[left]
            left++
            right--
        }
    }
    return nums
}
```

```javascript
var sortArrayByParity = function(nums) {
    let left = 0, right = nums.length - 1;
    while (left < right) {
        while (left < right && nums[left] % 2 === 0) {
            left++;
        }
        while (left < right && nums[right] % 2 === 1) {
            right--;
        }
        if (left < right) {
            const temp = nums[left];
            nums[left] = nums[right];
            nums[right] = temp;
            left++;
            right--;
        }
    }
    return nums;
};
```

**复杂度分析**

- 时间复杂度：$O(n)$。原数组中每个元素只遍历一次。
- 空间复杂度：$O(1)$。原地排序，只消耗常数空间。
