using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Кот нашёл выход! Уровень пройден.");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}