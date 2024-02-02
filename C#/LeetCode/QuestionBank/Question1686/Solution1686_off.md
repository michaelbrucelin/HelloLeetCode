### [石子游戏 VI](https://leetcode.cn/problems/stone-game-vi/solutions/2623533/shi-zi-you-xi-vi-by-leetcode-solution-t2u9/)

#### 方法一：贪心 + 排序

##### 思路

假设有 $2$ 个石子 $i$ 和 $j$，$\text{Alice}$ 和 $\text{Bob}$ 认为它们的价值分别为 $a_i$, $b_i$ 和 $a_j$, $b_j$。如果 $\text{Alice}$ 取了 $i$，而 $\text{Bob}$ 取了 $j$，则它们的分数差为 $a_i - b_j$；如果 $\text{Alice}$ 取了 $j$，而 $\text{Bob}$ 取了 $i$，则它们的分数差为 $a_j - b_i$。对于 $\text{Alice}$ 来说，这两个方案，选取哪一种，取决于这两个分数差的差：$(a_i - b_j)-(a_j - b_i) = (a_i+b_i)-(a_j+b_j)$。当这个值 $>0$ 时，$\text{Alice}$ 会优先选择 $i$，当这个值 $<0$ 时，$\text{Alice}$ 会优先选择 $j$。因此，$\text{Alice}$ 在选择时，会优先选择 $(a_i+b_i)$ 大的石头。

我们只需要将两个数组 $\textit{aliceValues}$ 和 $\textit{bobValues}$ 对应的元素相加后倒序排序，然后 $\text{Alice}$ 和 $\text{Bob}$ 依次选取，最后计算两人的分数和后进行比较返回结果。

##### 代码

```python
class Solution {
public:
    int stoneGameVI(vector<int>& aliceValues, vector<int>& bobValues) {
        int n = aliceValues.size();
        vector<tuple<int, int, int>> values;
        for (int i = 0; i < aliceValues.size(); i++) {
            values.emplace_back(aliceValues[i] + bobValues[i], aliceValues[i], bobValues[i]);
        }
        sort(values.begin(), values.end(), [](tuple<int, int, int> &a, tuple<int, int, int> &b) {
            return get<0>(a) > get<0>(b);
        });
        int aliceSum = 0, bobSum = 0;
        for (int i = 0; i < n; i++) {
            if (i % 2 == 0) {
                aliceSum += get<1>(values[i]);
            } else {
                bobSum += get<2>(values[i]);
            }
        }

        if (aliceSum > bobSum) {
            return 1;
        } else if (aliceSum == bobSum) {
            return 0;
        } else {
            return -1;
        }
    }
}; 
```

```java
class Solution {
public:
    int stoneGameVI(vector<int>& aliceValues, vector<int>& bobValues) {
        int n = aliceValues.size();
        vector<tuple<int, int, int>> values;
        for (int i = 0; i < aliceValues.size(); i++) {
            values.emplace_back(aliceValues[i] + bobValues[i], aliceValues[i], bobValues[i]);
        }
        sort(values.begin(), values.end(), [](tuple<int, int, int> &a, tuple<int, int, int> &b) {
            return get<0>(a) > get<0>(b);
        });
        int aliceSum = 0, bobSum = 0;
        for (int i = 0; i < n; i++) {
            if (i % 2 == 0) {
                aliceSum += get<1>(values[i]);
            } else {
                bobSum += get<2>(values[i]);
            }
        }

        if (aliceSum > bobSum) {
            return 1;
        } else if (aliceSum == bobSum) {
            return 0;
        } else {
            return -1;
        }
    }
}; 
```

```csharp
class Solution {
public:
    int stoneGameVI(vector<int>& aliceValues, vector<int>& bobValues) {
        int n = aliceValues.size();
        vector<tuple<int, int, int>> values;
        for (int i = 0; i < aliceValues.size(); i++) {
            values.emplace_back(aliceValues[i] + bobValues[i], aliceValues[i], bobValues[i]);
        }
        sort(values.begin(), values.end(), [](tuple<int, int, int> &a, tuple<int, int, int> &b) {
            return get<0>(a) > get<0>(b);
        });
        int aliceSum = 0, bobSum = 0;
        for (int i = 0; i < n; i++) {
            if (i % 2 == 0) {
                aliceSum += get<1>(values[i]);
            } else {
                bobSum += get<2>(values[i]);
            }
        }

        if (aliceSum > bobSum) {
            return 1;
        } else if (aliceSum == bobSum) {
            return 0;
        } else {
            return -1;
        }
    }
}; 
```

