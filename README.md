# About

This library allows you to use a flexible configuration system, that can observate the 
configurations and notify  the system about these changes.
The default fileformat is the used in the linux systems.



# reading a configuration
To read a configuration, you can use the 'get' method. This method returns a ConfItem object (this objects will be described bellow);
See an example:

```c#
    //Instantiate the Configuration class and laods the file "settings.con"
    var confs = new Configuration("settings.conf");

    //gets the "port" configuration 
    ConfItem serverPort = confs.Get("port", 1500);

    //get the value as a integer
    int portAsInt serverPort.AsInt;
```

```c#
    //Instantiate the Configuration class and laods the file "settings.con"
    var confs = new Configuration("settings.conf");

    //you can also resume the code:
    int port = confs.Get("port", 1500).AsInt;
```

Content of file "settings.conf" (used in the examples above)
```ini
#the port of the server
port=1234
```

## observating a configuration
In addition to doing simple get operations, you can use a more shphisticated sytem, specifying an observer. In that case, you will be notified of changes to the settings.

Let me show an example:

```c#
    public OnConfChange ObservateConfiguration(string confName, OnConfChange onChange, bool invokeFirstTime = true, object defaultValueToFirstTimeInvoke = null)

    //Instantiate the Configuration class and laods the file "settings.con"
    var confs = new Configuration("settings.conf");
    int portAsInt = 1234;

    confs.ObservateConfiguration("port", (ConfItem newValue) => {
        portAsInt = newValue.AsInt;
    }, true, 1235);
    //before execute any code bellow here, the delegate above will be called with the initial 'port' value

```
The ObservateConfiguration method receives 4 arguments (2 is optional):

    confName: The name of the configuration in the file
    
    onChange: A delegate to be called when configuration is changed

    invokeFirstTime: This parameter force the sytem to run the delegate immediatelly. It is very usefull to read a initial value. The default value of this parameter is 'true'

    defaultValueTOFDirstTimeInvoke: an optional value  to be passed to delegate in the first run if the variable is not found in the file.




# writing a configuration

# reading an enumeration

## observating a enumeration

# writing an enumaration



# custom writing and reading



# configuration returns types

All read and observating functions uses a type that allow the easy convertion of the represented value.
This type contains access properties that can acces the internal value as another primitives types, like
string and int.