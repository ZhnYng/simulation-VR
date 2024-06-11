using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FirstAidScript : MonoBehaviour
{
    public GameObject textObject; // Reference to the UI text element

    private void Start()
    {
        // Ensure the text is initially hidden
        if (textObject != null)
        {
            textObject.SetActive(false);
        }
    }

    public void OnSelectEnter(XRBaseInteractor interactor)
    {
        // Show the text when the object is clicked
        if (textObject != null)
        {
            textObject.SetActive(true);
        }
    }

    public void OnSelectExit(XRBaseInteractor interactor)
    {
        // Optionally hide the text when the object is no longer clicked
        if (textObject != null)
        {
            textObject.SetActive(false);
        }
    }
}
