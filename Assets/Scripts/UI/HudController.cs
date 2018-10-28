using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TicTacToe.UI
{
    public class HudController : MonoBehaviour
    {
        [SerializeField]
        private Text textMessage;

        public void Initialize()
        {
            TurnOffMessage();
        }

        private void TurnOnMessage()
        {
            textMessage.enabled = true;
        }

        private void TurnOffMessage()
        {
            textMessage.enabled = false;
        }

        public void ShowMessage(string message)
        {
            TurnOnMessage();
            textMessage.text = message;
        }
    }
}
