using UnityEngine;

namespace TicTacToe
{
    public interface IPositionHandler
    {
        void UpdatePosition(Vector3 newPosition);
    }
}