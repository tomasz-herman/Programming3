namespace BarrierExample;

class Program
{
    static void Main(string[] args)
    {
        var barrier = new Barrier(3, _ => Console.WriteLine());
        new Thread(RollDice).Start();
        new Thread(RollDice).Start();
        new Thread(RollDice).Start();
        void RollDice()
        {
            for (int i = 0; i < 5; i++)
            {
                barrier.SignalAndWait();
                Console.Write(D6() + " ");
                barrier.SignalAndWait();
            }
        }
    }

    static int D6()
    {
        return 1 + Random.Shared.Next(6);
    }
}