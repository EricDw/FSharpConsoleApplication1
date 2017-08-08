// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.


open Xunit
open FunctionsToTest



[<Fact>]
let ShouldReturnOneReturnsOne() =
    let one = 1
    let shouldBeOne = returnOne()
    Assert.Equal(one, shouldBeOne)



[<EntryPoint>]
let main argv = 
    printfn "%A" argv
    0 // return an integer exit code
