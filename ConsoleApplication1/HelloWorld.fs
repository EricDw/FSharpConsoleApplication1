// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
module HelloWorld

open System


let helloWorld = 

    printfn "What is your name?"
    
    let input = Console.ReadLine()

    printfn "Hello %s" input

    Console.ReadLine() |> ignore

    Console.ReadKey |> ignore

    0
