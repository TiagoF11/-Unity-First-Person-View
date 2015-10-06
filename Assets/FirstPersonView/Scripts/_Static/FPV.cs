using UnityEngine;

namespace FirstPersonView
{
    /// <summary>
    /// Static Class for the First Person Viewer Instantiation Methods.
    /// </summary>
    public static class FPV
    {

        /// <summary>
        /// Instantiate a new gameobject and automatically add it to the FPV Container of Generic Type.
        /// </summary>
        /// <param name="original"></param>
        /// <param name="position"></param>
        /// <param name="rotation"></param>
        /// <returns></returns>
        public static GameObject Instantiate(Object original, Vector3 position, Quaternion rotation)
        {
            GameObject result = Object.Instantiate(original, position, rotation) as GameObject;
            FPV_Container.AddGenericFPO(result); //Add to container 
            return result;
        }

        /// <summary>
        /// Instantiate a new gameobject and automatically add it to the FPV Container of DisableOnly Type.
        /// </summary>
        /// <param name="original"></param>
        /// <param name="position"></param>
        /// <param name="rotation"></param>
        /// <returns></returns>
        public static GameObject InstantiateDisableOnlyFPO(Object original, Vector3 position, Quaternion rotation)
        {
            GameObject result = Object.Instantiate(original, position, rotation) as GameObject;
            FPV_Container.AddDisableOnlyFPO(result); //Add to container 
            return result;
        }

        /// <summary>
        /// Instantiate a new gameobject and automatically add it to the FPV Container of Generic type.
        /// </summary>
        /// <param name="original"></param>
        /// <returns></returns>
        public static GameObject Instantiate(Object original)
        {
            return Instantiate(original, Vector3.zero, Quaternion.identity);
        }

        /// <summary>
        /// Instantiate a new gameobject and automatically add it to the FPV Container of DisableOnly type.
        /// </summary>
        /// <param name="original"></param>
        /// <returns></returns>
        public static GameObject InstantiateDisableFPO(Object original)
        {
            return InstantiateDisableOnlyFPO(original, Vector3.zero, Quaternion.identity);
        }

    }
}