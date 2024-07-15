using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    static T _instance;

    public static T Instance
    {
        get
        {
            Component GetAllObjectsOnlyInScene<T1>() where T1 : Component
            {
                var components = Resources.FindObjectsOfTypeAll(typeof(T1));
                foreach (UnityEngine.Object co in components)
                {
                    Component component = co as Component;
                    GameObject go = component.gameObject;
                    if (go.scene.name == null) // 씬에 있는 오브젝트가 아니므로 제외한다.
                        continue;

                    // HideFlags 이용하여 씬에 있는 오브젝트가 아닌경우 제외
                    if (go.hideFlags == HideFlags.NotEditable || go.hideFlags == HideFlags.HideAndDontSave || go.hideFlags == HideFlags.HideInHierarchy)
                        continue;

                    return component;
                }

                return null;
            }
            if (_instance == null)
            {
                _instance = (T)FindObjectOfType(typeof(T));

                if (_instance == null)
                {
                    _instance = (T)GetAllObjectsOnlyInScene<T>();
                }
                
                if (_instance == null)
                {
                    Debug.LogError($"{typeof(T)} 싱글턴 클래스 없음");
                }
            }

            return _instance;
        }



    }

    private void OnDestroy()
    {
        _instance = null;
    }

}
