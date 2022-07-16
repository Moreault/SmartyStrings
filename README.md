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