### [找出峰值](https://leetcode.cn/problems/find-the-peaks/solutions/2783717/zhao-chu-feng-zhi-by-leetcode-solution-c6gc/)

#### 方法一：模拟

**思路与算法**

遍历 $\textit{mountain}$ 数组，检查每个元素是否严格大于其相邻元素的元素，如果是则是峰值，加入返回数组。

返回所有找到的峰值。

**代码**

```C++
class Solution {
public:
    vector<int> findPeaks(vector<int> &mountain) {
        vector<int> res;
        for (int i = 1; i + 1 < mountain.size(); i++) {
            if (mountain[i - 1] < mountain[i] && mountain[i] > mountain[i + 1]) {
                res.push_back(i);
            }
        }
        return res;
    }
};
```

```Java
class Solution {
    public List<Integer> findPeaks(int[] mountain) {
        List<Integer> res = new ArrayList<>();
        for (int i = 1; i < mountain.length - 1; i++) {
            if (mountain[i - 1] < mountain[i] && mountain[i] > mountain[i + 1]) {
                res.add(i);
            }
        }
        return res;
    }
}
```

```Python
class Solution:
    def findPeaks(self, mountain: List[int]) -> List[int]:
            res = []
            for i in range(1, len(mountain) - 1):
                if mountain[i - 1] < mountain[i] and mountain[i] > mountain[i + 1]:
                    res.append(i)
            return res
```

```JavaScript
var findPeaks = function(mountain) {
    const res = [];
    for (let i = 1; i < mountain.length - 1; i++) {
        if (mountain[i - 1] < mountain[i] && mountain[i] > mountain[i + 1]) {
            res.push(i);
        }
    }
    return res;
};
```

```TypeScript
function findPeaks(mountain: number[]): number[] {
    const res = [];
    for (let i = 1; i < mountain.length - 1; i++) {
        if (mountain[i - 1] < mountain[i] && mountain[i] > mountain[i + 1]) {
            res.push(i);
        }
    }
    return res;
};
```

```Go
func findPeaks(mountain []int) []int {
    var res []int
    for i := 1; i < len(mountain) - 1; i++ {
        if mountain[i-1] < mountain[i] && mountain[i] > mountain[i+1] {
            res = append(res, i)
        }
    }
    return res
}
```

```CSharp
public class Solution {
    public IList<int> FindPeaks(int[] mountain) {
        var res = new List<int>();
        for (int i = 1; i < mountain.Count() - 1; i++) {
            if (mountain[i - 1] < mountain[i] && mountain[i] > mountain[i + 1]) {
                res.Add(i);
            }
        }
        return res;
    }
}
```

```C
int* findPeaks(int* mountain, int mountainSize, int* returnSize) {
    *returnSize = 0;
    int* res = (int*)malloc(mountainSize * sizeof(int));
    for (int i = 1; i < mountainSize - 1; i++) {
        if (mountain[i - 1] < mountain[i] && mountain[i] > mountain[i + 1]) {
            res[*returnSize] = i;
            (*returnSize)++;
        }
    }
    return res;
}
```

```Rust
impl Solution {
    pub fn find_peaks(mountain: Vec<i32>) -> Vec<i32> {
        let mut res = Vec::new();
        for i in 1..mountain.len() - 1 {
            if mountain[i - 1] < mountain[i] && mountain[i] > mountain[i + 1] {
                res.push(i as i32);
            }
        }
        res
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是数组的长度。
- 空间复杂度：$O(1)$。
