// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const editPostTitle = document.getElementById('edit-post-title');

editPostTitle.addEventListener('click', function (e) {
  console.log(e);
  const currColor = editPostTitle.style.backgroundColor;
  currColor === 'orange'
    ? (editPostTitle.style.backgroundColor = 'inherit')
    : (editPostTitle.style.backgroundColor = 'orange');
});
