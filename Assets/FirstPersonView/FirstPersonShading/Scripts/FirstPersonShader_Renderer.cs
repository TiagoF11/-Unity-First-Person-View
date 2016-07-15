using UnityEngine;

namespace FirstPersonView
{
    public class FirstPersonShader_Renderer : MonoBehaviour, IFirstPersonShader_Renderer
    {
        private const string DEFAULTSHADER = "Custom/Weapon";

        private Renderer objectRenderer;

        public Material originalMaterial;
        public Material firstPersonMaterial;

        private bool isFirstPersonEnabled;

        public Shader firstPersonShader;

        public void Setup()
        {
            objectRenderer = GetComponent<Renderer>();

            originalMaterial = objectRenderer.sharedMaterial;
            firstPersonMaterial = objectRenderer.material;

            firstPersonMaterial.shader = firstPersonShader == null ? Shader.Find(DEFAULTSHADER) : firstPersonShader;

            DisableFirstPersonView();
        }

        public void EnableFirstPersonView()
        {
            objectRenderer.sharedMaterial = firstPersonMaterial;
            isFirstPersonEnabled = true;
        }

        public void DisableFirstPersonView()
        {
            isFirstPersonEnabled = false;

            Matrix4x4 m = Matrix4x4.identity;
            Matrix4x4 m2 = Matrix4x4.identity;

            firstPersonMaterial.SetMatrix("_INVERSE_MATRIX", m);
            firstPersonMaterial.SetMatrix("_FIRSTPERSON_MATRIX", m2);

            objectRenderer.sharedMaterial = originalMaterial;
        }

        public void OnWillRenderObject()
        {
            if (isFirstPersonEnabled)
            {
                Matrix4x4 modelToWorld = transform.localToWorldMatrix;

                Matrix4x4 m = (FirstPersonShader_WorldCamera.WorldToCamToProjection * modelToWorld).inverse;
                Matrix4x4 m2 = (FirstPersonShader_FirstPersonCamera.WorldToCamToProjection * modelToWorld);

                firstPersonMaterial.SetMatrix("_INVERSE_MATRIX", m);
                firstPersonMaterial.SetMatrix("_FIRSTPERSON_MATRIX", m2);
            }
        }

    }
}