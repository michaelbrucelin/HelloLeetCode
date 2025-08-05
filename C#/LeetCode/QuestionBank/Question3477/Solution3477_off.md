### [水果成篮 II](https://leetcode.cn/problems/fruits-into-baskets-ii/solutions/3737060/shui-guo-cheng-lan-ii-by-leetcode-soluti-f92n/)

#### 方法一：模拟

**思路及解法**

由于本题数据量很小，我们只需要枚举每种水果，然后从左到右枚举每个篮子，观察当前水果是否有篮子可以装下。存在两种情况：

1. 如果能找到装得下当前水果的篮子，也就是篮子的容量大于等于水果数量，那么用来装当前水果的篮子则不能再用，将其容量更新为 $0$。
2. 如果找不到装得下当前水果的篮子，也就是篮子的容量小于水果数量，那么计数器 $count$ 加一。

**代码**

```C++
class Solution {
public:
    int numOfUnplacedFruits(vector<int>& fruits, vector<int>& baskets) {
        int count = 0;
        int n = baskets.size();
        for (auto fruit : fruits) {
            int unset = 1;
            for (int i = 0; i < n; i++) {
                if (fruit <= baskets[i]) {
                    baskets[i] = 0;
                    unset = 0;
                    break;
                }
            }
            count += unset;
        }
        return count;
    }
};
```

```Java
class Solution {
    public int numOfUnplacedFruits(int[] fruits, int[] baskets) {
        int count = 0;
        int n = baskets.length;
        for (int fruit : fruits) {
            int unset = 1;
            for (int i = 0; i < n; i++) {
                if (fruit <= baskets[i]) {
                    baskets[i] = 0;
                    unset = 0;
                    break;
                }
            }
            count += unset;
        }
        return count;
    }
}
```

```CSharp
public class Solution {
    public int NumOfUnplacedFruits(int[] fruits, int[] baskets) {
        int count = 0;
        int n = baskets.Length;
        foreach (int fruit in fruits) {
            int unset = 1;
            for (int i = 0; i < n; i++) {
                if (fruit <= baskets[i]) {
                    baskets[i] = 0;
                    unset = 0;
                    break;
                }
            }
            count += unset;
        }
        return count;
    }
}
```

```Go
func numOfUnplacedFruits(fruits []int, baskets []int) int {
    count := 0
    n := len(baskets)
    for _, fruit := range fruits {
        unset := 1
        for i := 0; i < n; i++ {
            if fruit <= baskets[i] {
                baskets[i] = 0
                unset = 0
                break
            }
        }
        count += unset
    }
    return count
}
```

```Python
class Solution:
    def numOfUnplacedFruits(self, fruits: List[int], baskets: List[int]) -> int:
        count = 0
        n = len(baskets)
        for fruit in fruits:
            unset = 1
            for i in range(n):
                if fruit <= baskets[i]:
                    baskets[i] = 0
                    unset = 0
                    break
            count += unset
        return count
```

```C
int numOfUnplacedFruits(int* fruits, int fruitsSize, int* baskets, int basketsSize) {
    int count = 0;
    for (int j = 0; j < fruitsSize; j++) {
        int unset = 1;
        for (int i = 0; i < basketsSize; i++) {
            if (fruits[j] <= baskets[i]) {
                baskets[i] = 0;
                unset = 0;
                break;
            }
        }
        count += unset;
    }
    return count;
}
```

```JavaScript
var numOfUnplacedFruits = function(fruits, baskets) {
    let count = 0;
    const n = baskets.length;
    for (const fruit of fruits) {
        let unset = 1;
        for (let i = 0; i < n; i++) {
            if (fruit <= baskets[i]) {
                baskets[i] = 0;
                unset = 0;
                break;
            }
        }
        count += unset;
    }
    return count;
};
```

```TypeScript
function numOfUnplacedFruits(fruits: number[], baskets: number[]): number {
    let count = 0;
    const n = baskets.length;
    for (const fruit of fruits) {
        let unset = 1;
        for (let i = 0; i < n; i++) {
            if (fruit <= baskets[i]) {
                baskets[i] = 0;
                unset = 0;
                break;
            }
        }
        count += unset;
    }
    return count;
}
```

```Rust
impl Solution {
    pub fn num_of_unplaced_fruits(fruits: Vec<i32>, mut baskets: Vec<i32>) -> i32 {
        let mut count = 0;
        let n = baskets.len();
        for fruit in fruits {
            let mut unset = 1;
            for i in 0..n {
                if fruit <= baskets[i] {
                    baskets[i] = 0;
                    unset = 0;
                    break;
                }
            }
            count += unset;
        }
        count
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n^2)$，其中 $n$ 是数组 $fruits$ 的长度，每遍历到一种水果都需要遍历一遍篮子数组。
- 空间复杂度：$O(1)$，申请了常数个变量。
