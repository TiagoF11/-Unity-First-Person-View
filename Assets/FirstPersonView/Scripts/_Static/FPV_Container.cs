using System.Collections.Generic;
using UnityEngine;

namespace FirstPersonView
{
    /// <summary>
    /// Container class of the First Person Viewer Objects.
    /// </summary>
    public static class FPV_Container
    {
        /// <summary>
        /// First Person Render Layer. This MUST be set in the Layer's settings.
        /// </summary>
        public static readonly int FIRSTPERSONRENDERLAYER = LayerMask.NameToLayer("FirstPersonView");

        /// <summary>
        /// Collection of all Generic FPV Objects
        /// </summary>
        private static FPV_Collection<IFPV_Object> _FPVObjects;
        /// <summary>
        /// Collection of all DisableOnly FPV Objects
        /// </summary>
        private static FPV_Collection<IFPV_Object> _FPVObjects_DisableOnly;

        /// <summary>
        /// Constructor
        /// </summary>
        static FPV_Container()
        {
            _FPVObjects = new FPV_Collection<IFPV_Object>();
            _FPVObjects_DisableOnly = new FPV_Collection<IFPV_Object>();
        }

        /// <summary>
        /// Add a GameObject to the container of Generic Type.
        /// It will automatically create all components on the Object.
        /// </summary>
        /// <param name="obj"></param>
        public static void AddGenericFPO(GameObject obj)
        {
            AddGenericFPO(obj.AddComponent<FPV_Object>());
        }
        /// <summary>
        /// Add a GameObject to the container of type DisableOnly FPO.
        /// It will automatically create all components on the Object.
        /// </summary>
        /// <param name="obj"></param>
        public static void AddDisableOnlyFPO(GameObject obj)
        {
            AddDisableOnlyFPO(obj.AddComponent<FPV_Object_DisableOnly>());
        }

        /// <summary>
        /// Add a generic First person object to the container
        /// </summary>
        /// <param name="obj"></param>
        public static void AddGenericFPO(IFPV_Object obj)
        {
            _FPVObjects.Add(obj);
        }
        /// <summary>
        /// Add a Disable Only First Person Object to the container
        /// </summary>
        /// <param name="obj"></param>
        public static void AddDisableOnlyFPO(FPV_Object_DisableOnly obj)
        {
            _FPVObjects_DisableOnly.Add(obj);
        }

        /// <summary>
        /// Remove a generic FPO from the container.
        /// </summary>
        /// <param name="obj"></param>
        public static void RemoveGenericFPO(IFPV_Object obj)
        {
            _FPVObjects.Remove(obj);
        }
        /// <summary>
        /// Remove a Disable Only FPO from the container.
        /// </summary>
        /// <param name="obj"></param>
        public static void RemoveDisableOnlyFPO(FPV_Object_DisableOnly obj)
        {
            _FPVObjects_DisableOnly.Remove(obj);
        }

        /// <summary>
        /// Clear all containers.
        /// </summary>
        public static void ClearContainers()
        {
            _FPVObjects.Clear();
            _FPVObjects_DisableOnly.Clear();
        }

        /// <summary>
        /// Enable First Person Render of all Visible Generic First Person Objects.
        /// </summary>
        public static void EnableFirstPersonViewer()
        {
            Perform_EnableFirstPersonViewer(_FPVObjects.GetEnumerator());
        }
        /// <summary>
        /// Enable First Person Render of all Visible DisableOnly type First Person Objects.
        /// </summary>
        public static void EnableDisableOnlyFirstPersonViewer()
        {
            Perform_EnableFirstPersonViewer(_FPVObjects_DisableOnly.GetEnumerator());
        }

        /// <summary>
        /// Given an Enumerator, Enable the First Person Viewer for every FPV Object.
        /// </summary>
        /// <param name="enumerator"></param>
        private static void Perform_EnableFirstPersonViewer(IEnumerator<IFPV_Object> enumerator)
        {
            while (enumerator.MoveNext())
            {
                enumerator.Current.EnableFirstPersonViewer();
            }
            enumerator.Reset();
        }

        /// <summary>
        /// Disable First Person Render.
        /// This will revert every object to their initial state.
        /// </summary>
        public static void DisableFirstPersonViewer()
        {
            Perform_DisableFirstPersonViewer(_FPVObjects.GetEnumerator());
            Perform_DisableFirstPersonViewer(_FPVObjects_DisableOnly.GetEnumerator());
        }

        /// <summary>
        /// Given an Enumerator, Disable the First Person Viewer for every FPV Object.
        /// </summary>
        /// <param name="enumerator"></param>
        private static void Perform_DisableFirstPersonViewer(IEnumerator<IFPV_Object> enumerator)
        {
            while (enumerator.MoveNext())
            {
                enumerator.Current.DisableFirstPersonViewer();
            }
            enumerator.Reset();
        }
    }
}
