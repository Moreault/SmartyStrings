![SmartyStrings](https://github.com/Moreault/SmartyStrings/blob/master/smartystrings.png)

# SmartyStrings
Extension methods to make strings just a little bit smarter.

## Gettings started

```c#
//returns "Hello, guy What's up'"
var newString = "Hello, guy!!! What's up!!'".RemoveAll('!');

//returns true
var isNumeric = "123".IsNumeric();

//returns true
var isNumeric = "123.456".IsNumeric();

//returns false
var isNumeric = "One hundred and twenty three point four hundred and fifty six".IsNumeric();
```

# Potential breaking changes

1.0.X -> 1.1.X : SmartyStrings no longer references EasyTypeParsing so you'll have to add it to your project if you needed it before
