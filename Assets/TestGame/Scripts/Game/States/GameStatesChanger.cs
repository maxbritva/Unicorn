using UnityEngine;
using Zenject;

namespace TestGame.Scripts.Game.States
{
	public enum GameStates
	{
		Prepare,Game,GameOver, Win
	}
	public class GameStatesChanger : MonoBehaviour
	{
		private IGameState _prepareState;
		private IGameState _gameState;
		private IGameState _looseState;
		private IGameState _winState;
		private IGameState _gameOverState;
		private GameStates _currentState;
		public GameStates CurrentState => _currentState;

		private void Start() => SetGameState(GameStates.Prepare);

		[Inject] private void Construct(PrepareState prepareState, GameState gameState,LooseState looseState, WinState winState)
		{
			_prepareState = prepareState;
			_gameState = gameState;
			_winState = winState;
			_looseState = looseState;
		}
		public void SetGameState(GameStates state)
		{
			if (state == GameStates.Prepare)
			{
				_prepareState.ActivateState();
				_currentState = GameStates.Prepare;
			}
			if (state == GameStates.Game)
			{
				_gameState.ActivateState();
				_currentState = GameStates.Game;
				Debug.Log(44);
			}
			if (state == GameStates.GameOver)
			{
				_looseState.ActivateState();
				_currentState = GameStates.GameOver;
			}
			if (state == GameStates.Win)
			{
				_winState.ActivateState();
				_currentState = GameStates.Win;
			}
		}
	}
}