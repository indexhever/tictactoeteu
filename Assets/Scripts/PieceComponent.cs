using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace TicTacToe
{
    public class PieceComponent : MonoBehaviour, IPointerClickHandler, IPositionHandler
    {
        private Sprite initialSprite;
        private GameController gameController;
        private Piece piece;
        [SerializeField]
        private SpriteRenderer spriteRenderer;        

        [Inject]
        public void Construct(GameController gameController, Piece piece)
        {
            this.gameController = gameController;
            this.piece = piece;
        }

        public void Initialize(Vector2 referencePosition, float offset)
        {
            initialSprite = spriteRenderer.sprite;
            SetInitialPosition(referencePosition, offset);
        }

        public void SetInitialPosition(Vector2 referencePosition, float offset)
        {
            Vector2 newPiecePosition = new Vector2();
            newPiecePosition.x = referencePosition.x + spriteRenderer.sprite.bounds.extents.x * piece.Column * offset;
            newPiecePosition.y = referencePosition.y - spriteRenderer.sprite.bounds.extents.y * piece.Row * offset;
            UpdatePosition(newPiecePosition);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            piece.PaintWithIcon(GetCurrentPlayerIcon());
            ChangeSpriteImage(piece.Icon);
            if (piece.CheckPieceMatch())
                gameController.WinGame();
            else
                gameController.UpdateTurn();
        }

        private Icon GetCurrentPlayerIcon()
        {
            Player currentPlayer = gameController.CurrentPlayer;
            return currentPlayer.Icon;
        }

        private void ChangeSpriteImage(Icon iconType)
        {
            ChangeSpriteImage(iconType.sprite);
        }

        private void ChangeSpriteImage(Sprite sprite)
        {
            spriteRenderer.sprite = sprite;
        }

        public void UpdatePosition(Vector3 newPosition)
        {
            transform.position = newPosition;
        }

        public void Reset()
        {
            ChangeSpriteImage(initialSprite);
        }

        public class Factory : PlaceholderFactory<Piece, PieceComponent>
        {

        }
    }
}
