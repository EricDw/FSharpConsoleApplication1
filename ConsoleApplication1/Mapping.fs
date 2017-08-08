module Mapping

open System

let mapIt =
    
    let addOne x = x + 1

    let increaseAll array = array |> List.map addOne

    let printNumber number = 
        printf "%d, " number

    
    let originalList = [1; 2; 3; 4]

    printfn "The list before map function:"

    let printNumbers numbers = numbers |> List.map printNumber

    printNumbers originalList |> ignore

    printfn ""

    printfn "The list after going through the map function:"

    increaseAll(originalList) |> printNumbers |> ignore

    Console.ReadKey() |> ignore

    0
