using UnityEngine;
using UnityEngine.UI;

public class ImageController : MonoBehaviour
{
    public Image imageComponent; // Referentie naar de Image component
    public Sprite newSprite;     // Een nieuwe Sprite om in te stellen

    private void Start()
    {
        // Zorg ervoor dat de imageComponent is toegewezen in de Unity Editor
        if (imageComponent != null)
        {
            // Zorg ervoor dat de afbeelding zichtbaar is
            imageComponent.gameObject.SetActive(true);
        }
    }

    private void Update()
    {
        // Verander de afbeelding als op de spatiebalk wordt gedrukt
        if (Input.GetKeyDown(KeyCode.Space) && imageComponent != null)
        {
            ChangeImage();
        }
    }

    // Functie om de Sprite van de Image te veranderen
    public void ChangeImage()
    {
        if (newSprite != null)
        {
            imageComponent.sprite = newSprite;
            Debug.Log("Afbeelding is veranderd!");
        }
    }

    // Functie om de transparantie van de afbeelding te veranderen
    public void SetImageTransparency(float alphaValue)
    {
        if (imageComponent != null)
        {
            Color tempColor = imageComponent.color;
            tempColor.a = Mathf.Clamp01(alphaValue); // Zorg ervoor dat alpha tussen 0 en 1 blijft
            imageComponent.color = tempColor;
        }
    }
}
