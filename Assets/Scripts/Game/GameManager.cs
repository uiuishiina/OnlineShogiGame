using UnityEngine;


namespace KTC.Game
{
    public class GameManager : MonoBehaviour
    {
        private FixToScale _fixScale = new FixToScale(1240, 10);

        public GameObject piece = null;

        private void Start()
        {
            if (piece == null) {
                return;
            }
            if(!piece.TryGetComponent<SpriteRenderer>(out var renderer)) {
                return;
            }

            float sizeY = _fixScale.GetPieceSize(6) / renderer.sprite.rect.height;

            renderer.transform.localScale *= sizeY;

        }
    }
}