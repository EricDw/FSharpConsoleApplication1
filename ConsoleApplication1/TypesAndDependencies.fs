module TypesAndDependencies

open System

(*
We use the type keyword to make new
objects something like classes. for
example below is a TwoNumbers type:
*)

type TwoNumbers = int * int

let types =

    /// Takes a TwoNumbers type then adds those numbers
    /// and returns the result.
    let addTwoNumbers ((firstNumber, secondNumber) : TwoNumbers) =
        firstNumber + secondNumber

    let stringToInt number = (Int32.Parse(number))
   
    printfn "Enter a number:"

    let numberOne = Console.ReadLine() |> stringToInt

    printfn "Enter another number:"

    let numberTwo = Console.ReadLine() |> stringToInt

    printfn "%d" (addTwoNumbers (numberOne, numberTwo))

    Console.ReadKey() |> ignore

    0

