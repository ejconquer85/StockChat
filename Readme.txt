Para correr la solución se debe hacer los siguiente:

Prerequisitos: Tener una instancia de Redis local levantada por el puerto 6379

Pasos:

1. Establecer el proyecto StockChat como proyecto de inicio.
2. Correr el proyecto StockChat. (levantará por el puerto 5005 asegurarse que dicho puerto no está en uso).
3. Pararse en la ruta: /1. WebApp/StockChatApp/StockChatApp y escribir ng serve --port 4201  (Esto levantará la WebApp por el puerto 4201, asegurarse que no está en uso).
4. Ejecuar el proyecto StockChat.Bot




Falta:
Integrar la autenticación con la autorización:

Se puede probar el registro de la siguiente manera:

1.Abre Postman, SoapUI o una herramienta que permita hacer peticiones http


Registro:

url: http://localhost:5005/api/account/register
trama:
 {
    "UserName":"",
    "Email":"",
    "FullName":"",
    "Password": ""
}

Autenticacion:

url: http://localhost:5005/api/account/login

trama:
 {
    "UserName":"",
    "Password": ""
}