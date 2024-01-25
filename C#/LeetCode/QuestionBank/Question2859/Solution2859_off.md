### [计算 K 置位下标对应元素的和](https://leetcode.cn/problems/sum-of-values-at-indices-with-k-set-bits/solutions/2614602/ji-suan-k-zhi-wei-xia-biao-dui-ying-yuan-axzr/)

#### 方法一：枚举所有的下标

##### 思路与算法

对于给定长度为 $n$ 的数组 $nums$，我们在 $[0, n)$ 的范围内枚举每一个下标 $i$。如果 $i$ 有 $k$ 个置位，就将 $nums[i]$ 加入答案。

为了计算 $i$ 的置位个数，我们可以使用十进制转二进制的方法，每次通过 $i \bmod 2$ 得到最低的二进制位，在通过 $\lfloor i / 2 \rfloor$ 去掉最低的二进制位（其中 $\lfloor \cdot \rfloor$ 表示向下取整），不断进行该操作直到 $i = 0$ 为止。

##### 代码

```c++
class Solution {
public:
    int sumIndicesWithKSetBits(vector<int>& nums, int k) {
        auto bitCount = [](int x) {
            int cnt = 0;
            while (x) {
                cnt += (x % 2);
                x /= 2;
            }
            return cnt;
        };

        int ans = 0;
        for (int i = 0; i < nums.size(); ++i) {
            if (bitCount(i) == k) {
                ans += nums[i];
            }
        }
        return ans;
    }
};
```

```java
class Solution {
    public int sumIndicesWithKSetBits(List<Integer> nums, int k) {
        int ans = 0;
        for (int i = 0; i < nums.size(); ++i) {
            if (bitCount(i) == k) {
                ans += nums.get(i);
            }
        }
        return ans;
    }

    public int bitCount(int x) {
        int cnt = 0;
        while (x != 0) {
            cnt += (x % 2);
            x /= 2;
        }
        return cnt;
    }
}
```

```csharp
public class Solution {
    public int SumIndicesWithKSetBits(IList<int> nums, int k) {
        int ans = 0;
        for (int i = 0; i < nums.Count; ++i) {
            if (BitCount(i) == k) {
                ans += nums[i];
            }
        }
        return ans;
    }

    public int BitCount(int x) {
        int cnt = 0;
        while (x != 0) {
            cnt += (x % 2);
            x /= 2;
        }
        return cnt;
    }
}
```

```python
class Solution:
    def sumIndicesWithKSetBits(self, nums: List[int], k: int) -> int:
        def bitCount(x: int) -> int:
            cnt = 0
            while x:
                cnt += (x % 2)
                x //= 2
            return cnt
        
        ans = 0
        for i, num in enumerate(nums):
            if bitCount(i) == k:
                ans += num
        return ans
```

```c
int bitCount(int x) {
    int cnt = 0;
    while (x) {
        cnt += (x % 2);
        x /= 2;
    }
    return cnt;
};

int sumIndicesWithKSetBits(int* nums, int numsSize, int k) {
    int ans = 0;
    for (int i = 0; i < numsSize; ++i) {
        if (bitCount(i) == k) {
            ans += nums[i];
        }
    }
    return ans;
}
```

```go
func sumIndicesWithKSetBits(nums []int, k int) int {
    ans := 0
    for i := 0; i < len(nums); i++ {
        if bitCount(i) == k {
            ans += nums[i]
        }
    }
    return ans
}

func bitCount(x int) int {
    cnt := 0
    for x != 0 {
        cnt += (x % 2)
        x /= 2
    }
    return cnt
}
```

```javascript
var sumIndicesWithKSetBits = function(nums, k) {
    const bitCount = (x) => {
        let cnt = 0;
        while (x) {
            cnt += (x % 2);
            x >>= 1;
        }
        return cnt;
    }

    let ans = 0;
    for (let i = 0; i < nums.length; ++i) {
        if (bitCount(i) == k) {
            ans += nums[i];
        }
    }
    return ans;
};
```

```typescript
function sumIndicesWithKSetBits(nums: number[], k: number): number {
    const bitCount = (x: number): number => {
        let cnt = 0;
        while (x) {
            cnt += (x % 2);
            x >>= 1;
        }
        return cnt;
    };

    let ans = 0;
    for (let i = 0; i < nums.length; ++i) {
        if (bitCount(i) === k) {
            ans += nums[i];
        }
    }
    return ans;
};
```

