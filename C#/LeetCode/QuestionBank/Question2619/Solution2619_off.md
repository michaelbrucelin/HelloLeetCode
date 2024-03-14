### [数组原型对象的最后一个元素](https://leetcode.cn/problems/array-prototype-last/solutions/2506895/shu-zu-yuan-xing-dui-xiang-de-zui-hou-yi-4phe/)

#### 概述

这个问题引导我们进入 JavaScript 编程的一个有趣部分：向内置原型添加新功能。尽管这因为可能会有潜在风险，通常不是推荐做法，但它确实提供了对 JavaScript 灵活和动态特性的深刻理解。在这个挑战中，我们需要向 `Array` 原型添加一个 `last()` 方法。这个新方法将返回应用到它的任何数组的最后一个元素，如果数组为空则返回 -1。

在 JavaScript 中，数组是对象，所有对象都从它们的原型继承属性和方法。原型是一种用作创建其他对象基础的“模板对象”。在这个上下文中，JavaScript 的 Array 对象是一个全局对象，包含用于操作数组的方法，这个对象可以通过自定义方法或属性来扩展。

例如，让我们看一下内置的 `push()` 方法，它可以将新的项添加到数组的末尾并返回新的长度。这个方法是 `Array` 原型的一部分，对 JavaScript 中的所有数组都可用：

```javascript
let arr = [1, 2, 3];

console.log(Array.prototype.hasOwnProperty('push')); // 这将返回 true，因为数组有 push 方法

arr.push(4); // 现在 arr 是 [1, 2, 3, 4]
```

现在，如果你想向所有数组添加一个新的方法，例如 `last()`，你可以将它添加到 `Array` 原型中：

```javascript
Array.prototype.last = function() {
  // 这里放置 last 方法的实现
};
```

你创建的所有数组现在都可以访问这个 `last()` 方法：

```javascript
let arr = [1, 2, 3];
console.log(arr.last()); // 你的实现将决定这将输出什么
```

扩展内置原型，如 Array 的原型，可能会有潜在风险，因为如果你的方法名称与未来的 JavaScript 更新或其他库的方法名称冲突，可能会导致意想不到的行为。例如，考虑尝试覆盖 Array 原型上的 `push()` 方法：

```javascript
Array.prototype.push = function() {
    console.log('push 方法已被覆盖！');
};
`
let nums = [1, 2, 3];
nums.push(4); // push 方法已被覆盖！
```

在这种情况下，`push()` 方法不再将元素附加到数组的末尾。相反，它仅仅在控制台上记录一条消息。

通常不鼓励覆盖内置方法，`push()` 方法广泛用于 JavaScript，改变其功能可能导致大量的错误和问题。这在处理第三方库或其他开发者的代码时尤其麻烦，因为他们期望 `push()` 方法按预期工作。

如果需要一个内置方法的修改版本，通常建议创建一个单独的方法或函数。例如，你可以开发一个新的函数，将元素附加到数组中，然后记录一条消息：

```javascript
function pushAndLog(array, element) {
    array.push(element);
    console.log('元素 ' + element + ' 已添加到数组中。');
}

let nums = [1, 2, 3];
pushAndLog(nums, 4); // 元素 4 已添加到数组中。
console.log(nums); // [1, 2, 3, 4]
```

在这个问题中，你的任务是扩展 `Array` 原型，包含一个 `last()` 方法，如果存在，它应该返回数组的最后一个元素，如果数组为空，则返回 -1。

理解这个任务涉及到理解 JavaScript 中的 this 关键字。在这里，JavaScript 中的 this 关键字的行为与其他编程语言略有不同。this 的值取决于函数调用时的上下文。在这个问题中，this 将引用当前调用 last() 方法的对象，它将是一个数组。

在 JavaScript 中，`this` 的行为与其他编程语言稍有不同。它的值由它的使用上下文决定，这对初学者来说可能会让人感到困惑。因此，了解上下文和 `this` 在不同情况下所指的对象是至关重要的。

##### 全局上下文

在全局执行上下文中（即，在任何函数之外），`this` 无论在严格模式还是非严格模式下，都引用全局对象。

在 web 浏览器中，全局对象是 `window`，所以 `this` 将引用 `window` 对象：

```javascript
console.log(this); // 在浏览器上下文中会记录 "[object Window]"
```

在 Node.js 环境中，全局对象不是 `window` 而是 `global`。因此，如果在 Node.js 上下文中运行相同的代码，`this` 将引用全局对象：

```javascript
console.log(this); // 在 Node.js 上下文中会记录 "[object global]"
```

##### 函数上下文

在普通函数内部，`this` 的值取决于函数的调用方式。如果函数在全局上下文中调用，`this` 在严格模式下将为 `undefined`，在非严格模式下将引用全局对象。

```javascript
function func() {
  console.log(this);
}

