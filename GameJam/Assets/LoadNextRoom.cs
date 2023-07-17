using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextRoom : MonoBehaviour
{
    [SerializeField] string NextRoom;
    
    public void LoadNext()
    {
        SceneManager.LoadScene(NextRoom);
    }
}
