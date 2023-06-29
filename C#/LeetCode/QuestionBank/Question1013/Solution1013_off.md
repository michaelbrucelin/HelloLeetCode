#### [方法一：寻找切分点](https://leetcode.cn/problems/partition-array-into-three-parts-with-equal-sum/solutions/134429/1013-jiang-shu-zu-fen-cheng-he-xiang-deng-de-san-2/)

我们将数组 `A` 中的所有数的和记为 `sum(A)`。根据题目我们可以得知，每一个非空部分的和都应当是 `sum(A) / 3`。因此我们需要找到索引 `i` 和 `j` 使得：

-   `A[0] + A[1] + ... + A[i] = sum(A) / 3`;
-   `A[i + 1] + A[i + 2] + ... + A[j] = sum(A) / 3`。这等价于 `A[0] + A[1] + ... + A[j] = sum(A) / 3 * 2` 且 `j > i`。

首先我们需要找出索引 `i`。具体地，我们从第一个元素开始遍历数组 `A` 并对数组中的数进行累加。当累加的和等于 `sum(A) / 3` 时，我们就将当前的位置置为索引 `i`。由于数组中的数有正有负，我们可能会得到若干个索引 `i0, i1, i2, ...`，从 `A[0]` 到这些索引的数之和均为 `sum(A) / 3`。那么我们应该选取那个索引呢？直觉告诉我们，应该贪心地选择最小的那个索引 `i0`，这也是可以证明的：假设最终的答案中我们选取了某个不为 `i0` 的索引 `ik` 以及另一个索引 `j`，那么根据上面的两条要求，有：

-   `A[0] + A[1] + ... + A[ik] = sum(A) / 3`;
-   `A[0] + A[1] + ... + A[j] = sum(A) / 3 * 2` 且 `j > ik`。

然而 `i0` 也是满足第一条要求的一个索引，因为 `A[0] + A[1] + ... + A[i0] = sum(A) / 3` 并且 `j > ik > i0`，我们可以将 `ik` 替换为 `i0`，因此选择最小的那个索引是合理的。

在选择了 `i0` 作为 `i` 之后，我们从 `i0 + 1` 开始继续遍历数组 `A` 并进行累加，当累加的和等于 `sum(A) / 3 * 2` 时，我们就得到了索引 `j`，可以返回 `true` 作为答案。如果我们无法找到索引 `i` 或索引 `j`，或者 `sum(A)` 本身无法被 `3` 整数，那么我们返回 `false`。

```python
class Solution:
    def canThreePartsEqualSum(self, A: List[int]) -> bool:
        s = sum(A)
        if s % 3 != 0:
            return False
        target = s // 3
        n, i, cur = len(A), 0, 0
        while i < n:
            cur += A[i]
            if cur == target:
                break
            i += 1
        if cur != target:
            return False
        j = i + 1
        while j + 1 < n:  # 需要满足最后一个数组非空
            cur += A[j]
            if cur == target * 2:
                return True
            j += 1
        return False
```

```cpp
class Solution {
public:
    bool canThreePartsEqualSum(vector<int>& A) {
        int s = accumulate(A.begin(), A.end(), 0);
        if (s % 3 != 0) {
            return false;
        }
        int target = s / 3;
        int n = A.size(), i = 0, cur = 0;
        while (i < n) {
            cur += A[i];
            if (cur == target) {
                break;
            }
            ++i;
        }
        if (cur != target) {
            return false;
        }
        int j = i + 1;
        while (j + 1 < n) {  // 需要满足最后一个数组非空
            cur += A[j];
            if (cur == target * 2) {
                return true;
            }
            ++j;
        }
        return false;
    }
};
```

```java
class Solution {
    public boolean canThreePartsEqualSum(int[] A) {
        int s = 0;
        for (int num : A) {
            s += num;
        }
        if (s % 3 != 0) {
            return false;
        }
        int target = s / 3;
        int n = A.length, i = 0, cur = 0;
        while (i < n) {
            cur += A[i];
            if (cur == target) {
                break;
            }
            ++i;
        }
        if (cur != target) {
            return false;
        }
        int j = i + 1;
        while (j + 1 < n) {  // 需要满足最后一个数组非空
            cur += A[j];
            if (cur == target * 2) {
                return true;
            }
            ++j;
        }
        return false;
    }
}
```

**复杂度分析**

-   时间复杂度：$O(N)$，其中 $N$ 是数组 `A` 的长度。我们最多只需要遍历一遍数组就可以得到答案。
-   空间复杂度：$O(1)$。我们只需要使用额外的索引变量 `i`，`j` 以及一些存储数组信息的变量。
