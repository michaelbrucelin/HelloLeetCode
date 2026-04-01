### [机器人碰撞](https://leetcode.cn/problems/robot-collisions/solutions/3934241/ji-qi-ren-peng-zhuang-by-leetcode-soluti-ob7v/)

#### 方法一：排序 + 栈模拟

**思路与算法**

由于所有机器人以相同速度移动，两个机器人发生碰撞当且仅当左侧的机器人向右移动（$R$），而右侧的机器人向左移动（$L$）。

因此，我们首先将所有机器人按照位置从小到大排序。排序后，我们使用栈来模拟碰撞过程。按位置从左到右遍历每个机器人。当栈非空，且栈顶机器人方向为 R、当前机器人方向为 $L$ 时，二者会发生碰撞。我们弹出栈顶机器人，比较两者的健康度：

- 如果栈顶机器人健康度较高，则当前机器人被移除，栈顶机器人健康度减 $1$；
- 如果当前机器人健康度较高，则栈顶机器人被移除，当前机器人健康度减 $1$，继续与新的栈顶碰撞；
- 如果两者健康度相等，则都被移除。

如果最终当前机器人被保留，则将它压入栈中。

遍历结束后，栈中剩余的机器人即为幸存者。将它们按照原始编号排序，返回健康度即可。

**代码**

```C++
class Solution {
public:
    vector<int> survivedRobotsHealths(vector<int>& positions, vector<int>& healths, string directions) {
        int n = positions.size();
        vector<int> idx(n);
        iota(idx.begin(), idx.end(), 0);
        sort(idx.begin(), idx.end(), [&](int a, int b) {
            return positions[a] < positions[b];
        });

        vector<tuple<int, int, char>> alive;
        for (int i: idx) {
            int curIdx = i, curHp = healths[i];
            char curDir = directions[i];
            while (!alive.empty()) {
                auto [prevIdx, prevHp, prevDir] = alive.back();
                if (prevDir == 'R' && curDir == 'L') {
                    alive.pop_back();
                    if (prevHp > curHp) {
                        curIdx = prevIdx;
                        curHp = prevHp - 1;
                        curDir = prevDir;
                    } else if (prevHp < curHp) {
                        curHp -= 1;
                    } else {
                        curIdx = -1;
                        break;
                    }
                } else {
                    break;
                }
            }
            if (curIdx != -1) {
                alive.emplace_back(curIdx, curHp, curDir);
            }
        }

        sort(alive.begin(), alive.end());
        vector<int> ans;
        for (auto& [id, hp, dir]: alive) {
            ans.push_back(hp);
        }
        return ans;
    }
};
```

```Python
class Solution:
    def survivedRobotsHealths(self, positions: List[int], healths: List[int], directions: str) -> List[int]:
        n = len(positions)
        idx = list(range(n))
        idx.sort(key=lambda i: positions[i])

        alive = []
        for i in idx:
            curIdx, curHp, curDir = i, healths[i], directions[i]
            while alive:
                prevIdx, prevHp, prevDir = alive[-1]
                if prevDir == "R" and curDir == "L":
                    alive.pop()
                    if prevHp > curHp:
                        curIdx, curHp, curDir = prevIdx, prevHp - 1, prevDir
                    elif prevHp < curHp:
                        curHp -= 1
                    else:
                        curIdx = -1
                        break
                else:
                    break
            if curIdx != -1:
                alive.append((curIdx, curHp, curDir))

        alive.sort(key=lambda o: o[0])
        return list(o[1] for o in alive)
```

