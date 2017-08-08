module Records

open System
open Logger

// RECORDS

    (*
    Records (types) are basically aggregates of name value pairs.
    Records are immutable like most things in F#.
    The distinguishing features of records is that records
    can have properties and functions as members. 
    A record is a type and that means it can be infered at 
    compile time. 

    Let's take a look at how to instantiate a record.

    *)

    type Person = {   // Capital for the name is convention
        name: string; // name: valueType
        age: int      // name: valueType
    } 
    with member this.canDrink =
                this.age > 19 // This is correct indentation
    // This is not (odd I know)



let records =
    
    (*
    So we have this Person record but how do we use it?
    We declar a new objet inside "{}" curly brackets.
    For example:
    *)

    let bob = {name = "Bob"; age = 55}


    (*
    The values of records can be accessed via the "." operator.
    Let's create a function that take a person and logs
    their information.
    *)

    let logPerson person = 
        String.Format("Name = {0}, Age = {1}, Can Drink = {2}", 
            person.name, 
            person.age,
            person.canDrink) 
        |> logit

    logPerson bob        
    
    (*
    Records are immutable so when we need to make a change
    we instead create modified clones. That sounds extensive
    but F# has you covered with the "with" keyword.
    For example:
    *)

    let olderBob = {bob with age = 56}

    logPerson olderBob // This does not effect bob's values
                       // because olderBob is a new record


    Console.ReadKey() |> ignore

    0
