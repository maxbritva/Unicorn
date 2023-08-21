using System.Collections;
using UnityEngine;
using Zenject;

namespace TestGame.Scripts.Game.Core.FX
{
	public class ExplosionSpawner : MonoBehaviour
	{
		private ExplosionFXPool _explosionFXPool;
		private WaitForSeconds _interval = new WaitForSeconds(1f);
		
		public void Initialize(Vector3 position)
		{
			GameObject fxFromPool = _explosionFXPool.GetFXFromPool();
			fxFromPool.transform.position = position;
			//StartCoroutine(TimerToHide(fxFromPool));
		}

		[Inject] private void Construct(ExplosionFXPool explosionFXPool) => _explosionFXPool = explosionFXPool;
		private IEnumerator TimerToHide(GameObject target)
		{
			yield return _interval;
			target.gameObject.SetActive(false);
		}
	}
}