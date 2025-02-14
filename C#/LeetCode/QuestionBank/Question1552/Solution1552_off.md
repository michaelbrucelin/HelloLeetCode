### [两球之间的磁力](https://leetcode.cn/problems/magnetic-force-between-two-balls/solutions/403701/liang-qiu-zhi-jian-de-ci-li-by-leetcode-solution/)

#### 方法一：二分查找

**思路与算法**

对于此题我们需要先思考一个子问题：给定 $n$ 个空篮子，$m$ 个球放置的位置已经确定。那么「最小磁力」我们该如何计算？

不难得出「最小磁力」为这 $m$ 个球中相邻两球距离的最小值的结论。对于 $i<j<k$ 三个位置的球，最小磁力一定是 $j-i$ 和 $k-j$ 的较小值，而不是跨越了位置 $j$ 的 $i$ 和 $k$ 的差值 $k-i$。

明确了给定位置最小磁力的计算方法，回到本题，在本题中 $m$ 个球的位置是由我们决定的，只知道空篮子的位置，且题目希望通过排列 $m$ 个球的位置来「最大化最小磁力」。

我们假定最终的答案是 $ans$，即这个时候最小磁力为 $ans$，那么我们知道小于 $ans$ 的答案一定也合法。因为既然我们存在一种放置的方法使得相邻小球间距的最小值大于等于 $ans$，那么也一定大于 $[1,ans-1]$ 中的任意一个值，而大于 $ans$ 的均不合法，因此我们可以对答案进行**二分查找**。

假设我们在 $[left,right]$ 的区间查找。每次取 $mid$ 为 $left$ 和 $right$ 的平均值，进行如下操作：

- 如果当前的 $mid$ 合法，则令 $ans=mid$，并将区间缩小为 $[mid+1,right]$；
- 如果当前的 $mid$ 不合法，则将区间缩小为 $[left,mid-1]$。

最后剩下的问题是如何判断答案是否合法，即给定一个答案 $x$，是否存在一种放置方法使得相邻小球的间距最小值大于等于 $x$。这个问题其实很好解决，相邻小球的间距最小值大于等于 $x$，其实就等价于相邻小球的间距**均大于等于 $x$**。我们预先对给定的篮子的位置进行排序，那么从贪心的角度考虑，第一个小球放置的篮子一定是 $position$ 最小的篮子，即排序后的第一个篮子。那么为了满足上述条件，第二个小球放置的位置一定要大于等于 $position[0]+x$，接下来同理。因此我们从前往后扫 $position$ 数组，看在当前答案 $x$ 下我们最多能在篮子里放多少个小球，我们记这个数量为 $cnt$，如果 $cnt$ 大于等于 $m$，那么说明当前答案下我们的贪心策略能放下 $m$ 个小球且它们间距均大于等于 $x$，为合法的答案，否则不合法。

**代码**

```C++
class Solution {
public:
    bool check(int x, vector<int>& position, int m) {
        int pre = position[0], cnt = 1;
        for (int i = 1; i < position.size(); ++i) {
            if (position[i] - pre >= x) {
                pre = position[i];
                cnt += 1;
            }
        }
        return cnt >= m;
    }

    int maxDistance(vector<int>& position, int m) {
        sort(position.begin(), position.end());
        int left = 1, right = position.back() - position[0], ans = -1;
        while (left <= right) {
            int mid = (left + right) / 2;
            if (check(mid, position, m)) {
                ans = mid;
                left = mid + 1;
            } else {
                right = mid - 1;
            }
        }
        return ans;
    }
};
```

```Java
class Solution {
    public int maxDistance(int[] position, int m) {
        Arrays.sort(position);
        int left = 1, right = position[position.length - 1] - position[0], ans = -1;
        while (left <= right) {
            int mid = (left + right) / 2;
            if (check(mid, position, m)) {
                ans = mid;
                left = mid + 1;
            } else {
                right = mid - 1;
            }
        }
        return ans;
    }

    public boolean check(int x, int[] position, int m) {
        int pre = position[0], cnt = 1;
        for (int i = 1; i < position.length; ++i) {
            if (position[i] - pre >= x) {
                pre = position[i];
                cnt += 1;
            }
        }
        return cnt >= m;
    }
}
```

```JavaScript
const check = (x, position, m) => {
    let pre = position[0], cnt = 1;
    for (let i = 1; i < position.length; ++i) {
        if (position[i] - pre >= x) {
            pre = position[i];
            cnt += 1;
        }
    }
    return cnt >= m;
}
var maxDistance = function(position, m) {
    position.sort((x, y) => x - y);
    let left = 1, right = position[position.length - 1] - position[0], ans = -1;
    while (left <= right) {
        const mid = Math.floor((left + right) / 2); 
        if (check(mid, position, m)) {
            ans = mid;
            left = mid + 1;
        } else {
            right = mid - 1;
        }
    }
    return ans;
};
```

