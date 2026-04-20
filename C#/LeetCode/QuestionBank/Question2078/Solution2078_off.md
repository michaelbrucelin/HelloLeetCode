### [两栋颜色不同且距离最远的房子](https://leetcode.cn/problems/two-furthest-houses-with-different-colors/solutions/1115321/liang-dong-yan-se-bu-tong-qie-ju-chi-zui-84qv/)

#### 方法一：枚举

**思路与算法**

我们可以通过枚举两栋房子来计算两栋不同颜色房子的最远距离。

具体地，我们首先枚举下标较小的房子，然后在下标较小的房子右侧枚举下标较大的房子。随后，我们比较这两栋房子的颜色：如果两栋房子颜色不同，则我们计算两栋房子的距离，并尝试更新最远距离；反之则不进行任何操作。最终，我们返回最远距离作为答案。

**代码**

```C++
class Solution {
public:
    int maxDistance(vector<int>& colors) {
        int n = colors.size();
        int res = 0;   // 两栋颜色不同房子的最远距离
        // 遍历两栋房子下标并维护最远距离
        for (int i = 0; i < n; ++i){
            for (int j = i + 1; j < n; ++j){
                if (colors[i] != colors[j]){
                    res = max(res, j - i);
                }
            }
        }
        return res;
    }
};
```

```Python
class Solution:
    def maxDistance(self, colors: List[int]) -> int:
        n = len(colors)
        res = 0   # 两栋颜色不同房子的最远距离
        # 遍历两栋房子下标并维护最远距离
        for i in range(n):
            for j in range(i + 1, n):
                if colors[i] != colors[j]:
                    res = max(res, j - i)
        return res
```

```Java
class Solution {
    public int maxDistance(int[] colors) {
        int n = colors.length;
        int res = 0;   // 两栋颜色不同房子的最远距离
        // 遍历两栋房子下标并维护最远距离
        for (int i = 0; i < n; i++) {
            for (int j = i + 1; j < n; j++) {
                if (colors[i] != colors[j]) {
                    res = Math.max(res, j - i);
                }
            }
        }
        return res;
    }
}
```

```CSharp
public class Solution {
    public int MaxDistance(int[] colors) {
        int n = colors.Length;
        int res = 0;   // 两栋颜色不同房子的最远距离
        // 遍历两栋房子下标并维护最远距离
        for (int i = 0; i < n; i++) {
            for (int j = i + 1; j < n; j++) {
                if (colors[i] != colors[j]) {
                    res = Math.Max(res, j - i);
                }
            }
        }
        return res;
    }
}
```

```Go
func maxDistance(colors []int) int {
    n := len(colors)
    res := 0   // 两栋颜色不同房子的最远距离
    // 遍历两栋房子下标并维护最远距离
    for i := 0; i < n; i++ {
        for j := i + 1; j < n; j++ {
            if colors[i] != colors[j] {
                if j-i > res {
                    res = j - i
                }
            }
        }
    }
    return res
}
```

```C
int maxDistance(int* colors, int colorsSize) {
    int n = colorsSize;
    int res = 0;   // 两栋颜色不同房子的最远距离
    // 遍历两栋房子下标并维护最远距离
    for (int i = 0; i < n; i++) {
        for (int j = i + 1; j < n; j++) {
            if (colors[i] != colors[j]) {
                if (j - i > res) {
                    res = j - i;
                }
            }
        }
    }
    return res;
}
```

```JavaScript
var maxDistance = function(colors) {
    const n = colors.length;
    let res = 0;   // 两栋颜色不同房子的最远距离
    // 遍历两栋房子下标并维护最远距离
    for (let i = 0; i < n; i++) {
        for (let j = i + 1; j < n; j++) {
            if (colors[i] !== colors[j]) {
                res = Math.max(res, j - i);
            }
        }
    }
    return res;
};
```

```TypeScript
function maxDistance(colors: number[]): number {
    const n = colors.length;
    let res = 0;   // 两栋颜色不同房子的最远距离
    // 遍历两栋房子下标并维护最远距离
    for (let i = 0; i < n; i++) {
        for (let j = i + 1; j < n; j++) {
            if (colors[i] !== colors[j]) {
                res = Math.max(res, j - i);
            }
        }
    }
    return res;
};
```

```Rust
impl Solution {
    pub fn max_distance(colors: Vec<i32>) -> i32 {
        let n = colors.len();
        let mut res = 0;   // 两栋颜色不同房子的最远距离
        // 遍历两栋房子下标并维护最远距离
        for i in 0..n {
            for j in i + 1..n {
                if colors[i] != colors[j] {
                    res = res.max((j as i32) - (i as i32));
                }
            }
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n^2)$，其中 $n$ 为 $colors$ 的长度。即为枚举不同房子对并维护不同颜色房子最大距离的时间复杂度。
- 空间复杂度：$O(1)$。