func(); // 在非严格模式的浏览器上下文中记录 "[object Window]"，在严格模式下会记录 "undefined"
```

但是，当函数充当对象的方法时，`this` 将引用调用该方法的对象。这展示了 `this` 的值不绑定于函数本身，而是由函数被调用的方式和位置决定，这个概念称为执行上下文：

```javascript
let obj = {
  prop: "Hello",
  func: function

() {
    console.log(this.prop);
  }
}

obj.func(); // 记录 "Hello"
```

然而，箭头函数不具有自己的 `this`。相反，它们从创建时的父作用域继承 `this`。换句话说，箭头函数内部的 `this` 值不由它的调用方式决定，而是由它的定义时的外部词法上下文决定：

```javascript
let obj = {
  prop: "Hello",
  func: () => {
    console.log(this.prop);
  }
}

obj.func(); // 记录 "undefined"，因为箭头函数内部的 `this` 不绑定到 `obj`，而是绑定到其外部词法上下文
```

这在某些情况下可能很有用，但它也使得箭头函数不适合需要访问它们被调用的对象的其他属性的方法。

##### 事件处理程序

在事件处理程序的上下文中，`this` 引用附加了事件监听器的元素，与 `event.currentTarget` 相同。

```javascript
button.addEventListener('click', function() {
  console.log(this); // 记录按钮的整个 HTML 内容
});
```

重要的是注意，它不引用常用的 `event.target` 属性。让我们澄清 `event.currentTarget` 和 `event.target` 之间的区别。

- `event.currentTarget`：该属性引用附加了事件处理程序（如 `addEventListener`）的元素。这是在事件处理程序函数的上下文中 `this` 引用的内容。
- `event.target`：该属性引用引发事件的实际 DOM 元素。对于会冒泡的事件特别重要。如果你点击内部元素，事件将冒泡到外部元素，触发它们的事件监听器。对于这些外部元素，`event.target` 将是实际被点击的最内层元素，而 `event.currentTarget`（或 `this`）将是当前处理程序附加到的元素。

```javascript
<div id="outer">点击我
  <div id="inner">或者点击我</div>
</div>

<script>
document.getElementById('outer').addEventListener('click', function(event) {
  console.log("currentTarget: ", event.currentTarget.id);
  console.log("this: ", this.id);
  console.log("target: ", event.target.id);
});
</script>
```

在这种情况下，如果你点击外部 div，所有三个日志都将打印 "outer"，因为点击的元素（`target`）和处理程序附加的元素（`currentTarget` 或 `this`）是相同的。但是，如果你点击内部 div 中的 "或者点击我" 文本，`event.target` 将是 "inner"（因为这是你点击的元素），而 `event.currentTarget`（或 `this`）仍将是 "outer"（因为这是事件处理程序附加的元素）。

##### 构造函数上下文

在构造函数内部，`this` 引用新创建的对象。但是，这里的“新创建”是什么意思呢？要理解这一点，我们需要探讨 JavaScript 中的 `new` 关键字。当你在函数调用之前使用 `new` 时，它告诉 JavaScript 进行四个操作：

1. 创建一个新的空对象。这不是一个函数、数组或 null，只是一个空对象。
1. 使函数内部的 `this` 引用这个新对象。新对象与构造函数内的 `this` 关联起来。这就是为什么 `Person(name)` 内的 `this.name` 实际上修改了新对象。
1. 正常执行函数。它像通常情况下执行函数代码一样执行。
1. 如果函数没有返回自己的对象，则返回新对象。如果构造函数返回一个对象，那个对象将被返回，而不是新对象。如果返回其他任何内容，将返回新对象。

`new` 关键字允许 JavaScript 开发者以面向对象的方式使用语言，从构造函数中创建实例，就像其他语言中的类一样。这也意味着构造函数内部的 `this` 关键字将像从基于类的语言中转换的开发者所期望的那样引用对象的新实例。

```javascript
function Person(name) {
  // 当使用 `new` 调用时，这是一个新的、空的对象
  this.name = name; // `this` 现在有一个 `name` 属性
  // 函数结束后，将返回 `this`，因为没有其他对象被函数返回
}

