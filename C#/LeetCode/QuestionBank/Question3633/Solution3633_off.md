### [最早完成陆地和水上游乐设施的时间 I](https://leetcode.cn/problems/earliest-finish-time-for-land-and-water-rides-i/solutions/3976311/zui-zao-wan-cheng-lu-di-he-shui-shang-yo-q93j/)

#### 方法一：暴力枚举 + 分类讨论

**思路与算法**

暴力枚举所有水上项目和陆地项目的组合。可以先玩陆地项目再玩水上项目，也可以反过来。要找到最早的完成时间，我们需要分别计算这两种顺序下的最优结果，然后取其中的最小值。以“先陆地、后水上”为例，计算逻辑如下：

- 对于陆地类别项目，分别计算它的“开始时间 $+$ 持续时间”。
- 准备玩第二个项目时，会遇到两种情况：
    - 如果水上项目已经开放了，你可以立即开始，完成时刻就是“第一个项目的结束时间 $+$ 水上项目的持续时间”。
    - 如果水上项目还没开放，你必须等到它开始才能动工，完成时刻就是“水上项目的开始时间 $+$ 水上项目的持续时间”。

然后交换顺序，按照同样的方法计算“先水上、后陆地”的最早完成时间。

暴力枚举所有组合，最后返回数值较小作为最终答案。

**代码**

```C++
class Solution {
public:
    int earliestFinishTime(vector<int>& landStartTime, vector<int>& landDuration, vector<int>& waterStartTime, vector<int>& waterDuration) {
        int n = landStartTime.size();
        int m = waterStartTime.size();
        int res = INT_MAX;
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                int land = landStartTime[i] + landDuration[i];
                int land_water = max(land, waterStartTime[j]) + waterDuration[j];
                res = min(res, land_water);

                int water = waterStartTime[j] + waterDuration[j];
                int water_land = max(water, landStartTime[i]) + landDuration[i];
                res = min(res, water_land);
            }
        }
        return res;
    }
};
```

```Java
class Solution {
    public int earliestFinishTime(int[] landStartTime, int[] landDuration, int[] waterStartTime, int[] waterDuration) {
        int n = landStartTime.length;
        int m = waterStartTime.length;
        int res = Integer.MAX_VALUE;
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                int land = landStartTime[i] + landDuration[i];
                int land_water = Math.max(land, waterStartTime[j]) + waterDuration[j];
                res = Math.min(res, land_water);

                int water = waterStartTime[j] + waterDuration[j];
                int water_land = Math.max(water, landStartTime[i]) + landDuration[i];
                res = Math.min(res, water_land);
            }
        }
        return res;
    }
}
```

```Python
class Solution:
    def earliestFinishTime(self, landStartTime: List[int], landDuration: List[int], waterStartTime: List[int], waterDuration: List[int]) -> int:
        n = len(landStartTime)
        m = len(waterStartTime)
        res = inf
        for i in range(n):
            for j in range(m):
                land = landStartTime[i] + landDuration[i]
                land_water = max(land,  waterStartTime[j]) + waterDuration[j]
                res = min(res, land_water)

                water = waterStartTime[j] + waterDuration[j]
                water_land = max(water, landStartTime[i]) + landDuration[i]
                res = min(res, water_land)
        return res
```

```JavaScript
var earliestFinishTime = function(landStartTime, landDuration, waterStartTime, waterDuration) {
    let n = landStartTime.length;
    let m = waterStartTime.length;
    let res = Infinity;
    for (let i = 0; i < n; i++) {
        for (let j = 0; j < m; j++) {
            let land = landStartTime[i] + landDuration[i];
            let land_water = Math.max(land, waterStartTime[j]) + waterDuration[j];
            res = Math.min(res, land_water);

            let water = waterStartTime[j] + waterDuration[j];
            let water_land = Math.max(water, landStartTime[i]) + landDuration[i];
            res = Math.min(res, water_land);
        }
    }
    return res;
};
```

