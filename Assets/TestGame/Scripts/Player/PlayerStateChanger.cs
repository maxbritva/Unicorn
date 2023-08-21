using Spine.Unity;
using TestGame.Scripts.Animations;
using UnityEngine;
using Zenject;

namespace TestGame.Scripts.Player
{
	public enum PlayerStates
	{
		Idle, Run, Attack, Loose
	}
	public class PlayerStateChanger : MonoBehaviour
	{
		[SerializeField] private SkeletonAnimation _playerAnimation;
		[SerializeField] private AnimationReferenceAsset _idle;
		[SerializeField] private AnimationReferenceAsset _run;
		[SerializeField] private AnimationReferenceAsset _attack;
		[SerializeField] private AnimationReferenceAsset _loose;
		private ObjectApplyAnimation _objectApplyAnimation;

		private void Start() => SetCharacterState(PlayerStates.Idle);

		[Inject] private void Construct(ObjectApplyAnimation objectApplyAnimation) => _objectApplyAnimation = objectApplyAnimation;

		public void SetCharacterState(PlayerStates state)
		{
			if (state == PlayerStates.Idle) 
				_objectApplyAnimation.SetAnimation(_playerAnimation, _idle, true, 1f);
			if (state == PlayerStates.Run) 
				_objectApplyAnimation.SetAnimation(_playerAnimation, _run, true, 1f);
			if (state == PlayerStates.Attack) 
				_objectApplyAnimation.SetAnimation(_playerAnimation, _attack, false, 1f);
			if (state == PlayerStates.Loose) 
				_objectApplyAnimation.SetAnimation(_playerAnimation, _loose, false, 1f);
		}
		
	}
}