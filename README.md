# InfluxDB Studio
**.NET Management Tools for InfluxDB and the TICK stack**

InfluxDB Studio is a UI management tool for [the InfluxDB time series database](https://www.influxdata.com/time-series-platform/influxdb/).
Its inspiration comes from other similar database management tools such as [SQL Server Management Studio](https://en.wikipedia.org/wiki/SQL_Server_Management_Studio)
and [Robomongo](https://robomongo.org/). Under the hood it's powered by [InfluxData.Net](https://github.com/pootzko/InfluxData.Net)
which is a portable InfluxDB client library for .NET (plus some [Kapacitor](https://www.influxdata.com/time-series-platform/kapacitor/) support).
InfluxDB Studio presently implements interfaces and workflows for most of the InfluxData.Net API.

The following are planned features that are not yet implemented in the current version:

* _Retention Policy management_
* _An interface for writing point data directly to the database_
* _Custom stats view for server stats (diagnostics is presently supported)_

## Table of contents

 - [Installation](#installation)
 - [Managing Connections](#managing-connections)
   - [Connection Settings](#connection-settings)
 - [Connecting to a Server](#connecting-to-a-server)
 - [Working with Connections](#working-with-connections)
 - [Working with Databases](#working-with-databases)
   - [Creating a Database](#creating-a-database)
   - [Dropping a Database](#dropping-a-database)
   - [Running a Database Query](#running-a-database-query)
   - [Creating Continuous Queries](#creating-continuous-queries)
   - [Running a Backfill Query](#running-a-backfill-query)
 - [License](#license)
   
## Installation

Currently you should build locally by downloading the source or cloning the repository. Eventually some binary releases might be included with the repository going forward. To build, you will need [Visual Studio 2015](https://www.visualstudio.com/downloads/). Building with Mono might be possible with additional steps but it's not clear how usable it will be. The Mac OS X version definitely has some issues. For now, Windows is the recommended platform to use.

Open the solution file `CymaticLabs.InfluxDB.sln` to get started.

## Managing Connections

Upon running **InfluxDBStudio.exe** you will be prompted with the **Manage Connections** dialog. This window will let you create, edit, and delete InfluxDB server connections.

![Empty Manage Connections Dialog](docs/img/ManageConnectionsDialog_Blank.png?raw=true "Empty Manage Connections Dialog")

Press the **Create** button to add your first InfluxDB connection using the **Connection Setting** dialog.

#### Connection Settings

Use the Connection Settings dialog to configure the details of the InfluxDB connection:

 * **Name** - The name of the connection. This is the label you will see when working with this connection.
 * **Address** - The InfluxDB server's host URI. Exclude protocol information. **Port** is filled in to the right.
 * **Database** - The database to use for the connection. Leave this blank to list all databases _(requires admin privileges)_.
 * **Username** - The InfluxDB username to use with the connection.
 * **Password** - The InfluxDB password to use with the connection.
 * **Use SSL** - Whether or not to use SSL security (HTTPS) when connecting to InfluxDB.

![Create/Edit Connection Dialog](docs/img/ConnectionsDialog_1.png?raw=true "Create/Edit Connection Dialog")

_The **Test** button to lets you test the connection to InfluxDB using the provided connection details._

_The **Ping** button lets you ping the InfluxDB server and check response time and server version._

_Press the **Save** button to create or update the connection information._

## Connecting to a Server

Once you have created at least one connection, select it in the **Manage Connections** dialog and press the **Connect** buton.

![Connect to a Server](docs/img/ManageConnectionsDialog_WithLocalhost.png?raw=true "Connect to a Server")

After pressing the **Connect** button you will see the **the main application window**. The list of active connection(s) is located in the tree view to the left. This window is where perform most of your interactions with the various InfluxDB connections that you have chosen to connect to. You can launch the **Manage Connections** dialog again at any time by pressing the toolbar button in the top-left corner or by selecting from the application menu **Connections** -> **Manage**.

![Main Window](docs/img/AppForm_InitialView.png?raw=true "Main Window")

_Explore databases and measurements by using the tree view in the left panel._

## Working with Connections

**Right-click** when you have a **Connection** node selected in the tree view. You will see a **context menu** of available commands for the server. These commands are also available at the top of the application in **the toolbar**. Find the corresponding **toolbar button** by matching its icon to the **context menu** command.

![Connection Commands](docs/img/Connections_ContextMenu.png?raw=true "Connection Commands")

The following connection commands are available:

 * **Refresh** - Refreshes the connections data; refetches database information from the server.
 * **Create Database** - Creates a new database on the server.
 * **Show Users** - Lists users on the server and provides a user management interface.
 * **Diagnostics** - Shows server diagnostics including runtime, version, uptime, etc.
 * **Disconnect** - Closes the connection and removes it from the active connection list.
 
## Working with Databases

The following section outlines the actions available when working with InfluxDB databases.

#### Creating a Database 
 
To create a database, select the connection on which you'd like to create the database and select **Create Database** from the **context menu** or **the toolbar button**. Next provide the name for the database to create and press the **Create** button:
 
![Create Database](docs/img/Connections_CreateDatabase_1.png?raw=true "Create Database")

The created database should now appear in the tree view on the left:

![Database Created](docs/img/Connections_CreateDatabase_2.png?raw=true "Database Created")

#### Dropping a Database

To drop a database, select it in the tree view on the left. Then **right-click** or use **the toolbar button** and select **Drop Database**:

![Drop Database](docs/img/Databases_Drop_1.png?raw=true "Drop Database")

Confirm that you would like to drop the selected database _(**this is a permanent operation**)_:

![Confirm Drop Database](docs/img/Databases_Drop_2.png?raw=true "Confirm Drop Database")

#### Running a Database Query

Select a database node in the tree view and either double click, **right-click**, use **the toolbar button**, or select from the application menu **Query -> New** to select the **New Query** command:

![Create New Query](docs/img/Databases_RunQuery_1.png?raw=true "Create New Query")

Press **CTRL+R**, **the toolbar button**, or select from the application menu **Query -> Run** to run the query. Results will be displayed in the table area below:

![Run Query](docs/img/Databases_RunQuery_2.png?raw=true "Run Query")

Using **aggregation (GROUP BY)** in queries will group the series results into their own tabs in the results area:

![Group Results](docs/img/Databases_RunQuery_3.png?raw=true "Group Results")

#### Creating Continuous Queries

#### Running a Backfill Query
 
 
## License

Code and documentation are available according to the *MIT* License (see [LICENSE](https://github.com/CymaticLabs/InfluxDBStudio/blob/master/LICENSE)).
