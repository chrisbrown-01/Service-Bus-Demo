# Service-Bus-Demo

This is a demo project I created to better learn service bus events/communications in .NET. Items are randomly created with the Bogus Nuget package and are communicated as events over the service bus. 

The following technologies are used:
 
- MassTransit with RabbitMQ
- .NET Worker Services (*ItemGeneratorApp + ItemConsumerApp projects*) that publish/consume events
- .NET API (*ItemApi project*) that publishes events
- Class library (*AppLibrary project*) for shared record contracts
- YARP reverse proxy
