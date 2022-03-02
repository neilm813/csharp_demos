/**
 * Adds two numbers together.
 * @param {number} a
 * @param {number} b
 * @returns {number|NaN} The sum.
 */
function add(a, b) {
  return a + b;
}

/* Naive unit testing */
// console.log(add(1, 2), 'should equal', 3);
// console.log(add(5, 5), 'should equal', 10);
// console.log(add(-5, 5), 'should equal', 0);

/* Still naive, but better because it causes a more noticeable error */
// const test1 = add(1, 2);
// const test2 = add(5, 5);
// const test3 = add(-5, 5);

// const errors = [];

// if (test1 !== 3) {
//   errors.push(new Error(`expected ${test1} to equal 3`));
// }

// if (test2 !== 10) {
//   errors.push(new Error(`expected ${test2} to equal 10`));
// }

// if (test3 !== 0) {
//   errors.push(new Error(`expected ${test3} to equal 0`));
// }

// if (errors.length) {
//   for (let i = 0; i < errors.length; i++) {
//     console.log(errors[i].toString());
//   }

//   throw new Error(
//     `add function failed ${errors.length} test cases. See above.`
//   );
// }

// const mergeArrTest1 = mergeArr([1, 2, 3], ['a', 'b']);
// const expectedTest1 = [1, 2, 3, 'z', 'b'];

// for (let i = 0; i < mergeArrTest1.length; i++) {
//   const actualItem = mergeArrTest1[i];
//   const expectedItem = expectedTest1[i];

//   if (actualItem !== expectedItem) {
//     throw new Error(
//       `expected ${actualItem} to be ${expectedItem} at index ${i}`
//     );
//   }
// }

/* 
Not-naive way, use a testing library:

This built in testing library for node is not recommended for large amounts of
testing, it is deprecated. Use a testing library instead, such as Jest.
*/
const assert = require('assert');

// assert.deepEqual(add(1, 2), 3);
// assert.deepEqual(add(5, 5), 10);

/* Fails when one key has wrong value */
// assert.deepEqual(
//   [
//     { name: 'Anthony', age: 29 },
//     { name: 'Neil', age: 32 },
//   ],
//   [
//     { name: 'Anthony', age: 29 },
//     { name: 'Neil', age: 33 },
//   ]
// );

module.exports = {
  add,
};
