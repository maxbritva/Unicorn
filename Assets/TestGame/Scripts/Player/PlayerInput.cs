using System.Collections;
using TestGame.Scripts.Game.Enemy;
using UnityEngine;
using Zenject;

namespace TestGame.Scripts.Player
{
	public class PlayerInput : MonoBehaviour
	{
		[SerializeField] private Camera _camera;
		[SerializeField] private ParticleSystem _attackParticles;
		[SerializeField] private AudioSource _attackSound;
		private PlayerStateChanger _playerStateChanger;
		private PlayerMove _playerMove;
		private WaitForSeconds _interval = new WaitForSeconds(1f);
		
		private void Update() => GetRaycastClick();

		[Inject] private void Construct(PlayerStateChanger playerStateChanger, PlayerMove playerMove)
		{
			_playerStateChanger = playerStateChanger;
			_playerMove = playerMove;
		}

		private void GetRaycastClick()
		{
			if (!Input.GetMouseButtonDown(0)) return;
			Vector3 point = _camera.ScreenToWorldPoint(Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast(point, point, 1000);
			{
				if (!hit) return;
				hit.collider.TryGetComponent(out EnemyDeath enemy);
				if (!enemy) return;
				enemy.Initialize();
				Attack();
			}
		}

		private void Attack()
		{
			_attackParticles.Play();
			_attackSound.Play();
			_playerStateChanger.SetCharacterState(PlayerStates.Attack);
			StartCoroutine(AttackTimer());
		}

		private IEnumerator AttackTimer()
		{
			_playerMove.SetRunningState(false,false);
			yield return _interval;
			_playerMove.SetRunningState(true,false);
			_playerStateChanger.SetCharacterState(PlayerStates.Run);
		}
	}
}