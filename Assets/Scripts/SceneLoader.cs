using UnityEngine.SceneManagement;

public static class SceneLoader
{
    public enum Scene
    {
        TestScene,
        MainMenu,
        Level1,
        Level2,
        Level3,
    }

    private static Scene _targetScene;

    public static void Load(Scene targetScene)
    {
        _targetScene = targetScene;
        SceneManager.LoadScene(targetScene.ToString());
    }
}
