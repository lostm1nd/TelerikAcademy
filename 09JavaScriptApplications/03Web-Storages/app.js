$(function() {
  'use strict';

  var $inputs = $('div.counter').find('input'),
      $results = $('div.results'),
      secretNumber = getSecretNumber(),
      numberOfGuesses = 0;

  $('.counter').on('click', 'a', function() {
    var $input = $(this).parent().find('input'),
        currentValue = parseInt($input.val(), 10) || 0,
        minValue = parseInt($input.attr('data-min'), 10),
        maxValue = parseInt($input.attr('data-max'), 10);

    if ($(this).hasClass('up-arrow') && currentValue + 1 <= maxValue) {
      $input.val(currentValue + 1);
    }

    if ($(this).hasClass('down-arrow') && currentValue - 1 >= minValue) {
      $input.val(currentValue - 1);
    }
  });

  $('#guess').on('click', function() {
    var number = '';
    $inputs.each(function() {
      number += $(this).val();
    });

    if (isNumberValid(number)) {
      numberOfGuesses += 1;
      var bullsAndCows = compareWithSecretNumber(number);

      if (bullsAndCows.bulls === 4) {
        numberGuessed();
        newGame();
      } else {
        outputResult(number, bullsAndCows);
      }

    } else {
      alert('Number must not contain repeating digits.');
    }
  });

  $('#highscores').on('click', function() {
    var highscores = JSON.parse(localStorage.getItem('Highscores'));

    if (highscores) {
      var result = '';
      highscores.forEach(function(entry) {
        result += entry.username + ' with ' + entry.score + ' guesses.\n';
      });
      alert(result);
    } else {
      alert('No entries yet.');
    }
  });

  function getSecretNumber() {
    var secretNumberLength = 4,
        result = '',
        digit;

    result += getRandomInt(1, 10);
    secretNumberLength -= 1;

    for (var i = 0; i < secretNumberLength; i+=1) {
      digit = getRandomInt(0, 10);
      while (result.indexOf(digit) >= 0) {
        digit = getRandomInt(0, 10);
      }

      result += digit;
    }

    return result;
  }

  function compareWithSecretNumber(guess) {
    var bulls = 0,
        cows = 0;

    for (var i = 0; i < secretNumber.length; i++) {
      if (secretNumber[i] === guess[i]) {
        bulls += 1;
      } else if (secretNumber.indexOf(guess[i]) >= 0) {
        cows += 1;
      }
    }

    return {
      bulls: bulls,
      cows: cows
    };
  }

  function outputResult(guess, hits) {
    var par = ['<p>', numberOfGuesses,'. Guess: ', guess, ' -> ',
              hits.bulls, 'bulls; ', hits.cows, 'cows', '</p>'];
    $results.append(par.join(''));
  }

  function isNumberValid(guess) {
    for (var i = 0; i < guess.length; i++) {
      if (guess.indexOf(guess[i], i+1) >= 0) {
        return false;
      }
    }

    return true;
  }

  function numberGuessed() {
    var username = prompt('You guessed the number with ' + numberOfGuesses + ' guesses.\n' +
                          'Enter your name:');

    var highscores = JSON.parse(localStorage.getItem('Highscores')) || [];
    highscores.push({
      username: username,
      score: numberOfGuesses
    });

    highscores.sort(function(entry1, entry2) {
      return entry1.score - entry2.score;
    });

    localStorage.setItem('Highscores', JSON.stringify(highscores));
  }

  function newGame() {
    secretNumber = getSecretNumber();
    numberOfGuesses = 0;

    $results.empty();
    $inputs.each(function() {
      var min = $(this).attr('data-min');

      $(this).val(min);
    });
  }

  function getRandomInt(min, max) {
    return Math.floor(Math.random() * (max - min)) + min;
  }
});
