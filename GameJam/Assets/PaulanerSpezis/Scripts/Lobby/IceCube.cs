using UnityEngine;

public class IceCube : MonoBehaviour
{
    public WaterPlant Riddle;
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.name != "PlantEarth" || other.name != "PlantShaft" || other.name != "PlantFlower" || other.name != "shittyBucket")
        {
            Destroy(this);
        } else
        {
            if (other.name == "PlantEarth")
            {
                other.gameObject.GetComponent<Plant>().AddHit();
                Destroy(this);
            }
        }
    }
}
