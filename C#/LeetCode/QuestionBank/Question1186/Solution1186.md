#### 贡献值 + 前缀和 + 单调栈

1. 预处理
    1. 原数组：将连续的非负整数可以合并为一项，来减少时间复杂度
    2. 前缀和：$pre$
    3. 前缀和的单调栈：$stack$，方便找出某一$id$后最大值
2. 枚举原数组中的每一项，假定如果删除，删除的就是这一项，看看其对应的最大的和是多少
    1. 同时枚举前缀和的每一项，可以确认数组项左侧前缀和最小的位置$min$
    2. 通过$stack$可以快速找出数组项右侧前缀和最大的位置$max$
    3. 判断枚举项
        1. 如果数组项大于等于0，这一项的贡献值是：$pre[max] - pre[min]$
        2. 如果数组项小于0，这一项的贡献值是：$pre[max] - pre[min] + arr[i]$

## 示例

`arr = [ 1, -2, 0, 5, -1, 2, 1, -3, 3 ]`
1. 预处理
    ```c
    索引：   [    0   1  2   3  4   5  6 ]
    原数组： [    1, -2, 5, -1, 3, -3, 2 ]
    前缀和： [ 0, 1, -1, 4,  3, 6,  3, 5 ]  sum(arr[l,r]) = pre[r+1] = pre[r]
    索引：   [ 0  1   2  3   4  5   6  7 ]
    单调栈： 栈顶 [ 4, 6 ] 栈底
    ```
2. 枚举
    ```c
    min = 0;  // 表示枚举项左侧最小前缀和的id
    id = 0;   // 从头开始枚举数组项
    // 开始枚举
    id = 0;
        min = 0; id < stack.Peek(); arr[id] > 0; 贡献值为：6 = pre[stack.Peek()+1] - pre[min]
    id = 1;
        min = 0; id < stack.Peek(); arr[id] < 0; 贡献值为：8 = pre[stack.Peek()+1] - pre[min] - arr[id]
    id = 2;
        min = 2; id < stack.Peek(); arr[id] > 0; 贡献值为：7 = pre[stack.Peek()+1] - pre[min]
    id = 3;
        min = 2; id < stack.Peek(); arr[id] < 0; 贡献值为：8 = pre[stack.Peek()+1] - pre[min] - arr[id]
    id = 4;
        min = 2; id = stack.Peek(); stack.Pop();
                                    arr[id] > 0; 贡献值为：6 = pre[stack.Peek()+1] - pre[min]
    id = 5;
        min = 2; id < stack.Peek(); arr[id] < 0; 贡献值为：9 = pre[stack.Peek()+1] - pre[min] - arr[id]
    id = 6;
        min = 2; id = stack.Peek(); stack.Pop();
                                    arr[id] > 0; 贡献值为：6 = pre[arr.Length] - pre[min]
    ```
