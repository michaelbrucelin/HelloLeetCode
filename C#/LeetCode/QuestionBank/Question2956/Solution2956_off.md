### [找到两个数组中的公共元素](https://leetcode.cn/problems/find-common-elements-between-two-arrays/solutions/2840766/zhao-dao-liang-ge-shu-zu-zhong-de-gong-g-iqb7/)

#### 方法一：遍历

第一个数组的计算过程：遍历整数数组 $nums_1$ ，记当前遍历的下标为 $i$，在整数数组 $nums_2$ 中遍历查找 $nums_1[i]$，如果出现，则将下标 $i$ 统计到答案中。

第二个数组的计算过程类似，最后返回两个数组为结果。

```C++
class Solution {
public:
    vector<int> findIntersectionValues(vector<int>& nums1, vector<int>& nums2) {
        vector<int> res(2);
        for (int i = 0; i < nums1.size(); i++) {
            for (int j = 0; j < nums2.size(); j++) {
                if (nums1[i] == nums2[j]) {
                    res[0]++;
                    break;
                }
            }
        }
        for (int i = 0; i < nums2.size(); i++) {
            for (int j = 0; j < nums1.size(); j++) {
                if (nums2[i] == nums1[j]) {
                    res[1]++;
                    break;
                }
            }
        }
        return res;
    }
};
```

```Go
func findIntersectionValues(nums1 []int, nums2 []int) []int {
    res := make([]int, 2)
    for _, x1 := range nums1 {
        for _, x2 := range nums2 {
            if x1 == x2 {
                res[0]++
                break
            }
        }
    }
    for _, x2 := range nums2 {
        for _, x1 := range nums1 {
            if x2 == x1 {
                res[1]++
                break
            }
        }
    }
    return res
}
```

```Python
class Solution:
    def findIntersectionValues(self, nums1: List[int], nums2: List[int]) -> List[int]:
        return [sum(x in nums2 for x in nums1), sum(x in nums1 for x in nums2)]
```

```C
int* findIntersectionValues(int* nums1, int nums1Size, int* nums2, int nums2Size, int* returnSize) {
    int *ret = malloc(sizeof(int) * 2);
    memset(ret, 0, sizeof(int) * 2);
    for (int i = 0; i < nums1Size; i++) {
        for (int j = 0; j < nums2Size; j++) {
            if (nums1[i] == nums2[j]) {
                ret[0]++;
                break;
            }
        }
    }
    for (int i = 0; i < nums2Size; i++) {
        for (int j = 0; j < nums1Size; j++) {
            if (nums2[i] == nums1[j]) {
                ret[1]++;
                break;
            }
        }
    }
    *returnSize = 2;
    return ret;
}
```

```Java
class Solution {
    public int[] findIntersectionValues(int[] nums1, int[] nums2) {
        int[] res = new int[2];
        for (int x1 : nums1) {
            for (int x2 : nums2) {
                if (x1 == x2) {
                    res[0]++;
                    break;
                }
            }
        }
        for (int x2 : nums2) {
            for (int x1 : nums1) {
                if (x2 == x1) {
                    res[1]++;
                    break;
                }
            }
        }
        return res;
    }
}
```

```CSharp
public class Solution {
    public int[] FindIntersectionValues(int[] nums1, int[] nums2) {
        int[] res = new int[2];
        foreach (int x1 in nums1) {
            foreach (int x2 in nums2) {
                if (x1 == x2) {
                    res[0]++;
                    break;
                }
            }
        }
        foreach (int x2 in nums2) {
            foreach (int x1 in nums1) {
                if (x2 == x1) {
                    res[1]++;
                    break;
                }
            }
        }
        return res;
    }
}
```

```JavaScript
var findIntersectionValues = function(nums1, nums2) {
    let res = new Array(2).fill(0);
    for (let i = 0; i < nums1.length; i++) {
        for (let j = 0; j < nums2.length; j++) {
            if (nums1[i] == nums2[j]) {
                res[0]++;
                break;
            }
        }
    }
    for (let i = 0; i < nums2.length; i++) {
        for (let j = 0; j < nums1.length; j++) {
            if (nums2[i] == nums1[j]) {
                res[1]++;
                break;
            }
        }
    }
    return res;
};
```

```TypeScript
function findIntersectionValues(nums1: number[], nums2: number[]): number[] {
    let res = new Array(2).fill(0);
    for (let i = 0; i < nums1.length; i++) {
        for (let j = 0; j < nums2.length; j++) {
            if (nums1[i] == nums2[j]) {
                res[0]++;
                break;
            }
        }
    }
    for (let i = 0; i < nums2.length; i++) {
        for (let j = 0; j < nums1.length; j++) {
            if (nums2[i] == nums1[j]) {
                res[1]++;
                break;
            }
        }
    }
    return res;
};
```

```Rust
use std::collections::HashSet;
impl Solution {
    pub fn find_intersection_values(nums1: Vec<i32>, nums2: Vec<i32>) -> Vec<i32> {
        let mut res1 = 0;
        let mut res2 = 0;
        for x1 in nums1.iter() {
            for x2 in nums2.iter() {
                if x1 == x2 {
                    res1 += 1;
                    break;
                }
            }
        }
        for x2 in nums2.iter() {
            for x1 in nums1.iter() {
                if x2 == x1 {
                    res2 += 1;
                    break;
                }
            }
        }
        [res1, res2].to_vec()
    }
}
```

**复杂度分析**

- 时间复杂度：$O(mn)$，其中 $m$ 和 $n$ 分别为 $nums_1$ 和 $nums_2$ 的长度。
- 空间复杂度：$O(1)$。

