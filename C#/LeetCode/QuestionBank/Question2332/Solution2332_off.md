### [坐上公交的最晚时间](https://leetcode.cn/problems/the-latest-time-to-catch-a-bus/solutions/2913531/zuo-shang-gong-jiao-de-zui-wan-shi-jian-b7j5y/)

#### 方法一：模拟

**思路与算法**

由于**最早**到达的乘客优先上车，为了方便模拟，我们将公交车到达的时间和乘客到达的时间按照先后顺序进行排序。设第 $i$ 班公交车到达的时间为 $buses[i]$，此时未上车且在 $buses[i]$ 时刻之前到达的乘客按照时间先后顺序依次上车，直到车辆载客人数达到上限 $capacity$ 为止，则继续模拟第 $i+1$ 班公交车乘客上车，直到所有的车辆均模拟完毕。

此时记录最后一班公交车发车时的空位数为 $space$，此时有以下两种情形：

- 如果此时 $space>0$，则表示最后一班公交车发车时车上还有空位，这意味着我们**最晚**可以在最后一班公交发车时刻到站即可，由于**不能**跟别的乘客同时刻到达，此时从最后一班发车时刻 $buses[n-1]$ 开始向前找到一个没有乘客到达的时刻即可；
- 如果此时满足 $space=0$，则表示最后一班公交车发车时车上没有空位，这意味着我们最后一个**上车**的乘客上车以后载客**已满**，此时我们从最后一个**上车**乘客的到达时间往前找到一个没有乘客到达的时刻即可，如果到达时间晚于最后一个**上车**的乘客的到达时间，则一定无法乘车。

**代码**

```C++
class Solution {
public:
    int latestTimeCatchTheBus(vector<int>& buses, vector<int>& passengers, int capacity) {
        sort(buses.begin(), buses.end());
        sort(passengers.begin(), passengers.end());
        int pos = 0;
        int space = 0;
        for (int arrive : buses) {
            space = capacity;
            while (space > 0 && pos < passengers.size() && passengers[pos] <= arrive) {
                space--;
                pos++;
            }
        }
        
        pos--;
        int lastCatchTime = space > 0 ? buses.back() : passengers[pos];
        while (pos >= 0 && passengers[pos] == lastCatchTime) {
            pos--;
            lastCatchTime--;
        }

        return lastCatchTime;
    }
};
```

```Java
class Solution {
    public int latestTimeCatchTheBus(int[] buses, int[] passengers, int capacity) {
        Arrays.sort(buses);
        Arrays.sort(passengers);
        int pos = 0;
        int space = 0;

        for (int arrive : buses) {
            space = capacity;
            while (space > 0 && pos < passengers.length && passengers[pos] <= arrive) {
                space--;
                pos++;
            }
        }

        pos--;
        int lastCatchTime = space > 0 ? buses[buses.length - 1] : passengers[pos];
        while (pos >= 0 && passengers[pos] == lastCatchTime) {
            pos--;
            lastCatchTime--;
        }

        return lastCatchTime;
    }
}
```

```CSharp
public class Solution {
    public int LatestTimeCatchTheBus(int[] buses, int[] passengers, int capacity) {
        Array.Sort(buses);
        Array.Sort(passengers);
        int pos = 0;
        int space = 0;

        foreach (int arrive in buses) {
            space = capacity;
            while (space > 0 && pos < passengers.Length && passengers[pos] <= arrive) {
                space--;
                pos++;
            }
        }

        pos--;
        int lastCatchTime = space > 0 ? buses[buses.Length - 1] : passengers[pos];
        while (pos >= 0 && passengers[pos] == lastCatchTime) {
            pos--;
            lastCatchTime--;
        }

        return lastCatchTime;
    }
}
```

```C
int compare(const void *a, const void *b) {
    return (*(int*)a - *(int*)b);
}

int latestTimeCatchTheBus(int* buses, int busesSize, int* passengers, int passengersSize, int capacity) {
    qsort(buses, busesSize, sizeof(int), compare);
    qsort(passengers, passengersSize, sizeof(int), compare);
    int pos = 0;
    int space = 0;

    for (int i = 0; i < busesSize; i++) {
        int arrive = buses[i];
        space = capacity;
        while (space > 0 && pos < passengersSize && passengers[pos] <= arrive) {
            space--;
            pos++;
        }
    }

    pos--;
    int lastCatchTime = space > 0 ? buses[busesSize - 1] : passengers[pos];
    while (pos >= 0 && passengers[pos] == lastCatchTime) {
        pos--;
        lastCatchTime--;
    }

    return lastCatchTime;
}
```

