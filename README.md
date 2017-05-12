# InfluxDB Studio
**InfluxDB Studio is a UI management tool for [the InfluxDB time series database](https://www.influxdata.com/time-series-platform/influxdb/).**

Its inspiration comes from other similar database management tools such as [SQL Server Management Studio](https://en.wikipedia.org/wiki/SQL_Server_Management_Studio)
and [Robomongo](https://robomongo.org/). Under the hood it's powered by [InfluxData.Net](https://github.com/pootzko/InfluxData.Net)
which is a portable InfluxDB client library for .NET (plus some [Kapacitor](https://www.influxdata.com/time-series-platform/kapacitor/) support).
InfluxDB Studio presently implements interfaces and workflows for most of the InfluxData.Net API.

The following are planned features that are not yet implemented in the current version:

* _~~Retention Policy management~~ implemented, but not documented_
* _~~Custom stats view for server stats (diagnostics is presently supported)~~ implemented, but not documented_
* _~~Listing currently running queries~~ implemented, but not documented_ 
* _~~Stopping long running queries~~ implemented, but not documented_
* _An interface for writing point data directly to the database_

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
   - [Exporting Database Query Results](#exporting-database-query-results)
   - [Creating Continuous Queries](#creating-continuous-queries)
   - [Running a Backfill Query](#running-a-backfill-query)
   - [Listing Running Queries](#listing-running-queries)
   - [Stopping Long Running Queries](#stopping-long-running-queries)
 - [Working with Measurements and Series](#working-with-measurements-and-series)
   - [Running a Measurement Query](#running-a-measurement-query)
   - [Exporting Measurement Query Results](#exporting-measurement-query-results)
   - [Showing Tag Keys](#showing-tag-keys)
   - [Showing Tag Values](#showing-tag-values)
   - [Showing Field Keys](#showing-field-keys)
   - [Showing Series](#showing-series)
   - [Dropping Measurements](#dropping-measurements)
   - [Dropping Series](#dropping-series)
 - [Working with Users and Privileges](#working-with-users-and-privileges)
   - [Showing Users](#showing-users)
   - [Managing Users](#managing-users)
   - [Managing Privileges](#managing-privileges)
 - [Application Settings](#application-settings)
   - [Settings Overview](#settings-overview)
   - [Exporting Settings](#exporting-settings)
   - [Importing Settings](#importing-settings)
 - [License](#license)
   
## Installation

Binary releases can be found [here](https://github.com/CymaticLabs/InfluxDBStudio/releases).

You can build locally by downloading the source or cloning the repository. Eventually some binary releases might be included with the repository going forward. To build, you will need [Visual Studio 2015](https://www.visualstudio.com/downloads/). Building with Mono might be possible with additional steps but it's not clear how usable it will be. The Mac OS X version definitely has some issues. For now, Windows is the recommended platform to use.

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

After pressing the **Connect** button you will see the **the main application window**. The list of active connection(s) is located in the tree view to the left. This window is where perform most of your interactions with the various InfluxDB connections that you have chosen to connect to. You can launch the **Manage Connections** dialog again at any time by pressing the toolbar button in the top-left corner or by selecting from the application menu **Connections** → **Manage**.

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

Select a database node in the tree view and either **double-click**, **right-click**, use **the toolbar button**, or select from the application menu **Query → New** to select the **New Query** command.

Press **CTRL+R**, **the toolbar button**, or select from the application menu **Query → Run** to run the query. Results will be displayed in the table area below:

![Run Query](docs/img/Databases_RunQuery_2.png?raw=true "Run Query")

Using **aggregation (GROUP BY)** in queries will group the series results into their own tabs in the results area:

![Group Results](docs/img/Databases_RunQuery_3.png?raw=true "Group Results")

### Exporting Database Query Results

The results of most query windows in InfluxDB Studio can be exported to file. **Right-click** in the results table and choose from the available export options.
Data can be exported in either **CSV** or **JSON** format. Choosing **Export All** will export the entire set of returned rows to file. Alternatively you can
export just the selected rows by using **CTRL + Left Click** and **Shift + Left Click** to select the rows you want to export and then choosing **Export Selected**
in the export context menu.

![Exporting Database Results](docs/img/Databases_ExportQueryResults.png?raw=true "Exporting Database Results")

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

The following commands are available from the Measurement **context menu** and **toolbar buttons**:

  * **New Query** - Opens a new query tab where you can run custom queries and explore the results.
  * **Show Tag Keys** - Lists all tag names/keys that exist for the selected measurement/series.
  * **Show Tag Values** - Lets you explore the values of all tags keys.
  * **Show Field Keys** - Lists the names/keys of all fields in the measurement as well as their data types.
  * **Show Series** - Lists all Series that exist under the selected measurement.
  * **Drop Measurement** - Drops the selected measurement from the database.
  * **Drop Series** - Leaves the measurement but drops all series data from it.

### Running a Measurement Query

Select a measurement node in the tree view and either **double-click**, **right-click**, use **the toolbar button**, or select from the application menu **Query → New** to select the **New Query** command.

Press **CTRL+R**, **the toolbar button**, or select from the application menu **Query → Run** to run the query. Results will be displayed in the table area below:

![Run Query](docs/img/Measurements_RunQuery_1.png?raw=true "Run Query")

Using **aggregation (GROUP BY)** in queries will group the series results into their own tabs in the results area:

![Group Results](docs/img/Databases_RunQuery_3.png?raw=true "Group Results")

### Exporting Measurement Query Results

The results of most query windows in InfluxDB Studio can be exported to file. **Right-click** in the results table and choose from the available export options.
Data can be exported in either **CSV** or **JSON** format. Choosing **Export All** will export the entire set of returned rows to file. Alternatively you can
export just the selected rows by using **CTRL + Left Click** and **Shift + Left Click** to select the rows you want to export and then choosing **Export Selected**
in the export context menu.

![Exporting Measurement Results](docs/img/Measurements_ExportQuery_1.png?raw=true "Exporting Measurement Results")

### Showing Tag keys

Select a measurement node in the tree view and either **right-click** or use **the toolbar button** and select **Show Tag Keys**:

![Showing Tag Keys](docs/img/Measurements_ShowTagKeys.png?raw=true "Showing Tag Keys")

_Tag keys can be exported by **right-clicking** in the results area and using the **export context menu**._

### Showing Tag Values

Select a measurement node in the tree view and either **right-click** or use **the toolbar button** and select **Show Tag Values**:

![Showing Tag Values](docs/img/Measurements_ShowTagValues.png?raw=true "Showing Tag Values")

_Use the **drop down menu** in the **Tag Values tab** to explore the values for each tag. Tag values can be exported by **right-clicking** in the results area and using the **export context menu**._

### Showing Field Keys

Select a measurement node in the tree view and either **right-click** or use **the toolbar button** and select **Show Field Keys**:

![Showing Field Keys](docs/img/Measurements_ShowFieldKeys.png?raw=true "Showing Field Keys")

_Field keys can be exported by **right-clicking** in the results area and using the **export context menu**._

### Showing Series

Select a measurement node in the tree view and either **right-click** or use **the toolbar button** and select **Show Series**:

![Showing Series](docs/img/Measurements_ShowSeries.png?raw=true "Showing Series")

_Series information can be exported by **right-clicking** in the results area and using the **export context menu**._

### Dropping Measurements

To drop a measurement, select it in the tree view on the left. Then **right-click** or use **the toolbar button** and select **Drop Measurement**:

![Confirm Drop Measurement](docs/img/Measurements_DropMeasurement.png?raw=true "Confirm Drop Measurement")

_Confirm that you would like to drop the selected measurement (**this is a permanent operation**)._

### Dropping Series

To drop all series for a measurement, select the measurement in the tree view on the left. Then **right-click** or use **the toolbar button** and select **Drop Series**:

![Confirm Drop Series](docs/img/Measurements_DropSeries.png?raw=true "Confirm Drop Series")

_Confirm that you would like to drop series for the selected measurement (**this is a permanent operation**). The measurement will be left intact, but all series data will be dropped._

## Working with Users and Privileges

The following is a list of available commands when working with users and privileges:

  * **Create User** - Creates a new user on the InfluxDB server.
  * **Edit User** - Allows a user's administrator status to be updated.
  * **Change Password** - Allows a user's password to be updated.
  * **Drop User** - Drops a user from the InfluxDB server.
  * **Grant Privilege** - Grants a privilege (Read, Write, All) to a user for a particular database.
  * **Edit Privilege** - Updates a user's privilege for a particular database.
 
### Showing Users

Select a connection node in the tree view and either **right-click** or use **the toolbar button** and select **Show Users**:

![Showing Users](docs/img/Connections_ShowUsers.png?raw=true "Showing Users")

_Users for the connection will be listed with an indicator of whether or not they have administrator privileges. Clicking on a user in the list will also let you browse and edit their database privileges._

### Managing Users

#### Creating a User

After bring up the **Users tab** by selecting the **[Show Users](#showing-users)** command, **right-click** or use the **Create User** button in the **Users tab**:

![Create User Dialog](docs/img/Connections_CreateUser_1.png?raw=true "Create User Dialog")

Enter the user's name and password and select whether or not they will be a server administrator and click the **Create** button.

![User Created](docs/img/Connections_CreateUser_2.png?raw=true "User Created")

#### Editing a User

Presently the only editable aspect of a user is whether or not they are a server administrator. To edit a user **right-click** or click the **Edit User** button in the **Users tab**:

![Edit User](docs/img/Connections_EditUser.png?raw=true "Edit User")

#### Changing a User's Password

To update a user's password, **right-click** or click the **Change Password** button in the **Users tab**:

![Change User Password](docs/img/Connections_ChangeUserPassword.png?raw=true "Change User Password")

#### Dropping a User

To drop a user, **right-click** or click the **Drop User** button in the **Users tab**:

![Confirm Drop User](docs/img/Connections_DropUser.png?raw=true "Confirm Drop User")

_Confirm that you would like to drop the selected user (**this is a permanent operation**)._

### Managing Privileges

After bring up the **Users tab** by selecting the **[Show Users](#showing-users)** command, click on a user to select them from the list. The user's various databases privileges will be listed in the **Privileges Panel** below the users list.

#### Granting a Privilege

To grant a new database privilege to a user make sure the user is selected in the users list and then **right-click** in the **Privileges Panel** or click the **Grant Privilege** button:

![Granting a Privilege](docs/img/Connections_GrantUserPrivilege_1.png?raw=true "Granting a Privilege")

Select the database the privilege will be for and then select one of the following privileges to grant:

  * **Read** - The user can only read from the database.
  * **Write** - The user can only write to the database.
  * **All** - The user can read and write to the database.

Click the **Grant** button to grant the user the privilege:

![Privilege Granted](docs/img/Connections_GrantUserPrivilege_2.png?raw=true "Privilege Granted")

#### Editing a Privilege

To edit a privilege make sure the user is selected in the users list and then **right-click** in the **Privileges Panel** or click the **Edit Privilege** button:

![Edit a Privilege](docs/img/Connections_EditUserPrivilege.png?raw=true "Edit a Privilege")

_Select the desired privilege from the drop down and save. To revoke all privileges, select the **None** option._

## Application Settings

Application settings can be adjusted in the application **Settings** menu. Settings and connection information can also be imported and exported.

### Settings Overview
  
  * **Settings → Time Format**
    * **12 hour** - Time will be displayed in a 12 hour format with AM/PM.
	* **24 hour** - Time will be displayed in a 24 hour format.
  * **Settings → Date Format**
    * **Month First** - Dates will be displayed as: mm/dd/yyyy.
	* **Day First** - Dates will be displayed as: dd/mm/yyyy.
  * **Allow Untrusted SSL** - When this setting is turned on, untrusted SSL certificates for InfluxDB servers will be allowed.

### Exporting Settings

To export application settings, including all configured InfluxDB server connections, select **File → Export → Settings** from the **application menu** and choose a location and file name for the settings file and click **Save**.

### Importing Settings

To import application settings, including all configured InfluxDB server connections, select **File → Import → Settings** from the **application menu** and browse to and select the exported settings file you would like to import then click **Open**.

## License

Code and documentation are available according to the *MIT* License (see [LICENSE](https://github.com/CymaticLabs/InfluxDBStudio/blob/master/LICENSE)).
