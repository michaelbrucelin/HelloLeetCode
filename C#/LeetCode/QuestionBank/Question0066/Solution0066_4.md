#### [����һ���ҳ���ĺ�׺ 9](https://leetcode.cn/problems/plus-one/solutions/1057162/jia-yi-by-leetcode-solution-2hor/)

**˼·**

�����Ƕ����� $digits$ ��һʱ������ֻ��Ҫ��ע $digits$ ��ĩβ�����˶��ٸ� $9$ ���ɡ����ǿ��Կ������µ����������
-   ��� $digits$ ��ĩβû�� $9$������ $[1, 2, 3]$����ô����ֱ�ӽ�ĩβ������һ���õ� $[1, 2, 4]$ �����أ�
-   ��� $digits$ ��ĩβ�����ɸ� $9$������ $[1, 2, 3, 9, 9]$����ô����ֻ��Ҫ�ҳ���ĩβ��ʼ��**��һ��**��Ϊ $9$ ��Ԫ�أ��� $3$������Ԫ�ؼ�һ���õ� $[1, 2, 4, 9, 9]$�����ĩβ�� $9$ ȫ�����㣬�õ� $[1, 2, 4, 0, 0]$ �����ء�
-   ��� $digits$ ������Ԫ�ض��� $9$������ $[9, 9, 9, 9, 9]$����ô��Ϊ $[1, 0, 0, 0, 0, 0]$������ֻ��Ҫ����һ�����ȱ� $digits$ �� $1$ �������飬����Ԫ����Ϊ $1$������Ԫ����Ϊ $0$ ���ɡ�

**�㷨**

����ֻ��Ҫ������ $digits$ ����һ������������ҳ���һ����Ϊ $9$ ��Ԫ�أ������һ������������Ԫ�����㼴�ɡ���� $digits$ �����е�Ԫ�ؾ�Ϊ $9$����ô��Ӧ�š�˼·�����ֵĵ����������������Ҫ����һ���µ����顣

**����**

```cpp
class Solution {
public:
    vector<int> plusOne(vector<int>& digits) {
        int n = digits.size();
        for (int i = n - 1; i >= 0; --i) {
            if (digits[i] != 9) {
                ++digits[i];
                for (int j = i + 1; j < n; ++j) {
                    digits[j] = 0;
                }
                return digits;
            }
        }

        // digits �����е�Ԫ�ؾ�Ϊ 9
        vector<int> ans(n + 1);
        ans[0] = 1;
        return ans;
    }
};
```

```java
class Solution {
    public int[] plusOne(int[] digits) {
        int n = digits.length;
        for (int i = n - 1; i >= 0; --i) {
            if (digits[i] != 9) {
                ++digits[i];
                for (int j = i + 1; j < n; ++j) {
                    digits[j] = 0;
                }
                return digits;
            }
        }

        // digits �����е�Ԫ�ؾ�Ϊ 9
        int[] ans = new int[n + 1];
        ans[0] = 1;
        return ans;
    }
}
```

```c#
public class Solution {
    public int[] PlusOne(int[] digits) {
        int n = digits.Length;
        for (int i = n - 1; i >= 0; --i) {
            if (digits[i] != 9) {
                ++digits[i];
                for (int j = i + 1; j < n; ++j) {
                    digits[j] = 0;
                }
                return digits;
            }
        }

        // digits �����е�Ԫ�ؾ�Ϊ 9
        int[] ans = new int[n + 1];
        ans[0] = 1;
        return ans;
    }
}
```

```python
class Solution:
    def plusOne(self, digits: List[int]) -> List[int]:
        n = len(digits)
        for i in range(n - 1, -1, -1):
            if digits[i] != 9:
                digits[i] += 1
                for j in range(i + 1, n):
                    digits[j] = 0
                return digits

        # digits �����е�Ԫ�ؾ�Ϊ 9
        return [1] + [0] * n
```

```go
func plusOne(digits []int) []int {
    n := len(digits)
    for i := n - 1; i >= 0; i-- {
        if digits[i] != 9 {
            digits[i]++
            for j := i + 1; j < n; j++ {
                digits[j] = 0
            }
            return digits
        }
    }
    // digits �����е�Ԫ�ؾ�Ϊ 9

    digits = make([]int, n+1)
    digits[0] = 1
    return digits
}
```

```javascript
var plusOne = function(digits) {
    const n = digits.length;
    for (let i = n - 1; i >= 0; --i) {
        if (digits[i] !== 9) {
            ++digits[i];
            for (let j = i + 1; j < n; ++j) {
                digits[j] = 0;
            }
            return digits;
        }
    }

    // digits �����е�Ԫ�ؾ�Ϊ 9
    const ans = new Array(n + 1).fill(0);
    ans[0] = 1;
    return ans;
};
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(n)$������ $n$ ������ $digits$ �ĳ��ȡ�
-   �ռ临�Ӷȣ�$O(1)$������ֵ������ռ临�Ӷȡ