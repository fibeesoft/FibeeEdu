using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainWindowTaskChooser : MonoBehaviour
{
    public Button[] taskChooseButtons;
    void Start()
    {
        MainUI.instance.DisplayHideBtnInfo(false);
        for(int i = 0; i < taskChooseButtons.Length; i++)
        {
            int x = i;
            taskChooseButtons[i].onClick.AddListener(delegate { LoadTaskScene(x + 2); });
        }
    }

    void LoadTaskScene(int i)
    {
        SceneManager.LoadScene(i);
    }
}
