using UnityEngine;

public class MouseClickChecker : MonoBehaviour
{
    [SerializeField] private LayerMask _canMoveLayer;

    public Vector3 GetPoint()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit raycastHit;

        if (Physics.Raycast(ray, out raycastHit, 100, _canMoveLayer))
        {
            return raycastHit.point;
        }

        return transform.position;
    }
}