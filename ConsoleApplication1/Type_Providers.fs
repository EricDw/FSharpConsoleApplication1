module Type_Providers


open System
open System.Linq
open Logger
open FSharp.Data

(*
    Type Providers!!!! Type Providers are amazing!

    Type Providers are located in the FSharp.Data package
    availabe from Nuget.

    Type Providers take a file name or url and use meta
    programming at compile time to generate code that 
    allows to programer to interact with the data as if 
    was a .NET object.

    One of the biggest advantages to Type Providers is
    the ability to convert possible runtime errors into
    reliable compile time errors. This helps provide
    so much more stability to a program.
*)

// Tell the system the file name and ask it for the data.
let testFile = JsonProvider<"TestJSON.json">.GetSample()


// Create a type we can matching the one from the 
// type provider.
type JsonUser = JsonProvider<"TestJSON.json">.User

// And now we have an array of User objects
// and a type we can play with!
// It's that simple!!!!
let jsonUsers = 
    testFile.Users

// let's create a normal F# type
type User = {   
                id:         int;
                firstName:  string;
                lastName:   string;
                email:      string;
                country:    string
                modified:   DateTime;
                vip:        bool
            }

let typeProviders =

    // Grab the first user from the array
    logit jsonUsers.[0]

    // This function converts a JsonUser
    // to a User.
    let jsonUserToUser (ju:JsonUser) = 
        { id =          ju.Id       
          firstName =   ju.FirstName
          lastName =    ju.LastName
          email =       ju.Email
          country =     ju.Country
          modified =    ju.Modified
          vip =         ju.Vip
        }

    // Take out JsonUser array and conver it
    // to a User array.
    let convertjsonUsersToUsers (jus:array<JsonUser>) =
        Array.map jsonUserToUser jus

    // Now we have a list Users we can do
    // more F# specific things with.
    let users = 
        convertjsonUsersToUsers jsonUsers

    let getVipUsers (u:array<User>) =
        // Get all the vip users using Linq
        // function syntax.
        u.Where(fun u -> u.vip = true)


    let vipUsers = 
        getVipUsers users

    logit vipUsers
     
    let logUsers (userArray:seq<User>) = 
        for u in userArray do 
            logit u
    
    logUsers vipUsers

    let filterVipUsers (userArray:array<User>) = 
        Array.filter (fun u -> u.vip = false) userArray

    let notVipUsers = 
        filterVipUsers users
    
    logUsers notVipUsers

    Console.ReadKey() |> ignore
    0