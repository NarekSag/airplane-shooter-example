using Develop.Runtime.Utilities;
using VContainer.Unity;
using UnitySceneManager = UnityEngine.SceneManagement.SceneManager;

namespace Develop.Runtime.Bootstrap
{
    public class BootstrapFlow : IStartable
    {
        private readonly LoadingService _loadingService;
        private readonly ConfigContainer _configContainer;

        public BootstrapFlow(LoadingService loadingService,
            ConfigContainer configContainer)
        {
            _loadingService = loadingService;
            _configContainer = configContainer;
        }
        
        public async void Start()
        {
            await _loadingService.BeginLoading(new ApplicationConfigurationLoadUnit());
            await _loadingService.BeginLoading(_configContainer);

            UnitySceneManager.LoadScene(RuntimeConstants.Scenes.Core);
            //_sceneManager.LoadScene(RuntimeConstants.Scenes.Core).Forget();
        }
    }
}
