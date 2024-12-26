using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Generator : MonoBehaviour
{
    [SerializeField] private Game game = null;
    [SerializeField] private Chimera chimera;
    [SerializeField] private GameObject generatePlace;

    private Chimera generatedChimera = null;

    // 生成装置の左右に空きがなければTrue
    public bool CheckGeneratable()
    {
        return game.GetFirstAnimal() != null && game.GetLastAnimal() != null;
    }

    public void GenerateChimera()
    {
        // サウンドの処理を記述、生成までに時間をかけたい
        // サウンド開始、キメラ生成(非表示)、サウンド終了、キメラ表示、になる予定

        // キメラを生成する
        generatedChimera = Instantiate(chimera, generatePlace.transform.position, Quaternion.identity);
        generatedChimera.MakeChimera(game.GetFirstAnimal(), game.GetLastAnimal());

        // Gameに生成した内容を反映する
        game.SetChimeraName(generatedChimera.GetName());
        game.CheckAnswer();
    }

    // GameのfirstAnimal,lastAnimalの削除　と generatedChimeraの削除
    public void DestroyAnimalsAndChimera()
    {
        // Animalsの後処理はGameがやってる、あとで処理をここに移したい
        game.ClearAnimals();

        generatedChimera.DestroySelf();
    }
}
