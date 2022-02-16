# [Data Structures](../data_structures) Algo Schedule

- Recursion review [Recursion Intro](../recursion/intro-notes/Recursion.md)

---

## [Week 1 - Singly Linked Lists](../data_structures/LinkedLists/SinglyLinkedList.js)

---

## [Week 2 - Stacks and Queues](../data_structures)

- [Stacks and Queues Intro](../data_structures/StacksAndQueues.md)
- [Stack](../data_structures/Stacks/Stack.js)

## W1 Mon

- A Stack is a LIFO (Last in First Out) data structure
- Design a class to represent a stack using an array to store the items
- Create these methods for each of the Stack classes with O(1) time complexity:
  - push (adds new item and returns new size)
  - pop (returns removed item)
  - isEmpty
  - size
  - peek (return top item without removing)
- Recreate the stack class using a singly linked list to store the items instead of an array

### W2 Tue

- [Queue.js](../data_structures/Queues/Queue.js)

- A Queue is a FIFO (First in First Out) data structure
- Design a class to represent a queue using an array to store the items.
- Recreate the queue class using a singly linked list to store the items.
- Create these methods for each classes:
  - enqueue (add item, return new size)
  - dequeue (remove and return item)
  - isEmpty
  - size
  - front (return first item without removing)
- Time complexities should be as follows:
  - Array Queue: enqueue: O(1), dequeue: O(n), size: O(1), front: O(1)
  - Linked List Queue: enqueue: O(1), dequeue: O(1), size: O(1), front: O(1)

### W2 Wed

- [Queue.js](../data_structures/Queues/Queue.js)

- compareQueues
  - Write a method on the Queue class that, given another queue, will return whether they are equal (same items in same order).
  - Use ONLY the provided queue methods, do not manually index the queue items via bracket notation, use no extra array or objects.
  - Restore the queues to their original state
- queueIsPalindrome
  - Write a method on the Queue class that returns whether or not the queue is a palindrome
  - Use only 1 stack as additional storage (no additional arrays / objects).
  - Do not manually index the queue via bracket notation, use the provided queue methods and stack methods, restore the queue to original order when done.
- Extra: MinStack
  - Design a stack that supports push, pop, top, and min methods where the min method retrieves the minimum int in the stack
  - Bonus: retrieve min element in constant time (no looping).