```Python
class Solution:
    def latestTimeCatchTheBus(self, buses: List[int], passengers: List[int], capacity: int) -> int:
        buses.sort()
        passengers.sort()
        pos = 0

        for arrive in buses:
            space = capacity
            while space > 0 and pos < len(passengers) and passengers[pos] <= arrive:
                space -= 1
                pos += 1

        pos -= 1
        last_catch_time = buses[-1] if space > 0 else passengers[pos]
        while pos >= 0 and passengers[pos] == last_catch_time:
            pos -= 1
            last_catch_time -= 1

        return last_catch_time
```

```Go
func latestTimeCatchTheBus(buses []int, passengers []int, capacity int) int {
    sort.Ints(buses)
    sort.Ints(passengers)
    pos := 0
    space := 0

    for _, arrive := range buses {
        space = capacity
        for space > 0 && pos < len(passengers) && passengers[pos] <= arrive {
            space--
            pos++
        }
    }

    pos--
    lastCatchTime := buses[len(buses)-1]
    if space <= 0 {
        lastCatchTime = passengers[pos]
    }
    for pos >= 0 && passengers[pos] == lastCatchTime {
        pos--
        lastCatchTime--
    }

    return lastCatchTime
}
```

```JavaScript
var latestTimeCatchTheBus = function(buses, passengers, capacity) {
    buses.sort((a, b) => a - b);
    passengers.sort((a, b) => a - b);
    let pos = 0;
    let space = 0;

    for (const arrive of buses) {
        space = capacity;
        while (space > 0 && pos < passengers.length && passengers[pos] <= arrive) {
            space--;
            pos++;
        }
    }

    pos--;
    let lastCatchTime = space > 0 ? buses[buses.length - 1] : passengers[pos];
    while (pos >= 0 && passengers[pos] === lastCatchTime) {
        pos--;
        lastCatchTime--;
    }

    return lastCatchTime;
};
```

```TypeScript
function latestTimeCatchTheBus(buses: number[], passengers: number[], capacity: number): number {
    buses.sort((a, b) => a - b);
    passengers.sort((a, b) => a - b);
    let pos = 0;
    let space = 0;

    for (const arrive of buses) {
        space = capacity;
        while (space > 0 && pos < passengers.length && passengers[pos] <= arrive) {
            space--;
            pos++;
        }
    }

    pos--;
    let lastCatchTime = space > 0 ? buses[buses.length - 1] : passengers[pos];
    while (pos >= 0 && passengers[pos] === lastCatchTime) {
        pos--;
        lastCatchTime--;
    }

    return lastCatchTime;
};
```

```Rust
impl Solution {
    pub fn latest_time_catch_the_bus(buses: Vec<i32>, passengers: Vec<i32>, capacity: i32) -> i32 {
        let mut buses = buses;
        let mut passengers = passengers;
        buses.sort();
        passengers.sort();
        let mut pos = 0;
        let mut space = 0;

        for &arrive in &buses {
            space = capacity;
            while space > 0 && pos < passengers.len() && passengers[pos] <= arrive {
                space -= 1;
                pos += 1;
            }
        }

        pos -= 1;
        let mut last_catch_time = if space > 0 { *buses.last().unwrap() } else { passengers[pos]} ;
        while pos >= 0 && passengers[pos as usize] == last_catch_time {
            pos -= 1;
            last_catch_time -= 1;
        }

        last_catch_time
    }
}
```

```Cangjie
import std.sort.SortExtension

class Solution {
    func latestTimeCatchTheBus(buses: Array<Int64>, passengers: Array<Int64>, capacity: Int64): Int64 {
        buses.sort()
        passengers.sort()
        var pos = 0
        var space = 0
        for (arrive in buses) {
            space = capacity
            while (space > 0 && pos < passengers.size && passengers[pos] <= arrive) {
                space--
                pos++
            }
        }
        
        pos--
        var lastCatchTime = buses[buses.size - 1]
        if (space == 0) {
            lastCatchTime = passengers[pos]
        }
        while (pos >= 0 && passengers[pos] == lastCatchTime) {
            pos--
            lastCatchTime--
        }

        return lastCatchTime
    }
}
```

**复杂度分析**

- 时间复杂度：$O(nlogn+mlogm)$，其中 $n$ 表示数组 $buses$ 的长度， 其中 $m$ 表示数组 $buses$ 的长度。排序需要的时间为 $O(nlogn+mlogm)$，双指针遍历两个数组需要的时间为 $O(m+n)$，因此总共需要的时间为 $O(nlogn+mlogm)$。
- 空间复杂度：$O(logn+logm)$，其中 $n$ 表示数组 $buses$ 的长度， 其中 $m$ 表示数组 $buses$ 的长度。排序需要 $O(logn+logm)$ 的栈空间。
