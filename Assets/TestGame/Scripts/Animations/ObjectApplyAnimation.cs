using Spine.Unity;
using UnityEngine;

namespace TestGame.Scripts.Animations
{
	public class ObjectApplyAnimation : MonoBehaviour
	{
		
		public void SetAnimation(SkeletonAnimation target, AnimationReferenceAsset targetAnimation, bool loop, float timeScale) => 
			target.state.SetAnimation(0,targetAnimation, loop).TimeScale = timeScale;
	}
}