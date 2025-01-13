using System.Data;

namespace Workshop;

public class Sleigh
{
    public const int MaxPayload = 1000;

    private ICollection<Gift> Gifts { get; } = new List<Gift>();
    private int Payload { get; set; }

    public bool PushGift(Gift gift)
    {
        if (gift.Weight + Payload > MaxPayload) return false;
        Gifts.Add(gift);
        Payload += gift.Weight;
        return true;
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