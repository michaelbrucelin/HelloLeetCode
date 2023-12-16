### [统计区间中的整数数目](https://leetcode.cn/problems/count-integers-in-intervals/solutions/2566065/tong-ji-qu-jian-zhong-de-zheng-shu-shu-m-jkey/)

#### 方法一：平衡二叉搜索树

##### 思路

用一棵平衡二叉搜索树维护插入的区间，树中的区间两两不相交。当插入一个新的区间时，需要找出所有与待插入区间有重合整数的区间，将这些区间合并成一个新的区间后插入平衡树里。间隔包含两个属性，左端点 $l$ 和右端点 $r$，其中左端点在树中参与排序。当插入一个新的间隔 $add(left, right)$ 时，需要找到树中的最大的间隔 $interval$ 满足：$interval.l \leq right$，这个是可能与待插入的间隔相交的最大的间隔，如果相交，则将它们合并，并且继续寻找下一个这样的间隔，直到不存在这样的间隔或者找到的间隔与待插入的间隔不相交。同时用一个整数 $cnt$ 维护树中的间隔覆盖的整数，当调用 $count$ 时，直接返回即可。

##### 代码

```java
class CountIntervals {
    TreeMap<Integer, Integer> map = new TreeMap<>();
    int cnt = 0;

    public CountIntervals() {

    }
    
    public void add(int left, int right) {
        Map.Entry<Integer, Integer> interval = map.floorEntry(right);
        while (interval != null && interval.getValue() >= left) {
        int l = interval.getKey(), r = interval.getValue();
            left = Math.min(left, l);
            right = Math.max(right, r);
            cnt -= r - l + 1;
            map.remove(l);
            interval = map.floorEntry(right);
        }
        cnt += (right - left + 1);
        map.put(left, right);
    }
    
    public int count() {
        return cnt;
    }
}
```

```c++
class CountIntervals {
public:
    CountIntervals() {

    }
    
    void add(int left, int right) {
        auto interval = mp.upper_bound(right);
        if (interval != mp.begin()) {
            interval--;
        }
        while (interval != mp.end() && interval->first <= right && interval->second >= left) {
            int l = interval->first, r = interval->second;
            left = min(left, l);
            right = max(right, r);
            cnt -= r - l + 1;
            mp.erase(interval);
            interval = mp.upper_bound(right);
            if (interval != mp.begin()) {
                interval--;
            }
        }
        cnt += (right - left + 1);
        mp[left] = right;
    }
    
    int count() {
        return cnt;
    }
private:
    int cnt = 0;
    map<int, int> mp;
};
```

```python
from sortedcontainers import SortedDict

class CountIntervals:

    def __init__(self):
        self.mp = SortedDict()
        self.cnt = 0

    def add(self, left: int, right: int) -> None:
        interval_index = self.mp.bisect_right(right)
        if interval_index != 0:
            interval_index -= 1
        while interval_index < len(self.mp) and self.mp.keys()[interval_index] <= right \
                                            and self.mp.values()[interval_index] >= left:
            l, r = self.mp.items()[interval_index]
            left = min(left, l)
            right = max(right, r)
            self.cnt -= r - l + 1
            self.mp.popitem(interval_index)
            interval_index = self.mp.bisect_right(right)
            if interval_index != 0:
                interval_index -= 1
        self.cnt += right - left + 1
        self.mp[left] = right

    def count(self) -> int:
        return self.cnt
```

```go
type CountIntervals struct {
    *treemap.Map
    cnt int
}

func Constructor() CountIntervals {
    return CountIntervals {
        treemap.NewWithIntComparator(), 0,
    }
}

func (this *CountIntervals) Add(left int, right int)  {
    for k, v := this.Floor(right); k != nil && v.(int) >= left; k, v = this.Floor(right) {
        l, r := k.(int), v.(int)
        left, right = min(left, l), max(right, r)
        this.cnt -= r - l + 1
        this.Remove(k)
    }
    this.cnt += right - left + 1
    this.Put(left, right)
}

func (this *CountIntervals) Count() int {
    return this.cnt
}
```

#### 复杂度分析

- 时间复杂度：$add$ 的均摊时间复杂度为 $O(\log{n})$，其中 $n$ 是调用 $add$ 的次数，因为每个区间最多只会被加入和删除一次，单次加入和删除的时间复杂度是 $O(\log{n})$。单次 $add$ 的复杂度最差情况是 $O(n \times \log{n})$。$count$ 的时间复杂度是 $O(\log{1})$。
- 空间复杂度：$O(n)$。