```TypeScript
function earliestFinishTime(landStartTime: number[], landDuration: number[], waterStartTime: number[], waterDuration: number[]): number {
    let n = landStartTime.length;
    let m = waterStartTime.length;
    let res = Infinity;
    for (let i = 0; i < n; i++) {
        for (let j = 0; j < m; j++) {
            let land = landStartTime[i] + landDuration[i];
            let land_water = Math.max(land, waterStartTime[j]) + waterDuration[j];
            res = Math.min(res, land_water);

            let water = waterStartTime[j] + waterDuration[j];
            let water_land = Math.max(water, landStartTime[i]) + landDuration[i];
            res = Math.min(res, water_land);
        }
    }
    return res;
};
```

```Go
func earliestFinishTime(landStartTime []int, landDuration []int, waterStartTime []int, waterDuration []int) int {
    n := len(landStartTime)
    m := len(waterStartTime)
    res := 1000000
    for i := 0; i < n; i++ {
        for j := 0; j < m; j++ {
            land := landStartTime[i] + landDuration[i]
            land_water := land
            if waterStartTime[j] > land_water {
                land_water = waterStartTime[j]
            }
            land_water += waterDuration[j]
            if land_water < res {
                res = land_water
            }

            water := waterStartTime[j] + waterDuration[j]
            water_land := water
            if landStartTime[i] > water_land {
                water_land = landStartTime[i]
            }
            water_land += landDuration[i]
            if water_land < res {
                res = water_land
            }
        }
    }
    return res
}
```

```CSharp
public class Solution {
    public int EarliestFinishTime(int[] landStartTime, int[] landDuration, int[] waterStartTime, int[] waterDuration) {
        int n = landStartTime.Length;
        int m = waterStartTime.Length;
        int res = int.MaxValue;;
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < m; j++) {
                int land = landStartTime[i] + landDuration[i];
                int land_water = Math.Max(land, waterStartTime[j]) + waterDuration[j];
                res = Math.Min(res, land_water);

                int water = waterStartTime[j] + waterDuration[j];
                int water_land = Math.Max(water, landStartTime[i]) + landDuration[i];
                res = Math.Min(res, water_land);
            }
        }
        return res;
    }
}
```

```C
#define MAX(a, b) ((a) > (b) ? (a) : (b))
#define MIN(a, b) ((a) < (b) ? (a) : (b))

int earliestFinishTime(int* landStartTime, int landStartTimeSize, int* landDuration, int landDurationSize, int* waterStartTime, int waterStartTimeSize, int* waterDuration, int waterDurationSize) {
    int n = landStartTimeSize;
    int m = waterStartTimeSize;
    int res = INT_MAX;
    for (int i = 0; i < n; i++) {
        for (int j = 0; j < m; j++) {
            int land = landStartTime[i] + landDuration[i];
            int land_water = MAX(land, waterStartTime[j]) + waterDuration[j];
            res = MIN(res, land_water);

            int water = waterStartTime[j] + waterDuration[j];
            int water_land = MAX(water, landStartTime[i]) + landDuration[i];
            res = MIN(res, water_land);
        }
    }
    return res;
}
```

