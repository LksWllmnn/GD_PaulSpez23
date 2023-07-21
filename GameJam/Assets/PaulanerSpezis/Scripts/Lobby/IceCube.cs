using UnityEngine;

public class IceCube : MonoBehaviour
{
    public WaterPlant Riddle;
    [SerializeField] AudioSource m_AudioSource;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit sth trigger: " + other.name);
        if (checkAudioCollider(other.name))
        {

        }
        if (!checkCollider(other.name)) {
            Destroy(this.gameObject);
        } else
        {

            Debug.Log("Not Destroy");
            if (other.name == "plantcollider")
            {
                other.gameObject.GetComponent<Plant>().AddHit();
                Destroy(gameObject);
            }
        }
    }

    bool checkCollider(string name)
    {
        switch (name)
        {
            case "PlantEarth": return true;
            case "PlantShaft": return true;
            case "PlantFlower": return true;
            case "shittyBucket": return true;
            case "normalBucket": return true;
                
            case "IceCube(Clone)": return true;
            case "BucketWall":return true;
            case "BucketWall (1)": return true;
            case "BucketWall (2)": return true;
            case "BucketWall (3)": return true;
            case "BucketWall (4)": return true;
            case "BucketWall (5)": return true;
            case "BucketWall (6)": return true;
            case "BucketWall (7)": return true;
            case "BucketWall (8)": return true;
            case "BucketWall (9)": return true;
            case "waterDispencer":
                return true;
            case "CupHandle":
                return true;
            case "plantcollider":
                return true; 
            case "GamJamLobbyCup1":
                return true;
            case "Teller":
                return true;
            case "Direct Interactor":
                return true;
            default: return false;
        }
    }

    bool checkAudioCollider(string name)
    {
        switch(name)
        {
            case "shittyBucket": return true;
            case "normalBucket": return true;
            case "IceCube(Clone)": return false;
            case "BucketWall": return false;
            case "BucketWall (1)": return false;
            case "BucketWall (2)": return false;
            case "BucketWall (3)": return false;
            case "BucketWall (4)": return false;
            case "BucketWall (5)": return false;
            case "BucketWall (6)": return false;
            case "BucketWall (7)": return false;
            case "BucketWall (8)": return false;
            case "BucketWall (9)": return false;
            case "waterDispencer": return true;
            case "Teller":
                return true;
                
            default: return true;
        }
        
    }
}
