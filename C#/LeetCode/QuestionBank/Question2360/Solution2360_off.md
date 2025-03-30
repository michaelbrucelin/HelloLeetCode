### [图中的最长环](https://leetcode.cn/problems/longest-cycle-in-a-graph/solutions/3625322/tu-zhong-de-zui-chang-huan-by-leetcode-s-3iq1/)

#### 方法一：从每个节点开始进行遍历

**思路与算法**

由于每个节点至多有一个出边，因此从任意节点开始进行遍历，只会遇到下面的三种情况之一：

- 最终遍历到一个没有出边的节点，此过程中没有找到任何环；
- 最终遍历到一个已经遍历过的节点 $u$，并且 $u$ 也是在这一轮遍历中被遍历到的。如果 $u$ 第一次是第 $x$ 个遍历到的节点，第二次是第 $y$ 个遍历到的节点，我们就找到了一个长度为 $y-x$ 的环，可以结束遍历；
- 最终遍历到一个已经遍历过的节点 $v$，但 $v$ 是在之前的某一轮遍历中被遍历到的，那么即使之后出现了环，也已经在之前的那轮遍历中计算完成，可以结束遍历。

为了实现上述的遍历方法，我们使用一个变量 $current\_label$ 记录节点第一次被遍历到的编号，它的初始值为 $0$，每遍历到一个新的节点，它的值就加 $1$。当我们从节点 $i$ 开始进行遍历时，首先记录下当前的 $current\_label$，记为 $start\_label$，随后就可以进行遍历：

- 如果第一次遍历到某个节点，就将 $current\_label$ 增加 $1$ 并作为该节点的编号；
- 如果已经遍历过某个节点，并且该节点的编号大于 $start\_label$，说明该节点也是在这一轮遍历中被遍历到的，我们就找到了一个环；
- 如果已经遍历过某个节点，并且该节点的编号小于等于 $start\_label$，说明该节点是在之前的某一轮遍历中被遍历到的。

**代码**

```C++
class Solution {
public:
    int longestCycle(vector<int>& edges) {
        int n = edges.size();
        vector<int> label(n);
        int current_label = 0, ans = -1;
        for (int i = 0; i < n; ++i) {
            if (label[i]) {
                continue;
            }
            int pos = i, start_label = current_label;
            while (pos != -1) {
                ++current_label;
                // 如果遇到了已经遍历过的节点
                if (label[pos]) {
                    // 如果该节点是这一次 i 循环中遍历的，说明找到了新的环，更新答案
                    if (label[pos] > start_label) {
                        ans = max(ans, current_label - label[pos]);
                    }
                    break;
                }
                label[pos] = current_label;
                pos = edges[pos];
            }
        }
        return ans;
    }
};

```

```Python
class Solution:
    def longestCycle(self, edges: List[int]) -> int:
        n = len(edges)
        label = [0] * n
        current_label = 0
        ans = -1
        for i in range(n):
            if label[i] > 0:
                continue
            pos = i
            start_label = current_label
            while pos != -1:
                current_label += 1
                # 如果遇到了已经遍历过的节点
                if label[pos] > 0:
                    # 如果该节点是这一次 i 循环中遍历的，说明找到了新的环，更新答案
                    if label[pos] > start_label:
                        ans = max(ans, current_label - label[pos])
                    break
                label[pos] = current_label
                pos = edges[pos]
        return ans
```

```Java
class Solution {
    public int longestCycle(int[] edges) {
        int n = edges.length;
        int[] label = new int[n];
        int current_label = 0, ans = -1;
        for (int i = 0; i < n; ++i) {
            if (label[i] != 0) {
                continue;
            }
            int pos = i, start_label = current_label;
            while (pos != -1) {
                ++current_label;
                // 如果遇到了已经遍历过的节点
                if (label[pos] != 0) {
                    // 如果该节点是这一次 i 循环中遍历的，说明找到了新的环，更新答案
                    if (label[pos] > start_label) {
                        ans = Math.max(ans, current_label - label[pos]);
                    }
                    break;
                }
                label[pos] = current_label;
                pos = edges[pos];
            }
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public int LongestCycle(int[] edges) {
        int n = edges.Length;
        int[] label = new int[n];
        int current_label = 0, ans = -1;
        for (int i = 0; i < n; ++i) {
            if (label[i] != 0) {
                continue;
            }
            int pos = i, start_label = current_label;
            while (pos != -1) {
                ++current_label;
                // 如果遇到了已经遍历过的节点
                if (label[pos] != 0) {
                    // 如果该节点是这一次 i 循环中遍历的，说明找到了新的环，更新答案
                    if (label[pos] > start_label) {
                        ans = Math.Max(ans, current_label - label[pos]);
                    }
                    break;
                }
                label[pos] = current_label;
                pos = edges[pos];
            }
        }
        return ans;
    }
}
```

