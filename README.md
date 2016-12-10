# InfluxDB Studio
**InfluxDB Studio is a UI management tool for [the InfluxDB time series database](https://www.influxdata.com/time-series-platform/influxdb/).**

Its inspiration comes from other similar database management tools such as [SQL Server Management Studio](https://en.wikipedia.org/wiki/SQL_Server_Management_Studio)
and [Robomongo](https://robomongo.org/). Under the hood it's powered by [InfluxData.Net](https://github.com/pootzko/InfluxData.Net)
which is a portable InfluxDB client library for .NET (plus some [Kapacitor](https://www.influxdata.com/time-series-platform/kapacitor/) support).
InfluxDB Studio presently implements interfaces and workflows for most of the InfluxData.Net API.

The following are planned features that are not yet implemented in the current version:

* _Retention Policy management_
* _An interface for writing point data directly to the database_
* _Custom stats view for server stats (diagnostics is presently supported)_
* _Listing currently running queries_
* _Stopping long running queries_

## Table of Contents

 - [Installation](#installation)
 - [Managing Connections](#managing-connections)
   - [Connection Settings](#connection-settings)
 - [Connecting to a Server](#connecting-to-a-server)
 - [Working with Connections](#working-with-connections)
   - [Showing Server Diagnostics](#showing-server-diagnostics)
 - [Working with Databases](#working-with-databases)
   - [Creating a Database](#creating-a-database)
   - [Dropping a Database](#dropping-a-database)
   - [Running a Database Query](#running-a-database-query)
   - [Exporting Query Results](#exporting-query-results)
   - [Creating Continuous Queries](#creating-continuous-queries)
   - [Running a Backfill Query](#running-a-backfill-query)
   - [Listing Running Queries](#listing-running-queries)
   - [Stopping Long Running Queries](#stopping-long-running-queries)
 - [Working with Measurements and Series](#working-with-measurements-and-series)
   - [Running a Query](#running-a-query)
   - [Showing Tag Keys](#showing-tag-keys)
   - [Showing Tag Values](#showing-tag-values)
   - [Showing Tag Values](#showing-tag-values)
   - [Showing Field Keys](#showing-field-keys)
   - [Showing Series](#showing-series)
   - [Dropping Measurements](#dropping-measurements)
   - [Dropping Series](#dropping-series)
 - [Working with Users and Permissions](#working-with-users-and-permissions)
   - [Showing Users](#showing-users)
   - [Managing Users](#managing-users)
   - [Managing Permissions](#managing-permissions)
 - [Application Settings](#application-settings)
   - [Settings Overview](#settings-overview)
   - [Exporting Settings](#exporting-settings)
   - [Importing Settings](#importing-settings)
 - [License](#license)
   
## Installation

Currently you should build locally by downloading the source or cloning the repository. Eventually some binary releases might be included with the repository going forward. To build, you will need [Visual Studio 2015](https://www.visualstudio.com/downloads/). Building with Mono might be possible with additional steps but it's not clear how usable it will be. The Mac OS X version definitely has some issues. For now, Windows is the recommended platform to use.

Open the solution file `CymaticLabs.InfluxDB.sln` to get started.

## Managing Connections

Upon running **InfluxDBStudio.exe** you will be prompted with the **Manage Connections** dialog. This window will let you create, edit, and delete InfluxDB server connections.

![Empty Manage Connections Dialog](docs/img/ManageConnectionsDialog_Blank.png?raw=true "Empty Manage Connections Dialog")

Press the **Create** button to add your first InfluxDB connection using the **Connection Setting** dialog.

### Connection Settings

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
 
### Showing Server Diagnostics

To show connection diagnostics **right-click** or use **the toolbar button** to select the **Show Diagnostics** command:

![Show Diagnostics](docs/img/Connections_Diagnostics_2.png?raw=true "Show Diagnostics")
 
## Working with Databases

The following commands are available from the Database **context menu** and **toolbar buttons**:

  * **Refresh** - Refreshes the database data; refetches measurement/series information from the server.
  * **New Query** - Opens a new query tab where you can run custom queries and explore the results.
  * **Show Continuous Queries** - Allows you to list, create, and delete **Continuous Queries** for the database.
  * **Run Backfill** - Lets your run a **Backfill Query** that downsamples or processes data into new measurements.
  * **Drop Database** - Drops the current database from the server.

### Creating a Database 
 
To create a database, select the **Connection** where you would like to create the database and select **Create Database** from the **context menu** or **the toolbar button**. Next provide the name for the database to create and press the **Create** button:
 
![Create Database](docs/img/Connections_CreateDatabase_1.png?raw=true "Create Database")

The created database should now appear in the tree view on the left:

![Database Created](docs/img/Connections_CreateDatabase_2.png?raw=true "Database Created")

### Dropping a Database

To drop a database, select it in the tree view on the left. Then **right-click** or use **the toolbar button** and select **Drop Database**:

![Confirm Drop Database](docs/img/Databases_Drop_2.png?raw=true "Confirm Drop Database")

_Confirm that you would like to drop the selected database (**this is a permanent operation**)._

### Running a Database Query

Select a database node in the tree view and either double click, **right-click**, use **the toolbar button**, or select from the application menu **Query -> New** to select the **New Query** command.

Press **CTRL+R**, **the toolbar button**, or select from the application menu **Query -> Run** to run the query. Results will be displayed in the table area below:

![Run Query](docs/img/Databases_RunQuery_2.png?raw=true "Run Query")

Using **aggregation (GROUP BY)** in queries will group the series results into their own tabs in the results area:

![Group Results](docs/img/Databases_RunQuery_3.png?raw=true "Group Results")

### Exporting Query Results

The results of most query windows in InfluxDB Studio can be exported to file. **Right-click** in the results table and choose from the available export options.
Data can be exported in either **CSV** or **JSON** format. Choosing **Export All** will export the entire set of returned rows to file. Alternatively you can
export just the selected rows by using **CTRL + Left Click** and **Shift + Left Click** to select the rows you want to export and then choosing **Export Selected**
in the export context menu.

![Exporting Results](docs/img/Databases_ExportQueryResults.png?raw=true "Exporting Results")

### Creating Continuous Queries

[Continious Queries](http://docs.influxdata.com/influxdb/v1.1/query_language/continuous_queries/) run at an interval that you specify and are often used to downsample data by averaging it or processing it as it streams in and dumping the downsample data into a new measurement. 

To create and manage Continuous Queries, **right-click** or use **the toolbar button** and select the **Show Continuous Queries** command.

![Create Continuous Query](docs/img/Databases_CQ_2.png?raw=true "Create Continuous Query")

_Once the CQ tab opens, click the **Create CQ** button which will bring up the **Create Continuous Query Dialog**._

### Continuous Query Dialog

Use the dialog to design a new **Continuous Query**. Mouse over the **help tool tips** to learn more about the different form values.

![Create Continuous Queries Dialog](docs/img/Databases_CQ_3.png?raw=true "Create Continuous Queries Dialog")

_Once you are satisified with your CQ press the **Create** button to create and run your query. You can verify that the CQ is working by running queries against its destination measurement and exploring the data:_

![Continuous Query Created](docs/img/Databases_CQ_4.png?raw=true "Continuous Query Created")

### Running a Backfill Query
 
**Backfill Queries** are similar to **Continuous Queries** in that they are typically used to process or downsample data from one measurement into another.
The difference is that where as **Continuous Queries** run in realtime at a fixed interval and process incoming data inside a user-specified rolling time window,
**Backfill Queries** are typically only run once on older measurment data that is already stored in the database and outside of the CQ time window.

For example: imagine that you decided you needed to start downsampling data that you've already been collecting for months. You could create a **Continuous Query**
that would downsample the data every hour and average it on all new, incoming data. However since that would only begin downsampling new data, you might also consider
running a **Backfill Query** on the older historic data so that all data becomes downsampled both backwards and forwards through time.

To run a **Backfill Query** either **right-click** or click **the toolbar button** and select **Run Backfill**. The **Run Backfill Query Dialog** will open:

### Run Backfill Query Dialog

Use the dialog to design a **Backfill Query**. Mouse over the help tool tips to learn more about the different form values.

![Run Backfill Query Dialog](docs/img/Databases_Backfill_1.png?raw=true "Run Backfill Query Dialog")

Click the **Run** button when you are ready to run the backfill. Unless you receive an error message, the query has successfully run.
Check to see that the data exists in the destination measurement as expected:

![Backfill Query Results](docs/img/Databases_Backfill_2.png?raw=true "Backfill Query Results")

_If you don't see any data or your destination measurement was not created check your time ranges to make sure the **Backfill Query** did not operate on an empty result set._

## Working with Measurements and Series

... More Soon

## Working with Users and Permissions

... More Soon

## Application Settings

... More Soon

## License

Code and documentation are available according to the *MIT* License (see [LICENSE](https://github.com/CymaticLabs/InfluxDBStudio/blob/master/LICENSE)).
