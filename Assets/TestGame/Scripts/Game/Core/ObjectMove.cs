using UnityEngine;

namespace TestGame.Scripts.Game.Core
{
	public class ObjectMove : MonoBehaviour
	{
		[SerializeField] private float _speed;
		private bool _isRunning;
		private bool _isInverseMove;
		private int _direction;
		private void Update() => Move();

		private void Move()
		{
			if (_isInverseMove) _direction = -1;
			else
				_direction = 1;

			if (_isRunning)
				transform.position += Vector3.right * (_direction * (_speed * Time.deltaTime));
		}

		public void SetRunningState(bool value, bool direction)
		{
			_isRunning = value;
			_isInverseMove = direction;
		}
	}
}