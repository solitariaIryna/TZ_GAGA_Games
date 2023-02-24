using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeAction : Actions
{
    [SerializeField] private Player _player;
    public override void Act()
    {
        Destroy(gameObject);
        _player.IsPotion = true;
    }
}
