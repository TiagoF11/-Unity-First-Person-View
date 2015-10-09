using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace FirstPersonView
{
    public interface IFPV_Camera
    {
        /// <summary>
        /// Manualy update the static camera variable of this component.
        /// </summary>
        void UpdateStaticCamera();

        /// <summary>
        /// Get the camera component of this camera.
        /// </summary>
        /// <returns></returns>
        Camera GetCamera();
    }
}
