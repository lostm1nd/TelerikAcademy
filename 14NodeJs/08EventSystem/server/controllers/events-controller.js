'use strict';

var DATETIME_SUPPORT = 'The datetime input field is supported only by Chrome.';
var INVALID_NAME_LENGTH = 'The event title must be between 3 and 20 charactes.';
var INVALID_DESC_LENGTH = 'The event description must be more than 3 charactes.';
var CREATE_SUCCESS = 'You have successfully created and event.';
var JOIN_SUCCESS = 'You have successfully joined an event.';
var LEAVE_SUCCESS = 'You have successfully left an event.';
var INVALID_COMMENT_LENGTH = 'The comment must be at least 6 charactes.';
var COMMENT_SUCCESS = 'You have successfully posted a new comment.';

var controller = {};

module.exports = function (eventsData) {
  controller.getPast = function (req, res) {
    var now = Date.now();

    eventsData.getAll()
      .then(function succes(events) {
        var pastEvents = events.filter(function (event) {
          return event.date < now;
        });

        res.render('home', {pastEvents: pastEvents});
      }, function (err) {
        req.session.errorMessage = err.message;
        res.render('404');
      });
  };

  controller.getCreate = function (req, res) {
    res.render('events/create', {infoMessage: DATETIME_SUPPORT});
  };

  controller.postCreate = function (req, res) {
    if (req.body.title.length < 3 || req.body.title.length > 20) {
      req.session.errorMessage = INVALID_NAME_LENGTH;
      return res.redirect('/events/create');
    }

    if (req.body.description.length < 3) {
      req.session.errorMessage = INVALID_DESC_LENGTH;
      return res.redirect('/events/create');
    }

    req.body.type.initiative = req.body.type.initiative || undefined;
    req.body.type.season = req.body.type.season || undefined;
    req.body.creator = {
      username: req.user.username,
      phone: req.user.phone
    };

    eventsData.create(req.body)
      .then(function succes(event) {
        req.session.successMessage = CREATE_SUCCESS;
        res.redirect('/');
      }, function error(err) {
        console.log(err);
        req.session.errorMessage = err.message;
        res.redirect('/events/create');
      });
  };

  controller.getActive = function (req, res) {
    var now = Date.now();

    eventsData.getByInitiatives(req.user.initiatives)
      .then(function succes(events) {
        var active = events.filter(function (event) {
          return event.date > now;
        });
        console.log(active);
        active.sort(function (ev1, ev2) {
          return ev1.date - ev2.date;
        });

        res.render('events/active', {activeEvents: active});
      }, function (err) {
        req.session.errorMessage = err.message;
        res.redirect('/');
      });
  };

  controller.getDetails = function (req, res) {
    var isJoined = false;

    eventsData.byId(req.params.id)
      .then(function succes(event) {
        if (event.attendants && event.attendants.indexOf(req.user.username) !== -1) {
          isJoined = true;
        }

        res.render('events/details', {event: event, isJoined: isJoined});
      }, function error(err) {
        req.session.errorMessage = err.message;
        res.redirect('/');
      });
  };

  controller.postDetails = function (req, res) {
    if (req.body.eventAction === 'join') {
      eventsData.joinById(req.params.id, req.user.username)
        .then(function succes(event) {
          req.session.successMessage = JOIN_SUCCESS;
          res.redirect('/events/active');
        }, function error(err) {
          req.session.errorMessage = err.message;
          res.redirect('/events/active');
        });
    } else {
      eventsData.leaveById(req.params.id, req.user.username)
        .then(function succes(event) {
          req.session.successMessage = LEAVE_SUCCESS;
          res.redirect('/events/active');
        }, function error(err) {
          req.session.errorMessage = err.message;
          res.redirect('/events/active');
        });
    }
  };

  controller.postComment = function (req, res) {
    if (req.body.comment.length < 6) {
      req.session.infoMessage = INVALID_COMMENT_LENGTH;
      return res.redirect('/events/active/' + req.params.id);
    }

    eventsData.postCommentById(req.params.id, req.body.comment)
      .then(function succes(event) {
        req.session.successMessage = COMMENT_SUCCESS;
        res.redirect('/events/active/' + req.params.id);
      }, function error(err) {
        req.session.errorMessage = err.message;
        res.redirect('/events/active/' + req.params.id);
      });
  };

  return controller;
};
