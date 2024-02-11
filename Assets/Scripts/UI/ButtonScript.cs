using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] GameObject pauseBanner;
    [SerializeField] GameObject levelUI;
    public void inGame()
    {
        SceneManager.LoadScene("GameLevel1");
    }
    public void Exit()
    {
        Application.Quit();
    }

    public void Pause()
    {
        Time.timeScale = 0;
        levelUI.SetActive(false);
        pauseBanner.SetActive(true);
    }

    public void Continue()
    {
        Time.timeScale = 1;
        levelUI.SetActive(true);
        pauseBanner.SetActive(false);
    }

    public void inMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void NextLevel()
    {
        SceneManager.LoadScene("GameLevel2");
    }
}
