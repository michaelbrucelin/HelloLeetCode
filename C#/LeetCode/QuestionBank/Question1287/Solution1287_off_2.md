#### [�����������ֲ���](https://leetcode.cn/problems/element-appearing-more-than-25-in-sorted-array/solutions/101725/you-xu-shu-zu-zhong-chu-xian-ci-shu-chao-guo-25d-3/)

������ĿҪ���������������� `x` ���������� `arr` �г����� `span = arr.length / 4 + 1` �Σ���ô���ǿ��Զ϶������� `arr` �е�Ԫ�� `arr[0], arr[span], arr[span * 2], ...` һ������ `x`��

���ǿ���ʹ�÷�֤��֤�������Ľ��ۡ����� `arr[0], arr[span], arr[span * 2], ...` ����Ϊ `x`���������� `arr` �Ѿ�������ô `x` ֻ�������س����� `arr[0], arr[span], arr[span * 2], ...` ��ĳ��������Ԫ�صļ���У��������ֵĴ������Ϊ `span - 1` �Σ����������ٳ��� `span` ����ì�ܡ�

���������Ľ��ۣ����ǾͿ�������ö�� `arr[0], arr[span], arr[span * 2], ...` �е�Ԫ�أ�����ÿ��Ԫ�������� `arr` �Ͻ��ж��ֲ��ң��õ����� `arr` �г��ֵ�λ�����䡣���������ĳ�������Ϊ `span`����ô���Ǿ͵õ��˴𰸡�

```cpp
class Solution {
public:
    int findSpecialInteger(vector<int>& arr) {
        int n = arr.size();
        int span = n / 4 + 1;
        for (int i = 0; i < n; i += span) {
            auto iter_l = lower_bound(arr.begin(), arr.end(), arr[i]);
            auto iter_r = upper_bound(arr.begin(), arr.end(), arr[i]);
            if (iter_r - iter_l >= span) {
                return arr[i];
            }
        }
        return -1;
    }
};
```

```cpp
class Solution {
public:
    int findSpecialInteger(vector<int>& arr) {
        int n = arr.size();
        int span = n / 4 + 1;
        for (int i = 0; i < n; i += span) {
            auto [iter_l, iter_r] = equal_range(arr.begin(), arr.end(), arr[i]);
            if (iter_r - iter_l >= span) {
                return arr[i];
            }
        }
        return -1;
    }
};
```

```python
class Solution:
    def findSpecialInteger(self, arr: List[int]) -> int:
        n = len(arr)
        span = n // 4 + 1
        for i in range(0, n, span):
            iter_l = bisect.bisect_left(arr, arr[i])
            iter_r = bisect.bisect_right(arr, arr[i])
            if iter_r - iter_l >= span:
                return arr[i]
        return -1
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(\log N)$������ $N$ ������ `arr` �ĳ��ȡ�����ö�ٵ�Ԫ�ظ���Ϊ����Ϊ $4$ ������������ $O(1)$������ÿ��Ԫ�أ�������Ҫ������ `arr` �Ͻ��ж��ֲ��ң�ʱ�临�Ӷ�Ϊ $O(\log N)$��
-   �ռ临�Ӷȣ�$O(1)$��
