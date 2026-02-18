using UnityEngine;
using UnityEngine.SceneManagement;

namespace MainMenu
{
    public class MainMenu : MonoBehaviour
    {

        public void PlayGame()
        {
            Debug.Log("<color=green>Начало новой игры...</color>");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        public void QuitGame()
        {
            Debug.Log("<color=red>Игра закрылась!</color>"); 
          
            Application.Quit();
        }

        public void OpenSettings()
        {
            Debug.Log("<color=cyan>Открытие настроек...</color>");
            SceneManager.LoadScene("Settings");
        }
    }
}