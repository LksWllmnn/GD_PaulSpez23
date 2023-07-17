using UnityEngine;
using UnityEngine.SceneManagement;

public class Room : MonoBehaviour
{
    [SerializeField] Riddle m_Riddle;
    [SerializeField] OpenDoor m_Door;
    [SerializeField] string m_NextRoom;

    private void Start()
    {
        m_Riddle.CS += OpenDoor;
        m_Door.cO += LoadNext;
    }

    void OpenDoor()
    {
        m_Door.Open();
    }

    public void LoadNext()
    {
        SceneManager.LoadScene(m_NextRoom);
    }
}
