window.onload = function() {
  var prevCityBtn = document.querySelector('#nav>.prev'),
      nextCityBtn = document.querySelector('#nav>.next'),
      mapContainer = document.getElementById('map'),
      cities = CityData.cities,
      cityInfo = CityData.cityInfo,
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

  // Initialize map to the first city in the array
  getCityCoordinatesPromise(cities[0])
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



};
