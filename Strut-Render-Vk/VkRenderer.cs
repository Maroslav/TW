using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpVk.HelloTriangle;

namespace Strut_Render_Vk
{
    public class Renderer : Strut_Render_Base.Renderer
    {
        private Program p;


        public override void Init()
        {
            base.Init();

            p = new Program();
            p.InitialiseVulkan(WinHandle);
        }

        public override void Draw()
        {
            base.Draw();
            p.DrawFrame();
        }

        public override void Dispose()
        {
            p.TearDown();
            base.Dispose();
        }
    }
}
