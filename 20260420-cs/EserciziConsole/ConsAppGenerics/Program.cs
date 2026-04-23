using ConsAppGenerics;

var arr = new int[] { 3, 7, 1, 44, 2, 6, 99, 5 };
var arr2 = new string[] { "pippo", "pluto", "paperino", "minnie" };

//Console.WriteLine(Utils.GetIndex(arr, 44));
//Console.WriteLine(Utils.GetIndex(arr2, "pluto"));

int[] arr3 = Utils.Sort(arr);

// Essendo passato per riferimento viene ordinato anche l'array di partenza
Console.WriteLine(string.Join(" ", arr3));
Console.WriteLine(string.Join(" ", arr));

var db = new Database<User>();
db.AddItem(new User() { Id = 1, FirstName = "Mario", LastName = "Rossi" });
db.AddItem(new User() { Id = 2, FirstName = "Beppe", LastName = "Verdi" });
db.AddItem(new User() { Id = 3, FirstName = "Carlo", LastName = "Bianchi" });
db.DeleteItem(2);

Console.WriteLine(db.GetItems().Count());

var dbPost = new Database<Post>();
dbPost.AddItem(new Post() { Id = 1, Text = "Hello", ImgPath = ""});
dbPost.AddItem(new Post() { Id = 2, Text = "Ciao a tutti", ImgPath = ""});
