### [统计道路上的碰撞次数](https://leetcode.cn/problems/count-collisions-on-a-road/solutions/3843920/tong-ji-dao-lu-shang-de-peng-zhuang-ci-s-4s9q/)

#### 方法一：模拟

**思路与算法**

从题意可知，停留的车辆不会计算碰撞次数，只有移动的车辆发生碰撞时才会计算次数。我们从左到右遍历所有车辆，并使用一个变量 $flag$ 来记录左侧车辆的情况。

- 如果左侧没有车辆，或者左侧车辆全部向左移动，那么 $flag$ 标记为 $-1$。
- 如果左侧有车辆发生碰撞，它们最终某个点停止，那么 $flag$ 标记为 $0$。
- 如果左侧有连续的车辆在向右移动，那么 $flag$ 标记为向右移动的车辆的数量。

这样一来，可分为如下三种情况：

1. 当前车辆向左移动，若 $flag\ge 0$，则碰撞次数新增 $flag+1$ 次，然后重新标记 $flag$ 为 $0$。
2. 当前车辆停留在当前位置，若 $flag>0$，则碰撞次数新增 $flag$ 次；标记 $flag$ 为 $0$。
3. 当前车辆向右移动，若 $flag<0$，则令 $flag$ 为 $1$；否则将 $flag$ 增加 $1$。

最终返回累计的所有碰撞次数。

**代码**

```C++
class Solution {
public:
    int countCollisions(string directions) {
        int res = 0;
        int flag = -1;
        for (auto c : directions) {
            if (c == 'L') {
                if (flag >= 0) {
                    res += flag + 1;
                    flag = 0;
                }
            } else if (c == 'S') {
                if (flag > 0) {
                    res += flag;
                }
                flag = 0;
            } else {
                if (flag >= 0) {
                    flag++;
                } else {
                    flag = 1;
                }
            }
        }
        return res;
    }
};
```

```Python
class Solution:
    def countCollisions(self, directions: str) -> int:
        res = 0
        flag = -1  

        for c in directions:
            if c == 'L':
                if flag >= 0:
                    res += flag + 1
                    flag = 0
            elif c == 'S':
                if flag > 0:
                    res += flag
                flag = 0
            else: 
                if flag >= 0:
                    flag += 1
                else:
                    flag = 1
        return res
```

```Rust
impl Solution {
    pub fn count_collisions(directions: String) -> i32 {
        let mut res = 0;
        let mut flag: i32 = -1;

        for c in directions.chars() {
            match c {
                'L' => {
                    if flag >= 0 {
                        res += flag + 1;
                        flag = 0;
                    }
                }
                'S' => {
                    if flag > 0 {
                        res += flag;
                    }
                    flag = 0;
                }
                'R' => {
                    if flag >= 0 {
                        flag += 1;
                    } else {
                        flag = 1;
                    }
                }
                _ => {}
            }
        }

        res
    }
}
```

```Java
class Solution {
    public int countCollisions(String directions) {
        int res = 0;
        int flag = -1;
        for (char c : directions.toCharArray()) {
            if (c == 'L') {
                if (flag >= 0) {
                    res += flag + 1;
                    flag = 0;
                }
            } else if (c == 'S') {
                if (flag > 0) {
                    res += flag;
                }
                flag = 0;
            } else {
                if (flag >= 0) {
                    flag++;
                } else {
                    flag = 1;
                }
            }
        }
        return res;
    }
}
```

```CSharp
public class Solution {
    public int CountCollisions(string directions) {
        int res = 0;
        int flag = -1;
        foreach (char c in directions) {
            if (c == 'L') {
                if (flag >= 0) {
                    res += flag + 1;
                    flag = 0;
                }
            } else if (c == 'S') {
                if (flag > 0) {
                    res += flag;
                }
                flag = 0;
            } else {
                if (flag >= 0) {
                    flag++;
                } else {
                    flag = 1;
                }
            }
        }
        return res;
    }
}
```

```Go
func countCollisions(directions string) int {
    res := 0
    flag := -1
    for _, c := range directions {
        if c == 'L' {
            if flag >= 0 {
                res += flag + 1
                flag = 0
            }
        } else if c == 'S' {
            if flag > 0 {
                res += flag
            }
            flag = 0
        } else {
            if flag >= 0 {
                flag++
            } else {
                flag = 1
            }
        }
    }
    return res
}
```

```C
int countCollisions(char* directions) {
    int res = 0;
    int flag = -1;
    
    for (int i = 0; directions[i] != '\0'; i++) {
        char c = directions[i];
        if (c == 'L') {
            if (flag >= 0) {
                res += flag + 1;
                flag = 0;
            }
        } else if (c == 'S') {
            if (flag > 0) {
                res += flag;
            }
            flag = 0;
        } else {
            if (flag >= 0) {
                flag++;
            } else {
                flag = 1;
            }
        }
    }
    return res;
}
```

