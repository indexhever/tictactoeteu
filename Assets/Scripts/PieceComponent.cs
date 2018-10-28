﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TicTacToe
{
    public class PieceComponent : MonoBehaviour, IPointerClickHandler, IPositionHandler
    {
        private Piece piece;
        [SerializeField]
        private SpriteRenderer spriteRenderer;

        // TODO: initialize icon container
        public void Initialize(Piece peace)
        {
            this.piece = peace;

        }

        public void Initialize(Piece peace, Vector2 referencePosition, float offset)
        {
            Initialize(peace);
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
            piece.Touch(GetCurrentPlayerIcon());
            ChangeSpriteImage(piece.Icon);
            if (piece.CheckPieceMatch())
                ObjectiveControler.Instance.WinGame();
            Debug.Log("Piece pressed");
        }

        // TODO: Get player icon from a player controller
        private IconType GetCurrentPlayerIcon()
        {
            Player currentPlayer = ObjectiveControler.Instance.CurrentPlayer;
            return currentPlayer.iconType;
        }

        private void ChangeSpriteImage(IconType iconType)
        {
            spriteRenderer.sprite = iconType.sprite;
        }

        public void UpdatePosition(Vector3 newPosition)
        {
            transform.position = newPosition;
        }
    }
}