#### 复杂度分析

- 时间复杂度：$O(n \log n)$，其中 $n$ 是数组 $nums$ 的长度。对于每个下标，我们需要 $O(\log n)$ 的时间计算它的置位个数。
- 空间复杂度：$O(1)$。

#### 方法二：对计算置位个数进行优化

##### 思路与算法

我们可以对计算置位个数的代码进行优化。

在本题中，下标的最大值为 $10^3 - 1$，它对应的二进制数有 $10$ 位，我们用 $(\texttt{abcdefghij})_2$ 来表示。本质上，我们希望快速得到：

$$a+b+c+d+e+f+g+h+i+j \tag{1}$$

的值。我们可以使用分治的思想，进行如下的三步操作：

- 第一步将 $(\texttt{abcdefghij})_2$ 拆分成两个二进制数 $(\texttt{0a0c0e0g0i})_2$ 与 $(\texttt{0b0d0f0h0j})_2$。我们将它们直接相加，由于 $0+0$ 一定不会产生进位，因此我们两位两位地看这个加法操作，它们之间是相互不会影响的，例如 $(\texttt{0a})_2 + (\texttt{0b})_2$，得到的结果实际上就是 $a+b$ 对应的二进制数。这样一来，加法操作得到的新数 $(\texttt{abcdefghij})_2$，其中：
$$\overline{ab} + \overline{cd} + \overline{ef} + \overline{gh} + \overline{ij} \tag{2}$$
的值与 $(1)$ 式是相同的，这里 $\overline{ab}$ 表示将 $ab$ 看成一个两位的二进制数，计算其十进制的值。
- 第二步是类似的，将新的 $(\texttt{abcdefghij})_2$ 拆分成两个二进制数 $(\texttt{ab00ef00ij})_2$ 与 $(\texttt{00cd00gh})_2$，并直接相加。我们四位四位地看这个加法操作，它们之间是相互不会影响的。这样一来，加法操作得到的新数 $(\texttt{abcdefghij})_2$，其中：
$$\overline{ab} + \overline{cdef} + \overline{ghij} \tag{3}$$
的值与 $(1)$ 式是相同的。
- 第三步时，我们只剩下三个部分，因此无需继续分治，直接计算 $(3)$ 式的值即可。

在编写代码时，我们需要使用位运算。三步操作分别对应着：

- 通过 $\texttt{x \& 0101010101}$ 得到 $(\texttt{0a0c0e0g0i})_2$，以及 $\texttt{(x \& 1010101010) >> 1}$ 得到 $(\texttt{0b0d0f0h0j})_2$。
- 通过 $\texttt{x \& 1100110011}$ 得到 $(\texttt{ab00ef00ij})_2$，以及 $\texttt{(x \& 0011001100) >> 2}$ 得到 $(\texttt{00cd00gh})_2$。
- 通过 $\texttt{x >> 8}$ 得到 $(\texttt{ab})_2$，以及 $\texttt{(x >> 4) \& 1111}$ 得到 $(\texttt{cdef})_2$，以及 $\texttt{x \& 1111}$ 得到 $(\texttt{ghij})_2$。

##### 代码

```c++
class Solution {
public:
    int sumIndicesWithKSetBits(vector<int>& nums, int k) {
        auto bitCount = [](int x) {
            x = (x & 0b0101010101) + ((x & 0b1010101010) >> 1);
            x = ((x & 0b0011001100) >> 2) + (x & 0b1100110011);
            x = (x >> 8) + ((x >> 4) & 0b1111) + (x & 0b1111);
            return x;
        };

        int ans = 0;
        for (int i = 0; i < nums.size(); ++i) {
            if (bitCount(i) == k) {
                ans += nums[i];
            }
        }
        return ans;
    }
};
```

