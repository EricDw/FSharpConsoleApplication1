module Discriminated_Unions

open System
open Logger




    (*
    A Discriminated Union (DU) is effectively an enumeration
    or, as known in other languages, an Enum.
    Let's start by instantiating a simple DU that describes
    the days of the week.
    *)

type Day =
    | Monday // | is optional on first element but it does add some visual consistency
    | Tuesday 
    | Wednesday
    | Thursday
    | Friday
    | Saturday
    | Sunday


    (*
    A few details of note here. 
    Elements in the DU have to have their names begin with a capital.
    Monday is acceptable but monday is not. 

    Records can not be defined in a DU, only outside.

    Oddly enough names can be the exact same as the values.
    For example:
    type IntOrBool = Int32 of Int32 | Boolean of Boolean
    This "double naming" is totally valid and common.


    Ok so we have this "Enum" like object but
    what good is it to us? What does it do?

    DUs are commonly used in tandem with pattern matching
    functions. Because the compiler knows all of the possible
    forms a DU can take it can then force the programmer to
    deal with those scenarios.Let's take a look at an example
    of what that means.
    *)


/// <summary>Takes in a number ranging from 1 to 7.
/// Returns the corresponding day of the week
/// as a type.</summary>
let getDayOfWeek numberOfDay =
    match numberOfDay with
    | 1     -> Monday
    | 2     -> Tuesday 
    | 3     -> Wednesday
    | 4     -> Thursday
    | 5     -> Friday
    | 6     -> Saturday
    | 7     -> Sunday
    | _     -> Monday // Anything that is not 1..7


let getWeatherForDay day =
    
    // These could be dyanmically loaded from the internet.
    // But let's just use some dummy values for now.
    
    match day with
    | Monday    -> "Sunny!"
    | Tuesday   -> "Sunny!" 
    | Wednesday -> "Partly Cloudy"
    | Thursday  -> "Rain"
    | Friday    -> "Rain"
    | Saturday  -> "Insane Rain!"
    | Sunday    -> "Meatballs!"


    (*
    We made a DU and the created a method that takes
    an int and pumps out a Day. After that we made a 
    method that takes a Day and spits out a string.

    These pattern matching methods are super safe because
    the compiler will not allow us to put in objects
    that are not Days or ints.
    *)

let week = [1..7]

    (*
    We compose our matcher functions into a single function.
    This function takes an int, matches it to a day, and then
    matches the day to the weather string.

    This code is not so elegant but it displays a little of
    what can be done with DUs and pattern matching.
    *)

let logWeatherForTheDay = getDayOfWeek >> getWeatherForDay >> logit


let logWeatherForTheWeek = 
        week
        |> List.map logWeatherForTheDay

let unions = 

    logWeatherForTheWeek |> ignore
    
    logWeatherForTheDay week.[0]

    Monday.ToString() |> logit

    Monday |> logit
    

    Console.ReadKey() |> ignore

    0

    (*
    DUs do not have to be big an complicated, sometimes they 
    may only have a single case. This is because they can offer
    compile time safety to your functions due to the fact that 
    they DUs can NOT be assigned to other DUs.
    For example:
    *)

type CustomerId = CustomerId of int // Single case DU
type OrderId = OrderId of int       // Single case DU
type ProductId = ProductId of int   // Single case DU

type Product = { description: string; productId: ProductId } 

type Order = { orderId: OrderId; products: List<Product> }

type Name = { first: string; last: string }

type Customer  = { name: Name; customerId: CustomerId }

let unions2 = 
    
    

    let customerBob = { 

        name = { first = "Bob"; last = "Guy"};
        customerId = CustomerId 13013
        (* 
        CustomerId is all the compiler allows and that 
        is trustworthy code. 
        *)
    }

    (*
    Single case DUs also allow for pattern matching but
    without the match keywords. For example:
    *)

    /// Logs a products ID
    let logProduct product = 
        // Internal pattern match to ensure correctness
        // at compile time as well as deconstruction.
        let (ProductId id) = product.productId
        // Pattern match must be parenthesized
        // or it will declare function.

        sprintf "%s, %A" product.description product.productId
        |> logit


    // Let's try it out
    let octocatPlushy = { 
        description = "Fluffy octokitty!" 
        productId = ProductId 1234
    }
    
    logProduct octocatPlushy
    // Uncomment and witness the compiler error
    // logProduct customerBob


    (*
    Quick pattern matching and deconstructions can 
    be done in a parameter as well.
    *)

    let logCustomerId (CustomerId id) =
        logit id

    logCustomerId customerBob.customerId

    // Uncomment and witness the compiler error
    //logCustomerId octocatPlushy.productId

    Console.ReadKey() |> ignore

    0