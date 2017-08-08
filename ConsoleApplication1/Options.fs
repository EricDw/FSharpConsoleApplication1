module Options

open System
open Logger

(*
   Most of the time we are interacting with databases or
   files, or REST APIs...etc...etc. When doing so we run
   into one of two scenarios:
        
        1. We get what we want in the way we expect it
        2. We don't

   Besides catching exceptions how do we handle these 
   kinds of scenarios?

   What if we had a type that can be either one of
   the decribed scenarios? In F# we do, it is called
   Option. Option is a Dicriminated Union and can 
   be either the Some(value) or None types.

   Let's take a look at some code that leverages
   the Option type.
*)

let firstOdd xs =
    (*
         List.tryPick takes a function that checks
         an object against a predicate. If the object
         matches the predicate then the function
         returns it wrapped in the Some type.
         Otherwise the function returns None.
    *)
    List.tryPick (fun x -> if x % 2 = 1 then Some x else None) xs


let options = 
    

    firstOdd [1..4] |> logit

    (*
    Let's try returning a string no matter the 
    value.
    *)

    let maybeString a =
        let x = (firstOdd a)
        match x with
            | Some(value) -> value.ToString()
            | None -> "No Match!"
    

    // Let's try it out
    maybeString [1..4] |> logit


    // Let's pass only even numbers
    maybeString [0..2..10] |> logit

    (*
        As a side note this is the perfect
        kind of thing to test with FsCheck!


        The fisrtOdd function can be declared
        in another, more terse, syntax. This 
        syntax is called point free style.
        For example:
    *)

    let pointFreeOdd = // Notice no input parameter

        List.tryPick (fun x -> if x % 2 = 1 then Some x else None)
       

    pointFreeOdd [1..4] // Give input anyway!
    |> logit

    (*
        Let's have a look at a more realistic
        example. Let's try to parse a number
        from a string and then square the number.
    *)

    let toNumberAndSquare o =

        (*
        Option.bind takes a function and an option.
        The function passed into bind needsto return 
        an Option.
        *)
        Option.bind (fun s -> // Beginning of first param
                        let (succeeded, value) = Double.TryParse(s)
                        if succeeded then Some value else None)
                        o // next param 
        // result piped into another bind
        |> Option.bind (fun n -> n*n |> Some)

    // Let's create a functions that logs the result
    let logOption o = 
        match o with 
            | Some value -> value |> logit
            | None -> "Bad input " |> logit

    // Let's create a some small function that will
    // be an intermediary for the toNumberAndSquare 
    // and pointFreeOdd functions

    let intOptionsToStringOption o =
        match o with
            | Some value -> Some (value.ToString())
            | None -> None

    Some "5" |> toNumberAndSquare |> logOption

    Some "foo" |> toNumberAndSquare |> logOption


    [1..4] |> pointFreeOdd |> logOption

    [0..2..10] |> pointFreeOdd |> logOption


    Console.ReadKey() |> ignore

    0