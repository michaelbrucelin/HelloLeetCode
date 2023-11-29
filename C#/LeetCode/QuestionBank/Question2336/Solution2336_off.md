### [无限集中的最小数字](https://leetcode.cn/problems/smallest-number-in-infinite-set/solutions/2542156/wu-xian-ji-zhong-de-zui-xiao-shu-zi-by-l-5mfr/)

#### 方法一：有序集合

**思路与算法**

由于一开始类中包含**所有正整数**，并且操作要么添加**任意**的正整数，要么删除**最小**的正整数，因此我们可以期望，在任意时刻，存在一个正整数 $thres$，使得所有大于等于 $thres$ 的正整数均在类中。并且这个 $thres$ 不会很大：如果操作进行了 $k$ 次，那么 $thres$ 不会超过 $k + 1$。

> 这是因为只有当我们删除正整数时，$thres$ 才会变大。但由于我们只能删除**最小**的正整数，因此一次删除操作最多将 $thres$ 增加 $1$，而 $thres$ 的初始值为 $1$。

因此，我们可以使用一个有序集合 $s$ 维护所有小于 $thres$ 的正整数，并用 $thres$ 表示所有大于等于 $thres$ 的正整数。对于题目描述中的两种操作：

-   如果要删除最小的正整数，那么当 $s$ 不为空时，我们删除 $s$ 中最小的正整数，否则删除 $thres$ 并将 $thres$ 的值增加 $1$；
-   如果要添加一个正整数，如果它大于等于 $thres$，则不进行任何操作，否则将其加入 $s$ 中。

**代码**

```c++
class SmallestInfiniteSet {
public:
    SmallestInfiniteSet() {}
    
    int popSmallest() {
        if (s.empty()) {
            int ans = thres;
            ++thres;
            return ans;
        }
        int ans = *s.begin();
        s.erase(s.begin());
        return ans;
    }
    
    void addBack(int num) {
        if (num < thres) {
            s.insert(num);
        }
    }

private:
    int thres = 1;
    set<int> s;
};
```

```java
class SmallestInfiniteSet {
    private int thres;
    private TreeSet<Integer> set;

    public SmallestInfiniteSet() {
        thres = 1;
        set = new TreeSet<Integer>();
    }

    public int popSmallest() {
        if (set.isEmpty()) {
            int ans = thres;
            ++thres;
            return ans;
        }
        int ans = set.pollFirst();
        return ans;
    }

    public void addBack(int num) {
        if (num < thres) {
            set.add(num);
        }
    }
}
```

```python
from sortedcontainers import SortedSet

class SmallestInfiniteSet:
    def __init__(self):
        self.thres = 1
        self.s = SortedSet()

    def popSmallest(self) -> int:
        s_ = self.s

        if not s_:
            ans = self.thres
            self.thres += 1
            return ans
        
        ans = s_[0]
        s_.pop(0)
        return ans

    def addBack(self, num: int) -> None:
        s_ = self.s

        if num < self.thres:
            s_.add(num)
```

```go
type SmallestInfiniteSet struct {
    thres int
    s *treeset.Set
}

func Constructor() SmallestInfiniteSet {
    return SmallestInfiniteSet{
        thres:1,
        s:treeset.NewWithIntComparator(),
    }
}

func (this *SmallestInfiniteSet) PopSmallest() int {
    if this.s.Empty() {
        ans := this.thres
        this.thres++
        return ans
    }
    it := this.s.Iterator()
    it.Next()
    ans := it.Value().(int)
    this.s.Remove(ans)
    return ans
}

func (this *SmallestInfiniteSet) AddBack(num int)  {
    if num < this.thres {
        this.s.Add(num)
    }
}
```

```javascript
var SmallestInfiniteSet = function() {
    this.thres = 1;
    this.s = new Set();
    this.pq = new MinPriorityQueue();
};

SmallestInfiniteSet.prototype.popSmallest = function() {
    let ans = 0;
    if (this.s.size == 0) {
        ans = this.thres;
        this.thres++;
        return ans;
    }
    ans = this.pq.dequeue().element;
    this.s.delete(ans);
    return ans;
};

SmallestInfiniteSet.prototype.addBack = function(num) {
    if (num < this.thres && !this.s.has(num)) {
        this.s.add(num);
        this.pq.enqueue(num);
    }
};
```

**复杂度分析**

-   时间复杂度：初始化需要的时间为 $O(1)$，单次任意操作的时间复杂度为 $O(\log n)$，其中 $n$ 是当前有序集合 $s$ 中的元素个数，它不会超过已经操作的次数。
-   空间复杂度：$O(n)$，即为有序集合 $s$ 需要使用的空间。
