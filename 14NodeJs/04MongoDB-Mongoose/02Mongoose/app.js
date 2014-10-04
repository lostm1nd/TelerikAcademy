/* global require, console */
'use strict';

var chatDb = require('./chat-db');

chatDb.init('localhost:27017/chat');

// chatDb.registerUser({username: 'Ivan', pass: 123456});
// chatDb.registerUser({username: 'Margarit', pass: 123456});

// chatDb.sendMessage({
//   from: 'Ivan',
//   to: 'Margarit',
//   text: 'Hi there!'
// });

// chatDb.sendMessage({
//   from: 'Margarit',
//   to: 'Ivan',
//   text: 'Hello. Whats up?'
// });


chatDb.getMessages('Ivan', 'Margarit', function (err, results) {
  if (err) {
    console.log(err);
  }

  console.log(results);
});
