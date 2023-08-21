using TestGame.Scripts.Game.Core;

namespace TestGame.Scripts.Game.Enemy
{
	public class EnemyMove: ObjectMove
	{
		private void OnEnable() => SetRunningState(true, true);

		private void OnDisable() => SetRunningState(false, false);
	}
}