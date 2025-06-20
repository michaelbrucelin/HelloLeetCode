### [K次修改后的最大曼哈顿距离](https://leetcode.cn/problems/maximum-manhattan-distance-after-k-changes/solutions/3688589/kci-xiu-gai-hou-de-zui-da-man-ha-dun-ju-q5twm/)

#### 方法一：分步求解

**思路及解法**

对于任意一个给定的字符串，我们可以求出该字符串对应的曼哈顿距离，即：

$$\vert sum_N​-sum_S​ \vert + \vert sum_E​-sum_W​ \vert$$

其中，$sum_N$​、$sum_S$​、$sum_E$​、$sum_W$​ 分别表示给定字符串中 $‘N’$、$‘S’$、$‘E’$、$‘W’$ 的个数。

当我们尝试修改该字符串中的字母时，会出现三种情况：

1. 修改横向或纵向中数量较少（不为 $0$）的字母后，该字符串对应的曼哈顿距离增大，且增量为 $2$。
2. 修改横向或纵向中数量较多的字母后，该字符串对应的曼哈顿距离减小，且增量为 $-2$。
3. 不修改字母，该字符串对应的曼哈顿距离不变。

易知只有第一种情况会导致字符串曼哈顿距离增大，因此我们将整个修改过程拆分为两步：

- 第一步：修改纵向中数量较少的字母，若该字母的数量大于 $k$，则只修改 $k$ 个，剩余修改次数为 $t=0$ 次；若该字母的数量小于 $k$，则全部修改，剩余修改次数设为 $t$ 次。
- 第二步：修改横向中数量较少的字母，若该字母的数量大于 $t$，则只修改 $t$ 个；若该字母的数量小于 $t$，则全部修改。

由于题目要求找出在 **按顺序** 执行所有移动操作过程中的 **任意时刻**，所能达到的离原点的 **最大曼哈顿距离**，以上步骤需要在遍历字符串的过程中进行，并取最大值。

**代码**

```C++
class Solution {
public:
    int maxDistance(string s, int k) {
        int ans = 0;
        int north = 0, south = 0, east = 0, west = 0;
        for (char it : s) {
            switch (it) {
            case 'N':
                north++;
                break;
            case 'S':
                south++;
                break;
            case 'E':
                east++;
                break;
            case 'W':
                west++;
                break;
            }
            int times1 = min({north, south, k});        // modification times for N and S
            int times2 = min({east, west, k - times1}); // modification times for E and W
            ans = max(ans,
                      count(north, south, times1) + count(east, west, times2));
        }
        return ans;
    }

    int count(int drt1, int drt2, int times) {
        return abs(drt1 - drt2) + times * 2;
    } // Calculate modified Manhattan distance
};
```

```Python
class Solution:
    def maxDistance(self, s: str, k: int) -> int:
        ans = 0
        north = south = east = west = 0
        for it in s:
            if it == 'N':
                north += 1
            elif it == 'S':
                south += 1
            elif it == 'E':
                east += 1
            elif it == 'W':
                west += 1
            times1 = min(north, south, k)        # modification times for N and S
            times2 = min(east, west, k - times1) # modification times for E and W
            ans = max(ans, self.count(north, south, times1) + self.count(east, west, times2))
        return ans

    def count(self, drt1: int, drt2: int, times: int) -> int:
        return abs(drt1 - drt2) + times * 2  # Calculate modified Manhattan distance
```

```Java
public class Solution {
    public int maxDistance(String s, int k) {
        int ans = 0;
        int north = 0, south = 0, east = 0, west = 0;
        for (char it : s.toCharArray()) {
            switch (it) {
                case 'N':
                    north++;
                    break;
                case 'S':
                    south++;
                    break;
                case 'E':
                    east++;
                    break;
                case 'W':
                    west++;
                    break;
            }
            int times1 = Math.min(Math.min(north, south), k); // modification times for N and S
            int times2 = Math.min(Math.min(east, west), k - times1); // modification times for E and W
            ans = Math.max(ans, count(north, south, times1) + count(east, west, times2));
        }
        return ans;
    }

    private int count(int drt1, int drt2, int times) {
        return Math.abs(drt1 - drt2) + times * 2; // Calculate modified Manhattan distance
    }
}
```

```CSharp
public class Solution {
    public int MaxDistance(string s, int k) {
        int ans = 0;
        int north = 0, south = 0, east = 0, west = 0;
        foreach (char it in s) {
            switch (it) {
                case 'N':
                    north++;
                    break;
                case 'S':
                    south++;
                    break;
                case 'E':
                    east++;
                    break;
                case 'W':
                    west++;
                    break;
            }
            int times1 = Math.Min(Math.Min(north, south), k); // modification times for N and S
            int times2 = Math.Min(Math.Min(east, west), k - times1); // modification times for E and W
            ans = Math.Max(ans, Count(north, south, times1) + Count(east, west, times2));
        }
        return ans;
    }

    private int Count(int drt1, int drt2, int times) {
        return Math.Abs(drt1 - drt2) + times * 2; // Calculate modified Manhattan distance
    }
}
```

