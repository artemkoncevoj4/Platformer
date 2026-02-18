using UnityEngine;
using UnityEngine.SceneManagement;

namespace SettingMenu
{
    public class BtnExit : MonoBehaviour
    {
        public void ReturnBack()
        {
            Time.timeScale = 1f;

            
            Scene settingsScene = SceneManager.GetSceneByName("Settings");

            if (settingsScene.isLoaded)
            {
                
                foreach (GameObject obj in settingsScene.GetRootGameObjects())
                {
                    obj.SetActive(false);
                }

                
                SceneManager.UnloadSceneAsync(settingsScene);
            }
            // Если нужно скрыть курсор обратно после закрытия меню (для шутеров):
            // Cursor.visible = false;
            // Cursor.lockState = CursorLockMode.Locked;
        }
        
        // Если нужно именно выйти в главное меню из настроек
        public void ExitToMainMenu()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(0); 
        }
    }
}