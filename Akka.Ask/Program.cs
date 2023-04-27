using Akka.Actor;
using Akka.Ask.Actors;

Console.WriteLine("Started");

var sys = ActorSystem.Create("sys");

var worker = sys.ActorOf(Props.Create(() => new Worker()));
var manager = sys.ActorOf(Props.Create(() => new Manager(worker)));

manager.Tell(new Command("from Program.cs", manager));

Console.ReadLine();