### [环和杆](https://leetcode.cn/problems/rings-and-rods/solutions/1153686/huan-he-gan-by-leetcode-solution-88xj/)

#### 方法一：维护每根杆的状态

**思路与算法**

我们可以遍历字符串中的每个颜色位置对，来模拟套环的过程。

对于每个杆，我们只在意它上面有哪些颜色的环，而不在意具体的数量。因此我们可以用一个大小为 $10 \times 3$ 的二维数组来维护十个杆子的状态，不妨把它命名为 $state$。在数组的第二维，下标 $0,1,2$ 的数值分别表示是否有红、绿、蓝颜色的环，值为 $1$ 则表示有，值为 $0$ 则表示没有。

每次遇到一个环，就修改对应杆相应颜色的状态为 $1$。最后遍历所有的杆，统计三个颜色状态都为 $1$ 的杆的个数，并返回该个数作为答案。

**代码**

```c++
class Solution {
public:
    static constexpr int POLE_NUM = 10;
    static constexpr int COLOR_NUM = 3;
    int getColorId(char color) {
        if (color == 'R') {
            return 0;
        } else if (color == 'G') {
            return 1;
        }
        return 2;
    }
    int countPoints(string rings) {
        vector<vector<int>> state(POLE_NUM, vector<int>(COLOR_NUM, 0));
        int n = rings.size();
        for (int i = 0; i < n; i += 2) {
            char color = rings[i];
            int pole_index = rings[i + 1] - '0';
            state[pole_index][getColorId(color)] = 1;
        }
        int res = 0;
        for (int i = 0; i < POLE_NUM; i++) {
            bool flag = true;
            for (int j = 0; j < COLOR_NUM; j++) {
                if (state[i][j] == 0) {
                    flag = false;
                    break;
                }
            }
            if (flag) {
                res++;
            }
        }
        return res;
    }
};
```

```java
class Solution {
    static final int POLE_NUM = 10;
    static final int COLOR_NUM = 3;

    public int countPoints(String rings) {
        int[][] state = new int[POLE_NUM][COLOR_NUM];
        int n = rings.length();
        for (int i = 0; i < n; i += 2) {
            char color = rings.charAt(i);
            int poleIndex = rings.charAt(i + 1) - '0';
            state[poleIndex][getColorId(color)] = 1;
        }
        int res = 0;
        for (int i = 0; i < POLE_NUM; i++) {
            boolean flag = true;
            for (int j = 0; j < COLOR_NUM; j++) {
                if (state[i][j] == 0) {
                    flag = false;
                    break;
                }
            }
            if (flag) {
                res++;
            }
        }
        return res;
    }

    public int getColorId(char color) {
        if (color == 'R') {
            return 0;
        } else if (color == 'G') {
            return 1;
        }
        return 2;
    }
}
```

```csharp
public class Solution {
    const int POLE_NUM = 10;
    const int COLOR_NUM = 3;

    public int CountPoints(string rings) {
        int[][] state = new int[POLE_NUM][];
        for (int i = 0; i < POLE_NUM; i++) {
            state[i] = new int[COLOR_NUM];
        }
        int n = rings.Length;
        for (int i = 0; i < n; i += 2) {
            char color = rings[i];
            int poleIndex = rings[i + 1] - '0';
            state[poleIndex][GetColorId(color)] = 1;
        }
        int res = 0;
        for (int i = 0; i < POLE_NUM; i++) {
            bool flag = true;
            for (int j = 0; j < COLOR_NUM; j++) {
                if (state[i][j] == 0) {
                    flag = false;
                    break;
                }
            }
            if (flag) {
                res++;
            }
        }
        return res;
    }

    public int GetColorId(char color) {
        if (color == 'R') {
            return 0;
        } else if (color == 'G') {
            return 1;
        }
        return 2;
    }
}
```

```c
const int POLE_NUM = 10;
const int COLOR_NUM = 3;

static int getColorId(char color) {
    if (color == 'R') {
        return 0;
    } else if (color == 'G') {
        return 1;
    }
    return 2;
}

int countPoints(char * rings) {
    int state[POLE_NUM][COLOR_NUM];
    int n = strlen(rings);
    memset(state, 0, sizeof(state));
    for (int i = 0; i < n; i += 2) {
        char color = rings[i];
        int pole_index = rings[i + 1] - '0';
        state[pole_index][getColorId(color)] = 1;
    }
    int res = 0;
    for (int i = 0; i < POLE_NUM; i++) {
        bool flag = true;
        for (int j = 0; j < COLOR_NUM; j++) {
            if (state[i][j] == 0) {
                flag = false;
                break;
            }
        }
        if (flag) {
            res++;
        }
    }
    return res;
}
```

