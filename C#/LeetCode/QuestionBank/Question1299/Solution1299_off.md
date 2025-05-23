### [将每个元素替换为右侧最大元素](https://leetcode.cn/problems/replace-elements-with-greatest-element-on-right-side/solutions/101750/jiang-mei-ge-yuan-su-ti-huan-wei-you-ce-zui-da-y-5/)

#### 方法一：逆序遍历

本题等价于对于数组 `arr` 中的每个元素 `arr[i]`，将其替换成 `arr[i + 1], arr[i + 2], ..., arr[n - 1]` 中的最大值。因此我们可以逆序地遍历整个数组，同时维护从数组右端到当前位置所有元素的最大值。

设 `ans[i] = max(arr[i + 1], arr[i + 2], ..., arr[n - 1])`，那么在进行逆序遍历时，我们可以直接通过

```c
ans[i] = max(ans[i + 1], arr[i + 1])
```

来递推地得到答案。

```C++
class Solution {
public:
    vector<int> replaceElements(vector<int>& arr) {
        int n = arr.size();
        vector<int> ans(n);
        ans[n - 1] = -1;
        for (int i = n - 2; i >= 0; --i) {
            ans[i] = max(ans[i + 1], arr[i + 1]);
        }
        return ans;
    }
};
```

```Python
class Solution:
    def replaceElements(self, arr: List[int]) -> List[int]:
        n = len(arr)
        ans = [0] * (n - 1) + [-1]
        for i in range(n - 2, -1, -1):
            ans[i] = max(ans[i + 1], arr[i + 1])
        return ans
```

```Java
class Solution {
    public int[] replaceElements(int[] arr) {
        int n = arr.length;
        int[] ans = new int[n];
        ans[n - 1] = -1;
        for (int i = n - 2; i >= 0; --i) {
            ans[i] = Math.max(ans[i + 1], arr[i + 1]);
        }
        return ans;
    }
}
```

```CSharp
public class Solution {
    public int[] ReplaceElements(int[] arr) {
        int n = arr.Length;
        int[] ans = new int[n];
        ans[n - 1] = -1;
        for (int i = n - 2; i >= 0; --i) {
            ans[i] = Math.Max(ans[i + 1], arr[i + 1]);
        }
        return ans;
    }
}
```

```Go
func replaceElements(arr []int) []int {
    n := len(arr)
    ans := make([]int, n)
    ans[n-1] = -1
    for i := n - 2; i >= 0; i-- {
        ans[i] = max(ans[i + 1], arr[i + 1])
    }
    return ans
}
```

```C
int* replaceElements(int* arr, int arrSize, int* returnSize) {
    int *ans = calloc(arrSize, sizeof(int));
    ans[arrSize - 1] = -1;
    *returnSize = arrSize;
    for (int i = arrSize - 2; i >= 0; --i) {
        ans[i] = (arr[i + 1] > ans[i + 1]) ? arr[i + 1] : ans[i + 1];
    }
    return ans;
}
```

```JavaScript
var replaceElements = function(arr) {
    const n = arr.length;
    const ans = new Array(n);
    ans[n - 1] = -1;
    for (let i = n - 2; i >= 0; i--) {
        ans[i] = Math.max(ans[i + 1], arr[i + 1]);
    }
    return ans;
};
```

```TypeScript
function replaceElements(arr: number[]): number[] {
    const n = arr.length;
    const ans: number[] = new Array(n);
    ans[n - 1] = -1;
    for (let i = n - 2; i >= 0; i--) {
        ans[i] = Math.max(ans[i + 1], arr[i + 1]);
    }
    return ans;
};
```

```Rust
impl Solution {
    pub fn replace_elements(arr: Vec<i32>) -> Vec<i32> {
        let mut ans = vec![0; arr.len()];
        let n = arr.len();
        ans[n - 1] = -1;
        for i in (0..n - 1).rev() {
            ans[i] = ans[i + 1].max(arr[i + 1]);
        }
        ans
    }
}
```

**复杂度分析**

- 时间复杂度：$O(N)$，其中 $N$ 是数组 `arr` 的长度。
- 空间复杂度：$O(1)$，除了存储答案的数组 `ans` 之外，额外的空间复杂度是 $O(1)$。
