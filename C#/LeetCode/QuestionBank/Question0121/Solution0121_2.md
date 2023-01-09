#### [��������һ�α���](https://leetcode.cn/problems/best-time-to-buy-and-sell-stock/solutions/136684/121-mai-mai-gu-piao-de-zui-jia-shi-ji-by-leetcode-/)

**�㷨**

�������������Ϊ��`[7, 1, 5, 3, 6, 4]`

���������ͼ���ϻ��Ƹ��������е����֣����ǽ���õ���

![](./assets/img/Solution0121_2_01.png)

�����������Լ��������Ʊ������ʱ������ƣ�ÿ�����Ƕ�����ѡ����۹�Ʊ�����ô�������ڵ� `i` �죬�������Ҫ�ڽ�������Ʊ����ô������׬����Ǯ�أ�

��Ȼ��������������������Ʊ�����ǿ϶����룺�����������ʷ��͵���Ĺ�Ʊ�ͺ��ˣ�̫���ˣ�����Ŀ�У�����ֻҪ��һ��������¼һ����ʷ��ͼ۸� `minprice`�����ǾͿ��Լ����Լ��Ĺ�Ʊ����������ġ���ô�����ڵ� `i` ��������Ʊ�ܵõ���������� `prices[i] - minprice`��

��ˣ�����ֻ��Ҫ�����۸�����һ�飬��¼��ʷ��͵㣬Ȼ����ÿһ�쿼����ôһ�����⣺�����������ʷ��͵�����ģ���ô�ҽ���������׬����Ǯ������������������֮ʱ�����Ǿ͵õ�����õĴ𰸡�

```java
public class Solution {
    public int maxProfit(int prices[]) {
        int minprice = Integer.MAX_VALUE;
        int maxprofit = 0;
        for (int i = 0; i < prices.length; i++) {
            if (prices[i] < minprice) {
                minprice = prices[i];
            } else if (prices[i] - minprice > maxprofit) {
                maxprofit = prices[i] - minprice;
            }
        }
        return maxprofit;
    }
}
```

```python
class Solution:
    def maxProfit(self, prices: List[int]) -> int:
        inf = int(1e9)
        minprice = inf
        maxprofit = 0
        for price in prices:
            maxprofit = max(price - minprice, maxprofit)
            minprice = min(price, minprice)
        return maxprofit
```

```cpp
class Solution {
public:
    int maxProfit(vector<int>& prices) {
        int inf = 1e9;
        int minprice = inf, maxprofit = 0;
        for (int price: prices) {
            maxprofit = max(maxprofit, price - minprice);
            minprice = min(price, minprice);
        }
        return maxprofit;
    }
};
```

**���Ӷȷ���**

-   ʱ�临�Ӷȣ�$O(n)$��ֻ��Ҫ����һ�Ρ�
-   �ռ临�Ӷȣ�$O(1)$��ֻʹ���˳�����������
