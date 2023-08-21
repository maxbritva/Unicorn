using TestGame.Scripts.Game.Enemy;
using TestGame.Scripts.Player;
using UnityEngine;
using Zenject;

namespace TestGame.Scripts.Game.States
{
	public class GameState : MonoBehaviour, IGameState
	{
		private PlayerMove _playerMove;
		private PrepareState _prepareState;
		private PlayerStateChanger _playerStateChanger;
		private EnemySpawner _enemySpawner;

		[Inject] private void Construct(PlayerMove playerMove, PlayerStateChanger playerStateChanger, EnemySpawner enemySpawner, PrepareState prepareState)
		{
			_playerMove = playerMove;
			_playerStateChanger = playerStateChanger;
			_enemySpawner = enemySpawner;
			_prepareState = prepareState;
		}
		public void ActivateState()
		{
			_prepareState.DeactivateButton();
			_playerMove.SetRunningState(true, false);
			_playerStateChanger.SetCharacterState(PlayerStates.Run);
			_enemySpawner.ActivateSpawn();
		}
	}
}