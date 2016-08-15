This shows how you can create a business library and database connection separate from
each other. Because it's .NET, you do need a 3rd assembly to hold the contracts.

The dependencies look like this:

* Library --> Contracts
* Database --> Contracts
* Tests --> Pretty much everything.

What this allows you to do is create multiple libraries which use the same data access
code. It would also let you plug in different data access code.

To run the tests you will need to do the following:

* Create a table in the database using SampleItem.sql
* Update the connection string in LocalContext.cs

