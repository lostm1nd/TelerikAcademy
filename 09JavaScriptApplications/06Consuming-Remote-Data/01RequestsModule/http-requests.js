var XHRModule = (function() {
  'use strict';

  var getHttpRequrest = function() {
    try {
      return new XMLHttpRequest();
    } catch (e) {}

    try {
      return new ActiveXObject('Msxml3.XMLHTTP');
    } catch (e) {}

    try {
      return new ActiveXObject('Msxml2.XMLHTTP.6.0');
    } catch (e) {}

    try {
      return new ActiveXObject('Msxml2.XMLHTTP.3.0');
    } catch (e) {}

    try  {
      return new ActiveXObject('Msxml2.XMLHTTP');
    } catch (e) {}

    try {
      return new ActiveXObject('Microsoft.XMLHTTP');
    } catch (e) {}

    return null;
  };

  var makeRequest = function (type, url, options) {
    var xhr = getHttpRequrest(),
        contentType,
        accept,
        data,
        deferred;

    if (xhr === null) {
      throw new Error('Browser does not support this functionality.');
    }

    options = options || {};
    contentType = options.contentType || 'application/json';
    accept = options.accept || 'application/json';
    data = JSON.stringify(options.data) || null;
    deferred = Q.defer();

    xhr.onreadystatechange = function() {
      if (xhr.readyState === 4) {
        switch (Math.floor(xhr.status / 100)) {
          case 2:
            deferred.resolve(JSON.parse(xhr.responseText));
            break;
          default:
            deferred.reject(xhr.responseText);
            break;
        }
      }
    };

    xhr.open(type, url, true);
    xhr.setRequestHeader('Content-Type', contentType);
    xhr.setRequestHeader('Accept', accept);
    xhr.send(data);

    return deferred.promise;
  };

  var getJSON = function(url, options) {
    return makeRequest('GET', url, options);
  };

  var postJSON = function(url, options) {
    return makeRequest('POST', url, options);
  };

  return {
    getJSON: getJSON,
    postJSON: postJSON
  };

}());
