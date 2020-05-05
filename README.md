.Net Core 3.0 Project.
Property Management system. 
Keep track of all information for all the properties and replace all the current spreadsheets
Record all owner’s details and the property/s they own
Track all monies owed by the properties (or the owner)
Track all Invoices (transactions)
Keep notes on each property
Web-based. Also responsive for mobile.
Ability to automatically create invoices for several properties at once by using Bulk invoice creation
Only registered users have access to use the system. ( but possible to change so that some functionality is also visible to anonymous users).
II.	 The System - prototype
Components:
1.	House
Either a house or property.  Must have an Owner linked to it.
2.	Owner 
The person who own the property. May or may not be linked to a House. It is possible to have orphaned Owners on the system.
3.	Invoice
This represents a single transaction where money is owed by a House.  An Invoice is linked to a House.
4.	User
Represent all users registered to use the system.
