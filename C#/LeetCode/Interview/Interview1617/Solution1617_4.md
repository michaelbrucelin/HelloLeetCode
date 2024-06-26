#### [方法二：分治](https://leetcode.cn/problems/contiguous-sequence-lcci/solutions/586439/lian-xu-shu-lie-by-leetcode-solution-be4z/)

**思路和算法**
**这个分治方法类似于「线段树求解最长公共上升子序列问题」的 `pushUp` 操作。** 也许读者还没有接触过线段树，没有关系，方法二的内容假设你没有任何线段树的基础。当然，如果读者有兴趣的话，推荐阅读线段树区间合并法解决**多次询问**的「区间最长连续上升序列问题」和「区间最大子段和问题」，还是非常有趣的。 我们定义一个操作 `get(a, l, r)` 表示查询 $a$ 序列 $[l,r]$ 区间内的最大子段和，那么最终我们要求的答案就是 `get(nums, 0, nums.size() - 1)`。如何分治实现这个操作呢？对于一个区间 $[l,r]$，我们取 $m = \lfloor \frac{l + r}{2} \rfloor$，对区间 $[l,m]$ 和 $[m+1,r]$ 分治求解。当递归逐层深入直到区间长度缩小为 $1$ 的时候，递归「开始回升」。这个时候我们考虑如何通过 $[l,m]$ 区间的信息和 $[m+1,r]$ 区间的信息合并成区间 $[l,r]$ 的信息。最关键的两个问题是：
+ 我们要维护区间的哪些信息呢？
+ 我们如何合并这些信息呢？

对于一个区间 $[l,r]$，我们可以维护四个量：
+ $lSum$ 表示 $[l,r]$ 内以 $l$ 为左端点的最大子段和
+ $rSum$ 表示 $[l,r]$ 内以 $r$ 为右端点的最大子段和
+ $mSum$ 表示 $[l,r]$ 内的最大子段和
+ $iSum$ 表示 $[l,r]$ 的区间和

以下简称 $[l,m]$ 为 $[l,r]$ 的「左子区间」，$[m+1,r]$ 为 $[l,r]$ 的「右子区间」。我们考虑如何维护这些量呢（如何通过左右子区间的信息合并得到 $[l,r]$ 的信息）？对于长度为 $1$ 的区间 $[i, i]$，四个量的值都和 $nums[i]$ 相等。对于长度大于 $1$ 的区间：
+ 首先最好维护的是 $iSum$，区间 $[l,r]$ 的 $iSum$ 就等于「左子区间」的 $iSum$ 加上「右子区间」的 $iSum$。
+ 对于 $[l,r]$ 的 $lSum$，存在两种可能，它要么等于「左子区间」的 $lSum$，要么等于「左子区间」的 $iSum$ 加上「右子区间」的 $lSum$，二者取大。
+ 对于 $[l,r]$ 的 $rSum$，同理，它要么等于「右子区间」的 $rSum$，要么等于「右子区间」的 $iSum$ 加上「左子区间」的 $rSum$，二者取大。
+ 当计算好上面的三个量之后，就很好计算 $[l,r]$ 的 $mSum$ 了。我们可以考虑 $[l,r]$ 的 $mSum$ 对应的区间是否跨越 $m$——它可能不跨越 $m$，也就是说 $[l,r]$ 的 $mSum$ 可能是「左子区间」的 $mSum$ 和 「右子区间」的 $mSum$ 中的一个；它也可能跨越 $m$，可能是「左子区间」的 $rSum$ 和 「右子区间」的 $lSum$ 求和。三者取大。

这样问题就得到了解决。 

**代码** 
```cpp [sol2-C++]
class Solution {
    public: struct Status {
        int lSum, rSum, mSum, iSum;
    };

    Status pushUp(Status l, Status r) {
        int iSum = l.iSum + r.iSum;
        int lSum = max(l.lSum, l.iSum + r.lSum);
        int rSum = max(r.rSum, r.iSum + l.rSum);
        int mSum = max(max(l.mSum, r.mSum), l.rSum + r.lSum);

        return (Status) {lSum, rSum, mSum, iSum};
    };

    Status get(vector<int> &a, int l, int r) {
        if (l == r) {
            return (Status) {a[l], a[l], a[l], a[l]};
        }

        int m = (l + r) >> 1; Status lSub = get(a, l, m);
        Status rSub = get(a, m + 1, r);

        return pushUp(lSub, rSub);
    }

    int maxSubArray(vector<int>& nums) {
        return get(nums, 0, nums.size() - 1).mSum;
    }
};
```

```csharp [sol2-C#]
public class Solution {
    public class Status {
        public int lSum, rSum, mSum, iSum;
        public Status(int lSum_, int rSum_, int mSum_, int iSum_) {
            lSum = lSum_;
            rSum = rSum_;
            mSum = mSum_;
            iSum = iSum_;
        }
    }

    public Status pushUp(Status l, Status r) {
        int iSum = l.iSum + r.iSum;
        int lSum = Math.Max(l.lSum, l.iSum + r.lSum);
        int rSum = Math.Max(r.rSum, r.iSum + l.rSum);
        int mSum = Math.Max(Math.Max(l.mSum, r.mSum), l.rSum + r.lSum);

        return new Status(lSum, rSum, mSum, iSum);
    }

    public Status getInfo(int[] a, int l, int r) {
        if (l == r) {
            return new Status(a[l], a[l], a[l], a[l]);
        }

        int m = (l + r) >> 1;
        Status lSub = getInfo(a, l, m);
        Status rSub = getInfo(a, m + 1, r);

        return pushUp(lSub, rSub);
    }

    public int MaxSubArray(int[] nums) {
        return getInfo(nums, 0, nums.Length - 1).mSum;
    }
}
```

