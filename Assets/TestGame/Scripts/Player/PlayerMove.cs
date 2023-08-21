using TestGame.Scripts.Game.Core;
using TestGame.Scripts.Game.Enemy;
using TestGame.Scripts.Game.States;
using UnityEngine;
using Zenject;

namespace TestGame.Scripts.Player
{
	public class PlayerMove : ObjectMove
	{
		private GameStatesChanger _gameStatesChanger;
		private EnemyPool _enemyPool;

		[Inject] private void Construct(GameStatesChanger gameStatesChanger) => _gameStatesChanger = gameStatesChanger;

		private void OnTriggerEnter2D(Collider2D col)
		{
			if (col.TryGetComponent(out WinCheckPoint winZone)) 
				_gameStatesChanger.SetGameState(GameStates.Win);
		}
	}
}