#### [�����壺Boyer-Moore ͶƱ�㷨](https://leetcode.cn/problems/shu-zu-zhong-chu-xian-ci-shu-chao-guo-yi-ban-de-shu-zi-lcof/solutions/832356/shu-zu-zhong-chu-xian-ci-shu-chao-guo-yi-pvh8/)

**˼·**

������ǰ�������Ϊ $+1$������������Ϊ $-1$��������ȫ������������Ȼ�ʹ��� `0`���ӽ���������ǿ��Կ����������������ࡣ

**�㷨**

Boyer-Moore �㷨�ı��ʺͷ������еķ���ʮ�����ơ��������ȸ��� Boyer-Moore �㷨����ϸ���裺

-   ����ά��һ����ѡ���� `candidate` �������ֵĴ��� `count`����ʼʱ `candidate` ����Ϊ����ֵ��`count` Ϊ `0`��
-   ���Ǳ������� `nums` �е�����Ԫ�أ�����ÿ��Ԫ�� `x`�����ж� `x` ֮ǰ����� `count` ��ֵΪ `0`�������Ƚ� `x` ��ֵ���� `candidate`����������ж� `x`��
    -   ��� `x` �� `candidate` ��ȣ���ô������ `count` ��ֵ���� `1`��
    -   ��� `x` �� `candidate` ���ȣ���ô������ `count` ��ֵ���� `1`��
-   �ڱ�����ɺ�`candidate` ��Ϊ���������������

���Ǿ�һ����������ӣ����������������飺

```csharp
[7, 7, 5, 7, 5, 1 | 5, 7 | 5, 5, 7, 7 | 7, 7, 7, 7]
```

�ڱ����������еĵ�һ��Ԫ���Լ�ÿ���� `|` ֮���Ԫ��ʱ��`candidate` ������Ϊ `count` ��ֵ��Ϊ `0` �������ı䡣���һ�� `candidate` ��ֵ�� `5` ��Ϊ `7`��Ҳ������������е�������

Boyer-Moore �㷨����ȷ�Խ���֤�����������һ�ֽ�Ϊ��ϸ�������Ӹ���֤����˼·�������߲ο���

�������Ǹ����㷨�����ж� `count` �Ķ��壬���Է��֣��ڶ�����������б����Ĺ����У�`count` ��ֵһ���Ǹ���������Ϊ��� `count` ��ֵΪ `0`����ô����һ�ֱ����Ŀ�ʼʱ�̣����ǻὫ `x` ��ֵ���� `candidate` ���ڽ�������һ���н� `count` ��ֵ���� `1`����� `count` ��ֵ�ڱ����Ĺ�����һֱ���ַǸ���

��ô `count` ������˼�����֮�⣬����ʲô�����ε������أ����ǻ���������

```csharp
[7, 7, 5, 7, 5, 1 | 5, 7 | 5, 5, 7, 7 | 7, 7, 7, 7]
```

��Ϊ���ӣ�����д������ÿһ������ʱ `candidate` �� `count` ��ֵ��

```
nums:      [7, 7, 5, 7, 5, 1 | 5, 7 | 5, 5, 7, 7 | 7, 7, 7, 7]
candidate:  7  7  7  7  7  7   5  5   5  5  5  5   7  7  7  7
count:      1  2  1  2  1  0   1  0   1  2  1  0   1  2  3  4
```

�����ٶ���һ������ `value`���������������� `maj` �󶨡���ÿһ������ʱ�������ǰ���� `x` �� `maj` ��ȣ���ô `value` ��ֵ�� `1`������� `1`��`value` ��ʵ�����弴Ϊ������ǰ����һ������Ϊֹ���������ֵĴ����ȷ���������˶��ٴΡ����ǽ� `value` ��ֵҲд���·���

```
nums:      [7, 7, 5, 7, 5, 1 | 5, 7 | 5, 5, 7, 7 | 7, 7, 7, 7]
value:      1  2  1  2  1  0  -1  0  -1 -2 -1  0   1  2  3  4
```

��û�з���ʲô�����ǽ� `count` �� `value` ����һ��

```
nums:      [7, 7, 5, 7, 5, 1 | 5, 7 | 5, 5, 7, 7 | 7, 7, 7, 7]
count:      1  2  1  2  1  0   1  0   1  2  1  0   1  2  3  4
value:      1  2  1  2  1  0  -1  0  -1 -2 -1  0   1  2  3  4
```

������ÿһ�������У�`count` �� `value` Ҫô��ȣ�Ҫô��Ϊ�෴���������ں�ѡ���� `candidate` ���� `maj` ʱ��������ȣ�`candidate` ����������ʱ�����ǻ�Ϊ�෴����

Ϊʲô������ô����������أ��Ⲣ����֤�������ǽ���ѡ���� `candidate` ���ֲ���������ı�����Ϊ��һ�Ρ�����ͬһ���У�`count` ��ֵ�Ǹ��� `candidate == x` ���жϽ��мӼ��ġ���ô��� `candidate` ǡ��Ϊ `maj`����ô����һ���У�`count` �� `value` �ı仯��ͬ���ģ���� `candidate` ��Ϊ `maj`����ô����һ���� `count` �� `value` �ı仯���෴�ġ���˾���������һ����������ʡ�

�������������ڣ�

-   ����֤���� `count` ��ֵһֱΪ�Ǹ��������һ������������Ҳ����ˣ�
-   ���� `value` ��ֵ������������ `maj` �󶨣���������ʾ���������ֵĴ����ȷ���������˶��ٴΡ�����ô�����һ������������`value` ��ֵΪ������

�����һ������������`count` �Ǹ���`value` Ϊ�������������ǲ����ܻ�Ϊ�෴����ֻ������ȣ��� `count == value`����������һ�Ρ��У�`count` �� `value` �ı仯��ͬ���ģ�Ҳ����˵��`candidate` �д洢�ĺ�ѡ������������������ `maj`��

```java
class Solution {
    public int majorityElement(int[] nums) {
        int count = 0;
        Integer candidate = null;

        for (int num : nums) {
            if (count == 0) {
                candidate = num;
            }
            count += (num == candidate) ? 1 : -1;
        }

        return candidate;
    }
}
```

```python
class Solution:
    def majorityElement(self, nums: List[int]) -> int:
        count = 0
        candidate = None

        for num in nums:
            if count == 0:
                candidate = num
            count += (1 if num == candidate else -1)

        return candidate
```

```cpp
class Solution {
public:
    int majorityElement(vector<int>& nums) {
        int candidate = -1;
        int count = 0;
        for (int num : nums) {
            if (num == candidate)
                ++count;
            else if (--count < 0) {
                candidate = num;
                count = 1;
            }
        }
        return candidate;
    }
};
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(n)$��Boyer-Moore �㷨ֻ�����������һ�α�����
-   �ռ临�Ӷȣ�$O(1)$��Boyer-Moore �㷨ֻ��Ҫ��������Ķ���ռ䡣
