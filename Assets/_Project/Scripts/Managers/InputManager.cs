using Input;
using Utilities;

namespace Managers
{
    public class InputManager : SingletonMonoBehaviour<InputManager>
    {
        private InputMaster _input;

        public InputMaster.GameplayActions Gameplay;
        public InputMaster.CutsceneActions Cutscene;

        private void Awake()
        {
            _input = new InputMaster();
            Gameplay = _input.Gameplay;
            Cutscene = _input.Cutscene;
        }

        private void OnEnable() => _input.Enable();

        private void OnDisable() => _input.Disable();
    }
}