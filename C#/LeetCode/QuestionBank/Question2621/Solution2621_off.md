### [睡眠函数](https://leetcode.cn/problems/sleep/solutions/2506139/shui-mian-han-shu-by-leetcode-solution-vuse/)

#### 解决方案

##### 概述

这个问题涉及到异步编程的概念，具体来说，它关注了 promises 和 `setTimeout` 函数，后者是一种在代码执行中引入延迟的 Web API 方法。

在 JavaScript 中，Promise 是一个表示异步操作最终完成或失败的对象。它本质上是一个返回的对象，你可以附加回调函数，而不是将回调传递给函数。

```javascript
let promise = new Promise((resolve, reject) => {
    let condition = true; // 这可以是某个操作的结果

    // 1秒后检查条件并解决或拒绝 Promise
    setTimeout(() => {
        if (condition) {
            resolve('Promise 已完成！');
        } else {
            reject('Promise 被拒绝！');
        }
    }, 1000);
});

// 将 then() 和 catch() 处理程序附加到 Promise
promise
    .then(value => {
        // 如果 Promise 已解决，则执行此操作
        console.log(value); // 输出: Promise 已完成！
    })
    .catch(error => {
        // 如果 Promise 被拒绝，则执行此操作
        console.log(error);
    });
```

在这个示例中，创建了一个 Promise，它将在 1 秒后解决或拒绝，具体取决于条件的值。如果 Promise 成功，将调用 resolve 函数；如果 Promise 失败，将调用 reject 函数。

当 Promise 解决时，then 方法被调用，并接收传递给 resolve 函数的值。类似地，当 Promise 被拒绝时，catch 方法被调用，并接收传递给 reject 函数的值。

##### setTimeout 和事件循环

setTimeout 函数在这个问题中发挥了关键作用。它是一个方法，调用一个函数或在指定的毫秒数后评估一个表达式。在 JavaScript 中，setTimeout 用于延迟代码的执行。

```javascript
console.log("启动定时器...");

setTimeout(() => {
    console.log("定时已完成！");
}, 2000);
```

在这个示例中，“启动定时器...”将立即记录到控制台。然后，调用 setTimeout 函数，传递两个参数：一个回调函数和以毫秒为单位的延迟。回调函数是一个简单的箭头函数，用于将 “定时已完成！”记录到控制台，延迟为 2000 毫秒（或2秒）。

一旦调用了 `setTimeout`，JavaScript 运行时设置了定时器，但随后立即继续执行任何后续代码。它不会暂停或等待定时器完成，这展示了 JavaScript 的非阻塞特性。

在指定的延迟之后（在本例中为2秒），将回调函数添加到任务队列中。但重要的是要注意，回调函数不一定会在此刻立即执行。回调函数实际执行之前的实际延迟可能会比指定的延迟稍长。这是由于事件驱动的 JavaScript 运行时和单线程事件循环的性质所决定的。

假设主 JavaScript 线程中有一个耗时较长的进程或操作。在这种情况下，即使定时器在后台完成，回调函数仍必须等待阻塞任务的完成。这是因为事件循环一次只能处理一个任务，并按照排队的顺序处理任务。

因此，setTimeout 中指定的“2 秒”应被理解为在调用回调函数之前的 “最小延迟”，而不是 “保证延迟”。如果 JavaScript 运行时正忙于其他任务，回调函数实际执行的时间可能会超过 2 秒。这种行为强调了理解 JavaScript 异步性质的重要性，因为它对代码的性能和行为产生重大影响。

另外，值得一提的是 `clearTimeout`，这是 JavaScript 定时器函数套件中的一个有用函数。`clearTimeout` 是一个函数，它取消了先前通过调用 `setTimeout` 建立的定时器。

下面是它的使用示例：

```javascript
console.log("启动定时器...");

// setTimeout 返回一个 Timeout 对象，可用于引用定时器
let timeoutId = setTimeout(() => {
    console.log("定时已完成！");
}, 2000);

// 一些条件或逻辑
if (/* 一些条件 */) {
    // 取消定时器
    clearTimeout(timeoutId);
}
```

