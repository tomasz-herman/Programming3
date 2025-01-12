namespace Workshop;

public class Workshop
{
    private const int AssemblyLineCapacity = 8;

    private Sleigh Sleigh { get; } = new();
    private AssemblyLine AssemblyLine { get; } = new(AssemblyLineCapacity);

    public async Task Start(CancellationToken token)
    {
        Task[] assemblers = StartAssemblers(token);
        Task[] wrappers = StartWrappers(token);
        Task santa = StartSanta(token);
        
        await Task.WhenAll(assemblers);
        await Task.WhenAll(wrappers);
        await Task.WhenAll(santa);
    }
    
    /// <summary>
    /// Each Assembler takes a new Gift Order (new Gift()).
    /// Assembles the order, and puts it on the assembly line.
    /// </summary>
    private const int AssemblersCount = 5;
    private Task[] StartAssemblers(CancellationToken token)
    {
        // TODO: Implement assemblers
        return [];
    }
    
    /// <summary>
    /// Each Wrapper takes a new Gift from assembly line.
    /// Wraps the order, and puts it into the Sleigh.
    /// Only one Elf at the time can load a present to the sleigh.
    /// When the sleigh is full they call the Santa to deliver.
    /// </summary>
    private const int WrappersCount = 3;
    private Task[] StartWrappers(CancellationToken token)
    {
        // TODO: Implement wrappers
        return [];
    }
    
    /// <summary>
    /// When called by one of the wrapper to delivers goes out for the delivery.
    /// After he comes back he signals others to resume moving gifts to the sleigh,
    /// and waits again for another call for delivery.
    /// </summary>
    private Task StartSanta(CancellationToken token)
    {
        // TODO: Implement santa
        return Task.Run(() => {});
    }
}