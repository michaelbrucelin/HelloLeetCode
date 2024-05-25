### [找出满足差值条件的下标 I](https://leetcode.cn/problems/find-indices-with-index-and-value-difference-i/solutions/2784952/zhao-chu-man-zu-chai-zhi-tiao-jian-de-xi-wxxb/)

#### 方法一：双层循环

**思路**

进行双层循环，遍历所有 $i$ 和 $j$ 的可能性，如果满足条件则返回 $[i,j]$。如果遍历完成后仍未找到满足条件的下标对则返回 $[-1,-1]$。

**代码**

```Python3
class Solution:
    def findIndices(self, nums: List[int], indexDifference: int, valueDifference: int) -> List[int]:
        for i in range(len(nums)):
            for j in range(i, len(nums)):
                if j - i >= indexDifference and abs(nums[j] - nums[i]) >= valueDifference:
                    return [i, j]
        return [-1, -1]
```

```Java
class Solution {
    public int[] findIndices(int[] nums, int indexDifference, int valueDifference) {
        for (int i = 0; i < nums.length; i++) {
            for (int j = i; j < nums.length; j++) {
                if (j - i >= indexDifference && Math.abs(nums[j] - nums[i]) >= valueDifference) {
                    return new int[]{i, j};
                }
            }
        }
        return new int[]{-1, -1};
    }
}
```

```CSharp
public class Solution {
    public int[] FindIndices(int[] nums, int indexDifference, int valueDifference) {
        for (int i = 0; i < nums.Length; i++) {
            for (int j = i; j < nums.Length; j++) {
                if (j - i >= indexDifference && Math.Abs(nums[j] - nums[i]) >= valueDifference) {
                    return new int[]{i, j};
                }
            }
        }
        return new int[]{-1, -1};
    }
}
```

```C++
class Solution {
public:
    vector<int> findIndices(vector<int>& nums, int indexDifference, int valueDifference) {
        for (int i = 0; i < nums.size(); i++) {
            for (int j = i; j < nums.size(); j++) {
                if (j - i >= indexDifference && abs(nums[j] - nums[i]) >= valueDifference) {
                    return {i, j};
                }
            }
        }
        return {-1, -1};
    }
};
```

```C
int* findIndices(int* nums, int numsSize, int indexDifference, int valueDifference, int* returnSize) {
    *returnSize = 2;
    int *ret = (int *)malloc(sizeof(int) * 2);
    for (int i = 0; i < numsSize; i++) {
        for (int j = i; j < numsSize; j++) {
            if (j - i >= indexDifference && abs(nums[j] - nums[i]) >= valueDifference) {
                ret[0] = i;
                ret[1] = j;
                return ret;
            }
        }
    }
    ret[0] = -1;
    ret[1] = -1;
    return ret;
}
```

```Go
func abs(x int) int {
    if x < 0 {
        return -x
    }
    return x
}

func findIndices(nums []int, indexDifference int, valueDifference int) []int {
    for i := 0; i < len(nums); i++ {
        for j := i; j < len(nums); j++ {
            if j - i >= indexDifference && abs(nums[j] - nums[i]) >= valueDifference {
                return []int{i, j}
            }
        }
    }
    return []int{-1, -1}
}
```

```JavaScript
var findIndices = function(nums, indexDifference, valueDifference) {
    for (let i = 0; i < nums.length; i++) {
        for (let j = i; j < nums.length; j++) {
            if (j - i >= indexDifference && Math.abs(nums[j] - nums[i]) >= valueDifference) {
                return [i, j];
            }
        }
    }
    return [-1, -1];
};
```

```TypeScript
function findIndices(nums: number[], indexDifference: number, valueDifference: number): number[] {
    for (let i = 0; i < nums.length; i++) {
        for (let j = i; j < nums.length; j++) {
            if (j - i >= indexDifference && Math.abs(nums[j] - nums[i]) >= valueDifference) {
                return [i, j];
            }
        }
    }
    return [-1, -1];
};
```