```JavaScript
var countCollisions = function(directions) {
    let res = 0;
    let flag = -1;
    for (let i = 0; i < directions.length; i++) {
        const c = directions[i];
        if (c === 'L') {
            if (flag >= 0) {
                res += flag + 1;
                flag = 0;
            }
        } else if (c === 'S') {
            if (flag > 0) {
                res += flag;
            }
            flag = 0;
        } else {
            if (flag >= 0) {
                flag++;
            } else {
                flag = 1;
            }
        }
    }
    return res;
};
```

```TypeScript
function countCollisions(directions: string): number {
    let res: number = 0;
    let flag: number = -1;
    for (let i = 0; i < directions.length; i++) {
        const c: string = directions[i];
        if (c === 'L') {
            if (flag >= 0) {
                res += flag + 1;
                flag = 0;
            }
        } else if (c === 'S') {
            if (flag > 0) {
                res += flag;
            }
            flag = 0;
        } else {
            if (flag >= 0) {
                flag++;
            } else {
                flag = 1;
            }
        }
    }
    return res;
};
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 为 $directions$ 的长度。
- 空间复杂度：$O(1)$。过程中只使用了常数个变量。

#### 方法二：计数

**思路与算法**

我们定义连续向外侧（左或者右）行驶，且中间未被反向或静止车辆阻断的车辆称为“外移车辆”。

那么，左外移车辆和右外移车辆不会互相碰撞，其余的车辆都会发生一次碰撞。

**代码**

```C++
class Solution {
public:
    int countCollisions(string directions) {
        int n = directions.size();
        int l = 0, r = n - 1;

        while (l < n && directions[l] == 'L') {
            l++;
        }
        
        while (r >= l && directions[r] == 'R') {
            r--;
        }

        int res = 0;
        for (int i = l; i <= r; i++) {
            if (directions[i] != 'S') {
                res++;
            }
        }
        return res;
    }
};
```

```Python
class Solution:
    def countCollisions(self, directions: str) -> int:
        dirs = directions.lstrip('L').rstrip('R')
        return len(dirs) - dirs.count('S')
```

```Rust
impl Solution {
    pub fn count_collisions(directions: String) -> i32 {
        let s = directions.as_str();
        let l = s.find(|c| c != 'L');
        let r = s.rfind(|c| c != 'R');

        if l.is_none() || r.is_none() {
            return 0
        }

        let l = l.unwrap();
        let r = r.unwrap();

        if l > r {
            return 0;
        }
        s[l..=r].chars().filter(|&c| c != 'S').count() as i32
    }
}
```

```Java
class Solution {
    public int countCollisions(String directions) {
        int n = directions.length();
        int l = 0, r = n - 1;

        while (l < n && directions.charAt(l) == 'L') {
            l++;
        }
        
        while (r >= l && directions.charAt(r) == 'R') {
            r--;
        }

        int res = 0;
        for (int i = l; i <= r; i++) {
            if (directions.charAt(i) != 'S') {
                res++;
            }
        }
        return res;
    }
}
```

```CSharp
public class Solution {
    public int CountCollisions(string directions) {
        int n = directions.Length;
        int l = 0, r = n - 1;

        while (l < n && directions[l] == 'L') {
            l++;
        }
        
        while (r >= l && directions[r] == 'R') {
            r--;
        }

        int res = 0;
        for (int i = l; i <= r; i++) {
            if (directions[i] != 'S') {
                res++;
            }
        }
        return res;
    }
}
```

```Go
func countCollisions(directions string) int {
    n := len(directions)
    l, r := 0, n-1

    for l < n && directions[l] == 'L' {
        l++
    }
    
    for r >= l && directions[r] == 'R' {
        r--
    }

    res := 0
    for i := l; i <= r; i++ {
        if directions[i] != 'S' {
            res++
        }
    }
    return res
}
```

```C
int countCollisions(char* directions) {
    int n = strlen(directions);
    int l = 0, r = n - 1;

    while (l < n && directions[l] == 'L') {
        l++;
    }
    
    while (r >= l && directions[r] == 'R') {
        r--;
    }

    int res = 0;
    for (int i = l; i <= r; i++) {
        if (directions[i] != 'S') {
            res++;
        }
    }
    return res;
}
```

```JavaScript
var countCollisions = function(directions) {
    const n = directions.length;
    let l = 0, r = n - 1;

    while (l < n && directions[l] === 'L') {
        l++;
    }
    
    while (r >= l && directions[r] === 'R') {
        r--;
    }

    let res = 0;
    for (let i = l; i <= r; i++) {
        if (directions[i] !== 'S') {
            res++;
        }
    }
    return res;
};
```

```TypeScript
function countCollisions(directions: string): number {
    const n: number = directions.length;
    let l: number = 0, r: number = n - 1;

    while (l < n && directions[l] === 'L') {
        l++;
    }
    
    while (r >= l && directions[r] === 'R') {
        r--;
    }

    let res: number = 0;
    for (let i = l; i <= r; i++) {
        if (directions[i] !== 'S') {
            res++;
        }
    }
    return res;
};
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 为 $directions$ 的长度。
- 空间复杂度：$O(1)$。过程中只使用了常数个变量。
