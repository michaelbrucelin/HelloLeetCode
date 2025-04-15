### [交易逆序对的总数](https://leetcode.cn/problems/shu-zu-zhong-de-ni-xu-dui-lcof/solutions/216984/shu-zu-zhong-de-ni-xu-dui-by-leetcode-solution/)

#### 方法一：归并排序

**预备知识**

「归并排序」是分治思想的典型应用，它包含这样三个步骤：

- **分解：** 待排序的区间为 [l,r]，令 $m=\lfloor \frac{l+r}{2} \rfloor$，我们把 $[l,r]$ 分成 $[l,m]$ 和 $[m+1,r]$
- **解决：** 使用归并排序递归地排序两个子序列
- **合并：** 把两个已经排好序的子序列 $[l,m]$ 和 $[m+1,r]$ 合并起来

在待排序序列长度为 $1$ 的时候，递归开始「回升」，因为我们默认长度为 $1$ 的序列是排好序的。

**思路**

那么求逆序对和归并排序又有什么关系呢？关键就在于「归并」当中「并」的过程。我们通过一个实例来看看。假设我们有两个已排序的序列等待合并，分别是 $L={8,12,16,22,100}$ 和 $R={9,26,55,64,91}$。一开始我们用指针 `lPtr = 0` 指向 $L$ 的首部，`rPtr = 0` 指向 $R$ 的头部。记已经合并好的部分为 $M$。

```c
L = [8, 12, 16, 22, 100]   R = [9, 26, 55, 64, 91]  M = []
     |                          |
   lPtr                       rPtr
```

我们发现 `lPtr` 指向的元素小于 `rPtr` 指向的元素，于是把 `lPtr` 指向的元素放入答案，并把 `lPtr` 后移一位。

```c
L = [8, 12, 16, 22, 100]   R = [9, 26, 55, 64, 91]  M = [8]
        |                       |
      lPtr                     rPtr
```

这个时候我们把左边的 $8$ 加入了答案，我们发现右边没有数比 $8$ 小，所以 $8$ 对逆序对总数的「贡献」为 $0$。

接着我们继续合并，把 $9$ 加入了答案，此时 `lPtr` 指向 $12$，`rPtr` 指向 $26$。

```c
L = [8, 12, 16, 22, 100]   R = [9, 26, 55, 64, 91]  M = [8, 9]
        |                          |
       lPtr                       rPtr
```

此时 `lPtr` 比 `rPtr` 小，把 `lPtr` 对应的数加入答案，并考虑它对逆序对总数的贡献为 `rPtr` 相对 $R$ 首位置的偏移 $1$（即右边只有一个数比 $12$ 小，所以只有它和 $12$ 构成逆序对），以此类推。

我们发现用这种「算贡献」的思想在合并的过程中计算逆序对的数量的时候，只在 `lPtr` 右移的时候计算，是基于这样的事实：当前 `lPtr` 指向的数字比 `rPtr` 小，但是比 $R$ 中 `[0 ... rPtr - 1]` 的其他数字大，`[0 ... rPtr - 1]` 的其他数字本应当排在 `lPtr` 对应数字的左边，但是它排在了右边，所以这里就贡献了 `rPtr` 个逆序对。

利用这个思路，我们可以写出如下代码。

**代码**

```C++
class Solution {
public:
    int mergeSort(vector<int>& record, vector<int>& tmp, int l, int r) {
        if (l >= r) {
            return 0;
        }

        int mid = (l + r) / 2;
        int inv_count = mergeSort(record, tmp, l, mid) + mergeSort(record, tmp, mid + 1, r);
        int i = l, j = mid + 1, pos = l;
        while (i <= mid && j <= r) {
            if (record[i] <= record[j]) {
                tmp[pos] = record[i];
                ++i;
                inv_count += (j - (mid + 1));
            }
            else {
                tmp[pos] = record[j];
                ++j;
            }
            ++pos;
        }
        for (int k = i; k <= mid; ++k) {
            tmp[pos++] = record[k];
            inv_count += (j - (mid + 1));
        }
        for (int k = j; k <= r; ++k) {
            tmp[pos++] = record[k];
        }
        copy(tmp.begin() + l, tmp.begin() + r + 1, record.begin() + l);
        return inv_count;
    }

    int reversePairs(vector<int>& record) {
        int n = record.size();
        vector<int> tmp(n);
        return mergeSort(record, tmp, 0, n - 1);
    }
};
```

