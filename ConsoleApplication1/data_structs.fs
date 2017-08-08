module data_stucts

open Logger
open System


let dataStructs = 


    // STRING SYNTAX

    (*
    The most basic string syntax is the double quotes:
    
    ""
    *)


    printfn "Most basic,
    string syntax"

    (*
    To include quotes in the string use triple quotes 
    to encase the string, for example:
    *)

    // No need to escape the quotes
    printfn """This "string" includes quotes"""

    (*
    Next up we have the Verbatim syntax that ignores
    all escape sequences except quotes
    
    @"". In order 
    ignore th "" in Verbatim we double them up: 
    
    "" ""

    For example:
    *)

    printfn @"This is a verbatim ""String"" that,
    ignores all escapes."

    (*
    Without the @ we have access to escape characters,
    for example:
    *)

    printfn "Verbatim strings\n dont't\t encode\n escape sequences"

    (*
    We can acces individual characters in a string by 
    treating it sort of like an array. We use the .[n]
    syntax to access characters in the string.
    *)

    // Let's try it out
    let aString = "this is a basic string"

    logit """Output should be "this" """

    aString.[0..3] |> logit

    // If we leave off the 0 we get the same thing.
    aString.[..3] |> logit

    // If we shave off the 5 though we get everything.
    aString.[0..] |> logit

    // Let's cut it down to basic.
    aString.[10..] |> logit


    (*
    String contains many insteresting functions for 
    string manipulations that most other languages do not.
    *)


    // UNIT

    (*
    Unit is basically null and used when we don't
    want to return something from our function.

    For example the printfn returns Unit because it does
    work but does not need to return anything. All
    functions must return a value though so Unit is used
    to represent nothing being returned.
    *)

    // Let's try it out
    logit "Output should be Unit in string form,
    i.e. <fun:callingFunctionName@line#CalledFrom>,
    in the case: <fun:dataStuff@97>"
    logit |> logit


    //LISTS

    (*
    Unlike most languages a [] s not an Array. Instead 
    [] represents a linked List, this makes large []s
    expensive to traverse. That being said Lists in F#
    are very nice to work with when they dont't need 
    to contain large data sets due to the plethora
    of helper functions they contain.

    A List in F# can only hold data of the same type.

    First let's have a look at List range syntax.
    *)

    // List with ints from 1 to 8
    let oneToEight = [1..8]

    oneToEight |> logit

    (*
    We can control the way the compiler increments the 
    items in the list. For example lets make a list from
    0 to 8 counting by 2.
    *)
    
    let oneToEightByTwo = [0..2..8]

    oneToEightByTwo |> logit

    (*
    Things get a little quirky when trying to count 
    backwards. To do so we must use negative numbers
    as the increment parameter. This makes sense if
    you think about how the compiler actually has to
    do the work. 
    *)


    // Start at 10 then minus 1..etc..etc
    let countDown = [10..-1..0]

    countDown |> logit

    // Now do it by 2s
    let countDownBy2 = [10..-2..0]

    countDownBy2 |> logit


    (*
    Adding things to a list is done with the "::" cons
    operator.
    *)

    // Let's try adding 0 to a list
    let zeroToEight = 0::oneToEight

    zeroToEight |> logit

    (*
    Adding something to the end of a list is not as
    straight forward. To add to the end we have to 
    put our item into another list and then concatenate
    the lists together. To do this we use the "@" operator
    *)

    // Let's try it out!
    let oneToNine = oneToEight @ [9]

    oneToNine |> logit


    (*
    When Instantiating a list with out using the range
    operator we must deliniate items with ";" semicolons.
    *)

    let ab = ['a';'b']

    let cd = ['c';'d']

    // Stick them together
    ab @ cd |> logit


    // ARRAYS

    (*
    Arrays are instantiated almost like lists except
    we add pipes inside the square brackets, like this:

    [| 1;2;3 |]
    *)


    let oneToThreeArray = [| 1;2;3 |]


    // Access an item by index using .[]
    // much like a String
    oneToThreeArray.[0] |> logit

    (*
    Arrays do not have the "::" cons operator
    or the "@" concat oprator so adding things
    to them is not easy. Sacrifices are made for
    better performance
    *)

    let fourToSixArray = [| 4;5;6 |]



    // TUPLES

    (*
    Tuples are groupings of unnamed but ordered values.
    Tuples can contain values of different types as well.
    Items in a Tuple are deliniated by "," commas.
    *)

    let oneTwoTuple = (1,2)

    // Different types and lengths are allowed.
    let boolIntStringTuple = (true, 1, "string")

    (*
    getting items from a tuple comes in a 1 of two ways.
    If the Tuple contains only two items we can use 
    special functions to access the values. For example:
    *)

    // fst function
    fst oneTwoTuple |> logit

    // snd function
    snd oneTwoTuple |> logit

    (*
    The second way to access the values is by pattern matching.
    For example:
    *)

    let ericTuple = ("Eric", 29)

    let logTuple (name,age) =
        name |> logit
        age |> logit

    logTuple ericTuple

    (*
    So what happend here?
    The structure of the function signature of logTuple
    matches with ericTuples values. When ericTuple was
    passed to the logTuple function the compiler 
    deconstructed the values and assigned them to the
    corresponding parameters or logTuple. We can pass
    any Tuple that matches the signature of logTuple
    to logTuple, for example:
    *)

    let John = ("John", 40)

    logTuple John


    Console.ReadLine() |> ignore

    0