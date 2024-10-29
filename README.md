# TechtivaPruebaTecnica - Projecte de Prova Tècnica ERP

Aquest projecte implementa una base de dades **ERP** a SQL Server amb una taula `Client` que inclou quatre camps principals i tres registres d'exemple. Inclou una API en .NET per gestionar dades de clients i una aplicació web que consumeix i mostra les dades de l’API.

## Objectiu

1. **Crear una base de dades**: La base de dades `ERP` en SQL Server inclou la taula `Client` amb quatre camps principals i tres registres.
2. **Desenvolupar una API en MVC**: L’API permet accedir als registres de la base de dades `ERP` mitjançant un controlador MVC.
3. **Integrar un projecte web**: L'aplicació web crida al mètode del controlador de l’API i mostra els registres de clients en pantalla.

## Estructura del Projecte

- **ERPApi**: API en .NET Core que connecta amb la base de dades `ERP` i exposa un endpoint per accedir als registres de clients.
- **ERPWebApp**: Aplicació web en .NET MVC que consumeix l’API i mostra les dades de clients.

## Requisits

- [.NET SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/es-es/sql-server/sql-server-downloads)

## Configuració del Projecte

1. **Crear la Base de Dades**:
   - Al projecte `ERPApi`, trobaràs un script SQL per crear la base de dades i la taula `Client` amb quatre camps principals.
   - Executa l’script a SQL Server per generar la base de dades `ERP`.

2. **Configurar ERPApi**:
   - Obre el fitxer `appsettings.json` dins de `ERPApi` i actualitza la cadena de connexió a l’apartat `"ConnectionStrings"` perquè coincideixi amb el teu entorn de SQL Server.

## Accés

- **API**: Disponible a `http://localhost:<port_api>/api/client` per accedir als registres de la taula `Client`.
- **Aplicació Web**: Accedeix a `http://localhost:<port_web>/` per visualitzar les dades de clients obtingudes des de l’API.

## Estructura de la Taula `Client`

La taula `Client` conté quatre camps principals (per exemple: `Id`, `Name`, `Email`, `Phone`) i inclou tres registres d'exemple per fer proves.

---

Aquest projecte compleix amb els requisits de la prova tècnica, proporcionant una base de dades `ERP`, una API en MVC i una aplicació web per consumir i visualitzar les dades.
