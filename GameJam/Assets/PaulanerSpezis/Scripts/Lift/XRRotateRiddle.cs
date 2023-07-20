using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XRRotateRiddle : MonoBehaviour
{
    bool _isClicked = false;
    Transform _interActorTransform;
    Vector3 oldPosition;


    public void Clicked(SelectEnterEventArgs args)
    {
        _isClicked = true;
        _interActorTransform = args.interactorObject.transform.parent.transform;
        oldPosition = _interActorTransform.localPosition;
    }

    public void Released()
    {
        _isClicked = false;
    }

    public void HoverExit()
    {
        _isClicked = false;
    }

    private void Update()
    {
        
        if (_isClicked)
        {
            Vector3 _difference = _interActorTransform.position - transform.position;
            if (Mathf.Abs(_difference.x) < Mathf.Abs(_difference.z) && _difference.z > 0) // north
            {
                transform.Rotate(new Vector3(
                    (oldPosition.y - _interActorTransform.localPosition.y) * 30000 * Time.deltaTime, //vertical
                    -(oldPosition.x - _interActorTransform.localPosition.x) * 30000 * Time.deltaTime, 0),//horizontal 
                    Space.World);
                
            } else if (Mathf.Abs(_difference.x) > Mathf.Abs(_difference.z) && _difference.x > 0) // east
            {
                transform.Rotate(new Vector3(
                    0, 
                    (oldPosition.z - _interActorTransform.localPosition.z) * 30000 * Time.deltaTime, //horizontal
                    -(oldPosition.y - _interActorTransform.localPosition.y) * 30000 * Time.deltaTime), Space.World); //vertical
            }
            else if (Mathf.Abs(_difference.x) < Mathf.Abs(_difference.z) && _difference.z < 0) // south
            {
                transform.Rotate(new Vector3(
                    -(oldPosition.y - _interActorTransform.localPosition.y) * 30000 * Time.deltaTime, //vertical
                    (oldPosition.x - _interActorTransform.localPosition.x) * 30000 * Time.deltaTime, //horizontal
                    0), Space.World);
            }
            else if (Mathf.Abs(_difference.x) > Mathf.Abs(_difference.z) && _difference.x < 0) // west
            {
                transform.Rotate(new Vector3(
                    0, 
                    -(oldPosition.z - _interActorTransform.localPosition.z) * 30000 * Time.deltaTime, //horizontal
                    (oldPosition.y - _interActorTransform.localPosition.y) * 30000 * Time.deltaTime), Space.World); //vertical
            }
            oldPosition = _interActorTransform.localPosition;

        }
    }
}
