
using UnityEngine;

public class CharacterSwitchManager : MonoBehaviour
{
    [Header("Characters")]
    [SerializeField] private PlayerMovement grandpa;
    [SerializeField] private PlayerMovement child;

    [Header("Camera")]
    [SerializeField] private CameraFollow cameraFollow;
    private PlayerMovement activeCharacter;

    private void Start()
    {
        // Grandpa is the first active character
        activeCharacter = grandpa;

        grandpa.SetActive(true);
        child.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SwitchCharacter();
        }
    }

    private void SwitchCharacter()
    {
        if (activeCharacter == grandpa)
        {
            activeCharacter.SetActive(false);
            activeCharacter = child;
        }
        else
        {
            activeCharacter.SetActive(false);
            activeCharacter = grandpa;
        }

        activeCharacter.SetActive(true);

        Debug.Log("Active Character: " + activeCharacter.name);
    }
}
