using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuSceneControl : MonoBehaviour
{
	public void LoadSceneWithScreenOrientationLandscapeLeft(string sceneName)
	{
		Screen.orientation = ScreenOrientation.LandscapeLeft;

		LoadScreenControl.Instance.LoadScene(sceneName);
	}

	public void LoadSceneWithScreenOrientationPortrait(string sceneName)
	{
		Screen.orientation = ScreenOrientation.Portrait;

		LoadScreenControl.Instance.LoadScene(sceneName);
	}

	public void ReloadCurrentScene()
	{
		LoadScreenControl.Instance.LoadScene(SceneManager.GetActiveScene().name);
	}
	public void OnGameOver(bool status)
	{
		GameManager.instance.hudManager.gameFinishPanels[0].transform.parent.gameObject.SetActive(true);

		if (status == true)
		{
			GameManager.instance.hudManager.gameFinishPanels[1].SetActive(true);
		}
		else
		{
			GameManager.instance.hudManager.gameFinishPanels[0].SetActive(true);
		}
	}
	public void Quit()
	{
		Application.Quit();
	}
}