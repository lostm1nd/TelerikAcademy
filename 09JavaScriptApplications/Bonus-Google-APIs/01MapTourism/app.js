window.onload = function() {
  var prevCityBtn = document.querySelector('#nav>.prev'),
      nextCityBtn = document.querySelector('#nav>.next'),
      citySelect = document.querySelector('#nav>.cities'),
      mapContainer = document.getElementById('map'),
      cities = CityData.cities,
      cityInfo = CityData.cityInfo,
      cityIndex = 0,
      geocoder = new google.maps.Geocoder(),
      mapZoom = 10,
      googleMap,
      marker,
      infoWindow;

  function getCityCoordinatesPromise(cityName) {
    var deferred = Q.defer();

    geocoder.geocode({ address: cityName}, function(results, status) {
      if (status == google.maps.GeocoderStatus.OK) {
        deferred.resolve({
          city: cityName,
          coords: results[0].geometry.location
        });
      } else {
        deferred.reject('Cannot geolocate this city.');
      }
    });

    return deferred.promise;
  }

  function panMapTo(cityName) {
    getCityCoordinatesPromise(cityName)
      .then(function success(results) {
        googleMap.panTo(results.coords);
        marker.setPosition(results.coords);
        infoWindow = new google.maps.InfoWindow({
          content: cityInfo[cities.indexOf(results.city)]
        });
      }, function error(msg) {
        console.log(msg);
      });
  }

  (function populateSelectInput() {
    var fragment = document.createDocumentFragment(),
        option = document.createElement('option');

    cities.forEach(function(city) {
      var clone = option.cloneNode(true);
      clone.value = city;
      clone.innerText = city;
      fragment.appendChild(clone);
    });

    citySelect.appendChild(fragment);
  }());

  // Initialize map and the marker to the first city in the array
  // also create a new info window with the city information
  getCityCoordinatesPromise(cities[cityIndex])
    .then(function success(results) {
      googleMap = new google.maps.Map(mapContainer, {
        zoom: mapZoom,
        center: results.coords
      });

      marker = new google.maps.Marker({
        map: googleMap,
        position: results.coords,
        title: results.city
      });

      infoWindow = new google.maps.InfoWindow({
        content: cityInfo[cities.indexOf(results.city)]
      });

      google.maps.event.addListener(marker, 'click', function() {
        infoWindow.open(googleMap, this);
      });

    }, function error(msg) {
      console.log(msg);
    });

  // Attach event handlers for navigation
  prevCityBtn.addEventListener('click', function(){
    cityIndex -= 1;

    if (cityIndex < 0) {
      cityIndex = cities.length - 1;
    }

    panMapTo(cities[cityIndex]);
  }, false);

  nextCityBtn.addEventListener('click', function(){
    cityIndex += 1;

    if (cityIndex === cities.length) {
      cityIndex = 0;
    }

    panMapTo(cities[cityIndex]);
  }, false);

  citySelect.addEventListener('input', function() {
    cityIndex = cities.indexOf(this.value);

    panMapTo(cities[cityIndex]);
  }, false);

};
