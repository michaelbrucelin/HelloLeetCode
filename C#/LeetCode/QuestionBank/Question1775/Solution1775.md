#### 通过最少操作次数使数组的和相等

贪心调整。

**步骤：**
1. 遍历两个数组，统计出每个数组的和以及数组中每个数字的频次
   - 如果两个数组的和相等，return 0;
2. 用small（长度m）指向和较小的数组，其和可到达的范围是range_s: [m, 6m]，用big（长度n）指向和较大的数组，其和可到达的范围是range_b: [n, 6n]
    - 如果[m, 6m]与[n, 6n]无交集，return -1;
    - 否则交集为inter: [left, right]，且必有解
3. 用最少的步骤将range_s与range_b调整到与inter有交集（如果已经有交集，则不需要调整）
    - 调整range_s时
        - 优先调整数字1，每次调整range的左边界+1，右边界+5
        - 数字1全部调整完，调整数字2，每次调整range的左边界+1，右边界+4
        - ... ...
        - 最后调整数字5，每次调整range的左边界+1，右边界+1
    - 调整range_b时
        - 优先调整数字6，每次调整range的左边界-5，右边界-1
        - 数字6全部调整完，调整数字5，每次调整range的左边界-4，右边界-1
        - ... ...
        - 最后调整数字2，每次调整range的左边界-1，右边界-1
4. 此时，range_s、range_b都与inter有交集
    - 如果range_s与range_b有交集，那么返回上面调整的总步数即可
    - 如果range_s与range_b无交集，那么调整一次range_s或range_b再次看二者之间有没有交集，直至有交集为止
        - 调整策略以哪个调整的步幅大，就调整哪个，如果步幅一样大，调整哪个都可以
        - 例如range_s中数字1、2全部调整完，那么最大步幅为调整数字3，即步幅是3，而range_b中数字6、5、4、3全部调整完，那么最大步幅为调整数字2，即步幅是1，此时就调整range_s

**优化**
上面的调整range_s与range_b时，其实只要关注range_s的有边界与range_b的左边界即可，而不需要同时计算两边的边界。