```Go
func longestCycle(edges []int) int {
    n := len(edges)
    label := make([]int, n)
    current_label, ans := 0, -1
    for i := 0; i < n; i++ {
        if label[i] != 0 {
            continue
        }
        pos, start_label := i, current_label
        for pos != -1 {
            current_label++
            // 如果遇到了已经遍历过的节点
            if label[pos] != 0 {
                // 如果该节点是这一次 i 循环中遍历的，说明找到了新的环，更新答案
                if label[pos] > start_label {
                    if current_label - label[pos] > ans {
                        ans = current_label - label[pos]
                    }
                }
                break
            }
            label[pos] = current_label
            pos = edges[pos]
        }
    }
    return ans
}
```

```C
int longestCycle(int* edges, int edgesSize) {
    int n = edgesSize;
    int* label = (int*)calloc(n, sizeof(int));
    int current_label = 0, ans = -1;
    for (int i = 0; i < n; ++i) {
        if (label[i]) {
            continue;
        }
        int pos = i, start_label = current_label;
        while (pos != -1) {
            ++current_label;
            // 如果遇到了已经遍历过的节点
            if (label[pos]) {
                // 如果该节点是这一次 i 循环中遍历的，说明找到了新的环，更新答案
                if (label[pos] > start_label) {
                    ans = ans > (current_label - label[pos]) ? ans : (current_label - label[pos]);
                }
                break;
            }
            label[pos] = current_label;
            pos = edges[pos];
        }
    }
    free(label);
    return ans;
}
```

```JavaScript
var longestCycle = function(edges) {
    const n = edges.length;
    const label = new Array(n).fill(0);
    let current_label = 0, ans = -1;
    for (let i = 0; i < n; ++i) {
        if (label[i]) {
            continue;
        }
        let pos = i, start_label = current_label;
        while (pos !== -1) {
            ++current_label;
            // 如果遇到了已经遍历过的节点
            if (label[pos]) {
                // 如果该节点是这一次 i 循环中遍历的，说明找到了新的环，更新答案
                if (label[pos] > start_label) {
                    ans = Math.max(ans, current_label - label[pos]);
                }
                break;
            }
            label[pos] = current_label;
            pos = edges[pos];
        }
    }
    return ans;
};
```

```TypeScript
function longestCycle(edges: number[]): number {
    const n = edges.length;
    const label: number[] = new Array(n).fill(0);
    let current_label = 0, ans = -1;
    for (let i = 0; i < n; ++i) {
        if (label[i]) {
            continue;
        }
        let pos = i, start_label = current_label;
        while (pos !== -1) {
            ++current_label;
            // 如果遇到了已经遍历过的节点
            if (label[pos]) {
                // 如果该节点是这一次 i 循环中遍历的，说明找到了新的环，更新答案
                if (label[pos] > start_label) {
                    ans = Math.max(ans, current_label - label[pos]);
                }
                break;
            }
            label[pos] = current_label;
            pos = edges[pos];
        }
    }
    return ans;
};
```

```Rust
impl Solution {
    pub fn longest_cycle(edges: Vec<i32>) -> i32 {
        let n = edges.len();
        let mut label = vec![0; n];
        let mut current_label = 0;
        let mut ans = -1;
        for i in 0..n {
            if label[i] != 0 {
                continue;
            }
            let mut pos = i as i32;
            let start_label = current_label;
            while pos != -1 {
                current_label += 1;
                // 如果遇到了已经遍历过的节点
                if label[pos as usize] != 0 {
                    // 如果该节点是这一次 i 循环中遍历的，说明找到了新的环，更新答案
                    if label[pos as usize] > start_label {
                        ans = ans.max(current_label - label[pos as usize]);
                    }
                    break;
                }
                label[pos as usize] = current_label;
                pos = edges[pos as usize];
            }
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$。从任意节点开始进行遍历，到结束时只会遍历若干个之前没有遍历过的节点，以及至多一个之前遍历过的节点。前者总计为 $n$ 个节点，后者总计不超过 $n$ 个节点，因此时间复杂度为 $O(n)$。
- 空间复杂度：$O(n)$，即为存储节点编号需要使用的空间。
