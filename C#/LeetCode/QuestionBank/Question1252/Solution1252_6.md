#### [����˼·](https://leetcode.cn/problems/cells-with-odd-values-in-a-matrix/solutions/1663387/pythonjavatypescriptgo-rong-chi-yuan-li-7c5n1/)

����ֻ��Ҫͳ����Щ�м��������Σ���Щ�м��������� ����Ϊ����ż���εı仯������Ϊ��0�ȼۣ��൱��û�䣩 ������Щ�к��У������ݳ�ԭ��������ս����

�����ǣ� ÿһ�л���n������Ϊ������ÿһ�л���m������Ϊ����������ÿһ���к��еĽ��㶼��ż��(����������)�� ȴ�����������Σ�����Ҫ�ٳ������н���Ĵ�����

#### ����

```python
class Solution:
    def oddCells(self, m: int, n: int, indices: List[List[int]]) -> int:
        rows, cols = [0] * m, [0] * n
        for r, c in indices:
            rows[r] ^= 1
            cols[c] ^= 1
        return (r := sum(rows)) * n + (c := sum(cols)) * m - 2 * r * c
```

```java
class Solution {
    public int oddCells(int m, int n, int[][] indices) {
        int[] rows = new int[m];
        int[] cols = new int[n];
        for (int[] indice: indices) {
            rows[indice[0]] ^= 1;
            cols[indice[1]] ^= 1;
        }
        int r = 0, c = 0;
        for (int i = 0; i < m; i++) {
            r += rows[i];
        }
        for (int i = 0; i < n; i++) {
            c += cols[i];
        }
        return r * n + c * m - 2 * r * c;
    }
}
```

```typescript
function oddCells(m: number, n: number, indices: number[][]): number {
    const rows = new Array<number>(m).fill(0), cols = new Array<number>(n).fill(0)
    for (const [r, c] of indices) {
        rows[r] ^= 1
        cols[c] ^= 1
    }
    const r = rows.reduce((a, b) => a + b), c = cols.reduce((a, b) => a + b)
    return r * n + c * m - 2 * r * c
};
```

```go
func oddCells(m int, n int, indices [][]int) int {
    rows, cols := make([]int, m), make([]int, n)
    for _, indice := range indices {
        rows[indice[0]] ^= 1
        cols[indice[1]] ^= 1
    }
    r, c := sum(rows), sum(cols)
    return r * n + c * m - 2 * r * c
}

func sum(arr []int) (s int) {
    for _, num := range arr {
        s += num
    }
    return
}
```
