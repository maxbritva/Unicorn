using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TestGame.Scripts.Game.Core.FX
{
	public class ExplosionFXPool : MonoBehaviour
	{
		[SerializeField] private GameObject _explosionPrefab;

		[Inject] private DiContainer _diContainer;
		private List<GameObject> _explosionPool = new List<GameObject>();
		private const int StartCount = 5;

		private void Awake() => PoolInitialize();

		public GameObject GetFXFromPool()
		{
			for (int i = 0; i < _explosionPool.Count; i++) 
			{
				if (_explosionPool[i].gameObject.activeInHierarchy == false) {
					_explosionPool[i].gameObject.SetActive(true);
					return _explosionPool[i]; 
				}
			}
			GameObject newObject = SpawnFX();
			newObject.gameObject.SetActive(true);
			return newObject;
		}

		private void PoolInitialize() 
		{
			for (int i = 0; i < StartCount; i++) 
				SpawnFX();
		}

		private GameObject SpawnFX()
		{
			GameObject newObject = _diContainer.InstantiatePrefab(_explosionPrefab, transform);
			_explosionPool.Add(newObject);
			newObject.gameObject.SetActive(false);
			return newObject;
		}
		
	}
}