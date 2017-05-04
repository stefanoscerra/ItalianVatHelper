# ItalianVatHelper
A simple C# library for validating and generating italian VAT (partita iva) numbers.

A sample console application generating random valid values is provided.

Usage
-----

Class `ItalianVatHelper` contains methods to calculate and verify the check digit of the VAT number.

The check digit is calculated according to the [Luhn algorithm](https://en.wikipedia.org/wiki/Luhn_algorithm) (see https://it.wikipedia.org/wiki/Partita_IVA)
