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

### Installation

Currently you should build locally by downloading the source or cloning the repository. Eventually some binary releases might be included with the repository going forward. To build, you will need [Visual Studio 2015](https://www.visualstudio.com/downloads/). Building with Mono might be possible with additional steps but it's not clear how usable it will be. The Mac OS X version definitely has some issues. For now, Windows is the recommended platform to use.

Open the solution file `CymaticLabs.InfluxDB.sln` to get started.

### Managing Connections

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

_The **Test** button to let's you test the connection to InfluxDB using the provided connection details._

_The **Ping** button let's you ping the InfluxDB server and check response time and server version._

_Press the **Save** button to create or update the connection information._

### Connecting to a Server

Once you have created at least one connection, select it in the **Manage Connections** dialog and press the **Connect** buton.

![Connect to a Server](docs/img/ManageConnectionsDialog_WithLocalhost.png?raw=true "Connect to a Server")

After pressing the **Connect** button you will see the **the main application window**. The list of active connection(s) is located in the tree view to the left. This window is where perform most of your interactions with the various InfluxDB connections that you have chosen to connect to. You can launch the **Manage Connections** dialog up again at any time by pressing the toolbar button in the top-left corner or by opening selecting from the application menu **Connections** -> **Manage**.

![Main Window](docs/img/AppForm_InitialView.png?raw=true "Main Window")

_Explore databases and measurements by using the tree view in the left panel._