```Java [sol2-Java]
class Solution {
    public class Status {
        public int lSum, rSum, mSum, iSum;
        public Status(int lSum, int rSum, int mSum, int iSum) {
            this.lSum = lSum;
            this.rSum = rSum;
            this.mSum = mSum;
            this.iSum = iSum;
        }
    }

    public int maxSubArray(int[] nums) {
        return getInfo(nums, 0, nums.length - 1).mSum;
    }

    public Status getInfo(int[] a, int l, int r) {
        if (l == r) {
            return new Status(a[l], a[l], a[l], a[l]);
        }

        int m = (l + r) >> 1;
        Status lSub = getInfo(a, l, m);
        Status rSub = getInfo(a, m + 1, r);

        return pushUp(lSub, rSub);
    }

    public Status pushUp(Status l, Status r) {
        int iSum = l.iSum + r.iSum;
        int lSum = Math.max(l.lSum, l.iSum + r.lSum);
        int rSum = Math.max(r.rSum, r.iSum + l.rSum);
        int mSum = Math.max(Math.max(l.mSum, r.mSum), l.rSum + r.lSum);
        
        return new Status(lSum, rSum, mSum, iSum);
    }
}
```

```JavaScript [sol2-JavaScript]
function Status(l, r, m, i) {
    this.lSum = l;
    this.rSum = r;
    this.mSum = m;
    this.iSum = i;
}

const pushUp = (l, r) => {
    const iSum = l.iSum + r.iSum;
    const lSum = Math.max(l.lSum, l.iSum + r.lSum);
    const rSum = Math.max(r.rSum, r.iSum + l.rSum);
    const mSum = Math.max(Math.max(l.mSum, r.mSum), l.rSum + r.lSum);

    return new Status(lSum, rSum, mSum, iSum);
}

const getInfo = (a, l, r) => {
    if (l === r) {
        return new Status(a[l], a[l], a[l], a[l]);
    }

    const m = (l + r) >> 1;
    const lSub = getInfo(a, l, m);
    const rSub = getInfo(a, m + 1, r);
    return pushUp(lSub, rSub);
}

var maxSubArray = function(nums) {
    return getInfo(nums, 0, nums.length - 1).mSum;
};
```

```go [sol2-Golang]
func maxSubArray(nums []int) int {
    return get(nums, 0, len(nums) - 1).mSum;
}

func pushUp(l, r Status) Status {
    iSum := l.iSum + r.iSum lSum := max(l.lSum, l.iSum + r.lSum)
    rSum := max(r.rSum, r.iSum + l.rSum)
    mSum := max(max(l.mSum, r.mSum), l.rSum + r.lSum)

    return Status{lSum, rSum, mSum, iSum}
}

func get(nums []int, l, r int) Status {
    if (l == r) {
        return Status{nums[l], nums[l], nums[l], nums[l]}
    }
    m := (l + r) >> 1
    lSub := get(nums, l, m)
    rSub := get(nums, m + 1, r)

    return pushUp(lSub, rSub)
}

func max(x, y int) int { 
    if x > y { return x } 
    return y
}

type Status struct { lSum, rSum, mSum, iSum int }
```

```C [sol2-C]
struct Status { int lSum, rSum, mSum, iSum; };
struct Status pushUp(struct Status l, struct Status r) {
    int iSum = l.iSum + r.iSum;
    int lSum = fmax(l.lSum, l.iSum + r.lSum);
    int rSum = fmax(r.rSum, r.iSum + l.rSum);
    int mSum = fmax(fmax(l.mSum, r.mSum), l.rSum + r.lSum);

    return (struct Status){lSum, rSum, mSum, iSum};
};

struct Status get(int* a, int l, int r) {
    if (l == r) {
        return (struct Status){a[l], a[l], a[l], a[l]};
    }

    int m = (l + r) >> 1;
    struct Status lSub = get(a, l, m);
    struct Status rSub = get(a, m + 1, r);

    return pushUp(lSub, rSub);
}

int maxSubArray(int* nums, int numsSize) {
    return get(nums, 0, numsSize - 1).mSum;
}
```

**复杂度分析** 假设序列 $a$ 的长度为 $n$。
+ 时间复杂度：假设我们把递归的过程看作是一颗二叉树的先序遍历，那么这颗二叉树的深度的渐进上界为 $O(\log n)$，这里的总时间相当于遍历这颗二叉树的所有节点，故总时间的渐进上界是 $O(\sum_{i=1}^{\log n} 2^{i-1})=O(n)$，故渐进时间复杂度为 $O(n)$。
+ 空间复杂度：递归会使用 $O(\log n)$ 的栈空间，故渐进空间复杂度为 $O(\log n)$。

#### 题外话
「方法二」相较于「方法一」来说，时间复杂度相同，但是因为使用了递归，并且维护了四个信息的结构体，运行的时间略长，空间复杂度也不如方法一优秀，而且难以理解。那么这种方法存在的意义是什么呢？ 对于这道题而言，确实是如此的。但是仔细观察「方法二」，它不仅可以解决区间 $[0, n-1]$，还可以用于解决任意的子区间 $[l,r]$ 的问题。如果我们把 $[0, n-1]$ 分治下去出现的所有子区间的信息都用堆式存储的方式记忆化下来，即建成一颗真正的树之后，我们就可以在 $O(\log n)$ 的时间内求到任意区间内的答案，我们甚至可以修改序列中的值，做一些简单的维护，之后仍然可以在 $O(\log n)$ 的时间内求到任意区间内的答案，对于大规模查询的情况下，这种方法的优势便体现了出来。这棵树就是上文提及的一种神奇的数据结构——线段树。
