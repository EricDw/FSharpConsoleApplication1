[<RequireQualifiedAccess>]
module Modules 

    (*
    Modules can contain modules and values but not namespaces.

    Modules can use objects in namespaces by opening them with
    the open keyword. The same thing can be donw with other modules
    as well.

    *)

open System 
open Logger


    // RequireQualifiedAccess

    (*
    RequireQualifedAccess attribute, like the one at the top
    of this module, prevents the modules from being opened.

    That means that anything in this module must be accesed
    with the full name qualification. 

    A good example of this is with List functions. 

    I can not type this:

    open List

    map someList aFunction

    I get a compilation error, instead I have to do this:

    List.map someList aFunction
    *)



let doStuff = 
    logit "Stuff has been did"

    Console.ReadKey() |> ignore

    0

   