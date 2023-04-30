using UnityEngine;
using Unity.Netcode;

public class ShootFireball : NetworkBehaviour
{
    [SerializeField] private GameObject _projectile;
    private bool _shot = false;
    [SerializeField]private Transform _gun;

    // Update is called once per frame
    void Update()
    {
        if (!IsOwner) return;
        if(Input.GetKey(KeyCode.Space) && !_shot)
        {
            ShootServerRPC();
            _shot = true;
        } else if (!Input.GetKey(KeyCode.Space) && _shot)
        {
            _shot = false;
        }
    }


    [ServerRpc]
    private void ShootServerRPC()
    {
        GameObject go = Instantiate(_projectile, _gun.position, _gun.rotation);
        go.GetComponent<NetworkObject>().Spawn();
        //Vector3 projDirection = transform.forward;
        //go.AddComponent<MoveProjectile>().SetProjectileDirection(projDirection, _gun.position);
    }
}
