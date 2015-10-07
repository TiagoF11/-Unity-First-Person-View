using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace FirstPersonView
{
    /// <summary>
    /// ------------------ DOES NOT WORK ---------------------
    /// </summary>
    public class FPV_Object_Terrain : FPV_Object_DisableOnly
    {
        protected override void AddNewRenderer(Transform trans)
        {
            Terrain terrain = trans.GetComponent<Terrain>();

            if (terrain != null) //Add new IFPV_Renderer only if the object contains it.
            {
                AddRenderer(null, trans.gameObject.AddComponent<FPV_Renderer_Terrain>());
            }
        }
    }
}
