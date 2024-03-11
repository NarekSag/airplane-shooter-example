using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Develop.Runtime.Core.Airplane;
using Develop.Runtime.Core.Input;
using Develop.Runtime.Core.Shooting;
using Develop.Runtime.Core.UI;
using Develop.Runtime.Utilities;
using Develop.Runtime.Core.Target;
using UniRx;
using UnityEngine;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;
using Random = UnityEngine.Random;

namespace Develop.Runtime.Core
{
    public class CoreController : ILoadUnit<LevelConfiguration>
    {
        public AirplaneController Player { get; private set; }

        private List<TargetController> _targets;

        private readonly AirplaneFactory _planeFactory;
        private readonly TargetFactory _targetFactory;
        private readonly CoreHudController _coreHudController;
        private readonly CompositeDisposable _disposables = new();
        private readonly ShootingService _shootingService;

        public CoreController(AirplaneFactory planeFactory,
            TargetFactory targetFactory,
            ShootingService shootingService,
            CoreHudController coreHudController)
        {
            _planeFactory = planeFactory;
            _coreHudController = coreHudController;
            _shootingService = shootingService;
            _targetFactory = targetFactory;
        }

        public UniTask Load(LevelConfiguration levelConfiguration)
        {
            LoadPlayer();
            LoadTargets(levelConfiguration.TargetsCount);

            _coreHudController.Initialize(Player, _targets.Count);

            return UniTask.CompletedTask;
        }

        public void StartCore()
        {
            Player.gameObject.SetActive(true);

            foreach(TargetController target in _targets)
                target.gameObject.SetActive(true);
        }

        private void RestartCore()
        {
            _disposables.Dispose();
            UnitySceneManager.LoadScene(RuntimeConstants.Scenes.Core);
        }

        private void LoadPlayer()
        {
            Player = _planeFactory.CreatePlayer(RuntimeConstants.Airplanes.Corncob);
            Player.Input.ShootClick.Subscribe(_ => _shootingService.Shoot(Player)).AddTo(_disposables);
            Player.IsDead.Subscribe(isDead => OnPlayerDead(isDead)).AddTo(_disposables);
            Player.gameObject.SetActive(false);
        }

        private void LoadTargets(int targetsCount)
        {
            _targets = new List<TargetController>(targetsCount);

            for (var i = 0; i < targetsCount; i++)
            {
                Vector3 position = Random.insideUnitSphere * 100;
                TargetController target = _targetFactory.CreateTarget(RuntimeConstants.Targets.HotAirBalloon, position, Quaternion.identity);
                target.IsDead.Subscribe(isDead => OnTargetDie(isDead, target)).AddTo(_disposables);

                target.gameObject.SetActive(false);
                _targets.Add(target);
            }
        }

        private void OnPlayerDead(bool isDead)
        {
            if (!isDead)
                return;

            _coreHudController.ShowGameOver();
            RestartCore();
        }

        private void OnTargetDie(bool isDead, TargetController target)
        {
            if (!isDead)
                return;

            _targets.Remove(target);
            _coreHudController.UpdateTargetCount(_targets.Count);

            if (_targets.Count != 0)
                return;

            _coreHudController.ShowWin();
            RestartCore();
        }
    }

    // TODO: Move to config file
    public readonly struct LevelConfiguration
    {
        public readonly int TargetsCount;

        public LevelConfiguration(int targetsCount)
        {
            TargetsCount = targetsCount;
        }
    }
}