using UnityEngine;

namespace FirstPersonView
{
    public class FirstPersonShader_WorldCamera : MonoBehaviour
    {
        public static Matrix4x4 WorldToCamToProjection;
        
        public Camera cam { get; private set; }

        private bool d3d;

        void Awake()
        {
            d3d = SystemInfo.graphicsDeviceVersion.IndexOf("Direct3D") > -1;
            cam = GetComponent<Camera>();
        }
        
        void LateUpdate()
        {
            WorldToCamToProjection = PrepareProjection(cam.projectionMatrix) * cam.worldToCameraMatrix;
        }

        private Matrix4x4 PrepareProjection(Matrix4x4 p)
        {
            if (d3d)
            {
                // Invert Y for rendering to a render texture
                for (int i = 0; i < 4; i++)
                {
                    p[1, i] = -p[1, i];
                }
                // Scale and bias from OpenGL -> D3D depth range
                for (int i = 0; i < 4; i++)
                {
                    p[2, i] = p[2, i] * 0.5f + p[3, i] * 0.5f;
                }
            }

            return p;
        }
    }
}