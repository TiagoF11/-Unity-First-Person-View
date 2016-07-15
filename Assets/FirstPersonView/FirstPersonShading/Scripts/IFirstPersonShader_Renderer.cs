using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstPersonView
{
    public interface IFirstPersonShader_Renderer
    {
        void Setup();
        void EnableFirstPersonView();
        void DisableFirstPersonView();
    }
}
