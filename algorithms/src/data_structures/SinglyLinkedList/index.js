/**
 * A class to represents a single item of a SinglyLinkedList that can be
 * linked to other Node instances to form a list of linked nodes.
 */
class ListNode {
  /**
   * Constructs a new Node instance. Executed when the 'new' keyword is used.
   * @param {any} data The data to be added into this new instance of a Node.
   *    The data can be anything, just like an array can contain strings,
   *    numbers, objects, etc.
   * @returns {ListNode} A new Node instance is returned automatically without
   *    having to be explicitly written (implicit return).
   */
  constructor(data) {
    this.data = data;
    /**
     * This property is used to link this node to whichever node is next
     * in the list. By default, this new node is not linked to any other
     * nodes, so the setting / updating of this property will happen sometime
     * after this node is created.
     *
     * @type {ListNode|null}
     */
    this.next = null;
  }
}

/**
 * This class keeps track of the start (head) of the list and to store all the
 * functionality (methods) that each list should have.
 */
class SinglyLinkedList {
  /**
   * Constructs a new instance of an empty linked list that inherits all the
   * methods.
   * @returns {SinglyLinkedList} The new list that is instantiated is implicitly
   *    returned without having to explicitly write "return".
   */
  constructor() {
    /** @type {ListNode|null} */
    this.head = null;
  }

  /**
   * Concatenates the nodes of a given list onto the back of this list.
   * - Time: O(n) n = "this" list length -> O(n) linear.
   *    addList does not need to be looped over.
   * - Space: O(1) constant, although this list grows by addList's length,
   *    our algo doesn't create extra objects or arrays to take up more space.
   * @param {SinglyLinkedList} addList An instance of a different list whose
   *    whose nodes will be added to the back of this list.
   * @returns {SinglyLinkedList} This list with the added nodes.
   */
  concat(addList) {
    let runner = this.head;

    if (runner === null) {
      this.head = addList.head;
    } else {
      while (runner.next) {
        runner = runner.next;
      }
      runner.next = addList.head;
    }
    return this;
  }

  /**
   * Reverses this list in-place without using any extra lists.
   * - Time: O(n) linear, n = list length.
   * - Space: O(1) constant.
   * @returns {SinglyLinkedList} This list.
   */
  reverse() {
    /*
      Each iteration we cut out current's next node to make it the new head
      iteration-by-iteration example:
      1234 -> initial list, 'current' is 1, next is 2.
      2134 -> 'current' is still 1, next is 3.
      3214
      4321
    */
    if (!this.head || !this.head.next) {
      return this;
    }

    let current = this.head;

    while (current.next) {
      const newHead = current.next;
      // cut the newHead out from where it currently is
      current.next = current.next.next;
      newHead.next = this.head;
      this.head = newHead;
    }
    return this;
  }

  reverse2() {
    let prev = null;
    let node = this.head;

    while (node) {
      const nextNode = node.next;
      node.next = prev;
      prev = node;
      node = nextNode;
    }
    this.head = prev;
    return this;
  }

  /**
   * Determines whether the list has a loop in it which would result in
   * infinitely traversing unless otherwise avoided. A loop is when a node's
   * next points to a node that is behind it.
   * - Time: O(n) linear, n = list length.
   * - Space: O(1) constant.
   * @returns {boolean} Whether the list has a loop or not.
   */
  hasLoop() {
    /**
      APPROACH:
      two runners are sent out and one runner goes faster so it will
      eventually 'lap' the slower runner if there is a loop, 
      at the moment faster runner laps slower runner, they are at the same
      place, aka same instance of a node.
    */
    if (!this.head) {
      return false;
    }

    let fasterRunner = this.head;
    let runner = this.head;

    while (fasterRunner && fasterRunner.next) {
      runner = runner.next;
      fasterRunner = fasterRunner.next.next;

      if (runner === fasterRunner) {
        return true;
      }
    }
    return false;
  }

