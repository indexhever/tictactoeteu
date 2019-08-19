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

            InstallBoardFactory();
            InstallPieceComponentFactory();
            InstallPieceFactory();
        }

        private void InstallBoardFactory()
        {
            Container.BindFactory<int, Board, Board.Factory>()
                .AsSingle();
        }

        private void InstallPieceComponentFactory()
        {
            Container.BindFactory<Piece, PieceComponent, PieceComponent.Factory>()
                .FromComponentInNewPrefab(piecePrefab)
                .AsSingle();
        }

        private void InstallPieceFactory()
        {
            Container.BindFactory<Board, int, int, Piece, PieceFactory>()
                .AsSingle();
        }
    }
}
