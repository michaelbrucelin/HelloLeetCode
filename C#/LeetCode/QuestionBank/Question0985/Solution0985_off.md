### [查询后的偶数和](https://leetcode.cn/problems/sum-of-even-numbers-after-queries/solutions/3605/cha-xun-hou-de-ou-shu-he-by-leetcode/?envType=problem-list-v2&envId=h15Gc5qm)

#### 方法：调整数组和

**思路与算法**

让我们尝试不断调整 `S`，即每一步操作之后整个数组的偶数和。

我们操作数组中的某一个元素 `A[index]` 的时候，数组 `A` 其他位置的元素都应保持不变。如果 `A[index]` 是偶数，我们就从 `S` 中减去它，然后计算 `A[index] + val` 对 `S` 的影响（如果是偶数则在 `S` 中加上它）。

这里有一些例子：

- 如果当前情况为 `A = [2,2,2,2,2]`、`S = 10`，并且需要执行 `A[0] += 4` 操作：我们应该先令 `S -= 2`，然后令 `S += 6`。最后得到 `A = [6,2,2,2,2]` 与 `S = 14`。
- 如果当前情况为 `A = [1,2,2,2,2]`、`S = 8`，同时需要执行 `A[0] += 3` 操作：我们会跳过第一次更新 `S` 的步骤（因为 `A[0]` 是奇数），然后令 `S += 4`。最后得到 `A = [4,2,2,2,2]` 与 `S = 12`。
- 如果当前情况为 `A = [2,2,2,2,2]`、`S = 10`，同时需要执行 `A[0] += 1` 操作：我们先令 `S -= 2`，然后跳过第二次更新 `S` 的操作（因为 `A[0] + 1` 是奇数）。最后得到 `A = [3,2,2,2,2]` 与 `S = 8`。
- 如果当前情况为 `A = [1,2,2,2,2]`、`S = 8`，同时需要执行 `A[0] += 2` 操作：我们跳过第一次更新 `S` 的操作（因为 `A[0]` 是奇数），然后再跳过第二次更新 `S` 的操作（因为 `A[0] + 2` 是奇数）。最后得到 `A = [3,2,2,2,2]` 与 `S = 8`。

这些例子充分展现了我们的算法在每一次询问操作之后应该如何调整 `S`。

```Java
class Solution {
    public int[] sumEvenAfterQueries(int[] A, int[][] queries) {
        int S = 0;
        for (int x: A)
            if (x % 2 == 0)
                S += x;

        int[] ans = new int[queries.length];

        for (int i = 0; i < queries.length; ++i) {
            int val = queries[i][0], index = queries[i][1];
            if (A[index] % 2 == 0) S -= A[index];
            A[index] += val;
            if (A[index] % 2 == 0) S += A[index];
            ans[i] = S;
        }

        return ans;
    }
}
```

```Python
class Solution(object):
    def sumEvenAfterQueries(self, A, queries):
        S = sum(x for x in A if x % 2 == 0)
        ans = []

        for x, k in queries:
            if A[k] % 2 == 0: S -= A[k]
            A[k] += x
            if A[k] % 2 == 0: S += A[k]
            ans.append(S)

        return ans
```

**复杂度分析**

- 时间复杂度：$O(N+Q)$，其中 $N$ 是数组 `A` 的长度，$Q$ 是询问 `queries` 的数量。
- 空间复杂度：$O(N+Q)$，事实上我们只使用了 $O(1)$ 的额外空间。
