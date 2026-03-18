# Gilded Rose starting position in C# xUnit

## Build the project

Use your normal build tools to build the projects in Debug mode.
For example, you can use the `dotnet` command line tool:

``` cmd
dotnet build GildedRose.sln -c Debug
```

## Run the Gilded Rose Command-Line program

For e.g. 10 days:

``` cmd
GildedRose/bin/Debug/net8.0/GildedRose 10
```

## Run all the unit tests

``` cmd
dotnet test
```

--------------------------------------------------------
Gilded Rose – README Notes
--------------------------------------------------------
This refactor focuses on making the Gilded Rose codebase easier to understand and extend, while keeping all existing behaviour exactly the same. 
The main change is replacing the long conditional logic in UpdateQuality with a simple rule‑based structure. 
Each item type now has its own rule class, and a selector decides which rule to use. 
This keeps the behaviour for each item separate and makes future changes much safer and clearer.
Support for Conjured items has been added as required. These items now degrade in quality twice as fast as normal items.
Comments throughout the code aim to explain intent rather than narrate every line, keeping things readable without adding noise.

--------------------------------------------------------
Program.cs
--------------------------------------------------------
Program.cs has only been tidied lightly. Its purpose is simply to print out item values over a few days, and it forms part of the original code. 
Changing it too much would add unnecessary work and risk altering the expected output. 
I’ve added a few small comments and cleaned up the formatting so it’s easier to follow, while keeping the structure and behaviour exactly the same.

--------------------------------------------------------
Summary
--------------------------------------------------------
The update logic is now clearer, easier to maintain, and easier to extend. 
The behaviour of all existing items is preserved, the new Conjured rule is in place, and the overall codebase is more readable without introducing unnecessary complexity. 
The console runner has been kept close to the original, with only small improvements to make it easier to follow.