```Rust
impl Solution {
    pub fn earliest_finish_time(land_start_time: Vec<i32>, land_duration: Vec<i32>, water_start_time: Vec<i32>, water_duration: Vec<i32>) -> i32 {
        let n = land_start_time.len();
        let m = water_start_time.len();
        let mut res = i32::MAX;
        for i in 0..n {
            for j in 0..m {
                let land = land_start_time[i] + land_duration[i];
                let land_water = land.max(water_start_time[j]) + water_duration[j];
                res = res.min(land_water);

                let water = water_start_time[j] + water_duration[j];
                let water_land = water.max(land_start_time[i]) + land_duration[i];
                res = res.min(water_land);
            }
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n\times m)$，其中 $n$ 和 $m$ 是输入数组的长度。
- 空间复杂度：$O(1)$，其中 $n$ 是数组的长度。

#### 方法二：线性枚举 $+$ 分类讨论

**思路与算法**

可以先玩陆地项目再玩水上项目，也可以反过来。要找到最早的完成时间，我们需要分别计算这两种顺序下的最优结果，然后取其中的最小值。

对于固定的第二类项目，最终完成时间为：

$$max(finish1,start2)+duration2$$

其中 $finish1$ 表示第一类项目的结束时间，$start2$ 表示第二类项目的开始时间。由于该表达式随着 $finish1$ 的增大单调不减，因此为了使最终完成时间最小，我们只需要保留第一类项目中的最早结束时间即可。

在陆地项目结束最早的前提下，遍历所有的水上项目，并找到最早结束时间。

最后，交换顺序，按照同样的方法计算“先水上、后陆地”的最早完成时间。比较这两种顺序得到的结果，返回数值较小作为最终答案。

**代码**

```C++
class Solution {
    int solve(vector<int>& start1, vector<int>& duration1, vector<int>& start2, vector<int>& duration2) {
        int finish1 = INT_MAX;
        for (int i = 0; i < start1.size(); i++) {
            finish1 = min(finish1, start1[i] + duration1[i]);
        }

        int finish2 = INT_MAX;
        for (int i = 0; i < start2.size(); i++) {
            finish2 = min(finish2, max(start2[i], finish1) + duration2[i]);
        }
        return finish2;
    }

public:
    int earliestFinishTime(vector<int>& landStartTime, vector<int>& landDuration, vector<int>& waterStartTime, vector<int>& waterDuration) {
        int land_water = solve(landStartTime, landDuration, waterStartTime, waterDuration);
        int water_land = solve(waterStartTime, waterDuration, landStartTime, landDuration);
        return min(land_water, water_land);
    }
};
```

```Java
class Solution {
    private int solve(int[] start1, int[] duration1, int[] start2, int[] duration2) {
        int finish1 = Integer.MAX_VALUE;
        for (int i = 0; i < start1.length; i++) {
            finish1 = Math.min(finish1, start1[i] + duration1[i]);
        }
        int finish2 = Integer.MAX_VALUE;
        for (int i = 0; i < start2.length; i++) {
            finish2 = Math.min(finish2, Math.max(start2[i], finish1) + duration2[i]);
        }
        return finish2;
    }

    public int earliestFinishTime(int[] landStartTime, int[] landDuration, int[] waterStartTime, int[] waterDuration) {
        int land_water = solve(landStartTime, landDuration, waterStartTime, waterDuration);
        int water_land = solve(waterStartTime, waterDuration, landStartTime, landDuration);
        return Math.min(land_water, water_land);
    }
}
```

```Python
class Solution:
    def earliestFinishTime(self, landStartTime: List[int], landDuration: List[int], waterStartTime: List[int], waterDuration: List[int]) -> int:
        def solve(start1, duration1, start2, duration2):
            finish1 = inf
            for i in range(len(start1)):
                finish1 = min(finish1, start1[i] + duration1[i])
            finish2 = inf
            for i in range(len(start2)):
                finish2 = min(finish2, max(start2[i], finish1) + duration2[i])
            return finish2

        land_water = solve(landStartTime, landDuration, waterStartTime, waterDuration)
        water_land = solve(waterStartTime, waterDuration, landStartTime, landDuration)
        return min(land_water, water_land)
```

```JavaScript
var earliestFinishTime = function(landStartTime, landDuration, waterStartTime, waterDuration) {
    function solve(start1, duration1, start2, duration2) {
        let finish1 = Infinity;
        for (let i = 0; i < start1.length; i++) {
            finish1 = Math.min(finish1, start1[i] + duration1[i]);
        }
        let finish2 = Infinity;
        for (let i = 0; i < start2.length; i++) {
            finish2 = Math.min(finish2, Math.max(start2[i], finish1) + duration2[i]);
        }
        return finish2;
    }

    let land_water = solve(landStartTime, landDuration, waterStartTime, waterDuration);
    let water_land = solve(waterStartTime, waterDuration, landStartTime, landDuration);
    return Math.min(land_water, water_land);
};
```

```TypeScript
function solve(start1, duration1, start2, duration2) {
    let finish1 = Infinity;
    for (let i = 0; i < start1.length; i++) {
        finish1 = Math.min(finish1, start1[i] + duration1[i]);
    }
    let finish2 = Infinity;
    for (let i = 0; i < start2.length; i++) {
        finish2 = Math.min(finish2, Math.max(start2[i], finish1) + duration2[i]);
    }
    return finish2;
}

