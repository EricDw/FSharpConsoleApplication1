module Pattern_Matching


open System
open Logger

    (*
    Patten matching is done via structural equality
    and not physical memory space. That said phyical 
    memory matching can be done and is found inside 
    the Equality module of these notes.

    Things that can be pattern matched in F# include:
        
        - Constants
        - Tuples
        - Records
        - Discriminated Unions
        - Lists
        - Arrays
        - Type test
        - Null

    Let's have a look at a few samples of pattern
    matching.
    *)


(*
    The below code is called De-structural Assignment.
    What's happeing is that the compiler sees that the
    structure of these to objects are the same. Then 
    it sees that a and b have not been bound to a value yet.
    The compiler then assigns 1 to a and 2 to b.
*)
let (a,b) = (1,2)

(*
    De-structural Assignment can be combined with tuples
    and mathimatical operations.
*)
let addTuple (c,d) =
    c + d
    // The input gets bound to the variables,
    // added together, and a result is returned.

(*
    Let's write a more verbose version of the same
    function so that we understand what exactly is happening.
*)
let verboseAddTuple tuple =
    match       // Declares that we want to match something.
        tuple   // The object we want to match.
        with    // Declares the things we want to match against.
        // Code after -> is what will be returned.
        | (e, 0) -> e // no reason to add something to 0 so return e.
        | (0, f) -> f // no reason to add something to 0 so return f.
        | (e, f) -> e + f // Add values and return result.
    
    (*
    So what is happening here and why does it work?
    *)


let matching = 

    // a = 1 because that's what it was assigned to.
    logit a |> ignore
    // b = 2 because that's what it was assigned to.
    logit b |> ignore


    addTuple (5,5) |> logit

    verboseAddTuple (1,0) |> logit

    verboseAddTuple (0,2) |> logit

    verboseAddTuple (3,4) |> logit

    (*
    More complex behavior can be obtained by using the 
    "when" keyword in tandem with predicates.

    Let's build up a common fizzbuzzer using these concepts.
    *)

    let fizzbuzzer i =
        match i with
            | _ when i % 3 = 0 && i % 5 = 0 -> "fizzbuzz"
            | _ when i % 3 = 0 -> "fizz"
            | _ when i % 5 = 0 -> "buzz"
            | _ -> string i
    (*
    The "_" underscore is used to denote that we are not
    actually going to match i with anything. The "when"
    keyword denotes that the following code will contain
    a predicate statement. Basically a true or false statement.

    The "&&" operator is the and operator, one of the very 
    few similairities with other languages. 
    *)

    // Let's try it out
    [1..25] |> List.map fizzbuzzer |> logit
    (*
    I find zygohistomorphic prepromorphisms facsinating so
    let's filter out the numbers too.
    *)
    let isNotNumber (i:string)  =
        match i with
            | _ when i.Contains "1" -> false
            | _ when i.Contains "2" -> false
            | _ when i.Contains "3" -> false
            | _ when i.Contains "4" -> false
            | _ when i.Contains "5" -> false
            | _ when i.Contains "6" -> false
            | _ when i.Contains "7" -> false
            | _ when i.Contains "8" -> false
            | _ when i.Contains "9" -> false
            | _ when i.Contains "0" -> false
            | _ -> true

    [1..25] 
    |> List.map fizzbuzzer 
    |> List.filter isNotNumber
    |> logit





    Console.ReadKey() |> ignore

    0
