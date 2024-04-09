### [螺旋遍历二维数组](https://leetcode.cn/problems/shun-shi-zhen-da-yin-ju-zhen-lcof/solutions/275394/shun-shi-zhen-da-yin-ju-zhen-by-leetcode-solution/)

#### 方法一：模拟

可以模拟打印二维数组的路径。初始位置是二维数组的左上角，初始方向是向右，当路径超出界限或者进入之前访问过的位置时，顺时针旋转，进入下一个方向。

判断路径是否进入之前访问过的位置需要使用一个与输入二维数组大小相同的辅助二维数组 $\textit{visited}$，其中的每个元素表示该位置是否被访问过。当一个元素被访问时，将 $\textit{visited}$ 中的对应位置的元素设为已访问。

如何判断路径是否结束？由于二维数组中的每个元素都被访问一次，因此路径的长度即为二维数组中的元素数量，当路径的长度达到二维数组中的元素数量时即为完整路径，将该路径返回。

##### 代码

```java
class Solution {
    public int[] spiralArray(int[][] array) {
        if (array == null || array.length == 0 || array[0].length == 0) {
            return new int[0];
        }
        int rows = array.length, columns = array[0].length;
        boolean[][] visited = new boolean[rows][columns];
        int total = rows * columns;
        int[] order = new int[total];
        int row = 0, column = 0;
        int[][] directions = {{0, 1}, {1, 0}, {0, -1}, {-1, 0}};
        int directionIndex = 0;
        for (int i = 0; i < total; i++) {
            order[i] = array[row][column];
            visited[row][column] = true;
            int nextRow = row + directions[directionIndex][0], nextColumn = column + directions[directionIndex][1];
            if (nextRow < 0 || nextRow >= rows || nextColumn < 0 || nextColumn >= columns || visited[nextRow][nextColumn]) {
                directionIndex = (directionIndex + 1) % 4;
            }
            row += directions[directionIndex][0];
            column += directions[directionIndex][1];
        }
        return order;
    }
}
```

```c++
class Solution {
private:
    static constexpr int directions[4][2] = {{0, 1}, {1, 0}, {0, -1}, {-1, 0}};
public:
    vector<int> spiralArray(vector<vector<int>>& array) {
        if (array.size() == 0 || array[0].size() == 0) {
            return {};
        }
        
        int rows = array.size(), columns = array[0].size();
        vector<vector<bool>> visited(rows, vector<bool>(columns));
        int total = rows * columns;
        vector<int> order(total);

        int row = 0, column = 0;
        int directionIndex = 0;
        for (int i = 0; i < total; i++) {
            order[i] = array[row][column];
            visited[row][column] = true;
            int nextRow = row + directions[directionIndex][0], nextColumn = column + directions[directionIndex][1];
            if (nextRow < 0 || nextRow >= rows || nextColumn < 0 || nextColumn >= columns || visited[nextRow][nextColumn]) {
                directionIndex = (directionIndex + 1) % 4;
            }
            row += directions[directionIndex][0];
            column += directions[directionIndex][1];
        }
        return order;
    }
};
```

```python
class Solution:
    def spiralArray(self, array: List[List[int]]) -> List[int]:
        if not array or not array[0]:
            return list()
        
        rows, columns = len(array), len(array[0])
        visited = [[False] * columns for _ in range(rows)]
        total = rows * columns
        order = [0] * total

        directions = [[0, 1], [1, 0], [0, -1], [-1, 0]]
        row, column = 0, 0
        directionIndex = 0
        for i in range(total):
            order[i] = array[row][column]
            visited[row][column] = True
            nextRow, nextColumn = row + directions[directionIndex][0], column + directions[directionIndex][1]
            if not (0 <= nextRow < rows and 0 <= nextColumn < columns and not visited[nextRow][nextColumn]):
                directionIndex = (directionIndex + 1) % 4
            row += directions[directionIndex][0]
            column += directions[directionIndex][1]
        return order
```

```go
func spiralArray(array [][]int) []int {
    if len(array) == 0 || len(array[0]) == 0 {
        return []int{}
    }
    rows, columns := len(array), len(array[0])
    visited := make([][]bool, rows)
    for i := 0; i < rows; i++ {
        visited[i] = make([]bool, columns)
    }

    var (
        total = rows * columns
        order = make([]int, total)
        row, column = 0, 0
        directions = [][]int{[]int{0, 1}, []int{1, 0}, []int{0, -1}, []int{-1, 0}}
        directionIndex = 0
    )

    for i := 0; i < total; i++ {
        order[i] = array[row][column]
        visited[row][column] = true
        nextRow, nextColumn := row + directions[directionIndex][0], column + directions[directionIndex][1]
        if nextRow < 0 || nextRow >= rows || nextColumn < 0 || nextColumn >= columns || visited[nextRow][nextColumn] {
            directionIndex = (directionIndex + 1) % 4
        }
        row += directions[directionIndex][0]
        column += directions[directionIndex][1]
    }
    return order
}
```

