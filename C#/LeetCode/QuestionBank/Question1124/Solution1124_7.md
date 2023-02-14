#### [参考了几个大神的题解之后总结下来非常详细的解题思路, 希望大家少走些弯路](https://leetcode.cn/problems/longest-well-performing-interval/solutions/95896/can-kao-liao-ji-ge-da-shen-de-ti-jie-zhi-hou-zong-/)

参考链接 :[参考1](https://leetcode.com/problems/longest-well-performing-interval/discuss/335163/O(N)-Without-Hashmap.-Generalized-ProblemandSolution%3A-Find-Longest-Subarray-With-Sum-greater-K.); [参考2;](https://leetcode.cn/link/?target=https%3A%2F%2Fwww.jianshu.com%2Fp%2Fc548dbae322d)

1.  观察到题目中给出数组中的元素有且只有两种，分别是大于$8$和小于等于$8$，而具体的数值没有意义。所以简单起见，我们用$1$代表大于$8$的元素，用$-1$代表小于等于$8$的元素，得到一个数组$[1,1,-1,-1,-1,-1,1]$记为$arr$。
2.  现在题目变成了，我们需要找到一个子列，子列中$1$的元素数量**严格大于**$-1$的元素数量。
3.  继续简化：也就是需要找到一个子列，子列中所有元素的和大于$0$。
4.  这时自然可以想到直接暴力遍历所有子列，找到和大于$0$且长度最大的子列即可。
    1.  我们需要的仅仅是子列和，所以这里有一个技巧：
        -   $i$是数组的任意下标，计算$arr[0]$到$arr[i]$的和
        -   对数组中的每一个下标都计算一次，得到一个新的数组，它被称为**前缀和**数组
        ```python
        arr = [1, 1, -1, -1, -1, -1, 1]
        prefixSum = []    # 前缀和数组

        cur_sum = 0
        for val in arr:
            prefixSum.append(cur_sum)
            cur_sum += val
        prefixSum.append(cur_sum)

        print(prefixSum)  # [0, 1, 2, 1, 0, -1, -2, -1] 注意这里比arr多了一个元素
        ```
        -   这时就能很容易找到每一个子列和了，比如我想要$arr[2]+arr[3]+\ldots+arr[5]$的和直接用$prefixSum[6] - prefixSum[2]$即可，得到结果是$-4$。
5.  将任意一个子列表示为$(i, j)$，$i$和$j$分别是$prefixSum$数组中某个元素的下标。
6.  直接暴力遍历每一个$(i, j)$即可找出答案。
7.  继续优化。首先明确一下我们的目标：找到一个$(i, j)$使得$prefixSum[j] - prefixSum[i] > 0$。
    1.  按照暴力遍历的思路来看，我们需要在$prefixSum$数组进行这样的循环：
        ```python
        i = 0
        j = 0
        num = len(prefixSum)
        for i in range(num):
            for j in range(i + 1, num):
                # 检查每一对下标看是否符合条件
                if prefixSum[i] < prefixSum[j]:
                    res = max(j - i, res)
        ```
    2.  这时观察到，在遍历内层循环$j$的过程中，给任意一个$i < j_1 < j_2$，如果$prefixSum[i] < prefixSum[j_2]$，那么$(i, j_1)$一定不会是答案。
        也就是说，如果$(i, j_2)$符合条件, 那么它们中间的所有$j_1$都不需要再检查，所以我们可以从右往左遍历$j$：
        ```python
        i = 0
        j = 0
        res = 0
        num = len(prefixSum)
        for i in range(num):
            for j in range(num - 1, i, -1):  # j现在是从7遍历到1
                if prefixSum[i] < prefixSum[j]:
                    res = max(j - i, res)
                    continue                 # 说明此时剩下的(i,j)不是候选项
        ```
    3.  又观察到，在遍历外层循环$i$的过程中，在对于任意的一个$i < i_1 < j$，如果$prefixSum[i_1] \ge prefixSum[i]$，那么$(i_1, j)$一定不会是答案。
        因为:
        -   如果$prefixSum[j] > prefixSum[i_1]$，那么$(i_1, j)$一定不会是答案，因为$(i, j)$更长。
        -   如果$prefixSum[j] < prefixSum[i_1]$, 那么$(i_1, j)$也一定不会是答案，因为我们要找$prefixSum[j] - prefixSum[i_1] > 0$的$(i, j)$。
        这时我们需要从头遍历一遍$prefixSum$，找到一个严格单调递减的数组。
        比如当前这个测试用例，只有$[0, 5, 6]$可能是$i$的候选项。
        ```python
        # prefixSum = [0, 1, 2, 1, 0, -1, -2, -1] 
        stk = []
        for i in range(len(prefixSum)):
            if len(stk) == 0 or prefixSum[stk[-1]] > prefixSum[i]:
                stk.append(i)  # 因为最终需要的答案是最长距离,需要下标来计算,所以这里存储下标
            print(stk)         # [0, 5, 6]
        ```
8.  现在问题就变成了，遍历$stk = [0, 5, 6]$，拿到一个$i$，再从右向左遍历$prefixSum = [0, 1, 2, 1, 0, -1, -2, -1]$，拿到一个$j$，检查每一对$(i, j)$
9.  此时再观察
    -   对于一个$j$，如果它满足$prefixSum[j] > prefixSum[stk[0]]$，那么$(0, j)$是候选项，但是由于$stk$是单调递减的，所以$prefixSum[j]$也是$> prefixSum[stk[0 + x]]$，那么$(stk[0 + x], j)$也是候选项。
    -   对于一个$j$，如果它满足$prefixSum[j] < prefixSum[stk[0]]$，那么$(0, j)$不是候选项，但是$prefixSum[j]$和$prefixSum[stk[0 + x]]$的大小关系无法判断，所以$(stk[0 + x], j)$也是候选项。
    -   但是如果反过来，反向遍历$stk$，对于一个$j$，如果它满足$prefixSum[j] < prefixSum[stk[-1]]$，因为是单调递减的，所以$stk$中的其他元素都不会再小于$prefixSum[j]$，所以$j$就可以直接被排除掉。
    -   再然后，如果对于一个$j$，如果它满足$prefixSum[j] > prefixSum[stk[-1]]$，那么$(stk[-1], j)$就是候选项，此时再根据$7.1$，对于$stk[-1]$来说，$j$再继续向左遍历已经没有意义了，所以就可以把$stk[-1]$排除掉了。而$stk[-2]$及后面的元素还需要继续判断，但也不必回溯到$prefixSum$的最右端继续遍历$j$了。

    根据以上思路，操作刚好契合栈，所以就用栈$stk$来存储$[0, 5, 6]$，得到最终的代码，关键在$21$到$29$行。

    ```python
    def longestWPI(self, hours: List[int]) -> int:
        arr = []
        for val in hours:
            if val > 8:
                arr.append(1)
            else:
                arr.append(-1)
    
        prefixSum = []  # 前缀和数组
        cur_sum = 0
        for val in arr:
            prefixSum.append(cur_sum)
            cur_sum += val
        prefixSum.append(cur_sum)
    
        stk = []
        for i in range(len(prefixSum)):
            if len(stk) == 0 or prefixSum[stk[-1]] > prefixSum[i]:
                stk.append(i)  # 因为最终需要的答案是最长距离,需要下标来计算,所以这里存储下标
    
        res = 0
        # 逆向遍历prefixSum
        for j in range(len(prefixSum) - 1, -1, -1):
            # 成立的话, (stk[-1], j)是一个候选项
            while len(stk) != 0 and prefixSum[j] > prefixSum[stk[-1]]:
                res = max(res, j - stk[-1])
                stk.pop()
        
        return res
    ```
