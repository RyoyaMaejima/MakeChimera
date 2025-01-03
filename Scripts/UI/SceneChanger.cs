using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    #region/private変数
    private bool firstPush;
    private bool goNextScene;
    private string nameNextScene;
    #endregion

    void Start()
    {
        firstPush = false;
        goNextScene = false;
    }

    void Update()
    {
        if (!goNextScene && firstPush)
        {
            // シーン切り替え
            SceneManager.LoadScene(nameNextScene);
            goNextScene = true;
        }
    }

    public void Pressed(string sceneName)
    {
        if (!firstPush) // 反応は一回のみ
        {
            firstPush = true;
            nameNextScene = sceneName;
        }
    }
}
