using ConsAppGenerics.Utilities;

var ints = new int[] { 2, 10, 15, 20, 35, 40 };

// crea dei nuovi array applicando la lambda specificata
var newInts = ArrayUtils.Map(ints, x => x * 10);
Console.WriteLine(string.Join(' ', newInts));

var filteredInts = ArrayUtils.Filter(ints, x => x > 20);
Console.WriteLine(string.Join(' ', filteredInts));