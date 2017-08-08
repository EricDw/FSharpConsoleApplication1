namespace FSharpFundamentalsApp

open CSharpLibrary

(*
While working with F# you will have to interoperate with other
languages from the .NET ecosystem such as C# and VB.NET.

Infact we are already doing so by opening the System namespace.
That's basically how we interact with classes.

But for our fist example let's imagine that we have to opertate 
with the following C# INTERFACE.

    interface ICaneMultiplyNumbers
    {
        int Multiply(int a, int b);
    }

The fist method is to use F#'s built in Object Oriented capabilities.
For example:

    type ClassThatImplements() =
        interface ICaneMultiplyNumbers with
           member this.Multiply (a,b) = a * b

The type is the exact same as class in this case. The name of the class
is appended with parenthesees. The Multiply method in C# is a member
in F# so we have to tell the compiler that we want to provide an 
implementation for that member. The "this" keyword refers to the 
interface we just named. Also notice that the input for th C# interface
was converted into at sigle tuple in the F# implementation.


Sometimes we will need a single object that uses a C# interface
and we don't want to go through the ceremony of seeting up a class.
In this case we can do this:

let multiply (a,b) = { new ICaneMultiplyNumbers
                       with member this.Multiply (a,b) = a * b
                     }

That's it, now multiply can be passed into an object that takes 
an ICaneMultiplyNumbers object.

Let's take a look at the exact code mentioned in action!
*)


type Multiplier() =

    // This is how  instatiate a class in C#
    // and ten calling a method on that class
    let c1 = new Numbers() 
    member this.X = c1.GetOne();

    
    interface ICanMultiplyNumbers with 
        member this.Multiply (a,b) = a * b
