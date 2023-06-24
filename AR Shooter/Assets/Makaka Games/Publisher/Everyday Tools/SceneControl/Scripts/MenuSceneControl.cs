using UnityEngine;
using UnityEngine.UI;
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
			//pass panel
			GameManager.instance.hudManager.gameFinishPanels[0].SetActive(true);

			ShowCollectables();
		}
	}
	void ShowCollectables()
	{
		var chemicalSprites = GameManager.instance.GetCollectedChemicals();

        foreach (var item in chemicalSprites)
        {
			GameObject imgObject = new GameObject("collectable");

			RectTransform trans = imgObject.AddComponent<RectTransform>();
			trans.transform.SetParent(GameManager.instance.hudManager.collectablesListpanel.transform); // setting parent

			Image image = imgObject.AddComponent<Image>();

			image.sprite = item;
			image.preserveAspect = true;

		}
		
	}
	public void Quit()
	{
		Application.Quit();
	}
}