using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField, Header("全てのAnimalの数")] private List<Animal> animals;
    
    [SerializeField, Header("キメラを生成する数")] private int numChimera = 5;

    [SerializeField] private int correct1 = 1;
    [SerializeField] private int correct2 = 2;
    [SerializeField] private int correct3 = 3;
    [SerializeField] private int correct4 = 4;
    [SerializeField] private int correctAll = 5;
    //public int oneSetScore = 0; // 1フェーズごとのスコア -> GameManagerでトータルスコアを管理
    private int numCorrect = 0; // 正解数

    public List<Animal> gameUsedAnimals = new List<Animal>(); // ゲームで使用されるAnimalsを保持するリスト
    
    public Dictionary<string, bool> answerChimeraNames = new Dictionary<string, bool>();

    // 選択されたAnimals
    private Animal firstAnimal;
    private Animal lastAnimal;

    // 生成されたキメラの名前
    public string generatedChimeraName = "";



    // ゲーム開始時に呼ぶ初期化するメソッド
    public void InitGame()
    {
        // ゲーム情報の初期化
        gameUsedAnimals.Clear();
        answerChimeraNames.Clear();

        // ゲーム情報の生成
        SelectGameUsedAnimals();
        // 答えの生成
        MakeAnswer();

        numCorrect = 0;
    }

    // 今のステージの終了判定
    public bool CheckStageEnd()
    {
        return gameUsedAnimals.Count == 0;
    }

    // キメラ名を""に変更
    public void ClearGeneratedChimeraName()
    {
        generatedChimeraName = "";
    }

    // キメラ名をセット
    public void SetChimeraName(string chimeraName)
    {
        ClearGeneratedChimeraName();
        generatedChimeraName = chimeraName;
    }

    // Animals を削除
    public void ClearAnimals()
    {
        // 選択されたAnimalをgameUsedAnimalsから削除する
        RemoveAnimalFromList(firstAnimal);
        RemoveAnimalFromList(lastAnimal);

        // 自己破壊処理を呼び出す
        firstAnimal.DestroySelf();
        lastAnimal.DestroySelf();

        // 選択したAnimalをnullにする
        firstAnimal = null;
        lastAnimal = null;
    }

    // 左側を選択するAnimalをセット
    public void SetFirstAnimal(Animal animal)
    {
        firstAnimal = animal;
    }

    // 右側を選択するAnimalをセット
    public void SetLastAnimal(Animal animal)
    {
        lastAnimal = animal;
    }

    // 左側を選択する　Animal を渡す
    public Animal GetFirstAnimal()
    {
        return firstAnimal;
    }

    // 右側を選択する　Animal を渡す
    public Animal GetLastAnimal()
    {
        return lastAnimal;
    }

    public int GetNumCorrect()
    {
        return numCorrect;
    }

    // 選択された2つのAnimalからChimeraを生成する
    public void CheckAnswer()
    {
        // answerChimeraNamesからgeneratedChimeraNameを探索して、同じものがあるかをチェックする
        if (generatedChimeraName != "")
        {
            foreach (string chimeraName in answerChimeraNames.Keys)
            {
                if (chimeraName.Equals(generatedChimeraName))
                {
                    Debug.Log("生成されたキメラは解です。");

                    // Dict{answerChimeraNames}を更新
                    UpdateAnswerChimeraDict();

                    // 正解数++
                    numCorrect++;
                    ComputeScore();
                    return;
                }
            }
            Debug.Log("それは解ではありません。");
        }
    }

    private void UpdateAnswerChimeraDict()
    {
        // この時は、generatedChimeraNameをまだ保持しているので、
        // dictを参照して、false->trueに変更する
        foreach(string chimeraName in answerChimeraNames.Keys)
        {
            if (chimeraName.Equals(generatedChimeraName))
            {
                answerChimeraNames[generatedChimeraName] = true;
                break;
            }
        }
    }


    // 引数にとったAnimalをgameUsedAnimalsから削除する
    private void RemoveAnimalFromList(Animal selectedAnimal)
    {
        // 参照が同じなら削除
        foreach(Animal animal in gameUsedAnimals)
        {
            if(animal == selectedAnimal)
            {
                gameUsedAnimals.Remove(animal);
                return;
            }
        }
    }

    // numChimera*2の数だけゲームで使用するAnimalのリストに追加する
    private void SelectGameUsedAnimals()
    {
        // アニマルIDから、ランダムにAnimalを選択するtempListを生成
        List<int> animalID = new List<int>();
        for (int i = 0; i<animals.Count; i++) animalID.Add(i);

        // numChimeraの数だけ、ランダムにAnimalをgameUsedAnimalsにセットしていく
        for (int i = 0; i<numChimera*2; i++)
        {
            int random = animalID[Random.Range(0, animalID.Count)];

            Vector3 generatePos;
            if (i < numChimera)
            {
                float xPos = (i - (float)(numChimera - 1) / 2)*2.5f;
                generatePos = new Vector3(xPos, -1f, 0f);
            }
            else
            {
                float xPos = (i - (float)(numChimera-1) / 2 - numChimera)* 2.5f;
                generatePos = new Vector3(xPos, -3f, 0f);
            }
            Animal animal = Instantiate(animals[random], generatePos, Quaternion.identity);
            gameUsedAnimals.Add(animal);

            // IDの削除
            animalID.Remove(random);
        }

    }


    // 答えとなる組み合わせを生成する
    private void MakeAnswer()
    {
        // gameUsedAnimalsのコピーをtempListとして用意する
        List<Animal> tempList = new List<Animal>(gameUsedAnimals);
        // gameUsedAnimalsから、2種類を選択して、generatedChimeraNameに追加する


        // とりあえずは、ランダムに生成する
        for (int i=0; i<numChimera; i++)
        {
            // FirstCharacterを取得するAnimal
            int randomFirst = Random.Range(0, tempList.Count);
            Animal firstAnimal = tempList[randomFirst];
            tempList.Remove(firstAnimal); // 選択したら削除

            // LastCharacterを取得するAnimal
            int randomLast = Random.Range(0, tempList.Count);
            Animal lastAnimal = tempList[randomLast];
            tempList.Remove(lastAnimal); // 選択したら削除



            // {first, last} Animalから文字を取得してanswerChimeraNamesに追加する
            string firstChar = firstAnimal.GetFirstCharacter().ToString();
            string lastChar = lastAnimal.GetLastCharacter().ToString();

            // answerChimeraNamesに解を追加
            answerChimeraNames.Add(firstChar + lastChar, false);
            

        }
    }


    private void ComputeScore()
    {
        if (numCorrect == 1) GManager.instance.score += correct1;
        else if (numCorrect == 2) GManager.instance.score += correct2;
        else if (numCorrect == 3) GManager.instance.score += correct3;
        else if (numCorrect == 4) GManager.instance.score += correct4;
        else if (numCorrect == 5)
        {
            GManager.instance.score += correctAll;
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //CheckAnswer(); // -> 動く
            //GenerateChimeraName(); // -> 動く
        }
    }
}
