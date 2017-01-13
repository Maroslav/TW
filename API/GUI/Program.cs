using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoodAI.ToyWorld.Control;

namespace GUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var controller = ToyWorldFactory.GameFactory.GetGameController(null);

            controller.Init();

            while (true)
            {
                controller.MakeStep();
            }
            
        }
    }
}
