#### [方法二：前缀和](https://leetcode.cn/problems/sum-of-all-odd-length-subarrays/solutions/964878/suo-you-qi-shu-chang-du-zi-shu-zu-de-he-yoaqu/)

方法一中，对于每个子数组需要使用 $O(n)$ 的时间计算子数组的和。如果能将计算每个子数组的和的时间复杂度从 $O(n)$ 降低到 $O(1)$，则能将总时间复杂度从 $O(n^3)$ 降低到 $O(n^2)$。

为了在 $O(1)$ 的时间内得到每个子数组的和，可以使用前缀和。创建长度为 $n + 1$ 的前缀和数组 $prefixSums$，其中 $prefixSums[0] = 0$，当 $1 \le i \le n$ 时，$prefixSums[i]$ 表示数组 $arr$ 从下标 $0$ 到下标 $i - 1$ 的元素和。

得到前缀和数组 $prefixSums$ 之后，对于 $0 \le start \le end < n$，数组 $arr$ 的下标范围 $[start, end]$ 的子数组的和为 $prefixSums[end + 1] - prefixSums[start]$，可以在 $O(1)$ 的时间内得到每个子数组的和。

```java
class Solution {
    public int sumOddLengthSubarrays(int[] arr) {
        int n = arr.length;
        int[] prefixSums = new int[n + 1];
        for (int i = 0; i < n; i++) {
            prefixSums[i + 1] = prefixSums[i] + arr[i];
        }
        int sum = 0;
        for (int start = 0; start < n; start++) {
            for (int length = 1; start + length <= n; length += 2) {
                int end = start + length - 1;
                sum += prefixSums[end + 1] - prefixSums[start];
            }
        }
        return sum;
    }
}
```

```csharp
public class Solution {
    public int SumOddLengthSubarrays(int[] arr) {
        int n = arr.Length;
        int[] prefixSums = new int[n + 1];
        for (int i = 0; i < n; i++) {
            prefixSums[i + 1] = prefixSums[i] + arr[i];
        }
        int sum = 0;
        for (int start = 0; start < n; start++) {
            for (int length = 1; start + length <= n; length += 2) {
                int end = start + length - 1;
                sum += prefixSums[end + 1] - prefixSums[start];
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
        int n = arr.size();
        vector<int> prefixSums(n + 1);
        for (int i = 0; i < n; i++) {
            prefixSums[i + 1] = prefixSums[i] + arr[i];
        }
        int sum = 0;
        for (int start = 0; start < n; start++) {
            for (int length = 1; start + length <= n; length += 2) {
                int end = start + length - 1;
                sum += prefixSums[end + 1] - prefixSums[start];
            }
        }
        return sum;
    }
};
```

```c
int sumOddLengthSubarrays(int* arr, int arrSize) {
    int prefixSums[arrSize + 1];
    prefixSums[0] = 0;
    for (int i = 0; i < arrSize; i++) {
        prefixSums[i + 1] = prefixSums[i] + arr[i];
    }
    int sum = 0;
    for (int start = 0; start < arrSize; start++) {
        for (int length = 1; start + length <= arrSize; length += 2) {
            int end = start + length - 1;
            sum += prefixSums[end + 1] - prefixSums[start];
        }
    }
    return sum;
}
```

```go
func sumOddLengthSubarrays(arr []int) (sum int) {
    n := len(arr)
    prefixSums := make([]int, n+1)
    for i, v := range arr {
        prefixSums[i+1] = prefixSums[i] + v
    }
    for start := range arr {
        for length := 1; start+length <= n; length += 2 {
            end := start + length - 1
            sum += prefixSums[end+1] - prefixSums[start]
        }
    }
    return sum
}
```

```javascript
var sumOddLengthSubarrays = function(arr) {
    const n = arr.length;
    const prefixSums = new Array(n + 1).fill(0);
    for (let i = 0; i < n; i++) {
        prefixSums[i + 1] = prefixSums[i] + arr[i];
    }
    let sum = 0;
    for (let start = 0; start < n; start++) {
        for (let length = 1; start + length <= n; length += 2) {
            const end = start + length - 1;
            sum += prefixSums[end + 1] - prefixSums[start];
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
        prefixSums = [0] * (n + 1)
        for i, v in enumerate(arr):
            prefixSums[i + 1] = prefixSums[i] + v
        for start in range(n):
            length = 1
            while start + length <= n:
                end = start + length - 1
                sum += prefixSums[end + 1] - prefixSums[start]
                length += 2
        return sum
```

**复杂度分析**

-   时间复杂度：$O(n^2)$，其中 $n$ 是数组 $arr$ 的长度。需要 $O(n)$ 的时间计算前缀和数组 $prefixSums$，长度为奇数的子数组的数量是 $O(n^2)$，对于每个子数组需要 $O(1)$ 的时间计算子数组的和，因此总时间复杂度是 $O(n^2)$。
-   空间复杂度：$O(n)$，其中 $n$ 是数组 $arr$ 的长度。需要创建长度为 $n + 1$ 的前缀和数组 $prefixSums$。