let john = new Person('John'); // `john` 现在是函数 `Person` 返回的对象，包含一个值为 'John' 的 `name` 属性
console.log(john.name); // 记录 "John"
```

##### 类上下文

在类中，方法内部的 `this` 引用类的实例：

```javascript
class ExampleClass {
  constructor(value) {
    this.value = value;
  }

  logValue() {
    console.log(this.value);
  }
}

const exampleInstance = new ExampleClass('Hello');
exampleInstance.logValue(); // 记录 "Hello"
```

##### 显式 / 隐式绑定

你还可以使用函数上的 `.call()`、`.apply()` 或 `.bind()` 方法来明确设置 `this` 的上下文：

```javascript
function logThis() {
  console

.log(this);
}

const obj1 = { number: 1 };
const obj2 = { number: 2 };

logThis.call(obj1); // 记录 obj1
logThis.call(obj2); // 记录 obj2

const boundLogThis = logThis.bind(obj1);
boundLogThis(); // 记录 obj1
```

##### 绑定方法和永久 `this` 上下文

JavaScript 提供了一个名为 `bind` 的内置方法，允许我们设置方法中的 `this` 值。这个方法创建一个新函数，当调用时，将其 `this` 关键字设置为提供的值，以及在调用新函数时提供的一系列参数。

`bind` 方法的独特之处在于它创建了一个永久绑定的 `this` 值，无论后来如何调用该函数，都不会更改 `this` 的值。下面的示例演示了 `bind` 如何提供一种锁定函数中的 `this` 值的方法，在各种情况下都很有帮助，例如在设置事件处理程序时，希望 `this` 值始终引用特定对象，或者在使用调用回调函数的库或框架时，希望在回调中控制 `this` 引用的对象。

```javascript
function greet() {
  return `你好，我是 ${this.name}`;
}

let person1 = { name: 'Alice' };
let person2 = { name: 'Bob' };

// 创建一个与 `person1` 绑定的函数
let greetPerson1 = greet.bind(person1);

console.log(greetPerson1()); // 你好，我是 Alice

// 尝试使用 `call` 方法更改上下文；但是，它仍然使用 `person1` 作为 `this` 上下文
console.log(greetPerson1.call(person2)); // 你好，我是 Alice

// 相比之下，正常函数调用允许使用 `call` 方法设置 `this` 上下文
console.log(greet.call(person2)); // 你好，我是 Bob
```

在 JavaScript 中，了解 `this` 关键字的上下文对于操作和与对象交互非常重要，特别是在处理面向对象编程、事件处理程序和函数调用的某些方面。了解 `this` 的行为有助于改善代码的结构，并使其更可预测和更容易调试。此外，某些设计模式，如工厂模式和装饰器模式，大量使用 `this`，因此了解其行为对于有效实现这些模式至关重要。

JavaScript 中的一个关键概念是函数对象中的 `this` 值通常不是固定的 - 它通常是根据函数的执行上下文而确定的，而不是根据其定义的时刻。然而，也有例外情况。使用函数上的 `bind()`、`call()` 或 `apply()` 方法时，这些方法允许你显式设置函数调用的 `this` 值，从而覆盖其默认行为。此外，JavaScript 中的箭头函数行为不同。它们不绑定自己的 `this` 值。相反，它们从定义它们的外部词法环境中捕获 `this` 的值，并且这个值在函数的整个生命周期内保持不变。这些差异使得理解和使用 JavaScript 中的 `this` 既具有挑战性又非常重要。

#### 方法 1：扩展数组原型以包含 `.last()` 方法

##### 概述

根据问题陈述，您需要增强所有数组，使其具有返回数组最后一个元素的方法 `.last()`。如果数组中没有元素，则应返回-1。

为此，您可以向数组原型添加一个新方法。这个新方法可以通过访问这个 `this[this.length-1]` 简单地返回数组的最后一个元素。

添加到数组原型的方法中的 `this` 关键字引用调用该方法的数组。

注意：扩展原生原型是 JavaScript 的一个强大功能，但应该谨慎使用。如果其他代码(或更高版本的 JavaScript)添加了同名的方法，则可能会导致冲突。在扩展本机原型时始终保持谨慎。

##### 算法步骤

1. 在名为 last 的数组原型上定义一个新方法。
1. 在这个方法中，检查数组是否为空。如果是，返回 -1。
1. 如果数组不为空，则返回数组的最后一个元素。最后一个元素可以通过以下方式访问：`this[this.length - 1]`。

##### 实现

这种方法可以通过各种方式实现。

##### 实现 1：常规 if 检查

```javascript
Array.prototype.last = function() {
  if (this.length === 0) {
    return -1;
  }

  return this[this.length - 1];
}
```

```typescript
declare global {
    interface Array<T> {
        last(): T | -1;
    }
}

