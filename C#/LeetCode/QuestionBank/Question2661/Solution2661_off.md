### [找到叠涂元素](https://leetcode.cn/problems/first-completely-painted-row-or-column/solutions/2546583/zhao-dao-die-tu-yuan-su-by-leetcode-solu-8pz6/)

#### 方法一：哈希表

**思路与算法**

由于矩阵 $mat$ 中每一个元素都不同，并且都在数组 $arr$ 中，所以首先我们用一个哈希表来存储 $mat$ 中每一个元素的位置信息（即行列信息）。然后用一个长度为 $n$ 的数组 $rowCnt$ 来表示每一行中已经被涂色的个数，用一个长度为 $m$ 的数组 $colCnt$ 来表示每一列中已经被涂色的个数，其中若出现某一行 $i$ 有 $rowCnt[i] = m$ 或者某一列 $j$ 有 $colCnt[j] = n$，则表示第 $i$ 行或 $j$ 列已被全部涂色。

接着我们遍历数组 $arr$，对于遍历到的 $arr[i]$，从哈希表中得到该元素的行列信息，并更新数组 $rowCnt$ 和 $colCnt$，如果出现某一行或某一列被全部涂色，则返回该元素的下标 $i$。

**代码**

```c++
class Solution {
public:
    int firstCompleteIndex(vector<int>& arr, vector<vector<int>>& mat) {
        int n = mat.size();
        int m = mat[0].size();
        unordered_map<int, pair<int, int>> mp;
        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < m; ++j) {
                mp[mat[i][j]] = {i, j};
            }
        }
        vector<int> rowCnt(n, 0);
        vector<int> colCnt(m, 0);
        for (int i = 0; i < arr.size(); ++i) {
            auto& v = mp[arr[i]];
            ++rowCnt[v.first];
            if (rowCnt[v.first] == m) {
                return i;
            }
            ++colCnt[v.second];
            if (colCnt[v.second] == n) {
                return i;
            }
        }
        return -1;
    }
};
```

```java
class Solution {
    public int firstCompleteIndex(int[] arr, int[][] mat) {
        int n = mat.length;
        int m = mat[0].length;
        Map<Integer, int[]> map = new HashMap<Integer, int[]>();
        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < m; ++j) {
                map.put(mat[i][j], new int[]{i, j});
            }
        }
        int[] rowCnt = new int[n];
        int[] colCnt = new int[m];
        for (int i = 0; i < arr.length; ++i) {
            int[] v = map.get(arr[i]);
            ++rowCnt[v[0]];
            if (rowCnt[v[0]] == m) {
                return i;
            }
            ++colCnt[v[1]];
            if (colCnt[v[1]] == n) {
                return i;
            }
        }
        return -1;
    }
}
```

```csharp
public class Solution {
    public int FirstCompleteIndex(int[] arr, int[][] mat) {
        int n = mat.Length;
        int m = mat[0].Length;
        IDictionary<int, Tuple<int, int>> dictionary = new Dictionary<int, Tuple<int, int>>();
        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < m; ++j) {
                dictionary.Add(mat[i][j], new Tuple<int, int>(i, j));
            }
        }
        int[] rowCnt = new int[n];
        int[] colCnt = new int[m];
        for (int i = 0; i < arr.Length; ++i) {
            Tuple<int, int> v = dictionary[arr[i]];
            ++rowCnt[v.Item1];
            if (rowCnt[v.Item1] == m) {
                return i;
            }
            ++colCnt[v.Item2];
            if (colCnt[v.Item2] == n) {
                return i;
            }
        }
        return -1;
    }
}
```

```go
func firstCompleteIndex(arr []int, mat [][]int) int {
    n, m := len(mat), len(mat[0])
    mp := make(map[int][2]int)
    for i := 0; i < n; i++ {
        for j := 0; j < m; j++ {
            mp[mat[i][j]] = [2]int{i, j}
        }
    }
    rowCnt, colCnt := make([]int, n), make([]int, m)
    for i := 0; i < n; i++ {
        rowCnt[i] = 0
    }
    for j := 0; j < m; j++ {
        colCnt[j] = 0
    }
    for i := 0; i < len(arr); i++ {
        v := mp[arr[i]]
        rowCnt[v[0]]++
        if rowCnt[v[0]] == m {
            return i
        }
        colCnt[v[1]]++
        if colCnt[v[1]] == n {
            return i
        }
    }
    return -1
}
```

```python
class Solution:
    def firstCompleteIndex(self, arr: List[int], mat: List[List[int]]) -> int:
        n, m = len(mat), len(mat[0])
        mp = {}
        for i in range(n):
            for j in range(m):
                mp[mat[i][j]] = [i, j]
        rowCnt, colCnt = [0] * n, [0] * m
        for i in range(len(arr)):
            v = mp[arr[i]]
            rowCnt[v[0]] += 1
            if rowCnt[v[0]] == m:
                return i
            colCnt[v[1]] += 1
            if colCnt[v[1]] == n:
                return i
        return -1
```

```c
int firstCompleteIndex(int* arr, int arrSize, int** mat, int matSize, int* matColSize){
    int n = matSize, m = matColSize[0];
    int mp[m * n + 1][2];
    for (int i = 0; i < n; i++) {
        for (int j = 0; j < m; j++) {
            mp[mat[i][j]][0] = i;
            mp[mat[i][j]][1] = j;
        }
    }
    int rowCnt[n], colCnt[m];
    memset(rowCnt, 0, sizeof(int) * n);
    memset(colCnt, 0, sizeof(int) * m);
    for (int i = 0; i < arrSize; i++) {
        int *v = mp[arr[i]];
        rowCnt[v[0]]++;
        if (rowCnt[v[0]] == m) {
            return i;
        }
        colCnt[v[1]]++;
        if (colCnt[v[1]] == n) {
            return i;
        }
    }
    return -1;
}
```

```javascript
var firstCompleteIndex = function(arr, mat) {
    let n = mat.length, m = mat[0].length;
    let mp = new Map();
    for (let i = 0; i < n; i++) {
        for (let j = 0; j < m; j++) {
            mp.set(mat[i][j], [i, j]);
        }
    }
    let rowCnt = new Array(n).fill(0);
    let colCnt = new Array(m).fill(0);
    for (let i = 0; i < arr.length; i++) {
        let v = mp.get(arr[i]);
        rowCnt[v[0]]++;
        if (rowCnt[v[0]] == m) {
            return i;
        }
        colCnt[v[1]]++;
        if (colCnt[v[1]] == n) {
            return i;
        }
    }
    return -1;
};
```

**复杂度分析**

-   时间复杂度：$O(n \times m)$，其中 $n$ 和 $m$ 分别为矩阵 $mat$ 的行数和列数。
-   空间复杂度：$O(n \times m)$，其中 $n$ 和 $m$ 分别为矩阵 $mat$ 的行数和列数，主要为用哈希表存储矩阵 $mat$ 中每一个元素对应行列序号的空间开销。
