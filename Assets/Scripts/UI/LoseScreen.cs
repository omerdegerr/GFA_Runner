using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseScreen : MonoBehaviour
{
    [SerializeField]
	private Button _restartButton;

private void OnEnable() 
{
	 _restartButton.onClick.AddListener(OnNextLevelButtonPressed);
}

private void OnDisable() {
     _restartButton.onClick.RemoveListener(OnNextLevelButtonPressed);
    
}

private void OnNextLevelButtonPressed()
	{
		GameInstance.Instance.RestartLevel();
	}


}