Array.prototype.last = function(): number { 
    if (this.length === 0) {
        return -1;
    }

    return this[this.length - 1];
}
```

##### 实现 2：三元运算符

```typescript
Array.prototype.last = function() {
  return this.length === 0 ? -1 : this[this.length - 1];
}
```

```typescript
declare global {
    interface Array<T> {
        last(): T | -1;
    }
}

Array.prototype.last = function(): number {
    return this.length === 0 ? -1 : this[this.length - 1];
}
```

这个版本使用了一个三元运算符，代码更简洁。`?` 和 `:` 就像一个简短 `if/else`。

##### 实现 3：Nullish 合并运算符

```javascript
Array.prototype.last = function() {
  return this[this.length - 1] ?? -1;
}
```

```typescript
declare global {
    interface Array<T> {
        last(): T | -1;
    }
}

Array.prototype.last = function(): number {
  return this[this.length - 1] ?? -1;
}
```

此版本使用空合并运算符(`??`)。如果不为 `null` 或 `undefined`，则返回左侧操作数，否则返回右侧操作数。
请注意，此实现假定数组只包含数字。如果数组的最后一个元素为空或未定义，则此方法将返回-1，这可能会掩盖最后一个元素的实际值。它可能不适合包含其他数据类型的数组，在这些数组中，`null` 或 `undefined` 是有效且不同的值。始终确保使用适合数组中包含的数据类型的方法。

##### 实现 4：使用数组 `pop()` 方法

```javascript
Array.prototype.last = function() {
  let val = this.pop();
  return val !== undefined ? val : -1;
}
```

```typescript
declare global {
    interface Array<T> {
        last(): T | -1;
    }
}

Array.prototype.last = function(): number {
  let val = this.pop();
  return val !== undefined ? val : -1;
}
```

此版本使用数组 `pop()` 方法，该方法从数组中移除最后一个元素并返回它。如果数组为空，则 `pop()` 返回 `undefined`，我们检查它并将其替换为 -1。需要注意的是，该操作会改变原始数组，这可能并不理想，具体取决于您的用例。

##### 实现 6：将 Nullish 合并运算符与 `Array.prototype.at()` 方法结合使用

```javascript
Array.prototype.last = function() {
  return this.at(-1) ?? -1;
}
```

```typescript
declare global {
    interface Array<T> {
        last(): T | -1;
    }
}

Array.prototype.last = function(): number {
    return this.at(-1) ?? -1;
}
```

在此版本中，我们使用 ECMAScript 2021 中引入的 `Array.prototype.at()` 方法。此方法接受一个整数值，并返回该索引处的元素，允许使用正整数和负整数。负整数从数组末尾开始计数。如果数组为空，则 `at(-1)` 将是未定义的，因此我们提供 -1 作为备用。

##### 实现 7：使用 `Array.prototype.slice()` 方法

```javascript
Array.prototype.last = function() {
  return this.length ? this.slice(-1)[0] : -1;
}
```

```typescript
declare global {
    interface Array<T> {
        last(): T | -1;
    }
}

Array.prototype.last = function(): number {
    return this.length ? this.slice(-1)[0] : -1;
}
```

在这种方法中，我们使用 `Array.prototype.slice()` 方法。此方法提取数组的一部分并返回新数组。我们通过提供 -1 作为参数来请求最后一个元素。如果数组为空，则 `slice(-1)[0]` 将为 `undefined`，因此我们提供 -1 作为备用。需要注意的是，该方法不会改变原始数组，这与我们前面提到的 `pop()` 方法不同。

##### 实现 8：使用默认参数

```javascript
Array.prototype.last = function() {
  const [lastElement = -1] = this.slice(-1);
  return lastElement;
}
```

```typescript
declare global {
    interface Array<T> {
        last(): T | -1;
    }
}

