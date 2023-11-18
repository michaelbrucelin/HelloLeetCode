### [旅行终点站](https://leetcode.cn/problems/destination-city/solutions/1026156/lu-xing-zhong-dian-zhan-by-leetcode-solu-pscd/)

#### 方法一：哈希表

根据终点站的定义，终点站不会出现在 $cityA$ 中，因为存在从 $cityA$ 出发的线路，所以终点站只会出现在 $cityB$ 中。据此，我们可以遍历 $cityB$，返回不在 $cityA$ 中的城市，即为答案。

代码实现时，可以先将所有 $cityA$ 存于一哈希表中，然后遍历 $cityB$ 并查询 $cityB$ 是否在哈希表中。

```python
class Solution:
    def destCity(self, paths: List[List[str]]) -> str:
        citiesA = {path[0] for path in paths}
        return next(path[1] for path in paths if path[1] not in citiesA)
```

```c++
class Solution {
public:
    string destCity(vector<vector<string>> &paths) {
        unordered_set<string> citiesA;
        for (auto &path : paths) {
            citiesA.insert(path[0]);
        }
        for (auto &path : paths) {
            if (!citiesA.count(path[1])) {
                return path[1];
            }
        }
        return "";
    }
};
```

```java
class Solution {
    public String destCity(List<List<String>> paths) {
        Set<String> citiesA = new HashSet<String>();
        for (List<String> path : paths) {
            citiesA.add(path.get(0));
        }
        for (List<String> path : paths) {
            if (!citiesA.contains(path.get(1))) {
                return path.get(1);
            }
        }
        return "";
    }
}
```

```csharp
public class Solution {
    public string DestCity(IList<IList<string>> paths) {
        ISet<string> citiesA = new HashSet<string>();
        foreach (IList<string> path in paths) {
            citiesA.Add(path[0]);
        }
        foreach (IList<string> path in paths) {
            if (!citiesA.Contains(path[1])) {
                return path[1];
            }
        }
        return "";
    }
}
```

```go
func destCity(paths [][]string) string {
    citiesA := map[string]bool{}
    for _, path := range paths {
        citiesA[path[0]] = true
    }
    for _, path := range paths {
        if !citiesA[path[1]] {
            return path[1]
        }
    }
    return ""
}
```

```javascript
var destCity = function(paths) {
    const citiesA = new Set();
    for (const path of paths) {
        citiesA.add(path[0]);
    }
    for (const path of paths) {
        if (!citiesA.has(path[1])) {
            return path[1];
        }
    }
    return "";
};
```

**复杂度分析**

-   时间复杂度：$O(nm)$，其中 $n$ 是数组 $paths$ 的长度，$m$ 是城市名称的最大长度。
-   空间复杂度：$O(nm)$。
