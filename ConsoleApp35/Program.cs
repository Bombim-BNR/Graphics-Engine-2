namespace ConsoleApp34
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (Window game = new Window(800, 600, "rabotai"))
            {
                game.Run();
            }

        }
    }
}