```JavaScript
var maxDistance = function(s, k) {
    let ans = 0;
    let north = 0, south = 0, east = 0, west = 0;
    for (const it of s) {
        switch (it) {
            case 'N':
                north++;
                break;
            case 'S':
                south++;
                break;
            case 'E':
                east++;
                break;
            case 'W':
                west++;
                break;
        }

        const count = (drt1, drt2, times) => {
            return Math.abs(drt1 - drt2) + times * 2; // Calculate modified Manhattan distance
        };

        let times1 = Math.min(north, south, k); // modification times for N and S
        let times2 = Math.min(east, west, k - times1); // modification times for E and W
        ans = Math.max(ans, count(north, south, times1) + count(east, west, times2));
    }
    return ans;
};
```

```Go
func maxDistance(s string, k int) int {
    ans := 0
    north, south, east, west := 0, 0, 0, 0
    count := func(drt1, drt2, times int) int {
        return int(math.Abs(float64(drt1 - drt2))) + times * 2
    } // Calculate modified Manhattan distance

    for _, it := range s {
        switch it {
        case 'N':
            north++
        case 'S':
            south++
        case 'E':
            east++
        case 'W':
            west++
        }
        times1 := min(min(north, south), k)        // modification times for N and S
        times2 := min(min(east, west), k - times1)   // modification times for E and W
        current := count(north, south, times1) + count(east, west, times2)
        if current > ans {
            ans = current
        }
    }
    
    return ans
}
```

```C
int count(int drt1, int drt2, int times) {
    return abs(drt1 - drt2) + times * 2;
} // Calculate modified Manhattan distance

int maxDistance(char* s, int k) {
    int ans = 0;
    int north = 0, south = 0, east = 0, west = 0;
    for (char* p = s; *p != '\0'; p++) {
        char it = *p;
        switch (it) {
            case 'N':
                north++;
                break;
            case 'S':
                south++;
                break;
            case 'E':
                east++;
                break;
            case 'W':
                west++;
                break;
        }

        int times1 = fmin(fmin(north, south), k);  // modification times for N and S
        int times2 = fmin(fmin(east, west), k - times1); // modification times for E and W
        int current = count(north, south, times1) + count(east, west, times2);
        if (current > ans) {
            ans = current;
        }
    }
    
    return ans;
}
```

```TypeScript
function maxDistance(s: string, k: number): number {
    let ans = 0;
    let north = 0, south = 0, east = 0, west = 0;
    for (const it of s) {
        switch (it) {
            case 'N':
                north++;
                break;
            case 'S':
                south++;
                break;
            case 'E':
                east++;
                break;
            case 'W':
                west++;
                break;
        }
        const times1 = Math.min(north, south, k);        // modification times for N and S
        const times2 = Math.min(east, west, k - times1);  // modification times for E and W
        const current = count(north, south, times1) + count(east, west, times2);
        ans = Math.max(ans, current);
    }
    return ans;
}

function count(drt1: number, drt2: number, times: number): number {
    return Math.abs(drt1 - drt2) + times * 2;
} // Calculate modified Manhattan distance
```

```Rust
use std::cmp::{min, max};

impl Solution {
    pub fn max_distance(s: String, k: i32) -> i32 {
        let mut ans = 0;
        let (mut north, mut south, mut east, mut west) = (0, 0, 0, 0);
        for c in s.chars() {
            match c {
                'N' => north += 1,
                'S' => south += 1,
                'E' => east += 1,
                'W' => west += 1,
                _ => (),
            }
            let times1 = min(min(north, south), k);        // modification times for N and S
            let times2 = min(min(east, west), k - times1);  // modification times for E and W
            let current = Self::count(north, south, times1) + Self::count(east, west, times2);
            ans = max(ans, current);
        }
        ans
    }

    fn count(drt1: i32, drt2: i32, times: i32) -> i32 {
        (drt1 - drt2).abs() + times * 2
    } // Calculate modified Manhattan distance
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，$n$ 为该字符串的长度。
- 空间复杂度：$O(1)$，申请了常数个变量。

#### 方法二：整体求解

**思路及解法**

在方法一的分析中，我们不难发现：两个方向中数量较少的字母能改则改是最优策略。

因此，将两个方向中较少的字母当作一个整体，若整体数量大于 $k$，则修改任意 $k$ 个字母，该字符串对应的曼哈顿距离增大 $2 \times k$。

若整体数量小于 $k$，则此时两个方向中较少的字母会被全部修改，剩余的修改也不需要进行了，该字符串对应的曼哈顿距离即为该字符串的长度。

**代码**

```C++
class Solution {
public:
    int maxDistance(string s, int k) {
        int latitude = 0, longitude = 0, ans = 0;
        int n = s.size();
        for (int i = 0; i < n; i++) {
            switch (s[i]) {
            case 'N':
                latitude++;
                break;
            case 'S':
                latitude--;
                break;
            case 'E':
                longitude++;
                break;
            case 'W':
                longitude--;
                break;
            }
            ans = max(ans, min(abs(latitude) + abs(longitude) + k * 2, i + 1));
        }
        return ans;
    }
};
```

```Python
class Solution:
    def maxDistance(self, s: str, k: int) -> int:
        latitude = 0
        longitude = 0
        ans = 0
        n = len(s)
        for i in range(n):
            if s[i] == 'N':
                latitude += 1
            elif s[i] == 'S':
                latitude -= 1
            elif s[i] == 'E':
                longitude += 1
            elif s[i] == 'W':
                longitude -= 1
            ans = max(ans, min(abs(latitude) + abs(longitude) + k * 2, i + 1))
        return ans
