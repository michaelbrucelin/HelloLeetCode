#### [����״̬��](https://leetcode.cn/problems/binary-prefix-divisible-by-5/solutions/559804/you-xian-zhuang-tai-ji-by-nonsensersunny-glkk/)

״̬��Ӧ(mod 5)����ͷ��ʾ״̬ת�ƣ�ת�ƺ�����`(��ǰ״̬*2+��������ĩλ)%5`��
![](./assets/img/Solution1018_oth.png)

#### ����

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
