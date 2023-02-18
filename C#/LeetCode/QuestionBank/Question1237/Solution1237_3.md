#### [方法三：双指针](https://leetcode.cn/problems/find-positive-integer-solution-for-a-given-equation/solutions/2117301/zhao-chu-gei-ding-fang-cheng-de-zheng-zh-kie6/)

假设 $x_1 < x_2$，且 $f(x_1, y_1) = f(x_2, y_2) = z$，显然有 $y_1 > y_2$。因此我们从小到大进行枚举 $x$，并且从大到小枚举 $y$，当固定 $x$ 时，不需要重头开始枚举所有的 $y$，只需要从上次结束的值开始枚举即可。

```python
class Solution:
    def findSolution(self, customfunction: 'CustomFunction', z: int) -> List[List[int]]:
        ans = []
        y = 1000
        for x in range(1, 1001):
            while y and customfunction.f(x, y) > z:
                y -= 1
            if y == 0:
                break
            if customfunction.f(x, y) == z:
                ans.append([x, y])
        return ans
```

```cpp
class Solution {
public:
    vector<vector<int>> findSolution(CustomFunction& customfunction, int z) {
        vector<vector<int>> res;
        for (int x = 1, y = 1000; x <= 1000 && y >= 1; x++) {
            while (y >= 1 && customfunction.f(x, y) > z) {
                y--;
            }
            if (y >= 1 && customfunction.f(x, y) == z) {
                res.push_back({x, y});
            }
        }
        return res;
    }
};
```

```java
class Solution {
    public List<List<Integer>> findSolution(CustomFunction customfunction, int z) {
        List<List<Integer>> res = new ArrayList<List<Integer>>();
        for (int x = 1, y = 1000; x <= 1000 && y >= 1; x++) {
            while (y >= 1 && customfunction.f(x, y) > z) {
                y--;
            }
            if (y >= 1 && customfunction.f(x, y) == z) {
                List<Integer> pair = new ArrayList<Integer>();
                pair.add(x);
                pair.add(y);
                res.add(pair);
            }
        }
        return res;
    }
}
```

```csharp
public class Solution {
    public IList<IList<int>> FindSolution(CustomFunction customfunction, int z) {
        IList<IList<int>> res = new List<IList<int>>();
        for (int x = 1, y = 1000; x <= 1000 && y >= 1; x++) {
            while (y >= 1 && customfunction.f(x, y) > z) {
                y--;
            }
            if (y >= 1 && customfunction.f(x, y) == z) {
                res.Add(new List<int> {x, y});
            }
        }
        return res;
    }
}
```

```c
int** findSolution(int (*customFunction)(int, int), int z, int* returnSize, int** returnColumnSizes) {
    int **res = (int **)malloc(sizeof(int *) * 1000 * 1000);
    int pos = 0;
    for (int x = 1, y = 1000; x <= 1000 && y >= 1; x++) {
        while (y >= 1 && customFunction(x, y) > z) {
            y--;
        }
        if (y >= 1 && customFunction(x, y) == z) {
            res[pos] = (int *)malloc(sizeof(int) * 2);
            res[pos][0] = x, res[pos][1] = y;
            pos++;
        }
    }
    *returnSize = pos;
    *returnColumnSizes = (int *)malloc(sizeof(int) * pos);
    for (int i = 0; i < pos; i++) {
        (*returnColumnSizes)[i] = 2;
    }
    return res;
}
```

```javascript
var findSolution = function(customfunction, z) {
    const res = [];
    for (let x = 1, y = 1000; x <= 1000 && y >= 1; x++) {
        while (y >= 1 && customfunction.f(x, y) > z) {
            y--;
        }
        if (y >= 1 && customfunction.f(x, y) === z) {
            res.push([x, y]);
        }
    }
    return res;
};
```

```go
func findSolution(customFunction func(int, int) int, z int) (ans [][]int) {
    for x, y := 1, 1000; x <= 1000 && y > 0; x++ {
        for y > 0 && customFunction(x, y) > z {
            y--
        }
        if y > 0 && customFunction(x, y) == z {
            ans = append(ans, []int{x, y})
        }
    }
    return
}
```

**复杂度分析**

-   时间复杂度：$O(m + n)$，其中 $m$ 是 $x$ 的取值数目，$n$ 是 $y$ 的取值数目。
-   空间复杂度：$O(1)$。返回值不计入空间复杂度。
