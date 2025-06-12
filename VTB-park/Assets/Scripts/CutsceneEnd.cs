using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraSceneSwitchTrigger : MonoBehaviour
{
    [SerializeField] private string sceneToLoad; // Имя сцены в Build Settings

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Объект {other.name} вошёл в триггер!"); // Проверка срабатывания

        if (other.CompareTag("Camera"))
        {
            Debug.Log("Камера вошла в триггер! Загружаем сцену: " + sceneToLoad);
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    // Проверка, что коллайдер настроен правильно
    private void OnValidate()
    {
        if (GetComponent<Collider>() == null)
        {
            Debug.LogError("Нет коллайдера на объекте!", this);
        }
        else if (!GetComponent<Collider>().isTrigger)
        {
            Debug.LogWarning("Коллайдер не является триггером!", this);
        }
    }
}