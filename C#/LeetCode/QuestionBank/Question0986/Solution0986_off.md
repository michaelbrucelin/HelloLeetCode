### [区间列表的交集](https://leetcode.cn/problems/interval-list-intersections/solutions/3604/qu-jian-lie-biao-de-jiao-ji-by-leetcode/?envType=problem-list-v2&envId=ySsxoJfz)

#### 方法：归并区间

**思路**

我们称 `b` 为区间 `[a, b]` 的末端点。

在两个数组给定的所有区间中，假设拥有最小末端点的区间是 `A[0]`。（为了不失一般性，该区间出现在数组 $A$ 中)

然后，在数组 `B` 的区间中，`A[0]` 只可能与数组 `B` 中的至多一个区间相交。（如果 `B` 中存在两个区间均与 `A[0]` 相交，那么它们将共同包含 `A[0]` 的末端点，但是 `B` 中的区间应该是不相交的，所以存在矛盾）

**算法**

如果 `A[0]` 拥有最小的末端点，那么它只可能与 `B[0]` 相交。然后我们就可以删除区间 `A[0]`，因为它不能与其他任何区间再相交了。

相似的，如果 `B[0]` 拥有最小的末端点，那么它只可能与区间 `A[0]` 相交，然后我们就可以将 `B[0]` 删除，因为它无法再与其他区间相交了。

我们用两个指针 `i` 与 `j` 来模拟完成删除 `A[0]` 或 `B[0]` 的操作。

```Java
class Solution {
  public int[][] intervalIntersection(int[][] A, int[][] B) {
    List<int[]> ans = new ArrayList();
    int i = 0, j = 0;

    while (i < A.length && j < B.length) {
      // Let's check if A[i] intersects B[j].
      // lo - the startpoint of the intersection
      // hi - the endpoint of the intersection
      int lo = Math.max(A[i][0], B[j][0]);
      int hi = Math.min(A[i][1], B[j][1]);
      if (lo <= hi)
        ans.add(new int[]{lo, hi});

      // Remove the interval with the smallest endpoint
      if (A[i][1] < B[j][1])
        i++;
      else
        j++;
    }

    return ans.toArray(new int[ans.size()][]);
  }
}
```

```python
class Solution:
    def intervalIntersection(self, A: List[List[int]], B: List[List[int]]) -> List[List[int]]:
        ans = []
        i = j = 0

        while i < len(A) and j < len(B):
            # Let's check if A[i] intersects B[j].
            # lo - the startpoint of the intersection
            # hi - the endpoint of the intersection
            lo = max(A[i][0], B[j][0])
            hi = min(A[i][1], B[j][1])
            if lo <= hi:
                ans.append([lo, hi])

            # Remove the interval with the smallest endpoint
            if A[i][1] < B[j][1]:
                i += 1
            else:
                j += 1

        return ans
```

**复杂度分析**

- 时间复杂度：$O(M+N)$，其中 $M,N$ 分别是数组 `A` 和 `B` 的长度。
- 空间复杂度：$O(M+N)$，答案中区间数量的上限。
