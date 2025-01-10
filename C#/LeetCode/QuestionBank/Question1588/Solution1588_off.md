### [所有奇数长度子数组的和](https://leetcode.cn/problems/sum-of-all-odd-length-subarrays/solutions/964878/suo-you-qi-shu-chang-du-zi-shu-zu-de-he-yoaqu/)

#### 方法一：暴力

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

- 时间复杂度：$O(n^3)$，其中 $n$ 是数组 $arr$ 的长度。长度为奇数的子数组的数量是 $O(n^2)$，对于每个子数组需要 $O(n)$ 的时间计算子数组的和，因此总时间复杂度是 $O(n^3)$。
- 空间复杂度：$O(1)$。

#### 方法二：前缀和

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

- 时间复杂度：$O(n^2)$，其中 $n$ 是数组 $arr$ 的长度。需要 $O(n)$ 的时间计算前缀和数组 $prefixSums$，长度为奇数的子数组的数量是 $O(n^2)$，对于每个子数组需要 $O(1)$ 的时间计算子数组的和，因此总时间复杂度是 $O(n^2)$。
- 空间复杂度：$O(n)$，其中 $n$ 是数组 $arr$ 的长度。需要创建长度为 $n + 1$ 的前缀和数组 $prefixSums$。

#### 方法三：数学

方法一和方法二都是通过计算每个子数组的和得到所有奇数长度子数组的和。可以换一种思路，数组中的每个元素都会在一个或多个奇数长度的子数组中出现，如果可以计算出每个元素在多少个长度为奇数的子数组中出现，即可得到所有奇数长度子数组的和。

对于元素 $arr[i]$，记其左边和右边的元素个数分别为 $leftCount$ 和 $rightCount$，则 $leftCount = i$，$rightCount = n - i - 1$。如果元素 $arr[i]$ 在一个长度为奇数的子数组中，则在该子数组中，元素 $arr[i]$ 的左边和右边的元素个数一定同为奇数或同为偶数（注意 $0$ 也是偶数）。

- 当元素 $arr[i]$ 的左边和右边的元素个数同为奇数时，在区间 $[0, leftCount]$ 范围内的奇数有 $leftOdd = \Big\lfloor \dfrac{leftCount + 1}{2} \Big\rfloor$ 个，在区间 $[0, rightCount]$ 范围内的奇数有 $rightOdd = \Big\lfloor \dfrac{rightCount + 1}{2} \Big\rfloor$ 个，包含元素 $arr[i]$ 的子数组个数为 $leftOdd \times rightOdd$；
- 当元素 $arr[i]$ 的左边和右边的元素个数同为偶数时，在区间 $[0, leftCount]$ 范围内的偶数有 $leftEven = \Big\lfloor \dfrac{leftCount}{2} \Big\rfloor + 1$ 个，在区间 $[0, rightCount]$ 范围内的偶数有 $rightEven = \Big\lfloor \dfrac{rightCount}{2} \Big\rfloor + 1$ 个，包含元素 $arr[i]$ 的子数组个数为 $leftEven \times rightEven$。

根据上述分析可知，包含元素 $arr[i]$ 的奇数长度子数组个数为 $leftOdd \times rightOdd + leftEven \times rightEven$，因此元素 $arr[i]$ 对奇数长度子数组元素和的贡献为 $arr[i] \times (leftOdd \times rightOdd + leftEven \times rightEven)$。

```java
class Solution {
    public int sumOddLengthSubarrays(int[] arr) {
        int sum = 0;
        int n = arr.length;
        for (int i = 0; i < n; i++) {
            int leftCount = i, rightCount = n - i - 1;
            int leftOdd = (leftCount + 1) / 2;
            int rightOdd = (rightCount + 1) / 2;
            int leftEven = leftCount / 2 + 1;
            int rightEven = rightCount / 2 + 1;
            sum += arr[i] * (leftOdd * rightOdd + leftEven * rightEven);
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
        for (int i = 0; i < n; i++) {
            int leftCount = i, rightCount = n - i - 1;
            int leftOdd = (leftCount + 1) / 2;
            int rightOdd = (rightCount + 1) / 2;
            int leftEven = leftCount / 2 + 1;
            int rightEven = rightCount / 2 + 1;
            sum += arr[i] * (leftOdd * rightOdd + leftEven * rightEven);
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
        for (int i = 0; i < n; i++) {
            int leftCount = i, rightCount = n - i - 1;
            int leftOdd = (leftCount + 1) / 2;
            int rightOdd = (rightCount + 1) / 2;
            int leftEven = leftCount / 2 + 1;
            int rightEven = rightCount / 2 + 1;
            sum += arr[i] * (leftOdd * rightOdd + leftEven * rightEven);
        }
        return sum;
    }
};
```

```c
int sumOddLengthSubarrays(int* arr, int arrSize) {
    int sum = 0;
    for (int i = 0; i < arrSize; i++) {
        int leftCount = i, rightCount = arrSize - i - 1;
        int leftOdd = (leftCount + 1) / 2;
        int rightOdd = (rightCount + 1) / 2;
        int leftEven = leftCount / 2 + 1;
        int rightEven = rightCount / 2 + 1;
        sum += arr[i] * (leftOdd * rightOdd + leftEven * rightEven);
    }
    return sum;
}
```

```go
func sumOddLengthSubarrays(arr []int) (sum int) {
    n := len(arr)
    for i, v := range arr {
        leftCount, rightCount := i, n-i-1
        leftOdd := (leftCount + 1) / 2
        rightOdd := (rightCount + 1) / 2
        leftEven := leftCount/2 + 1
        rightEven := rightCount/2 + 1
        sum += v * (leftOdd*rightOdd + leftEven*rightEven)
    }
    return sum
}
```

```javascript
var sumOddLengthSubarrays = function(arr) {
    let sum = 0;
    const n = arr.length;
    for (let i = 0; i < n; i++) {
        const leftCount = i, rightCount = n - i - 1;
        const leftOdd = Math.floor((leftCount + 1) / 2);
        const rightOdd = Math.floor((rightCount + 1) / 2);
        const leftEven = Math.floor(leftCount / 2) + 1;
        const rightEven = Math.floor(rightCount / 2) + 1;
        sum += arr[i] * (leftOdd * rightOdd + leftEven * rightEven);
    }
    return sum;
};
```

```python
class Solution:
    def sumOddLengthSubarrays(self, arr: List[int]) -> int:
        sum = 0
        n = len(arr)
        for i, v in enumerate(arr):
            leftCount, rightCount = i, n - i - 1
            leftOdd = (leftCount + 1) // 2
            rightOdd = (rightCount + 1) // 2
            leftEven = leftCount // 2 + 1
            rightEven = rightCount // 2 + 1
            sum += v * (leftOdd * rightOdd + leftEven * rightEven)
        return sum
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是数组 $arr$ 的长度。需要遍历数组 $arr$ 一次，对于每个元素，需要 $O(1)$ 的时间计算该元素在奇数长度子数组的和中的贡献值，因此总时间复杂度是 $O(n)$。
- 空间复杂度：$O(1)$。
