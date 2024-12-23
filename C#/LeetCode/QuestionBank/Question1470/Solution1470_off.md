### [重新排列数组](https://leetcode.cn/problems/shuffle-the-array/solutions/1776605/zhong-xin-pai-lie-shu-zu-by-leetcode-sol-1eps/)

#### 方法一：一次遍历

用 $ans$ 表示结果数组，数组 $nums$ 和 $ans$ 的长度都是 $2n$。对于 $0 \le i < n$，重新排列数组的规则如下：

- $nums[i]$ 填到 $ans[2 \times i]$；
- $nums[i+n]$ 填到 $ans[2 \times i+1]$。

根据该规则将原数组 $nums$ 中的元素依次填入结果数组 $ans$ 中，即可得到重新排列后的数组。

```Python
class Solution:
    def shuffle(self, nums: List[int], n: int) -> List[int]:
        ans = [0] * (2 * n)
        for i in range(n):
            ans[2 * i] = nums[i]
            ans[2 * i + 1] = nums[n + i]
        return ans
```

```Java
class Solution {
    public int[] shuffle(int[] nums, int n) {
        int[] ans = new int[2 * n];
        for (int i = 0; i < n; i++) {
            ans[2 * i] = nums[i];
            ans[2 * i + 1] = nums[i + n];
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public int[] Shuffle(int[] nums, int n) {
        int[] ans = new int[2 * n];
        for (int i = 0; i < n; i++) {
            ans[2 * i] = nums[i];
            ans[2 * i + 1] = nums[i + n];
        }
        return ans;
    }
}
```

```C++
class Solution {
public:
    vector<int> shuffle(vector<int>& nums, int n) {
        vector<int> ans(2 * n);
        for (int i = 0; i < n; i++) {
            ans[2 * i] = nums[i];
            ans[2 * i + 1] = nums[i + n];
        }
        return ans;
    }
};
```

```C
int* shuffle(int* nums, int numsSize, int n, int* returnSize){
    int *ans = (int *)malloc(sizeof(int) * n * 2);
    for (int i = 0; i < n; i++) {
        ans[2 * i] = nums[i];
        ans[2 * i + 1] = nums[i + n];
    }
    *returnSize = n * 2;
    return ans;
}
```

```JavaScript
var shuffle = function(nums, n) {
    const ans = new Array(2 * n).fill(0);
    for (let i = 0; i < n; i++) {
        ans[2 * i] = nums[i];
        ans[2 * i + 1] = nums[i + n];
    }
    return ans;
};
```

```Go
func shuffle(nums []int, n int) []int {
    ans := make([]int, n*2)
    for i, num := range nums[:n] {
        ans[2*i] = num
        ans[2*i+1] = nums[n+i]
    }
    return ans
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是给定的参数。需要遍历长度为 $2n$ 的数组 $nums$ 一次将数组重新排列，每个元素重新排列的时间是 $O(1)$。
- 空间复杂度：$O(1)$。注意返回值不计入空间复杂度。
