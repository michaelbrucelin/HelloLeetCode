### [排序数组中两个数字之和](https://leetcode.cn/problems/kLl5u1/solutions/1398898/pai-xu-shu-zu-zhong-liang-ge-shu-zi-zhi-8tv13/)

#### 方法一：二分查找
在数组中找到两个数，使得它们的和等于目标值，可以首先固定第一个数，然后寻找第二个数，第二个数等于目标值减去第一个数的差。利用数组的有序性质，可以通过二分查找的方法寻找第二个数。为了避免重复寻找，在寻找第二个数时，只在第一个数的右侧寻找。

##### 代码

```java
class Solution {
    public int[] twoSum(int[] numbers, int target) {
        for (int i = 0; i < numbers.length; ++i) {
            int low = i + 1, high = numbers.length - 1;
            while (low <= high) {
                int mid = (high - low) / 2 + low;
                if (numbers[mid] == target - numbers[i]) {
                    return new int[]{i, mid};
                } else if (numbers[mid] > target - numbers[i]) {
                    high = mid - 1;
                } else {
                    low = mid + 1;
                }
            }
        }
        return new int[]{-1, -1};
    }
}
```

```c++
class Solution {
public:
    vector<int> twoSum(vector<int>& numbers, int target) {
        for (int i = 0; i < numbers.size(); ++i) {
            int low = i + 1, high = numbers.size() - 1;
            while (low <= high) {
                int mid = (high - low) / 2 + low;
                if (numbers[mid] == target - numbers[i]) {
                    return {i, mid};
                } else if (numbers[mid] > target - numbers[i]) {
                    high = mid - 1;
                } else {
                    low = mid + 1;
                }
            }
        }
        return {-1, -1};
    }
};
```

```python
class Solution:
    def twoSum(self, numbers: List[int], target: int) -> List[int]:
        n = len(numbers)
        for i in range(n):
            low, high = i + 1, n - 1
            while low <= high:
                mid = (low + high) // 2
                if numbers[mid] == target - numbers[i]:
                    return [i, mid]
                elif numbers[mid] > target - numbers[i]:
                    high = mid - 1
                else:
                    low = mid + 1
        
        return [-1, -1]
```

```go
func twoSum(numbers []int, target int) []int {
    for i := 0; i < len(numbers); i++ {
        low, high := i + 1, len(numbers) - 1
        for low <= high {
            mid := (high - low) / 2 + low
            if numbers[mid] == target - numbers[i] {
                return []int{i, mid}
            } else if numbers[mid] > target - numbers[i] {
                high = mid - 1
            } else {
                low = mid + 1
            }
        }
    }
    return []int{-1, -1}
}
```

```c
int* twoSum(int* numbers, int numbersSize, int target, int* returnSize) {
    int* ret = (int*)malloc(sizeof(int) * 2);
    *returnSize = 2;

    for (int i = 0; i < numbersSize; ++i) {
        int low = i + 1, high = numbersSize - 1;
        while (low <= high) {
            int mid = (high - low) / 2 + low;
            if (numbers[mid] == target - numbers[i]) {
                ret[0] = i, ret[1] = mid;
                return ret;
            } else if (numbers[mid] > target - numbers[i]) {
                high = mid - 1;
            } else {
                low = mid + 1;
            }
        }
    }
    ret[0] = -1, ret[1] = -1;
    return ret;
}
```

##### 复杂度分析

- 时间复杂度：$O(n \log n)$，其中 $n$ 是数组的长度。需要遍历数组一次确定第一个数，时间复杂度是 $O(n)$，寻找第二个数使用二分查找，时间复杂度是 $O(\log n)$，因此总时间复杂度是 $O(n \log n)$。
- 空间复杂度：$O(1)$。

#### 方法二：双指针

初始时两个指针分别指向第一个元素位置和最后一个元素的位置。每次计算两个指针指向的两个元素之和，并和目标值比较。如果两个元素之和等于目标值，则发现了唯一解。如果两个元素之和小于目标值，则将左侧指针右移一位。如果两个元素之和大于目标值，则将右侧指针左移一位。移动指针之后，重复上述操作，直到找到答案。

使用双指针的实质是缩小查找范围。那么会不会把可能的解过滤掉？答案是不会。假设 $\textit{numbers}[i]+\textit{numbers}[j]=\textit{target}$ 是唯一解，其中 $0 \leq i<j \leq \textit{numbers}.\textit{length}-1$。初始时两个指针分别指向下标 $0$ 和下标 $\textit{numbers}.\textit{length}-1$，左指针指向的下标小于或等于 $i$，右指针指向的下标大于或等于 $j$。除非初始时左指针和右指针已经位于下标 $i$ 和 $j$，否则一定是左指针先到达下标 $i$ 的位置或者右指针先到达下标 $j$ 的位置。

如果左指针先到达下标 $i$ 的位置，此时右指针还在下标 $j$ 的右侧，$\textit{sum}>\textit{target}$，因此一定是右指针左移，左指针不可能移到 $i$ 的右侧。

如果右指针先到达下标 $j$ 的位置，此时左指针还在下标 $i$ 的左侧，$\textit{sum}<\textit{target}$，因此一定是左指针右移，右指针不可能移到 $j$ 的左侧。

由此可见，在整个移动过程中，左指针不可能移到 $i$ 的右侧，右指针不可能移到 $j$ 的左侧，因此不会把可能的解过滤掉。由于题目确保有唯一的答案，因此使用双指针一定可以找到答案。

##### 代码

```java
class Solution {
    public int[] twoSum(int[] numbers, int target) {
        int low = 0, high = numbers.length - 1;
        while (low < high) {
            int sum = numbers[low] + numbers[high];
            if (sum == target) {
                return new int[]{low, high};
            } else if (sum < target) {
                ++low;
            } else {
                --high;
            }
        }
        return new int[]{-1, -1};
    }
}
```

```c++
class Solution {
public:
    vector<int> twoSum(vector<int>& numbers, int target) {
        int low = 0, high = numbers.size() - 1;
        while (low < high) {
            int sum = numbers[low] + numbers[high];
            if (sum == target) {
                return {low, high};
            } else if (sum < target) {
                ++low;
            } else {
                --high;
            }
        }
        return {-1, -1};
    }
};
```

```python
class Solution:
    def twoSum(self, numbers: List[int], target: int) -> List[int]:
        low, high = 0, len(numbers) - 1
        while low < high:
            total = numbers[low] + numbers[high]
            if total == target:
                return [low, high]
            elif total < target:
                low += 1
            else:
                high -= 1

        return [-1, -1]
```

```go
func twoSum(numbers []int, target int) []int {
    low, high := 0, len(numbers) - 1
    for low < high {
        sum := numbers[low] + numbers[high]
        if sum == target {
            return []int{low, high}
        } else if sum < target {
            low++
        } else {
            high--
        }
    }
    return []int{-1, -1}
}
```

```c
int* twoSum(int* numbers, int numbersSize, int target, int* returnSize) {
    int* ret = (int*)malloc(sizeof(int) * 2);
    *returnSize = 2;

    int low = 0, high = numbersSize - 1;
    while (low < high) {
        int sum = numbers[low] + numbers[high];
        if (sum == target) {
            ret[0] = low, ret[1] = high;
            return ret;
        } else if (sum < target) {
            ++low;
        } else {
            --high;
        }
    }
    ret[0] = -1, ret[1] = -1;
    return ret;
}
```

##### 复杂度分析

- 时间复杂度：$O(n)$，其中 $n$ 是数组的长度。两个指针移动的总次数最多为 $n$ 次。
- 空间复杂度：$O(1)$。
