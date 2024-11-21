### [矩阵中的蛇](https://leetcode.cn/problems/snake-in-matrix/solutions/2981524/ju-zhen-zhong-de-she-by-leetcode-solutio-ujq2/)

#### 方法一：模拟

**思路与算法**

我们按照题目描述进行模拟即可。初始时，我们在位置 $(0,0)$，对应的答案为 $0$。当我们在位置 $(i,j)$ 时：

- 如果操作为 $UP$，那么移动到 $(i-1,j)$，对应的答案减少 $n$；
- 如果操作为 $DOWN$，那么移动到 $(i+1,j)$，对应的答案增加 $n$；
- 如果操作为 $LEFT$，那么移动到 $(i,j-1)$，对应的答案减少 $1$；
- 如果操作为 $RIGHT$，那么移动到 $(i,j+1)$，对应的答案增加 $1$。

**代码**

```C++
class Solution {
public:
    int finalPositionOfSnake(int n, vector<string>& commands) {
        int ans = 0;
        for (const string& c: commands) {
            if (c[0] == 'U') {
                ans -= n;
            }
            else if (c[0] == 'D') {
                ans += n;
            }
            else if (c[0] == 'L') {
                --ans;
            }
            else {
                ++ans;
            }
        }
        return ans;
    }
};
```

```Python
class Solution:
    def finalPositionOfSnake(self, n: int, commands: List[str]) -> int:
        ans = 0
        for c in commands:
            if c[0] == "U":
                ans -= n
            elif c[0] == 'D':
                ans += n
            elif c[0] == 'L':
                ans -= 1
            else:
                ans += 1
        return ans
```

```Java
class Solution {
    public int finalPositionOfSnake(int n, List<String> commands) {
        int ans = 0;
        for (String c : commands) {
            if (c.charAt(0) == 'U') {
                ans -= n;
            } else if (c.charAt(0) == 'D') {
                ans += n;
            } else if (c.charAt(0) == 'L') {
                --ans;
            } else {
                ++ans;
            }
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public int FinalPositionOfSnake(int n, IList<string> commands) {
        int ans = 0;
        foreach (string c in commands) {
            if (c[0] == 'U') {
                ans -= n;
            } else if (c[0] == 'D') {
                ans += n;
            } else if (c[0] == 'L') {
                --ans;
            } else {
                ++ans;
            }
        }
        return ans;
    }
}
```

```Go
func finalPositionOfSnake(n int, commands []string) int {
    ans := 0
    for _, c := range commands {
        switch c[0] {
        case 'U':
            ans -= n
        case 'D':
            ans += n
        case 'L':
            ans--
        case 'R':
            ans++
        }
    }
    return ans
}
```

```C
int finalPositionOfSnake(int n, char** commands, int commandsSize) {
    int ans = 0;
    for (int i = 0; i < commandsSize; i++) {
        if (commands[i][0] == 'U') {
            ans -= n;
        } else if (commands[i][0] == 'D') {
            ans += n;
        } else if (commands[i][0] == 'L') {
            ans--;
        } else {
            ans++;
        }
    }
    return ans;
}
```

```JavaScript
var finalPositionOfSnake = function(n, commands) {
    let ans = 0;
    for (const c of commands) {
        if (c[0] === 'U') {
            ans -= n;
        } else if (c[0] === 'D') {
            ans += n;
        } else if (c[0] === 'L') {
            ans--;
        } else {
            ans++;
        }
    }
    return ans;
};
```

```TypeScript
function finalPositionOfSnake(n: number, commands: string[]): number {
    let ans = 0;
    for (const c of commands) {
        if (c[0] === 'U') {
            ans -= n;
        } else if (c[0] === 'D') {
            ans += n;
        } else if (c[0] === 'L') {
            ans--;
        } else {
            ans++;
        }
    }
    return ans;
};
```

```Rust
impl Solution {
    pub fn final_position_of_snake(n: i32, commands: Vec<String>) -> i32 {
        let mut ans = 0;
        for c in commands {
            match c.chars().next().unwrap() {
                'U' => ans -= n,
                'D' => ans += n,
                'L' => ans -= 1,
                _ => ans += 1,
            }
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(L)$，其中 $L$ 是数组 $commands$ 的长度。
- 空间复杂度：$O(1)$。
