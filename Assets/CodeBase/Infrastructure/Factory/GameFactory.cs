using CodeBase.Infrastructure.Assets;
using UnityEngine;

namespace CodeBase.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssets _assetProvider;

        public GameFactory(IAssets assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public GameObject CreateHero(Vector3 at) => this._assetProvider.Instantiate(AssetPaths.HeroHero, at);
        public GameObject CreateHud() => this._assetProvider.Instantiate(AssetPaths.HUDHud);
    }
}