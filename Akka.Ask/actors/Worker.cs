using Akka.Actor;

namespace Akka.Ask.Actors;

public class Worker : ReceiveActor
{
    public Worker()
    {
        Receive<Command>(cmd =>
        {
            // if .Ask, then Sender is not Manager
            var sender = Sender;
            
            // start async work            

            // ack work started
            Sender.Tell(new Started(cmd));
        });
    }
}