```python
class Solution:
    def countPoints(self, rings: str) -> int:
        def getColorId(color):
            if color == 'R':
                return 0
            elif color == 'G':
                return 1
            else:
                return 2

        POLE_NUM, COLOR_NUM = 10, 3
        state = [[0 for i in range(COLOR_NUM)]  for j in range(POLE_NUM)]
        n = len(rings)
        for i in range(0, n, 2):
            color = rings[i]
            pole_index = ord(rings[i + 1]) - ord('0')
            state[pole_index][getColorId(color)] = 1
        res = 0
        for i in range(POLE_NUM):
            flag = True
            for j in range(COLOR_NUM):
                if state[i][j] == 0:
                    flag = False
                    break
            if flag:
                res += 1
        return res
```

```go
var POLE_NUM, COLOR_NUM = 10, 3

func countPoints(rings string) int {
    state := make([][]int, POLE_NUM)
    for i := 0; i < POLE_NUM; i++ {
        state[i] = make([]int, COLOR_NUM)
    }
    n := len(rings)
    for i := 0; i < n; i += 2 {
        color := rings[i]
        pole_index := rings[i + 1] - '0'
        state[pole_index][getColorId(color)] = 1
    }
    res := 0
    for i := 0; i < POLE_NUM; i++ {
        flag := true
        for j := 0; j < COLOR_NUM; j++ {
            if state[i][j] == 0 {
                flag = false
                break
            }
        }
        if flag {
            res++
        }
    }
    return res
}

func getColorId(color byte) int {
    if color == 'R' {
        return 0
    } else if color == 'G' {
        return 1
    }
    return 2
}
```

```javascript
const POLE_NUM = 10;
const COLOR_NUM = 3;

var countPoints = function(rings) {
    const getColorId = function(color) {
        if (color == 'R') {
            return 0;
        } else if (color == 'G') {
            return 1;
        }
        return 2;
    }

    const state = new Array(POLE_NUM).fill(0).map(() => new Array(COLOR_NUM).fill(0));
    const n = rings.length;
    for (let i = 0; i < n; i += 2) {
        const color = rings[i];
        const pole_index = rings[i + 1] - '0';
        state[pole_index][getColorId(color)] = 1;
    }
    let res = 0
    for (let i = 0; i < POLE_NUM; i++) {
        flag = true
        for (let j = 0; j < COLOR_NUM; j++) {
            if (state[i][j] == 0) {
                flag = false;
                break;
            }
        }
        if (flag) {
            res++;
        }
    }
    return res;
};
```

**复杂度分析**

-   时间复杂度：$O(nk+mk)$，其中 $n$ 为 $rings$ 的长度，$k$ 为颜色的数量（在本题中固定为 $3$），$m$ 为杆的数量（在本题中固定为 $10$）。
-   空间复杂度：$O(mk)$。

#### 方法二：状态压缩优化

**思路与算法**

我们也可以用一个 $3$ 位二进制整数来表示每个杆的状态。具体的，在二进制表示中，从低到高的第 $0,1,2$ 位分别表示是否有红、绿、蓝色。每一位为 $1$ 则表示当前杆上有对应颜色的环，为 $0$ 则表示没有。

因此当遇到一个在 $3$ 号杆，颜色为红色的环时，需要将 $state[3]$ 的第 $0$ 位置为 $1$。在代码中，将 $state[3]$ 与 $1$ 做位或运算即可（因为 $2^0 = 1$）。

最后，遍历 $state$，统计状态值为 $(111)_2 = 7$ 的个数，并返回该个数作为答案。

**代码**

```c++
class Solution {
public:
    static constexpr int POLE_NUM = 10;
    int countPoints(string rings) {
        vector<int> state(POLE_NUM);
        int n = rings.size();
        for (int i = 0; i < n; i += 2) {
            char color = rings[i];
            int pole_index = rings[i + 1] - '0';
            if (color == 'R') {
                state[pole_index] |= 1;
            } else if (color == 'G') {
                state[pole_index] |= 2;
            } else {
                state[pole_index] |= 4;
            }
        }
        int res = 0;
        for (int i = 0; i < POLE_NUM; i++) {
            res += state[i] == 7;
        }
        return res;
    }
};
```