```javascript
var spiralArray = function(array) {
    if (!array.length || !array[0].length) {
        return [];
    }
    const rows = array.length, columns = array[0].length;
    const visited = new Array(rows).fill(0).map(() => new Array(columns).fill(false));
    const total = rows * columns;
    const order = new Array(total).fill(0);

    let directionIndex = 0, row = 0, column = 0;
    const directions = [[0, 1], [1, 0], [0, -1], [-1, 0]];
    for (let i = 0; i < total; i++) { 
        order[i] = array[row][column];
        visited[row][column] = true;
        const nextRow = row + directions[directionIndex][0], nextColumn = column + directions[directionIndex][1];
        if (!(0 <= nextRow && nextRow < rows && 0 <= nextColumn && nextColumn < columns && !(visited[nextRow][nextColumn]))) {
            directionIndex = (directionIndex + 1) % 4;
        }
        row += directions[directionIndex][0];
        column += directions[directionIndex][1];
    }
    return order;
};
```

```c
int directions[4][2] = {{0, 1}, {1, 0}, {0, -1}, {-1, 0}};

int* spiralArray(int** array, int arraySize, int* arrayColSize, int* returnSize) {
    if (arraySize == 0 || arrayColSize[0] == 0) {
        *returnSize = 0;
        return NULL;
    }

    int rows = arraySize, columns = arrayColSize[0];
    int visited[rows][columns];
    memset(visited, 0, sizeof(visited));
    int total = rows * columns;
    int* order = malloc(sizeof(int) * total);
    *returnSize = total;

    int row = 0, column = 0;
    int directionIndex = 0;
    for (int i = 0; i < total; i++) {
        order[i] = array[row][column];
        visited[row][column] = true;
        int nextRow = row + directions[directionIndex][0], nextColumn = column + directions[directionIndex][1];
        if (nextRow < 0 || nextRow >= rows || nextColumn < 0 || nextColumn >= columns || visited[nextRow][nextColumn]) {
            directionIndex = (directionIndex + 1) % 4;
        }
        row += directions[directionIndex][0];
        column += directions[directionIndex][1];
    }
    return order;
}
```

##### 复杂度分析

- 时间复杂度：$O(mn)$，其中 $m$ 和 $n$ 分别是输入二维数组的行数和列数。二维数组中的每个元素都要被访问一次。
- 空间复杂度：$O(mn)$。需要创建一个大小为 $m \times n$ 的二维数组 $\textit{visited}$ 记录每个位置是否被访问过。

#### 方法二：按层模拟

可以将二维数组看成若干层，首先打印最外层的元素，其次打印次外层的元素，直到打印最内层的元素。

定义二维数组的第 $k$ 层是到最近边界距离为 $k$ 的所有顶点。例如，下图二维数组最外层元素都是第 $1$ 层，次外层元素都是第 $2$ 层，剩下的元素都是第 $3$ 层。

```c
[[1, 1, 1, 1, 1, 1, 1],
 [1, 2, 2, 2, 2, 2, 1],
 [1, 2, 3, 3, 3, 2, 1],
 [1, 2, 2, 2, 2, 2, 1],
 [1, 1, 1, 1, 1, 1, 1]]
```

对于每层，从左上方开始以顺时针的顺序遍历所有元素。假设当前层的左上角位于 $(\textit{top}, \textit{left})$，右下角位于 $(\textit{bottom}, \textit{right})$，按照如下顺序遍历当前层的元素。

1. 从左到右遍历上侧元素，依次为 $(\textit{top}, \textit{left})$ 到 $(\textit{top}, \textit{right})$。
2. 从上到下遍历右侧元素，依次为 $(\textit{top} + 1, \textit{right})$ 到 $(\textit{bottom}, \textit{right})$。
3. 如果 $\textit{left} < \textit{right}$ 且 $\textit{top} < \textit{bottom}$，则从右到左遍历下侧元素，依次为 $(\textit{bottom}, \textit{right} - 1)$ 到 $(\textit{bottom}, \textit{left} + 1)$，以及从下到上遍历左侧元素，依次为 $(\textit{bottom}, \textit{left})$ 到 $(\textit{top} + 1, \textit{left})$。

遍历完当前层的元素之后，将 $\textit{left}$ 和 $\textit{top}$ 分别增加 $1$，将 $\textit{right}$ 和 $\textit{bottom}$ 分别减少 $1$，进入下一层继续遍历，直到遍历完所有元素为止。

![](./assets/img/Solution0146_off.png)

##### 代码

```java
class Solution {
    public int[] spiralArray(int[][] array) {
        if (array == null || array.length == 0 || array[0].length == 0) {
            return new int[0];
        }
        int rows = array.length, columns = array[0].length;
        int[] order = new int[rows * columns];
        int index = 0;
        int left = 0, right = columns - 1, top = 0, bottom = rows - 1;
        while (left <= right && top <= bottom) {
            for (int column = left; column <= right; column++) {
                order[index++] = array[top][column];
            }
            for (int row = top + 1; row <= bottom; row++) {
                order[index++] = array[row][right];
            }
            if (left < right && top < bottom) {
                for (int column = right - 1; column > left; column--) {
                    order[index++] = array[bottom][column];
                }
                for (int row = bottom; row > top; row--) {
                    order[index++] = array[row][left];
                }
            }
            left++;
            right--;
            top++;
            bottom--;
        }
        return order;
    }
}
```

