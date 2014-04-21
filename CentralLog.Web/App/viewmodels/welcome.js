define(function () {
    var ctor = function () {
        this.projectName = 'Best Project Ever';

        var moduletestGroup = {
            name: "Modultests", subgroups: [
                { name: "ProductRepositoryTests", count: 123 },
                { name: "CustomerRepositoryTests", count: 10 },
                { name: "LocationRepositoryTests", count: 133 }
            ]
        };

        var integrationtestGroup = {
            name: "Integrationstests", subgroups: [
                { name: "ProductManagementTest", count: 123 },
                { name: "CustomerManagementTest", count: 412 },
                { name: "LocationManagementTest", count: 24 }
            ]
        };

        var systemtestGroup = {
            name: "Systemtests", subgroups: [
                { name: "ManagementConsoleTest", count: 12 },
                { name: "EventManagementTests", count: 32 },
                { name: "SearchEngineUiTests", count: 75 }
            ]
        };

        this.jobGroups = [moduletestGroup, integrationtestGroup, systemtestGroup];
        this.description = 'This is the main entrance page for the Central Log Project.';
       
    };

    //Note: This module exports a function. That means that you, the developer, can create multiple instances.
    //This pattern is also recognized by Durandal so that it can create instances on demand.
    //If you wish to create a singleton, you should export an object instead of a function.
    //See the "flickr" module for an example of object export.

    return ctor;
});