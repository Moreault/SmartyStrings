![SmartyStrings](https://github.com/Moreault/SmartyStrings/blob/master/smartystrings.png)

# SmartyStrings
Extension methods to make strings just a little bit smarter.

## RemoveAll
Removes all occurences of the specified string or character from a string.

```cs
//returns "Hello, guy What's up'"
var newString = "Hello, guy!!! What's up!!'".RemoveAll('!');
```

## IsNumeric
True if the string is an integer or floating point number.

```cs
if ("123".IsNumeric())
{
  //do something
}
```

## TrimStart / TrimEnd
Removes all occurences of the specified string from the start or end of a string.

```cs
//returns "guy!!!"
var result = "Hello, guy!!!".TrimStart("Hello, ");
```

## IndexesOf
Returns all indexes of the specified string in a string.

```cs
//returns [7, 34]
var indexes = "Hello, guy!!! Hello, Jessie lady-guy!!!".IndexesOf("guy");
```

## LastIndex
Returns the last index of the string.

```cs
//returns 9
"Hello, guy!!!".LastIndex(); 
```

# Potential breaking changes

1.0.X -> 1.1.X : SmartyStrings no longer references EasyTypeParsing so you'll have to add it to your project if you needed it before