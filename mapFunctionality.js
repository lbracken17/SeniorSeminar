
//var theMarker = {};

function route() {

  var originCode = document.getElementById('originCode').value.toUpperCase();
  var destinationCode = document.getElementById('destinationCode').value.toUpperCase();

  if (codes[originCode] != undefined && codes[destinationCode] != undefined){
    document.getElementById("path").innerHTML = "Routing from " + codes[originCode][0] + " to " + codes[destinationCode][0];
    }

  else if (codes[destinationCode] == undefined && codes[originCode] == undefined) {
    document.getElementById("path").innerHTML = "Neither of your codes are recognized. Try 3 (or 6) letter building codes."
    }

  else if (codes[destinationCode] == undefined) {
    document.getElementById("path").innerHTML = "Your destination building code isn't recognized."
    }

  else if (codes[originCode] == undefined) {
    document.getElementById("path").innerHTML = "Your starting building code isn't recognized."
    }

    if (theMarker != undefined) {
      mymap.removeLayer(theMarker);
      };

  theMarker = L.marker([codes[destinationCode][1], codes[destinationCode][2]]).addTo(mymap);
  }

function myMap(){
  var mymap = L.map('mapid').setView([44.011419, -73.177980], 16);

  L.tileLayer('https://api.tiles.mapbox.com/v4/{id}/{z}/{x}/{y}.png?access_token=pk.eyJ1Ijoid2lsbDIzOTciLCJhIjoiY2pvYWJ5a2sxMDAzdzNwbjJycmlzaXB6YiJ9.c-hvWE8i0ybvu7fbDVIkvg', {
    attribution: 'Map data &copy; <a href="https://www.openstreetmap.org/">OpenStreetMap</a> contributors, <a href="https://creativecommons.org/licenses/by-sa/2.0/">CC-BY-SA</a>, Imagery © <a href="https://www.mapbox.com/">Mapbox</a>',
    maxZoom: 18,
    id: 'mapbox.streets',
    accessToken: 'pk.eyJ1Ijoid2lsbDIzOTciLCJhIjoiY2pvYWJ5a2sxMDAzdzNwbjJycmlzaXB6YiJ9.c-hvWE8i0ybvu7fbDVIkvg'}).addTo(mymap);

    var myLines = [{
      "type": "LineString",
      "coordinates": [[-73.177956, 44.012532], [-73.178678, 44.012353], [-73.180705, 44.013365]]
    }];

    var myStyle = {
      "color": "#ff7800",
      "weight": 5,
      "opacity": 0.65
    };

    L.geoJSON(myLines, {style: myStyle}).addTo(mymap);
  }
