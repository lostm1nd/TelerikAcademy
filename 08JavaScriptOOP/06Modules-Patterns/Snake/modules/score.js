define(function() {
  'use strict';

  var score = 0;

  function getScore() {
    return score;
  }

  function increaseScore() {
    score += 10;
  }

  return {
    getScore: getScore,
    increaseScore: increaseScore
  };
});
