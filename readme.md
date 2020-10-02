# Azure Functions CRUD REST API
Demonstrates how to implement CRUD operations as a REST service using
Azure Functions.

Because Azure Functions do not support method overloads, each HTTP verb
must be implemented in its own class.

## Create (Post)
/api/values, Body = Name

### `PostValueFunction`
`Invoke-RestMethod -Method Post -Uri http://localhost:7071/api/values -Body "name"`

## Read (Get)

### `ValuesGetFunction`
`Invoke-RestMethod -Method Get -Uri http://localhost:7071/api/values`

`Invoke-RestMethod -Method Get -Uri http://localhost:7071/api/values/{id?}`

## Update (Put)
### `ValuesPutFunction`
`Invoke-RestMethod -Method Put -Uri http://localhost:7071/api/values/{id} -Body (@{ Id = 3; Name = "THREE"} | ConvertTo-Json)`

## Delete (Delete)
### `ValuesDeleteFunction`
`Invoke-RestMethod -Method Delete -Uri http://localhost:7071/api/values/{id}`
