using UnityEditor;
using UnityEditor.SceneManagement;

namespace Develop.Editor
{
    public class SceneSwitcher
    {
        [MenuItem("Tools/Scenes/Bootstrap &1", priority = 201)]
        public static void OpenBootstrapScene()
        {
            EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
            EditorSceneManager.OpenScene("Assets/_Project/Scenes/0.Bootstrap.unity");
        }

        [MenuItem("Tools/Scenes/Core &2", priority = 202)]
        public static void OpenCoreScene()
        {
            EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo();
            EditorSceneManager.OpenScene("Assets/_Project/Scenes/2.Core.unity");
        }
    }
}