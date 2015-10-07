using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace FirstPersonView
{
    public class FPV_WorldCamera : MonoBehaviour
    {
        /// <summary>
        /// Camera component of the WorldCamera
        /// </summary>
        private Camera worldCamera;

        void Awake()
        {
            worldCamera = GetComponent<Camera>();
            UpdateStaticCamera();
        }

        /// <summary>
        /// Manualy update the static world camera variable.
        /// </summary>
        public void UpdateStaticCamera()
        {
            FPV.worldCamera = this;
        }

        /// <summary>
        /// Get the camera component of this camera.
        /// </summary>
        /// <returns></returns>
        public Camera GetCamera()
        {
            return worldCamera;
        }
    }
}
