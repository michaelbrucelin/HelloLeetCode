#### [方法一：直接排序](https://leetcode.cn/problems/squares-of-a-sorted-array/solutions/447736/you-xu-shu-zu-de-ping-fang-by-leetcode-solution/)

**思路与算法**

最简单的方法就是将数组 $nums$ 中的数平方后直接排序。

**代码**

```cpp
class Solution {
public:
    vector<int> sortedSquares(vector<int>& nums) {
        vector<int> ans;
        for (int num: nums) {
            ans.push_back(num * num);
        }
        sort(ans.begin(), ans.end());
        return ans;
    }
};
```

```java
class Solution {
    public int[] sortedSquares(int[] nums) {
        int[] ans = new int[nums.length];
        for (int i = 0; i < nums.length; ++i) {
            ans[i] = nums[i] * nums[i];
        }
        Arrays.sort(ans);
        return ans;
    }
}
```

```python
class Solution:
    def sortedSquares(self, nums: List[int]) -> List[int]:
        return sorted(num * num for num in nums)
```

```go
func sortedSquares(nums []int) []int {
    ans := make([]int, len(nums))
    for i, v := range nums {
        ans[i] = v * v
    }
    sort.Ints(ans)
    return ans
}
```

```c
int cmp(const void* _a, const void* _b) {
    int a = *(int*)_a, b = *(int*)_b;
    return a - b;
}

int* sortedSquares(int* nums, int numsSize, int* returnSize) {
    (*returnSize) = numsSize;
    int* ans = malloc(sizeof(int) * numsSize);
    for (int i = 0; i < numsSize; ++i) {
        ans[i] = nums[i] * nums[i];
    }
    qsort(ans, numsSize, sizeof(int), cmp);
    return ans;
}
```

**复杂度分析**

-   时间复杂度：$O(n \log n)$，其中 $n$ 是数组 $nums$ 的长度。
-   空间复杂度：$O(\log n)$。除了存储答案的数组以外，我们需要 $O(\log n)$ 的栈空间进行排序。
