using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PrototypPlayerMovement : NetworkBehaviour
{
    public float rotationSpeed = 500;
    public float movementSpeed = 5;

    [SerializeField]private TextMeshProUGUI m_TextMeshProUGUI;


    private void Update()
    {
        if (!isLocalPlayer) return;
        // Bewegung entlang der horizontalen Achse
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(0f, 0f, verticalInput) * movementSpeed * Time.deltaTime;
        transform.Translate(movement);

        // Rotation um die y-Achse basierend auf der vertikalen Achse
        float rotation = horizontalInput * rotationSpeed * Time.deltaTime;
        transform.Rotate(0f, rotation, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isLocalPlayer) return;
        Debug.Log(other.gameObject.name);
        if (m_TextMeshProUGUI.enabled && other.gameObject.name == "bridge")
        {
            m_TextMeshProUGUI.gameObject.SetActive(false);
        }
        
        Mob mob = other.gameObject.GetComponent<Mob>();
        switch(mob)
        {
            case GoodMob gMob:
                gMob.Interact(true);
                break;
            case BadMob badMob: 
                badMob.Interact(true);
                m_TextMeshProUGUI.gameObject.SetActive(true);
                break;
            default: break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        try
        {
            Mob mob = other.gameObject.GetComponent<Mob>();
            switch (mob)
            {
                case GoodMob gMob:
                    gMob.Interact(false);
                    break;
                case BadMob badMob:
                    badMob.Interact(false);
                    break;
                default: break;
            }
        }
        catch
        {
            Debug.Log("Wasnt A Mob");
        }
    }
}
