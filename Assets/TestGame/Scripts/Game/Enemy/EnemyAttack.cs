using System.Collections;
using TestGame.Scripts.Player;
using UnityEngine;
using Zenject;

namespace TestGame.Scripts.Game.Enemy
{
	public class EnemyAttack : MonoBehaviour
	{
		
		[SerializeField] private EnemyStateChanger _enemyStateChanger;
		[SerializeField] private EnemyMove _enemyMove;
		[Inject] private EnemyPool _enemyPool;
		private WaitForSeconds _interval = new WaitForSeconds(1.5f);

		private void OnTriggerEnter2D(Collider2D col)
		{
			if (col.TryGetComponent(out PlayerMove playerMove))
			{
				_enemyMove.SetRunningState(false,true);
				StartCoroutine(TimerToHide());
				AttackAnimation();
			}
		}
		private void AttackAnimation() => _enemyStateChanger.SetEnemyState(EnemyStates.Attack);

		private IEnumerator TimerToHide()
		{
			yield return _interval;
			_enemyPool.HideAll();
		}
	}
}