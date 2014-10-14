'use strict';

var Q = require('q');
var Event = require('mongoose').model('Event');
var data = {};

data.byId = function (id) {
  var deferred = Q.defer();

  Event.findById(id)
  .exec(function (err, event) {
    if (err) {
      return deferred.reject(err);
    }

    return deferred.resolve(event);
  });

  return deferred.promise;
};

data.joinById = function (id, username) {
  var deferred = Q.defer();

  Event.findById(id)
  .exec(function (err, event) {
    if (err) {
      return deferred.reject(err);
    }

    event.attendants.push(username);
    event.save(function (err, joinedEvent) {
      if (err) {
        return deferred.reject(err);
      }

      return deferred.resolve(joinedEvent);
    });
  });

  return deferred.promise;
};

data.leaveById = function (id, username) {
  var deferred = Q.defer();

  Event.findById(id)
  .exec(function (err, event) {
    if (err) {
      return deferred.reject(err);
    }

    var index = event.attendants.indexOf(username);
    if (index >= 0) {
      event.attendants.splice(index, 1);
    }

    event.save(function (err, leftEvent) {
      if (err) {
        return deferred.reject(err);
      }

      return deferred.resolve(leftEvent);
    });
  });

  return deferred.promise;
};

data.postCommentById = function (id, comment) {
  var deferred = Q.defer();

  Event.findById(id)
  .exec(function (err, event) {
    if (err) {
      return deferred.reject(err);
    }

    event.comments.push(comment);

    event.save(function (err, commentedEvent) {
      if (err) {
        return deferred.reject(err);
      }

      return deferred.resolve(commentedEvent);
    });
  });

  return deferred.promise;
};

data.getAll = function () {
  var deferred = Q.defer();

  Event.find()
  .exec(function (err, events) {
    if (err) {
      return deferred.reject(err);
    }

    return deferred.resolve(events);
  });

  return deferred.promise;
};

data.create = function (event) {
  var deferred = Q.defer();

  Event.create(event, function (err, saved) {
    if (err) {
      return deferred.reject(err);
    }

    return deferred.resolve(saved);
  });

  return deferred.promise;
};

data.getByInitiatives = function (initiatives) {
  var deferred = Q.defer();

  Event.find({
    $or: [ {'type': {$exists: false}}, {'type.initiative': {$in: initiatives}} ]
  }, function (err, events) {
    if (err) {
      return deferred.reject(err);
    }

    return deferred.resolve(events);
  });

  return deferred.promise;
};

module.exports = data;
