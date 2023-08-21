using TestGame.Scripts.Game.Enemy;
using TestGame.Scripts.Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace TestGame.Scripts.Game.States
{
	public class LooseState : MonoBehaviour, IGameState
	{
		[SerializeField] private Image _endGamePanel;
		[SerializeField] private TextMeshProUGUI _targetText;
		private PlayerMove _playerMove;
		private PlayerStateChanger _playerStateChanger;
		private EnemySpawner _enemySpawner;

		[Inject] private void Construct(PlayerMove playerMove, PlayerStateChanger playerStateChanger, EnemySpawner enemySpawner, PrepareState prepareState)
		{
			_playerMove = playerMove;
			_playerStateChanger = playerStateChanger;
			_enemySpawner = enemySpawner;
		}
		public void ActivateState()
		{
			_playerMove.SetRunningState(false,false);
			_playerStateChanger.SetCharacterState(PlayerStates.Loose);
			_enemySpawner.DeactivateSpawn();
			_endGamePanel.gameObject.SetActive(true);
			_targetText.text = "КОНЕЦ ИГРЫ!";
		}
	}
}