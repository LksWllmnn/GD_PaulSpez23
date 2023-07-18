using Unity.VisualScripting;
using UnityEngine;

public class IceCube : MonoBehaviour
{
    public WaterPlant Riddle;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit sth trigger: " + other.name);
        if (!checkCollider(other.name)) {
            Destroy(this.gameObject);
        } else
        {

            Debug.Log("Not Destroy");
            if (other.name == "PlantEarth")
            {
                other.gameObject.GetComponent<Plant>().AddHit();
                Destroy(this);
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
            default: return false;
        }
    }
}
