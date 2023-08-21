using Spine.Unity;
using TestGame.Scripts.Game.States;
using UnityEngine;
using Zenject;

namespace TestGame.Scripts.Game.Enemy
{
	public enum EnemyStates
	{
		Run, Attack, Dead, Win
	}
	public class EnemyStateChanger : MonoBehaviour
	{
		[SerializeField] private SkeletonAnimation _enemyAnimation;
		[SerializeField] private AnimationReferenceAsset _run;
		[SerializeField] private AnimationReferenceAsset _attack;
		[SerializeField] private AnimationReferenceAsset _win;
		private GameStatesChanger _gameStatesChanger;

		private void OnEnable() => SetEnemyState(EnemyStates.Run);

		public void SetEnemyState(EnemyStates state)
		{
			if (state == EnemyStates.Run)
			{
				SetAnimation(_run, true,1f);
			}
			if (state == EnemyStates.Attack)
			{
				SetAnimation(_attack, false,1f);
				_gameStatesChanger.SetGameState(GameStates.GameOver);
			}
			if (state == EnemyStates.Dead)
			{
				//death logic
			}
			if (state == EnemyStates.Win)
			{
				SetAnimation(_win, true,1f);
			}
		}
		
		[Inject] private void Construct(GameStatesChanger gameStatesChanger) => _gameStatesChanger = gameStatesChanger;


		private void SetAnimation(AnimationReferenceAsset targetAnimation, bool loop, float timeScale) => 
			_enemyAnimation.state.SetAnimation(0,targetAnimation, loop).TimeScale = timeScale;
	}
}