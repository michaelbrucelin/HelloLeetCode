#### [方法一：暴力枚举](https://leetcode.cn/problems/number-of-arithmetic-triplets/solutions/2200026/suan-zhu-san-yuan-zu-de-shu-mu-by-leetco-ldq4/)

为了得到算术三元组的数目，最直观的做法是使用三重循环暴力枚举数组中的每个三元组，判断每个三元组是否为算术三元组，枚举结束之后即可得到算术三元组的数目。

```java
class Solution {
    public int arithmeticTriplets(int[] nums, int diff) {
        int ans = 0;
        int n = nums.length;
        for (int i = 0; i < n; i++) {
            for (int j = i + 1; j < n; j++) {
                if (nums[j] - nums[i] != diff) {
                    continue;
                }
                for (int k = j + 1; k < n; k++) {
                    if (nums[k] - nums[j] == diff) {
                        ans++;
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
    public int ArithmeticTriplets(int[] nums, int diff) {
        int ans = 0;
        int n = nums.Length;
        for (int i = 0; i < n; i++) {
            for (int j = i + 1; j < n; j++) {
                if (nums[j] - nums[i] != diff) {
                    continue;
                }
                for (int k = j + 1; k < n; k++) {
                    if (nums[k] - nums[j] == diff) {
                        ans++;
                    }
                }
            }
        }
        return ans;
    }
}
```

```cpp
class Solution {
public:
    int arithmeticTriplets(vector<int>& nums, int diff) {
        int ans = 0;
        int n = nums.size();
        for (int i = 0; i < n; i++) {
            for (int j = i + 1; j < n; j++) {
                if (nums[j] - nums[i] != diff) {
                    continue;
                }
                for (int k = j + 1; k < n; k++) {
                    if (nums[k] - nums[j] == diff) {
                        ans++;
                    }
                }
            }
        }
        return ans;
    }
};
```

```c
int arithmeticTriplets(int* nums, int numsSize, int diff) {
    int ans = 0;
    for (int i = 0; i < numsSize; i++) {
        for (int j = i + 1; j < numsSize; j++) {
            if (nums[j] - nums[i] != diff) {
                continue;
            }
            for (int k = j + 1; k < numsSize; k++) {
                if (nums[k] - nums[j] == diff) {
                    ans++;
                }
            }
        }
    }
    return ans;
}
```

```javascript
var arithmeticTriplets = function(nums, diff) {
    let ans = 0;
    const n = nums.length;
    for (let i = 0; i < n; i++) {
        for (let j = i + 1; j < n; j++) {
            if (nums[j] - nums[i] !== diff) {
                continue;
            }
            for (let k = j + 1; k < n; k++) {
                if (nums[k] - nums[j] === diff) {
                    ans++;
                }
            }
        }
    }
    return ans;
};
```

**复杂度分析**

-   时间复杂度：$O(n^3)$，其中 $n$ 是数组 $nums$ 的长度。使用三重循环暴力枚举需要 $O(n^3)$ 的时间。
-   空间复杂度：$O(1)$。只需要常数的额外空间。
