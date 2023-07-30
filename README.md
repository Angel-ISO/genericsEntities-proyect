
#    -------------- 🎥api cine📽️ ---------------

Esta api fue desarrollada con el simple hecho de ejemplificar buenas practicas a la hora de codificar un proyecto de gran embergadura hablando de backend.


#  acompañamiento para ejecucion


#### Primero cambiar las credenciales de la base de datos por sus credenciales propias

![ubicacion del archivo para reemplazar credenciales](/images/credencialesbasededatos.png)


### luego ejecutar los siguientes comandos para generar migraciones(en este caso las migraciones ya tienen una carpeta creada por lo tanto solo ejecutar el siguiente comando)


```c#
dotnet ef database update --project ./Infrastructure/ --startup-project ./API/
```






#### luego de que se ejecute la base de datos deberia observarse de la siguiente manera (el diseño es minimo debido a que es un proyecto personal de practica)




![base de datos](/images/basededatosdise%C3%B1o.png)


## Iniciar servidor

para iniciar el servidor es necesario ubicarse en la carpeta /API y ejecutar el siguiente comando

```c#
  dotnet run
```

#### seguido a esto deberia obtener una respuesta de este tipo

![levantamiento servicio](/images/respuestaservicio.png)






## Realizar peticiones a la api

Una vez iniciado el servidor se puede testear la api con los 4 metodos (get, post, update, delete) el endpoint se encontrara en /API/Controllers en el archivo BaseApiController.cs


![ubicacion endpoint](/images/endpointruta.png)



### luego puede ejecutar todas las acciones con un limite de 10 peticiones cada 10 minutos esto debido al rate limiter que fue configurado e instalado en las dependencias del proyecto


##### ejemplo peticion 

luego de todo lo anterior visto es libre de ya sea consumir la api desde otro proyecto o realizar peticiones como la siguiente


![peticion muestra](/images/apipeticion.png)

## Tecnologias usadas en el  Stack

**Client:** not yet.

**Server:** c#, entityframework 


## el proyecto aun esta en demo y cabe aclarar que puede recibir mas soporte en el futuro estar atento a esta documentacion para futuras actualizaciones :)

## Soporte

para soporte y consultar adicionales, email angelgabrielorteg@gmail.com o enviame solicitud por discord!

