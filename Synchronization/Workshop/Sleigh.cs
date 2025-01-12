using System.Data;

namespace Workshop;

public class Sleigh
{
    public const int MaxPayload = 1000;

    // TODO: Choose internal collection implementation
    private ICollection<Gift> Gifts { get; } = null!;
    public int Payload { get; private set; }

    public bool PushGift(Gift gift)
    {
        // TODO: Implement push gift
        return false;
    }

    public void DeliverGifts()
    {
        int payload = 0;
        foreach (var gift in Gifts)
        {
            payload += gift.Weight;
        }

        if (payload >= MaxPayload)
        {
            throw new ConstraintException("Gifts cannot be heavier than maximum payload");
        }
        
        Console.WriteLine("Santa goes out for delivery!");
        Thread.Sleep(Random.Shared.Next(100, 500));
        foreach (var gift in Gifts)
        {
            gift.Deliver();
        }
        Thread.Sleep(Random.Shared.Next(100, 500));
        Console.WriteLine("Santa came back!");
        Gifts.Clear();
        Payload = 0;
    }
}