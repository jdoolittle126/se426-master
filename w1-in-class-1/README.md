# Week 1 Group & In-Class Activites

## Group Activity 1

Create an XML document that describes a contact database

Each contact will have the following
- The latest version date as an element
- The current version number (decimal number) as an element
- It will store a series of contacts (called contacts).  Each contact will have the following information:
	- First Name
	- Last Name
	- Phone Number
	- Fax Number
	- Email Address
	- An attribute representing their sex (stored as M or F)

Fill in enough data for 5 contacts

## Group Activity 2

Open up the PracticeXMLFile.xml in XPathVisualizer.

Now figure out the XPath for the following requirements:
- Pull all author elements
- Pull all first-name elements
- All elements that are children of the author element
- The exchange attribute on <price> elements within the current context.
- The first publication for each author

## In-Class Activity

Take your contact.xml file and pull the following information from it:
- Display the version date and version number
- Return all of the information about each contact (including the sex)
- Return all of the information for only the males in the contact list
- Return all of the information for a specific last name that you enter (you need to get the information via one XPath statement, not walking through the whole list until you find the correct last name)