```c++
class Solution {
public:
    vector<int> spiralArray(vector<vector<int>>& array) {
        if (array.size() == 0 || array[0].size() == 0) {
            return {};
        }

        int rows = array.size(), columns = array[0].size();
        vector<int> order;
        int left = 0, right = columns - 1, top = 0, bottom = rows - 1;
        while (left <= right && top <= bottom) {
            for (int column = left; column <= right; column++) {
                order.push_back(array[top][column]);
            }
            for (int row = top + 1; row <= bottom; row++) {
                order.push_back(array[row][right]);
            }
            if (left < right && top < bottom) {
                for (int column = right - 1; column > left; column--) {
                    order.push_back(array[bottom][column]);
                }
                for (int row = bottom; row > top; row--) {
                    order.push_back(array[row][left]);
                }
            }
            left++;
            right--;
            top++;
            bottom--;
        }
        return order;
    }
};
```

```python
class Solution:
    def spiralArray(self, array: List[List[int]]) -> List[int]:
        if not array or not array[0]:
            return list()
        
        rows, columns = len(array), len(array[0])
        order = list()
        left, right, top, bottom = 0, columns - 1, 0, rows - 1
        while left <= right and top <= bottom:
            for column in range(left, right + 1):
                order.append(array[top][column])
            for row in range(top + 1, bottom + 1):
                order.append(array[row][right])
            if left < right and top < bottom:
                for column in range(right - 1, left, -1):
                    order.append(array[bottom][column])
                for row in range(bottom, top, -1):
                    order.append(array[row][left])
            left, right, top, bottom = left + 1, right - 1, top + 1, bottom - 1
        return order
```

```go
func spiralArray(array [][]int) []int {
    if len(array) == 0 || len(array[0]) == 0 {
        return []int{}
    }
    var (
        rows, columns = len(array), len(array[0])
        order = make([]int, rows * columns)
        index = 0
        left, right, top, bottom = 0, columns - 1, 0, rows - 1
    )

    for left <= right && top <= bottom {
        for column := left; column <= right; column++ {
            order[index] = array[top][column]
            index++
        }
        for row := top + 1; row <= bottom; row++ {
            order[index] = array[row][right]
            index++
        }
        if left < right && top < bottom {
            for column := right - 1; column > left; column-- {
                order[index] = array[bottom][column]
                index++
            }
            for row := bottom; row > top; row-- {
                order[index] = array[row][left]
                index++
            }
        }
        left++
        right--
        top++
        bottom--
    }
    return order
}
```

```javascript
var spiralArray = function(array) {
    if (!array.length || !array[0].length) {
        return [];
    }

    const rows = array.length, columns = array[0].length;
    const order = [];
    let left = 0, right = columns - 1, top = 0, bottom = rows - 1;
    while (left <= right && top <= bottom) {
        for (let column = left; column <= right; column++) {
            order.push(array[top][column]);
        }
        for (let row = top + 1; row <= bottom; row++) {
            order.push(array[row][right]);
        }
        if (left < right && top < bottom) {
            for (let column = right - 1; column > left; column--) {
                order.push(array[bottom][column]);
            }
            for (let row = bottom; row > top; row--) {
                order.push(array[row][left]);
            }
        }
        [left, right, top, bottom] = [left + 1, right - 1, top + 1, bottom - 1];
    }
    return order;
};
```

```c
int* spiralArray(int** array, int arraySize, int* arrayColSize, int* returnSize) {
    if (arraySize == 0 || arrayColSize[0] == 0) {
        *returnSize = 0;
        return NULL;
    }

    int rows = arraySize, columns = arrayColSize[0];
    int total = rows * columns;
    int* order = malloc(sizeof(int) * total);
    *returnSize = 0;

    int left = 0, right = columns - 1, top = 0, bottom = rows - 1;
    while (left <= right && top <= bottom) {
        for (int column = left; column <= right; column++) {
            order[(*returnSize)++] = array[top][column];
        }
        for (int row = top + 1; row <= bottom; row++) {
            order[(*returnSize)++] = array[row][right];
        }
        if (left < right && top < bottom) {
            for (int column = right - 1; column > left; column--) {
                order[(*returnSize)++] = array[bottom][column];
            }
            for (int row = bottom; row > top; row--) {
                order[(*returnSize)++] = array[row][left];
            }
        }
        left++;
        right--;
        top++;
        bottom--;
    }
    return order;
}
```

##### 复杂度分析

- 时间复杂度：$O(mn)$，其中 $m$ 和 $n$ 分别是输入二维数组的行数和列数。二维数组中的每个元素都要被访问一次。
- 空间复杂度：$O(1)$。除了输出数组以外，空间复杂度是常数。
