module Choices


open System
open Logger



(*
    Choice is a funny little type and is mostly used
    to detect errors. A Choice is hard to explain so
    let's look at some code fisrt.
*)


let choices =

    let safeDiv num den = 
        if den = 0 then 
            Choice1Of3 "Divide by Zero is not allowed"
        else if num = 0 then
            Choice2Of3 "Divide by Zero is not allowed"
        else
            Choice3Of3 (num / den) 

    safeDiv 0 1 |> logit

    safeDiv 3 1 |> logit


(*
    After looking at this code we can see that the 
    Choice can be one of three types, string, 
    string or int.

    In reality a Choice can be one of any type upto
    a maximum of 7 different types. 

    Choice works something like a pattern match and
    based on the pattern it matches to it is going 
    to return to you a 
    
        Choice#Of# x 
    
    value. Understanding this will allow you to 
    extract and interact with the data Choice 
    gives back to you. You do this with pattern
    matching. For example:

*)
        
    // Here we consume and convert a Choice
    let choiceToTuple c = 
        match c with
            | Choice1Of3 a -> (a, false)
            | Choice2Of3 b -> (b, false)
            | Choice3Of3 c -> ((c.ToString()), true)
 
    
    // Here we make what we are consuming explicit
    let choiceToOption (c:Choice<string,string,int>) = 
        match c with
            | Choice3Of3 x -> Some x
            | Choice2Of3 y -> None
            | Choice1Of3 z -> None


            
    safeDiv 0 1 |> choiceToTuple |> logit

    safeDiv 1 0 |> choiceToTuple |> logit

    safeDiv 3 1 |> choiceToTuple |> logit

    let optionLogger = logOp "Error Message" 

    safeDiv 0 1 |> choiceToOption |> optionLogger

    safeDiv 1 0 |> choiceToOption |> optionLogger

    safeDiv 3 1 |> choiceToOption |> optionLogger



    // Here we extract the value from the Choice directly
    let extractChoiceValueAsString (c:Choice<string,string,int>) = 
        match c with
            | Choice3Of3 x -> x.ToString()
            | _ -> "Empty String"

    safeDiv 0 1 |> extractChoiceValueAsString |> sprintf "The extracted value: %s" |> logit

    safeDiv 3 1 |> extractChoiceValueAsString |> sprintf "The extracted value: %s" |> logit


    
    let extractChoiceValueAsInt (c:Choice<string,string,int>) = 
        match c with
            | Choice3Of3 x -> x
            | _ -> 0


    safeDiv 0 1 |> extractChoiceValueAsInt |> sprintf "The extracted value: %d" |> logit

    safeDiv 3 1 |> extractChoiceValueAsInt |> sprintf "The extracted value: %d" |> logit





    Console.ReadKey() |> ignore

    0