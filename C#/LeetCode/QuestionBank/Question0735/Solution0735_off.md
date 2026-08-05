### [行星碰撞](https://leetcode.cn/problems/asteroid-collision/solutions/1663442/xing-xing-peng-zhuang-by-leetcode-soluti-u3k0/?envType=problem-list-v2&envId=tBJHVASZ)

#### 方法一：栈模拟

使用栈 $st$ 模拟行星碰撞，从左往右遍历行星数组 $asteroids$，当我们遍历到行星 $aster$ 时，使用变量 $alive$ 记录行星 $aster$ 是否还存在（即未爆炸）。

当行星 $aster$ 存在且 $aster<0$，栈顶元素非空且大于 $0$ 时，说明两个行星相互向对方移动：如果栈顶元素大于等于 $-aster$，则行星 $aster$ 发生爆炸，将 $alive$ 置为 $false$；如果栈顶元素小于等于 $-aster$，则栈顶元素表示的行星发生爆炸，执行出栈操作。重复以上判断直到不满足条件，如果最后 $alive$ 为真，说明行星 $aster$ 不会爆炸，则将 $aster$ 入栈。

> 为了代码简洁性，我们使用变长数组模拟栈。

```Python
class Solution:
    def asteroidCollision(self, asteroids: List[int]) -> List[int]:
        st = []
        for aster in asteroids:
            alive = True
            while alive and aster < 0 and st and st[-1] > 0:
                alive = st[-1] < -aster
                if st[-1] <= -aster:
                    st.pop()
            if alive:
                st.append(aster)
        return st
```

```C++
class Solution {
public:
    vector<int> asteroidCollision(vector<int>& asteroids) {
        vector<int> st;
        for (auto aster : asteroids) {
            bool alive = true;
            while (alive && aster < 0 && !st.empty() && st.back() > 0) {
                alive = st.back() < -aster; // aster 是否存在
                if (st.back() <= -aster) {  // 栈顶行星爆炸
                    st.pop_back();
                }
            }
            if (alive) {
                st.push_back(aster);
            }
        }
        return st;
    }
};
```

```Java
class Solution {
    public int[] asteroidCollision(int[] asteroids) {
        Deque<Integer> stack = new ArrayDeque<Integer>();
        for (int aster : asteroids) {
            boolean alive = true;
            while (alive && aster < 0 && !stack.isEmpty() && stack.peek() > 0) {
                alive = stack.peek() < -aster; // aster 是否存在
                if (stack.peek() <= -aster) {  // 栈顶行星爆炸
                    stack.pop();
                }
            }
            if (alive) {
                stack.push(aster);
            }
        }
        int size = stack.size();
        int[] ans = new int[size];
        for (int i = size - 1; i >= 0; i--) {
            ans[i] = stack.pop();
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public int[] AsteroidCollision(int[] asteroids) {
        Stack<int> stack = new Stack<int>();
        foreach (int aster in asteroids) {
            bool alive = true;
            while (alive && aster < 0 && stack.Count > 0 && stack.Peek() > 0) {
                alive = stack.Peek() < -aster; // aster 是否存在
                if (stack.Peek() <= -aster) {  // 栈顶行星爆炸
                    stack.Pop();
                }
            }
            if (alive) {
                stack.Push(aster);
            }
        }
        int count = stack.Count;
        int[] ans = new int[count];
        for (int i = count - 1; i >= 0; i--) {
            ans[i] = stack.Pop();
        }
        return ans;
    }
}
```

```C
int* asteroidCollision(int* asteroids, int asteroidsSize, int* returnSize){
    int *st = (int *)malloc(sizeof(int) * asteroidsSize);
    int pos = 0;
    for (int i = 0; i < asteroidsSize; i++) {
        bool alive = true;
        while (alive && asteroids[i] < 0 && pos > 0 && st[pos - 1] > 0) {
            alive = st[pos - 1] < -asteroids[i]; // aster 是否存在
            if (st[pos - 1] <= -asteroids[i]) {  // 栈顶行星爆炸
                pos--;
            }
        }
        if (alive) {
            st[pos++] = asteroids[i];
        }
    }
    *returnSize = pos;
    return st;
}
```

```JavaScript
var asteroidCollision = function(asteroids) {
    const stack = [];
    for (const aster of asteroids) {
        let alive = true;
        while (alive && aster < 0 && stack.length > 0 && stack[stack.length - 1] > 0) {
            alive = stack[stack.length - 1] < -aster; // aster 是否存在
            if (stack[stack.length - 1] <= -aster) {  // 栈顶行星爆炸
                stack.pop();
            }
        }
        if (alive) {
            stack.push(aster);
        }
    }
    const size = stack.length;
    const ans = new Array(size).fill(0);
    for (let i = size - 1; i >= 0; i--) {
        ans[i] = stack.pop();
    }
    return ans;
};
```

```Go
func asteroidCollision(asteroids []int) (st []int) {
    for _, aster := range asteroids {
        alive := true
        for alive && aster < 0 && len(st) > 0 && st[len(st)-1] > 0 {
            alive = st[len(st)-1] < -aster // aster 是否存在
            if st[len(st)-1] <= -aster {   // 栈顶行星爆炸
                st = st[:len(st)-1]
            }
        }
        if alive {
            st = append(st, aster)
        }
    }
    return
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 为数组 $asteroids$ 的大小。出入栈次数均不超过 $n$ 次。
- 空间复杂度：$O(1)$。返回值不计入空间复杂度。
