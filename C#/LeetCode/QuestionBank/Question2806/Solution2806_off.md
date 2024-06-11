### [取整购买后的账户余额](https://leetcode.cn/problems/account-balance-after-rounded-purchase/solutions/2800312/qu-zheng-gou-mai-hou-de-zhang-hu-yu-e-by-xtsn/)

#### 方法一：分类讨论

**思路与算法**

$\textit{purchaseAmount}$ 对 $10$ 取余后，若余数 $r$ 小于 $5$，实际支出的金额为 $\textit{purchaseAmount} - r$；否则余数 $r$ 大于等于 $5$，实际支出的金额为 $\textit{purchaseAmount} + 10 - r$。

最后，$100$ 减去实际支出的金额即可得到答案。

**代码**

```Python
class Solution:
    def accountBalanceAfterPurchase(self, purchaseAmount: int) -> int:
        r = purchaseAmount % 10
        purchaseAmount = purchaseAmount - r if r < 5 else purchaseAmount + 10 - r
        return 100 - purchaseAmount
```

```Java
class Solution {
    public int accountBalanceAfterPurchase(int purchaseAmount) {
        int r = purchaseAmount % 10;
        if (r < 5) {
            purchaseAmount -= r;
        } else {
            purchaseAmount += 10 - r;
        }
        return 100 - purchaseAmount;
    }
}
```

```CSharp
public class Solution {
    public int AccountBalanceAfterPurchase(int purchaseAmount) {
        int r = purchaseAmount % 10;
        if (r < 5) {
            purchaseAmount -= r;
        } else {
            purchaseAmount += 10 - r;
        }
        return 100 - purchaseAmount;
    }
}
```

```C++
class Solution {
public:
    int accountBalanceAfterPurchase(int purchaseAmount) {
        int r = purchaseAmount % 10;
        if (r < 5) {
            purchaseAmount -= r;
        } else {
            purchaseAmount += 10 - r;
        }
        return 100 - purchaseAmount;
    }
}; 
```

```C
int accountBalanceAfterPurchase(int purchaseAmount){
    int r = purchaseAmount % 10;
    if (r < 5) {
        purchaseAmount -= r;
    } else {
        purchaseAmount += 10 - r;
    }
    return 100 - purchaseAmount;
}
```

```Go
func accountBalanceAfterPurchase(purchaseAmount int) int {
    r := purchaseAmount % 10;
    if r < 5 {
        purchaseAmount -= r;
    } else {
        purchaseAmount += 10 - r;
    }
    return 100 - purchaseAmount;
}
```

```JavaScript
var accountBalanceAfterPurchase = function(purchaseAmount) {
    const r = purchaseAmount % 10;
    if (r < 5) {
        purchaseAmount -= r;
    } else {
        purchaseAmount += 10 - r;
    }
    return 100 - purchaseAmount;
};
```

```TypeScript
function accountBalanceAfterPurchase(purchaseAmount: number): number {
    const r = purchaseAmount % 10;
    if (r < 5) {
        purchaseAmount -= r;
    } else {
        purchaseAmount += 10 - r;
    }
    return 100 - purchaseAmount;
};
```

```Rust
impl Solution {
    pub fn account_balance_after_purchase(purchase_amount: i32) -> i32 {
        let mut val = purchase_amount;
        let r = val % 10;
        if (r < 5) {
            val -= r;
        } else {
            val += 10 - r;
        }
        100 - val
    }
}
```

**复杂度分析**

- 时间复杂度：$O(1)$。
- 空间复杂度：$O(1)$。

#### 方法二：四舍五入

**思路与算法**

容易发现，实际支付的金额为对 $\textit{purchaseAmount}$ 在个位上进行四舍五入的结果，即：

$$\lfloor{\text{purchaseAmount} + 5 \over 10}\rfloor \times 10$$

**代码**

```Python
class Solution:
    def accountBalanceAfterPurchase(self, purchaseAmount: int) -> int:
        return 100 - (purchaseAmount + 5) // 10 * 10
```

```Java
class Solution {
    public int accountBalanceAfterPurchase(int purchaseAmount) {
        return 100 - (purchaseAmount + 5) / 10 * 10;
    }
}
```

```CSharp
public class Solution {
    public int AccountBalanceAfterPurchase(int purchaseAmount) {
        return 100 - (purchaseAmount + 5) / 10 * 10;
    }
}
```

```C++
class Solution {
public:
    int accountBalanceAfterPurchase(int purchaseAmount) {
        return 100 - (purchaseAmount + 5) / 10 * 10;
    }
}; 
```

```C
int accountBalanceAfterPurchase(int purchaseAmount){
    return 100 - (purchaseAmount + 5) / 10 * 10;
}
```

```Go
func accountBalanceAfterPurchase(purchaseAmount int) int {
    return 100 - (purchaseAmount + 5) / 10 * 10;
}
```

```JavaScript
var accountBalanceAfterPurchase = function(purchaseAmount) {
    return 100 - Math.floor((purchaseAmount + 5) / 10) * 10;
};
```

```TypeScript
function accountBalanceAfterPurchase(purchaseAmount: number): number {
    return 100 - Math.floor((purchaseAmount + 5) / 10) * 10;
};
```

```Rust
impl Solution {
    pub fn account_balance_after_purchase(purchase_amount: i32) -> i32 {
        100 - (purchase_amount + 5) / 10 * 10
    }
}
```

**复杂度分析**

- 时间复杂度：$O(1)$。
- 空间复杂度：$O(1)$。
