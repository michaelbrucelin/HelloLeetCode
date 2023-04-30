#### [方法三：原地交换](https://leetcode.cn/problems/sort-array-by-parity/solutions/1449791/an-qi-ou-pai-xu-shu-zu-by-leetcode-solut-gpmm/)

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

-   时间复杂度：$O(n)$。原数组中每个元素只遍历一次。
-   空间复杂度：$O(1)$。原地排序，只消耗常数空间。
