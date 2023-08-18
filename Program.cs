using System;
using System.Threading.Tasks;
using assesment.Controller;

class Program
{
    public async static Task Main(string[] args)
    {
        await UserContoller.Init();
    }
}
