### [统计最大组的数目](https://leetcode.cn/problems/count-largest-group/solutions/197510/tong-ji-zui-da-zu-de-shu-mu-by-leetcode-solution/)

#### 方法一：哈希表

**思路**

对于 $[1,n]$ 中的每一个整数 $i$，我们可以计算出它的数位和 $s_i$​。建立一个从数位和到原数字的哈希映射，对每一个数字 $i$，使键 $s_i$​ 对应的值自增一。然后我们在值的集合中找到最大的值 $m$，再遍历哈希表，统计值为 $m$ 的个数即可。

**代码**

```Python
class Solution:
    def countLargestGroup(self, n: int) -> int:
        hashMap = collections.Counter()
        for i in range(1, n + 1): 
            key = sum([int(x) for x in str(i)])
            hashMap[key] += 1
        maxValue = max(hashMap.values())
        count = sum(1 for v in hashMap.values() if v == maxValue)
        return count
```

```C++
class Solution {
public:
    int countLargestGroup(int n) {
        unordered_map<int, int> hashMap;
        int maxValue = 0;
        for (int i = 1; i <= n; ++i) {
            int key = 0, i0 = i;
            while (i0) {
                key += i0 % 10;
                i0 /= 10;
            }
            ++hashMap[key];
            maxValue = max(maxValue, hashMap[key]);
        }
        int count = 0;
        for (auto& kvpair: hashMap) {
            if (kvpair.second == maxValue) {
                ++count;
            }
        }
        return count;
    }
};
```

```C++
// C++17
class Solution {
public:
    int countLargestGroup(int n) {
        unordered_map<int, int> hashMap;
        int maxValue = 0;
        for (int i = 1; i <= n; ++i) {
            int key = 0, i0 = i;
            while (i0) {
                key += i0 % 10;
                i0 /= 10;
            }
            ++hashMap[key];
            maxValue = max(maxValue, hashMap[key]);
        }
        int count = 0;
        for (auto& [_, value]: hashMap) {
            if (value == maxValue) {
                ++count;
            }
        }
        return count;
    }
};
```

```Java
class Solution {
    public int countLargestGroup(int n) {
        Map<Integer, Integer> hashMap = new HashMap<Integer, Integer>();
        int maxValue = 0;
        for (int i = 1; i <= n; ++i) {
            int key = 0, i0 = i;
            while (i0 != 0) {
                key += i0 % 10;
                i0 /= 10;
            }
            hashMap.put(key, hashMap.getOrDefault(key, 0) + 1);
            maxValue = Math.max(maxValue, hashMap.get(key));
        }
        int count = 0;
        for (Map.Entry<Integer, Integer> kvpair : hashMap.entrySet()) {
            if (kvpair.getValue() == maxValue) {
                ++count;
            }
        }
        return count;
    }
}
```

```CSharp
public class Solution {
    public int CountLargestGroup(int n) {
        var hashMap = new Dictionary<int, int>();
        int maxValue = 0;
        for (int i = 1; i <= n; ++i) {
            int key = 0, i0 = i;
            while (i0 > 0) {
                key += i0 % 10;
                i0 /= 10;
            }
            if (hashMap.ContainsKey(key)) {
                hashMap[key]++;
            } else {
                hashMap[key] = 1;
            }
            maxValue = Math.Max(maxValue, hashMap[key]);
        }

        int count = 0;
        foreach (var value in hashMap.Values) {
            if (value == maxValue) {
                count++;
            }
        }
        return count;
    }
}
```

```Go
func countLargestGroup(n int) int {
    hashMap := make(map[int]int)
    maxValue := 0
    for i := 1; i <= n; i++ {
        key := 0
        i0 := i
        for i0 > 0 {
            key += i0 % 10
            i0 /= 10
        }
        hashMap[key]++
        maxValue = max(maxValue, hashMap[key])
    }

    count := 0
    for _, value := range hashMap {
        if value == maxValue {
            count++
        }
    }
    return count
}
```

```C
int countLargestGroup(int n) {
    int hashMap[100] = {0};
    int maxValue = 0;
    for (int i = 1; i <= n; ++i) {
        int key = 0, i0 = i;
        while (i0) {
            key += i0 % 10;
            i0 /= 10;
        }
        hashMap[key]++;
        if (hashMap[key] > maxValue) {
            maxValue = hashMap[key];
        }
    }

    int count = 0;
    for (int i = 0; i < 100; ++i) {
        if (hashMap[i] == maxValue) {
            count++;
        }
    }
    return count;
}
```

```JavaScript
var countLargestGroup = function(n) {
    let hashMap = {};
    let maxValue = 0;
    for (let i = 1; i <= n; ++i) {
        let key = 0, i0 = i;
        while (i0) {
            key += i0 % 10;
            i0 = Math.floor(i0 / 10);
        }
        hashMap[key] = (hashMap[key] || 0) + 1;
        maxValue = Math.max(maxValue, hashMap[key]);
    }

    let count = 0;
    for (let value of Object.values(hashMap)) {
        if (value === maxValue) {
            count++;
        }
    }
    return count;
};
```

```TypeScript
function countLargestGroup(n: number): number {
    let hashMap: { [key: number]: number } = {};
    let maxValue = 0;
    for (let i = 1; i <= n; ++i) {
        let key = 0, i0 = i;
        while (i0) {
            key += i0 % 10;
            i0 = Math.floor(i0 / 10);
        }
        hashMap[key] = (hashMap[key] || 0) + 1;
        maxValue = Math.max(maxValue, hashMap[key]);
    }

    let count = 0;
    for (let value of Object.values(hashMap)) {
        if (value === maxValue) {
            count++;
        }
    }
    return count;
};
```

```Rust
use std::collections::HashMap;

impl Solution {
    pub fn count_largest_group(n: i32) -> i32 {
        let mut hash_map = HashMap::new();
        let mut max_value = 0;
        for i in 1..=n {
            let mut key = 0;
            let mut i0 = i;
            while i0 > 0 {
                key += i0 % 10;
                i0 /= 10;
            }
            *hash_map.entry(key).or_insert(0) += 1;
            max_value = max_value.max(*hash_map.get(&key).unwrap());
        }

        let mut count = 0;
        for &value in hash_map.values() {
            if value == max_value {
                count += 1;
            }
        }
        count
    }
}
```

**复杂度分析**

- 时间复杂度：对数 $x$ 求数位和的时间为 $O(\log_{10}​x)=O(\log x)$，因此总时间代价为 $O(n \log n)$，选出最大元素和遍历哈希表的时间代价均为 $O(n)$，故渐渐时间复杂度 $O(n \log n)+O(n)=O(n \log n)$。
- 空间复杂度：使用哈希表作为辅助空间，$n$ 的数位个数为 $O(\log_{10}​n)=O(\log n)$，每一个数位都在 $[0,9]$ 之间，故哈希表最多包含的键的个数为 $O(10 \log n)=O(\log n)$，渐进空间复杂度为 $O(\log n)$。
