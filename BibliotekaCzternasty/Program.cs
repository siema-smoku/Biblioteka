using BibliotekaCzternasty.Services;

namespace BibliotekaCzternasty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var mainService = new MainService();
            mainService.StartProgram();
        }
    }
}