using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RadiationDeathZone3D : MonoBehaviour
{
    public float fadeDuration = 2f; // Длительность эффекта
    public Image fadeImage;        // Чёрный UI Image (на Canvas)
    public Color radiationColor = new Color(0.5f, 1f, 0.5f, 0.5f); // Зелёный оттенок

    private bool isPlayerInside = false;
    private float timer = 0f;
    private Renderer playerRenderer; // Renderer вместо SpriteRenderer (для 3D)

    private void OnTriggerEnter(Collider other) // OnTriggerEnter для 3D
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = true;
            playerRenderer = other.GetComponent<Renderer>(); // Получаем Renderer (MeshRenderer/SkinnedMeshRenderer)
            if (playerRenderer != null)
            {
                playerRenderer.material.color = radiationColor; // Меняем цвет материала
            }
        }
    }

    private void Update()
    {
        if (isPlayerInside)
        {
            timer += Time.deltaTime;

            // Затемнение экрана
            if (fadeImage != null)
            {
                float alpha = Mathf.Clamp01(timer / fadeDuration);
                fadeImage.color = new Color(0, 0, 0, alpha);
            }

            // Замедление времени (опционально)
            Time.timeScale = Mathf.Lerp(1f, 0.1f, timer / fadeDuration);

            // Перезагрузка сцены после завершения эффекта
            if (timer >= fadeDuration)
            {
                Time.timeScale = 1f; // Возвращаем нормальную скорость
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    // На случай, если игрок выйдет из триггера до смерти
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ResetEffects();
        }
    }

    private void ResetEffects()
    {
        isPlayerInside = false;
        timer = 0f;
        Time.timeScale = 1f;

        if (playerRenderer != null)
        {
            playerRenderer.material.color = Color.white; // Возвращаем стандартный цвет
        }

        if (fadeImage != null)
        {
            fadeImage.color = new Color(0, 0, 0, 0); // Убираем затемнение
        }
    }
}