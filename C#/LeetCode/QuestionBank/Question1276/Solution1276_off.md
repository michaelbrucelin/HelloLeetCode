### [不浪费原料的汉堡制作方案](https://leetcode.cn/problems/number-of-burgers-with-no-waste-of-ingredients/solutions/101702/bu-lang-fei-yuan-liao-de-yi-bao-zhi-zuo-fang-an-2/)

#### 方法一：数学

设巨无霸汉堡有 $x$ 个，皇堡有 $y$ 个，由于所有的材料都需要用完，因此我们可以得到二元一次方程组：

$$\begin{cases} 4x + 2y = tomatoSlices \\ x + y = cheeseSlices \end{cases}$$

解得：

$$\begin{cases} x = \dfrac{1}{2} \times tomatoSlices - cheeseSlices \\ y = 2 \times cheeseSlices - \dfrac{1}{2} \times tomatoSlices \end{cases}$$

根据题意，$x, y \geq 0$ 且 $x, y \in \mathbb{N}$，因此需要满足：

$$\begin{cases} tomatoSlices = 2k, \quad k \in \mathbb{N} \\ tomatoSlices \geq 2 \times cheeseSlices \\ 4 \times cheeseSlices \geq tomatoSlices \end{cases}$$

若不满足，则无解。

```c++
class Solution {
public:
    vector<int> numOfBurgers(int tomatoSlices, int cheeseSlices) {
        if (tomatoSlices % 2 != 0 || tomatoSlices < cheeseSlices * 2 || cheeseSlices * 4 < tomatoSlices) {
            return {};
        }
        return {tomatoSlices / 2 - cheeseSlices, cheeseSlices * 2 - tomatoSlices / 2};
    }
};
```

```python
class Solution:
    def numOfBurgers(self, tomatoSlices: int, cheeseSlices: int) -> List[int]:
        if tomatoSlices % 2 != 0 or tomatoSlices < cheeseSlices * 2 or cheeseSlices * 4 < tomatoSlices:
            return []
        return [tomatoSlices // 2 - cheeseSlices, cheeseSlices * 2 - tomatoSlices // 2]
```

```c
int* numOfBurgers(int tomatoSlices, int cheeseSlices, int* returnSize) {
if (tomatoSlices % 2 != 0 || tomatoSlices < cheeseSlices * 2 || cheeseSlices * 4 < tomatoSlices) {
        *returnSize = 0;
        return NULL;
    }
    int *ans = (int *)malloc(sizeof(int) * 2);
    ans[0] = tomatoSlices / 2 - cheeseSlices;
    ans[1] = cheeseSlices * 2 - tomatoSlices / 2;
    *returnSize = 2;
    return ans;
}
```

```java
class Solution {
    public List<Integer> numOfBurgers(int tomatoSlices, int cheeseSlices) {
        if (tomatoSlices % 2 != 0 || tomatoSlices < cheeseSlices * 2 || cheeseSlices * 4 < tomatoSlices) {
            return new ArrayList<>();
        }
        List<Integer> ans = new ArrayList<Integer>();
        ans.add(tomatoSlices / 2 - cheeseSlices);
        ans.add(cheeseSlices * 2 - tomatoSlices / 2);
        return ans;
    }
}
```

```csharp
public class Solution {
    public IList<int> NumOfBurgers(int tomatoSlices, int cheeseSlices) {
      if (tomatoSlices % 2 != 0 || tomatoSlices < cheeseSlices * 2 || cheeseSlices * 4 < tomatoSlices) {
            return new List<int>();
        }
        IList<int> ans = new List<int>();
        ans.Add(tomatoSlices / 2 - cheeseSlices);
        ans.Add(cheeseSlices * 2 - tomatoSlices / 2);
        return ans;
    }
}
```

```go
func numOfBurgers(tomatoSlices int, cheeseSlices int) []int {
    if tomatoSlices % 2 != 0 || tomatoSlices < cheeseSlices * 2 || cheeseSlices * 4 < tomatoSlices {
        return nil
    }
    return []int{tomatoSlices / 2 - cheeseSlices, cheeseSlices * 2 - tomatoSlices / 2}
}
```

```javascript
var numOfBurgers = function(tomatoSlices, cheeseSlices) {
    if (tomatoSlices % 2 != 0 || tomatoSlices < cheeseSlices * 2 || cheeseSlices * 4 < tomatoSlices) {
        return []
    }
    return [(tomatoSlices >> 1) - cheeseSlices, cheeseSlices * 2 - (tomatoSlices >> 1)];
};
```

#### 复杂度分析

- 时间复杂度：$O(1)$。
- 空间复杂度：$O(1)$。
