const list = [1,2,3,4,5];

let currentIdx = 0;
let currentItem = list[currentIdx];

while (currentItem !== undefined) {
  console.log(currentItem);
  currentIdx = currentIdx + 1;
  currentItem = list[currentIdx];
}

const linkedList = {
  head: {
    data: 1,
    next: {
      data: 2,
      next: {
        data: 3,
        next: {
          data: 4,
          next: null
        }
      }
    }
  }
};

console.log(linkedList);

let runner = linkedList.head;

while (runner.next !== null) {
  console.log(runner.data);
  runner = runner.next;
}

console.log(runner);
runner.next = { data: 5, next: null }
console.log(runner);