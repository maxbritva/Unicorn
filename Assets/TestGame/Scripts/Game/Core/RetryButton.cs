using TestGame.Scripts.Game.States;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace TestGame.Scripts.Game.Core
{
	public class RetryButton : MonoBehaviour
	{
		[Inject] private GameStatesChanger _gameStatesChanger;
		[SerializeField] private Image _image;
		
		public void Retry()
		{
			_gameStatesChanger.SetGameState(GameStates.Prepare);
			_image.gameObject.SetActive(false);
		}
	}
}