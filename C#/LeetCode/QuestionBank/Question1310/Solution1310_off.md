### [子数组异或查询](https://leetcode.cn/problems/xor-queries-of-a-subarray/solutions/101717/zi-shu-zu-yi-huo-cha-xun-by-leetcode-solution/?envType=problem-list-v2&envId=tBJHVASZ)

#### 方法一：前缀异或

朴素的想法是，对每个查询，计算数组中的对应下标范围内的元素的异或结果。每个查询的计算时间取决于查询对应的下标范围的长度。如果数组 $arr$ 的长度为 $n$，数组 $queries$ 的长度为 $m$（即有 $m$ 个查询），则最坏情况下每个查询都需要 $O(n)$ 的时间计算结果，总时间复杂度是 $O(nm)$，会超出时间限制，因此必须优化。

由于有 $m$ 个查询，对于每个查询都要计算结果，因此应该优化每个查询的计算时间。理想情况下，每个查询的计算时间应该为 $O(1)$。为了将每个查询的计算时间从 $O(n)$ 优化到 $O(1)$，需要计算数组的前缀异或。

定义长度为 $n+1$ 的数组 $xors$。令 $xors[0]=0$，对于 $0\le i<n$，$xors[i+1]=xors[i]\oplus arr[i]$，其中 $\oplus$ 是异或运算符。当 $1\le i\le n$ 时，$xors[i]$ 为从 $arr[0]$ 到 $arr[i-1]$ 的元素的异或运算结果：

$$xors[i]=arr[0]\oplus \dots \oplus arr[i-1]$$

对于查询 $[left,right](left\le right)$，用 $Q(left,right)$ 表示该查询的结果。

- 当 $left=0$ 时，$Q(left,right)=xors[right+1]$。
- 当 $left>0$ 时，$Q(left,right)$ 的计算如下：
$$\begin{array}{ccl}& & Q(left,right) \\& =&arr[left]\oplus \dots \oplus arr[right] \\& =&(arr[0]\oplus \dots \oplus arr[left-1])\oplus (arr[0]\oplus \dots \oplus arr[left-1])\oplus (arr[left]\oplus \dots \oplus arr[right]) \\& =&(arr[0]\oplus \dots \oplus arr[left-1])\oplus (arr[0]\oplus \dots \oplus arr[right]) \\& =&xors[left]\oplus xors[right+1]\end{array}$$

上述计算用到了异或运算的结合律，以及异或运算的性质 $x\oplus  x=0$。

当 $left=0$ 时，$xors[left]=0$，因此 $Q(left,right)=xors[left]\oplus xors[right+1]$ 也成立。

因此对任意 $0\le left\le right<n$，都有 $Q(left,right)=xors[left]\oplus xors[right+1]$，即可在 $O(1)$ 的时间内完成一个查询的计算。

根据上述分析，这道题可以分两步求解。

1. 计算前缀异或数组 $xors$；
2. 计算每个查询的结果，第 $i$ 个查询的结果为 $xors[queries[i][0]]\oplus xors[queries[i][1]+1]$。

```Java
class Solution {
    public int[] xorQueries(int[] arr, int[][] queries) {
        int n = arr.length;
        int[] xors = new int[n + 1];
        for (int i = 0; i < n; i++) {
            xors[i + 1] = xors[i] ^ arr[i];
        }
        int m = queries.length;
        int[] ans = new int[m];
        for (int i = 0; i < m; i++) {
            ans[i] = xors[queries[i][0]] ^ xors[queries[i][1] + 1];
        }
        return ans;
    }
}\oplus 
```

```CSharp
public class Solution {
    public int[] XorQueries(int[] arr, int[][] queries) {
        int n = arr.Length;
        int[] xors = new int[n + 1];
        for (int i = 0; i < n; i++) {
            xors[i + 1] = xors[i] ^ arr[i];
        }
        int m = queries.Length;
        int[] ans = new int[m];
        for (int i = 0; i < m; i++) {
            ans[i] = xors[queries[i][0]] ^ xors[queries[i][1] + 1];
        }
        return ans;
    }
}\oplus 
```

```JavaScript
var xorQueries = function(arr, queries) {
    const n = arr.length;
    const xors = new Array(n + 1).fill(0);
    for (let i = 0; i < n; i++) {
        xors[i + 1] = xors[i] ^ arr[i];
    }
    const m = queries.length;
    const ans = new Array(m).fill(0);
    for (let i = 0; i < m; i++) {
        ans[i] = xors[queries[i][0]] ^ xors[queries[i][1] + 1];
    }
    return ans;
};\oplus 
```

```Go
func xorQueries(arr []int, queries [][]int) []int {
    xors := make([]int, len(arr)+1)
    for i, v := range arr {
        xors[i+1] = xors[i] ^ v
    }
    ans := make([]int, len(queries))
    for i, q := range queries {
        ans[i] = xors[q[0]] ^ xors[q[1]+1]
    }
    return ans
}\oplus 
```

```C++
class Solution {
public:
    vector<int> xorQueries(vector<int>& arr, vector<vector<int>>& queries) {
        int n = arr.size();
        vector<int> xors(n + 1);
        for (int i = 0; i < n; i++) {
            xors[i + 1] = xors[i] ^ arr[i];
        }
        int m = queries.size();
        vector<int> ans(m);
        for (int i = 0; i < m; i++) {
            ans[i] = xors[queries[i][0]] ^ xors[queries[i][1] + 1];
        }
        return ans;
    }
};\oplus 
```

```C
int* xorQueries(int* arr, int arrSize, int** queries, int queriesSize, int* queriesColSize, int* returnSize) {
    int n = arrSize;
    int xors[n + 1];
    xors[0] = 0;
    for (int i = 0; i < n; i++) {
        xors[i + 1] = xors[i] ^ arr[i];
    }
    int m = queriesSize;
    int* ans = malloc(sizeof(int) * m);
    *returnSize = m;
    for (int i = 0; i < m; i++) {
        ans[i] = xors[queries[i][0]] ^ xors[queries[i][1] + 1];
    }
    return ans;
}\oplus 
```

```Python
class Solution:
    def xorQueries(self, arr: List[int], queries: List[List[int]]) -> List[int]:
        xors = [0]
        for num in arr:
            xors.append(xors[-1] ^ num)
        
        ans = list()
        for left, right in queries:
            ans.append(xors[left] ^ xors[right + 1])
        
        return ans
```

**复杂度分析**

- 时间复杂度：$O(n+m)$，其中 $n$ 是数组 $arr$ 的长度，$m$ 是数组 $queries$ 的长度。需要遍历数组 $arr$ 一次，计算前缀异或数组的每个元素值，然后对每个查询分别使用 $O(1)$ 的时间计算查询结果。
- 空间复杂度：$O(n)$，其中 $n$ 是数组 $arr$ 的长度。需要创建长度为 $n+1$ 的前缀异或数组，注意返回值不计入空间复杂度。
