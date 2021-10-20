# Week 2 Group & In-Class Activities

In this assignment, we used wsdl web services to make calculations, lookup phone numbers, and find the potential zipcodes in a given area. Includes group activity and both in-class assignments.

## Group Activity 1

### Accessing Your First Web Service

Create a .Net Framework Project (C#) – we’ll stay away from .Core just because it adds a bunch of stuff I don’t want to deal with here.  If you are comfortable with controllers, talk to me and you can do it that way.
 
- Add the following web reference:
	- http://www.dneonline.com/calculator.asmx
- Remember to change the name of the web service to something meaningful
- Make two web services calls, one for Add, one for Subtract.
- Call Add and Subtract and return the information

 ## In-Class Activity 1

### Part 1

- Add the following web reference
	- http://ws.cdyne.com/phoneverify/phoneverify.asmx
- Call Check Phone Number (you don’t need a license key – you can put 0)
- Display the results (the city, state, and zip)

### Part 2

- Add the following web reference
	- http://ws.cdyne.com/psaddress/addresslookup.asmx
- Call the CityStateToZipCodeMatcher Method
- Ask the user for the City and State Abbreviation
- Set the IgnoreBadCitySpelling to false
- Set the license key to 0
- Display all of the possible zip codes
