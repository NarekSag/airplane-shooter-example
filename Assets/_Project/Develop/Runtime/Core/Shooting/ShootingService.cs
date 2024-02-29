using Cysharp.Threading.Tasks;
using Develop.Runtime.Core.Airplane;
using Develop.Runtime.Utilities;
using UnityEngine;

namespace Develop.Runtime.Core.Shooting
{
    public class ShootingService : ILoadUnit
    {
        private readonly CoreConfigContainer _configContainer;
        private Bullet _bulletPrefab;

        public ShootingService(ConfigContainer configContainer)
        {
            _configContainer = configContainer.Core;
        }

        public UniTask Load()
        {
            _bulletPrefab = AssetService.R.Load<Bullet>($"{RuntimeConstants.Resources.Bullets}{RuntimeConstants.Bullets.UniversalBullet}");
            return UniTask.CompletedTask;
        }

        public void Shoot(AirplaneController airplaneController)
        {
            if (airplaneController != null)
                CreateBullet(airplaneController.FirePivot);
            // TODO: Implement bullet pool
        }

        private Bullet CreateBullet(Transform spawnPoint)
        {
            var instance = Object.Instantiate(_bulletPrefab, spawnPoint.position, spawnPoint.rotation);

            BulletConfig bulletConfig = _configContainer.AirplaneConfig.Bullet;

            int collideMask =
                LayerMask.NameToLayer(RuntimeConstants.PhysicLayers.PlayerBullet);

            instance.Initialize(bulletConfig, collideMask);
            return instance;
        }
    }
}