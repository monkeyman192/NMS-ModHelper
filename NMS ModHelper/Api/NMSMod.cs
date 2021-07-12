namespace NMS_ModHelper.Api
{
    public abstract class NMSMod
    {
        #region Core events

        public virtual void Start()
        {

        }

        public virtual void Update()
        {

        }

        #endregion


        #region Input Events

        public virtual void OnKeyDown(KeyCode keyCode)
        {

        }

        public virtual void OnKeyUp(KeyCode keyCode)
        {

        }

        public virtual void OnKeyHeld(KeyCode keyCode)
        {

        }

        public virtual void OnMouseDown(KeyCode keyCode)
        {

        }

        public virtual void OnMouseUp(KeyCode keyCode)
        {

        }

        public virtual void OnMouseHeld(KeyCode keyCode)
        {

        }

        #endregion
    }
}
