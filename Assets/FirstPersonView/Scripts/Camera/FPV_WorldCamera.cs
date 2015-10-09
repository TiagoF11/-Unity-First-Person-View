namespace FirstPersonView
{
    public class FPV_WorldCamera : FPV_Camera
    {
        void Awake()
        {
            SetCamera();
            UpdateStaticCamera();
        }

        /// <summary>
        /// Manualy update the static world camera variable.
        /// </summary>
        public override void UpdateStaticCamera()
        {
            FPV.worldCamera = this;
        }
    }
}
