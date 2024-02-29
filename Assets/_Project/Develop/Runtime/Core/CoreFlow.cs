using Develop.Runtime.Bootstrap.Units;
using Develop.Runtime.Utilities;
using Develop.Runtime.Utilities.Logging;
using Cysharp.Threading.Tasks;
using VContainer.Unity;
using Develop.Runtime.Core.Shooting;
using Develop.Runtime.Core.UI;

namespace Develop.Runtime.Core
{
    public class CoreFlow : IStartable
    {
        private readonly LoadingService _loadingService;
        private readonly AirplaneFactory _airplaneFactory;
        private readonly ShootingService _shootingService;
        private readonly CoreController _coreController;
        private readonly TargetFactory _targetFactory;

        public CoreFlow(LoadingService loadingService,
            AirplaneFactory airplaneFactory,
            ShootingService shootingService,
            CoreController coreController,
            TargetFactory targetFactory)
        {
            _loadingService = loadingService;
            _airplaneFactory = airplaneFactory;
            _shootingService = shootingService;
            _coreController = coreController;
            _targetFactory = targetFactory;
        }

        public async void Start()
        {
            await _loadingService.BeginLoading(_shootingService);
            await _loadingService.BeginLoading(_airplaneFactory);
            await _loadingService.BeginLoading(_targetFactory);
            await _loadingService.BeginLoading(_coreController, new LevelConfiguration(10));

            _coreController.StartCore();
            Log.Core.D("CoreFlow.Start()");
            //_sceneManager.LoadScene(RuntimeConstants.Scenes.Bootstrap).Forget();
        }
    }
}