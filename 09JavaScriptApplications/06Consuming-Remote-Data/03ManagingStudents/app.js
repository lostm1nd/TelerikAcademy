$(function() {
  'use strict';

  var $addStudent = $('#add-student'),
      $studentContainer = $('#students-container');

  function addStudent(name, grade) {
    $.ajax({
      type: 'POST',
      url: 'http://localhost:3000/students',
      dataType: 'json',
      contentType: 'application/json',
      data: JSON.stringify({
        name: name,
        grade: grade
      })
    })
    .then(function success(data) {
      populateStudents(data);
    }, function error(err) {
      alert('There was an error when saving the student. Try later.');
    });
  }

  function populateStudents(students) {
    $('#no-students').remove();

    if (!Array.isArray(students)) {
      students = [students];
    }

    students.forEach(function(student) {
      $studentContainer.append(
        '<li data-id="' + student.id + '">Name ' + student.name +
        ' - Grade ' + student.grade +
        '<span class="remove">X</span></li>');
    });
  }

  function deleteStudent(id) {
    $.ajax({
      type: 'POST',
      url: 'http://localhost:3000/students/' + id,
      data: { _method: 'delete' }
    })
    .then(function success(msg) {
      $('li[data-id="' + id + '"').remove();
      console.log(msg);
    }, function(err) {
      console.log(err);
    });
  }

  $.ajax({
    type: 'GET',
    url: 'http://localhost:3000/students',
    dataType: 'json'
  })
  .then(function success(data) {
    console.log(data);
    if (data.count > 0) {
      populateStudents(data.students);
    } else {
      $studentContainer.append('<li id="no-students">No students available.</li>');
    }
  }, function error(err) {
    $studentContainer.append('<li>There was an error. Try later.</li>');
  });

  $addStudent.on('click', function() {
    var name = $('#name').val(),
        grade = $('#grade').val();

    addStudent(name, grade);
  });

  $studentContainer.on('click', '.remove', function() {
    var $li = $(this).parent(),
        studentId = $li.attr('data-id');

    deleteStudent(studentId);
  });

});
