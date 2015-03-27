# TddExamples

A simple demonstration of some different testing and coding techniques.

## Unit Test Patterns

These are in `TddEXamples.Naming.Tests.WidgetTests.cs`

1. Arrange, Act, Assert or AAA
    1. Using constants to be more specific.
    1. Using TestCase to reduce duplication.
1. [ContextSpecification](http://stevenharman.net/toward-a-better-use-of-context-specification)
    1. Context is Arrange or Given.
    1. BecauseOf is Act or When.
    1. Each test is an assert or a Then.
    1. Integration attribute test to be skipped.

## Coding Examples

`Widget.cs`

1. Constructor injection

`Parsers.cs`

1. Inheritance for something with a domain name.

`ParserMap.cs`

1. Interface segregation; each interface defines a specific use.
1. Strategy pattern, depending on how you look at it.
    * Linq gives you polymorphic behavior, gets rid of 'if'.

`Parser.cs`

1. Each strategy is its own class.
1. A little trickery makes a class think it's an enum with behavior.