```Java
class Solution {
    public List<Integer> survivedRobotsHealths(int[] positions, int[] healths, String directions) {
        int n = positions.length;
        Integer[] idx = new Integer[n];
        for (int i = 0; i < n; i++) {
            idx[i] = i;
        }
        Arrays.sort(idx, (a, b) -> Integer.compare(positions[a], positions[b]));
        Stack<int[]> stack = new Stack<>();

        for (int i : idx) {
            int curIdx = i;
            int curHp = healths[i];
            char curDir = directions.charAt(i);

            while (!stack.isEmpty()) {
                int[] prev = stack.peek();
                char prevDir = (char)prev[2];

                if (prevDir == 'R' && curDir == 'L') {
                    stack.pop();
                    if (prev[1] > curHp) {
                        curIdx = prev[0];
                        curHp = prev[1] - 1;
                        curDir = prevDir;
                    } else if (prev[1] < curHp) {
                        curHp -= 1;
                    } else {
                        curIdx = -1;
                        break;
                    }
                } else {
                    break;
                }
            }

            if (curIdx != -1) {
                stack.push(new int[]{curIdx, curHp, curDir});
            }
        }

        List<int[]> alive = new ArrayList<>(stack);
        alive.sort((a, b) -> Integer.compare(a[0], b[0]));

        List<Integer> ans = new ArrayList<>();
        for (int[] robot : alive) {
            ans.add(robot[1]);
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public IList<int> SurvivedRobotsHealths(int[] positions, int[] healths, string directions) {
        int n = positions.Length;
        int[] idx = Enumerable.Range(0, n).ToArray();
        Array.Sort(idx, (a, b) => positions[a].CompareTo(positions[b]));
        Stack<(int index, int health, char direction)> stack = new();

        foreach (int i in idx) {
            int curIdx = i;
            int curHp = healths[i];
            char curDir = directions[i];

            while (stack.Count > 0) {
                var prev = stack.Peek();
                if (prev.direction == 'R' && curDir == 'L') {
                    stack.Pop();
                    if (prev.health > curHp) {
                        curIdx = prev.index;
                        curHp = prev.health - 1;
                        curDir = prev.direction;
                    } else if (prev.health < curHp) {
                        curHp -= 1;
                    } else {
                        curIdx = -1;
                        break;
                    }
                } else {
                    break;
                }
            }

            if (curIdx != -1) {
                stack.Push((curIdx, curHp, curDir));
            }
        }

        var alive = stack.ToList();
        alive.Sort((a, b) => a.index.CompareTo(b.index));

        return alive.Select(r => r.health).ToList();
    }
}
```

```Go
func survivedRobotsHealths(positions []int, healths []int, directions string) []int {
    n := len(positions)
    idx := make([]int, n)
    for i := 0; i < n; i++ {
        idx[i] = i
    }

    sort.Slice(idx, func(a, b int) bool {
        return positions[idx[a]] < positions[idx[b]]
    })

    type Robot struct {
        index   int
        health  int
        dir     byte
    }
    stack := make([]Robot, 0)

    for _, i := range idx {
        curIdx := i
        curHp := healths[i]
        curDir := directions[i]

        for len(stack) > 0 {
            prev := stack[len(stack)-1]
            if prev.dir == 'R' && curDir == 'L' {
                stack = stack[:len(stack)-1]
                if prev.health > curHp {
                    curIdx = prev.index
                    curHp = prev.health - 1
                    curDir = prev.dir
                } else if prev.health < curHp {
                    curHp -= 1
                } else {
                    curIdx = -1
                    break
                }
            } else {
                break
            }
        }

        if curIdx != -1 {
            stack = append(stack, Robot{curIdx, curHp, curDir})
        }
    }

    sort.Slice(stack, func(a, b int) bool {
        return stack[a].index < stack[b].index
    })

    ans := make([]int, len(stack))
    for i, r := range stack {
        ans[i] = r.health
    }
    return ans
}
```

```C
typedef struct {
    int index;
    int health;
    char dir;
} Robot;

int compareIndex(const void* a, const void* b) {
    Robot* ra = (Robot*)a;
    Robot* rb = (Robot*)b;
    return ra->index - rb->index;
}

int comparePosition(const void* a, const void* b) {
    int* ia = *(int**)a;
    int* ib = *(int**)b;
    return ia[1] - ib[1];
}

int* survivedRobotsHealths(int* positions, int positionsSize, int* healths, int healthsSize,
char* directions, int* returnSize) {
    int n = positionsSize;
    int** idx = (int**)malloc(n * sizeof(int*));
    for (int i = 0; i < n; i++) {
        idx[i] = (int*)malloc(2 * sizeof(int));
        idx[i][0] = i;
        idx[i][1] = positions[i];
    }

    qsort(idx, n, sizeof(int*), comparePosition);
    Robot* stack = (Robot*)malloc(n * sizeof(Robot));
    int stackSize = 0;

    for (int k = 0; k < n; k++) {
        int i = idx[k][0];
        int curIdx = i;
        int curHp = healths[i];
        char curDir = directions[i];

        while (stackSize > 0) {
            Robot prev = stack[stackSize - 1];
            if (prev.dir == 'R' && curDir == 'L') {
                stackSize--;
                if (prev.health > curHp) {
                    curIdx = prev.index;
                    curHp = prev.health - 1;
                    curDir = prev.dir;
                } else if (prev.health < curHp) {
                    curHp -= 1;
                } else {
                    curIdx = -1;
                    break;
                }
            } else {
                break;
            }
        }

        if (curIdx != -1) {
            stack[stackSize].index = curIdx;
            stack[stackSize].health = curHp;
            stack[stackSize].dir = curDir;
            stackSize++;
        }
    }

    qsort(stack, stackSize, sizeof(Robot), compareIndex);
    *returnSize = stackSize;
    int* result = (int*)malloc(stackSize * sizeof(int));
    for (int i = 0; i < stackSize; i++) {
        result[i] = stack[i].health;
    }

    for (int i = 0; i < n; i++) {
        free(idx[i]);
    }
    free(idx);
    free(stack);

    return result;
}
```

