using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject mainPanel;
    [SerializeField] GameObject instructionsPanel;
    [SerializeField] GameObject optionsPanel;

    public void GoToMain()
    {
        mainPanel.SetActive(true);
        instructionsPanel.SetActive(false);
        optionsPanel.SetActive(false);
    }

    public void GoToInstructions ()
    {
        mainPanel.SetActive(false);
        instructionsPanel.SetActive(true);
        optionsPanel.SetActive(false);
    }

    public void GoToOptions()
    {
        mainPanel.SetActive(false);
        instructionsPanel.SetActive(false);
        optionsPanel.SetActive(true);
    }

    public void OnPlayClicked()
    {
        SceneManager.LoadScene("main");
    }

    public void QuitGame ()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
      Application.Quit();
#endif
    }
}
