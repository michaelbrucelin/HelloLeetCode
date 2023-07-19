### [有限状态机](https://leetcode.cn/problems/binary-prefix-divisible-by-5/solutions/559804/you-xian-zhuang-tai-ji-by-nonsensersunny-glkk/)

状态对应(mod 5)，箭头表示状态转移，转移函数是`(当前状态*2+二进制数末位)%5`。
![](./assets/img/Solution1018_oth.png)

#### 代码

```rust
impl Solution {
    pub fn prefixes_div_by5(a: Vec<i32>) -> Vec<bool> {
        let mut state: i32 = 0;
        let mut result = vec![];
        let stateSet = [[0, 1], [2, 3], [4, 0], [1, 2], [3, 4]];
        for i in a {
            state = stateSet[state as usize][i as usize];
            result.push(state == 0);
        }
        result
    }
}
```