```

```Java
public class Solution {
    public int maxDistance(String s, int k) {
        int latitude = 0, longitude = 0, ans = 0;
        int n = s.length();
        for (int i = 0; i < n; i++) {
            char c = s.charAt(i);
            switch (c) {
                case 'N':
                    latitude++;
                    break;
                case 'S':
                    latitude--;
                    break;
                case 'E':
                    longitude++;
                    break;
                case 'W':
                    longitude--;
                    break;
            }
            ans = Math.max(ans, Math.min(Math.abs(latitude) + Math.abs(longitude) + k * 2, i + 1));
        }
        return ans;
    }
}
```

```CSharp
public class Solution{
    public int MaxDistance(string s, int k){
        int latitude = 0, longitude = 0, ans = 0;
        int n = s.Length;
        for (int i = 0; i < n; i++){
            switch (s[i]){
                case 'N':
                    latitude++;
                    break;
                case 'S':
                    latitude--;
                    break;
                case 'E':
                    longitude++;
                    break;
                case 'W':
                    longitude--;
                    break;
            }
            ans = Math.Max(ans, Math.Min(Math.Abs(latitude) + Math.Abs(longitude) + k * 2, i + 1));
        }
        return ans;
    }
}
```

```JavaScript
var maxDistance = function(s, k) {
    let latitude = 0, longitude = 0, ans = 0;
    const n = s.length;
    for (let i = 0; i < n; i++) {
        switch (s[i]) {
            case 'N':
                latitude++;
                break;
            case 'S':
                latitude--;
                break;
            case 'E':
                longitude++;
                break;
            case 'W':
                longitude--;
                break;
        }
        ans = Math.max(ans, Math.min(Math.abs(latitude) + Math.abs(longitude) + k * 2, i + 1));
    }
    return ans;
};
```

```Go
func maxDistance(s string, k int) int {
    latitude, longitude, ans := 0, 0, 0
    n := len(s)
    for i := 0; i < n; i++ {
        switch s[i] {
            case 'N':
                latitude++
            case 'S':
                latitude--
            case 'E':
                longitude++
            case 'W':
                longitude--
        }
        ans = max(ans, min(abs(latitude) + abs(longitude) + k * 2, i + 1))
    }
    return ans
}

func abs(x int) int {
    if x < 0 {
        return -x
    }
    return x
}
```

```C
int maxDistance(char* s, int k) {
    int latitude = 0, longitude = 0, ans = 0;
    int n = strlen(s);
    for (int i = 0; i < n; i++) {
        switch (s[i]) {
            case 'N':
                latitude++;
                break;
            case 'S':
                latitude--;
                break;
            case 'E':
                longitude++;
                break;
            case 'W':
                longitude--;
                break;
        }
        ans = fmax(ans, fmin(abs(latitude) + abs(longitude) + k * 2, i + 1));
    }
    return ans;
}
```

```TypeScript
function maxDistance(s: string, k: number): number {
    let latitude = 0, longitude = 0, ans = 0;
    const n = s.length;
    for (let i = 0; i < n; i++) {
        switch (s[i]) {
            case 'N':
                latitude++;
                break;
            case 'S':
                latitude--;
                break;
            case 'E':
                longitude++;
                break;
            case 'W':
                longitude--;
                break;
        }
        ans = Math.max(ans, Math.min(Math.abs(latitude) + Math.abs(longitude) + k * 2, i + 1));
    }
    return ans;
}
```

```Rust
use std::cmp::{min, max};

impl Solution {
    pub fn max_distance(s: String, k: i32) -> i32 {
        let (mut latitude, mut longitude, mut ans) = (0 as i32, 0 as i32, 0 as i32);
        let n = s.len();
        for (i, c) in s.chars().enumerate() {
            match c {
                'N' => latitude += 1,
                'S' => latitude -= 1,
                'E' => longitude += 1,
                'W' => longitude -= 1,
                _ => (),
            }
            let current = min(
                latitude.abs() + longitude.abs() + k * 2,
                (i + 1) as i32
            );
            ans = max(ans, current);
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，$n$ 为该字符串的长度。
- 空间复杂度：$O(1)$，申请了常数个变量。
