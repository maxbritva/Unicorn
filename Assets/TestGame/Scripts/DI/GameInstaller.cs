using TestGame.Scripts.Animations;
using TestGame.Scripts.Game.Core.FX;
using TestGame.Scripts.Game.Enemy;
using TestGame.Scripts.Game.States;
using TestGame.Scripts.Player;
using UnityEngine;
using Zenject;

namespace TestGame.Scripts.DI
{
	public class GameInstaller : MonoInstaller
	{
		[SerializeField] private PlayerMove _playerMove;
		[SerializeField] private PlayerStateChanger _playerStateChanger;
		[SerializeField] private ObjectApplyAnimation _objectApplyAnimation;
		[SerializeField] private PrepareState _prepareState;
		[SerializeField] private GameState _gameState;
		[SerializeField] private LooseState _looseState;
		[SerializeField] private WinState _winState;
		[SerializeField] private GameStatesChanger _gameStatesChanger;
		[SerializeField] private EnemyPool _enemyPool;
		[SerializeField] private EnemySpawner _enemySpawner;
		[SerializeField] private ExplosionFXPool _explosionFXPool;
		[SerializeField] private ExplosionSpawner _explosionSpawner;
		public override void InstallBindings()
		{
			Container.Bind<ObjectApplyAnimation>().FromInstance(_objectApplyAnimation).AsSingle().NonLazy();
			Container.Bind<PrepareState>().FromInstance(_prepareState).AsSingle().NonLazy();
			Container.Bind<GameState>().FromInstance(_gameState).AsSingle().NonLazy();
			Container.Bind<LooseState>().FromInstance(_looseState).AsSingle().NonLazy();
			Container.Bind<WinState>().FromInstance(_winState).AsSingle().NonLazy();
			Container.Bind<GameStatesChanger>().FromInstance(_gameStatesChanger).AsSingle().NonLazy();
			Container.Bind<PlayerMove>().FromInstance(_playerMove).AsSingle().NonLazy();
			Container.Bind<PlayerStateChanger>().FromInstance(_playerStateChanger).AsSingle().NonLazy();
			Container.Bind<ExplosionFXPool>().FromInstance(_explosionFXPool).AsSingle().NonLazy();
			Container.Bind<ExplosionSpawner>().FromInstance(_explosionSpawner).AsSingle().NonLazy();
			BindEnemy();
		}


		private void BindEnemy()
		{
			Container.Bind<EnemyPool>().FromInstance(_enemyPool).AsSingle().NonLazy();
			Container.Bind<EnemySpawner>().FromInstance(_enemySpawner).AsSingle().NonLazy();
		}
	}
}