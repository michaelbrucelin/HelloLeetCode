#### [方法一：暴力](https://leetcode.cn/problems/sum-of-all-odd-length-subarrays/solutions/964878/suo-you-qi-shu-chang-du-zi-shu-zu-de-he-yoaqu/)

最简单的方法是遍历数组 $arr$ 中的每个长度为奇数的子数组，计算这些子数组的和。由于只需要计算所有长度为奇数的子数组的和，不需要分别计算每个子数组的和，因此只需要维护一个变量 $sum$ 存储总和即可。

实现方面，令数组 $arr$ 的长度为 $n$，子数组的开始下标为 $start$，长度为 $length$，结束下标为 $end$，则有 $0 \le start \le end < n$，$length = end - start + 1$ 为奇数。遍历符合上述条件的子数组，计算所有长度为奇数的子数组的和。

```java
class Solution {
    public int sumOddLengthSubarrays(int[] arr) {
        int sum = 0;
        int n = arr.length;
        for (int start = 0; start < n; start++) {
            for (int length = 1; start + length <= n; length += 2) {
                int end = start + length - 1;
                for (int i = start; i <= end; i++) {
                    sum += arr[i];
                }
            }
        }
        return sum;
    }
}
```

```csharp
public class Solution {
    public int SumOddLengthSubarrays(int[] arr) {
        int sum = 0;
        int n = arr.Length;
        for (int start = 0; start < n; start++) {
            for (int length = 1; start + length <= n; length += 2) {
                int end = start + length - 1;
                for (int i = start; i <= end; i++) {
                    sum += arr[i];
                }
            }
        }
        return sum;
    }
}
```

```cpp
class Solution {
public:
    int sumOddLengthSubarrays(vector<int>& arr) {
        int sum = 0;
        int n = arr.size();
        for (int start = 0; start < n; start++) {
            for (int length = 1; start + length <= n; length += 2) {
                int end = start + length - 1;
                for (int i = start; i <= end; i++) {
                    sum += arr[i];
                }
            }
        }
        return sum;
    }
};
```

```c
int sumOddLengthSubarrays(int* arr, int arrSize) {
    int sum = 0;
    for (int start = 0; start < arrSize; start++) {
        for (int length = 1; start + length <= arrSize; length += 2) {
            int end = start + length - 1;
            for (int i = start; i <= end; i++) {
                sum += arr[i];
            }
        }
    }
    return sum;
}
```

```go
func sumOddLengthSubarrays(arr []int) (sum int) {
    n := len(arr)
    for start := range arr {
        for length := 1; start+length <= n; length += 2 {
            for _, v := range arr[start : start+length] {
                sum += v
            }
        }
    }
    return sum
}
```

```javascript
var sumOddLengthSubarrays = function(arr) {
    let sum = 0;
    const n = arr.length;
    for (let start = 0; start < n; start++) {
        for (let length = 1; start + length <= n; length += 2) {
            const end = start + length - 1;
            for (let i = start; i <= end; i++) {
                sum += arr[i];
            }
        }
    }
    return sum;
};
```

```python
class Solution:
    def sumOddLengthSubarrays(self, arr: List[int]) -> int:
        sum = 0
        n = len(arr)
        for start in range(n):
            length = 1
            while start + length <= n:
                for v in arr[start:start + length]:
                    sum += v
                length += 2
        return sum
```

**复杂度分析**

-   时间复杂度：$O(n^3)$，其中 $n$ 是数组 $arr$ 的长度。长度为奇数的子数组的数量是 $O(n^2)$，对于每个子数组需要 $O(n)$ 的时间计算子数组的和，因此总时间复杂度是 $O(n^3)$。
-   空间复杂度：$O(1)$。
