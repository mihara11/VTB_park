using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RadiationDeath : MonoBehaviour
{
    [SerializeField] private CapsuleCollider radiationzone;
    [SerializeField] private GameObject Player;

    private void OnCollisionEnter(Collision collision)
    {
        SceneManager.LoadScene(0);
    }
}