```Python
class Solution:
    def maxDistance(self, position: List[int], m: int) -> int:
        def check(x: int) -> bool:
            pre = position[0]
            cnt = 1
            for i in range(1, len(position)):
                if position[i] - pre >= x:
                    pre = position[i]
                    cnt += 1
            return cnt >= m

        position.sort()
        left, right, ans = 1, position[-1] - position[0], -1
        while left <= right:
            mid = (left + right) // 2;
            if check(mid):
                ans = mid
                left = mid + 1
            else:
                right = mid - 1
        
        return ans
```

```CSharp
public class Solution {
    public int MaxDistance(int[] position, int m) {
        Array.Sort(position);
        int left = 1, right = position[position.Length - 1] - position[0], ans = -1;
        while (left <= right) {
            int mid = (left + right) / 2;
            if (Check(mid, position, m)) {
                ans = mid;
                left = mid + 1;
            } else {
                right = mid - 1;
            }
        }
        return ans;
    }

    public bool Check(int x, int[] position, int m) {
        int pre = position[0], cnt = 1;
        for (int i = 1; i < position.Length; i++) {
            if (position[i] - pre >= x) {
                pre = position[i];
                cnt++;
            }
        }
        return cnt >= m;
    }
}
```

```Go
func maxDistance(position []int, m int) int {
    sort.Ints(position)
    left, right := 1, position[len(position)-1] - position[0]
    ans := -1
    for left <= right {
        mid := (left + right) / 2
        if check(mid, position, m) {
            ans = mid
            left = mid + 1
        } else {
            right = mid - 1
        }
    }
    return ans
}

func check(x int, position []int, m int) bool {
    pre, cnt := position[0], 1
    for i := 1; i < len(position); i++ {
        if position[i] - pre >= x {
            pre = position[i]
            cnt++
        }
    }
    return cnt >= m
}
```

```C
static int compare(const void *a, const void *b) {
    return *(int *)a - *(int *)b;
}

static bool check(int x, const int* position, int positionSize, int m) {
    int pre = position[0], cnt = 1;
    for (int i = 1; i < positionSize; ++i) {
        if (position[i] - pre >= x) {
            pre = position[i];
            cnt += 1;
        }
    }
    return cnt >= m;
}

int maxDistance(int* position, int positionSize, int m) {
    qsort(position, positionSize, sizeof(int), compare);
    int left = 1, right = position[positionSize - 1] - position[0], ans = -1;
    while (left <= right) {
        int mid = (left + right) / 2;
        if (check(mid, position, positionSize, m)) {
            ans = mid;
            left = mid + 1;
        } else {
            right = mid - 1;
        }
    }
    return ans;
}
```

```TypeScript
function maxDistance(position: number[], m: number): number {
    position.sort((x, y) => x - y);
    let left = 1, right = position[position.length - 1] - position[0], ans = -1;
    while (left <= right) {
        const mid = Math.floor((left + right) / 2); 
        if (check(mid, position, m)) {
            ans = mid;
            left = mid + 1;
        } else {
            right = mid - 1;
        }
    }
    return ans;
};

function check(x: number, position: number[], m: number): boolean {
    let pre = position[0], cnt = 1;
    for (let i = 1; i < position.length; ++i) {
        if (position[i] - pre >= x) {
            pre = position[i];
            cnt += 1;
        }
    }
    return cnt >= m;
}
```

```Rust
impl Solution {
    pub fn max_distance(position: Vec<i32>, m: i32) -> i32 {
        let mut position = position;
        position.sort();
        let mut left = 1;
        let mut right = position[position.len() - 1] - position[0];
        let mut ans = -1;
        while left <= right {
            let mid = (left + right) / 2;
            if Self::check(mid, &position, m) {
                ans = mid;
                left = mid + 1;
            } else {
                right = mid - 1;
            }
        }
        ans
    }

    fn check(x: i32, position: &Vec<i32>, m: i32) -> bool {
        let mut pre = position[0];
        let mut cnt = 1;
        for &pos in &position[1..] {
            if pos - pre >= x {
                pre = pos;
                cnt += 1;
            }
        }
        cnt >= m
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n \log (nS))$，其中 $n$ 为篮子的个数，$S$ 为篮子位置的上限。对篮子位置排序需要 $O(n \log n)$ 的时间复杂度，二分查找对篮子位置间隔进行二分，需要 $O(\log S)$ 的时间复杂度。每次统计答案是否符合要求需要 $O(n)$ 的时间复杂度，因此总时间复杂度为 O(n \log n+n \log S)=$O(n \log (nS))$。
- 空间复杂度：O( \log n)，即为排序需要的栈空间。
