### [需要添加的硬币的最小数量](https://leetcode.cn/problems/minimum-number-of-coins-to-be-added/solutions/2578933/xu-yao-tian-jia-de-ying-bi-de-zui-xiao-s-khhi/)

#### 方法一：贪心

为方便处理，首先将数组 $\textit{coins}$ 按升序排序，然后计算需要添加的硬币的最小数量。

对于正整数 $x$，如果区间 $[1,x-1]$ 内的所有金额都可取得，且 $x$ 在数组中，则区间 $[1,2x-1]$ 内的所有金额也都可取得。证明如下。

> 对于任意 $1 \le y<x$，$y$ 可取得，$x$ 在数组中，因此 $y+x$ 也可取得，区间 $[x+1,2x-1]$（即区间 $[1,x-1]$ 内的每个金额加上 $x$ 之后得到的区间）内的所有金额也可取得，由此可得区间 $[1,2x-1]$ 内的所有金额都可取得。

假设金额 $x$ 不可取得，则至少需要在数组中添加一个小于或等于 $x$ 的数，才能取得 $x$，否则无法取得 $x$。

如果区间 $[1,x-1]$ 内的所有金额都可取得，则从贪心的角度考虑，添加 $x$ 之后即可取得 $x$，且满足添加的金额个数最少。在添加 $x$ 之后，区间 $[1,2x-1]$ 内的所有金额都可取得，下一个不可取得的金额一定不会小于 $2x$。

由此可以提出一个贪心的方案。每次找到不可取得的最小的金额 $x$，在数组中添加 $x$，然后寻找下一个不可取得的最小的整数，重复上述步骤直到区间 $[1,\textit{target}]$ 中的所有金额都可取得。

具体实现方面，任何时候都应满足区间 $[1,x-1]$ 内的所有金额都可取得。令 $x$ 的初始值为 $1$，数组下标 $\textit{index}$ 的初始值为 $0$，则初始状态下区间 $[1,x-1]$ 为空区间，满足区间内的所有金额都可取得。进行如下操作。

- 如果 $\textit{index}$ 在数组 $\textit{coins}$ 的下标范围内且 $\textit{coins}[\textit{index}] \le x$，则将 $\textit{coins}[\textit{index}]$ 的值加给 $x$，并将 $\textit{index}$ 的值加 $1$。
    - 可取得的区间从 $[1,x-1]$ 扩展到 $[1,x+\textit{coins}[\textit{index}]-1]$，对 $x$ 的值更新以后，可取得的区间为 $[1,x-1]$。
- 否则，$x$ 没有可取得，因此需要在数组中添加 $x$，然后将 $x$ 的值乘以 $2$。
    - 在数组中添加 $x$ 之后，可取得的区间从 $[1,x-1]$ 扩展到 $[1,2x-1]$，对 $x$ 的值更新以后，可取得的区间为 $[1,x-1]$。
- 重复上述操作，直到 $x$ 的值大于 $\textit{target}$。

由于任何时候都满足区间 $[1,x-1]$ 内的所有金额都可取得，因此上述操作可以保证区间 $[1,\textit{target}]$ 内的所有金额都可取得。

又由于上述操作只在 $x$ 不可取得时才在数组中添加 $x$，如果不添加 $x$ 则 $x$ 无法可取得，因此可以保证添加的金额个数最少。如果减少添加的金额个数，则无法取得区间 $[1,\textit{target}]$ 内的所有金额。

##### 代码

```java
class Solution {
    public int minimumAddedCoins(int[] coins, int target) {
        Arrays.sort(coins);
        int ans = 0;
        int x = 1;
        int length = coins.length, index = 0;
        while (x <= target) {
            if (index < length && coins[index] <= x) {
                x += coins[index];
                index++;
            } else {
                x *= 2;
                ans++;
            }
        }
        return ans;
    }
}
```

```csharp
public class Solution {
    public int MinimumAddedCoins(int[] coins, int target) {
        Array.Sort(coins);
        int ans = 0;
        int x = 1;
        int length = coins.Length, index = 0;
        while (x <= target) {
            if (index < length && coins[index] <= x) {
                x += coins[index];
                index++;
            } else {
                x *= 2;
                ans++;
            }
        }
        return ans;
    }
}
```

```javascript
var minimumAddedCoins = function(coins, target) {
    coins.sort((x, y) => x - y);
    let ans = 0;
    let x = 1;
    const length = coins.length;
    let index = 0;
    while (x <= target) {
        if (index < length && coins[index] <= x) {
            x += coins[index];
            index++;
        } else {
            x *= 2;
            ans++;
        }
    }
    return ans;
};
```

```c++
class Solution {
public:
    int minimumAddedCoins(vector<int>& coins, int target) {
        sort(coins.begin(), coins.end());
        int ans = 0;
        int x = 1;
        int length = coins.size(), index = 0;
        while (x <= target) {
            if (index < length && coins[index] <= x) {
                x += coins[index];
                index++;
            } else {
                x <<= 1;
                ans++;
            }
        }
        return ans;
    }
};
```

```python
class Solution:
    def minimumAddedCoins(self, coins: List[int], target: int) -> int:
        coins.sort()
        ans, x = 0, 1
        length, index = len(coins), 0

        while x <= target:
            if index < length and coins[index] <= x:
                x += coins[index]
                index += 1
            else:
                x <<= 1
                ans += 1
        
        return ans
```

```go
func minimumAddedCoins(coins []int, target int) (ans int) {
    sort.Ints(coins)
    for i, x := 0, 1; x <= target; {
        if i < len(coins) && coins[i] <= x {
            x += coins[i]
            i++
        } else {
            x *= 2
            ans++
        }
    }
    return
}
```

```c
int comp(const void* a, const void* b) {
    return *(int*)a - *(int*)b;
}

int minimumAddedCoins(int* coins, int coinsSize, int target) {
    qsort(coins, coinsSize, sizeof(int), comp);
    int ans = 0;
    int x = 1;
    int index = 0;
    while (x <= target) {
        if (index < coinsSize && coins[index] <= x) {
            x += coins[index];
            index++;
        } else {
            x <<= 1;
            ans++;
        }
    }
    return ans;
}
```

##### 复杂度分析

- 时间复杂度：$O(n \log n+\log \textit{target})$，其中 $n$ 是数组 $\textit{coins}$ 的长度，$\textit{target}$ 是给定的正整数。将数组 $\textit{coins}$ 排序需要 $O(n \log n)$ 的时间，排序后需要遍历数组中的 $n$ 个元素，以及更新 $x$ 的值，由于 $x$ 的值上限为 $\textit{target}$，因此对 $x$ 的值乘以 $2$ 的操作不会超过 $\log \textit{target}$ 次，故时间复杂度是 $O(n+\log \textit{target})$。
- 空间复杂度：$O(\log n)$，其中 $n$ 是数组 $\textit{coins}$ 的长度。主要为排序的递归调用栈空间。
