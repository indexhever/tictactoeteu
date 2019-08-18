using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TicTacToe.UI;
using Zenject;

namespace TicTacToe
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField]
        private GameObject piecePrefab;

        public override void InstallBindings()
        {
            Container.Bind<GameController>()
                .FromComponentInHierarchy()
                .AsSingle()
                .NonLazy();

            Container.Bind<BoardComponent>()
                .FromComponentInHierarchy()
                .AsSingle()
                .NonLazy();

            Container.Bind<HudController>()
                .FromComponentInHierarchy()
                .AsSingle()
                .NonLazy();

            InstallPieceComponent();
        }

        private void InstallPieceComponent()
        {
            Container.BindFactory<Piece, PieceComponent, PieceComponent.Factory>().FromComponentInNewPrefab(piecePrefab);
        }
    }
}
