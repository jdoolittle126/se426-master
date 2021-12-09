import $ from "jquery";

// Cache Selectors
const buttonSubmitPart1 = $("#buttonSubmitPart1");
const textPostalCode = $("#textPostalCode");
const postalResultsList = $("#postalResultsList");

const buttonSubmitPart2 = $("#buttonSubmitPart2");
const topStoriesList = $("#topStoriesList");

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
const getPostalCodeData = (postalCode) => {

    postalResultsList.html("");
    const url = "http://api.geonames.org/postalCodeSearchJSON?postalcode=" +  postalCode + "&username=jdoolittle";

    makeJsonRequest(url, (xmlHttpRequest) => {
            if (xmlHttpRequest.readyState === 4 && xmlHttpRequest.status === 200) {

            let results = JSON.parse(xmlHttpRequest.responseText);

            if(results.postalCodes == null) {
                $("<li>No items found!</li>").appendTo(postalResultsList);
            } else {
                for(let i = 0; i < results.postalCodes.length; i++) {
                    let postalCode = results.postalCodes[i];
                    $("<li>" + postalCode.postalCode + " - " + postalCode.placeName + "</li>").appendTo(postalResultsList);
                }
            }

        } else {

        }
    });
};

// Part 2 Function
const getNewYorkTimesArticles = () => {

    topStoriesList.html("");
    const url = "https://api.nytimes.com/svc/topstories/v2/science.json?api-key=w2rLsvNYWk3jUWSBAGH4kubevDsRLsAX";

    makeJsonRequest(url, (xmlHttpRequest) => {
        if (xmlHttpRequest.readyState === 4 && xmlHttpRequest.status === 200) {
            let results = JSON.parse(xmlHttpRequest.responseText);

            if(results.results == null) {
                $("<li>No items found!</li>").appendTo(topStoriesList);
            } else {
                // Skip first 2 promotional stories
                for(let i = 2; i < results.results.length; i++) {
                    let story = results.results[i];
                    $("<li>" + story.title + " " + story.byline + " - <a href='" + story.url + "'>LINK</a></li>").appendTo(topStoriesList);
                }
            }

        } else {
            // waiting for the call to complete
        }
    });
};

// Click listeners for buttons
buttonSubmitPart1.on("click", function() {
    getPostalCodeData(textPostalCode.val());
});

buttonSubmitPart2.on("click", function() {
    getNewYorkTimesArticles();
});
