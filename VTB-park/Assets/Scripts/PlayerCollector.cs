using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerCollector : MonoBehaviour
{
    public int collectedItems = 0;
    public int maxItems = 5;
    public Text counterText; // Текст для отображения счёта
    public AudioClip collectSound; // Звук подбора
    public GameObject finalTriggerZone; // Триггер, который активируется после сбора всех предметов

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        finalTriggerZone.SetActive(false); // Выключаем триггер в начале
        UpdateCounterText();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible")) // Если коснулись собираемого предмета
        {
            collectedItems++;
            Destroy(other.gameObject); // Удаляем предмет
            PlayCollectSound();
            UpdateCounterText();
            Debug.Log("Collect");

            if (collectedItems >= maxItems) // Если собрали всё
            {
                finalTriggerZone.SetActive(true); // Активируем финальную зону
            }
        }
    }

    private void PlayCollectSound()
    {
        if (collectSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(collectSound);
        }
    }

    private void UpdateCounterText()
    {
        if (counterText != null)
        {
            counterText.text = $"Собрано: {collectedItems}/{maxItems}";
        }
    }
}