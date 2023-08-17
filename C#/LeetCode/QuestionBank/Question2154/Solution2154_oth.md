### [巧妙利用位运算优化空间复杂度：从 O(n) 到 O(log C) 到 O(1)](https://leetcode.cn/problems/keep-multiplying-found-values-by-two/solutions/1239409/ha-xi-biao-mo-ni-by-endlesscheng-ipk3/)

#### 方法一：用哈希表记录 $nums$ 的每个元素

用哈希表记录 $nums$ 的每个元素，然后不断将 $original$ 乘 $2$ 直至其不在哈希表中。

```go
func findFinalValue(nums []int, original int) int {
    has := map[int]bool{}
    for _, num := range nums {
        has[num] = true
    }
    for has[original] {
        original *= 2
    }
    return original
}
```

```cpp
class Solution {
public:
    int findFinalValue(vector<int> &nums, int original) {
        unordered_set<int> s(nums.begin(), nums.end());
        while (s.count(original)) original *= 2;
        return original;
    }
};
```

-   时间复杂度：$O(n+\log\dfrac{\max(nums)}{original})$，其中 $n$ 为 $nums$ 的长度（下同）。
-   空间复杂度：$O(n)$。

#### 方法二：用哈希表记录 $original$ 的所有可能值

我们还可以反过来，用哈希表记录 $original$ 可能出现的值，将其标记为 $1$。然后遍历 $nums$ 的每个元素，将标记为 $1$ 的值标记为 $2$。最后不断将 $original$ 乘 $2$ 直至其标记值不为 $2$。

```go
func findFinalValue(nums []int, original int) int {
    state := map[int]int8{}
    for x := original; x <= 1000; x *= 2 {
        state[x] = 1
    }
    for _, num := range nums {
        if state[num] == 1 {
            state[num] = 2
        }
    }
    for state[original] == 2 {
        original *= 2
    }
    return original
}
```

```cpp
class Solution {
public:
    int findFinalValue(vector<int> &nums, int original) {
        unordered_map<int, int> state;
        for (int x = original; x <= 1000; x *= 2) state[x] = 1;
        for (int num : nums) if (state.count(num)) state[num] = 2;
        while (state[original] == 2) original *= 2;
        return original;
    }
};
```

-   时间复杂度：$O(n+\log\dfrac{C}{original})$，这里 $C=1000$。
-   空间复杂度：$O(\log C)$，或者更准确地说是 $O(\log\dfrac{C}{original})$。

#### 方法三：位运算

注意到我们要找的是 $original$ 的 $2$ 的幂次倍数，因此可以用一个二进制数 $mask$ 记录 $nums$ 中含有哪些 $original$ 的 $2$ 幂次倍数。

遍历完 $nums$ 后，我们可以模拟题目的过程，即从 $mask$ 的最低位开始，找连续的 $2$ 的幂次倍数，即连续的 $1$ 的个数。这可以通过位运算 $O(1)$ 地计算出来：将 $mask$ 取反后，找最低位的 $1$，其对应的二进制数 $lowbit$ 即为我们可以达到的最大 $2$ 的幂次倍数。

```go
func findFinalValue(nums []int, original int) int {
    mask := 0
    for _, num := range nums {
        if num%original == 0 {
            k := num / original // 倍数
            if k&(k-1) == 0 { // 倍数是 2 的幂次
                mask |= k
            }
        }
    }
    mask = ^mask // 取反后，找最低位的 1（lowbit = mask & -mask）
    return original * (mask & -mask)
}
```

```cpp
class Solution {
public:
    int findFinalValue(vector<int> &nums, int original) {
        int mask = 0;
        for (int num : nums) {
            if (num % original == 0) {
                int k = num / original; // 倍数
                if ((k & (k - 1)) == 0) { // 倍数是 2 的幂次
                    mask |= k;
                }
            }
        }
        mask = ~mask; // 取反后，找最低位的 1（lowbit = mask & -mask）
        return original * (mask & -mask);
    }
};
```

-   时间复杂度：$O(n)$。
-   空间复杂度：$O(1)$。仅需要几个额外的变量。
