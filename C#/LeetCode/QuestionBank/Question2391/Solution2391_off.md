### [收集垃圾的最少总时间](https://leetcode.cn/problems/minimum-amount-of-time-to-collect-garbage/solutions/2768299/shou-ji-la-ji-de-zui-shao-zong-shi-jian-94b5h/)

#### 方法一：一次遍历

##### 思路与算法

由于任意时刻只有一辆车处于使用状态，所以可以将处理三类垃圾的车分开讨论。对于处理垃圾 $c$ 的车，消耗的时间包括：

- 处理 $\textit{garbage}$ 中所有垃圾 $c$ 的时间
- 设 $\textit{garbage}$ 中最后一次出现垃圾 $c$ 的下标为 $\textit{index}$，将车移动到该处消耗的时间，即 $\textit{travel}[0] + \cdots + \textit{travel}[index-1]$

在计算三辆车总的时间时，对于第一部分，可直接对 $\textit{garbage}$ 中所有字符串的长度求和；对于第二部分，可以求出每辆车到达每类垃圾最后一次出现的位置所消耗的时间，最后进行求和。

在第二部分进行代码实现时，可用一个变量维护 $\textit{travel}$ 的前缀和，并用哈希表及时的更新处理每类车的时间。

##### 代码

```c++
class Solution {
public:
    int garbageCollection(vector<string>& garbage, vector<int>& travel) {
        unordered_map<char, int> distance;
        int res = 0, cur_dis = 0;
        for (int i = 0; i < garbage.size(); i++) {
            res += garbage[i].size();
            if (i > 0) {
                cur_dis += travel[i - 1];
            }
            for (auto c : garbage[i]) {
                distance[c] = cur_dis;
            }
        }
        for (auto &[k, v] : distance) {
            res += v;
        }
        return res;
    }
};
```

```python
class Solution:
    def garbageCollection(self, garbage: List[str], travel: List[int]) -> int:
        distance = {}
        res = 0
        cur_dis = 0
        for i in range(len(garbage)):
            res += len(garbage[i])
            if i > 0:
                cur_dis += travel[i - 1]
            for c in garbage[i]:
                distance[c] = cur_dis
        return res + sum(distance.values())
```

```java
class Solution {
    public int garbageCollection(String[] garbage, int[] travel) {
        Map<Character, Integer> distance = new HashMap<>();
        int res = 0, curDis = 0;
        for (int i = 0; i < garbage.length; i++) {
            res += garbage[i].length();
            if (i > 0) {
                curDis += travel[i - 1];
            }
            for (char c : garbage[i].toCharArray()) {
                distance.put(c, curDis);
            }
        }
        return res + distance.values().stream().reduce(0, Integer::sum);
    }
}
```

```csharp
public class Solution {
    public int GarbageCollection(string[] garbage, int[] travel) {
        IDictionary<char, int> distance = new Dictionary<char, int>();
        int res = 0, curDis = 0;
        for (int i = 0; i < garbage.Length; i++) {
            res += garbage[i].Length;
            if (i > 0) {
                curDis += travel[i - 1];
            }
            foreach (char c in garbage[i]) {
                if (!distance.ContainsKey(c)) {
                    distance.Add(c, curDis);
                } else {
                    distance[c] = curDis;
                }
            }
        }
        return res + distance.Values.Sum();
    }
}
```

```go
func garbageCollection(garbage []string, travel []int) int {
    distance := make(map[rune]int)
    res := 0
    curDis := 0
    for i, item := range garbage {
        res += len(item)
        if i > 0 {
            curDis += travel[i - 1]
        }
        for _, c := range item {
            distance[c] = curDis
        }
    }
    for _, v := range distance {
        res += v
    }
    return res
}
```

```c
int garbageCollection(char** garbage, int garbageSize, int* travel, int travelSize) {
    int distance[26] = {0}; 
    int res = 0, curDis = 0;
    for (int i = 0; i < garbageSize; i++) {
        res += strlen(garbage[i]);
        if (i > 0) {
            curDis += travel[i - 1];
        }
        for (int j = 0; garbage[i][j] != '\0'; j++) {
            distance[garbage[i][j] - 'A'] = curDis;
        }
    }
    for (int i = 0; i < 26; i++) {
        res += distance[i];
    }
    return res;
}
```

```javascript
var garbageCollection = function(garbage, travel) {
    const distance = new Map();
    let res = 0, curDis = 0;
    for (let i = 0; i < garbage.length; i++) {
        res += garbage[i].length;
        if (i > 0) {
            curDis += travel[i - 1];
        }
        for (const c of garbage[i]) {
            distance.set(c, curDis);
        }
    }
    for (const [k, v] of distance) {
        res += v;
    }
    return res;
};
```

```typescript
function garbageCollection(garbage: string[], travel: number[]): number {
    const distance = new Map<string, number>();
    let res = 0, curDis = 0;
    for (let i = 0; i < garbage.length; i++) {
        res += garbage[i].length;
        if (i > 0) {
            curDis += travel[i - 1];
        }
        for (const c of garbage[i]) {
            distance.set(c, curDis);
        }
    }
    for (const [k, v] of distance) {
        res += v;
    }
    return res;
};
```

```rust
use std::collections::HashMap;

impl Solution {
    pub fn garbage_collection(garbage: Vec<String>, travel: Vec<i32>) -> i32 {
        let mut distance: HashMap<char, i32> = HashMap::new();
        let mut res = 0;
        let mut cur_dis = 0;
        for (i, item) in garbage.iter().enumerate() {
            res += item.len() as i32;
            if i > 0 {
                cur_dis += travel[i - 1];
            }
            for c in item.chars() {
                *distance.entry(c).or_insert(0) = cur_dis;
            }
        }
        for v in distance.values() {
            res += v;
        }
        res
    }
}
```

##### 复杂度分析

- 时间复杂度：$O(nm)$，其中 $n$ 为 $\textit{garbage}$ 的长度，$m$ 为 $\textit{garbage}[i]$ 的长度。
- 空间复杂度：$O(C)$，其中 $C$ 表示垃圾的种类数。过程中使用哈希表来存储到达每种垃圾最后一次出现的位置所需要的时间。
