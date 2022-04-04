const head = {
  data: 'hello',
  next: {
    data: 'world',
    next: {
      data: 'ben',
      next: null,
    },
  },
};

let runner = head;

while (runner.next !== null) {
  console.log(runner.data);
  runner = runner.next;
}

runner.next = { data: 'NEW', next: null };

console.log(head);

function recursiveTraverse(currentNode) {
  if (currentNode === null) {
    return;
  }

  console.log(currentNode.data);
  recursiveTraverse(currentNode.next);
}
