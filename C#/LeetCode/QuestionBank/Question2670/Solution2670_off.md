### [找出不同元素数目差数组](https://leetcode.cn/problems/find-the-distinct-difference-array/solutions/2614624/zhao-chu-bu-tong-yuan-su-shu-mu-chai-shu-iufa/)

#### 方法一：哈希表 + 前后缀预处理

##### 思路与算法

首先我们创建一个长度为 $n$ 的结果数组 $\textit{res}$，其中 $n$ 为数组 $\textit{nums}$ 的长度，然后我们用数组 $\textit{sufCnt}$ 来记录原数组中每一个后缀中不同元素的个数：$\textit{sufCnt}[i]$ 表示原数组中从 $\textit{nums}[i]$ 到 $\textit{nums}[n - 1]$ 不同元素的个数，其中 $n$ 为数组 $\textit{nums}$ 的长度，并标记 $\textit{sufCnt}[n] = 0$。对于数组 $\textit{sufCnt}$ 的计算，我们可以从数组末尾开始向前遍历 $\textit{nums}$，并记录每个后缀的不同元素个数到数组 $\textit{sufCnt}$ 中。这个过程可以通过使用哈希表来实现——将遍历到的元素全部依次加入哈希表中，然后哈希表的大小即为该位置的后缀数组中不同元素的个数。

然后我们正序枚举数组 $\textit{nums}$，同样我们可以用哈希表来得到遍历到的位置 $i$ 的不同元素个数，此时 $\textit{res}[i]$ 等于此时哈希表的大小减去 $\textit{sufCnt}[i + 1]$。

最终我们返回数组 $\textit{res}$ 即可。

##### 代码

```c++
class Solution {
public:
    vector<int> distinctDifferenceArray(vector<int>& nums) {
        int n = nums.size();
        unordered_set<int> st;
        vector<int> sufCnt(n + 1, 0);
        for (int i = n - 1; i > 0; i--) {
            st.insert(nums[i]);
            sufCnt[i] = st.size();
        }
        vector<int> res;
        st.clear();
        for (int i = 0; i < n; i++) {
            st.insert(nums[i]);
            res.push_back(int(st.size()) - sufCnt[i + 1]);
        }
        return res;
    }
};
```

```java
class Solution {
    public int[] distinctDifferenceArray(int[] nums) {
        int n = nums.length;
        Set<Integer> set = new HashSet<Integer>();
        int[] sufCnt = new int[n + 1];
        for (int i = n - 1; i > 0; i--) {
            set.add(nums[i]);
            sufCnt[i] = set.size();
        }
        int[] res = new int[n];
        set.clear();
        for (int i = 0; i < n; i++) {
            set.add(nums[i]);
            res[i] = set.size() - sufCnt[i + 1];
        }
        return res;
    }
}
```

```csharp
public class Solution {
    public int[] DistinctDifferenceArray(int[] nums) {
        int n = nums.Length;
        ISet<int> set = new HashSet<int>();
        int[] sufCnt = new int[n + 1];
        for (int i = n - 1; i > 0; i--) {
            set.Add(nums[i]);
            sufCnt[i] = set.Count;
        }
        int[] res = new int[n];
        set.Clear();
        for (int i = 0; i < n; i++) {
            set.Add(nums[i]);
            res[i] = set.Count - sufCnt[i + 1];
        }
        return res;
    }
}
```

```go
func distinctDifferenceArray(nums []int) []int {
    st := map[int]struct{}{}
    sufCnt := make([]int, len(nums) + 1)
    for i := len(nums) - 1; i > 0; i-- {
        st[nums[i]] = struct{}{}
        sufCnt[i] = len(st)
    }
    var res []int
    st = map[int]struct{}{}
    for i := 0; i < len(nums); i++ {
        st[nums[i]] = struct{}{}
        res = append(res, len(st) - sufCnt[i + 1])
    }
    return res
}
```

```python
class Solution:
    def distinctDifferenceArray(self, nums: List[int]) -> List[int]:
        st = set()
        sufCnt = [0] * (len(nums) + 1)
        for i in range(len(nums) - 1, 0, -1):
            st.add(nums[i])
            sufCnt[i] = len(st)
        res = []
        st.clear()
        for i in range(len(nums)):
            st.add(nums[i])
            res.append(len(st) - sufCnt[i + 1])
        return res
```

```javascript
var distinctDifferenceArray = function(nums) {
    let st = new Set();
    let sufCnt = new Array(nums.length + 1).fill(0);
    for (let i = nums.length - 1; i > 0; i--) {
        st.add(nums[i]);
        sufCnt[i] = st.size;
    }
    let res = [];
    st.clear();
    for (let i = 0; i < nums.length; i++) {
        st.add(nums[i]);
        res.push(st.size - sufCnt[i + 1]);
    }
    return res;
};
```

```c
typedef struct {
    int value;
    UT_hash_handle hh;
} Set;

void insert(Set **st, int x) {
    Set *s;
    HASH_FIND_INT(*st, &x, s);
    if (s == NULL) {
        s = (Set *)malloc(sizeof(Set));
        s->value = x;
        HASH_ADD_INT(*st, value, s);
    }
}

void clear(Set **st) {
    Set *cur = NULL, *p = NULL;
    HASH_ITER(hh, *st, cur, p) {
        HASH_DEL(*st, cur);
        free(cur);
    }
}

int size(Set **st) {
    return HASH_COUNT(*st);
}

int *distinctDifferenceArray(int *nums, int numsSize, int *returnSize) {
    Set *st = NULL;
    int *sufCnt = (int *)malloc(sizeof(int) * (numsSize + 1));
    memset(sufCnt, 0, sizeof(int) * (numsSize + 1));
    for (int i = numsSize - 1; i >= 0; i--) {
        insert(&st, nums[i]);
        sufCnt[i] = size(&st);
    }
    int *res = (int *)malloc(sizeof(int) * numsSize);
    clear(&st);
    for (int i = 0; i < numsSize; i++) {
        insert(&st, nums[i]);
        res[i] = size(&st) - sufCnt[i + 1];
    }
    clear(&st);
    free(sufCnt);
    *returnSize = numsSize;
    return res;
}
```

复杂度分析

- 时间复杂度：$O(n)$，其中 $n$ 为数组 $\textit{nums}$ 的长度。
- 空间复杂度：$O(n)$，其中 $n$ 为数组 $\textit{nums}$ 的长度。主要为哈希表和数组 $\textit{sufCnt}$ 的空间开销。