Array.prototype.last = function(): number {
    const [lastElement = -1] = this.slice(-1);
    return lastElement;
}
```

此实施使用带缺省值的 ES6 解构。它本质上与 `slice(-1)[0]` 版本相同，但具有不同的语法。

##### 实现 9：`findLast` 方法（适用于 ECMAScript 2022 及之后版本）

此版本使用 `Array.prototype.findLast()`，这是为 ECMAScript 2022 建议的一种方法，用于查找数组中满足所提供测试函数的最后一个元素。在这里，我们提供了一个始终返回 true 的函数，因此它将返回最后一个元素，如果数组为空，则返回 -1。

请注意，此解决方案可能在某些情况下不起作用，因为 `findLast()` 尚未得到广泛支持。请始终查看当前的 JavaScript 文档，了解其可用性和兼容性。如果要在不支持 `findLast()` 的环境中使用 `findLast()`，可以创建 polyfill：

```javascript
if (!Array.prototype.findLast) {
    Array.prototype.findLast = function(predicate) {
        for (let i = this.length - 1; i >= 0; i--) {
            if (predicate(this[i], i, this)) {
                return this[i];
            }
        }
        return undefined;
    };
}
```

以下是完整的解决方案，我们还包括 findLast() 的 polyfill，根据您的环境可能不需要：

```javascript
if (!Array.prototype.findLast) {
    Array.prototype.findLast = function(predicate) {
        for (let i = this.length - 1; i >= 0; i--) {
            if (predicate(this[i], i, this)) {
                return this[i];
            }
        }
        return undefined;
    };
}

Array.prototype.last = function() {
  return this.findLast(() => true) ?? -1;
}
```

```typescript
declare global {
    interface Array<T> {
        last(): T | -1;
        findLast(predicate: (value: T, index: number, obj: T[]) => unknown, thisArg?: any): T | undefined;
    }
}

if (!Array.prototype.findLast) {
    Array.prototype.findLast = function(predicate: (value: any, index: number, obj: any[]) => unknown) {
        for (let i = this.length - 1; i >= 0; i--) {
            if (predicate(this[i], i, this)) {
                return this[i];
            }
        }
        return undefined;
    };
}

Array.prototype.last = function(this: any[]): number {
    return this.findLast(() => true) ?? -1;
}
```

##### 复杂度分析

- 时间复杂度：$O(1)$。无论数组的大小如何，我们只访问数组的最后一个元素，这是一个恒定的时间操作。
- 空间复杂度：$O(1)$。这是因为我们没有使用任何随输入数组大小而扩展的额外空间。在空间复杂性分析中不考虑数组本身，因为它是函数的输入。我们只考虑该函数使用的任何额外空间。

需要注意的是，就时间和空间复杂性而言，将方法添加到阵列原型不会影响其他阵列，因为它不会为每个阵列重复该方法。相反，该方法驻留在原型中，并且可以由所有数组访问。这使得它成为一种高度节省空间的操作。

#### 方法 2：使用 ES6 Getters

##### 概述

在 JavaScript 中，getter 是获取特定属性的值的方法。在这里，我们将为最后一个属性创建一个 getter。

##### 算法

1. 通过为最后一个属性定义一个 getter来增强数组原型。
1. getter 函数将返回另一个函数，该函数返回数组的最后一个元素，如果数组为空，则返回 -1。

##### 实现

```javascript
Object.defineProperty(Array.prototype, 'last', {
  get: function() {
    return () => this.length ? this[this.length - 1] : -1;
  }
});
```

```typescript
declare global {
    interface Array<T> {
        last(): T | -1;
    }
}
Object.defineProperty(Array.prototype, 'last', {
    get: function() {
        return () => this.length ? this[this.length - 1] : -1;
    },
} as PropertyDescriptor);
```

当你定义一个 getter 时，你实际上是把 `last` 当作一个属性而不是一个函数。因此，它是通过 `array.last` 而不是 `array.last()` 访问的。如果您将数组的最后一个元素视为该数组的属性，而不是函数的结果，则这种观点在语义上会更清晰。Getter可以提供一种更精炼的、类似于属性的语法，以增强可读性，特别是当您要实现的操作不需要任何参数并且在概念上是一个属性时。

此外，当在大量使用 getter 和 setter 的代码库中工作时，使用 getter 可以提高一致性。然而，在您的特定问题的上下文中注意到这一点很重要：因为 getter 被视为一个属性，所以需要一个嵌套的函数来通过在线判断。这个附加层提供了一种与属性交互的方法，使评测机能够实现预期的适当功能。

##### 复杂度分析

- 时间复杂度：$O(1)$。在 JavaScript 中，访问数组中特定索引处的元素是一个恒定的时间操作。
- 空间复杂度：$O(1)$。不会使用额外的空间。
