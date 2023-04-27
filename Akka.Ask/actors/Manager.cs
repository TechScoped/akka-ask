using Akka.Actor;

namespace Akka.Ask.Actors;

public class Manager : ReceiveActor
{
    private readonly IActorRef WorkerRef;

    public Manager(IActorRef workerRef)
    {
        WorkerRef = workerRef;

        // get command from client
        Receive<Command>(command =>
        {
            WorkerRef.Ask<Started>(command, TimeSpan.FromSeconds(10)).PipeTo(Self, WorkerRef);
        });
    }
}

public record Command(string Id, IActorRef sender);
public record Started(Command? Command = null);