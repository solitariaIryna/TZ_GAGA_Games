
using System.Collections.Generic;
using UnityEngine;

public class QuestAction : Actions
{
    [Multiline(5)]
    [SerializeField] private List<string> _messages;
    [SerializeField] private bool _enableDialog;
    [SerializeField] private string _yesText, _noText;
    [SerializeField] private List<Actions> _yesActions, _noActions;
    private bool _isPotion;
    public override void Act()
    {
        if (!_isPotion)
        {
            DialogSystem.Instance.ShowMessages(_messages, _enableDialog, _yesActions, _noActions, _yesText, _noText);
        }
        else
        {
            print("Complete");
        }

    }
}
