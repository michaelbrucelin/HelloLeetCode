### [RLE 迭代器](https://leetcode.cn/problems/rle-iterator/solutions/18777/rle-die-dai-qi-by-leetcode/?envType=problem-list-v2&envId=ySsxoJfz)

#### 方法一：维护下一个元素的位置和删除次数

**分析**

在调用 `next()` 函数时，我们不会真正删除剩余的元素（或者说改变数组 `A` 的值），而是维护两个变量 `i` 和 `q`，其中 `i` 表示迭代器当前指向的是元素 `A[i + 1]`，`q` 表示它已经被删除的次数，`q` 的值不会大于 `A[i]`。

例如，当数组 `A` 为 `[1,2,3,4]` 时，它表示的序列为 `[2,4,4,4]`。当 `i` 和 `q` 的值分别为 `0` 和 `0` 时，表示没有任何元素被删除；当 `i` 和 `q` 的值分别为 `0` 和 `1` 时，表示元素 `A[0 + 1] = 2` 被删除了 `1` 次；当 `i` 和 `q` 的值分别为 `2` 和 `1` 时，表示元素 `A[2 + 1] = 4` 被删除了 `1` 次，且之前的元素被全部删除。

**算法**

如果我们调用 `next(n)`，即删除 `n` 个元素，那么对于当前的元素 `A[i + 1]`，我们还可以删除的次数为 `D = A[i] - q`。

如果 `n > D`，那么我们会删除所有的 `A[i + 1]`，并迭代到下一个元素，即 `n -= D; i += 2; q = 0`。

如果 `n <= D`，那么我们删除的最后一个元素就为 `A[i + 1]`，即 `q += D; return A[i + 1]`。

```Java
class RLEIterator {
    int[] A;
    int i, q;

    public RLEIterator(int[] A) {
        this.A = A;
        i = q = 0;
    }

    public int next(int n) {
        while (i < A.length) {
            if (q + n > A[i]) {
                n -= A[i] - q;
                q = 0;
                i += 2;
            } else {
                q += n;
                return A[i+1];
            }
        }

        return -1;
    }
}

```

```Python
class RLEIterator(object):

    def __init__(self, A):
        self.A = A
        self.i = 0
        self.q = 0

    def next(self, n):
        while self.i < len(self.A):
            if self.q + n > self.A[self.i]:
                n -= self.A[self.i] - self.q
                self.q = 0
                self.i += 2
            else:
                self.q += n
                return self.A[self.i+1]
        return -1
```

**复杂度分析**

- 时间复杂度：$O(N+Q)$，其中 $N$ 是数组 `A` 的长度，$Q$ 是调用函数 `next()` 的次数。
- 空间复杂度：$O(N)$。
