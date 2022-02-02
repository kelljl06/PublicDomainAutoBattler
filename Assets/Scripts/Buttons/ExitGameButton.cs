using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ExitGameButton : MonoBehaviour
{

    public Button exitButton;

    void Start()
    {
        Button btn = exitButton.GetComponent<Button>();
        btn.onClick.AddListener(PlayClicked);
    }

    public void PlayClicked()
    {
        Debug.Log("Game Exited");
        Application.Quit();
    }
}
