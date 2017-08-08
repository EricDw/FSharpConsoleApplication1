module Tests



open Xunit
open FunctionsToTest


    [<Fact>]
    let ShouldReturnOneReturnsOne() =
        let one = 1
        let shouldBeOne = returnOne()
        Assert.Equal(one, shouldBeOne)


