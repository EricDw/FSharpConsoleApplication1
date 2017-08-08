module Logger

open System

let logit object = 
    printfn "%A" object
    
/// Takes an Option and logs the value of Some to the console.
/// If None then logs the given message to the console. 
let logOp (errorMessage:string) o = 
    match o with 
        | Some value -> value |> logit
        | None -> errorMessage |> logit
