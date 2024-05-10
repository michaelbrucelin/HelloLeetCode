### [统计已测试设备](https://leetcode.cn/problems/count-tested-devices-after-test-operations/solutions/2756410/tong-ji-yi-ce-shi-she-bei-by-leetcode-so-v89z/)

#### 方法一：模拟

##### 思路与算法

根据题意可知，对于每个设备 $i$，执行以下测试操作：

- 如果 $\textit{batteryPercentages}[i] > 0$，则增加**已测试**设备的计数，将下标在 $j \in [i + 1, n - 1]$ 的所有设备的电池百分比减少 $1$，但不会减少为负数，此时 $\textit{batteryPercentages}[j] = \max(0, \textit{batteryPercentages}[j] - 1)$，继续移动到下一个设备；
- 如果 $\textit{batteryPercentages}[i] = 0$，移动到下一个设备而不执行任何测试。

根据题目要求进行模拟即可，遍历数组中的每一个元素，如果当前的元素大于 $0$，则增加计数，并数组将该元素之后的所有元素进行减 $1$，每个至多减少到 $0$，最后返回计数即可。

##### 代码

```c++
class Solution {
public:
    int countTestedDevices(vector<int>& batteryPercentages) {
        int n = batteryPercentages.size();
        int need = 0;
        for (int i = 0; i < n; i++) {
            if (batteryPercentages[i] > 0) {
                need++;
                for (int j = i + 1; j < n; j++) {
                    batteryPercentages[j] = max(batteryPercentages[j] - 1, 0);
                }
            }
        }
        return need;
    }
};
```

```c
int countTestedDevices(int* batteryPercentages, int batteryPercentagesSize) {
    int need = 0;
    for (int i = 0; i < batteryPercentagesSize; i++) {
        if (batteryPercentages[i] > 0) {
            need++;
            for (int j = i + 1; j < batteryPercentagesSize; j++) {
                batteryPercentages[j] = fmax(batteryPercentages[j] - 1, 0);
            }
        }
    }
    return need;
}
```

```java
class Solution {
    public int countTestedDevices(int[] batteryPercentages) {
        int n = batteryPercentages.length;
        int need = 0;
        for (int i = 0; i < n; i++) {
            if (batteryPercentages[i] > 0) {
                need++;
                for (int j = i + 1; j < n; j++) {
                    batteryPercentages[j] = Math.max(batteryPercentages[j] - 1, 0);
                }
            }
        }
        return need;
    }
}
```

```csharp
public class Solution {
    public int CountTestedDevices(int[] batteryPercentages) {
        int n = batteryPercentages.Length;
        int need = 0;
        for (int i = 0; i < n; i++) {
            if (batteryPercentages[i] > 0) {
                need++;
                for (int j = i + 1; j < n; j++) {
                    batteryPercentages[j] = Math.Max(batteryPercentages[j] - 1, 0);
                }
            }
        }
        return need;
    }
}
```

```python
class Solution:
    def countTestedDevices(self, batteryPercentages: List[int]) -> int:
        n = len(batteryPercentages)
        need = 0
        for i in range(n):
            if batteryPercentages[i] > 0:
                need += 1
                for j in range(i + 1, n):
                    batteryPercentages[j] = max(batteryPercentages[j] - 1, 0)
        return need
```

```go
func countTestedDevices(batteryPercentages []int) int {
    n := len(batteryPercentages)
	need := 0
	for i := 0; i < n; i++ {
		if batteryPercentages[i] > 0 {
			need++
			for j := i + 1; j < n; j++ {
				batteryPercentages[j] = max(batteryPercentages[j] - 1, 0)
			}
		}
	}
	return need
}
```

```javascript
var countTestedDevices = function(batteryPercentages) {
    let n = batteryPercentages.length;
    let need = 0;
    for (let i = 0; i < n; i++) {
        if (batteryPercentages[i] > 0) {
            need++;
            for (let j = i + 1; j < n; j++) {
                batteryPercentages[j] = Math.max(batteryPercentages[j] - 1, 0);
            }
        }
    }
    return need;
};
```

