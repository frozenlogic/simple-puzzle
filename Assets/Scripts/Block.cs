using System;
using UnityEngine;

namespace SimplePuzzle
{
    public class Block : MonoBehaviour
    {
        [SerializeField] private BlockData _blockData;
        private SpriteRenderer _spriteRenderer;
        public const float k_Gap = 0.16f;
        public const int k_DefaultLayer = 2;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _spriteRenderer.sprite = _blockData.BlockSprite;
        }

        public void SetLayer(int layer)
        {
            _spriteRenderer.sortingOrder = k_DefaultLayer + layer;
        }
    }
}