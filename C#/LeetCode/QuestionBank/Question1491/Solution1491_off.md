### [去掉最低工资和最高工资后的工资平均值](https://leetcode.cn/problems/average-salary-excluding-the-minimum-and-maximum-salary/solutions/327125/qu-diao-zui-di-gong-zi-he-zui-gao-gong-zi-hou-de-4/)

#### 方法一：模拟

##### 思路

我们可以按照题意来模拟：

- 找到一个最大值 $\rm maxValue$；
- 找到一个最小值 $\rm minValue$；
- 然后对所有元素求和后减去这两个值 ${\rm sum} = (\sum_{i} {\rm salary}[i]) - {\rm maxValue} - {\rm minValue}$；
- 求平均值 ${\rm sum} / [{\rm salary.size() - 2}]$。

因为这里保证了 $\rm salary$ 数组的长度至少是 $3$，所以我们不用特殊考虑 $\rm maxValue$ 和 $\rm minValue$ 是同一个的问题，因为如果它们相等的话（假设等于 $x$），这个序列里面所有元素都应该是 $x$，不影响计算结果。

##### 代码

```c++
class Solution {
public:
    double average(vector<int>& salary) {
        double maxValue = *max_element(salary.begin(), salary.end());
        double minValue = *min_element(salary.begin(), salary.end());
        double sum = accumulate(salary.begin(), salary.end(), - maxValue - minValue);
        return sum / int(salary.size() - 2);
    }
};
```

```java
class Solution {
    public double average(int[] salary) {
        double sum = 0;
        double maxValue = Integer.MIN_VALUE, minValue = Integer.MAX_VALUE;
        for (int num : salary) {
            sum += num;
            maxValue = Math.max(maxValue, num);
            minValue = Math.min(minValue, num);
        }
        return (sum - maxValue - minValue) / (salary.length - 2);
    }
}
```

```python
class Solution:
    def average(self, salary: List[int]) -> float:
        maxValue = max(salary)
        minValue = min(salary)
        total = sum(salary) - maxValue - minValue
        return total / (len(salary) - 2)
```

```c
double average(int* salary, int salarySize) {
    double maxValue = INT_MIN;
    double minValue = INT_MAX;
    double sum = 0;

    for (int i = 0; i < salarySize; ++i) {
        if (salary[i] > maxValue) {
            maxValue = salary[i];
        }
        if (salary[i] < minValue) {
            minValue = salary[i];
        }
        sum += salary[i];
    }
    sum -= maxValue + minValue;
    return sum / (salarySize - 2);
}
```

```go
func average(salary []int) float64 {
    maxValue := salary[0]
    minValue := salary[0]
    sum := 0
    for _, s := range salary {
        if s > maxValue {
            maxValue = s
        }
        if s < minValue {
            minValue = s
        }
        sum += s
    }
    sum -= maxValue + minValue
    return float64(sum) / float64(len(salary) - 2)
}
```

```javascript
var average = function(salary) {
    let maxValue = Math.max(...salary);
    let minValue = Math.min(...salary);
    let sum = salary.reduce((acc, cur) => acc + cur, 0);
    sum -= maxValue + minValue;
    return sum / (salary.length - 2);
};
```

```typescript
function average(salary: number[]): number {
    let maxValue = Math.max(...salary);
    let minValue = Math.min(...salary);
    let sum = salary.reduce((acc, cur) => acc + cur, 0);
    sum -= maxValue + minValue;
    return sum / (salary.length - 2);
};
```

```rust
impl Solution {
    pub fn average(salary: Vec<i32>) -> f64 {
        let mut max_value = i32::MIN;
        let mut min_value = i32::MAX;
        let mut sum = 0;
        for &s in salary.iter() {
            if s > max_value {
                max_value = s;
            }
            if s < min_value {
                min_value = s;
            }
            sum += s;
        }
        sum -= max_value + min_value;
        sum as f64 / (salary.len() as f64 - 2.0)
    }
}
```

##### 复杂度

- 时间复杂度：$O(n)$。选取最大值、最小值和求和的过程的时间代价都是 $O(n)$，故渐进时间复杂度为 $O(n)$。
- 空间复杂度：$O(1)$。这里只用到了常量级别的辅助空间。