```Java
public class Solution {
    public int reversePairs(int[] record) {
        int len = record.length;

        if (len < 2) {
            return 0;
        }

        int[] copy = new int[len];
        for (int i = 0; i < len; i++) {
            copy[i] = record[i];
        }

        int[] temp = new int[len];
        return reversePairs(copy, 0, len - 1, temp);
    }

    private int reversePairs(int[] record, int left, int right, int[] temp) {
        if (left == right) {
            return 0;
        }

        int mid = left + (right - left) / 2;
        int leftPairs = reversePairs(record, left, mid, temp);
        int rightPairs = reversePairs(record, mid + 1, right, temp);

        if (record[mid] <= record[mid + 1]) {
            return leftPairs + rightPairs;
        }

        int crossPairs = mergeAndCount(record, left, mid, right, temp);
        return leftPairs + rightPairs + crossPairs;
    }

    private int mergeAndCount(int[] record, int left, int mid, int right, int[] temp) {
        for (int i = left; i <= right; i++) {
            temp[i] = record[i];
        }

        int i = left;
        int j = mid + 1;

        int count = 0;
        for (int k = left; k <= right; k++) {

            if (i == mid + 1) {
                record[k] = temp[j];
                j++;
            } else if (j == right + 1) {
                record[k] = temp[i];
                i++;
            } else if (temp[i] <= temp[j]) {
                record[k] = temp[i];
                i++;
            } else {
                record[k] = temp[j];
                j++;
                count += (mid - i + 1);
            }
        }
        return count;
    }
}
```

```Python
class Solution:
    def mergeSort(self, record, tmp, l, r):
        if l >= r:
            return 0

        mid = (l + r) // 2
        inv_count = self.mergeSort(record, tmp, l, mid) + self.mergeSort(record, tmp, mid + 1, r)
        i, j, pos = l, mid + 1, l
        while i <= mid and j <= r:
            if record[i] <= record[j]:
                tmp[pos] = record[i]
                i += 1
                inv_count += (j - (mid + 1))
            else:
                tmp[pos] = record[j]
                j += 1
            pos += 1
        for k in range(i, mid + 1):
            tmp[pos] = record[k]
            inv_count += (j - (mid + 1))
            pos += 1
        for k in range(j, r + 1):
            tmp[pos] = record[k]
            pos += 1
        record[l:r+1] = tmp[l:r+1]
        return inv_count

    def reversePairs(self, record: List[int]) -> int:
        n = len(record)
        tmp = [0] * n
        return self.mergeSort(record, tmp, 0, n - 1)
```

```Go
func reversePairs(record []int) int {
    return mergeSort(record, 0, len(record)-1)
}

func mergeSort(record []int, start, end int) int {
    if start >= end {
        return 0
    }
    mid := start + (end - start)/2
    cnt := mergeSort(record, start, mid) + mergeSort(record, mid + 1, end)
    tmp := []int{}
    i, j := start, mid + 1
    for i <= mid && j <= end {
        if record[i] <= record[j] {
            tmp = append(tmp, record[i])
            cnt += j - (mid + 1)
            i++
        } else {
            tmp = append(tmp, record[j])
            j++
        }
    }
    for ; i <= mid; i++ {
        tmp = append(tmp, record[i])
        cnt += end - (mid + 1) + 1
    }
    for ; j <= end; j++ {
        tmp = append(tmp, record[j])
    }
    for i := start; i <= end; i++ {
        record[i] = tmp[i - start]
    }
    return cnt
}
```

**复杂度分析**

记序列长度为 $n$。

- 时间复杂度：同归并排序 $O(n\log n)$。
- 空间复杂度：同归并排序 $O(n)$，因为归并排序需要用到一个临时数组。

#### 方法二：离散化树状数组

**预备知识**

「树状数组」是一种可以动态维护序列前缀和的数据结构，它的功能是：

- **单点更新 `update(i, v)`：** 把序列 $i$ 位置的数加上一个值 $v$，这题 $v=1$
- **区间查询 `query(i)`：** 查询序列 $[1 \dots i]$ 区间的区间和，即 $i$ 位置的前缀和

修改和查询的时间代价都是 $O(\log n)$，其中 $n$ 为需要维护前缀和的序列的长度。

**思路**

记题目给定的序列为 $a$，我们规定 $a_i$ 的取值集合为 $a$ 的「值域」。我们用桶来表示值域中的每一个数，桶中记录这些数字出现的次数。假设$a={5,5,2,3,6}$，那么遍历这个序列得到的桶是这样的：

```c
index  ->  1 2 3 4 5 6 7 8 9
value  ->  0 1 1 0 2 1 0 0 0
```

我们可以看出它第 $i-1$ 位的前缀和表示「有多少个数比 $i$ 小」。那么我们可以从后往前遍历序列 $a$，记当前遍历到的元素为 $a_i$，我们把 $a_i$ 对应的桶的值自增 $1$，把 $i-1$ 位置的前缀和加入到答案中算贡献。为什么这么做是对的呢，因为我们在循环的过程中，我们把原序列分成了两部分，后半部部分已经遍历过（已入桶），前半部分是待遍历的（未入桶），那么我们求到的 $i-1$ 位置的前缀和就是「已入桶」的元素中比 $a_i$ 大的元素的总和，而这些元素在原序列中排在 $a_i$ 的后面，但它们本应该排在 $a_i$ 的前面，这样就形成了逆序对。

我们显然可以用数组来实现这个桶，可问题是如果 $a_i$ 中有很大的元素，比如 $10^9$，我们就要开一个大小为 $10^9$ 的桶，内存中是存不下的。这个桶数组中很多位置是 $0$，有效位置是稀疏的，我们要想一个办法让有效的位置全聚集到一起，减少无效位置的出现，这个时候我们就需要用到一个方法——离散化。

