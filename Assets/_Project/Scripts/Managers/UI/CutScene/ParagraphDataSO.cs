using UnityEngine;

namespace Managers
{
    [CreateAssetMenu(fileName = "ParagraphData", menuName = "Game/Cutscene/Paragraph Data", order = 0)]
    public class ParagraphDataSO : ScriptableObject
    {
        public Sprite image;
        public string text;
    }
}