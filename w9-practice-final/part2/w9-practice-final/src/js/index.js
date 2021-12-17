import $ from "jquery";

// Cache Selectors
const regionName = $("#regionName");
const regionResults = $("#regionResults");
const buttonSubmit = $("#buttonSubmit");


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
const getTeamData = () => {

    regionResults.html("");
    const url = "http://52.152.227.167/jsonfootballservice/footballteams/GetFootballTeam";

    makeJsonRequest(url, (xmlHttpRequest) => {
            if (xmlHttpRequest.readyState === 4 && xmlHttpRequest.status === 200) {

            let results = JSON.parse(xmlHttpRequest.responseText);

            if(results.roster == null) {
                $("<tr>" +
                    "<td>" +
                    "<p>No players found!</p>" +
                    "</td>" +
                    "</tr>").appendTo(regionResults);
            } else {

                regionName.html(results.TeamName);


                for(let i = 0; i < results.roster.length; i++) {
                    let player = results.roster[i];

                    $("<tr>" +
                        "<td>" +
                        "<p>" + player.name + "</p>" +
                        "</td>" +
                        "<td>" +
                        "<p>" + player.weight + "</p>" +
                        "</td>" +
                        "</tr>").appendTo(regionResults);
                }
            }

        } else {
            // waiting for the call to complete
        }
    });
};


buttonSubmit.on("click", function() {
    getTeamData();
});
