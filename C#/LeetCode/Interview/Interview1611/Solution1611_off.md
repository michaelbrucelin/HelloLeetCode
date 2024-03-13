### [跳水板](https://leetcode.cn/problems/diving-board-lcci/solutions/319967/tiao-shui-ban-by-leetcode-solution/)

#### 前言

这道题是《程序员面试金典》上的题，书上给出了三种解法，分别是递归解法、记忆化解法和最优解法。

递归解法的时间复杂度是 $O(2^k)$，记忆化解法的时间复杂度是 $O(k^2)$，都会超出时间限制，因此这里只给出最优解法。

#### 方法一：数学

首先考虑两种边界情况。

- 如果 $k=0$，则不能建造任何跳水板，因此返回空数组。
- 如果 $\textit{shorter}$ 和 $\textit{longer}$ 相等，则建造的跳水板的长度是唯一的，都等于 $\textit{shorter} \times k$，因此返回长度为 $1$ 的数组，数组中的元素为 $\textit{shorter} \times k$。

然后考虑一般情况，即 $\textit{shorter}<\textit{longer}$ 且 $k>0$。由于短木板和长木板一共使用 $k$ 块，因此一共有 $k+1$ 种组合，每种组合下建造的跳水板长度都是不一样的，一共有 $k+1$ 种不同的长度。

为什么每种组合下建造的跳水板长度都是不一样的？考虑以下两种不同的组合：第一种组合，有 $i$ 块长木板，则跳水板的长度是 $\textit{shorter} \times (k-i)+\textit{longer} \times i$；第二种组合，有 $j$ 块长木板，则跳水板的长度是 $\textit{shorter} \times (k-j)+\textit{longer} \times j$。其中 $0 \leq i<j \leq k$。则两种不同的组合下的跳水板长度之差为：

$$(\textit{shorter} \times (k-i)+\textit{longer} \times i)-(\textit{shorter} \times (k-j)+\textit{longer} \times j)=(\textit{longer}-\textit{shorter}) \times (i-j)$$

由于 $\textit{longer}>\textit{shorter}$ 且 $i<j$，因此上式的值小于 $0$。由此可见，任意两种不同的组合下的跳水板长度都是不一样的，而且使用的长木板越多，跳水板的长度越大。

因此创建长度为 $k+1$ 的数组 $\textit{lengths}$，对于 $0 \leq i \leq k$，令 $\textit{lengths}[i]=\textit{shorter} \times (k-i)+\textit{longer} \times i$，则 $\textit{lengths}$ 包含跳水板所有可能的长度，且长度为升序排序。

![](./assets/img/Solution1611_off.gif)

```java
class Solution {
    public int[] divingBoard(int shorter, int longer, int k) {
        if (k == 0) {
            return new int[0];
        }
        if (shorter == longer) {
            return new int[]{shorter * k};
        }
        int[] lengths = new int[k + 1];
        for (int i = 0; i <= k; i++) {
            lengths[i] = shorter * (k - i) + longer * i;
        }
        return lengths;
    }
}
```

```c++
class Solution {
public:
    vector<int> divingBoard(int shorter, int longer, int k) {
        if (k == 0) {
            return vector <int> ();
        }

        if (shorter == longer) {
            return vector <int> (1, shorter * k);
        }

        vector <int> lengths(k + 1);
        for (int i = 0; i <= k; ++i) {
            lengths[i] = shorter * (k - i) + longer * i;
        }

        return lengths;
    }
};
```

```csharp
public class Solution 
{
    public int[] DivingBoard(int shorter, int longer, int k) 
    {
        if (k == 0)
        {
            return new int[0];
        }

        if (shorter == longer) 
        {
            return new int[]{shorter * k};
        }

        int[] lengths = new int[k + 1];
        for (int i = 0; i <= k; i++) 
        {
            lengths[i] = shorter * (k - i) + longer * i;
        }
        
        return lengths;
    }
}
```

```c
int* divingBoard(int shorter, int longer, int k, int* returnSize) {
    if (k == 0) {
        *returnSize = 0;
        return NULL;
    }
    if (shorter == longer) {
        int* p = (int*)malloc(sizeof(int));
        *p = shorter * k;
        *returnSize = 1;
        return p;
    }
    *returnSize = k + 1;
    int* lengths = (int*)malloc(sizeof(int) * (k + 1));
    for (int i = 0; i <= k; ++i) {
        lengths[i] = shorter * (k - i) + longer * i;
    }
    return lengths;
}
```

```go
func divingBoard(shorter int, longer int, k int) []int {
    if k == 0 {
        return []int{}
    }
    if shorter == longer {
        return []int{shorter * k}
    }
    lengths := make([]int, k + 1)
    for i := 0; i <= k; i++ {
        lengths[i] = shorter * (k - i) + longer * i
    }
    return lengths
}
```

##### 复杂度分析

- 时间复杂度：$O(k)$，其中 $k$ 是木板数量。短木板和长木板一共使用 $k$ 块，一共有 $k+1$ 种组合，对于每种组合都要计算跳水板的长度。
- 空间复杂度：$O(1)$。除了返回值以外，额外使用的空间复杂度为常数。