#### 方法二：哈希表

分别将 $nums_1$ 和 $nums_2$ 的元素放到哈希表 $s1$ 和 $s2$ 中。统计 $nums_1$ 在哈希表 $s2$ 中的元素数目和 $nums_2$ 在哈希表 $s1$ 中的元素数目，返回结果。

```C++
class Solution {
public:
    vector<int> findIntersectionValues(vector<int>& nums1, vector<int>& nums2) {
        unordered_set<int> s1(nums1.begin(), nums1.end()), s2(nums2.begin(), nums2.end());
        vector<int> res(2);
        for (int x : nums1) {
            if (s2.count(x)) {
                res[0]++;
            }
        }
        for (int x : nums2) {
            if (s1.count(x)) {
                res[1]++;
            }
        }
        return res;
    }
};
```

```Go
func findIntersectionValues(nums1 []int, nums2 []int) []int {
    s1, s2 := map[int]bool{}, map[int]bool{}
    for _, x := range nums1 {
        s1[x] = true
    }
    for _, x := range nums2 {
        s2[x] = true
    }
    res := make([]int, 2)
    for _, x := range nums1 {
        if s2[x] {
            res[0]++
        }
    }
    for _, x := range nums2 {
        if s1[x] {
            res[1]++
        }
    }
    return res
}
```

```Python
class Solution:
    def findIntersectionValues(self, nums1: List[int], nums2: List[int]) -> List[int]:
        s1, s2 = set(nums1), set(nums2)
        return [sum(x in s2 for x in nums1), sum(x in s1 for x in nums2)]
```

```C
int* findIntersectionValues(int* nums1, int nums1Size, int* nums2, int nums2Size, int* returnSize) {
    int s1[101] = {0}, s2[101] = {0};
    for (int i = 0; i < nums1Size; i++) {
        s1[nums1[i]] = 1;
    }
    for (int i = 0; i < nums2Size; i++) {
        s2[nums2[i]] = 1;
    }
    int *ret = malloc(sizeof(int) * 2);
    memset(ret, 0, sizeof(int) * 2);
    for (int i = 0; i < nums1Size; i++) {
        ret[0] += s2[nums1[i]];
    }
    for (int i = 0; i < nums2Size; i++) {
        ret[1] += s1[nums2[i]];
    }
    *returnSize = 2;
    return ret;
}
```

```Java
class Solution {
    public int[] findIntersectionValues(int[] nums1, int[] nums2) {
        HashSet<Integer> s1 = new HashSet<>();
        for (int x : nums1) {
            s1.add(x);
        }
        HashSet<Integer> s2 = new HashSet<>();
        for (int x : nums2) {
            s2.add(x);
        }

        int[] res = new int[2];
        for (int x : nums1) {
            if (s2.contains(x)) {
                res[0]++;
            }
        }
        for (int x : nums2) {
            if (s1.contains(x)) {
                res[1]++;
            }
        }
        return res;
    }
}
```

```CSharp
public class Solution {
    public int[] FindIntersectionValues(int[] nums1, int[] nums2) {
        HashSet<int> s1 = new HashSet<int>();
        foreach (int x in nums1) {
            s1.Add(x);
        }
        HashSet<int> s2 = new HashSet<int>();
        foreach (int x in nums2) {
            s2.Add(x);
        }

        int[] res = new int[2];
        foreach (int x in nums1) {
            if (s2.Contains(x)) {
                res[0]++;
            }
        }
        foreach (int x in nums2) {
            if (s1.Contains(x)) {
                res[1]++;
            }
        }
        return res;
    }
}
```

```JavaScript
var findIntersectionValues = function(nums1, nums2) {
    let s1 = new Set(nums1);
    let s2 = new Set(nums2);

    let res = new Array(2).fill(0);
    for (let i = 0; i < nums1.length; i++) {
        if (s2.has(nums1[i])) {
            res[0]++;
        }
    }
    for (let i = 0; i < nums2.length; i++) {
        if (s1.has(nums2[i])) {
            res[1]++;
        }
    }
    return res;
};
```

```TypeScript
function findIntersectionValues(nums1: number[], nums2: number[]): number[] {
    let s1 = new Set(nums1);
    let s2 = new Set(nums2);

    let res = new Array(2).fill(0);
    for (let i = 0; i < nums1.length; i++) {
        if (s2.has(nums1[i])) {
            res[0]++;
        }
    }
    for (let i = 0; i < nums2.length; i++) {
        if (s1.has(nums2[i])) {
            res[1]++;
        }
    }
    return res;
};
```

```Rust
use std::collections::HashSet;
impl Solution {
    pub fn find_intersection_values(nums1: Vec<i32>, nums2: Vec<i32>) -> Vec<i32> {
        let mut s1 = HashSet::new();
        let mut s2 = HashSet::new();
        for x in nums1.iter() {
            s1.insert(x);
        }
        for x in nums2.iter() {
            s2.insert(x);   
        }
        let mut res1 = 0;
        let mut res2 = 0;
        for x in nums1.iter() {
            if s2.contains(x) {
                res1 += 1;
            }
        }
        for x in nums2.iter() {
            if s1.contains(x) {
                res2 += 1;
            }
        }
        [res1, res2].to_vec()
    }
}
```

**复杂度分析**

- 时间复杂度：$O(m+n)$，其中 $m$ 和 $n$ 分别为 $nums_1$ 和  $nums_2$的长度。
- 空间复杂度：$O(m+n)$。