```Rust
impl Solution {
    pub fn find_indices(nums: Vec<i32>, index_difference: i32, value_difference: i32) -> Vec<i32> {
        for i in 0..nums.len() {
            for j in i..nums.len() {
                if j - i >= index_difference as usize && (nums[j] - nums[i]).abs() >= value_difference {
                    return vec![i as i32, j as i32];
                }
            }
        }
        vec![-1, -1]
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n^2)$。
- 空间复杂度：$O(1)$。

#### 方法二：一次遍历

**思路**

不妨设 $j \ge i$。这样，为了满足下标条件，$j$ 的取值范围为 $[\textit{indexDifference},n-1]$。对于某个固定的 $j$，$i$ 的取值范围为 $[0,j-\textit{indexDifference}]$。随着 $j$ 的不断增大，$i$ 的取值范围是不断增大的。而在满足下标条件之外，为了满足 $|\textit{nums}[i] - \textit{nums}[j]| >= valueDifference$，我们只需要记录 $\textit{nums}[i]$ 的最大值和最小值即可。如果 $\textit{nums}[i]$ 的最大值和最小值都不能满足第二个条件，那么其他值也不能满足条件。在遍历过程中，如果满足条件则返回 $[i,j]$。如果遍历完成后仍未找到满足条件的下标对则返回 $[-1,-1]$。

**代码**

```Python3
class Solution:
    def findIndices(self, nums: List[int], indexDifference: int, valueDifference: int) -> List[int]:
        minIndex, maxIndex = 0, 0
        for j in range(indexDifference, len(nums)):
            i = j - indexDifference
            if nums[i] < nums[minIndex]:
                minIndex = i
            if nums[j] - nums[minIndex] >= valueDifference:
                return [minIndex, j]
            if nums[i] > nums[maxIndex]:
                maxIndex = i
            if nums[maxIndex] - nums[j] >= valueDifference:
                return [maxIndex, j]
        return [-1, -1]
