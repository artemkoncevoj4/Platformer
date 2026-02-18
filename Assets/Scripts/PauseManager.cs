using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Проверяем, загружена ли уже сцена Settings
            Scene settingsScene = SceneManager.GetSceneByName("Settings");

            if (!settingsScene.isLoaded)
            {
                OpenSettings();
            }
        }
    }

    public void OpenSettings()
    {
        Time.timeScale = 0f;
        // Загружаем аддитивно
        SceneManager.LoadScene("Settings", LoadSceneMode.Additive);
        
        // Включаем курсор, чтобы можно было нажимать на слайдеры
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}