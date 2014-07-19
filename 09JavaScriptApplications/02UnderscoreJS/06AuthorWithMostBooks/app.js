// By a given collection of books,
// find the most popular author
// (the author with the highest number of books)

(function() {
  'use strict';

  var book = {
    init: function(title, author) {
      this.title = title;
      this.author = author;
      return this;
    }
  };

  var books = [
    Object.create(book).init('Book 1', 'Author 1'),
    Object.create(book).init('Book 1', 'Author 2'),
    Object.create(book).init('Book 1', 'Author 3'),
    Object.create(book).init('Book 1', 'Author 4'),
    Object.create(book).init('Book 2', 'Author 1'),
    Object.create(book).init('Book 2', 'Author 3'),
    Object.create(book).init('Book 3', 'Author 1'),
    Object.create(book).init('Book 3', 'Author 3'),
    Object.create(book).init('Book 2', 'Author 4'),
    Object.create(book).init('Book 4', 'Author 3')
  ];

  var mostPopularAuthor = _.chain(books)
                            .countBy('author')
                            .map(function(value, key) {
                              return {
                                author: key,
                                books: value
                              };
                            })
                            .max(function(entry) {
                              return entry.books;
                            })
                            .value();

  console.log(mostPopularAuthor);
}());
