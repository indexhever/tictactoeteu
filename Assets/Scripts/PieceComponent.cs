using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TicTacToe
{
    public class PieceComponent : MonoBehaviour, IPointerClickHandler, IPositionHandler
    {
        private Piece peace;
        [SerializeField]
        private SpriteRenderer spriteRenderer;

        // TODO: initialize icon container
        public void Initialize(Piece peace)
        {
            this.peace = peace;
            this.peace.SetPositionHandler(this);
            //spriteRenderer.sprite.pixelsPerUnit

        }

        public void Initialize(Piece peace, Vector2 referencePosition, float offset)
        {
            Initialize(peace);
            SetInitialPosition(referencePosition, offset);
        }

        public void SetInitialPosition(Vector2 referencePosition, float offset)
        {
            Vector2 newPiecePosition = new Vector2();
            newPiecePosition.x = referencePosition.x + spriteRenderer.sprite.bounds.extents.x * peace.Column * offset;
            newPiecePosition.y = referencePosition.y - spriteRenderer.sprite.bounds.extents.y * peace.Row * offset;
            UpdatePosition(newPiecePosition);
        }



        public void OnPointerClick(PointerEventData eventData)
        {
            //peace.Touch(GetCurrentPlayerIcon());
            Debug.Log("Piece pressed");
        }

        // TODO: Get player icon from a player controller
        private PieceIcon GetCurrentPlayerIcon()
        {
            return PieceIcon.None;
        }

        private void ChangeSpriteImage(Sprite newSprite)
        {
            spriteRenderer.sprite = newSprite;
        }

        public void UpdatePosition(Vector3 newPosition)
        {
            transform.position = newPosition;
        }
    }
}