如果 if 语句内部的条件为真，那么 clearTimeout 函数将取消通过 setTimeout 设置的定时器。如果取消了定时器，setTimeout 提供的函数将不会被调用。

这在各种场景中很有用，例如，如果要在操作执行之前检查用户是否仍然活跃在页面上，但用户在延迟结束之前导航到其他页面，你可以使用 clearTimeout 来取消检查。

#### JavaScript 的事件循环

JavaScript 使用调用堆栈来管理函数的执行。当调用函数时，它会被添加到堆栈中。当函数完成时，它会从堆栈中移除。由于 JavaScript 是单线程的，一次只能执行一个函数。

然而，如果一个函数需要较长时间才能执行（例如网络请求），这可能会有问题。这就是事件循环的用武之地。

事件循环是一个持续的循环，检查调用堆栈是否为空。如果为空，它会从任务队列（也称为事件队列或回调队列）中获取第一个任务并将其推送到调用堆栈中，立即执行它。

##### 异步回调

setTimeout 是 JavaScript 中的异步函数示例。当调用 setTimeout 函数时，它会启动一个定时器，然后立即返回，允许 JavaScript 运行时在等待定时器完成的同时继续执行其他代码。这是 JavaScript 的非阻塞特性。

一旦定时器完成，给 setTimeout 提供的回调函数将添加到任务队列中。事件循环不断检查调用堆栈和任务队列。当调用堆栈为空时，它会从任务队列中获取第一个任务并将其推送到调用堆栈中以执行。

##### 并发和事件循环

以下是 JavaScript 如何处理并发操作的方式：

1. JavaScript 运行一段代码（此代码在主线程上运行）。
1. 当遇到异步操作（如 setTimeout、fetch 等）时，JavaScript 将其启动，然后继续运行其余代码。它不会等待异步操作完成。这些异步操作可能在后台运行，但不会运行在主 JavaScript 线程上。
1. 当异步操作完成时，其回调函数将被放入任务队列中。
1. 一旦调用堆栈为空（即，当前事件循环的所有代码都已执行完毕），事件循环将从任务队列中获取第一个任务并将其推送到调用堆栈中，以立即执行它。

这个过程继续进行，事件循环会在调用堆栈为空时将任务从任务队列中推送到调用堆栈，从而使 JavaScript 能够处理多个操作，尽管它是单线程的。

这是 JavaScript 处理异步操作的高级概述。实际上更复杂，还涉及微任务和宏任务等附加特性，但这是其基本概念。

#### 问题：创建一个“sleep”函数

这个问题需要创建一个函数，模拟一个延迟，通常在编程中称为 “sleep” 函数。这个函数利用了 `promises` 和 `setTimeout`，以创建一个异步延迟，返回一个在指定时间后解决的 promise。

这些概念在 JavaScript 编程中占据了重要地位，尤其是在某些操作需要在不停止其余代码执行的情况下暂停或延迟执行时。了解如何将 `setTimeout` 和 `promises` 结合使用是许多实际应用程序（如限制 API 请求速率或管理用户交互）中的重要技能。

为了简化与 `promises` 的工作，JavaScript 提供了 `async` 和 `await` 关键字，允许你编写看起来和行为更像同步代码的异步代码。`async` 关键字用于声明异步函数。当调用时，异步函数返回一个 `promise`。当异步函数返回一个值时，该 `promise` 将被该值解决。如果异步函数引发异常，该 `promise` 将被引发的值拒绝。

以下是一个 `async` 函数的简单示例：

```javascript
async function foo() {
  return 'Hello, World!';
}

foo().then(message => console.log(message)); // 输出 'Hello, World!'
```

`foo` 函数使用 `async` 关键字声明，这意味着它返回一个 `promise`。当调用 `foo` 时，它返回一个 `promise`，该 `promise` 立即以值 `Hello, World!` 解决。由异步函数返回的 `promise` 可以使用 `.then` 方法安排代码在 `promise` 解决后运行，或者使用 `await` 关键字在 `promise` 解决后暂停异步函数的执行。请注意，尽管 `async` 函数使异步代码看起来和行为更像同步代码，但它们仍然是非阻塞的。JavaScript 运行时可以在等待异步函数返回的 `promise` 解决时继续执行其他工作。

