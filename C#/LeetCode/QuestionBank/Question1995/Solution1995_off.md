#### [方法一：直接枚举](https://leetcode.cn/problems/count-special-quadruplets/solutions/1179031/tong-ji-te-shu-si-yuan-zu-by-leetcode-so-50e2/)

**思路与算法**

最简单的方法是直接枚举四个下标 $a, b, c, d$ 并进行判断。

**代码**

```cpp
class Solution {
public:
    int countQuadruplets(vector<int>& nums) {
        int n = nums.size();
        int ans = 0;
        for (int a = 0; a < n; ++a) {
            for (int b = a + 1; b < n; ++b) {
                for (int c = b + 1; c < n; ++c) {
                    for (int d = c + 1; d < n; ++d) {
                        if (nums[a] + nums[b] + nums[c] == nums[d]) {
                            ++ans;
                        }
                    }
                }
            }
        }
        return ans;
    }
};
```

```java
class Solution {
    public int countQuadruplets(int[] nums) {
        int n = nums.length;
        int ans = 0;
        for (int a = 0; a < n; ++a) {
            for (int b = a + 1; b < n; ++b) {
                for (int c = b + 1; c < n; ++c) {
                    for (int d = c + 1; d < n; ++d) {
                        if (nums[a] + nums[b] + nums[c] == nums[d]) {
                            ++ans;
                        }
                    }
                }
            }
        }
        return ans;
    }
}
```

```csharp
public class Solution {
    public int CountQuadruplets(int[] nums) {
        int n = nums.Length;
        int ans = 0;
        for (int a = 0; a < n; ++a) {
            for (int b = a + 1; b < n; ++b) {
                for (int c = b + 1; c < n; ++c) {
                    for (int d = c + 1; d < n; ++d) {
                        if (nums[a] + nums[b] + nums[c] == nums[d]) {
                            ++ans;
                        }
                    }
                }
            }
        }
        return ans;
    }
}
```

```python
class Solution:
    def countQuadruplets(self, nums: List[int]) -> int:
        n = len(nums)
        ans = 0
        for a in range(n):
            for b in range(a + 1, n):
                for c in range(b + 1, n):
                    for d in range(c + 1, n):
                        if nums[a] + nums[b] + nums[c] == nums[d]:
                            ans += 1
        return ans
```

```go
func countQuadruplets(nums []int) (ans int) {
    for a, x := range nums {
        for b := a + 1; b < len(nums); b++ {
            for c := b + 1; c < len(nums); c++ {
                for _, y := range nums[c+1:] {
                    if x+nums[b]+nums[c] == y {
                        ans++
                    }
                }
            }
        }
    }
    return
}
```

```c
int countQuadruplets(int* nums, int numsSize){
    int ans = 0;
    for (int a = 0; a < numsSize; ++a) {
        for (int b = a + 1; b < numsSize; ++b) {
            for (int c = b + 1; c < numsSize; ++c) {
                for (int d = c + 1; d < numsSize; ++d) {
                    if (nums[a] + nums[b] + nums[c] == nums[d]) {
                        ++ans;
                    }
                }
            }
        }
    }
    return ans;
}
```

**复杂度分析**

-   时间复杂度：$O(n^4)$，其中 $n$ 是数组 $nums$ 的长度。
-   空间复杂度：$O(1)$。
