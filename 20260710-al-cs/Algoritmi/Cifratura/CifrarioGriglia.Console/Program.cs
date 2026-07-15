using IalCypher.Lib;

var gridCypher = new GridCypher("The quick brown fox jumps over the lazy dog");

var cifrato = gridCypher.Encrypt("buongiorno");
var decifrato = gridCypher.Decrypt("tcpkvdpjkp");

Console.WriteLine(cifrato);
Console.WriteLine(decifrato);