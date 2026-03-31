## Microservice .NET

#### General

Este proyecto contiene una estrcutura de ejemplo para un microservicio hecho en el stack de .NET 8, siguiendo la implementacion de un arquetipo DDD (Domain Driven Design).   

En dicho proyecto, todas las reglas de negocio o caso de usos deben ser implementados como "Features" dentro de la carpeta Core (Aplicacion o Dominio). 
Por otro lado todo lo que da soporte a dicha capa de aplicacion debe ser simplemente detalles.  
El objetivo de dicho arquetipo es no acoplar mi logica de negocio con los servicios externos (ajenos a mi dominio), los cuales pueden ser propensos a variar todo el tiempo.

Por esta razón, el proyecto está dividido en:

1) **Entrypoint** (Web Api, Listeners de queues, workers de un job, etc).
No debe implementar reglas de negocio. Solamente recibe los request y se los delega a [MediatR](https://github.com/jbogard/MediatR).
Dicho arquetipo implementa y promueve el uso de Mediatr para el desacople entre capas y asi implementar una arquitectura CQRS entre lo transaccional y consultivo.

2) **Core** - dichos proyectos tienen como principal objetivo implementar logica de negocio y casos de uso. Debemos velar para que no existan referencias a Frameworks de acceso a Datos.
   * Domain: Donde definiremos las reglas de negocio (en terminos de DDD, tambien llamadas Dominio y expresadas a traves de entidades, servicios de Dominio, value objects, interfaces de repositorio).
   * Application - Implementaremos el flujo para desarrollar una funcionalidad especifica de mi aplicacion. Orquestará entre los diferentes Dominios/Repositorios.

3) **Infrastructure** - Aqui encontraremos implementaciones concretas de nuestros acceso a Datos. Veremos ORMs, MicroORMS, Request HTTP, etc.


##### Proyectos:

- Entrypoint\Web API\Bibliotecas - ASP.NET Core 8.0
- Tests - .NET 8.0 / xUnit (Pendiente de desarrollar)

##### HealthChecks
Utilizamos la biblioteca [Microsoft.AspNetCore.Diagnostics.HealthChecks](https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/health-checks?view=aspnetcore-8.0) exponiendo por defecto el endpoint ```GET /health```  
Dicha configuracion podes encontrarlo en [HealthChecksApplicationBuilderExtensions](Worldsys.Infrastructure.Bootstrap/Extensions/ApplicationBuilder/HealthChecksApplicationBuilderExtensions.cs)  

##### Logs
Por defecto la salida de los logs es por **Consola**.
Otros tipos de logs (Pendiente de desarrollar)

##### Unit Test

##### Integration Test

##### Otros Frameworks interesantes:
- [Refit](https://github.com/reactiveui/refit) - Para la creación de HttpClients (Incluido en el arquetipo ```IExternalPostsService```)
- [Polly](https://github.com/App-vNext/Polly) - Para implementar políticas de CircuitBreaking / Retry

#### Pipeline