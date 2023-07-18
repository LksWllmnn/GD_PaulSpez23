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
            if (_difference.x < 0)
            {
                transform.Rotate(new Vector3(-(oldPosition.y - _interActorTransform.localPosition.y) * 10, 0, 0), Space.World);
                
            } else if (_difference.x > 0)
            {
                transform.Rotate(new Vector3((oldPosition.y - _interActorTransform.localPosition.y) * 10, 0, 0), Space.World);
            }
            oldPosition = _interActorTransform.localPosition;
            Debug.Log(_difference.x);

        }
    }
}
