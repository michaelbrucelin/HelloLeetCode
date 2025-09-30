### [数组的三角和](https://leetcode.cn/problems/find-triangular-sum-of-an-array/solutions/1418104/shu-zu-de-san-jiao-he-by-leetcode-soluti-qpc8/)

#### 方法一：模拟

**思路与算法**

我们只需要按照题目中的操作进行模拟即可。

记数组 $nums$ 的长度为 $n$。我们进行 $n-1$ 次循环，第 $i (0\le i<n)$ 次循环得到 $(nums[i]+nums[i+1])mod10$ 的值，并将其放去一个新的数组 $new\_nums$ 中。当循环结束后，我们再用 $new\_nums$ 覆盖 $nums$。

当 $n=1$ 时，操作结束，我们返回 $nums[0]$ 即可。

**代码**

```C++
class Solution {
public:
    int triangularSum(vector<int>& nums) {
        while (nums.size() > 1) {
            vector<int> new_nums;
            for (int i = 0; i < nums.size() - 1; ++i) {
                new_nums.push_back((nums[i] + nums[i + 1]) % 10);
            }
            nums = move(new_nums);
        }
        return nums[0];
    }
};
```

```Python
class Solution:
    def triangularSum(self, nums: List[int]) -> int:
        while len(nums) > 1:
            new_nums = list()
            for i in range(len(nums) - 1):
                new_nums.append((nums[i] + nums[i + 1]) % 10)
            nums = new_nums
        return nums[0]
```

```Java
class Solution {
    public int triangularSum(int[] nums) {
        List<Integer> current = Arrays.stream(nums).boxed().collect(Collectors.toList());
        while (current.size() > 1) {
            List<Integer> newNums = new ArrayList<>();
            for (int i = 0; i < current.size() - 1; ++i) {
                newNums.add((current.get(i) + current.get(i + 1)) % 10);
            }
            current = newNums;
        }
        return current.get(0);
    }
}
```

```CSharp
public class Solution {
    public int TriangularSum(int[] nums) {
        List<int> current = new List<int>(nums);
        while (current.Count > 1) {
            List<int> newNums = new List<int>();
            for (int i = 0; i < current.Count - 1; ++i) {
                newNums.Add((current[i] + current[i + 1]) % 10);
            }
            current = newNums;
        }
        return current[0];
    }
}
```

```Go
func triangularSum(nums []int) int {
    current := nums    
    for len(current) > 1 {
        newNums := make([]int, 0, len(current)-1)
        for i := 0; i < len(current)-1; i++ {
            newNums = append(newNums, (current[i] + current[i + 1])%10)
        }
        current = newNums
    }
    return current[0]
}
```

```C
int triangularSum(int* nums, int numsSize) {
    int* current = (int*)malloc(numsSize * sizeof(int));
    int* newNums = (int*)malloc(numsSize * sizeof(int));
    memcpy(current, nums, numsSize * sizeof(int));
    int currentSize = numsSize;    
    while (currentSize > 1) {
        for (int i = 0; i < currentSize - 1; ++i) {
            newNums[i] = (current[i] + current[i + 1]) % 10;
        }
        currentSize--;
        memcpy(current, newNums, sizeof(int) * currentSize);
    }
    
    int result = current[0];
    free(current);
    free(newNums);
    return result;
}
```

```JavaScript
var triangularSum = function(nums) {
    let current = nums;    
    while (current.length > 1) {
        const newNums = [];
        for (let i = 0; i < current.length - 1; i++) {
            newNums.push((current[i] + current[i + 1]) % 10);
        }
        current = newNums;
    }
    return current[0];
};

```

```TypeScript
function triangularSum(nums: number[]): number {
    let current = nums;
    while (current.length > 1) {
        const newNums: number[] = [];
        for (let i = 0; i < current.length - 1; i++) {
            newNums.push((current[i] + current[i + 1]) % 10);
        }
        current = newNums;
    }
    return current[0];
}
```

```Rust
impl Solution {
    pub fn triangular_sum(nums: Vec<i32>) -> i32 {
        let mut current = nums.clone();
        while current.len() > 1 {
            let mut new_nums = Vec::with_capacity(current.len() - 1);
            for i in 0..current.len() - 1 {
                new_nums.push((current[i] + current[i + 1]) % 10);
            }
            current = new_nums;
        }
        current[0]
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n^2)$。
- 空间复杂度：$O(n)$，即数组 $new\_nums$ 需要使用的空间。
