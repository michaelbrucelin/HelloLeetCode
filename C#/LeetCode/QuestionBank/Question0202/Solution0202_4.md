#### [方法三：数学](https://leetcode.cn/problems/happy-number/solutions/224894/kuai-le-shu-by-leetcode-solution/)

前两种方法是你在面试中应该想到的。第三种方法不是你在面试中会写的，而是针对对数学好奇的人，因为它很有趣。

下一个值可能比自己大的最大数字是什么？根据我们之前的分析，我们知道它必须低于 243。因此，我们知道任何循环都必须包含小于 243 的数字，用这么小的数字，编写一个能找到所有周期的强力程序并不困难。

如果这样做，您会发现只有一个循环：$4 \rightarrow 16 \rightarrow 37 \rightarrow 58 \rightarrow 89 \rightarrow 145 \rightarrow 42 \rightarrow 20 \rightarrow 4$。所有其他数字都在进入这个循环的链上，或者在进入 $1$ 的链上。

因此，我们可以硬编码一个包含这些数字的散列集，如果我们达到其中一个数字，那么我们就知道在循环中。

**算法**

```python
def isHappy(self, n: int) -> bool:

    cycle_members = {4, 16, 37, 58, 89, 145, 42, 20}

    def get_next(number):
        total_sum = 0
        while number > 0:
            number, digit = divmod(number, 10)
            total_sum += digit ** 2
        return total_sum

    while n != 1 and n not in cycle_members:
        n = get_next(n)

    return n == 1
```

```java
class Solution {

    private static Set<Integer> cycleMembers =
        new HashSet<>(Arrays.asList(4, 16, 37, 58, 89, 145, 42, 20));

    public int getNext(int n) {
        int totalSum = 0;
        while (n > 0) {
            int d = n % 10;
            n = n / 10;
            totalSum += d * d;
        }
        return totalSum;
    }


    public boolean isHappy(int n) {
        while (n != 1 && !cycleMembers.contains(n)) {
            n = getNext(n);
        }
        return n == 1;
    }
}
```

```csharp
class Solution {
    public int getNext(int n) {
        int totalSum = 0;
        while (n > 0) {
            int d = n % 10;
            n = n / 10;
            totalSum += d * d;
        }
        return totalSum;
    }

    public bool IsHappy(int n) {
        HashSet<int> cycleMembers =
            new HashSet<int>(new int[8] {4, 16, 37, 58, 89, 145, 42, 20});

        while (n != 1 && !cycleMembers.Contains(n)) {
            n = getNext(n);
        }
        return n == 1;
    }
}
```

```go
func isHappy(n int) bool {
    cycle := map[int]bool{4: true, 6: true, 37: true, 58: true, 89: true, 145: true, 42: true, 20: true}
    for n != 1 && !cycle[n] {
        n = step(n)
    }
    return n == 1
}

func step(n int) int {
    sum := 0
    for n > 0 {
        sum += (n%10) * (n%10)
        n = n/10
    }
    return sum
}
```

**复杂度分析**

-   时间复杂度：$O(\log n)$。和上面一样。
-   空间复杂度：$O(1)$，我们没有保留我们所遇到的数字的历史记录。硬编码哈希集的大小是固定的。
