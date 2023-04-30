#### [����һ��˫ָ��](https://leetcode.cn/problems/move-zeroes/solutions/489622/yi-dong-ling-by-leetcode-solution/)

**˼·���ⷨ**

ʹ��˫ָ�룬��ָ��ָ��ǰ�Ѿ�����õ����е�β������ָ��ָ����������е�ͷ����

��ָ�벻�������ƶ���ÿ����ָ��ָ���������������ָ���Ӧ����������ͬʱ��ָ�����ơ�

ע�⵽�������ʣ�

1.  ��ָ����߾�Ϊ��������
2.  ��ָ�����ֱ����ָ�봦��Ϊ�㡣

���ÿ�ν��������ǽ���ָ���������ָ��ķ������������ҷ����������˳��δ�ı䡣

**����**

```cpp
class Solution {
public:
    void moveZeroes(vector<int>& nums) {
        int n = nums.size(), left = 0, right = 0;
        while (right < n) {
            if (nums[right]) {
                swap(nums[left], nums[right]);
                left++;
            }
            right++;
        }
    }
};
```

```java
class Solution {
    public void moveZeroes(int[] nums) {
        int n = nums.length, left = 0, right = 0;
        while (right < n) {
            if (nums[right] != 0) {
                swap(nums, left, right);
                left++;
            }
            right++;
        }
    }

    public void swap(int[] nums, int left, int right) {
        int temp = nums[left];
        nums[left] = nums[right];
        nums[right] = temp;
    }
}
```

```python
class Solution:
    def moveZeroes(self, nums: List[int]) -> None:
        n = len(nums)
        left = right = 0
        while right < n:
            if nums[right] != 0:
                nums[left], nums[right] = nums[right], nums[left]
                left += 1
            right += 1
```

```go
func moveZeroes(nums []int) {
    left, right, n := 0, 0, len(nums)
    for right < n {
        if nums[right] != 0 {
            nums[left], nums[right] = nums[right], nums[left]
            left++
        }
        right++
    }
}
```

```c
void swap(int *a, int *b) {
    int t = *a;
    *a = *b, *b = t;
}

void moveZeroes(int *nums, int numsSize) {
    int left = 0, right = 0;
    while (right < numsSize) {
        if (nums[right]) {
            swap(nums + left, nums + right);
            left++;
        }
        right++;
    }
}
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(n)$������ $n$ Ϊ���г��ȡ�ÿ��λ�����౻�������Ρ�
-   �ռ临�Ӷȣ�$O(1)$��ֻ��Ҫ�����Ŀռ������ɱ�����
