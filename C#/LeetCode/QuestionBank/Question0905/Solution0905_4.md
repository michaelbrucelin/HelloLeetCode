#### [��������ԭ�ؽ���](https://leetcode.cn/problems/sort-array-by-parity/solutions/1449791/an-qi-ou-pai-xu-shu-zu-by-leetcode-solut-gpmm/)

**˼·**

������ $nums$ �ĳ���Ϊ $n$���ȴ� $nums$ ��࿪ʼ�����������������ż�����ͱ�ʾ���Ԫ���Ѿ��ź����ˣ������������ұ�����ֱ������һ��������Ȼ��� $nums$ �Ҳ࿪ʼ������������������������ͱ�ʾ���Ԫ���Ѿ��ź����ˣ������������������ֱ������һ��ż�����������������ż����λ�ã������ظ����ߵı�����ֱ�����м�������$nums$ ������ϡ�

**����**

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

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(n)$��ԭ������ÿ��Ԫ��ֻ����һ�Ρ�
-   �ռ临�Ӷȣ�$O(1)$��ԭ������ֻ���ĳ����ռ䡣
