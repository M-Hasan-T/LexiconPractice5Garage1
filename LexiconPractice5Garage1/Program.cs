
namespace LexiconPractice5Garage1
{
    class Program
    {
        static void Main(string[] args)
        {
            UserInterface ui = new UserInterface();

            while (ui.GarageMenu())
                ui.Start();
        }
    }
}