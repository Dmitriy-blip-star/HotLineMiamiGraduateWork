using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] private GameObject _pauseBanner;
    [SerializeField] private GameObject _levelUI;
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
        _levelUI.SetActive(false);
        _pauseBanner.SetActive(true);
    }

    public void Continue()
    {
        Time.timeScale = 1;
        _levelUI.SetActive(true);
        _pauseBanner.SetActive(false);
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
