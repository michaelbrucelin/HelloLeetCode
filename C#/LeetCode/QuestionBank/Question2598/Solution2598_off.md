### [执行操作后的最大 MEX](https://leetcode.cn/problems/smallest-missing-non-negative-integer-after-operations/solutions/3801016/zhi-xing-cao-zuo-hou-de-zui-da-mex-by-le-dvbj/)

#### 方法一：贪心

**思路与算法**

为了方便描述，令 $k=value$。一个整数 $x$ 经过若干次操作后可以变成 $\dots ,x-m\times k,x-(m-1)\times k,\dots ,x+(m-1)\times k,x+m\times k,\dots$ 中的某个整数。因此我们可以将 $nums$ 种数字按照对 $k$ 取余后的结果进行分组，同组内的数字可以变成的数字集合都是相同的。

我们希望最大化数组的 $MEX$，因此可以从 $0$ 开始遍历直到无法用剩余数字变成当前数字即可得到答案。若当前数字为 $mex$，那么查看余数集合 $mex(modk)$ 是否为空，若为空则 $mex$ 就是答案，否则将该余数集合元素个数减 $1$，并且令 $mex$ 增加 $1$。

**代码**

```C++
class Solution {
public:
    int findSmallestInteger(vector<int>& nums, int value) {
        vector<int> mp(value);
        for (auto &x : nums) {
            int v = (x % value + value) % value;
            mp[v]++;
        }
        int mex = 0;
        while (mp[mex % value] > 0) {
            mp[mex % value]--;
            mex++;
        }
        return mex;
    }
};
```

```Python
class Solution:
    def findSmallestInteger(self, nums: List[int], value: int) -> int:
        mp = Counter(x % value for x in nums)
        mex = 0
        while mp[mex % value] > 0:
            mp[mex % value] -= 1
            mex += 1
        return mex
```

```Rust
impl Solution {
    pub fn find_smallest_integer(nums: Vec<i32>, value: i32) -> i32 {
        let mut mp = vec![0; value as usize];
        nums.iter().for_each(|&x| mp[((x % value + value) % value) as usize] += 1);
        let mut mex = 0;
        while mp[(mex % value) as usize] > 0 {
            mp[(mex % value) as usize] -= 1;
            mex += 1;
        }
        mex
    }
}
```

```Java
class Solution {
    public int findSmallestInteger(int[] nums, int value) {
        int[] mp = new int[value];
        for (int x : nums) {
            int v = ((x % value) + value) % value;
            mp[v]++;
        }
        int mex = 0;
        while (mp[mex % value] > 0) {
            mp[mex % value]--;
            mex++;
        }
        return mex;
    }
}
```

```CSharp
public class Solution {
    public int FindSmallestInteger(int[] nums, int value) {
        int[] mp = new int[value];
        foreach (int x in nums) {
            int v = ((x % value) + value) % value;
            mp[v]++;
        }
        int mex = 0;
        while (mp[mex % value] > 0) {
            mp[mex % value]--;
            mex++;
        }
        return mex;
    }
}
```

```Go
func findSmallestInteger(nums []int, value int) int {
    mp := make([]int, value)
    for _, x := range nums {
        v := ((x % value) + value) % value
        mp[v]++
    }
    mex := 0
    for mp[mex % value] > 0 {
        mp[mex % value]--
        mex++
    }
    return mex
}
```

```C
int findSmallestInteger(int* nums, int numsSize, int value) {
    int mp[value];
    memset(mp, 0, sizeof(mp));
    for (int i = 0; i < numsSize; i++) {
        int x = nums[i];
        int v = (x % value + value) % value;
        mp[v]++;
    }
    int mex = 0;
    while (mp[mex % value] > 0) {
        mp[mex % value]--;
        mex++;
    }
    return mex;
}
```

```JavaScript
var findSmallestInteger = function(nums, value) {
    const mp = new Array(value).fill(0);
    for (let x of nums) {
        const v = ((x % value) + value) % value;
        mp[v]++;
    }
    let mex = 0;
    while (mp[mex % value] > 0) {
        mp[mex % value]--;
        mex++;
    }
    return mex;
};
```

```TypeScript
impl Solution {
    pub fn find_smallest_integer(nums: Vec<i32>, value: i32) -> i32 {
        let mut mp = vec![0; value as usize];
        for &x in &nums {
            let v = ((x % value) + value) % value;
            mp[v as usize] += 1;
        }
        let mut mex = 0;
        while mp[(mex % value) as usize] > 0 {
            mp[(mex % value) as usize] -= 1;
            mex += 1;
        }
        mex
    }
}
```

**复杂度分析**

- 时间复杂度：$O(n)$，其中 $n$ 是 $nums$ 的长度。
- 空间复杂度：$O(value)$。我们需要一个大小为 $value$ 的数组 $mp$ 来记录每种余数的出现次数。
