using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TicTacToe
{
    public class PieceComponent : MonoBehaviour, IPointerClickHandler
    {
        private Piece peace;
        [SerializeField]
        private SpriteRenderer spriteRenderer;

        // TODO: initialize icon container
        public void Initialize(Piece peace)
        {
            this.peace = peace;
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
    }
}
