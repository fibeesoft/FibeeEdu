using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] Button btnStartGame;
	void Start()
	{
		btnStartGame.onClick.AddListener(delegate { SceneChanger.instance.LoadScene((int)Scenes.Game); });
	}
}
