using System.Collections;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] private Actions[] _actions;
    [SerializeField] private float distancePosition = 1f;
    public Vector3 InteractPosition()
    {
        return transform.position + transform.forward * distancePosition;
    }
    public void Interact(Player player)
    {
        print(gameObject.name + "clicked by player");

        StartCoroutine(WaitForPlayerArriving(player));
    }

    IEnumerator WaitForPlayerArriving(Player player)
    {
        while (!player.CheckIfArrived())
        {
            yield return null;
        }
        print("Player Arrived");
        player.SetDirection(transform.position);
        StartDialog();

    }

    private void StartDialog()
    {
        _actions[0].Act();
    }
}
