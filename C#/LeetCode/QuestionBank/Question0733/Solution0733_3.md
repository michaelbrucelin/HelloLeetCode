#### [ǰ��](https://leetcode.cn/problems/flood-fill/solutions/375836/tu-xiang-xuan-ran-by-leetcode-solution/)

����Ҫ�󽫸����Ķ�ά������ָ���ġ�ɫ�项Ⱦ����һ����ɫ����ɫ�项�Ķ����ǣ�ֱ�ӻ������ڵ�ͬɫ���񹹳ɵ����塣

���Է��֣���ɫ�项���Ǳ���ͬ��ɫ�ķ����Χ��һ��ͬɫ���졣���Ǵ�ɫ��������һ���ط���ʼ�����ù��������������������������ɱ����������졣

ע�⣺��Ŀ����ɫ�ͳ�ʼ��ɫ��ͬʱ�����������ԭ��������޸ġ�

#### [����һ�������������](https://leetcode.cn/problems/flood-fill/solutions/375836/tu-xiang-xuan-ran-by-leetcode-solution/)

**˼·���㷨**

���ǴӸ�������㿪ʼ�����й������������ÿ��������һ������ʱ����������ʼλ�õķ�����ɫ��ͬ���ͽ��÷��������У������÷������ɫ���£��Է�ֹ�ظ���ӡ�

ע�⣺��Ϊ��ʼλ�õ���ɫ�ᱻ�޸ģ�����������Ҫ�����ʼλ�õ���ɫ���Ա���֮��ĸ��²�����

**����**

```cpp
class Solution {
public:
    const int dx[4] = {1, 0, 0, -1};
    const int dy[4] = {0, 1, -1, 0};
    vector<vector<int>> floodFill(vector<vector<int>>& image, int sr, int sc, int color) {
        int currColor = image[sr][sc];
        if (currColor == color) {
            return image;
        }
        int n = image.size(), m = image[0].size();
        queue<pair<int, int>> que;
        que.emplace(sr, sc);
        image[sr][sc] = color;
        while (!que.empty()) {
            int x = que.front().first, y = que.front().second;
            que.pop();
            for (int i = 0; i < 4; i++) {
                int mx = x + dx[i], my = y + dy[i];
                if (mx >= 0 && mx < n && my >= 0 && my < m && image[mx][my] == currColor) {
                    que.emplace(mx, my);
                    image[mx][my] = color;
                }
            }
        }
        return image;
    }
};
```

```java
class Solution {
    int[] dx = {1, 0, 0, -1};
    int[] dy = {0, 1, -1, 0};

    public int[][] floodFill(int[][] image, int sr, int sc, int color) {
        int currColor = image[sr][sc];
        if (currColor == color) {
            return image;
        }
        int n = image.length, m = image[0].length;
        Queue<int[]> queue = new LinkedList<int[]>();
        queue.offer(new int[]{sr, sc});
        image[sr][sc] = color;
        while (!queue.isEmpty()) {
            int[] cell = queue.poll();
            int x = cell[0], y = cell[1];
            for (int i = 0; i < 4; i++) {
                int mx = x + dx[i], my = y + dy[i];
                if (mx >= 0 && mx < n && my >= 0 && my < m && image[mx][my] == currColor) {
                    queue.offer(new int[]{mx, my});
                    image[mx][my] = color;
                }
            }
        }
        return image;
    }
}
```

```python
class Solution:
    def floodFill(self, image: List[List[int]], sr: int, sc: int, color: int) -> List[List[int]]:
        currColor = image[sr][sc]
        if currColor == color:
            return image
        
        n, m = len(image), len(image[0])
        que = collections.deque([(sr, sc)])
        image[sr][sc] = color
        while que:
            x, y = que.popleft()
            for mx, my in [(x - 1, y), (x + 1, y), (x, y - 1), (x, y + 1)]:
                if 0 <= mx < n and 0 <= my < m and image[mx][my] == currColor:
                    que.append((mx, my))
                    image[mx][my] = color
        
        return image
```

```c
const int dx[4] = {1, 0, 0, -1};
const int dy[4] = {0, 1, -1, 0};

int** floodFill(int** image, int imageSize, int* imageColSize, int sr, int sc, int color, int* returnSize, int** returnColumnSizes) {
    int n = imageSize, m = imageColSize[0];
    *returnSize = n;
    for (int i = 0; i < n; i++) {
        (*returnColumnSizes)[i] = m;
    }
    int currColor = image[sr][sc];
    if (currColor == color) {
        return image;
    }
    int que[n * m][2];
    int l = 0, r = 0;
    que[r][0] = sr, que[r++][1] = sc;
    image[sr][sc] = color;
    while (l < r) {
        int x = que[l][0], y = que[l++][1];
        for (int i = 0; i < 4; i++) {
            int mx = x + dx[i], my = y + dy[i];
            if (mx >= 0 && mx < n && my >= 0 && my < m && image[mx][my] == currColor) {
                que[r][0] = mx, que[r++][1] = my;
                image[mx][my] = color;
            }
        }
    }
    return image;
}
```

```go
var (
    dx = []int{1, 0, 0, -1}
    dy = []int{0, 1, -1, 0}
)

func floodFill(image [][]int, sr int, sc int, color int) [][]int {
    currColor := image[sr][sc]
    if currColor == color {
        return image
    }
    n, m := len(image), len(image[0])
    queue := [][]int{}
    queue = append(queue, []int{sr, sc})
    image[sr][sc] = color
    for i := 0; i < len(queue); i++ {
        cell := queue[i]
        for j := 0; j < 4; j++ {
            mx, my := cell[0] + dx[j], cell[1] + dy[j]
            if mx >= 0 && mx < n && my >= 0 && my < m && image[mx][my] == currColor {
                queue = append(queue, []int{mx, my})
                image[mx][my] = color
            }
        }
    }
    return image
}
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(n \times m)$������ $n$ �� $m$ �ֱ��Ƕ�ά�������������������������Ҫ�������еķ���һ�Ρ�
-   �ռ临�Ӷȣ�$O(n \times m)$������ $n$ �� $m$ �ֱ��Ƕ�ά�������������������ҪΪ���еĿ�����
