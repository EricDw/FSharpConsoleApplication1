module Inference

open System


(*
Notice that no type need to be declared.
However we can explicitly declare types
if we choose to.
*)

let inference = 

    /// Multiplies a number by itself
    let square x = x * x

    printfn "Input a number to square"

    let input = Console.ReadLine()

    let parseNumber number = (Int32.Parse(number))
    

    (*
    Here we take the number from the screen which
    is a string and feed it into the parseNumber
    function. Using the "pipe" operator (|>) we feed
    the result into the square function.
    *)

    let result = parseNumber input |> square

    printfn "%d" result


    // Here we declare the specific type that 
    // can be taken in and returned.
    let square' (x:float) : float = x * x


    Console.ReadLine() |> ignore

    Console.ReadKey |> ignore

    0

