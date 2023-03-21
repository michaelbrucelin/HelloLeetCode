#### [����һ��̰��](https://leetcode.cn/problems/minimum-sum-of-four-digit-number-after-splitting-digits/solutions/1249214/chai-fen-shu-wei-hou-si-wei-shu-zi-de-zu-6awh/)

**��ʾ $1$**

�����������λ��**����ͬ**����ô��λ���ϸߵ����������λ�����λ���ϵ͵����������λ֮ǰ����������֮�Ͳ�����

**��ʾ $1$ ����**

��������������λ���ֱ�Ϊ $n_1, n_2 (n_1 > n_2)$����λ��Ϊ $d$����ô�仯ǰ����λ��������֮�͵Ĺ���Ϊ $d \times 10^{n_1}$���仯��Ϊ $d \times 10^{n_2+1} \le d \times 10^{n_1}$��

**��ʾ $2$**

�ڲ��ı�λ��������£�����Ӧ����**��С����ֵ���ڽϸ�λ**��

**��ʾ $2$ ����**

�����õ�����λ����Ϊ�������� $new_1$ �ĸ�λ��ʮλ�ֱ�Ϊ $d_1, d_2 (d_1 < d_2)$����ô����ǰ��$new_1 = 10 \times d_2 + d_1$����������Ϊ $10 \times d_1 + d_2 < 10 \times d_2 + d_1$��

**˼·���㷨**

������ʾ��������Ҫ�� $num$ �н�С����λ��Ϊ $new_1$ �� $new_2$ ��ʮλ�������ϴ����λ��Ϊ��λ����������ʹ�� $new_1 + new_2$ ��С��

�������������� $digits$ �洢 $num$ ��ÿλ��ֵ�����������򣬴�ʱ����С�ĺͼ�Ϊ

$$10 \times (digits[0] + digits[1]) + digits[2] + digits[3].$$

���Ƿ��ظ�ֵ��Ϊ�𰸡�

**����**

```cpp
class Solution {
public:
    int minimumSum(int num) {
        vector<int> digits;
        while (num) {
            digits.push_back(num % 10);
            num /= 10;
        }
        sort(digits.begin(), digits.end());
        return 10 * (digits[0] + digits[1]) + digits[2] + digits[3];
    }
};
```

```python
class Solution:
    def minimumSum(self, num: int) -> int:
        digits = []
        while num:
            digits.append(num % 10)
            num //= 10
        digits.sort()
        return 10 * (digits[0] + digits[1]) + digits[2] + digits[3]
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(1)$��
-   �ռ临�Ӷȣ�$O(1)$��
