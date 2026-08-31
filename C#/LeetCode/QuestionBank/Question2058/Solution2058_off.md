### [找出临界点之间的最小和最大距离](https://leetcode.cn/problems/find-the-minimum-and-maximum-number-of-nodes-between-critical-points/solutions/1077097/zhao-chu-lin-jie-dian-zhi-jian-de-zui-xi-b08v/)

#### 方法一：维护上一个和第一个临界点的位置

**思路与算法**

我们可以对链表进行一次遍历。

当我们遍历到节点 $cur$ 时，可以记 $cur$ 的值、$cur$ 后一个节点的值、$cur$ 后两个节点的值，分别为 $x,y,z$。如果 $y$ 严格大于 $x$ 和 $z$，或者 $y$ 严格小于 $x$ 和 $z$，那么 $cur$ 的后一个节点就是临界点。

由于我们需要得到任意两个临界点之间的最小距离和最大距离，而我们可以发现：

- 最小距离一定出现在两个相邻的临界点之间；
- 最大距离一定出现在第一个和最后一个临界点之间。

因此，在遍历的过程中，我们可以维护上一个临界点的位置以及第一个临界点的位置。这样一来，每当我们找到一个临界点，就可以更新最小距离和最大距离。

**代码**

```C++
class Solution {
public:
    vector<int> nodesBetweenCriticalPoints(ListNode* head) {
        int minDist = -1, maxDist = -1;
        int first = -1, last = -1, pos = 0;
        ListNode* cur = head;
        while (cur->next->next) {
            // 获取连续的三个节点的值
            int x = cur->val;
            int y = cur->next->val;
            int z = cur->next->next->val;
            // 如果 y 是临界点
            if (y > max(x, z) || y < min(x, z)) {
                if (last != -1) {
                    // 用相邻临界点的距离更新最小值
                    minDist = (minDist == -1 ? pos - last : min(minDist, pos - last));
                    // 用到第一个临界点的距离更新最大值
                    maxDist = max(maxDist, pos - first);
                }
                if (first == -1) {
                    first = pos;
                }
                // 更新上一个临界点
                last = pos;
            }
            cur = cur->next;
            ++pos;
        }
        return {minDist, maxDist};
    }
};
```

```Python
class Solution:
    def nodesBetweenCriticalPoints(self, head: Optional[ListNode]) -> List[int]:
        minDist = maxDist = -1
        first = last = -1
        pos = 0

        cur = head
        while cur.next.next:
            # 获取连续的三个节点的值
            x, y, z = cur.val, cur.next.val, cur.next.next.val
            # 如果 y 是临界点
            if y > max(x, z) or y < min(x, z):
                if last != -1:
                    # 用相邻临界点的距离更新最小值
                    minDist = (pos - last if minDist == -1 else min(minDist, pos - last))
                    # 用到第一个临界点的距离更新最大值
                    maxDist = max(maxDist, pos - first)
                if first == -1:
                    first = pos
                # 更新上一个临界点
                last = pos
            cur = cur.next
            pos += 1

        return [minDist, maxDist]
```

```Java
class Solution {
    public int[] nodesBetweenCriticalPoints(ListNode head) {
        int minDist = -1, maxDist = -1;
        int first = -1, last = -1, pos = 0;
        ListNode cur = head;
        while (cur.next.next != null) {
            // 获取连续的三个节点的值
            int x = cur.val;
            int y = cur.next.val;
            int z = cur.next.next.val;
            // 如果 y 是临界点
            if (y > Math.max(x, z) || y < Math.min(x, z)) {
                if (last != -1) {
                    // 用相邻临界点的距离更新最小值
                    minDist = (minDist == -1 ? pos - last : Math.min(minDist, pos - last));
                    // 用到第一个临界点的距离更新最大值
                    maxDist = Math.max(maxDist, pos - first);
                }
                if (first == -1) {
                    first = pos;
                }
                // 更新上一个临界点
                last = pos;
            }
            cur = cur.next;
            ++pos;
        }
        return new int[]{minDist, maxDist};
    }
}
```

```CSharp
public class Solution {
    public int[] NodesBetweenCriticalPoints(ListNode head) {
        int minDist = -1, maxDist = -1;
        int first = -1, last = -1, pos = 0;
        ListNode cur = head;
        while (cur.next.next != null) {
            // 获取连续的三个节点的值
            int x = cur.val;
            int y = cur.next.val;
            int z = cur.next.next.val;
            // 如果 y 是临界点
            if (y > Math.Max(x, z) || y < Math.Min(x, z)) {
                if (last != -1) {
                    // 用相邻临界点的距离更新最小值
                    minDist = (minDist == -1 ? pos - last : Math.Min(minDist, pos - last));
                    // 用到第一个临界点的距离更新最大值
                    maxDist = Math.Max(maxDist, pos - first);
                }
                if (first == -1) {
                    first = pos;
                }
                // 更新上一个临界点
                last = pos;
            }
            cur = cur.next;
            ++pos;
        }
        return new int[]{minDist, maxDist};
    }
}
```

