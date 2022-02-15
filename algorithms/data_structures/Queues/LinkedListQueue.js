/* 
  In order to maintain an O(1) enqueue time complexity like .push with an array
  We add a tail to our linked list so we can go directly to the last node
*/

class Node {
  constructor(data) {
    this.data = data;
    this.next = null;
  }
}

class LinkedListQueue {
  constructor() {
    this.head = null;
    this.tail = null;
    this.size = 0;
  }

  /**
   * - Time: O(1) constant.
   * - Space: O(1) constant.
   * @returns {boolean} Indicates if the list is empty.
   */
  isEmpty() {
    return this.head === null;
  }

  /**
   * Adds a given val to the back of the queue.
   * - Time: O(1) constant.
   * - Space: O(1) constant.
   * @param {any} val
   * @returns {number} The new size of the queue.
   */
  enqueue(val) {
    const newTail = new Node(val);

    if (this.isEmpty()) {
      this.head = newTail;
      this.tail = newTail;
    } else {
      this.tail.next = newTail;
      this.tail = newTail;
    }
    // pre-increment so the new size is returned otherwise old size is returned
    return ++this.size;
  }

  /**
   * - Time: O(1) constant.
   * - Space: O(1) constant.
   * @returns {any} The removed item.
   */
  dequeue() {
    // remove head
    if (!this.head) {
      return null;
    }

    const dequeued = this.head;
    this.head = this.head.next;

    if (this.head === null) {
      this.tail = null;
    }

    this.size--;
    return dequeued.data;
  }

  /**
   * Retrieves the first item without removing it.
   * - Time: O(1) constant.
   * - Space: O(1) constant.
   * @returns {any} The first item.
   */
  front() {
    return this.head ? this.head.data : null;
  }
}
