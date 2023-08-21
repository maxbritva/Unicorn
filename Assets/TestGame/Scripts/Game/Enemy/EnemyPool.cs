using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TestGame.Scripts.Game.Enemy
{
	public class EnemyPool : MonoBehaviour
	{
		[SerializeField] private GameObject _enemyPrefab;

		[Inject] private DiContainer _diContainer;
		private List<GameObject> _enemyPool = new List<GameObject>();
		private const int StartCount = 2;

		private void Awake() => PoolInitialize();

		public GameObject GetEnemyFromPool()
		{
			for (int i = 0; i < _enemyPool.Count; i++) 
			{
				if (_enemyPool[i].gameObject.activeInHierarchy == false) {
					_enemyPool[i].gameObject.SetActive(true);
					return _enemyPool[i]; 
				}
			}
			GameObject newObject = SpawnEnemy();
			newObject.gameObject.SetActive(true);
			return newObject;
		}

		private void PoolInitialize() 
		{
			for (int i = 0; i < StartCount; i++) 
				SpawnEnemy();
		}

		private GameObject SpawnEnemy()
		{
			GameObject newObject = _diContainer.InstantiatePrefab(_enemyPrefab, transform);
			_enemyPool.Add(newObject);
			newObject.gameObject.SetActive(false);
			return newObject;
		}

		public void HideAll()
		{
			for (int i = 0; i < _enemyPool.Count; i++) 
				_enemyPool[i].gameObject.SetActive(false);
		}
	}
}