下面是一个具体的示例，展示了如何使用异步编程处理用户交互。考虑一个网页，用户可以单击按钮以从服务器加载数据，例如要显示的项目列表。当用户单击按钮时，你不希望在等待服务器响应时冻结整个页面。相反，你希望以异步方式处理请求。下面是如何实现这个操作的示例：

```javascript
// 'async' 关键字允许在函数内部使用 'await'
button.addEventListener('click', async () => {
    // 显示加载旋转器
    spinner.style.display = 'block';

    try {
        // 从服务器获取数据
        let response = await fetch('https://api.example.com/items');

        // 解析 JSON 响应
        let items = await response.json();

        // 使用新项目更新用户界面
        displayItems(items);
    } catch (error) {
        // 处理任何错误
        console.error('错误：', error);
    } finally {
        // 隐藏加载旋转器
        spinner.style.display = 'none';
    }
});
```

在此示例中，当用户单击按钮时，浏览器将发送请求以获取数据。fetch 函数返回一个 promise，该 promise 解析为表示请求响应的 response 对象。通过使用 `await` 关键字，我们能够编写看似同步但实际上是异步运行的代码。这意味着浏览器可以在等待服务器响应时继续处理其他任务，比如处理用户输入或动画。一旦从服务器接收到数据，它被解析为 JSON（也返回一个 promise），然后使用新项目更新用户界面。如果在此过程中发生任何问题，错误将被捕获并记录到控制台。最后，无论请求是否成功，加载旋转器都将被隐藏。在这种情况下，用户交互是按钮单击，但数据的获取和用户界面的更新是异步处理的。

##### Async/await

Async/await 可以被看作是 Promise 的语法糖，它使异步代码更易于编写和理解。当我们使用 `async` 关键字标记函数时，它将成为一个自动返回 promise 的异步函数。在异步函数中，我们可以使用 `await` 关键字暂停代码的执行，直到 promise 解决或拒绝。

通过使用 `await`，我们可以消除使用 promises 时通常需要的明确的 `.then()` 和 `.catch()` 链。相反，我们可以以更线性和类似同步代码的方式构建代码。这使得更容易理解程序的流程并以更简洁的方式处理错误。

示例：

```javascript
// 使用 promises 和显式的 .then() 和 .catch()
fetchData()
  .then(response => {
    // 处理响应
    console.log("响应：", response);
    return processData(response);
  })
  .then(result => {
    // 处理处理后的数据
    console.log("处理后的数据：", result);
  })
  .catch(error => {
    // 处理任何错误
    console.error("错误：", error);
  });

// 使用 async/await
async function fetchDataAndProcess() {
  try {
    const response = await fetchData();
    console.log("响应：", response);

    const result = await processData(response);
    console.log("处理后的数据：", result);
  } catch (error) {
    console.error("错误：", error);
  }
}

fetchDataAndProcess();
```

通过使用明确的 `.then()` 和 `.catch()` 链，我们必须分别处理异步操作的每个步骤。当涉及多个 `promises` 时，可能会变得复杂，从而导致嵌套或链接的 `.then()` 调用。此外，错误处理需要单独的 `.catch()` 块。

相比之下，第二个示例使用 async/await 在更线性和类似同步代码的方式中构建代码。`fetchDataAndProcess()` 函数标记为 `async`，允许我们在其中使用 `await` 关键字。这消除了明确的 `.then()` 和 `.catch()` 链的需要。

在底层，`await` 关键字会暂停函数的执行，使其他任务继续执行，比如处理用户输入或动画。JavaScript 引擎会切换到执行其他代码，直到由异步函数返回的 promise 解决，然后它将恢复异步函数中的其余代码的执行。

#### Promise 链式编程

Promise 链式编程是 JavaScript 中的一种技术，允许你按顺序执行多个异步操作，每个操作在前一个操作完成后启动。Promise 链的主要优点是，它允许你避免使用嵌套回调来处理异步代码时的 “回调地狱” 或 “回调金字塔”。相反，你可以编写几乎看起来像同步代码的异步代码，从而更容易理解和维护。Promise 链中的每个 `then` 方法都会接收上一个 promise 解决的结果。此结果可以用来通知链中的下一个步骤。如果链中的 promise 被拒绝，后续的 `then` 方法将被跳过，直到找到 `catch` 方法来处理错误。

