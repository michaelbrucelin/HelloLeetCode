### [复写零](https://leetcode.cn/problems/duplicate-zeros/solutions/1604450/fu-xie-ling-by-leetcode-solution-7ael/)

#### 方法一：双指针

**思路与算法**

首先如果没有原地修改的限制，那么我们可以另开辟一个栈来进行模拟放置：

![](./assets/img/Solution1089_off_01.png)
![](./assets/img/Solution1089_off_02.png)
![](./assets/img/Solution1089_off_03.png)
![](./assets/img/Solution1089_off_04.png)
![](./assets/img/Solution1089_off_05.png)
![](./assets/img/Solution1089_off_06.png)
![](./assets/img/Solution1089_off_07.png)
![](./assets/img/Solution1089_off_08.png)
![](./assets/img/Solution1089_off_09.png)
![](./assets/img/Solution1089_off_10.png)

而实际上我们可以不需要开辟栈空间来模拟放置元素，我们只需要用两个指针来进行标记栈顶位置和现在需要放置的元素位置即可。我们用 $top$ 来标记栈顶位置，用 $i$ 来标记现在需要放置的元素位置，那么我们找到原数组中对应放置在最后位置的元素位置，然后在数组最后从该位置元素往前来进行模拟放置即可。

**代码**

```python
class Solution:
    def duplicateZeros(self, arr: List[int]) -> None:
        n = len(arr)
        top = 0
        i = -1
        while top < n:
            i += 1
            top += 1 if arr[i] else 2
        j = n - 1
        if top == n + 1:
            arr[j] = 0
            j -= 1
            i -= 1
        while j >= 0:
            arr[j] = arr[i]
            j -= 1
            if arr[i] == 0:
                arr[j] = arr[i]
                j -= 1
            i -= 1
```

```c++
class Solution {
public:
    void duplicateZeros(vector<int>& arr) {
        int n = arr.size();
        int top = 0;
        int i = -1;
        while (top < n) {
            i++;
            if (arr[i] != 0) {
                top++;
            } else {
                top += 2;
            }
        }
        int j = n - 1;
        if (top == n + 1) {
            arr[j] = 0;
            j--;
            i--;
        } 
        while (j >= 0) {
            arr[j] = arr[i];
            j--;
            if (!arr[i]) {
                arr[j] = arr[i];
                j--;
            } 
            i--;
        }
    }
};
```

```java
class Solution {
    public void duplicateZeros(int[] arr) {
        int n = arr.length;
        int top = 0;
        int i = -1;
        while (top < n) {
            i++;
            if (arr[i] != 0) {
                top++;
            } else {
                top += 2;
            }
        }
        int j = n - 1;
        if (top == n + 1) {
            arr[j] = 0;
            j--;
            i--;
        } 
        while (j >= 0) {
            arr[j] = arr[i];
            j--;
            if (arr[i] == 0) {
                arr[j] = arr[i];
                j--;
            } 
            i--;
        }
    }
}
```

```csharp
public class Solution {
    public void DuplicateZeros(int[] arr) {
        int n = arr.Length;
        int top = 0;
        int i = -1;
        while (top < n) {
            i++;
            if (arr[i] != 0) {
                top++;
            } else {
                top += 2;
            }
        }
        int j = n - 1;
        if (top == n + 1) {
            arr[j] = 0;
            j--;
            i--;
        } 
        while (j >= 0) {
            arr[j] = arr[i];
            j--;
            if (arr[i] == 0) {
                arr[j] = arr[i];
                j--;
            } 
            i--;
        }
    }
}
```

```c
void duplicateZeros(int* arr, int arrSize){
    int top = 0;
    int i = -1;
    while (top < arrSize) {
        i++;
        if (arr[i] != 0) {
            top++;
        } else {
            top += 2;
        }
    }
    int j = arrSize - 1;
    if (top == arrSize + 1) {
        arr[j] = 0;
        j--;
        i--;
    } 
    while (j >= 0) {
        arr[j] = arr[i];
        j--;
        if (!arr[i]) {
            arr[j] = arr[i];
            j--;
        } 
        i--;
    }
}
```

```javascript
var duplicateZeros = function(arr) {
    const n = arr.length;
    let top = 0;
    let i = -1;
    while (top < n) {
        i++;
        if (arr[i] !== 0) {
            top++;
        } else {
            top += 2;
        }
    }
    let j = n - 1;
    if (top === n + 1) {
        arr[j] = 0;
        j--;
        i--;
    } 
    while (j >= 0) {
        arr[j] = arr[i];
        j--;
        if (arr[i] === 0) {
            arr[j] = arr[i];
            j--;
        } 
        i--;
    }
};
```

```go
func duplicateZeros(arr []int) {
    n := len(arr)
    top := 0
    i := -1
    for top < n {
        i++
        if arr[i] != 0 {
            top++
        } else {
            top += 2
        }
    }
    j := n - 1
    if top == n+1 {
        arr[j] = 0
        j--
        i--
    }
    for j >= 0 {
        arr[j] = arr[i]
        j--
        if arr[i] == 0 {
            arr[j] = arr[i]
            j--
        }
        i--
    }
}
```

**复杂度分析**

-   时间复杂度：$O(n)$，其中 $n$ 为数组 $arr$ 的长度。需要遍历两遍数组。
-   空间复杂度：$O(1)$，仅使用常量空间。
