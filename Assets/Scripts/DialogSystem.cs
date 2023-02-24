using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    public static DialogSystem Instance { get; private set; }

    [SerializeField] TMPro.TextMeshProUGUI _messageText, _yesText, _noText;
    [SerializeField] GameObject _panel;
    [SerializeField] Button _yesButton, _noButton;

    private List<string> _currentMessages = new List<string>();
    private int _messageID = 0;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        _panel.SetActive(false);
    }

    public void ShowMessages(List<string> messages, bool dialog, List<Actions> yesActions = null, List<Actions> noActions = null, string yesMessage = "Yes", string noMessage = "No")
    {
        
        _messageID = 0;
        _yesButton.transform.parent.gameObject.SetActive(false);
        _currentMessages = messages;
        _panel.SetActive(true);
        if (dialog)
        {
            _yesText.text = yesMessage;
            _yesButton.onClick.RemoveAllListeners();
            _yesButton.onClick.AddListener(delegate
            {
                _panel.SetActive(false);

                if (yesActions != null)
                {
                    AssignActionsToButtons(yesActions);
                   
                }
                   
                
            });
            _noText.text = noMessage;
            _noButton.onClick.RemoveAllListeners();
            _noButton.onClick.AddListener(delegate
            {
                _panel.SetActive(false);

                if (noActions != null)
                {
                    AssignActionsToButtons(noActions);
                    
                }
                
            });
        }

        StartCoroutine(ShowMultipleMessages(dialog));
    }



    
    IEnumerator ShowMultipleMessages(bool useDialog)
    {
        _messageText.text = _currentMessages[_messageID];
        while(_messageID < _currentMessages.Count)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) && Extensions.IsMouseOverUI())
            {
                _messageID++;
                if (_messageID < _currentMessages.Count)
                    _messageText.text = _currentMessages[_messageID];

                if (useDialog && _messageID == _currentMessages.Count)
                {
                    _yesButton.transform.parent.gameObject.SetActive(true);
                    
                }

                _messageID = 0;
            }
            yield return null;
        }

        if (!useDialog)
            _panel.SetActive(false);
        
    }
    private void AssignActionsToButtons(List<Actions> actions)
    {
        List<Actions> localActions = actions;
        for (int i = 0; i < localActions.Count; i++)
        {
            localActions[i].Act();
        }
    }
    public void HideDialog()
    {
        _panel.SetActive(false);
    }
}
