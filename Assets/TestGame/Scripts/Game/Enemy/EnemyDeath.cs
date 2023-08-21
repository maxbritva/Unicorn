using TestGame.Scripts.Game.Core.FX;
using UnityEngine;
using Zenject;

namespace TestGame.Scripts.Game.Enemy
{
	public class EnemyDeath : MonoBehaviour
	{
		private ExplosionSpawner _explosionSpawner;

		[Inject] private void Construct(ExplosionSpawner explosionSpawner) => _explosionSpawner = explosionSpawner;

		public void Initialize()
		{
			gameObject.SetActive(false);
			_explosionSpawner.Initialize(transform.position);
		}
	}
}