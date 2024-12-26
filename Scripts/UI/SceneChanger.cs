using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    #region/private�ϐ�
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
            // �V�[���؂�ւ�
            SceneManager.LoadScene(nameNextScene);
            goNextScene = true;
        }
    }

    public void Pressed(string sceneName)
    {
        if (!firstPush) // �����͈��̂�
        {
            firstPush = true;
            nameNextScene = sceneName;
        }
    }
}