function earliestFinishTime(landStartTime: number[], landDuration: number[], waterStartTime: number[], waterDuration: number[]): number {
    let land_water = solve(landStartTime, landDuration, waterStartTime, waterDuration);
    let water_land = solve(waterStartTime, waterDuration, landStartTime, landDuration);
    return Math.min(land_water, water_land);
};
```

```Go
func earliestFinishTime(landStartTime []int, landDuration []int, waterStartTime []int, waterDuration []int) int {
    solve := func(start1, duration1, start2, duration2 []int) int {
        finish1 := 2147483647
        for i := 0; i < len(start1); i++ {
            if val := start1[i] + duration1[i]; val < finish1 {
                finish1 = val
            }
        }
        finish2 := 2147483647
        for i := 0; i < len(start2); i++ {
            curStart := start2[i]
            if finish1 > curStart {
                curStart = finish1
            }
            if val := curStart + duration2[i]; val < finish2 {
                finish2 = val
            }
        }
        return finish2
    }

    land_water := solve(landStartTime, landDuration, waterStartTime, waterDuration)
    water_land := solve(waterStartTime, waterDuration, landStartTime, landDuration)
    if land_water < water_land {
        return land_water
    }
    return water_land
}
```

```CSharp
public class Solution {
    private int solve(int[] start1, int[] duration1, int[] start2, int[] duration2) {
        int finish1 = int.MaxValue;
        for (int i = 0; i < start1.Length; i++) {
            finish1 = Math.Min(finish1, start1[i] + duration1[i]);
        }
        int finish2 = int.MaxValue;
        for (int i = 0; i < start2.Length; i++) {
            finish2 = Math.Min(finish2, Math.Max(start2[i], finish1) + duration2[i]);
        }
        return finish2;
    }

    public int EarliestFinishTime(int[] landStartTime, int[] landDuration, int[] waterStartTime, int[] waterDuration) {
        int land_water = solve(landStartTime, landDuration, waterStartTime, waterDuration);
        int water_land = solve(waterStartTime, waterDuration, landStartTime, landDuration);
        return Math.Min(land_water, water_land);
    }
}
```

```C
#define min(a, b) ((a) < (b) ? (a) : (b))
#define max(a, b) ((a) > (b) ? (a) : (b))

int solve(int* start1, int start1Size, int* duration1, int* start2, int start2Size, int* duration2) {
    int finish1 = INT_MAX;
    for (int i = 0; i < start1Size; i++) {
        finish1 = min(finish1, start1[i] + duration1[i]);
    }
    int finish2 = INT_MAX;
    for (int i = 0; i < start2Size; i++) {
        finish2 = min(finish2, max(start2[i], finish1) + duration2[i]);
    }
    return finish2;
}

int earliestFinishTime(int* landStartTime, int landStartTimeSize, int* landDuration, int landDurationSize, int* waterStartTime, int waterStartTimeSize, int* waterDuration, int waterDurationSize) {
    int land_water = solve(landStartTime, landStartTimeSize, landDuration, waterStartTime, waterStartTimeSize, waterDuration);
    int water_land = solve(waterStartTime, waterStartTimeSize, waterDuration, landStartTime, landStartTimeSize, landDuration);
    return min(land_water, water_land);
}
```

```Rust
impl Solution {
    fn solve(start1: &Vec<i32>, duration1: &Vec<i32>, start2: &Vec<i32>, duration2: &Vec<i32>) -> i32 {
        let mut finish1 = i32::MAX;
        for i in 0..start1.len() {
            finish1 = finish1.min(start1[i] + duration1[i]);
        }
        let mut finish2 = i32::MAX;
        for i in 0..start2.len() {
            finish2 = finish2.min(start2[i].max(finish1) + duration2[i]);
        }
        finish2
    }

    pub fn earliest_finish_time(landStartTime: Vec<i32>, landDuration: Vec<i32>, waterStartTime: Vec<i32>, waterDuration: Vec<i32>) -> i32 {
        let land_water = Self::solve(&landStartTime, &landDuration, &waterStartTime, &waterDuration);
        let water_land = Self::solve(&waterStartTime, &waterDuration, &landStartTime, &landDuration);
        land_water.min(water_land)
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n+m)$，其中 $n$ 和 $m$ 是输入数组的长度。
- 空间复杂度：$O(1)$。