  /**
   * Determines whether the list has a loop in it which would result in
   * infinitely traversing unless otherwise avoided.
   * In a normal object, the keys cannot be other objects, but in a Map object,
   * they can be. We can't use the .data as the keys in a normal object because
   * that would could cause hasLoop to return a false positive when there are
   * nodes with duplicate data but no loop.
   * - Time: O(n) linear, n = list length.
   * - Space: O(n) linear due to the Map.
   * @returns {boolean} Whether the list has a loop or not.
   */
  hasLoopMap() {
    if (this.isEmpty()) {
      return false;
    }

    const seenMap = new Map();
    let runner = this.head;

    while (runner) {
      if (seenMap.has(runner)) {
        return true;
      }
      seenMap.set(runner, true);
      runner = runner.next;
    }
    return false;
  }

  /**
   * Determines whether the list has a loop in it which would result in
   * infinitely traversing unless otherwise avoided.
   * This approaches adds a seen key to the nodes, then removes them when done.
   * - Time: O(2n) -> O(n) linear. The 2nd loop is to remove the extra seen key
   *    that was added.
   * - Space: O(n) because "seen" key is being stored n times.
   * @returns {boolean} Whether the list has a loop or not.
   */
  hasLoopSeen() {
    if (this.isEmpty()) {
      return false;
    }

    let runner = this.head;
    let hasLoop = false;

    while (runner) {
      if (runner.hasOwnProperty('seen')) {
        hasLoop = true;
        break;
      } else {
        runner.seen = true;
      }
      runner = runner.next;
    }

    runner = this.head;

    while (runner && runner.hasOwnProperty('seen')) {
      delete runner.seen;
      runner = runner.next;
    }
    return hasLoop;
  }

  /**
   * Removes all the nodes that have a negative integer as their data.
   * - Time: O(n) linear, n = list length.
   * - Space: O(1) constant.
   * @returns {SinglyLinkedList} This list after the negatives are removed.
   */
  removeNegatives() {
    if (this.isEmpty()) {
      return this;
    }

    let runner = this.head;

    // get rid of all negatives at start so head will be positive, or null
    while (runner && runner.data < 0) {
      runner = runner.next;
    }

    this.head = runner;

    //  head may have become null, that's why we check runner && runner.next
    while (runner && runner.next) {
      if (runner.next.data < 0) {
        runner.next = runner.next.next;
      } else {
        runner = runner.next;
      }
    }
    return this;
  }

  /**
   * Finds the node with the smallest number as data and moves it to the front
   * of this list.
   * - Time: O(2n) n = list length -> O(n) linear,
   *    2nd loop could go to end if min is at end.
   * - Space: O(1) constant.
   * @returns {SinglyLinkedList} This list.
   */
  moveMinFront() {
    /* 
      Alternatively, we could swap the data only in min node and head,
      but it's better to swap the nodes themselves in case anyone has variables
      pointing to these nodes already so that we don't unexpectedly change the
      the data in those nodes potentially causing unwanted side-effects.
    */
    if (this.isEmpty()) {
      return this;
    }

    let minNode = this.head;
    let runner = this.head;
    let prev = this.head;

    while (runner) {
      if (runner.data < minNode.data) {
        minNode = runner;
      }

      runner = runner.next;
    }
    // now that we know the min, if it is already the head, nothing needs to be done
    if (minNode === this.head) {
      return this;
    }

    runner = this.head;

    while (runner !== minNode) {
      prev = runner;
      runner = runner.next;
    }

    prev.next = minNode.next; // remove the minNode
    minNode.next = this.head;
    this.head = minNode;
    return this;
  }

  /**
   * Finds the node with the smallest data and moves it to the front of
   * this list.
   * - Time: O(n) linear, n = list length. This avoids the extra loop in
   *    the above sln.
   * - Space: O(n) linear.
   * @returns {SinglyLinkedList} This list.
   */
  moveMinToFront() {
    if (this.isEmpty()) {
      return this;
    }

    let minNode = this.head;
    let runner = this.head;
    let prev = this.head;

    while (runner.next) {
      if (runner.next.data < minNode.data) {
        prev = runner;
        minNode = runner.next;
      }

      runner = runner.next;
    }

    if (minNode === this.head) {
      return this;
    }

    prev.next = minNode.next;
    minNode.next = this.head;
    this.head = minNode;
    return this;
  }