```typescript
function countTestedDevices(batteryPercentages: number[]): number {
    let n = batteryPercentages.length;
    let need = 0;
    for (let i = 0; i < n; i++) {
        if (batteryPercentages[i] > 0) {
            need++;
            for (let j = i + 1; j < n; j++) {
                batteryPercentages[j] = Math.max(batteryPercentages[j] - 1, 0);
            }
        }
    }
    return need;
};
```

```rust
impl Solution {
    pub fn count_tested_devices(battery_percentages: Vec<i32>) -> i32 {
        let mut battery_percentages = battery_percentages.clone();
        let n = battery_percentages.len();
        let mut need = 0;
        for i in 0..n {
            if battery_percentages[i] > 0 {
                need += 1;
                for j in (i + 1)..n {
                    battery_percentages[j] = std::cmp::max(battery_percentages[j] - 1, 0);
                }
            }
        }
        need
    }
}
```

##### 复杂度分析

- 时间复杂度：$O(n^2)$, $n$ 表示给定的数组 $\textit{batteryPercentages}$ 的长度。遍历数组时，最差的情况下对于每个元素都需要再遍历它之后的元素，需要的时间为 $O(n^2)$。
- 空间复杂度：$O(1)$。

#### 方法二：差分

##### 思路与算法

我们可以利用「[差分数组](https://leetcode.cn/link/?target=https%3A%2F%2Foi-wiki.org%2Fbasic%2Fprefix-sum%2F%23%E5%B7%AE%E5%88%86)」的思想，用 $\textit{need}$ 表示当前元素需要减 $1$ 的次数，如果当前元素 $x = \textit{batteryPercentages}[i]$，当满足 $x > \textit{need}$，如果 $x > \textit{need}$ 时，当前元素实际的值为 $x - \textit{need} > 0$，$i$ 后面的所有元素都需要减 $1$，此时需对 $\textit{need}$ 加 $1$，当遍历完数组后，返回 $\textit{need}$ 即可。

##### 代码

```c++
class Solution {
public:
    int countTestedDevices(vector<int>& batteryPercentages) {
        int need = 0;
        for (int battery : batteryPercentages) {
            if (battery > need) {
                need++;
            }
        }
        return need;
    }
};
```

```c
int countTestedDevices(int* batteryPercentages, int batteryPercentagesSize) {
    int need = 0;
    for (int i = 0; i < batteryPercentagesSize; i++) {
        if (batteryPercentages[i] > need) {
            need++;
        }
    }
    return need;
}
```

```java
class Solution {
    public int countTestedDevices(int[] batteryPercentages) {
        int need = 0;
        for (int battery : batteryPercentages) {
            if (battery > need) {
                need++;
            }
        }
        return need;
    }
}
```

```csharp
public class Solution {
    public int CountTestedDevices(int[] batteryPercentages) {
        int need = 0;
        foreach (int battery in batteryPercentages) {
            if (battery > need) {
                need++;
            }
        }
        return need;
    }
}
```

```python
class Solution:
    def countTestedDevices(self, batteryPercentages: List[int]) -> int:
        need = 0
        for battery in batteryPercentages:
            if battery > need:
                need += 1
        return need
```

```javascript
var countTestedDevices = function(batteryPercentages) {
    let need = 0;
    for (let battery of batteryPercentages) {
        if (battery > need) {
            need++;
        }
    }
    return need;
};
```

```typescript
function countTestedDevices(batteryPercentages: number[]): number {
    let need: number = 0;
    for (let battery of batteryPercentages) {
        if (battery > need) {
            need++;
        }
    }
    return need;
};
```

```rust
impl Solution {
    pub fn count_tested_devices(battery_percentages: Vec<i32>) -> i32 {
        let mut need = 0;
        for &battery in battery_percentages.iter() {
            if battery > need {
                need += 1;
            }
        }
        need
    }
}
```

##### 复杂度分析

- 时间复杂度：$O(n)$, $n$ 表示给定的数组 $\textit{batteryPercentages}$ 的长度。只需遍历一遍数组即可。
- 空间复杂度：$O(1)$。
