namespace EmployeeDataStructs



    (*
    Name spaces cannot contain values, only type declarations.
    So a let does not work here

    *)

// Does not compile, instead tells you to use  module
// let x = "A Thing"

    (*
    This also means you can't nest a module into a Namespace
    because a module can have values.

    So what is a namespace goode for then? Namespaces are great
    for declaring data structures. Things like Records, 
    Discriminated Unions, and occasionaly other Namespaces.
    For Example:
    *)

    type Name = { 

        first: string; 
        last: string 
    }

    type EmployeeType =

        | Manager
        | Developer
        | Secretary

    type Employee = { 

        name: Name; 
        age: int;
        employeeType: EmployeeType
    }

    (*
    These are all types and are can serve as the beginning
    of a data structure. It's easy to imagine all kinds
    of Domain Specific language going into these kinds of files.

    If we need to access the contents of another namespace from 
    within a namespace file we use the open keyword.
    *)