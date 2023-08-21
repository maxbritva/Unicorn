using System.Collections;
using UnityEngine;
using Zenject;

namespace TestGame.Scripts.Game.Enemy
{
	public class EnemySpawner : MonoBehaviour
	{
		[SerializeField] private Transform _spawnPoint;
		private Coroutine _spawnEnemy;
		private WaitForSeconds _spawnInterval;
		private EnemyPool _enemyPool;

		public Coroutine SpawnEnemyRoutine => _spawnEnemy;

		public void ActivateSpawn() => _spawnEnemy = StartCoroutine(SpawnEnemy());
		public void DeactivateSpawn() => StopCoroutine(_spawnEnemy);

		[Inject] private void Construct(EnemyPool enemyPool) => _enemyPool = enemyPool;

		private IEnumerator SpawnEnemy()
		{
			while (true)
			{
				_spawnInterval = new WaitForSeconds(Random.Range(1f, 3f));
				GameObject enemyFromPool = _enemyPool.GetEnemyFromPool();
				enemyFromPool.transform.position = _spawnPoint.position;
				enemyFromPool.transform.rotation = Quaternion.identity;
				yield return _spawnInterval;
			}
		}
	}
}