using Develop.Runtime.Core.Shooting;
using Develop.Runtime.Core.UI;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Develop.Runtime.Core
{
    public sealed class CoreScope : LifetimeScope
    {
        [SerializeField] private CoreCanvasProvider _coreCanvasProvider;
        [SerializeField] private CoreHudController _coreHudController;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponent(_coreCanvasProvider).AsSelf();
            builder.RegisterComponent(_coreHudController).AsSelf();

            builder.Register<ShootingService>(Lifetime.Scoped);
            builder.Register<AirplaneFactory>(Lifetime.Scoped);
            builder.Register<TargetFactory>(Lifetime.Scoped);
            builder.Register<CoreController>(Lifetime.Scoped);

            builder.RegisterEntryPoint<CoreFlow>();
        }
    }
}