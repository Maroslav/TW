using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strut_Render_Base
{
    public class Renderer
        : IDisposable
    {
        public IntPtr WinHandle;


        public virtual void Init() { }

        public virtual void Draw() { }


        public virtual void Dispose()
        { }
    }
}