```javascript
fetchData()
  .then(response => {
    console.log("响应：", response);
    return processData(response);  // 这返回一个新的 promise
  })
  .then(processedData => {
    console.log("处理后的数据：", processedData);
    return furtherProcessing(processedData);  // 这返回另一个新的 promise
  })
  .then(finalResult => {
    console.log("最终结果：", finalResult);
  })
  .catch(error => {
    console.error("错误：", error);
  });
```

`fetchData`、`processData` 和 `furtherProcessing` 都是异步函数，返回 promises。then 方法被链接在一起，每个 then 在前一个 promise 解决后开始其操作。如果链中的任何 promise 被拒绝，将调用最后的 catch 方法来处理错误。

##### 理解 .finally

在 JavaScript 中，Promises 提供了处理异步操作及其结果的几种强大方法之一就是 `.finally` 方法。`.finally` 方法是 Promise 的内置方法，它始终会执行，无论 promise 是否被解决。这使得它成为放置无论 promise 结果如何都必须运行的清理代码的绝佳位置。

```javascript
let isLoading = true;

fetch('https://api.example.com/data')
  .then(response => {
    if (!response.ok) {
      throw new Error('网络响应不正常');
    }
    return response.json();
  })
  .then(data => console.log(data))
  .catch(error => console.error('错误：', error))
  .finally(() => {
    isLoading = false;
    console.log('获取操作完成');
  });
```

在这里，我们使用 `fetch`（返回一个 promise）从 URL 获取数据。然后，我们使用 `.then` 处理响应，并使用 `.catch` 处理任何错误。最后，无论获取操作是否成功，都会调用 `.finally` 以将 `isLoading` 设置为 `false` 并在控制台上记录一条消息。

#### 理解异步函数中的 promise 返回

在解决这个问题时，可能会派上用场的一个有趣事实是，在异步函数中，无论你是返回 `return new Promise()` 还是 `return await new Promise()`，行为通常是相同的。这是因为异步函数始终将返回值包装在 `promise` 中。然而，在某些情况下，如错误处理，使用 `await` 可能会有所不同。

思考下面的示例：

```javascript
async function example() {
    try {
        return new Promise((resolve, reject) => {
            throw new Error('糟糕！');
        });
    } catch (err) {
        console.error(err);
    }
}

example(); // 错误不会被捕获，它拒绝了 example 返回的 promise。

async function example2() {
    try {
        return await new Promise((resolve, reject) => {
            throw new Error('糟糕！');
        });
    } catch (err) {
        console.error(err);
    }
}

example2(); // 错误被捕获，example2 返回的 promise 被解决。
```

在 `example` 函数中，try 块不会捕获 promise 引发的错误，因为 promise 在引发错误之前就已经返回了。在 `example2` 中，`await` 会导致函数等待 promise 完成或抛出错误，因此它可以捕获 promise 引发的错误。

在给定的问题中，您的任务是创建一个异步函数 `sleep(millis)`，该函数旨在将执行暂停指定的毫秒数。下面让我们来探索一下如何实现这一点。

#### 方法 1：使用 Promises 和 setTimeout 的异步编程

##### 概述

在 JavaScript 中，通常使用承诺来处理异步操作。承诺表示一个值，该值可能还不可用，但将在将来的某个时候解决(或在出错的情况下拒绝)。要在 JavaScript 中模拟延迟或“休眠”，我们可以使用 setTimeout 函数，该函数将一个函数调度为在一段时间后运行。

该任务要求我们创建一个休眠指定毫秒的异步函数。要实现这一点，我们可以将 promises 与 setTimeout 结合起来。我们将返回在指定延迟后解决的承诺。

##### 算法步骤

