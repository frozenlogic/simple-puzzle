using UnityEngine;

namespace SimplePuzzle
{
    [CreateAssetMenu(fileName = "SimplePuzzle", menuName = "Create Game Settings", order = 0)]
    public class GameSettings : ScriptableObject
    {
        [field:SerializeField] public int StartMovesQty { get; private set; } 
    }
}