```Go
func nodesBetweenCriticalPoints(head *ListNode) []int {
    minDist, maxDist := -1, -1
    first, last, pos := -1, -1, 0
    cur := head
    for cur.Next.Next != nil {
        // 获取连续的三个节点的值
        x := cur.Val
        y := cur.Next.Val
        z := cur.Next.Next.Val
        // 如果 y 是临界点
        if y > max(x, z) || y < min(x, z) {
            if last != -1 {
                // 用相邻临界点的距离更新最小值
                if minDist == -1 {
                    minDist = pos - last
                } else {
                    minDist = min(minDist, pos-last)
                }
                // 用到第一个临界点的距离更新最大值
                maxDist = max(maxDist, pos-first)
            }
            if first == -1 {
                first = pos
            }
            // 更新上一个临界点
            last = pos
        }
        cur = cur.Next
        pos++
    }
    return []int{minDist, maxDist}
}
```

```C
int* nodesBetweenCriticalPoints(struct ListNode* head, int* returnSize) {
    int* result = (int*)malloc(2 * sizeof(int));
    *returnSize = 2;

    int minDist = -1, maxDist = -1;
    int first = -1, last = -1, pos = 0;
    struct ListNode* cur = head;

    while (cur->next->next) {
        // 获取连续的三个节点的值
        int x = cur->val;
        int y = cur->next->val;
        int z = cur->next->next->val;
        // 如果 y 是临界点
        if (y > (x > z ? x : z) || y < (x < z ? x : z)) {
            if (last != -1) {
                // 用相邻临界点的距离更新最小值
                int dist = pos - last;
                minDist = (minDist == -1 ? dist : (minDist < dist ? minDist : dist));
                // 用到第一个临界点的距离更新最大值
                maxDist = (maxDist > (pos - first) ? maxDist : (pos - first));
            }
            if (first == -1) {
                first = pos;
            }
            // 更新上一个临界点
            last = pos;
        }
        cur = cur->next;
        ++pos;
    }

    result[0] = minDist;
    result[1] = maxDist;
    return result;
}
```

```JavaScript
var nodesBetweenCriticalPoints = function(head) {
    let minDist = -1, maxDist = -1;
    let first = -1, last = -1, pos = 0;
    let cur = head;
    while (cur.next.next) {
        // 获取连续的三个节点的值
        const x = cur.val;
        const y = cur.next.val;
        const z = cur.next.next.val;
        // 如果 y 是临界点
        if (y > Math.max(x, z) || y < Math.min(x, z)) {
            if (last !== -1) {
                // 用相邻临界点的距离更新最小值
                minDist = (minDist === -1 ? pos - last : Math.min(minDist, pos - last));
                // 用到第一个临界点的距离更新最大值
                maxDist = Math.max(maxDist, pos - first);
            }
            if (first === -1) {
                first = pos;
            }
            // 更新上一个临界点
            last = pos;
        }
        cur = cur.next;
        ++pos;
    }
    return [minDist, maxDist];
};
```

```TypeScript
function nodesBetweenCriticalPoints(head: ListNode | null): number[] {
    let minDist = -1, maxDist = -1;
    let first = -1, last = -1, pos = 0;
    let cur = head;
    while (cur.next.next) {
        // 获取连续的三个节点的值
        const x = cur.val;
        const y = cur.next.val;
        const z = cur.next.next.val;
        // 如果 y 是临界点
        if (y > Math.max(x, z) || y < Math.min(x, z)) {
            if (last !== -1) {
                // 用相邻临界点的距离更新最小值
                minDist = (minDist === -1 ? pos - last : Math.min(minDist, pos - last));
                // 用到第一个临界点的距离更新最大值
                maxDist = Math.max(maxDist, pos - first);
            }
            if (first === -1) {
                first = pos;
            }
            // 更新上一个临界点
            last = pos;
        }
        cur = cur.next;
        ++pos;
    }
    return [minDist, maxDist];
}
```

```Rust
impl Solution {
    pub fn nodes_between_critical_points(head: Option<Box<ListNode>>) -> Vec<i32> {
        let mut min_dist = -1;
        let mut max_dist = -1;
        let mut first = -1;
        let mut last = -1;
        let mut pos = 0;
        let mut cur = &head;

        while let Some(node) = cur {
            if node.next.is_none() || node.next.as_ref().unwrap().next.is_none() {
                break;
            }

            // 获取连续的三个节点的值
            let x = node.val;
            let y = node.next.as_ref().unwrap().val;
            let z = node.next.as_ref().unwrap().next.as_ref().unwrap().val;

            // 如果 y 是临界点
            if y > x.max(z) || y < x.min(z) {
                if last != -1 {
                    // 用相邻临界点的距离更新最小值
                    min_dist = if min_dist == -1 {
                        pos - last
                    } else {
                        min_dist.min(pos - last)
                    };
                    // 用到第一个临界点的距离更新最大值
                    max_dist = max_dist.max(pos - first);
                }
                if first == -1 {
                    first = pos;
                }
                // 更新上一个临界点
                last = pos;
            }

            cur = &node.next;
            pos += 1;
        }

        vec![min_dist, max_dist]
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是给定的链表的长度。
- 空间复杂度：$O(1)$。
