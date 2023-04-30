#### [����������ָ��](https://leetcode.cn/problems/number-of-arithmetic-triplets/solutions/2200026/suan-zhu-san-yuan-zu-de-shu-mu-by-leetco-ldq4/)

�������� $nums$ �ϸ����������������ʹ����ָ���������õ�������Ԫ�飬ʹ�� $O(n)$ ʱ�临�ӶȺ� $O(1)$ �ռ临�Ӷȡ�

�� $i$��$j$ �� $k$ �ֱ��ʾ��Ԫ��������±꣬���� $i < j < k$����ʼʱ $i = 0$��$j = 1$��$k = 2$������ÿ���±� $i$�������һ���±� $j$ ��һ���±� $k$ ʹ�� $(i, j, k)$ ��������Ԫ�顣�����������������Ԫ�� $(i_1, j_1, k_1)$ �� $(i_2, j_2, k_2)$ ���� $i_1 < i_2$����������� $nums$ �ϸ�������Եõ� $nums[i_1] < nums[i_2]$������� $nums[j_1] < nums[j_2]$ �� $nums[k_1] < nums[k_2]$���±��ϵ���� $j_1 < j_2$ �� $k_1 < k_2$���ɴ˿��Եõ����ۣ���� $(i, j, k)$ ��������Ԫ�飬���ڽ� $i$ ����֮��Ϊ�˵õ��� $i$ ��Ϊ�׸��±��������Ԫ�飬���뽫 $j$ �� $k$ Ҳ���ӡ�

�����������ۣ�����ʹ����ָ��ͳ��������Ԫ�����Ŀ��

��С����ö��ÿ�� $i$������ÿ�� $i$��ִ�����²�����

1.  ��λ $j$��
    1.  Ϊ��ȷ�� $j > i$����� $j \le i$ �� $j$ ����Ϊ $i + 1$��
    2.  ��� $j < n - 1$ �� $nums[j] - nums[i] < diff$����ֻ�н� $j$ �����ƶ��ſ������� $nums[j] - nums[i] = diff$����˽� $j$ �����ƶ���ֱ�� $j \ge n - 1$ �� $nums[j] - nums[i] \ge diff$�������ʱ $j \ge n - 1$ �� $nums[j] - nums[i] > diff$������ڵ�ǰ�� $i$ ������ $j$ �� $k$ �������������Ԫ�飬��˼���ö����һ�� $i$��
2.  �� $j < n - 1$ �� $nums[j] - nums[i] = diff$ ʱ����λ $k$��
    1.  Ϊ��ȷ�� $k > j$����� $k \le j$ �� $k$ ����Ϊ $j + 1$��
    2.  ��� $k < n$ �� $nums[k] - nums[j] < diff$����ֻ�н� $k$ �����ƶ��ſ������� $nums[k] - nums[j] = diff$����˽� $k$ �����ƶ���ֱ�� $k \ge n$ �� $nums[k] - nums[j] \ge diff$�������ʱ $k < n$ �� $nums[k] - nums[j] = diff$����ǰ�� $(i, j, k)$ ��������Ԫ�顣

ö�����п��ܵ����֮�󣬼��ɵõ�������Ԫ�����Ŀ�����������У�ÿ���±궼ֻ�����Ӳ�����٣����ÿ���±���������ʱ�䶼�� $O(n)$��

```java
class Solution {
    public int arithmeticTriplets(int[] nums, int diff) {
        int ans = 0;
        int n = nums.length;
        for (int i = 0, j = 1, k = 2; i < n - 2 && j < n - 1 && k < n; i++) {
            j = Math.max(j, i + 1);
            while (j < n - 1 && nums[j] - nums[i] < diff) {
                j++;
            }
            if (j >= n - 1 || nums[j] - nums[i] > diff) {
                continue;
            }
            k = Math.max(k, j + 1);
            while (k < n && nums[k] - nums[j] < diff) {
                k++;
            }
            if (k < n && nums[k] - nums[j] == diff) {
                ans++;
            }
        }
        return ans;
    }
}
```

```csharp
public class Solution {
    public int ArithmeticTriplets(int[] nums, int diff) {
        int ans = 0;
        int n = nums.Length;
        for (int i = 0, j = 1, k = 2; i < n - 2 && j < n - 1 && k < n; i++) {
            j = Math.Max(j, i + 1);
            while (j < n - 1 && nums[j] - nums[i] < diff) {
                j++;
            }
            if (j >= n - 1 || nums[j] - nums[i] > diff) {
                continue;
            }
            k = Math.Max(k, j + 1);
            while (k < n && nums[k] - nums[j] < diff) {
                k++;
            }
            if (k < n && nums[k] - nums[j] == diff) {
                ans++;
            }
        }
        return ans;
    }
}
```

```cpp
class Solution {
public:
    int arithmeticTriplets(vector<int>& nums, int diff) {
        int ans = 0;
        int n = nums.size();
        for (int i = 0, j = 1, k = 2; i < n - 2 && j < n - 1 && k < n; i++) {
            j = max(j, i + 1);
            while (j < n - 1 && nums[j] - nums[i] < diff) {
                j++;
            }
            if (j >= n - 1 || nums[j] - nums[i] > diff) {
                continue;
            }
            k = max(k, j + 1);
            while (k < n && nums[k] - nums[j] < diff) {
                k++;
            }
            if (k < n && nums[k] - nums[j] == diff) {
                ans++;
            }
        }
        return ans;
    }
};
```

```c
#define MAX(a, b) ((a) > (b) ? (a) : (b))

int arithmeticTriplets(int* nums, int numsSize, int diff){
    int ans = 0;
    int n = numsSize;
    for (int i = 0, j = 1, k = 2; i < n - 2 && j < n - 1 && k < n; i++) {
        j = MAX(j, i + 1);
        while (j < n - 1 && nums[j] - nums[i] < diff) {
            j++;
        }
        if (j >= n - 1 || nums[j] - nums[i] > diff) {
            continue;
        }
        k = MAX(k, j + 1);
        while (k < n && nums[k] - nums[j] < diff) {
            k++;
        }
        if (k < n && nums[k] - nums[j] == diff) {
            ans++;
        }
    }
    return ans;
}
```

```javascript
var arithmeticTriplets = function(nums, diff) {
    let ans = 0;
    const n = nums.length;
    for (let i = 0, j = 1, k = 2; i < n - 2 && j < n - 1 && k < n; i++) {
        j = Math.max(j, i + 1);
        while (j < n - 1 && nums[j] - nums[i] < diff) {
            j++;
        }
        if (j >= n - 1 || nums[j] - nums[i] > diff) {
            continue;
        }
        k = Math.max(k, j + 1);
        while (k < n && nums[k] - nums[j] < diff) {
            k++;
        }
        if (k < n && nums[k] - nums[j] === diff) {
            ans++;
        }
    }
    return ans;
};
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(n)$������ $n$ ������ $nums$ �ĳ��ȡ�����ָ��������������һ�Ρ�
-   �ռ临�Ӷȣ�$O(1)$��ֻ��Ҫ�����Ķ���ռ䡣