  /**
   * Retrieves the data of the second to last node in this list.
   * - Time: O(n - 1) n = list length -> O(n) linear.
   * - Space: O(1) constant.
   * @returns {any} The data of the second to last node or null if there is no
   *    second to last node.
   */
  secondToLast() {
    if (!this.head || !this.head.next) {
      return null;
    }

    // There are at least 2 nodes since the above return hasn't happened.
    let runner = this.head;

    while (runner.next.next) {
      runner = runner.next;
    }
    return runner.data;
  }

  /**
   * Removes the node that has the given val.
   * - Time: O(n) linear, n = list length since the last node could be the one
   *    that is removed.
   * - Space: O(1) constant.
   * @param {any} val The value to compare to the node's data to find the
   *    node to be removed.
   * @returns {boolean} Indicates if a node was removed or not.
   */
  removeVal(val) {
    if (this.isEmpty()) {
      return false;
    }

    if (this.head.data === val) {
      this.removeHead();
      return true;
    }

    let runner = this.head;

    while (runner.next) {
      if (runner.next.data === val) {
        runner.next = runner.next.next;
        return true;
      }
      runner = runner.next;
    }
    return false;
  }

  /**
   * Removes the last node of this list.
   * - Time: O(n) linear, n = length of list.
   * - Space: O(1) constant.
   * @returns {any} The data from the node that was removed.
   */
  removeBack() {
    if (this.isEmpty()) {
      return null;
    }

    // Only 1 node.
    if (this.head.next === null) {
      return this.removeHead();
    }

    // More than 1 node.
    let runner = this.head;

    while (runner.next.next) {
      runner = runner.next;
    }

    // after while loop finishes, runner is now at 2nd to last node
    const removedData = runner.next.data;
    runner.next = null; // remove it from list
    return removedData;
  }

  /**
   * This version uses more conditions instead of more returns. It is a good
   * example of how more returns can make the code easier to read and cleaner.
   * Removes the last node of this list.
   * - Time: O(n) linear, n = length of list.
   * - Space: O(1) constant.
   * @returns {any} The data from the node that was removed.
   */
  removeBack2() {
    let removedData = null;

    if (!this.isEmpty()) {
      if (this.head.next === null) {
        // head only node
        removedData = this.removeHead();
      } else {
        let runner = this.head;
        // right of && will only be checked if left is true
        while (runner.next && runner.next.next) {
          runner = runner.next;
        }

        // after while loop finishes, runner is now at 2nd to last node
        removedData = runner.next.data;
        runner.next = null; // remove it from list
      }
    }
    return removedData;
  }

  /**
   * Determines whether or not the given search value exists in this list.
   * - Time: O(n) linear, n = length of list.
   * - Space: O(1) constant.
   * @param {any} val The data to search for in the nodes of this list.
   * @returns {boolean}
   */
  contains(val) {
    let runner = this.head;

    while (runner) {
      if (runner.data === val) {
        return true;
      }
      runner = runner.next;
    }
    return false;
  }

  /**
   * Determines whether or not the given search value exists in this list.
   * - Time: O(n) linear, n = length of list.
   * - Space: O(n) linear due to the call stack.
   * @param {any} val The data to search for in the nodes of this list.
   * @param {?node} current The current node during the traversal of this list
   *    or null when the end of the list has been reached.
   * @returns {boolean}
   */
  containsRecursive(val, current = this.head) {
    if (current === null) {
      return false;
    }
    if (current.data === val) {
      return true;
    }
    return this.containsRecursive(val, current.next);
  }

  /**
   * Creates a new node with the given data and inserts that node at the front
   * of the list.
   * - Time: O(1) constant.
   * - Space: O(1) constant.
   * @param {any} data The data for the new node.
   * @returns {SinglyLinkedList} This list.
   */
  insertAtFront(data) {
    const newHead = new ListNode(data);
    newHead.next = this.head;
    this.head = newHead;
    return this;
  }

  /**
   * Removes the first node of this list.
   * - Time: O(1) constant.
   * - Space: O(1) constant.
   * @returns {any} The data from the removed node.
   */
  removeHead() {
    if (this.isEmpty()) {
      return null;
    }

    const oldHead = this.head;
    this.head = oldHead.next;
    return oldHead.data;
  }

