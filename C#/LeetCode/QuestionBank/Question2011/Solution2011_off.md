### [执行操作后的变量值](https://leetcode.cn/problems/final-value-of-variable-after-performing-operations/solutions/2028909/zhi-xing-cao-zuo-hou-de-bian-liang-zhi-b-knvg/)

#### 方法一：模拟

初始时令 $x=0$，遍历字符串数组 $operations$，遇到 $"++X"$ 或 $"X++"$ 时，将 $x$ 加 $1$，否则将 $x$ 减 $1$。

```Python
class Solution:
    def finalValueAfterOperations(self, operations: List[str]) -> int:
        return sum(1 if op[1] == '+' else -1 for op in operations)
```

```C++
class Solution {
public:
    int finalValueAfterOperations(vector<string>& operations) {
        int x = 0;
        for (auto &op : operations) {
            if (op == "X++" || op == "++X") {
                x++;
            } else {
                x--;
            }
        }
        return x;
    }
};
```

```Java
class Solution {
    public int finalValueAfterOperations(String[] operations) {
        int x = 0;
        for (String op : operations) {
            if ("X++".equals(op) || "++X".equals(op)) {
                x++;
            } else {
                x--;
            }
        }
        return x;
    }
}
```

```CSharp
public class Solution {
    public int FinalValueAfterOperations(string[] operations) {
        int x = 0;
        foreach (string op in operations) {
            if (op == "X++" || op == "++X") {
                x++;
            } else {
                x--;
            }
        }
        return x;
    }
}
```

```C
int finalValueAfterOperations(char ** operations, int operationsSize) {
    int x = 0;
    for (int i = 0; i < operationsSize; i++) {
        char *op = operations[i];
        if (!strcmp(op, "X++") || !strcmp(op, "++X")) {
            x++;
        } else {
            x--;
        }
    }
    return x;
}
```

```JavaScript
var finalValueAfterOperations = function(operations) {
    let x = 0;
    for (const op of operations) {
        if ("X++" === op || "++X" === op) {
            x++;
        } else {
            x--;
        }
    }
    return x;
};
```

```Go
func finalValueAfterOperations(operations []string) (x int) {
    for _, op := range operations {
        if op[1] == '+' {
            x++
        } else {
            x--
        }
    }
    return
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是字符串数组 $operations$ 的长度。
- 空间复杂度：$O(1)$。仅用到若干额外变量。