```java
class Solution {
    public int sumIndicesWithKSetBits(List<Integer> nums, int k) {
        int ans = 0;
        for (int i = 0; i < nums.size(); ++i) {
            if (bitCount(i) == k) {
                ans += nums.get(i);
            }
        }
        return ans;
    }

    public int bitCount(int x) {
        x = (x & 0b0101010101) + ((x & 0b1010101010) >> 1);
        x = ((x & 0b0011001100) >> 2) + (x & 0b1100110011);
        x = (x >> 8) + ((x >> 4) & 0b1111) + (x & 0b1111);
        return x;
    }
}
```

```csharp
public class Solution {
    public int SumIndicesWithKSetBits(IList<int> nums, int k) {
        int ans = 0;
        for (int i = 0; i < nums.Count; ++i) {
            if (BitCount(i) == k) {
                ans += nums[i];
            }
        }
        return ans;
    }

    public int BitCount(int x) {
        x = (x & 0b0101010101) + ((x & 0b1010101010) >> 1);
        x = ((x & 0b0011001100) >> 2) + (x & 0b1100110011);
        x = (x >> 8) + ((x >> 4) & 0b1111) + (x & 0b1111);
        return x;
    }
}
```

```python
class Solution:
    def sumIndicesWithKSetBits(self, nums: List[int], k: int) -> int:
        def bitCount(x: int) -> int:
            x = (x & 0b0101010101) + ((x & 0b1010101010) >> 1)
            x = ((x & 0b0011001100) >> 2) + (x & 0b1100110011)
            x = (x >> 8) + ((x >> 4) & 0b1111) + (x & 0b1111)
            return x
        
        ans = 0
        for i, num in enumerate(nums):
            if bitCount(i) == k:
                ans += num
        return ans
```

```c
int bitCount(int x) {
    x = (x & 0b0101010101) + ((x & 0b1010101010) >> 1);
    x = ((x & 0b0011001100) >> 2) + (x & 0b1100110011);
    x = (x >> 8) + ((x >> 4) & 0b1111) + (x & 0b1111);
    return x;
};

int sumIndicesWithKSetBits(int* nums, int numsSize, int k) {
    int ans = 0;
    for (int i = 0; i < numsSize; ++i) {
        if (bitCount(i) == k) {
            ans += nums[i];
        }
    }
    return ans;
}
```

```go
func sumIndicesWithKSetBits(nums []int, k int) int {
    ans := 0
    for i := 0; i < len(nums); i++ {
        if bitCount(i) == k {
            ans += nums[i]
        }
    }
    return ans
}

func bitCount(x int) int {
    x = (x & 0b0101010101) + ((x & 0b1010101010) >> 1)
    x = ((x & 0b0011001100) >> 2) + (x & 0b1100110011)
    x = (x >> 8) + ((x >> 4) & 0b1111) + (x & 0b1111)
    return x
}
```

```javascript
var sumIndicesWithKSetBits = function(nums, k) {
    const bitCount = (x) => {
        x = (x & 0b0101010101) + ((x & 0b1010101010) >> 1);
        x = ((x & 0b0011001100) >> 2) + (x & 0b1100110011);
        x = (x >> 8) + ((x >> 4) & 0b1111) + (x & 0b1111);
        return x;
    }

    let ans = 0;
    for (let i = 0; i < nums.length; ++i) {
        if (bitCount(i) == k) {
            ans += nums[i];
        }
    }
    return ans;
};
```

```typescript
function sumIndicesWithKSetBits(nums: number[], k: number): number {
    const bitCount = (x: number): number => {
        x = (x & 0b0101010101) + ((x & 0b1010101010) >> 1);
        x = ((x & 0b0011001100) >> 2) + (x & 0b1100110011);
        x = (x >> 8) + ((x >> 4) & 0b1111) + (x & 0b1111);
        return x;
    };

    let ans = 0;
    for (let i = 0; i < nums.length; ++i) {
        if (bitCount(i) === k) {
            ans += nums[i];
        }
    }
    return ans;
};
```

#### 复杂度分析

- 时间复杂度：$O(n \log\log C)$，其中 $n$ 是数组 $nums$ 的长度，$C$ 是数组 $nums$ 的最大长度。上述的分治算法在第 $p~(p \geq 0)$ 步时，会将每连续 $2^p$ 的二进制位看成一个整体进行相加。$C$ 有 $O(\log C)$ 个二进制位，因此分治需要 $O(\log\log C)$ 次。
- 空间复杂度：$O(1)$。
