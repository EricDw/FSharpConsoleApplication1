#r "/Users/dewil/Documents/Visual Studio 2017/Projects/ConsoleApplication1/packages/FsCheck.2.9.0/lib/net452/FsCheck.dll"

open FsCheck


(*
    Besides unit tests there is something else we can do 
    to enusure the quality of our programs, and that is 
    Property Checking. 
    
    Instead of testing certain scenarios we can test the
    properties of our application that should always hold
    to be true.

    Let's look at an example using the FsCheck framework

    The really cool part here is that we can run this in
    the F# interactive! 
    
    1. Highlight everything but the Check.Quick line 
    2. Hit Alt + Enter. 
    3. Select the Check.quick lines 
    4. Hit Alt+Enter.

    If FsCheck finds a fault with our code it will tell 
    us how to make it fail in the most siple way possible.
    This is really valuable!

*)

let concatonatedListLength list1 list2 = 
    (list1 @ list2).Length = list1.Length + list2.Length


Check.Quick concatonatedListLength