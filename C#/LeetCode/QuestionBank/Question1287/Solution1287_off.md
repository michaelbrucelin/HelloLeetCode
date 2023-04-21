#### [方法一：遍历](https://leetcode.cn/problems/element-appearing-more-than-25-in-sorted-array/solutions/101725/you-xu-shu-zu-zhong-chu-xian-ci-shu-chao-guo-25d-3/)

由于数组 `arr` 已经有序，那么相同的数在 `arr` 中出现的位置也是连续的。因此我们可以对数组进行一次遍历，并统计每个数出现的次数。只要发现某个数出现的次数超过数组 `arr` 长度的 25%，那么这个数即为答案。

在计算数组 `arr` 长度的 25% 时，会涉及到浮点数。我们可以用整数运算 `count * 4 > arr.length` 代替浮点数运算 `count > arr.length * 25%`，减少精度误差。

```cpp
class Solution {
public:
    int findSpecialInteger(vector<int>& arr) {
        int n = arr.size();
        int cur = arr[0], cnt = 0;
        for (int i = 0; i < n; ++i) {
            if (arr[i] == cur) {
                ++cnt;
                if (cnt * 4 > n) {
                    return cur;
                }
            }
            else {
                cur = arr[i];
                cnt = 1;
            }
        }
        return -1;
    }
};
```

```python
class Solution:
    def findSpecialInteger(self, arr: List[int]) -> int:
        n = len(arr)
        cur, cnt = arr[0], 0
        for i in range(n):
            if arr[i] == cur:
                cnt += 1
                if cnt * 4 > n:
                    return cur
            else:
                cur, cnt = arr[i], 1
        return -1
```

**复杂度分析**

-   时间复杂度：$O(N)$，其中 $N$ 是数组 `arr` 的长度。
-   空间复杂度：$O(1)$。