```c++
class Solution {
public:
    int stoneGameVI(vector<int>& aliceValues, vector<int>& bobValues) {
        int n = aliceValues.size();
        vector<tuple<int, int, int>> values;
        for (int i = 0; i < aliceValues.size(); i++) {
            values.emplace_back(aliceValues[i] + bobValues[i], aliceValues[i], bobValues[i]);
        }
        sort(values.begin(), values.end(), [](tuple<int, int, int> &a, tuple<int, int, int> &b) {
            return get<0>(a) > get<0>(b);
        });
        int aliceSum = 0, bobSum = 0;
        for (int i = 0; i < n; i++) {
            if (i % 2 == 0) {
                aliceSum += get<1>(values[i]);
            } else {
                bobSum += get<2>(values[i]);
            }
        }

        if (aliceSum > bobSum) {
            return 1;
        } else if (aliceSum == bobSum) {
            return 0;
        } else {
            return -1;
        }
    }
}; 
```

```c
static int cmp(const void *a, const void *b) {
    return ((int *)b)[0] - ((int *)a)[0];
}

int stoneGameVI(int* aliceValues, int aliceValuesSize, int* bobValues, int bobValuesSize) {
    int n = aliceValuesSize;
    int values[n][3];
    for (int i = 0; i < n; i++) {
        values[i][0] = aliceValues[i] + bobValues[i];
        values[i][1] = aliceValues[i];
        values[i][2] = bobValues[i];
    }
    qsort(values, n, sizeof(values[0]), cmp);
    int aliceSum = 0, bobSum = 0;
    for (int i = 0; i < n; i++) {
        if (i % 2 == 0) {
            aliceSum += values[i][1];
        } else {
            bobSum += values[i][2];
        }
    }
    if (aliceSum > bobSum) {
        return 1;
    } else if (aliceSum == bobSum) {
        return 0;
    } else {
        return -1;
    }
} 
```

```go
func stoneGameVI(aliceValues []int, bobValues []int) int {
    n := len(aliceValues)
	values := make([][]int, n)
	for i := 0; i < n; i++ {
		values[i] = []int{aliceValues[i] + bobValues[i], aliceValues[i], bobValues[i]}
	}
	sort.Slice(values, func(i, j int) bool {
		return values[i][0] > values[j][0]
	})
	aliceSum, bobSum := 0, 0
    for i := 0; i < n; i++ {
        if i % 2 == 0 {
            aliceSum += values[i][1]
        } else {
            bobSum += values[i][2]
        }
    }

	if aliceSum > bobSum {
		return 1
	} else if aliceSum == bobSum {
		return 0
	} else {
		return -1
	}
} 
```

```javascript
var stoneGameVI = function(aliceValues, bobValues) {
    const values = aliceValues.map((a, i) => [a + bobValues[i], a, bobValues[i]]);
    values.sort((a, b) => b[0] - a[0]);
    const aliceSum = values.filter((_, i) => i % 2 === 0).reduce((sum, value) => sum + value[1], 0);
    const bobSum = values.filter((_, i) => i % 2 !== 0).reduce((sum, value) => sum + value[2], 0);
    if (aliceSum > bobSum) {
        return 1;
    } else if (aliceSum === bobSum) {
        return 0;
    } else {
        return -1;
    }
}; 
```

```typescript
function stoneGameVI(aliceValues: number[], bobValues: number[]): number {
    const values: number[][] = aliceValues.map((a, i) => [a + bobValues[i], a, bobValues[i]]);
    values.sort((a, b) => b[0] - a[0]);

    const aliceSum: number = values.filter((_, i) => i % 2 === 0).reduce((sum, value) => sum + value[1], 0);
    const bobSum: number = values.filter((_, i) => i % 2 !== 0).reduce((sum, value) => sum + value[2], 0);

    if (aliceSum > bobSum) {
        return 1;
    } else if (aliceSum === bobSum) {
        return 0;
    } else {
        return -1;
    }
}; 
```

```rust
impl Solution {
    pub fn stone_game_vi(alice_values: Vec<i32>, bob_values: Vec<i32>) -> i32 {
        let mut values: Vec<Vec<i32>> = alice_values
        .into_iter()
        .zip(bob_values)
        .map(|(a, b)| vec![a + b, a, b])
        .collect();

        values.sort_by(|a, b| b[0].cmp(&a[0]));
        let alice_sum: i32 = values.iter().step_by(2).map(|value| value[1]).sum();
        let bob_sum: i32 = values.iter().skip(1).step_by(2).map(|value| value[2]).sum();

        if alice_sum > bob_sum {
            1
        } else if alice_sum == bob_sum {
            0
        } else {
            -1
        }
    }
} 
```

#### 复杂度分析

- 时间复杂度：$O(n\times\log{n})$。需要进行一次排序。
- 空间复杂度：$O(n)$，为额外的数组 $\textit{values}$ 的空间复杂度。