离散化一个序列的前提是我们只关心这个序列里面元素的相对大小，而不关心绝对大小（即只关心元素在序列中的排名）；离散化的目的是让原来分布零散的值聚集到一起，减少空间浪费。那么如何获得元素排名呢，我们可以对原序列排序后去重，对于每一个 $a_i$ 通过二分查找的方式计算排名作为离散化之后的值。当然这里也可以不去重，不影响排名。

**代码**

```C++
class BIT {
private:
    vector<int> tree;
    int n;

public:
    BIT(int _n): n(_n), tree(_n + 1) {}

    static int lowbit(int x) {
        return x & (-x);
    }

    int query(int x) {
        int ret = 0;
        while (x) {
            ret += tree[x];
            x -= lowbit(x);
        }
        return ret;
    }

    void update(int x) {
        while (x <= n) {
            ++tree[x];
            x += lowbit(x);
        }
    }
};

class Solution {
public:
    int reversePairs(vector<int>& record) {
        int n = record.size();
        vector<int> tmp = record;
        // 离散化
        sort(tmp.begin(), tmp.end());
        for (int& num: record) {
            num = lower_bound(tmp.begin(), tmp.end(), num) - tmp.begin() + 1;
        }
        // 树状数组统计逆序对
        BIT bit(n);
        int ans = 0;
        for (int i = n - 1; i >= 0; --i) {
            ans += bit.query(record[i] - 1);
            bit.update(record[i]);
        }
        return ans;
    }
};
```

```Java
class Solution {
    public int reversePairs(int[] record) {
        int n = record.length;
        int[] tmp = new int[n];
        System.arraycopy(record, 0, tmp, 0, n);
        // 离散化
        Arrays.sort(tmp);
        for (int i = 0; i < n; ++i) {
            record[i] = Arrays.binarySearch(tmp, record[i]) + 1;
        }
        // 树状数组统计逆序对
        BIT bit = new BIT(n);
        int ans = 0;
        for (int i = n - 1; i >= 0; --i) {
            ans += bit.query(record[i] - 1);
            bit.update(record[i]);
        }
        return ans;
    }
}

class BIT {
    private int[] tree;
    private int n;

    public BIT(int n) {
        this.n = n;
        this.tree = new int[n + 1];
    }

    public static int lowbit(int x) {
        return x & (-x);
    }

    public int query(int x) {
        int ret = 0;
        while (x != 0) {
            ret += tree[x];
            x -= lowbit(x);
        }
        return ret;
    }

    public void update(int x) {
        while (x <= n) {
            ++tree[x];
            x += lowbit(x);
        }
    }
}
```

```Python
class BIT:
    def __init__(self, n):
        self.n = n
        self.tree = [0] * (n + 1)

    @staticmethod
    def lowbit(x):
        return x & (-x)
    
    def query(self, x):
        ret = 0
        while x > 0:
            ret += self.tree[x]
            x -= BIT.lowbit(x)
        return ret

    def update(self, x):
        while x <= self.n:
            self.tree[x] += 1
            x += BIT.lowbit(x)

class Solution:
    def reversePairs(self, record: List[int]) -> int:
        n = len(record)
        # 离散化
        tmp = sorted(record)
        for i in range(n):
            record[i] = bisect.bisect_left(tmp, record[i]) + 1
        # 树状数组统计逆序对
        bit = BIT(n)
        ans = 0
        for i in range(n - 1, -1, -1):
            ans += bit.query(record[i] - 1)
            bit.update(record[i])
        return ans
```

```Go
func reversePairs(record []int) int {
     n := len(record)
     tmp := make([]int, n)
     copy(tmp, record)
     sort.Ints(tmp)

     for i := 0; i < n; i++ {
         record[i] = sort.SearchInts(tmp, record[i]) + 1
     }

     bit := BIT{
         n: n,
         tree: make([]int, n + 1),
     }

     ans := 0
     for i := n - 1; i >= 0; i-- {
         ans += bit.query(record[i] - 1)
         bit.update(record[i])
     }
     return ans
}

type BIT struct {
    n int
    tree []int
}

func (b BIT) lowbit(x int) int { return x & (-x) }

func (b BIT) query(x int) int {
    ret := 0
    for x > 0 {
        ret += b.tree[x]
        x -= b.lowbit(x)
    }
    return ret
}

func (b BIT) update(x int) {
    for x <= b.n {
        b.tree[x]++
        x += b.lowbit(x)
    }
}
```

**复杂度分析**

- 时间复杂度：离散化的过程中使用了时间代价为 $O(n\log n)$ 的排序，单次二分的时间代价为 $O(\log n)$，一共有 $n$ 次，总时间代价为 $O(n\log n)$；循环执行 $n$ 次，每次进行 $O(\log n)$ 的修改和 $O(\log n)$ 的查找，总时间代价为 $O(n\log n)$。故渐进时间复杂度为 $O(n\log n)$。
- 空间复杂度：树状数组需要使用长度为 $n$ 的数组作为辅助空间，故渐进空间复杂度为 $O(n)$。
