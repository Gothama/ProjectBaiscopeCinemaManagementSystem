# ProjectBaiscopeCinemaManagementSystem
# BaiseCope-Cinema-Management-System

Clone the project from Github.
Initially you should install the NuGet Packages and arrange the MySQL database.
## Installation of NuGet Packages
1. Open the project in Visual Studio IDE. 
1. Go to Tools-> NuGet package manager -> Manage NuGet packages for solutions.
1. install AForge, AForge.Video, AForge.Video.DirectShow, Eramake.eCryptography, QRCoder, Zen.Barcode.Rendering.Framework, ZXing.Net packages.
## Arrangement of MySQL database.
1. Open the MySQL workbench
1. Go to File -> Run SQL Script -> then select the location of the 'Dump20200812' SQL file.
1. Type as cinemamanagementsystem as the Default Schema Name and click Run.
## Changing the database credentials
1. Open the project in Visual Studio IDE.
1. Open the DBConnect.cs file and change the password of the database into your MySQL password. (Replace your MySQL password with '12345')
## Changing the system Email credentials
1. Open the project in Visual Studio IDE.
1. Open the Email.cs file and change the email and password variables with your email and password.
1. To send emails from the system you should give access to use your gmail for less secure apps. To allow that,
    1. Go to your (Google Account).
    1. On the left navigation panel, click Security.
    1. On the bottom of the page, in the Less secure app access panel, click Turn on access.
1. Turn off that setting after using the email system to avoid security issues.
## Run the program now

# Features of this project.

* The administrators can add new movies, reserve tickets, get details of the tickets, manage expenses. 
* The customers can make their own accounts and every customer is have their own credentials.
* Customers can reserve tickets, view movies available and get data about movies.

## HAPPY CODING.
