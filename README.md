# HMO

In this project I implemented a FullStack system for managing patients' corona data for a large health fund. The system displays the patients, allows their editing and deletion and manages the records in a database. Also, the system will store key information about the corona virus epidemic in the context of health fund members. They will be able to refer to this database in the future for the purpose of making various withdrawals.
## Client- react
**Screenshots:**
https://drive.google.com/file/d/19Xgcyik4NRz7XrqsCikGALCSQb_hdWAi/view?usp=drive_link
![image 1](https://github.com/nira10/Hadasim/assets/147534014/b3d82f1e-1074-4d1b-8b83-13ba993628ff)

The system shows all the members of the health fund, 
the options on the left side - deleting the patient, updating their details and viewing details related to corona. 
On the top left is the Add patient button - to add a new member to the system.

https://drive.google.com/file/d/1lNu_W00jUsK_IWEQ6BBJUXzBH8OKa3nZ/view?usp=drive_link

In the example above, you can see that clicking on the corona symbol opened the appropriate details of the specific patient. Also, at the top on the left side, a button summarizing the monthly corona data is highlighted.

https://drive.google.com/file/d/1GMT9KGxheocsA-DW7UIkFKribGQ8w4wg/view?usp=drive_link

Updating an existing member - the system displays the patient's previous details and gives them the option to change them (if they are correct)
## Server- c#
**architecture:**
The web api is divided into 3 main types of operations: 
interfacing with the client, managing the business logic and dealing with the data.
Accordingly, the project is divided into different layers:
The api layer, which communicates with the client, 
the service layer, which is responsible for the business logic - calculations, various operations, etc. 
The data layer - which actually works on the database and updates it according to the necessary change.
All layers depend on the core layer - where interfaces and models are kept.
## Database- sql
**the tables:**
https://drive.google.com/file/d/1NwqhWwl_yPIa1iTt8CLPDo-obetWDkPM/view?usp=drive_link
The vaccine table is linked to the patient table and the manufacturers table by foreign keys. This is how it is kept for each vaccine to which client it was given and who is the manufacturer that created it. 


## External dependencies
**for runnig, it is necessary:**
The system consists of a client side - React and a server side - c# to run it you have to run the 2 programs at the same time - with the command npm start and clicking on the green arrow on the top in Visual Studio.
