using UnityEngine;

namespace SimplePuzzle
{
    [CreateAssetMenu(fileName = "Block", menuName = "Create Block Data", order = 0)]
    public class BlockData : ScriptableObject
    { 
        [field:SerializeField] public Sprite BlockSprite;
        [field:SerializeField] public BlockColor[] ColorsToMatch;
    }
}