```JavaScript
var survivedRobotsHealths = function(positions, healths, directions) {
    const n = positions.length;
    const idx = Array.from({length: n}, (_, i) => i);
    idx.sort((a, b) => positions[a] - positions[b]);
    const stack = [];

    for (const i of idx) {
        let curIdx = i;
        let curHp = healths[i];
        let curDir = directions[i];

        while (stack.length > 0) {
            const prev = stack[stack.length - 1];
            if (prev.dir === 'R' && curDir === 'L') {
                stack.pop();
                if (prev.health > curHp) {
                    curIdx = prev.index;
                    curHp = prev.health - 1;
                    curDir = prev.dir;
                } else if (prev.health < curHp) {
                    curHp -= 1;
                } else {
                    curIdx = -1;
                    break;
                }
            } else {
                break;
            }
        }

        if (curIdx !== -1) {
            stack.push({index: curIdx, health: curHp, dir: curDir});
        }
    }

    stack.sort((a, b) => a.index - b.index);
    return stack.map(r => r.health);
};
```

```TypeScript
function survivedRobotsHealths(positions: number[], healths: number[], directions: string): number[] {
    const n = positions.length;
    const idx: number[] = Array.from({length: n}, (_, i) => i);
    idx.sort((a, b) => positions[a] - positions[b]);

    interface Robot {
        index: number;
        health: number;
        dir: string;
    }
    const stack: Robot[] = [];

    for (const i of idx) {
        let curIdx: number = i;
        let curHp: number = healths[i];
        let curDir: string = directions[i];

        while (stack.length > 0) {
            const prev = stack[stack.length - 1];
            if (prev.dir === 'R' && curDir === 'L') {
                stack.pop();
                if (prev.health > curHp) {
                    curIdx = prev.index;
                    curHp = prev.health - 1;
                    curDir = prev.dir;
                } else if (prev.health < curHp) {
                    curHp -= 1;
                } else {
                    curIdx = -1;
                    break;
                }
            } else {
                break;
            }
        }

        if (curIdx !== -1) {
            stack.push({index: curIdx, health: curHp, dir: curDir});
        }
    }

    stack.sort((a, b) => a.index - b.index);
    return stack.map(r => r.health);
}
```

```Rust
impl Solution {
    pub fn survived_robots_healths(positions: Vec<i32>, healths: Vec<i32>, directions: String) -> Vec<i32> {
        let n = positions.len();
        let mut idx: Vec<usize> = (0..n).collect();
        idx.sort_by_key(|&i| positions[i]);

        let dir_chars: Vec<char> = directions.chars().collect();
        let mut stack: Vec<(usize, i32, char)> = Vec::new();

        for &i in &idx {
            let mut cur_idx = i;
            let mut cur_hp = healths[i];
            let mut cur_dir = dir_chars[i];

            while let Some(&(prev_idx, prev_hp, prev_dir)) = stack.last() {
                if prev_dir == 'R' && cur_dir == 'L' {
                    stack.pop();
                    if prev_hp > cur_hp {
                        cur_idx = prev_idx;
                        cur_hp = prev_hp - 1;
                        cur_dir = prev_dir;
                    } else if prev_hp < cur_hp {
                        cur_hp -= 1;
                    } else {
                        cur_idx = usize::MAX;
                        break;
                    }
                } else {
                    break;
                }
            }

            if cur_idx != usize::MAX {
                stack.push((cur_idx, cur_hp, cur_dir));
            }
        }

        stack.sort_by_key(|&(idx, _, _)| idx);
        stack.into_iter().map(|(_, hp, _)| hp).collect()
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n\log n)$，其中 $n$ 是机器人的数量。排序需要 $O(n\log n)$ 的时间，栈模拟的部分，每个机器人至多入栈和出栈各一次，因此需要 $O(n)$ 的时间。
- 空间复杂度：$O(n)$，即为排序的下标数组以及栈需要使用的空间。
