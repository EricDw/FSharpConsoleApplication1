module Functions

open System


let logit a =
    printfn "%A" a

let functions =
    
    (*
    Functions are evaluated from left to right.
    Functions will execute immediatly after they
    have recieved all valid input.
    *)

    let square x = x * x


    (*
    The following expression you might think 
    would equate to 16 (4x4) but it doesn't.
    Instead it equates to 9, this is because 
    3 is all the valid input that square requires.
    Once th compiler has recieved valid input it 
    stops looking for more. It then executes the 
    expression, returns the value, and continues 
    executing the rest of the line. So square 
    could read like so: 

    (square 3) + 1

    *)
    printfn "Output of square 3 + 1 :"
    printfn "%d" (square 3 + 1)

    (*
    To get the desired result we pass the input
    in parenthesis:
    *)

    // This out puts 16 as desired
    printfn "Output of square (3 + 1) :"
    printfn "%d" (square (3 + 1))

    
    // CURRYING (aka Partial Application)
    
    (*
    Currying is when you have a function that takes
    more then one parameter, pass it only one parameter,
    and then store that in another function.
    
    Basically the first parameter is treated as if
    it is always set at that point.

    For example the below method takes two params.
    *)

    let differenceBetweenNumbers x y = x - y |> abs

    
    (*
    
     We will pass only one parameter and 
     store the rest in another value.
     The compiler now treats that value as
     a function that takes only one parameter.
     THAT is currying.
    *)

    let differenceFrom5 = differenceBetweenNumbers 5

    printfn "%A" (differenceFrom5 -5)

    (*
    This works because the compiler takes the function
    and breaks it down into single parameter functions.
    For example:

    for:    let add a b = 
            a + b

    The compiler does this:
    

    let add a =
        let internal b =
            a + b

    The "a" parameter gets placed into the executions contexts
    memory space for access from internal.
    *)
    

    // PREFIX AND INFIX FUNCTIONS

    (*
    Regular functions are prefix functions meaning that
    the name of the function is before any parameters.

    Infix functons are functions that take 2 parameters
    and the name of the funtions goes between the parameters
    For example: 

    +, -, * are just a few infix funtions.

    Infix functions can be used like prefix funtions by
    encasing their names in parenthesis. For example:
    *) 

    let addTwoNumbers a b =
        (+) a b
        // this is the same as: a + b

    addTwoNumbers 1 2 |> logit

    (*
    To create an infix operator we must follow some rules.
        
        1. The name of the operator must be a symbol(s)
        2. The name of the operator must be in parenthesis

    Let's try encapsulating our difference function in a
    prefix operator like so:
    *)

    let (|><|) = differenceBetweenNumbers

    // Let's try it out!

    logit "Output of 10 |><| 11 should be 1:"

    10 |><| 11 |> logit

    (*
    If we chain them, they will execute from left to right
    This happens because functions are left associative.
    For example:

    10 |><| 11 |><| 12

    should output 11 because it executes like this:

    (10 |><| 11) |><| 12
    
    Parensthesis executes first so the output is 11.
    *)

    // Let's try it out!

    logit "Output of 10 |><| 11 |><| 12 should be 11:"

    10 |><| 11 |><| 12 |> logit



    // λs aka LAMDAS!  

    (*
    λs are just functions with no name (anonymous functions).
    λs can be created almost anywhere on the fly. To create
    a λ we use the "fun" keyword, for example:

    fun x -> x + x

    This can be used in parenthesis as a parameter in another
    function, like List.map for example.
    *)

    // Lets try it out!

    logit "List.map (fun x -> x + x) [1,2,3] should output [2;4;6]:"

    let newArray = List.map (fun x -> x + x) [1;2;3]

    logit newArray


    // RECURSIVE FUNCTIONS

    (*
    Recursion is when a method calls itself. In F# we 
    have to inform the compiler that the method is recursive.
    We do this by using the "rec" keyword before the name of 
    our function. For example:

    let rec factorial n =
        if n < 2 then
            1
        else
            n * factorial (n-1)

     First what is the purpose of this functions?
     The purpose of this funtions is to multiply a
     series of natural decending numbers. For example:

     ! = factorial

     4! = 4 x 3 = 12 then 12 x 2 = 24 then 24 x 1 = 24

     24 is the factorial of 4.
    *)

    // Let's try it out!

    logit "The output of factorial 4 should be 24:"

    let rec factorial n =
        if n < 2 then
            1
        else
            n * factorial (n-1)

    factorial 4 |> logit

    
    // PIPING FORWARDS "|>"

    (*
    The pipe operator "|>" forwards the output of
    a functions to the input of another function.
    The compiler only allows for piping to functions
    that take 1 argument. Using currying we can get
    around that limitation, for example:
    *)

    logit "The output should be 12:"

    [1..4]
        |> List.filter (fun i -> i % 2 = 0) // Curry param 2
        |> List.map ((*)2) // Curry param 2
        |> List.sum
        |> logit
    
    (*
    Let's look at what e did here line by line.

    First, we made an array from 1 to 4.

    Second, we filter that array into another array
    containing only values divisible by 2.

    Third, we multiply everything in the new array
    by 2.
    
    Filter and map both take 2 parameters but we only
    pipe in 1. We can do this because we curried the second
    parameter. 
    *)


    // PIPING BACKWARDS "<|"

    (*
    Yes you can pipe backwards too! Let's take a look
    at how we can use backward piping to make two param
    functions into suedo infix functions.
    *)

    logit "The output should be 7:"

    // min returns the smallest of 2 numbers
    12 |> min <| 7 |> logit

    (*
    We used the backwards pipe "<|" to feed in the second
    parameter to th min function. This is the smae thing as:

    min 12 7
    *)

    // MULTI PIPE

    (*
    The forward and backward pipe operators are cool when 
    mixed with currying and the like. Typing all that out
    although is kind of tedious. Because of that we have
    have the multi pipe operators. Multi pipe operators 
    come in two forms: 2 param passing and 3 param passing
    more than that is indicative of problems with your code.
    Although if you must you can use currying to pipe to 
    functions that take more then 3 params. let's have a look
    at the multi pipe operators:
    *)


    // Let's try it out!

    let addTwoNumbers (a,b) = 
        (a,b) ||> (+)
    
    logit "Output should be 3: "

    (1,2) |> addTwoNumbers |> logit

    let generateThreeNumbers =
        (1,2,3)

    let addThreeNumbers a b c =
        a + b + c
    
    logit "Output should be 6: "

    generateThreeNumbers |||> addThreeNumbers |> logit

    let addFourNumbers a b c d =
        a + b + c + d

    logit "Output should be 7: "
    
    generateThreeNumbers |||> addFourNumbers (1) |> logit


    // FUNCTION COMPOSITION OPERATORS

    (*
    Before we were using pipes to move output to input.
    Basically we were composing functions together. F#
    has specific operators for implementing this concept.

    ">>" - Forward function comperator
    "<<" - Backward function comperator

    To compose some functions we have to make sure the
    outputs fit the inputs. For example:
                
                 Forwards

     Function a   | to |   Function b
    int -> string | >> | string -> float


                 Backwards

     Function a   | to |   Function b
    int -> float  | << |  string -> int
    *)

    // Let's try it out

    let minus1 x = x - 1
    let times2 = (*) 2

    // Forwards
    let minus1ThenTimes2 = times2 >> minus1

    logit "Output should be 9:"

    minus1ThenTimes2 5 |> logit

    // Backwards (notice minus1 executes first)
    let times2ThenMinus1 = times2 << minus1

    logit "Output should be 8:"

    times2ThenMinus1 5 |> logit



    Console.ReadLine() |> ignore

    Console.ReadKey |> ignore

    0