```java
class Solution {
    static final int POLE_NUM = 10;

    public int countPoints(String rings) {
        int[] state = new int[POLE_NUM];
        int n = rings.length();
        for (int i = 0; i < n; i += 2) {
            char color = rings.charAt(i);
            int poleIndex = rings.charAt(i + 1) - '0';
            if (color == 'R') {
                state[poleIndex] |= 1;
            } else if (color == 'G') {
                state[poleIndex] |= 2;
            } else {
                state[poleIndex] |= 4;
            }
        }
        int res = 0;
        for (int i = 0; i < POLE_NUM; i++) {
            res += state[i] == 7 ? 1 : 0;
        }
        return res;
    }
}
```

```csharp
public class Solution {
    const int POLE_NUM = 10;

    public int CountPoints(string rings) {
        int[] state = new int[POLE_NUM];
        int n = rings.Length;
        for (int i = 0; i < n; i += 2) {
            char color = rings[i];
            int poleIndex = rings[i + 1] - '0';
            if (color == 'R') {
                state[poleIndex] |= 1;
            } else if (color == 'G') {
                state[poleIndex] |= 2;
            } else {
                state[poleIndex] |= 4;
            }
        }
        int res = 0;
        for (int i = 0; i < POLE_NUM; i++) {
            res += state[i] == 7 ? 1 : 0;
        }
        return res;
    }
}
```

```c
const int POLE_NUM = 10;

int countPoints(char * rings) {
    int state[POLE_NUM];
    memset(state, 0, sizeof(state));
    int n = strlen(rings);
    for (int i = 0; i < n; i += 2) {
        char color = rings[i];
        int pole_index = rings[i + 1] - '0';
        if (color == 'R') {
            state[pole_index] |= 1;
        } else if (color == 'G') {
            state[pole_index] |= 2;
        } else {
            state[pole_index] |= 4;
        }
    }
    int res = 0;
    for (int i = 0; i < POLE_NUM; i++) {
        res += state[i] == 7;
    }
    return res;
}
```

```python
class Solution:
    def countPoints(self, rings: str) -> int:
        POLE_NUM = 10
        mapping = {'R' : 0, 'G' : 1, 'B' : 2}
        state = [0] * POLE_NUM
        for i in range (0, len(rings), 2):
            color = rings[i]
            pole_index = ord(rings[i + 1]) - ord('0')
            state[pole_index] |= 1 << mapping[color]
        return sum(state[i] == 7 for i in range(POLE_NUM))
```

```go
var POLE_NUM = 10

func countPoints(rings string) int {
    state := make([]int, POLE_NUM)
    n := len(rings)
    for i := 0; i < n; i += 2 {
        color := rings[i]
        pole_index := rings[i + 1] - '0'
        if color == 'R' {
            state[pole_index] |= 1
        } else if color == 'G' {
            state[pole_index] |= 2
        } else {
            state[pole_index] |= 4
        }
    }
    res := 0
    for i := 0; i < POLE_NUM; i++ {
        if state[i] == 7 {
            res++
        }
    }
    return res
}
```

```javascript
const POLE_NUM = 10;

var countPoints = function(rings) {
    const state = new Array(POLE_NUM).fill(0);
    const n = rings.length;
    for (let i = 0; i < n; i += 2) {
        const color = rings[i];
        const pole_index = rings[i + 1] - '0';
        if (color == 'R') {
            state[pole_index] |= 1;
        } else if (color == 'G') {
            state[pole_index] |= 2;
        } else {
            state[pole_index] |= 4;
        }
    }
    let res = 0;
    for (let i = 0; i < POLE_NUM; i++) {
        res += state[i] == 7;
    }
    return res;
};
```

**复杂度分析**

-   时间复杂度：$O(nk+m)$，其中 $n$ 为 $rings$ 的长度，$k$ 为颜色的数量（在本题中固定为 $3$），$m$ 为杆的数量（在本题中固定为 $10$），如果使用哈希表代替掉 $if$，时间复杂度可以降低为 $O(n+m)$。
-   空间复杂度：$O(m)$。