1. 定义一个名为 `sleep(millis)` 的异步函数。此函数在解析之前将暂停执行 `millis` 毫秒。
1. 在该函数内部，构造一个新的 promise 对象。这个 promise 对象的 `executor` 函数是我们将合并延迟的地方。
1. 在 `executor` 函数中，使用 `setTimeout` 方法。`setTimeout` 是由主机环境(Web 浏览器、Node.js等)提供的方法。它在指定的延迟后执行提供的函数或代码段。
1. 将 `setTimeout` 的延迟设置为 `millis` 毫秒。延迟后执行的代码将是 promise 的 `resolve` 方法。
1. 当调用 resolve 方法时，它会将承诺标记为已实现，从而允许执行任何附加的 `.then` 处理程序。

##### 实现

```javascript
async function sleep(millis) {
  return new Promise(resolve => {
    setTimeout(resolve, millis);
  });
}
```

```typescript
async function sleep(millis: number): Promise<void> {
    return new Promise<void>(resolve => {
        setTimeout(resolve, millis);
    });
}
```

在此实现中，`sleep` 函数是返回 promise 的异步函数。promise 的 `executor` 函数使用 `setTimeout` 在 `millis` 毫秒后解析 promise。请注意，我们实际上并不需要将睡眠功能设置为异步，因为我们直接返回一个 promise，但将其标记为 `async` 并不会有什么坏处。

你可以像这样在你的代码中使用 sleep 函数：

```javascript
let t = Date.now();
sleep(100).then(() => {
    console.log(Date.now() - t); // 大约 100
});
```

在这种用法中，我们记录当前时间，调用 sleep 函数，然后记录 promise 解析时经过的时间。运行时间应该大致等于 sleep 的输入，这表明函数确实已经“休眠”了指定的时间量。

请注意，使用 `return new Promise()` 或 `return await new Promise()` 都会在异步函数中产生相同的结果，如概述部分所述。

此外，使用 `try {} catch(){}` 也是异步编程中的一种常见做法，因为它允许您处理可能引发的任何潜在异常。在下面的解决方案中，如果在 setTimeout 函数的执行过程中出现错误，则 promise 被拒绝，并抛出错误：

```javascript
async function sleep(millis) {
  return new Promise((res,rej) => {
    try {
      setTimeout(() => res(5), millis)
    } catch(err) {
      rej(err)
    }
  })
}
```

```typescript
async function sleep(millis: number): Promise<void> {
  return new Promise((res, rej) => {
    try {
      setTimeout(() => res(), millis)
    } catch(err) {
      rej(err)
    }
  })
}
```

##### 复杂度分析

- 时间复杂度：$O(1)$。该函数的时间复杂度为 $O(1)$，因为无论输入什么，计算量都保持不变。然而，函数完成或完成所用的实际时间可能有所不同，因为它涉及启动计时器和返回承诺，这与输入大小没有直接关系，而是与正在执行的特定任务有关。
- 空间复杂度：$O(1)$。该函数使用恒定的空间来存储 promise 和计时器。这不会随着输入值的变化而改变。

#### 方法 2：使用 Promises 和 setTimeout 不带返回的异步编程

这种方法与第一种方法类似，但略有不同：对于这个问题，您不需要显式返回任何内容。这也使以下代码成为有效的解决方案。此版本的 `sleep` 函数不返回任何内容(或者更准确地说，它返回 `undefined`)，因为没有返回语句。但由于问题陈述说，“它可以求解任何值”，这是完全可以接受的。这也是一个非常有效的俏皮话。

##### 实现

```javascript
async function sleep(milliseconds) {
    await new Promise(res => setTimeout(res, milliseconds)); 
}
```

```typescript
async function sleep(milliseconds: number): Promise<void> {
    await new Promise<void>(resolve => setTimeout(resolve, milliseconds));
}
```

##### 复杂度分析

- 时间复杂度：$O(1)$。该函数的时间复杂度为 $O(1)$，因为无论输入什么，计算量都保持不变。然而，函数完成或完成所用的实际时间可能有所不同，因为它涉及启动计时器和返回 promise，这与输入大小没有直接关系，而是与正在执行的特定任务有关。
- 空间复杂度：$O(1)$。该函数使用恒定的空间来存储 promise 和计时器。这不会随着输入值的变化而改变。
