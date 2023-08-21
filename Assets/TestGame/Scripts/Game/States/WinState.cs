using TestGame.Scripts.Game.Enemy;
using TestGame.Scripts.Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace TestGame.Scripts.Game.States
{
	public class WinState : MonoBehaviour, IGameState
	{
		[SerializeField] private Image _endGamePanel;
		[SerializeField] private TextMeshProUGUI _targetText;
		private PlayerMove _playerMove;
		private PlayerStateChanger _playerStateChanger;
		private EnemySpawner _enemySpawner;
		private EnemyPool _enemyPool;

		[Inject] private void Construct(PlayerMove playerMove, PlayerStateChanger playerStateChanger, 
			EnemySpawner enemySpawner, PrepareState prepareState, EnemyPool enemyPool)
		{
			_playerMove = playerMove;
			_playerStateChanger = playerStateChanger;
			_enemySpawner = enemySpawner;
			_enemyPool = enemyPool;
		}
		public void ActivateState()
		{
			_playerMove.SetRunningState(false,false);
			_playerStateChanger.SetCharacterState(PlayerStates.Idle);
			_enemySpawner.DeactivateSpawn();
			_enemyPool.HideAll();
			_endGamePanel.gameObject.SetActive(true);
			_targetText.text = "ПОБЕДА!";
		}
	}
}