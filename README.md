# Bike-Management-Project
this is a simple Bike management system made with C# with road & mountain classes that inherits from the parent class, bikes.

## Three Layers
              1-	Business Layer: bus
              2-	Data layer: data
              3-	Client Layer: client   


## Table of Contents

- **Building Business Layer:**
    - All class Diagrams are placed here
    - Enumerations, required private fields, public properties, constructors and public operations
    
- **Building Data Layer:**
    - file handlers to save data to permanent storage and to read data from the perma storage (Read/Write Bin file: bikes.bin)
    
- **Building Client Layer:**    
    - Friendly GUI interaface
        - login for the manager (uses identification and password for users are stored here)
        - Main Form includes the following functions... 
            - Add bikes (moutain or road)
            - Search for bikes 
            - Update bike information
            - Remove bikes
            - Save bike into Binary file 
            - Load bike into Binary file 
            - Display all bikes 
