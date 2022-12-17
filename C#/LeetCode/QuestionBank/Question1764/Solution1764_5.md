#### [方法二：KMP 匹配算法](https://leetcode.cn/problems/form-array-by-concatenating-subarrays-of-another-array/solutions/2022689/tong-guo-lian-jie-ling-yi-ge-shu-zu-de-z-xsvx/)

关于 KMP 算法的详细说明可以参考官方题解「[实现 strStr()](https://leetcode.cn/problems/find-the-index-of-the-first-occurrence-in-a-string/solutions/732236/shi-xian-strstr-by-leetcode-solution-ds6y/)」，本文不作详细说明。类似于字符串的匹配查找，数组也可以使用 KMP 算法进行匹配。我们依次枚举数组 groups[i]，并且使用变量 k 表示 nums 开始匹配查找的起点，初始时 k=0，如果匹配查找成功，那么将 k 设为查找到的下标加上 groups[i] 的长度，否则直接返回 false，匹配到最后直接返回 true。

```cpp
class Solution {
public:
    int find(vector<int> &nums, int k, vector<int> &g) {
        int m = g.size(), n = nums.size();
        if (k + g.size() > nums.size()) {
            return -1;
        }
        vector<int> pi(m);
        for (int i = 1, j = 0; i < m; i++) {
            while (j > 0 && g[i] != g[j]) {
                j = pi[j - 1];
            }
            if (g[i] == g[j]) {
                j++;
            }
            pi[i] = j;
        }
        for (int i = k, j = 0; i < n; i++) {
            while (j > 0 && nums[i] != g[j]) {
                j = pi[j - 1];
            }
            if (nums[i] == g[j]) {
                j++;
            }
            if (j == m) {
                return i - m + 1;
            }
        }
        return -1;
    }

    bool canChoose(vector<vector<int>>& groups, vector<int>& nums) {
        int k = 0;
        for (int i = 0; i < groups.size(); i++) {
            k = find(nums, k, groups[i]);
            if (k == -1) {
                return false;
            }
            k += groups[i].size();
        }
        return true;
    }
};
```

```java
class Solution {
    public boolean canChoose(int[][] groups, int[] nums) {
        int k = 0;
        for (int i = 0; i < groups.length; i++) {
            k = find(nums, k, groups[i]);
            if (k == -1) {
                return false;
            }
            k += groups[i].length;
        }
        return true;
    }

    public int find(int[] nums, int k, int[] g) {
        int m = g.length, n = nums.length;
        if (k + g.length > nums.length) {
            return -1;
        }
        int[] pi = new int[m];
        for (int i = 1, j = 0; i < m; i++) {
            while (j > 0 && g[i] != g[j]) {
                j = pi[j - 1];
            }
            if (g[i] == g[j]) {
                j++;
            }
            pi[i] = j;
        }
        for (int i = k, j = 0; i < n; i++) {
            while (j > 0 && nums[i] != g[j]) {
                j = pi[j - 1];
            }
            if (nums[i] == g[j]) {
                j++;
            }
            if (j == m) {
                return i - m + 1;
            }
        }
        return -1;
    }
}
```

```c#
public class Solution {
    public bool CanChoose(int[][] groups, int[] nums) {
        int k = 0;
        for (int i = 0; i < groups.Length; i++) {
            k = Find(nums, k, groups[i]);
            if (k == -1) {
                return false;
            }
            k += groups[i].Length;
        }
        return true;
    }

    public int Find(int[] nums, int k, int[] g) {
        int m = g.Length, n = nums.Length;
        if (k + g.Length > nums.Length) {
            return -1;
        }
        int[] pi = new int[m];
        for (int i = 1, j = 0; i < m; i++) {
            while (j > 0 && g[i] != g[j]) {
                j = pi[j - 1];
            }
            if (g[i] == g[j]) {
                j++;
            }
            pi[i] = j;
        }
        for (int i = k, j = 0; i < n; i++) {
            while (j > 0 && nums[i] != g[j]) {
                j = pi[j - 1];
            }
            if (nums[i] == g[j]) {
                j++;
            }
            if (j == m) {
                return i - m + 1;
            }
        }
        return -1;
    }
}
```

```c
int find(const int *nums, int numsSize, int k, const int *g, int gSize) {
    int m = gSize, n = numsSize;
    if (k + m > n) {
        return -1;
    }
    int pi[m];
    pi[0] = 0;
    for (int i = 1, j = 0; i < m; i++) {
        while (j > 0 && g[i] != g[j]) {
            j = pi[j - 1];
        }
        if (g[i] == g[j]) {
            j++;
        }
        pi[i] = j;
    }
    for (int i = k, j = 0; i < n; i++) {
        while (j > 0 && nums[i] != g[j]) {
            j = pi[j - 1];
        }
        if (nums[i] == g[j]) {
            j++;
        }
        if (j == m) {
            return i - m + 1;
        }
    }
    return -1;
}

bool canChoose(int** groups, int groupsSize, int* groupsColSize, int* nums, int numsSize) {
    int k = 0;
    for (int i = 0; i < groupsSize; i++) {
        k = find(nums, numsSize, k, groups[i], groupsColSize[i]);
        if (k == -1) {
            return false;
        }
        k += groupsColSize[i];
    }
    return true;
}
```

```javascript
var canChoose = function(groups, nums) {
    let k = 0;
    for (let i = 0; i < groups.length; i++) {
        k = find(nums, k, groups[i]);
        if (k == -1) {
            return false;
        }
        k += groups[i].length;
    }
    return true;
}

const find = (nums, k, g) => {
    let m = g.length, n = nums.length;
    if (k + g.length > nums.length) {
        return -1;
    }
    const pi = new Array(m).fill(0);
    for (let i = 1, j = 0; i < m; i++) {
        while (j > 0 && g[i] !== g[j]) {
            j = pi[j - 1];
        }
        if (g[i] === g[j]) {
            j++;
        }
        pi[i] = j;
    }
    for (let i = k, j = 0; i < n; i++) {
        while (j > 0 && nums[i] !== g[j]) {
            j = pi[j - 1];
        }
        if (nums[i] === g[j]) {
            j++;
        }
        if (j === m) {
            return i - m + 1;
        }
    }
    return -1;
};
```

**复杂度分析**

-   时间复杂度：$O(m + \sum g_i)$，其中 $m$ 是数组 $nums$ 的长度，$g_i$ 是数组 $groups[i]$ 的长度。最坏情况下，每一个 $groups[i]$ 都调用一次 $find$，因此总时间复杂度为 $O(m + \sum g_i)$。
-   空间复杂度：$O(\max g_i)$。对 $groups[i]$ 调用一次 KMP 算法需要申请 $O(g_i)$ 的空间。
