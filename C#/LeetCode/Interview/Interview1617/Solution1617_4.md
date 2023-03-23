#### [������������](https://leetcode.cn/problems/contiguous-sequence-lcci/solutions/586439/lian-xu-shu-lie-by-leetcode-solution-be4z/)

**˼·���㷨**
**������η��������ڡ��߶������������������������⡹�� `pushUp` ������** Ҳ����߻�û�нӴ����߶�����û�й�ϵ�������������ݼ�����û���κ��߶����Ļ�������Ȼ�������������Ȥ�Ļ����Ƽ��Ķ��߶�������ϲ������**���ѯ��**�ġ���������������������⡹�͡���������Ӷκ����⡹�����Ƿǳ���Ȥ�ġ� ���Ƕ���һ������ `get(a, l, r)` ��ʾ��ѯ $a$ ���� $[l,r]$ �����ڵ�����Ӷκͣ���ô��������Ҫ��Ĵ𰸾��� `get(nums, 0, nums.size() - 1)`����η���ʵ����������أ�����һ������ $[l,r]$������ȡ $m = \lfloor \frac{l + r}{2} \rfloor$�������� $[l,m]$ �� $[m+1,r]$ ������⡣���ݹ��������ֱ�����䳤����СΪ $1$ ��ʱ�򣬵ݹ顸��ʼ�����������ʱ�����ǿ������ͨ�� $[l,m]$ �������Ϣ�� $[m+1,r]$ �������Ϣ�ϲ������� $[l,r]$ ����Ϣ����ؼ������������ǣ�
+ ����Ҫά���������Щ��Ϣ�أ�
+ ������κϲ���Щ��Ϣ�أ�

����һ������ $[l,r]$�����ǿ���ά���ĸ�����
+ $lSum$ ��ʾ $[l,r]$ ���� $l$ Ϊ��˵������Ӷκ�
+ $rSum$ ��ʾ $[l,r]$ ���� $r$ Ϊ�Ҷ˵������Ӷκ�
+ $mSum$ ��ʾ $[l,r]$ �ڵ�����Ӷκ�
+ $iSum$ ��ʾ $[l,r]$ �������

���¼�� $[l,m]$ Ϊ $[l,r]$ �ġ��������䡹��$[m+1,r]$ Ϊ $[l,r]$ �ġ��������䡹�����ǿ������ά����Щ���أ����ͨ���������������Ϣ�ϲ��õ� $[l,r]$ ����Ϣ�������ڳ���Ϊ $1$ ������ $[i, i]$���ĸ�����ֵ���� $nums[i]$ ��ȡ����ڳ��ȴ��� $1$ �����䣺
+ �������ά������ $iSum$������ $[l,r]$ �� $iSum$ �͵��ڡ��������䡹�� $iSum$ ���ϡ��������䡹�� $iSum$��
+ ���� $[l,r]$ �� $lSum$���������ֿ��ܣ���Ҫô���ڡ��������䡹�� $lSum$��Ҫô���ڡ��������䡹�� $iSum$ ���ϡ��������䡹�� $lSum$������ȡ��
+ ���� $[l,r]$ �� $rSum$��ͬ����Ҫô���ڡ��������䡹�� $rSum$��Ҫô���ڡ��������䡹�� $iSum$ ���ϡ��������䡹�� $rSum$������ȡ��
+ ������������������֮�󣬾ͺܺü��� $[l,r]$ �� $mSum$ �ˡ����ǿ��Կ��� $[l,r]$ �� $mSum$ ��Ӧ�������Ƿ��Խ $m$���������ܲ���Խ $m$��Ҳ����˵ $[l,r]$ �� $mSum$ �����ǡ��������䡹�� $mSum$ �� ���������䡹�� $mSum$ �е�һ������Ҳ���ܿ�Խ $m$�������ǡ��������䡹�� $rSum$ �� ���������䡹�� $lSum$ ��͡�����ȡ��

��������͵õ��˽���� 

**����** 
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

**���Ӷȷ���** �������� $a$ �ĳ���Ϊ $n$��
+ ʱ�临�Ӷȣ��������ǰѵݹ�Ĺ��̿�����һ�Ŷ������������������ô��Ŷ���������ȵĽ����Ͻ�Ϊ $O(\log n)$���������ʱ���൱�ڱ�����Ŷ����������нڵ㣬����ʱ��Ľ����Ͻ��� $O(\sum_{i=1}^{\log n} 2^{i-1})=O(n)$���ʽ���ʱ�临�Ӷ�Ϊ $O(n)$��
+ �ռ临�Ӷȣ��ݹ��ʹ�� $O(\log n)$ ��ջ�ռ䣬�ʽ����ռ临�Ӷ�Ϊ $O(\log n)$��

#### ���⻰
��������������ڡ�����һ����˵��ʱ�临�Ӷ���ͬ��������Ϊʹ���˵ݹ飬����ά�����ĸ���Ϣ�Ľṹ�壬���е�ʱ���Գ����ռ临�Ӷ�Ҳ���緽��һ���㣬����������⡣��ô���ַ������ڵ�������ʲô�أ� �����������ԣ�ȷʵ����˵ġ�������ϸ�۲졸�������������������Խ������ $[0, n-1]$�����������ڽ������������� $[l,r]$ �����⡣������ǰ� $[0, n-1]$ ������ȥ���ֵ��������������Ϣ���ö�ʽ�洢�ķ�ʽ���仯������������һ����������֮�����ǾͿ����� $O(\log n)$ ��ʱ���������������ڵĴ𰸣��������������޸������е�ֵ����һЩ�򵥵�ά����֮����Ȼ������ $O(\log n)$ ��ʱ���������������ڵĴ𰸣����ڴ��ģ��ѯ������£����ַ��������Ʊ������˳�������������������ἰ��һ����������ݽṹ�����߶�����
