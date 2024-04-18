### [计数器](https://leetcode.cn/problems/counter/solutions/2487678/ji-shu-qi-by-leetcode-solution-xuwj/)

#### 解决方案

##### 概述

这个问题旨在介绍 _**闭包(closures)**_ 的概念。在 JavaScript 中，函数具有对在相同作用域以及任何外部作用域中声明的所有变量的引用。这些作用域被称为函数的 _**词法环境**_。函数与其环境的组合被称为 _**闭包**_。

##### 闭包示例

在 JavaScript 中，你可以在其他函数内部声明并返回函数。内部函数可以访问在其上方声明的任何变量。

```javascript
function createAdder(a) {
  return function add(b) {
    const sum = a + b;
    return sum;
  }
}
const addTo2 = createAdder(2);
addTo2(5); // 7
```

在示例代码中，内部函数 `add` 可以访问 `a`。这允许了外部函数充当新函数的工厂，每个函数都具有不同的行为。

##### 闭包 VS 类

你可能会注意到，在上面的示例中，`createAdder` 非常类似于类构造函数。

```javascript
class Adder {
  constructor(a) {
     this.a = a;
  }

  add(b) {
    const sum = this.a + b;
    return sum;
  }
}
const addTo2 = new Adder(2);
addTo2.add(5); // 7
```

除了语法上的差异之外，这两个示例在本质上具有相同的目的。它们都允许你在「构造函数(Constructor)」中传递一些状态，并具有可以访问此状态的「方法 (Method)」。

它们之间一个关键的区别是闭包允许真正的 _**封装**_。在类的示例中，没有任何限制阻止你编写 `addTo2.a = 3;` 并破坏其预期行为。然而，在闭包的示例中，理论上无法访问 `a`。请注意，截至2022年，使用 [# 前缀语法](https://leetcode.cn/link/?target=https%3A%2F%2Fsecurity.feishu.cn%2Flink%2Fsafety%3Ftarget%3Dhttps%3A%2F%2Fdeveloper.mozilla.org%2Fen-US%2Fdocs%2FWeb%2FJavaScript%2FReference%2FClasses%2FPrivate_class_fields%26scene%3Dccm%26logParams%3D%7B%22location%22%3A%22ccm_drive%22%7D%26lang%3Dzh-CN) 的类仍然可以实现真正的封装。

另一个区别是函数在内存中的存储方式。如果创建了许多类的实例，每个实例都存储对 _**原型对象**_ 的单一引用，其中都存储了所有「方法(Method)」。而对于闭包，所有「方法(Method)」都在每次调用外部函数时生成并存储了一个「副本(Copy)」。因此，在同时有多种方法可用的情况下，类可以在性能方面体现更高的效率。

与像 Java 这样的语言不同，你会发现使用其他语言编写的代码通常使用函数而不是类。但由于 JavaScript 是一种多范式语言，代码如何编写取决于你正在处理的具体项目。

#### 方法

现在让我们讨论实现计数器的方法。

##### 方法 1: 先增加再返回

我们先声明一个变量 `currentCount` 并将其设置为 `n - 1`。然后在 `counter` 函数内部，增加 `currentCount` 并返回其值。请注意，由于修改了 `currentCount`，应该使用 `let` 而不是 `const` 来声明它。

##### 代码实现：

```javascript
var createCounter = function(n) {
  let currentCount = n - 1;
  return function() {
    currentCount += 1;
    return currentCount;
  };
};
var createCounter = function(n: number) {
  let currentCount = n - 1;
  return function() {
    currentCount += 1;
    return currentCount;
  };
};
```

##### 方法 2: 后缀递增语法

JavaScript 提供了方便的语法，可以先返回一个值然后递增它。这使我们可以避免把初始值设置为 `n - 1`。

##### 代码实现：

```javascript
var createCounter = function(n) {
  return function() {
    return n++;
  };
};
var createCounter = function(n: number) {
  return function() {
    return n++;
  };
};
```

##### 方法 3: 前缀递减和递增语法

JavaScript 还有一种语法，允许你先递增一个值返回它。由于递增发生在值返回之前，因此我们必须先对初始值进行递减，类似于方法 1 。

##### 代码实现：

```javascript
var createCounter = function(n) {
  --n;
  return function() {
    return ++n;
  };
};
```

```javascript
var createCounter = function(n: number) {
  --n;
  return function() {
    return ++n;
  };
};
```

##### 方法 4: 带箭头函数的后缀递增语法

我们可以使用带有隐式返回的箭头函数来减少方法 2 中的代码量。

##### 代码实现：

```javascript
var createCounter = function(n) {
  return () => n++;
};
```

```javascript
var createCounter = function(n: number) {
  return () => n++;
};
```

这些是不同的方法来实现计数器，你可以根据项目的需要选择其中之一。
