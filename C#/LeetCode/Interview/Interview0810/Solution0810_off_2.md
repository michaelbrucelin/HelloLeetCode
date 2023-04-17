#### [�������������������](https://leetcode.cn/problems/color-fill-lcci/solutions/1790727/yan-se-tian-chong-by-leetcode-solution-ejum/)

**˼·���㷨**

���ǴӸ�������㿪ʼ�������������������ÿ��������һ������ʱ����������ʼλ�õķ�����ɫ��ͬ���ͽ��÷������ɫ���£��Է�ֹ�ظ��������������ͬ������л��ݡ�

ע�⣺��Ϊ��ʼλ�õ���ɫ�ᱻ�޸ģ�����������Ҫ�����ʼλ�õ���ɫ���Ա���֮��ĸ��²�����

**����**

```cpp
class Solution {
public:
    const int dx[4] = {1, 0, 0, -1};
    const int dy[4] = {0, 1, -1, 0};
    void dfs(vector<vector<int>>& image, int x, int y, int color, int newColor) {
        if (image[x][y] == color) {
            image[x][y] = newColor;
            for (int i = 0; i < 4; i++) {
                int mx = x + dx[i], my = y + dy[i];
                if (mx >= 0 && mx < image.size() && my >= 0 && my < image[0].size()) {
                    dfs(image, mx, my, color, newColor);
                }
            }
        }
    }

    vector<vector<int>> floodFill(vector<vector<int>>& image, int sr, int sc, int newColor) {
        int currColor = image[sr][sc];
        if (currColor != newColor) {
            dfs(image, sr, sc, currColor, newColor);
        }
        return image;
    }
};
```

```java
class Solution {
    int[] dx = {1, 0, 0, -1};
    int[] dy = {0, 1, -1, 0};

    public int[][] floodFill(int[][] image, int sr, int sc, int newColor) {
        int currColor = image[sr][sc];
        if (currColor != newColor) {
            dfs(image, sr, sc, currColor, newColor);
        }
        return image;
    }

    public void dfs(int[][] image, int x, int y, int color, int newColor) {
        if (image[x][y] == color) {
            image[x][y] = newColor;
            for (int i = 0; i < 4; i++) {
                int mx = x + dx[i], my = y + dy[i];
                if (mx >= 0 && mx < image.length && my >= 0 && my < image[0].length) {
                    dfs(image, mx, my, color, newColor);
                }
            }
        }
    }
}
```

```python
class Solution:
    def floodFill(self, image: List[List[int]], sr: int, sc: int, newColor: int) -> List[List[int]]:
        n, m = len(image), len(image[0])
        currColor = image[sr][sc]

        def dfs(x: int, y: int):
            if image[x][y] == currColor:
                image[x][y] = newColor
                for mx, my in [(x - 1, y), (x + 1, y), (x, y - 1), (x, y + 1)]:
                    if 0 <= mx < n and 0 <= my < m and image[mx][my] == currColor:
                        dfs(mx, my)

        if currColor != newColor:
            dfs(sr, sc)
        return image
```

```c
const int dx[4] = {1, 0, 0, -1};
const int dy[4] = {0, 1, -1, 0};

int n, m;

void dfs(int** image, int x, int y, int color, int newColor) {
    if (image[x][y] == color) {
        image[x][y] = newColor;
        for (int i = 0; i < 4; i++) {
            int mx = x + dx[i], my = y + dy[i];
            if (mx >= 0 && mx < n && my >= 0 && my < m) {
                dfs(image, mx, my, color, newColor);
            }
        }
    }
}

int** floodFill(int** image, int imageSize, int* imageColSize, int sr, int sc, int newColor, int* returnSize, int** returnColumnSizes) {
    n = imageSize, m = imageColSize[0];
    *returnSize = n;
    for (int i = 0; i < n; i++) {
        (*returnColumnSizes)[i] = m;
    }
    int currColor = image[sr][sc];
    if (currColor != newColor) {
        dfs(image, sr, sc, currColor, newColor);
    }
    return image;
}
```

```go
var (
    dx = []int{1, 0, 0, -1}
    dy = []int{0, 1, -1, 0}
)

func floodFill(image [][]int, sr int, sc int, newColor int) [][]int {
    currColor := image[sr][sc]
    if currColor != newColor {
        dfs(image, sr, sc, currColor, newColor)
    }
    return image
}

func dfs(image [][]int, x, y, color, newColor int) {
    if image[x][y] == color {
        image[x][y] = newColor
        for i := 0; i < 4; i++ {
            mx, my := x + dx[i], y + dy[i]
            if mx >= 0 && mx < len(image) && my >= 0 && my < len(image[0]) {
                dfs(image, mx, my, color, newColor)
            }
        }
    }
}
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(n \times m)$������ $n$ �� $m$ �ֱ��Ƕ�ά�������������������������Ҫ�������еķ���һ�Ρ�
-   �ռ临�Ӷȣ�$O(n \times m)$������ $n$ �� $m$ �ֱ��Ƕ�ά�������������������ҪΪջ�ռ�Ŀ�����
