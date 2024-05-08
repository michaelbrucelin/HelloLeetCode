### [给植物浇水](https://leetcode.cn/problems/watering-plants/solutions/$1$5310/gei-zhi-wu-jiao-shui-by-leetcode-solutio-y84o/)

#### 方法一：维护剩余的水量

##### 思路与算法

我们可以模拟浇水的过程。

我们使用一个变量 $\textit{rest}$ 维护剩余的水量。当我们从第 $i-1$ 株植物到达第 $i$ 株植物时：

- 如果 $\textit{rest} \geq \textit{plants}[i]$，那么我们可以完成浇水，需要的步数就是从 $i-1$ 到 $i$ 的 $1$ 步；
- 如果 $\textit{rest} < \textit{plants}[i]$，那么我们无法完成浇水，必须要返回河边装满水罐，需要的步数为：
  - 从 $i-1$ 到 $-1$ 的 $i$ 步；
  - 从 $-1$ 到 $i$ 的 $i+1$ 步。

总计 $2i + 1$ 步。

当我们模拟完成所有 $n$ 株植物的浇水过程之后，就可以返回总步数作为答案。

##### 代码

```c++
class Solution {
public:
    int wateringPlants(vector<int>& plants, int capacity) {
        int n = plants.size();
        int ans = 0;
        int rest = capacity;
        for (int i = 0; i < n; ++i) {
            if (rest >= plants[i]) {
                ++ans;
                rest -= plants[i];
            }
            else {
                ans += i * 2 + 1;
                rest = capacity - plants[i];
            }
        }
        return ans;
    }
};
```

```python
class Solution:
    def wateringPlants(self, plants: List[int], capacity: int) -> int:
        ans, rest = 0, capacity

        for i, plant in enumerate(plants):
            if rest >= plants[i]:
                ans += 1
                rest -= plants[i]
            else:
                ans += i * 2 + 1
                rest = capacity - plants[i]
        
        return ans
```

```java
class Solution {
    public int wateringPlants(int[] plants, int capacity) {
        int n = plants.length;
        int ans = 0;
        int rest = capacity;
        for (int i = 0; i < n; ++i) {
            if (rest >= plants[i]) {
                ++ans;
                rest -= plants[i];
            } else {
                ans += i * 2 + 1;
                rest = capacity - plants[i];
            }
        }
        return ans;
    }
}
```

```c
int wateringPlants(int* plants, int plantsSize, int capacity) {
    int ans = 0;
    int rest = capacity;
    for (int i = 0; i < plantsSize; ++i) {
        if (rest >= plants[i]) {
            ++ans;
            rest -= plants[i];
        } else {
            ans += i * 2 + 1;
            rest = capacity - plants[i];
        }
    }
    return ans;
}
```

```go
func wateringPlants(plants []int, capacity int) int {
    ans := 0
    rest := capacity
    for i, plant := range plants {
        if rest >= plant {
            ans++
            rest -= plant
        } else {
            ans += i*2 + 1
            rest = capacity - plant
        }
    }
    return ans
}
```

```javascript
var wateringPlants = function(plants, capacity) {
    let ans = 0;
    let rest = capacity;
    for (let i = 0; i < plants.length; i++) {
        if (rest >= plants[i]) {
            ans++;
            rest -= plants[i];
        } else {
            ans += i * 2 + 1;
            rest = capacity - plants[i];
        }
    }
    return ans;
};
```

```typescript
function wateringPlants(plants: number[], capacity: number): number {
    let ans = 0;
    let rest = capacity;
    for (let i = 0; i < plants.length; i++) {
        if (rest >= plants[i]) {
            ans++;
            rest -= plants[i];
        } else {
            ans += i * 2 + 1;
            rest = capacity - plants[i];
        }
    }
    return ans;
};
```

```rust
impl Solution {
    pub fn watering_plants(plants: Vec<i32>, capacity: i32) -> i32 {
        let mut ans = 0;
        let mut rest = capacity;
        for (i, &plant) in plants.iter().enumerate() {
            if rest >= plant {
                ans += 1;
                rest -= plant;
            } else {
                ans += i as i32 * 2 + 1;
                rest = capacity - plant;
            }
        }
        ans
    }
}
```

##### 复杂度分析

- 时间复杂度：$O(n)$。
- 空间复杂度：$O(1)$。
