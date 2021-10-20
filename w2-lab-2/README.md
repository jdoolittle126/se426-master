# Week 2 - Lab 2

## Problem 1

You will use Here.com web service for traffic incident data.

You will need to get a key to use it:
https://developer.here.com/documentation/authentication/dev_guide/index.html

Here are links to the documentation:

•	https://developer.here.com/documentation/traffic/dev_guide/topics/examples.html

•	https://developer.here.com/documentation/traffic/dev_guide/topics/request-constructing. html

You may choose what format you enter the geographical information but I used the bounding box.

The format of the bounding box is:

	bbox = min Longitude , min Latitude , max Longitude , max Latitude

I made a bounding box from East Greenwich to Providence, you are free to put your own location in.  

Use any website to get the latitude/longitude of your location.

You can set the criticality to minor.

You will return all Traffic Item Descriptions of type desc.
 

## Problem 2

For this task, you will use the website www.geonames.org.  For this program, you will need to make web service calls to accomplish the following tasks:

- List all cities for a given zip code
- List all nearby cities for a given zip code

These are two different buttons in your application, do not combine the two operations.

Note, you will not be able to discover this webservice, you must make a direct call to it via HTTP;

Here is one way to do it:

	//Create Request
	myHttpWebRequest = (HttpWebRequest)HttpWebRequest.Create(postalURL);
	myHttpWebRequest.Method = "GET";
	myHttpWebRequest.ContentType = "text/xml; encoding='utf-8'";
	//Get Response
	myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
	 
	//Load response stream into XMLReader
	myXMLReader = new XmlTextReader(myHttpWebResponse.GetResponseStream());


In both cases you will output the zip code and city.  The user will enter a zip code. I will be entering (it only takes 5 digit zip codes):
- 02864
- 0286