module Equality


open System
open Logger


    (*
    The general equality operator is: 
    
    "=" 
    
    it just so happens that this is also the assignment operator
    aswell. How is this possible?
    It's possible because everything in F# is by defualt immutable.
    If an object has a value then = is not assigning, it is 
    calculating equality.

    The inequality operator is far less intuitive and represented by:
    
    "<>". (Someone had too much creative freedom there.)

    Primitives, lists, arrays, tuples, records, and discriminated Unions
    are all considered to be equal if they have the same values.

    
    *)


type Person = {
    name: string; 
    age: int 
    }

let equates =

    let isEqual a b = 
        a = b 

    let compareAndLog a b = 
        isEqual a b |> logit

    compareAndLog 1 1

    let bob1 = { name = "Bob"; age = 25 }

    let bob2 = { name = "Bob"; age = 25 }

    compareAndLog bob1 bob2

    (*
    Ok so notice here that bob1 and bob2 are not the same object
    in memory but are the same object in value. That is the reason
    they equate to the same thing.

    So how do we findout if objects are not the same in memory space?
    Yes we can but it's a tad tedious.

    Does it matter? 
    It depends on what your doing.

    Below is how you compare physical memory space the safe way:

    (Refer to the following link as for why I use the word SAFE.

    https://stackoverflow.com/questions/39217116/how-do-i-check-for-reference-equality-in-f
)
    *)

    let isSameInMemory = LanguagePrimitives.PhysicalEquality
    let a = [1;2;3]
    let b = [1;2;3]
    
    // Structural equality
    compareAndLog a b

    // Physical memory space equality 
    isSameInMemory a b |> logit

    
    Console.ReadKey() |> ignore

    0