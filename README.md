# Introduction
This is a C# library for accessing the [Advantech Wise 4012E](http://www.advantech.com/products/4260f153-57cd-4102-81ea-7a0f36d9b216/wise-4012e/mod_4e936d58-a559-4c1a-9022-e96698c2930b?_ga=1.82474646.1033186900.1491183171) 

This library gives access to eg. the two Knobs (read), the two Switches (read) and the two Relays (write).

I reference the Modbus Nuget package called [NModbus](https://github.com/NModbus/NModbus). 

# Getting Started
1. Fork or download this project and recompile the solution
2. Just reference the Wise.4012E.Modbus project in your own solution
3. See the Demo app for examples on how to read Knobs and Switches
4. See the Demo app for examples on how to change the Relays

# Build and Test
Compile the solution, Run the test app

# Modbus
More documentation about Modbus on the Wise 4012E can be found [here](http://support.advantech.com/Support/DownloadSRDetail_New.aspx?SR_ID=1-W5ALRV&Doc_Source=Download). Just download the PDF from primary or secondary site.

Current features which are supported:
1. two Knobs (read)
2. average of two knobs (if activated on Wise) 
3. two Switches (read) 
4. two Relays (write)

# Contribute
Want to contribute? Throw me a pull request....
