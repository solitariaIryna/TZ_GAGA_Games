

using UnityEngine.EventSystems;

public static class Extensions 
{
      public static bool IsMouseOverUI()
      {
        return EventSystem.current.IsPointerOverGameObject();
      }
    
}
