using Input;
using Utilities;

namespace Managers
{
    public class InputManager : SingletonMonoBehaviour<InputManager>
    {
        private InputMaster _input;

        public InputMaster.GameplayActions Gameplay;

        protected override void OnCreateInstance()
        {
            base.OnCreateInstance();
        }

        private void Awake()
        {
            _input = new InputMaster();
            Gameplay = _input.Gameplay;
        }

        private void OnEnable() => _input.Enable();

        private void OnDisable() => _input.Disable();
    }
}