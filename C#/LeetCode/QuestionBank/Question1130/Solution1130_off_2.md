#### [方法二：单调栈](https://leetcode.cn/problems/minimum-cost-tree-from-leaf-values/solutions/2285433/xie-zhi-de-zui-xiao-dai-jie-sheng-cheng-26ozf/)

方法一的思路是自上而下构建二叉树，这里我们可以尝试自下而上构建二叉树：

1.  选择 $arr$ 两个相邻的值，即两个节点，将它们作为一个新节点的左子节点和右子节点；
2.  将这个新节点在数组 $arr$ 替代这两个节点；
3.  如果 $arr$ 剩余的元素数目大于 $1$，执行步骤 $1$，否则终止，那么剩余的节点就是构建的二叉树的根节点。

问题可以转化为：**给定一个数组 $arr$，不断地合并相邻的数，合并代价为两个数的乘积，合并之后的数为两个数的最大值，直到数组只剩一个数，求最小合并代价和**。

> 假设一个数 $arr[i] ~ (0 \lt i \lt n - 1)$，满足 $arr[i-1] \ge arr[i]$ 且 $arr[i] \le arr[i+1]$，如果 $arr[i-1] \le arr[i+1]$，那么优先将 $arr[i]$ 与 $arr[i-1]$ 合并是最优的，反之如果 $arr[i-1] \gt arr[i+1]$，那么优先将 $arr[i]$ 与 $arr[i+1]$ 合并是最优的（读者可以思考一下，就不给证明了）。

按照这种思路，套用单调栈算法（栈元素从底到顶是严格递减的），我们遍历数组 $arr$，记当前遍历的值为 $x$。

如果栈非空且栈顶元素小于等于 $x$，那么说明栈顶元素（类似于 $arr[i]$）是符合前面所说的最优合并的条件，将栈顶元素 $y$ 出栈：

-   如果栈空或栈顶元素大于 $x$，那么将 $y$ 与 $x$ 合并，合并代价为 $x \times y$，合并之后的值为 $x$；
-   否则将 $y$ 与栈顶元素合并，合并代价为 $y$ 与栈顶元素的乘积，合并之后的值为栈顶元素。

重复以上过程直到栈空或栈顶元素大于 $x$，然后将 $x$ 入栈。

经过以上合并过程后，栈中的元素从底到顶是严格递减的，因此可以不断地将栈顶的两个元素出栈，合并，再入栈，直到栈元素数目小于 $2$。返回最终合并代价和即可。

```cpp
class Solution {
public:
    int mctFromLeafValues(vector<int>& arr) {
        int res = 0;
        stack<int> stk;
        for (int x : arr) {
            while (!stk.empty() && stk.top() <= x) {
                int y = stk.top();
                stk.pop();
                if (stk.empty() || stk.top() > x) {
                    res += y * x;
                } else {
                    res += stk.top() * y;
                }
            }
            stk.push(x);
        }
        while (stk.size() >= 2) {
            int x = stk.top();
            stk.pop();
            res += stk.top() * x;
        }
        return res;
    }
};
```

```java
class Solution {
    public int mctFromLeafValues(int[] arr) {
        int res = 0;
        Deque<Integer> stk = new ArrayDeque<Integer>();
        for (int x : arr) {
            while (!stk.isEmpty() && stk.peek() <= x) {
                int y = stk.pop();
                if (stk.isEmpty() || stk.peek() > x) {
                    res += y * x;
                } else {
                    res += stk.peek() * y;
                }
            }
            stk.push(x);
        }
        while (stk.size() >= 2) {
            int x = stk.pop();
            res += stk.peek() * x;
        }
        return res;
    }
}
```

```csharp
public class Solution {
    public int MctFromLeafValues(int[] arr) {
        int res = 0;
        Stack<int> stk = new Stack<int>();
        foreach (int x in arr) {
            while (stk.Count > 0 && stk.Peek() <= x) {
                int y = stk.Pop();
                if (stk.Count == 0 || stk.Peek() > x) {
                    res += y * x;
                } else {
                    res += stk.Peek() * y;
                }
            }
            stk.Push(x);
        }
        while (stk.Count >= 2) {
            int x = stk.Pop();
            res += stk.Peek() * x;
        }
        return res;
    }
}
```

```python
class Solution:
    def mctFromLeafValues(self, arr: List[int]) -> int:
        res = 0
        stack = []
        for x in arr:
            while stack and stack[-1] <= x:
                y = stack.pop()
                if not stack or stack[-1] > x:
                    res += y * x
                else:
                    res += stack[-1] * y
            stack.append(x)
        while len(stack) >= 2:
            x = stack.pop()
            res += stack[-1] * x
        return res
```

```javascript
var mctFromLeafValues = function(arr) {
    let res = 0;
    let stack = [];
    for (let x of arr) {
        while (stack.length && stack[stack.length - 1] <= x) {
            let y = stack.pop();
            if (!stack.length || stack[stack.length - 1] > x) {
                res += y * x;
            } else {
                res += stack[stack.length - 1] * y;
            }
        }
        stack.push(x);
    }
    while (stack.length >= 2) {
        let x = stack.pop();
        res += stack[stack.length - 1] * x;
    }
    return res;
}
```

```go
func mctFromLeafValues(arr []int) int {
    res, stk := 0, []int{}
    for _, x := range arr {
        for len(stk) > 0 && stk[len(stk) - 1] <= x {
            if len(stk) == 1 || stk[len(stk) - 2] > x {
                res += stk[len(stk) - 1] * x
            } else {
                res += stk[len(stk) - 2] * stk[len(stk) - 1]
            }
            stk = stk[:len(stk)-1]
        }
        stk = append(stk, x)
    }
    for len(stk) > 1 {
        res += stk[len(stk) - 2] * stk[len(stk) - 1]
        stk = stk[:len(stk)-1]
    }
    return res
}
```

```c
int mctFromLeafValues(int* arr, int arrSize) {
    int res = 0;
    int stack[arrSize];
    int top = 0;
    for (int i = 0; i < arrSize; i++) {
        int x = arr[i];
        while (top > 0 && stack[top - 1] <= x) {
            int y = stack[top - 1];
            top--;
            if (top == 0 || stack[top - 1] > x) {
                res += y * x;
            } else {
                res += stack[top - 1] * y;
            }
        }
        stack[top++] = x;
    }
    while (top >= 2) {
        int x = stack[top - 1];
        top--;
        res += stack[top - 1] * x;
    }
    return res;
}
```

**复杂度分析**

-   时间复杂度：$O(n)$，其中 $n$ 为数组 $arr$ 的长度。每次循环都有入栈或出栈操作，总次数不超过 $2 \times n$，因此时间复杂度为 $O(n)$。
-   空间复杂度：$O(n)$。栈 $stk$ 需要 $O(n)$ 的空间。
