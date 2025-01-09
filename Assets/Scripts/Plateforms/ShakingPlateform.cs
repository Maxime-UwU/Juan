using System.Collections;
using UnityEngine;

public class ShakingPlateform : MonoBehaviour
{
    public float speed = 2f; // Vitesse de mouvement de la plateforme
    public float moveDuration = 1f; // Durée du mouvement de gauche à droite
    public Vector3 targetPosition; // Position finale à atteindre avant de tomber
    private Vector3 initialPosition; // Position de départ de la plateforme
    private bool isMoving = false;
    private Rigidbody rb;

    void Start()
    {
        // On récupère le Rigidbody attaché à la plateforme
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true; // On garde la plateforme "kinématique" au départ pour ne pas être affectée par la physique
        initialPosition = transform.position; // La position initiale de la plateforme
    }

    void OnTriggerEnter(Collider other)
    {
        // Vérifie si c'est le personnage qui entre en collision
        if (other.CompareTag("Player"))
        {
            if (!isMoving) // Empêche de lancer plusieurs fois le mouvement
            {
                isMoving = true;
                StartCoroutine(MovePlatform()); // Démarre le mouvement de la plateforme
            }
        }
    }

    IEnumerator MovePlatform()
    {
        // Déplace la plateforme de gauche à droite pendant 'moveDuration'
        float elapsedTime = 0f;

        while (elapsedTime < moveDuration)
        {
            transform.position = Vector3.Lerp(initialPosition, initialPosition + targetPosition, (elapsedTime / moveDuration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = initialPosition + targetPosition; // Assure que la plateforme arrive à la position cible

        // Après une seconde de mouvement, fait tomber la plateforme
        rb.isKinematic = false; // Permet à la plateforme de subir la gravité
    }
}