  /**
   * Calculates the average of this list.
   * - Time: O(n) linear, n = length of list.
   * - Space: O(1) constant.
   * @returns {number|NaN} The average of the node's data.
   */
  average() {
    let runner = this.head;
    let sum = 0;
    let cnt = 0;

    while (runner) {
      cnt++;
      sum += runner.data;
      runner = runner.next;
    }

    /**
     * Dividing by 0 will give you NaN (Not a Number), so an empty list
     * will return NaN in this case, it may make sense to allow NaN to be
     * returned, because the average of an empty list doesn't make sense and
     * it could be misleading to return 0 since 0 is the average of any
     * list with a sum of 0 (due to negatives or all zeros).
     */
    return sum / cnt;
  }

  /**
   * Determines if this list is empty.
   * - Time: O(1) constant.
   * - Space: O(1) constant.
   * @returns {boolean}
   */
  isEmpty() {
    return this.head === null;
  }

  /**
   * Creates a new node with the given data and inserts it at the back of
   * this list.
   * - Time: O(n) linear, n = length of list.
   * - Space: O(1) constant.
   * @param {any} data The data to be added to the new node.
   * @returns {SinglyLinkedList} This list.
   */
  insertAtBack(data) {
    const newBack = new ListNode(data);

    if (this.isEmpty()) {
      this.head = newBack;
      return this;
    }

    let runner = this.head;

    while (runner.next !== null) {
      runner = runner.next;
    }

    runner.next = newBack;
    return this;
  }

  /**
   * Creates a new node with the given data and inserts it at the back of
   * this list.
   * - Time: O(n) linear, n = length of list.
   * - Space: O(n) linear due to the call stack.
   * @param {any} data The data to be added to the new node.
   * @param {?ListNode} runner The current node during the traversal of this list
   *    or null when the end of the list has been reached.
   * @returns {SinglyLinkedList} This list.
   */
  insertAtBackRecursive(data, runner = this.head) {
    if (this.isEmpty()) {
      this.head = new ListNode(data);
      return this;
    }

    if (runner.next === null) {
      runner.next = new ListNode(data);
      return this;
    }
    return this.insertAtBackRecursive(data, runner.next);
  }

  /**
   * Calls insertAtBack on each item of the given array.
   * - Time: O(n * m) n = list length, m = arr.length.
   * - Space: O(1) constant.
   * @param {Array<any>} vals The data for each new node.
   * @returns {SinglyLinkedList} This list.
   */
  insertAtBackMany(vals) {
    for (const item of vals) {
      this.insertAtBack(item);
    }
    return this;
  }

  /**
   * Converts this list into an array containing the data of each node.
   * - Time: O(n) linear.
   * - Space: O(n).
   * @returns {Array<any>} An array of each node's data.
   */
  toArr() {
    const arr = [];
    let runner = this.head;

    while (runner) {
      arr.push(runner.data);
      runner = runner.next;
    }
    return arr;
  }
}

/******************************************************************* 
Multiple test lists already constructed to test your methods on.
Below commented code depends on insertAtBack method to be completed,
after completing it, uncomment the code.
*/
const emptyList = new SinglyLinkedList();

const singleNodeList = new SinglyLinkedList().insertAtBackMany([1]);
const biNodeList = new SinglyLinkedList().insertAtBackMany([1, 2]);
const firstThreeList = new SinglyLinkedList()
  .insertAtBack(1)
  .insertAtBack(2)
  .insertAtBack(3);
const secondThreeList = new SinglyLinkedList().insertAtBackMany([4, 5, 6]);
const unorderedList = new SinglyLinkedList().insertAtBackMany([
  -5, -10, 4, -3, 6, 1, -7, -2,
]);

/* node 4 connects to node 1, back to head */
// const perfectLoopList = new SinglyLinkedList().insertAtBackMany([1, 2, 3, 4]);
// perfectLoopList.head.next.next.next = perfectLoopList.head;

/* node 4 connects to node 2 */
// const loopList = new SinglyLinkedList().insertAtBackMany([1, 2, 3, 4]);
// loopList.head.next.next.next = loopList.head.next;

// const sortedDupeList = new SinglyLinkedList().insertAtBackMany([
//   1, 1, 1, 2, 3, 3, 4, 5, 5,
// ]);

// Print your list like so:
console.log(firstThreeList.toArr());
