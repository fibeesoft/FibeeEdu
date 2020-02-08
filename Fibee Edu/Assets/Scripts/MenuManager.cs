using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Button btnStartGame;

	void Start()
	{
        GameManager.instance.SwitchTask(Tasks.NoTask);

        btnStartGame.onClick.AddListener(delegate { SceneChanger.instance.LoadScene((int)Scenes.Game); });
        if(MainUI.instance.GetClass() == 0)
        {
            MainUI.instance.DisplaySetClassContainer();
        }
	}

    public void QuitTheGame()
    {
        Application.Quit();
    }

}
