using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TicTacToe
{
    public class PeaceComponent : MonoBehaviour, IPointerClickHandler
    {
        private Peace peace;
        [SerializeField]
        private SpriteRenderer spriteRenderer;

        // TODO: initialize icon container
        public void Initialize(Peace peace)
        {
            this.peace = peace;
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            //peace.Touch(GetCurrentPlayerIcon());
            Debug.Log("Peace pressed");
        }

        // TODO: Get player icon from a player controller
        private PeaceIcon GetCurrentPlayerIcon()
        {
            return PeaceIcon.None;
        }

        private void ChangeSpriteImage(Sprite newSprite)
        {
            spriteRenderer.sprite = newSprite;
        }
    }
}
