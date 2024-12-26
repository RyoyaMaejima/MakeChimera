using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    #region/private•Ï”
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
            // ƒV[ƒ“Ø‚è‘Ö‚¦
            SceneManager.LoadScene(nameNextScene);
            goNextScene = true;
        }
    }

    public void Pressed(string sceneName)
    {
        if (!firstPush) // ”½‰‚Íˆê‰ñ‚Ì‚İ
        {
            firstPush = true;
            nameNextScene = sceneName;
        }
    }
}
