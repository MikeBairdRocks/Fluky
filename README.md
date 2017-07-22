Fluky - A Random Framework
=====
Fluky is a framework to generate random strings, numbers, names, etc. to help reduce some of the monotony particularly while writing automated tests or anywhere else you need anything random data.

[![Build status](https://ci.appveyor.com/api/projects/status/0e1479awo8gmhrfx?svg=true)](https://ci.appveyor.com/project/michaeljbaird/fluky)

Contribution guidelines
-----
* Writing tests
* Code review
* Other guidelines

Features
-----
Fluky is a [NuGet library](https://www.nuget.org/packages/Fluky) that you can add in to your project that will allow you to generate random things using the `Randomizer` class.

Examples
-----

```csharp
var random = new Randomizer();
var firstName = random.FirstName(GenderType.Female); // Catherine
var lastName = random.LastName(); // Jones
var name = random.Name(); // Bruce Romero
var character = random.Character(symbols: false, alpha: true); // '5'
var paragraphs = random.Paragraph(3); // Ke otle je cewi ok ta feca ha hizo im se wade afna akfa. Fi ra he pe iwpa wi fo wo ca kepo ri ispa raej og hofa rola. Vake voha jira li nido jo ka mi iv me rohi be immo ve ilor tasi.
var date = random.Date(minYear: 1950); // 2/18/1983
var age = random.Age(AgeType.Adult); // 33
var number = random.Decimal(1, 20, fix: 20); // 15.02490243037460000000M
var roll = random.Rpg("3d20", sum: true); // 35
var dice = random.Dice(DiceType.D30); // 12
var address = random.Address(shortStreetSuffix: true); // 371 Fafo Tpke
```
