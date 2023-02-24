
using System.Collections.Generic;
using UnityEngine;

public class MessageAction : Actions
{
    [Multiline(5)]
    [SerializeField] private List<string> _messages;
    [SerializeField] private bool _enableDialog;
    [SerializeField] private string _yesText, _noText;
    [SerializeField] private List<Actions> _yesActions, _noActions;
    
    public override void Act()
    {
        DialogSystem.Instance.ShowMessages(_messages, _enableDialog, _yesActions, _noActions, _yesText, _noText);

    }


}
