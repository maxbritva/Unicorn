using TestGame.Scripts.Game.Enemy;
using TestGame.Scripts.Player;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace TestGame.Scripts.Game.States
{
	public class PrepareState : MonoBehaviour, IGameState
	{
		[SerializeField] private Button _startGameButton;
		private PlayerMove _player;
		private EnemySpawner _enemySpawner;
		private PlayerStateChanger _playerStateChanger;

		public void ActivateState()
		{
			_startGameButton.gameObject.SetActive(true);
			_player.transform.position = new Vector3(-45f, -5.03f);
			if (_enemySpawner.SpawnEnemyRoutine != null) 
				_enemySpawner.DeactivateSpawn();
			_playerStateChanger.SetCharacterState(PlayerStates.Idle);
			_player.SetRunningState(false, false);
		}

		public void DeactivateButton() => _startGameButton.gameObject.SetActive(false);

		[Inject] private void Construct(EnemySpawner enemySpawner, PlayerMove playerMove, PlayerStateChanger playerStateChanger)
		{
			_enemySpawner = enemySpawner;
			_player = playerMove;
			_playerStateChanger = playerStateChanger;
		}
	}
}