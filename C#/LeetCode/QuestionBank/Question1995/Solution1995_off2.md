#### [方法二：使用哈希表存储 $nums[d]$](https://leetcode.cn/problems/count-special-quadruplets/solutions/1179031/tong-ji-te-shu-si-yuan-zu-by-leetcode-so-50e2/)

**思路与算法**

如果我们已经枚举了前三个下标 $a, b, c$，那么就已经知道了等式左侧 $nums[a] + nums[b] + nums[c]$ 的值，即为 $nums[d]$ 的值。对于下标 $d$ 而言，它的取值范围是 $c < d < n$，那么我们可以使用哈希表统计数组 $nums[c + 1]$ 到 $nums[n - 1]$ 中每个元素出现的次数。这样一来，我们就可以直接从哈希表中获得满足等式的 $d$ 的个数，而不需要在 $[c+1, n-1]$ 的范围内进行枚举了。

**细节**

在枚举前三个下标 $a, b, c$ 时，我们可以先**逆序**枚举 $c$。在 $c$ 减小的过程中，$d$ 的取值范围是逐渐增大的：即从 $c+1$ 减小到 $c$ 时，$d$ 的取值范围中多了 $c+1$ 这一项，而其余的项不变。因此我们只需要将 $nums[c + 1]$ 加入哈希表即可。

在这之后，我们就可以枚举 $a, b$ 并使用哈希表计算答案了。

**代码**

```cpp
class Solution {
public:
    int countQuadruplets(vector<int>& nums) {
        int n = nums.size();
        int ans = 0;
        unordered_map<int, int> cnt;
        for (int c = n - 2; c >= 2; --c) {
            ++cnt[nums[c + 1]];
            for (int a = 0; a < c; ++a) {
                for (int b = a + 1; b < c; ++b) {
                    if (int sum = nums[a] + nums[b] + nums[c]; cnt.count(sum)) {
                        ans += cnt[sum];
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
        Map<Integer, Integer> cnt = new HashMap<Integer, Integer>();
        for (int c = n - 2; c >= 2; --c) {
            cnt.put(nums[c + 1], cnt.getOrDefault(nums[c + 1], 0) + 1);
            for (int a = 0; a < c; ++a) {
                for (int b = a + 1; b < c; ++b) {
                    ans += cnt.getOrDefault(nums[a] + nums[b] + nums[c], 0);
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
        Dictionary<int, int> cnt = new Dictionary<int, int>();
        for (int c = n - 2; c >= 2; --c) {
            if (!cnt.ContainsKey(nums[c + 1])) {
                cnt.Add(nums[c + 1], 1);
            } else {
                ++cnt[nums[c + 1]];
            }
            for (int a = 0; a < c; ++a) {
                for (int b = a + 1; b < c; ++b) {
                    int sum = nums[a] + nums[b] + nums[c];
                    if (cnt.ContainsKey(sum)) {
                        ans += cnt[sum];
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
        cnt = Counter()
        for c in range(n - 2, 1, -1):
            cnt[nums[c + 1]] += 1
            for a in range(c):
                for b in range(a + 1, c):
                    if (total := nums[a] + nums[b] + nums[c]) in cnt:
                        ans += cnt[total]
        return ans
```

```go
func countQuadruplets(nums []int) (ans int) {
    cnt := map[int]int{}
    for c := len(nums) - 2; c >= 2; c-- {
        cnt[nums[c+1]]++
        for a, x := range nums[:c] {
            for _, y := range nums[a+1 : c] {
                if sum := x + y + nums[c]; cnt[sum] > 0 {
                    ans += cnt[sum]
                }
            }
        }
    }
    return
}
```

```c
#define MAXN 500

int countQuadruplets(int* nums, int numsSize){
    int ans = 0;
    int * cnt = (int *)malloc(sizeof(int) * MAXN);
    memset(cnt, 0, sizeof(int) * MAXN);
    for (int c = numsSize - 2; c >= 2; --c) {
        cnt[nums[c + 1]]++;
        for (int a = 0; a < c; ++a) {
            for (int b = a + 1; b < c; ++b) {
                ans += cnt[nums[a] + nums[b] + nums[c]];
            }
        }
    }
    free(cnt);
    return ans;
}
```

**复杂度分析**

-   时间复杂度：$O(n^3)$，其中 $n$ 是数组 $nums$ 的长度。我们只需要枚举 $a, b, c$。
-   空间复杂度：$O(\min(n, C))$，其中 $c$ 是数组 $nums$ 中的元素范围，在本题中 $C = 100$。在返回最终答案前，哈希表中会存储数组 $nums$ 中的所有元素，种类不会超过 $\min(n, C)$ 个。