```

```Java
class Solution {
    public int[] findIndices(int[] nums, int indexDifference, int valueDifference) {
        int minIndex = 0, maxIndex = 0;
        for (int j = indexDifference; j < nums.length; j++) {
            int i = j - indexDifference;
            if (nums[i] < nums[minIndex]) {
                minIndex = i;
            }
            if (nums[j] - nums[minIndex] >= valueDifference) {
                return new int[]{minIndex, j};
            }
            if (nums[i] > nums[maxIndex]) {
                maxIndex = i;
            }
            if (nums[maxIndex] - nums[j] >= valueDifference) {
                return new int[]{maxIndex, j};
            }
        }
        return new int[]{-1, -1};
    }
}
```

```CSharp
public class Solution {
    public int[] FindIndices(int[] nums, int indexDifference, int valueDifference) {
        int minIndex = 0, maxIndex = 0;
        for (int j = indexDifference; j < nums.Length; j++) {
            int i = j - indexDifference;
            if (nums[i] < nums[minIndex]) {
                minIndex = i;
            }
            if (nums[j] - nums[minIndex] >= valueDifference) {
                return new int[]{minIndex, j};
            }
            if (nums[i] > nums[maxIndex]) {
                maxIndex = i;
            }
            if (nums[maxIndex] - nums[j] >= valueDifference) {
                return new int[]{maxIndex, j};
            }
        }
        return new int[]{-1, -1};
    }
}
```

```C++
class Solution {
public:
    vector<int> findIndices(vector<int>& nums, int indexDifference, int valueDifference) {
        int minIndex = 0, maxIndex = 0;
        for (int j = indexDifference; j < nums.size(); j++) {
            int i = j - indexDifference;
            if (nums[i] < nums[minIndex]) {
                minIndex = i;
            }
            if (nums[j] - nums[minIndex] >= valueDifference) {
                return {minIndex, j};
            }
            if (nums[i] > nums[maxIndex]) {
                maxIndex = i;
            }
            if (nums[maxIndex] - nums[j] >= valueDifference) {
                return {maxIndex, j};
            }
        }
        return {-1, -1};
    }
};
```

```C
int* findIndices(int* nums, int numsSize, int indexDifference, int valueDifference, int* returnSize) {
    *returnSize = 2;
    int *ret = (int *)malloc(sizeof(int) * 2);
    int minIndex = 0, maxIndex = 0;
    for (int j = indexDifference; j < numsSize; j++) {
        int i = j - indexDifference;
        if (nums[i] < nums[minIndex]) {
            minIndex = i;
        }
        if (nums[j] - nums[minIndex] >= valueDifference) {
            ret[0] = minIndex;
            ret[1] = j;
            return ret;
        }
        if (nums[i] > nums[maxIndex]) {
            maxIndex = i;
        }
        if (nums[maxIndex] - nums[j] >= valueDifference) {
            ret[0] = maxIndex;
            ret[1] = j;
            return ret;
        }
    }
    ret[0] = -1;
    ret[1] = -1;
    return ret;
}
```

```Go
func findIndices(nums []int, indexDifference int, valueDifference int) []int {
    minIndex, maxIndex := 0, 0
    for j := indexDifference; j < len(nums); j++ {
        i := j - indexDifference
        if nums[i] < nums[minIndex] {
            minIndex = i
        }
        if nums[j] - nums[minIndex] >= valueDifference {
            return []int{minIndex, j}
        }
        if nums[i] > nums[maxIndex] {
            maxIndex = i
        }
        if nums[maxIndex] - nums[j] >= valueDifference {
            return []int{maxIndex, j}
        }
    }
    return []int{-1, -1}
}
```

```JavaScript
var findIndices = function(nums, indexDifference, valueDifference) {
    let minIndex = 0, maxIndex = 0;
    for (let j = indexDifference; j < nums.length; j++) {
        let i = j - indexDifference;
        if (nums[i] < nums[minIndex]) {
            minIndex = i;
        }
        if (nums[j] - nums[minIndex] >= valueDifference) {
            return [minIndex, j];
        }
        if (nums[i] > nums[maxIndex]) {
            maxIndex = i;
        }
        if (nums[maxIndex] - nums[j] >= valueDifference) {
            return [maxIndex, j];
        }
    }
    return [-1, -1];
};
```

```TypeScript
function findIndices(nums: number[], indexDifference: number, valueDifference: number): number[] {
    let minIndex = 0, maxIndex = 0;
    for (let j = indexDifference; j < nums.length; j++) {
        let i = j - indexDifference;
        if (nums[i] < nums[minIndex]) {
            minIndex = i;
        }
        if (nums[j] - nums[minIndex] >= valueDifference) {
            return [minIndex, j];
        }
        if (nums[i] > nums[maxIndex]) {
            maxIndex = i;
        }
        if (nums[maxIndex] - nums[j] >= valueDifference) {
            return [maxIndex, j];
        }
    }
    return [-1, -1];
};
```

```Rust
impl Solution {
    pub fn find_indices(nums: Vec<i32>, index_difference: i32, value_difference: i32) -> Vec<i32> {
        let mut min_index = 0;
        let mut max_index = 0;
        for j in (index_difference as usize)..nums.len() {
            let i = j - index_difference as usize;
            if nums[i] < nums[min_index] {
                min_index = i;
            }
            if nums[j] - nums[min_index] >= value_difference {
                return vec![min_index as i32, j as i32];
            }
            if nums[i] > nums[max_index] {
                max_index = i;
            }
            if nums[max_index] - nums[j] >= value_difference {
                return vec![max_index as i32, j as i32];
            }
        }
        vec![-1, -1]
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$。
- 空间复杂度：$O(1)$。
