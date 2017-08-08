module LINQ


open System
open System.Linq
open Logger


(*
    LINQ stands for Language Interated Query. LINQ
    Is a syntax for extracting objects from a collection
    based a predicate. To get the full breadth of the
    LINQ systems power we need to open the System.Linq
    namespace like above.

    LINQ comes in two kinds of syntax
        
        1. IEnumerable Extention Funtions
        2. Query Expressions
    
*)

type Person = { name:string; age:int }

let linq =

    // Set up our collection we want to select from
    let people = 

        // Create a random between 1 and 100
        let randomAge = 
            System.Random()
        // Function to create a new Bob Person with a random age
        let newBob i j =
            { name = (sprintf "Bob %A" (i + 1)); age = (randomAge.Next(1,100))} 
        
        // For each int in the sequence we create a new Bob Person
        // and then return the list of Bobs...lol Bobs.
        Collections.List.mapi newBob [1..20]

    let logPeople s = 
        for person in s do
            logit person
    
    logPeople people

    // Let's use LINQ to find all the Bobs age 35
    // or over and log their names to the console
    let namesOfBobsOver35 (l:seq<Person>) =
        
        // We are going to use the extension
        // function syntax here
        l.Where(fun p -> p.age >=35)
         .Select(fun p -> p.name)

    namesOfBobsOver35 people |> logit

       
    let namesOfBobsOver35QuerySyntax =
        
        // We are going to use the query syntax here
            query {
            
                for p in people do
                    where (p.age >= 35)
                    select p.name
            }

    namesOfBobsOver35QuerySyntax |> logit



    Console.ReadKey() |> ignore
    0

