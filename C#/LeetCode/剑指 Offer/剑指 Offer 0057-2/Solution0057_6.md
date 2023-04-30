#### [方法三：双指针](https://leetcode.cn/problems/he-wei-sde-lian-xu-zheng-shu-xu-lie-lcof/solutions/128296/mian-shi-ti-57-ii-he-wei-sde-lian-xu-zheng-shu-x-2/)

我们用两个指针 $l$ 和 $r$ 表示当前枚举到的以 $l$ 为起点到 $r$ 的区间，$sum$ 表示 $[l,r]$ 的区间和，由求和公式可 $O(1)$ 求得为 sum=(l+r)×(r−l+1)2sum=\frac{(l+r) \\times (r-l+1)}{2}sum\=2(l+r)×(r−l+1) ，起始 l=1,r=2l=1,r=2l\=1,r\=2。

一共有三种情况：

-   如果 $sum<target$ 则说明指针 $r$ 还可以向右拓展使得 $sum$ 增大，此时指针 $r$ 向右移动，即 `r+=1`
-   如果 $sum>target$ 则说明以 $l$ 为起点不存在一个 $r$ 使得 $sum=target$ ，此时要枚举下一个起点，指针 $l$ 向右移动，即`l+=1`
-   如果 $sum==target$ 则说明我们找到了以 $l$ 为起点得合法解 $[l,r]$ ，我们需要将 $[l,r]$ 的序列放进答案数组，且我们知道以 $l$ 为起点的合法解最多只有一个，所以需要枚举下一个起点，指针 $l$ 向右移动，即 `l+=1`

终止条件即为 $l>=r$ 的时候，这种情况的发生指针 $r$ 移动到了$\lfloor\frac{target}{2}\rfloor+1$ 的位置，导致 $l<r$ 的时候区间和始终大于 $target$ 。

此方法其实是对方法一的优化，因为方法一是没有考虑区间与区间的信息可以复用，只是单纯的枚举起点，然后从起点开始累加，而该方法就是考虑到了如果已知 $[l,r]$ 的区间和等于 $target$ ，那么枚举下一个起点的时候，区间 $[l+1,r]$ 的和必然小于 $target$ ，我们就不需要再从 $l+1$ 再开始重复枚举，而是从 $r+1$ 开始枚举，充分的利用了已知的信息来优化时间复杂度。

```cpp
class Solution {
public:
    vector<vector<int>> findContinuousSequence(int target) {
        vector<vector<int>>vec;
        vector<int> res;
        for (int l = 1, r = 2; l < r;){
            int sum = (l + r) * (r - l + 1) / 2;
            if (sum == target) {
                res.clear();
                for (int i = l; i <= r; ++i) {
                    res.emplace_back(i);
                }
                vec.emplace_back(res);
                l++;
            } else if (sum < target) {
                r++;
            } else {
                l++;
            }
        }
        return vec;
    }
};
```

```java
class Solution {
    public int[][] findContinuousSequence(int target) {
        List<int[]> vec = new ArrayList<int[]>();
        for (int l = 1, r = 2; l < r;) {
            int sum = (l + r) * (r - l + 1) / 2;
            if (sum == target) {
                int[] res = new int[r - l + 1];
                for (int i = l; i <= r; ++i) {
                    res[i - l] = i;
                }
                vec.add(res);
                l++;
            } else if (sum < target) {
                r++;
            } else {
                l++;
            }
        }
        return vec.toArray(new int[vec.size()][]);
    }
}
```

**复杂度分析**

-   时间复杂度：由于两个指针移动均单调不减，且最多移动 $\lfloor\frac{target}{2}\rfloor$ 次，即方法一提到的枚举的上界，所以时间复杂度为 $O(target)$ 。
-   空间复杂度：$O(1)$ ，除了答案数组只需要常数的空间存放若干变量。
