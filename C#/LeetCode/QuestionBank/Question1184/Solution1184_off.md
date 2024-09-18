### [公交站间的距离](https://leetcode.cn/problems/distance-between-bus-stops/solutions/1689223/gong-jiao-zhan-jian-de-ju-chi-by-leetcod-o737/)

#### 方法一：一次遍历

记数组 $distance$ 的长度为 $n$。假设 $start \le destination$，那么我们可以：

- 从 $start$ 到 $destination$，距离为 $\sum\limits_{i=start}^{destination-1}​distance[i]$；
- 从 $start$ 到 $0$，再从 $0$ 到 $destination$，距离为 $\sum\limits_{i=0}^{start-1}​distance[i]+\sum\limits_{i=destination}^{n-1}​distance[i]$。

答案为这两个距离的最小值。

```Python
class Solution:
    def distanceBetweenBusStops(self, distance: List[int], start: int, destination: int) -> int:
        if start > destination:
            start, destination = destination, start
        return min(sum(distance[start:destination]), sum(distance[:start]) + sum(distance[destination:]))
```

```C++
class Solution {
public:
    int distanceBetweenBusStops(vector<int>& distance, int start, int destination) {
        if (start > destination) {
            swap(start, destination);
        }
        return min(accumulate(distance.begin() + start, distance.begin() + destination, 0),
                   accumulate(distance.begin(), distance.begin() + start, 0) +
                   accumulate(distance.begin() + destination, distance.end(), 0));
    }
};
```

```Java
class Solution {
    public int distanceBetweenBusStops(int[] distance, int start, int destination) {
        if (start > destination) {
            int temp = start;
            start = destination;
            destination = temp;
        }
        int sum1 = 0, sum2 = 0;
        for (int i = 0; i < distance.length; i++) {
            if (i >= start && i < destination) {
                sum1 += distance[i];
            } else {
                sum2 += distance[i];
            }
        }
        return Math.min(sum1, sum2);
    }
}
```

```CSharp
public class Solution {
    public int DistanceBetweenBusStops(int[] distance, int start, int destination) {
        if (start > destination) {
            int temp = start;
            start = destination;
            destination = temp;
        }
        int sum1 = 0, sum2 = 0;
        for (int i = 0; i < distance.Length; i++) {
            if (i >= start && i < destination) {
                sum1 += distance[i];
            } else {
                sum2 += distance[i];
            }
        }
        return Math.Min(sum1, sum2);
    }
}
```

```Go
func distanceBetweenBusStops(distance []int, start, destination int) int {
    if start > destination {
        start, destination = destination, start
    }
    sum1, sum2 := 0, 0
    for i, d := range distance {
        if start <= i && i < destination {
            sum1 += d
        } else {
            sum2 += d
        }
    }
    return min(sum1, sum2)
}

func min(a, b int) int {
    if a > b {
        return b
    }
    return a
}
```

```C
#define MIN(a, b) ((a) < (b) ? (a) : (b))

int distanceBetweenBusStops(int* distance, int distanceSize, int start, int destination){
    if (start > destination) {
        int temp = start;
        start = destination;
        destination = temp;
    }
    int sum1 = 0, sum2 = 0;
    for (int i = 0; i < distanceSize; i++) {
        if (i >= start && i < destination) {
            sum1 += distance[i];
        } else {
            sum2 += distance[i];
        }
    }
    return MIN(sum1, sum2);
}
```

```JavaScript
var distanceBetweenBusStops = function(distance, start, destination) {
    if (start > destination) {
        [start, destination] = [destination, start]
    }
    let sum1 = 0, sum2 = 0;
    for (let i = 0; i < distance.length; i++) {
        if (i >= start && i < destination) {
            sum1 += distance[i];
        } else {
            sum2 += distance[i];
        }
    }
    return Math.min(sum1, sum2);
};
```

```TypeScript
function distanceBetweenBusStops(distance: number[], start: number, destination: number): number {
    if (start > destination) {
        [start, destination] = [destination, start]
    }
    let sum1 = 0, sum2 = 0;
    for (let i = 0; i < distance.length; i++) {
        if (i >= start && i < destination) {
            sum1 += distance[i];
        } else {
            sum2 += distance[i];
        }
    }
    return Math.min(sum1, sum2);
};
```

```Rust
impl Solution {
    pub fn distance_between_bus_stops(distance: Vec<i32>, start: i32, destination: i32) -> i32 {
        let mut start = start;
        let mut destination = destination;
        if (start > destination) {
            let temp = start;
            start = destination;
            destination = temp;
        }
        let mut sum1 = 0;
        let mut sum2 = 0;
        for (i, x) in distance.iter().enumerate() {
            if (i >= start as usize && i < destination as usize) {
                sum1 += x;
            } else {
                sum2 += x;
            }
        }
        sum1.min(sum2)
    }
}
```

```Cangjie
class Solution {
    func distanceBetweenBusStops(distance: Array<Int64>, start: Int64, destination: Int64): Int64 {
        var currStart = start
        var currDestination = destination
        if (currStart > currDestination) {
            (currStart, currDestination) = (currDestination, currStart)
        }
        var sum1 = 0
        var sum2 = 0
        for (i in 0..distance.size) {
            if (i >= currStart && i < currDestination) {
                sum1 += distance[i];
            } else {
                sum2 += distance[i];
            }
        }
        return min(sum1, sum2)
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是数组 $distance$ 的长度。
- 空间复杂度：$O(1)$，只需要额外的常数级别的空间。
