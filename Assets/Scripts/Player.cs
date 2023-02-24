using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Camera _camera;
    

    private bool _turning;
    private Quaternion _targetRotation;
    private bool _isPotion = false;

    public bool IsPotion { get => _isPotion; set => _isPotion = value; }

    private void Update()
    {
       if (Input.GetMouseButtonDown(0) && !Extensions.IsMouseOverUI())
       {
            OnClick();
       }
       if (_turning && transform.rotation != _targetRotation)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, _targetRotation, 15f * Time.deltaTime);
        }
    }

    private void OnClick()
    {
        RaycastHit hit;
        Ray cameraToScreen = _camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(cameraToScreen, out hit, Mathf.Infinity))
        {
            if (hit.collider != null)
            {
                if (hit.collider.TryGetComponent(out Interactable interactable))
                {
                    Move(interactable.InteractPosition());
                    interactable.Interact(this);
                }
                else
                {
                    Move(hit.point);
                }
                
            }
        }
    }

    public bool CheckIfArrived()
    {
        return (!_agent.pathPending && _agent.remainingDistance <= _agent.stoppingDistance);
    }

    private void Move(Vector3 targetPosition)
    {
        _turning = false;
        _agent.SetDestination(targetPosition);

        DialogSystem.Instance.HideDialog();
    }
    public void SetDirection(Vector3 targetDirection)
    {
        _turning = true;
        _targetRotation = Quaternion.LookRotation(targetDirection - transform.position);
    }
}
