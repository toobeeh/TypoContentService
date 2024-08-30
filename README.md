# TypoContentService
![NuGet Version](https://img.shields.io/nuget/v/tobeh.TypoContentService.Client?style=flat&logo=nuget&label=NuGet&color=blue)


TypoContentService is a small gRPC microservice to generate assets for skribbltypo.  
This includes for example generating sprite combo images (stacking gif frames) or rendering the customcard of typo.

## Server
The gRPC server is located in the TypoImageGen project and contains a basic gRPC microservice.

## Client
With every push to this repository, a NuGet package is published which contains client services which can be consumed in other projects to connect to the microservice.
