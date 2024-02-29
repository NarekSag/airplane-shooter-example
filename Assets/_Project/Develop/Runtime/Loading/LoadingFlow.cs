using Develop.Runtime.Bootstrap.Units;
using Develop.Runtime.Utilities;
using Cysharp.Threading.Tasks;
using VContainer.Unity;

namespace Develop.Runtime.Loading
{
    public class LoadingFlow : IStartable
    {
        private readonly LoadingService _loadingService;

        public LoadingFlow(LoadingService loadingService)
        {
            _loadingService = loadingService;
        }

        public async void Start()
        {
            await _loadingService.BeginLoading(new FooLoadingUnit(3));
        }
    }
}