void Start()
{
    // Controleer of het Image component correct is ingesteld
    image = GetComponent<Image>();
    if (image == null)
    {
        Debug.LogError("Image component not found! Ensure the script is attached to a GameObject with an Image component.");
    }
    else
    {
        DefaultCursor = image.sprite;
    }
}
