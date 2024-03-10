using UnityEngine;

public class Character : MonoBehaviour
{
    // このキャラクターが「WANTED」かどうかを示すフラグ
    public bool isCorrectAnswer = false;

    void OnMouseDown()
    {
        // GameManagerにこのキャラクターの選択を通知する
        GameManager.Instance.OnCharacterSelected(isCorrectAnswer);

        if (isCorrectAnswer)
        {
            // 正しいキャラクター（WANTED）が選択された場合の処理
            // ここに必要な処理（例: アニメーション、サウンド再生など）を追加
            Debug.Log("Correct! Moving to the next level.");
        }
        else
        {
            // 誤ったキャラクターが選択された場合の処理
            Debug.Log("Wrong! Game Over.");
            // 必要に応じてゲームオーバーの処理をここに追加
        }
    }

    // オプションで、キャラクターに関する追加のロジック（例えば、表示されたときのアニメーションなど）をここに追加
}