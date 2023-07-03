#### [方法一：前缀和](https://leetcode.cn/problems/range-sum-query-immutable/solutions/627052/qu-yu-he-jian-suo-shu-zu-bu-ke-bian-by-l-px41/)

最朴素的想法是存储数组 $nums$ 的值，每次调用 $sumRange$ 时，通过循环的方法计算数组 $nums$ 从下标 $i$ 到下标 $j$ 范围内的元素和，需要计算 $j-i+1$ 个元素的和。由于每次检索的时间和检索的下标范围有关，因此检索的时间复杂度较高，如果检索次数较多，则会超出时间限制。

由于会进行多次检索，即多次调用 $sumRange$，因此为了降低检索的总时间，应该降低 $sumRange$ 的时间复杂度，最理想的情况是时间复杂度 $O(1)$。为了将检索的时间复杂度降到 $O(1)$，需要在初始化的时候进行预处理。

注意到当 $i \le j$ 时，$sumRange(i,j)$ 可以写成如下形式：

$$\begin{aligned} &\quad \ sumRange(i,j) \\ &=\sum\limits_{k=i}^j nums[k] \\ &= \sum\limits_{k=0}^j nums[k] - \sum\limits_{k=0}^{i-1} nums[k] \end{aligned}$$

由此可知，要计算 $sumRange(i,j)$，则需要计算数组 $nums$ 在下标 $j$ 和下标 $i-1$ 的前缀和，然后计算两个前缀和的差。

如果可以在初始化的时候计算出数组 $nums$ 在每个下标处的前缀和，即可满足每次调用 $sumRange$ 的时间复杂度都是 $O(1)$。

具体实现方面，假设数组 $nums$ 的长度为 $n$，创建长度为 $n+1$ 的前缀和数组 $sums$，对于 $0 \le i<n$ 都有 $sums[i+1]=sums[i]+nums[i]$，则当 $0 < i \le n$ 时，$sums[i]$ 表示数组 $nums$ 从下标 $0$ 到下标 $i-1$ 的前缀和。

将前缀和数组 $sums$ 的长度设为 $n+1$ 的目的是为了方便计算 $sumRange(i,j)$，不需要对 $i=0$ 的情况特殊处理。此时有：

$$sumRange(i,j)=sums[j+1]-sums[i]$$

```java
class NumArray {
    int[] sums;

    public NumArray(int[] nums) {
        int n = nums.length;
        sums = new int[n + 1];
        for (int i = 0; i < n; i++) {
            sums[i + 1] = sums[i] + nums[i];
        }
    }
    
    public int sumRange(int i, int j) {
        return sums[j + 1] - sums[i];
    }
}
```

```javascript
var NumArray = function(nums) {
    const n = nums.length;
    this.sums = new Array(n + 1).fill(0);
    for (let i = 0; i < n; i++) {
        this.sums[i + 1] = this.sums[i] + nums[i];
    }
};

NumArray.prototype.sumRange = function(i, j) {
    return this.sums[j + 1] - this.sums[i];
};
```

```go
type NumArray struct {
    sums []int
}

func Constructor(nums []int) NumArray {
    sums := make([]int, len(nums)+1)
    for i, v := range nums {
        sums[i+1] = sums[i] + v
    }
    return NumArray{sums}
}

func (na *NumArray) SumRange(i, j int) int {
    return na.sums[j+1] - na.sums[i]
}
```

```python
class NumArray:

    def __init__(self, nums: List[int]):
        self.sums = [0]
        _sums = self.sums

        for num in nums:
            _sums.append(_sums[-1] + num)

    def sumRange(self, i: int, j: int) -> int:
        _sums = self.sums
        return _sums[j + 1] - _sums[i]
```

```cpp
class NumArray {
public:
    vector<int> sums;

    NumArray(vector<int>& nums) {
        int n = nums.size();
        sums.resize(n + 1);
        for (int i = 0; i < n; i++) {
            sums[i + 1] = sums[i] + nums[i];
        }
    }

    int sumRange(int i, int j) {
        return sums[j + 1] - sums[i];
    }
};
```

```c
typedef struct {
    int* sums;
} NumArray;

NumArray* numArrayCreate(int* nums, int numsSize) {
    NumArray* ret = malloc(sizeof(NumArray));
    ret->sums = malloc(sizeof(int) * (numsSize + 1));
    ret->sums[0] = 0;
    for (int i = 0; i < numsSize; i++) {
        ret->sums[i + 1] = ret->sums[i] + nums[i];
    }
    return ret;
}

int numArraySumRange(NumArray* obj, int i, int j) {
    return obj->sums[j + 1] - obj->sums[i];
}

void numArrayFree(NumArray* obj) {
    free(obj->sums);
}
```

**复杂度分析**

-   时间复杂度：初始化 $O(n)$，每次检索 $O(1)$，其中 $n$ 是数组 $nums$ 的长度。 初始化需要遍历数组 $nums$ 计算前缀和，时间复杂度是 $O(n)$。 每次检索只需要得到两个下标处的前缀和，然后计算差值，时间复杂度是 $O(1)$。
-   空间复杂度：$O(n)$，其中 $n$ 是数组 $nums$ 的长度。需要创建一个长度为 $n+1$ 的前缀和数组。
