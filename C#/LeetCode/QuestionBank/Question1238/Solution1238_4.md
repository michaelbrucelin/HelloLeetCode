****#### [方法二：公式法](https://leetcode.cn/problems/circular-permutation-in-binary-representation/solutions/2126240/xun-huan-ma-pai-lie-by-leetcode-solution-6e40/)

**代码**

```cpp
class Solution {
public:
    vector<int> circularPermutation(int n, int start) {
        vector<int> ret(1 << n);
        for (int i = 0; i < ret.size(); i++) {
            ret[i] = (i >> 1) ^ i ^ start;
        }
        return ret;
    }
};
```

```java
class Solution {
    public List<Integer> circularPermutation(int n, int start) {
        List<Integer> ret = new ArrayList<Integer>();
        for (int i = 0; i < 1 << n; i++) {
            ret.add((i >> 1) ^ i ^ start);
        }
        return ret;
    }
}
```

```csharp
public class Solution {
    public IList<int> CircularPermutation(int n, int start) {
        IList<int> ret = new List<int>();
        for (int i = 0; i < 1 << n; i++) {
            ret.Add((i >> 1) ^ i ^ start);
        }
        return ret;
    }
}
```

```c
int* circularPermutation(int n, int start, int* returnSize){
    int ret_size = 1 << n;
    int *ret = (int *)malloc(ret_size * sizeof(int));
    for (int i = 0; i < ret_size; i++) {
        ret[i] = (i >> 1) ^ i ^ start;
    }
    *returnSize = ret_size;
    return ret;
}
```

```go
func circularPermutation(n int, start int) []int {
ans := make([]int, 1<<n)
for i := range ans {
ans[i] = (i >> 1) ^ i ^ start
}
return ans
}
```

```python
class Solution:
    def circularPermutation(self, n: int, start: int) -> List[int]:
        ans = [0] * (1 << n)
        for i in range(1 << n):
            ans[i] = (i >> 1) ^ i ^ start
        return ans
```

```javascript
var circularPermutation = function(n, start) {
    const ret = [];
    for (let i = 0; i < 1 << n; i++) {
        ret.push((i >> 1) ^ i ^ start);
    }
    return ret;
};
```

**复杂度分析**

-   时间复杂度：$O(2^n)$。每一个格雷码生成的时间为 $O(1)$，总时间为 $O(2^n)$。
-   空间复杂度：$O(1)$。这里返回值不计入空间复杂度。
