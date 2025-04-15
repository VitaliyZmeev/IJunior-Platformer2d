using UnityEngine;

namespace Platformer2d
{
    [RequireComponent(typeof(Player))]
    public class PlayerBootstrap : MonoBehaviour
    {
        private Player _player;
        private Vector2 _startPosition;

        private void Awake()
        {
            _player = GetComponent<Player>();
            _startPosition = _player.transform.position;
        }

        private void OnEnable()
        {
            _player.Died += OnPlayerDied;
        }

        private void OnDisable()
        {
            _player.Died -= OnPlayerDied;
        }

        private void OnPlayerDied()
        {
            _player.transform.position = _startPosition;
            _player.Init();
        }
    }
}