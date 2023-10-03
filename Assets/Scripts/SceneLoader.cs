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
        SceneManager.LoadScene(targetScene.ToString());
    }

    public static Scene GetCurrentScene()
    {
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 0:
                _currentScene = Scene.MainMenu;
                break;
            case 1:
                _currentScene = Scene.Level1;
                break;
            case 2:
                _currentScene = Scene.Level2;
                break;
            case 3:
                _currentScene = Scene.Level3;
                break;
        }
        return _currentScene;
    }
}
