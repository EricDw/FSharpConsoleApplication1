module Exceptions


open System
open Logger


    (*
    Good programming is not happy path programming and it needs
    to account for failure and exceptions.

    In F# we can catch exceptions using the "try with" keywords 
    coupled with the "finnaly" keyword.
    *)


    (*
    First let's learn how to create our own exception type.

    We can create our own Exception types if we like by
    using the "exception" keyword. We thow them using the 
    "raise" keyword.
    *)

// Declare a new exception type
exception EmailTooLongException of string
    

// Declare a method that fails and throws a system exception.

let failed email = 
    // failwith throws an execption.
    failwith (email + " is empty!")
// If we run this method and don't catch the exception
// then the application will crash. Let's deal with that.


let failedTooLong email =
    raise (EmailTooLongException (email + " is too long!"))


let fail =


    // Let's use the try with keywords to catch our exception.
    let tryWith =
        try 
            failed "Booger"
        // with catches the exception
        with
            // Failure is a union that takes a exception
            // and returns the exceptions string option.
            | Failure message -> logit message

    tryWith

    (*
    The "finally" keyword allows us to place a block of
    code into or outside a try..with statement that will
    always execute. For Example:
    *)
    let tryWithFinally =
        try 
        // We have to nest a try with in the try
        // in order to use finally after.
            try 
                failed "An Email"
            with
                | Failure message -> logit message

        finally
            logit "This code always runs"

    tryWithFinally

    // We can control when finally executes if we like.
    // For example:
    let tryFinallyWith =
        try
            try
                failed "An Email"
            finally
                logit "This code always runs"
        with
            | Failure message -> logit message

    tryFinallyWith


    //Let's try catching our custom exception
    let catchLongEmail = 
        try
            failedTooLong "An Email"
        with
            | EmailTooLongException message -> logit message
    
    catchLongEmail

    (*
    When working with F# you will inevitably run into 
    situations where you have to interact with C#.
    C# will throw exceptions at you and you must be
    able to deal with them. C# exeptions have to be
    handled in a special way. Let's take a look at how
    we do that.
    *)

    
    
    let tryWithSpecificCSharp =
        try
            1/0
        with
            // The :? operator will catch C# syle exceptions
            | :? System.DivideByZeroException
                // Casting the C# exception to an F# exception
                as ex ->
                logit ("Infinite is not allowed : " + ex.Message)
                0

    tryWithSpecificCSharp |> ignore

    let functionToTry =
        raise (new System.Exception("General error"))

    let tryWithGenericCSharp functionToRun =
        try
            functionToRun
        with
            | :? System.Exception as ex
            
                // when ensures the exception contains
                // the General error text
                when ex.Message = "General error" ->
                logit ("WTF Error : " + ex.Message)
                0
    
    tryWithGenericCSharp functionToTry |> ignore

    Console.ReadKey() |> ignore

    0