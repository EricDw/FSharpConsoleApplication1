module Tests



open NUnit.Framework
open FunctionsToTest


[<TestFixture>]
type ``When using function`` ()=
    [<Test>]
    member this.``shouldReturnOne returns one`` ()=
        let one = 1
        let shouldBeOne = returnOne()
        Assert.AreEqual(one, shouldBeOne)


