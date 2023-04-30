using UnityEngine;
using Unity.Netcode;

namespace HelloWorld
{
    public class HelloWorldPlayer : NetworkBehaviour
    {
        //public NetworkVariable<Vector3> Position = new NetworkVariable<Vector3>();
        private Vector3 _SpawnPos = Vector3.zero;
        public bool isSpawned = false;

        [SerializeField] private float movementSpeed = 5f;
        [SerializeField] private float rotationSpeed = 500f;

        public override void OnNetworkSpawn()
        {
            if (IsOwner)
            {
                Move();
                isSpawned = true;
                _SpawnPos = GetRandomPositionOnPlane();
            }
            
        }

        public void Move()
        {
            if (NetworkManager.Singleton.IsServer)
            {
                var randomPosition = GetRandomPositionOnPlane();
                transform.position = randomPosition;
                _SpawnPos = randomPosition;
            }
            else
            {
                SubmitPositionRequestServerRpc();
            }
        }

        [ServerRpc]
        void SubmitPositionRequestServerRpc(ServerRpcParams rpcParams = default)
        {
            /*Debug.Log("Spawned");
            Position.Value = GetRandomPositionOnPlane();
            isSpawned = true;*/
        }

        static Vector3 GetRandomPositionOnPlane()
        {
            return new Vector3(Random.Range(-3f, 3f), 1f, Random.Range(-3f, 3f));
        }

        void Update()
        {
            if (isSpawned)
            {
                transform.position = _SpawnPos;
                isSpawned = false;
                Debug.Log("Position Value: " + _SpawnPos);
            }
            if (!IsOwner) return;
            float horiInput = Input.GetAxis("Horizontal");
            float vertinput = Input.GetAxis("Vertical");

            Vector3 movDirection = new Vector3(horiInput, 0, vertinput);
            movDirection.Normalize();

            transform.Translate(movDirection * movementSpeed * Time.deltaTime, Space.World);

            if(movDirection != Vector3.zero)
            {
                Quaternion toRot = Quaternion.LookRotation(movDirection, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRot, rotationSpeed * Time.deltaTime);
            }
        }
    }
}
