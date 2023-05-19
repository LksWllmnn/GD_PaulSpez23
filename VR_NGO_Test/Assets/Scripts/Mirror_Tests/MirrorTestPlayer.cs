using Mirror;
using UnityEngine;
using UnityEngine.AI;

public class MirrorTestPlayer : NetworkBehaviour
{
    public float rotationSpeed = 5000;
    public float movementSpeed = 5;


    private void Update()
    {
        // take input from focused window only
        if (!Application.isFocused) return;

        // movement for local player
        if (isLocalPlayer)
        {
            float horiInput = Input.GetAxis("Horizontal");
            float vertinput = Input.GetAxis("Vertical");
            Vector3 movDirection = new Vector3(horiInput, 0, vertinput);
            movDirection.Normalize();

            transform.Translate(movDirection * movementSpeed * Time.deltaTime, Space.World);
            
            if (movDirection != Vector3.zero)
            {
                Quaternion toRot = Quaternion.LookRotation(movDirection, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRot, rotationSpeed * Time.deltaTime);
            }
        }
    }
}
