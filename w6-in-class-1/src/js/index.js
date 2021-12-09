import $ from "jquery";

// Cache Selectors
const buttonSubmitPart1 = $("#buttonSubmitPart1");
const textFoodCategory = $("#textFoodCategory");
const regionResults = $("#regionResults");

const buttonSubmitPart2 = $("#buttonSubmitPart2");
const textLocation = $("#textLocation");
const textLocalDate = $("#textLocalDate");
const textValue = $("#textValue");
const textUnit = $("#textUnit");
const textParameter = $("#textParameter");

/**
 * Makes an async request to the given URL with the given callback
 * @param url The URL of the webservice
 * @param callback The callback function, with one parameter for the xmlHttpRequest
 */
const makeJsonRequest = (url, callback) => {
    let xmlHttpRequest;

    if (window.XMLHttpRequest) {
        xmlHttpRequest = new XMLHttpRequest();
        if (typeof xmlHttpRequest.overrideMimeType != "undefined") {
            xmlHttpRequest.overrideMimeType("text/xml");
        }
    } else if (window.ActiveXObject) {
        xmlHttpRequest = new ActiveXObject("Microsoft.XMLHTTP");
    } else {
        // Error
        return;
    }

    xmlHttpRequest.open("GET", url, true);
    xmlHttpRequest.onreadystatechange = () => {
        callback(xmlHttpRequest);
    };
    xmlHttpRequest.send(null);
};

// Part 1 Function
const getMealData = (category) => {

    regionResults.html("");
    const url = "https://www.themealdb.com/api/json/v1/1/filter.php?c=" + category;

    makeJsonRequest(url, (xmlHttpRequest) => {
            if (xmlHttpRequest.readyState === 4 && xmlHttpRequest.status === 200) {

            let results = JSON.parse(xmlHttpRequest.responseText);

            if(results.meals == null) {
                $("<tr>" +
                    "<td>" +
                    "<p>No meals found!!</p>" +
                    "</td>" +
                    "</tr>").appendTo(regionResults);
            } else {
                for(let i = 0; i < results.meals.length; i++) {
                    let meal = results.meals[i];

                    $("<tr>" +
                        "<td>" +
                        "<p>" + meal.strMeal + "</p>" +
                        "</td>" +
                        "<td>" +
                        "<img class='image is-128x128' src='" + meal.strMealThumb + "'>" +
                        "</td>" +
                        "</tr>").appendTo(regionResults);
                }
            }

        } else {
            // waiting for the call to complete
        }
    });
};

// Part 2 Function
const getAirQuality = (location) => {

    const url = "https://api.openaq.org/v1/measurements?city=Providence-New%20Bedford-Fall%20River&location=" + location + "&limit=1";

    makeJsonRequest(url, (xmlHttpRequest) => {
        if (xmlHttpRequest.readyState === 4 && xmlHttpRequest.status === 200) {
            let results = JSON.parse(xmlHttpRequest.responseText);
            // We limit to 1 result, so index 0 is hardcoded
            if(results.results != null) {
                textLocation.val(results.results[0].location);
                textLocalDate.val(results.results[0].date.local);
                textValue.val(results.results[0].value);
                textUnit.val(results.results[0].unit);
                textParameter.val(results.results[0].parameter);
            }

        } else {
            // waiting for the call to complete
        }
    });
};

// Click listeners for buttons
buttonSubmitPart1.on("click", function() {
    getMealData(textFoodCategory.val());
});

buttonSubmitPart2.on("click", function() {
    getAirQuality(textLocation.val());
});
