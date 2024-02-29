using Develop.Runtime.Core.Airplane;
using Develop.Runtime.Core.Shooting;
using Develop.Runtime.Utilities;
using Develop.Runtime.Utilities.Logging;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using VContainer;
using TMPro;

namespace Develop.Runtime.Core.UI
{
    public sealed class CoreHudController : MonoBehaviour
    {
        [Header("Refs")] [SerializeField] private RectTransform crossHair;
        [SerializeField] TextMeshProUGUI _targetCountText;
        //[SerializeField] private Button shootBtn;

        private AirplaneController _player;
        private RectTransform _canvasRect;
        private ShootingService _shootingService;

        [Inject]
        private void Inject(CoreCanvasProvider coreCanvasProvider, ShootingService shootingService)
        {
            _shootingService = shootingService;
            _canvasRect = coreCanvasProvider.CanvasRect;
        }

        public void Initialize(AirplaneController player, int targetCount)
        {
            _player = player;
            UpdateTargetCount(targetCount);
            //shootBtn.OnClickAsObservable().Subscribe(OnShootClicked).AddTo(this);
            //_player.Input.ShootClick.Subscribe(OnShootClicked).AddTo(this);
        }

        private void OnShootClicked(Unit _)
        {
            _shootingService.Shoot(_player);
        }

        private void Update()
        {
            if (_player == null)
                return;

            Vector3 crossPos = _player.transform.position + _player.transform.forward * 50f;
            crossHair.anchoredPosition = CoordinateTransformer.FromWorldToCanvasLocalPos(crossPos, _player.PlaneCamera, _canvasRect);
        }

        public void ShowGameOver()
        {
            Log.Core.D("GAME OVER");
        }

        public void ShowWin()
        {
            Log.Core.D("WIN");
        }

        public void UpdateTargetCount(int count)
        {
            _targetCountText.text = $"Targets left: {count}";
        }
    }
}