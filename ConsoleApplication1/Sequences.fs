module Sequences


open System
open Logger


(*
    Sequnces are basically lists but with one huge advantage
    and that is that they are lazily evaluated!

    Say you take a List and give it a range from 0 to the max
    Int64 value. This would not work because it would take up 
    far to much space and you would get a OOMException.

    But not for a Sequence! A Sequnce does not instantiate it's
    items until they are iterated over.


    Sequences have an insane amount of built int functions and 
    you can check them all out at the Collections.Seq namespace.

    Let's take a look at some things we can do with sequnces.
*)



let sequences = 
    
    // Basic Sequence syntax uses curly braces
    let zeroToTenByTwos =
        seq { 0..2..10 }

    (*
    First thing we notice here is that only the first four
    numbers in the sequence because that's all that gets
    evaluated. If we want to see all the contents we have to
    iterate over them.
    *)
    logit zeroToTenByTwos

    let logSequence s =
        Collections.Seq.iter logit s
    
    // Now we get the whole list printed
    logSequence zeroToTenByTwos
    
    (*
    Let's talk about Collection Comprehesion Syntax. Comprehension Syntax
    allows for applying logic to a supported collection at the same time 
    of creating the collection. It follows this distinct pattern:

        seq {for PATTERN in COLLECTION -> EXPRESSION }

    For a list / array:
        
        List
        [ for PATTERN in COLLECTION -> EXPRESSION ]

        Array
        [| for PATTERN in COLLECTION -> EXPRESSION |]

    Same thing but with the "do" "yield" key words:
    
        seq {for PATTERN in COLLECTION do yield EXPRESSION }

    For a list / array:
        
        List
        [ for PATTERN in COLLECTION do yield EXPRESSION ]

        Array
        [| for PATTERN in COLLECTION do yield EXPRESSION |]

    
    Let's take a look of this in action:

    *)

    let squares = 
        seq {for i in [1..10] -> i * i }
    
    logSequence squares

    let stringify s =
        // do yield = ->
        seq {for i in s do yield i.ToString() }

    squares |> stringify |> logSequence

    // Let's try to get a sequence on one line.
    

    let sequenceToString (s:seq<'a>) =
        
        // grab head then add it to a string until 0 
        // then return the tail and string.
        
        let a = // Convert Seq to a list.
            (Seq.toList s)
         
        // Pump our list through an accumulator loop.
        // This is somewhat how a map function works.
        let rec append 
            (l:list<'a>) // Compiler needs a type hint here 
            accumulator =
            match l.Length with
                | 0 -> accumulator 
                | _ -> append l.Tail (sprintf "%s, %O" accumulator l.Head)

        append a.Tail (a.Head.ToString())
    

    logit "One line!"
    sequenceToString squares |> logit




    Console.ReadKey() |> ignore
    0
