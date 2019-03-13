# GraphQL AspNetCore
A basic application that runs GraphQL in .NET Core with a PostgresQL database.
On a mac, ensure that postgresql is install (preferably through brew).
Run it through:
```bash
    $ psql postgres
```

Create a table and insert into it:
```sql
        CREATE TABLE "Droids" (
          "Id" serial NOT NULL,
          "Name" text NULL,
          CONSTRAINT "PK_Droids" PRIMARY KEY ("Id")
      );

      INSERT INTO Droids Values
        (0, 'R2-D2'),
        (1, 'R3-D3'),
        (2, 'R4-D4'),
```
Yes, it is not the right droids, but anyway.


First of all call the following to get the nuget packages:
```bash
    $ dotnet restore
```

Run the project
```bash
    $ dotnet run
```

The go to postman an post the following
```json
    {
        "query": "query { hero(id: 2) { name } }"
    }
```

On the URL http://localhost:5000/api/graphql