### [构成整天的下标对数目 II](https://leetcode.cn/problems/count-pairs-that-form-a-complete-day-ii/solutions/2928185/gou-cheng-zheng-tian-de-xia-biao-dui-shu-4ijs/)

#### 方法一：哈希表

**思路与算法**

$hours[i]+hours[j]$ 能够被 $24$ 整除，只需 $hours[i]$ 除以 $24$ 的余数与 $hours[j]$ 除以 $24$ 的余数之和能够被 $24$ 整除。

我们可以枚举 $hours[i]$，每一个 $hours[i]$ 对答案的贡献就是能与其成对的 $hours[j]$ 的数量。如果暴力查找能够成对的 $hours[j]$，则每次都需要遍历一遍 $hours$ 数组中剩余的元素。我们可以使用一个长度为 $24$ 的数组 $cnt$ 记录每个余数的出现次数，从而快速查询能够与 $hours[i]$ 成对的元素数量。

注意，哈希表记录的是位于我们当前枚举的 $hours[i]$ 左边的元素，也就是说我们是在枚举右边值的同时维护左边的元素。

**代码**

```C++
class Solution {
public:
    long long countCompleteDayPairs(vector<int>& hours) {
        long long ans = 0;
        vector<int> cnt(24);
        for (int hour : hours) {
            ans += cnt[(24 - hour % 24) % 24];
            cnt[hour % 24]++;
        }
        return ans;
    }
};
```

```Java
class Solution {
    public long countCompleteDayPairs(int[] hours) {
        long ans = 0;
        int[] cnt = new int[24];
        for (int hour : hours) {
            ans += cnt[(24 - hour % 24) % 24];
            cnt[hour % 24]++;
        }
        return ans;
    }
}
```

```C
long long countCompleteDayPairs(int* hours, int hoursSize) {
    long long ans = 0;
    int cnt[24] = {0};
    for (int i = 0; i < hoursSize; i++) {
        int hour = hours[i];
        ans += cnt[(24 - hour % 24) % 24];
        cnt[hour % 24]++;
    }
    return ans;
}
```

```Go
func countCompleteDayPairs(hours []int) int64 {
    var ans int64 = 0
    cnt := make([]int, 24)
    for _, hour := range hours {
        ans += int64(cnt[(24 - hour % 24) % 24])
        cnt[hour % 24]++
    }
    return ans
}
```

```Python
class Solution:
    def countCompleteDayPairs(self, hours: List[int]) -> int:
        ans = 0
        cnt = [0] * 24
        for hour in hours:
            ans += cnt[(24 - hour % 24) % 24]
            cnt[hour % 24] += 1
        return ans
```

```Rust
impl Solution {
    pub fn count_complete_day_pairs(hours: Vec<i32>) -> i64 {
        let mut ans: i64 = 0;
        let mut cnt = vec![0; 24];
        for hour in hours {
            ans += cnt[(24 - hour % 24) as usize % 24] as i64;
            cnt[hour as usize % 24] += 1;
        }
        ans
    }
}
```

```CSharp
public class Solution {
    public long CountCompleteDayPairs(int[] hours) {
        long ans = 0;
        int[] cnt = new int[24];
        foreach (int hour in hours) {
            ans += cnt[(24 - hour % 24) % 24];
            cnt[hour % 24]++;
        }
        return ans;
    }
}
```

```JavaScript
var countCompleteDayPairs = function(hours) {
    let ans = 0;
    let cnt = new Array(24).fill(0);
    for (let hour of hours) {
        ans += cnt[(24 - hour % 24) % 24];
        cnt[hour % 24]++;
    }
    return ans;
};
```

```TypeScript
function countCompleteDayPairs(hours: number[]): number {
    let ans = 0;
    let cnt = new Array(24).fill(0);
    for (let hour of hours) {
        ans += cnt[(24 - hour % 24) % 24];
        cnt[hour % 24]++;
    }
    return ans;
};
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是 $hours$ 数组的长度。
- 空间复杂度：$O(24)$，哈希表的大小只需要包含 $hours[i]$ 除以 $24$ 余数的取值范围。
