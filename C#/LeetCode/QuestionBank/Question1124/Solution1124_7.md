#### [�ο��˼�����������֮���ܽ������ǳ���ϸ�Ľ���˼·, ϣ���������Щ��·](https://leetcode.cn/problems/longest-well-performing-interval/solutions/95896/can-kao-liao-ji-ge-da-shen-de-ti-jie-zhi-hou-zong-/)

�ο����� :[�ο�1](https://leetcode.com/problems/longest-well-performing-interval/discuss/335163/O(N)-Without-Hashmap.-Generalized-ProblemandSolution%3A-Find-Longest-Subarray-With-Sum-greater-K.); [�ο�2;](https://leetcode.cn/link/?target=https%3A%2F%2Fwww.jianshu.com%2Fp%2Fc548dbae322d)

1.  �۲쵽��Ŀ�и��������е�Ԫ������ֻ�����֣��ֱ��Ǵ���$8$��С�ڵ���$8$�����������ֵû�����塣���Լ������������$1$�������$8$��Ԫ�أ���$-1$����С�ڵ���$8$��Ԫ�أ��õ�һ������$[1,1,-1,-1,-1,-1,1]$��Ϊ$arr$��
2.  ������Ŀ����ˣ�������Ҫ�ҵ�һ�����У�������$1$��Ԫ������**�ϸ����**$-1$��Ԫ��������
3.  �����򻯣�Ҳ������Ҫ�ҵ�һ�����У�����������Ԫ�صĺʹ���$0$��
4.  ��ʱ��Ȼ�����뵽ֱ�ӱ��������������У��ҵ��ʹ���$0$�ҳ����������м��ɡ�
    1.  ������Ҫ�Ľ��������кͣ�����������һ�����ɣ�
        -   $i$������������±꣬����$arr[0]$��$arr[i]$�ĺ�
        -   �������е�ÿһ���±궼����һ�Σ��õ�һ���µ����飬������Ϊ**ǰ׺��**����
        ```python
        arr = [1, 1, -1, -1, -1, -1, 1]
        prefixSum = []    # ǰ׺������

        cur_sum = 0
        for val in arr:
            prefixSum.append(cur_sum)
            cur_sum += val
        prefixSum.append(cur_sum)

        print(prefixSum)  # [0, 1, 2, 1, 0, -1, -2, -1] ע�������arr����һ��Ԫ��
        ```
        -   ��ʱ���ܺ������ҵ�ÿһ�����к��ˣ���������Ҫ$arr[2]+arr[3]+\ldots+arr[5]$�ĺ�ֱ����$prefixSum[6] - prefixSum[2]$���ɣ��õ������$-4$��
5.  ������һ�����б�ʾΪ$(i, j)$��$i$��$j$�ֱ���$prefixSum$������ĳ��Ԫ�ص��±ꡣ
6.  ֱ�ӱ�������ÿһ��$(i, j)$�����ҳ��𰸡�
7.  �����Ż���������ȷһ�����ǵ�Ŀ�꣺�ҵ�һ��$(i, j)$ʹ��$prefixSum[j] - prefixSum[i] > 0$��
    1.  ���ձ���������˼·������������Ҫ��$prefixSum$�������������ѭ����
        ```python
        i = 0
        j = 0
        num = len(prefixSum)
        for i in range(num):
            for j in range(i + 1, num):
                # ���ÿһ���±꿴�Ƿ��������
                if prefixSum[i] < prefixSum[j]:
                    res = max(j - i, res)
        ```
    2.  ��ʱ�۲쵽���ڱ����ڲ�ѭ��$j$�Ĺ����У�������һ��$i < j_1 < j_2$�����$prefixSum[i] < prefixSum[j_2]$����ô$(i, j_1)$һ�������Ǵ𰸡�
        Ҳ����˵�����$(i, j_2)$��������, ��ô�����м������$j_1$������Ҫ�ټ�飬�������ǿ��Դ����������$j$��
        ```python
        i = 0
        j = 0
        res = 0
        num = len(prefixSum)
        for i in range(num):
            for j in range(num - 1, i, -1):  # j�����Ǵ�7������1
                if prefixSum[i] < prefixSum[j]:
                    res = max(j - i, res)
                    continue                 # ˵����ʱʣ�µ�(i,j)���Ǻ�ѡ��
        ```
    3.  �ֹ۲쵽���ڱ������ѭ��$i$�Ĺ����У��ڶ��������һ��$i < i_1 < j$�����$prefixSum[i_1] \ge prefixSum[i]$����ô$(i_1, j)$һ�������Ǵ𰸡�
        ��Ϊ:
        -   ���$prefixSum[j] > prefixSum[i_1]$����ô$(i_1, j)$һ�������Ǵ𰸣���Ϊ$(i, j)$������
        -   ���$prefixSum[j] < prefixSum[i_1]$, ��ô$(i_1, j)$Ҳһ�������Ǵ𰸣���Ϊ����Ҫ��$prefixSum[j] - prefixSum[i_1] > 0$��$(i, j)$��
        ��ʱ������Ҫ��ͷ����һ��$prefixSum$���ҵ�һ���ϸ񵥵��ݼ������顣
        ���統ǰ�������������ֻ��$[0, 5, 6]$������$i$�ĺ�ѡ�
        ```python
        # prefixSum = [0, 1, 2, 1, 0, -1, -2, -1] 
        stk = []
        for i in range(len(prefixSum)):
            if len(stk) == 0 or prefixSum[stk[-1]] > prefixSum[i]:
                stk.append(i)  # ��Ϊ������Ҫ�Ĵ��������,��Ҫ�±�������,��������洢�±�
            print(stk)         # [0, 5, 6]
        ```
8.  ��������ͱ���ˣ�����$stk = [0, 5, 6]$���õ�һ��$i$���ٴ����������$prefixSum = [0, 1, 2, 1, 0, -1, -2, -1]$���õ�һ��$j$�����ÿһ��$(i, j)$
9.  ��ʱ�ٹ۲�
    -   ����һ��$j$�����������$prefixSum[j] > prefixSum[stk[0]]$����ô$(0, j)$�Ǻ�ѡ���������$stk$�ǵ����ݼ��ģ�����$prefixSum[j]$Ҳ��$> prefixSum[stk[0 + x]]$����ô$(stk[0 + x], j)$Ҳ�Ǻ�ѡ�
    -   ����һ��$j$�����������$prefixSum[j] < prefixSum[stk[0]]$����ô$(0, j)$���Ǻ�ѡ�����$prefixSum[j]$��$prefixSum[stk[0 + x]]$�Ĵ�С��ϵ�޷��жϣ�����$(stk[0 + x], j)$Ҳ�Ǻ�ѡ�
    -   ����������������������$stk$������һ��$j$�����������$prefixSum[j] < prefixSum[stk[-1]]$����Ϊ�ǵ����ݼ��ģ�����$stk$�е�����Ԫ�ض�������С��$prefixSum[j]$������$j$�Ϳ���ֱ�ӱ��ų�����
    -   ��Ȼ���������һ��$j$�����������$prefixSum[j] > prefixSum[stk[-1]]$����ô$(stk[-1], j)$���Ǻ�ѡ���ʱ�ٸ���$7.1$������$stk[-1]$��˵��$j$�ټ�����������Ѿ�û�������ˣ����ԾͿ��԰�$stk[-1]$�ų����ˡ���$stk[-2]$�������Ԫ�ػ���Ҫ�����жϣ���Ҳ���ػ��ݵ�$prefixSum$�����Ҷ˼�������$j$�ˡ�

    ��������˼·�������պ�����ջ�����Ծ���ջ$stk$���洢$[0, 5, 6]$���õ����յĴ��룬�ؼ���$21$��$29$�С�

    ```python
    def longestWPI(self, hours: List[int]) -> int:
        arr = []
        for val in hours:
            if val > 8:
                arr.append(1)
            else:
                arr.append(-1)
    
        prefixSum = []  # ǰ׺������
        cur_sum = 0
        for val in arr:
            prefixSum.append(cur_sum)
            cur_sum += val
        prefixSum.append(cur_sum)
    
        stk = []
        for i in range(len(prefixSum)):
            if len(stk) == 0 or prefixSum[stk[-1]] > prefixSum[i]:
                stk.append(i)  # ��Ϊ������Ҫ�Ĵ��������,��Ҫ�±�������,��������洢�±�
    
        res = 0
        # �������prefixSum
        for j in range(len(prefixSum) - 1, -1, -1):
            # �����Ļ�, (stk[-1], j)��һ����ѡ��
            while len(stk) != 0 and prefixSum[j] > prefixSum[stk[-1]]:
                res = max(res, j - stk[-1])
                stk.pop()
        
        return res
    ```
