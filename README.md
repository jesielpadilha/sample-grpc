# Sample gRPC
Demonstrates how to use gRPC to exchange data between .net apps, in addition, the sample contains an AuthServer app  that allows generate JWT Tokens to be used by services that required authentication.

If you have your own auth server (e.g: IdentityServer) you can use it to authenticate the services. 
Just use <code> builder.Services.AddBearerAuthentication(builder.Configuration)</code> service and setup the parameters in <b>appsettings.json</b> file.

> Note: to generate a JWT Token in SampleGrpc.Auth, just pass the following credentials: john | 123465
