using UnityEngine;

namespace FirstPersonView
{
    public class FirstPersonShader_Object : MonoBehaviour, IFirstPersonShader_Object
    {
        private IFirstPersonShader_Renderer[] renderers;

        void Awake()
        {
            Setup();
        }

        public void Setup()
        {
            FindAllRenderers();
        }

        private void FindAllRenderers()
        {
            Renderer[] renders = transform.GetComponentsInChildren<Renderer>();
            renderers = new IFirstPersonShader_Renderer[renders.Length];

            for(int i = 0; i < renderers.Length; i++)
            {
                if((renderers[i] = renders[i].GetComponent<IFirstPersonShader_Renderer>()) == null)
                {
                    renderers[i] = renders[i].gameObject.AddComponent<FirstPersonShader_Renderer>();
                }
                renderers[i].Setup();
            }
        }

        public void EnableFirstPersonView()
        {
            for(int i = 0; i < renderers.Length; i++)
            {
                renderers[i].EnableFirstPersonView();
            }
        }

        public void DisableFirstPersonView()
        {
            for (int i = 0; i < renderers.Length; i++)
            {
                renderers[i].DisableFirstPersonView();
            }
        }

    }
}
