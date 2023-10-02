using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader
{
    public enum Scene
    {
        MainMenu,
        Level1,
        Level2,
        Level3,
    }
    
    private static Scene _currentScene;

    public static void Load(Scene targetScene)
    {
        _currentScene = targetScene;
        SceneManager.LoadScene(targetScene.ToString());
    }

    public static Scene GetCurrentScene()
    {
        return _currentScene;
    }
}
