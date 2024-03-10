using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    public Image wantedImage;
    private Sprite wantedSprite;
    public GameObject[] characterPrefabs; // 使用可能なキャラクタープレファブ
    public GameObject stage; // キャラクターを配置するステージオブジェクト
  
    public void SetupStage(int level, int initialCharacterCount)
    {
        ClearStage(); // 以前のキャラクターをクリア

        int characterCount = initialCharacterCount + level - 1; // このレベルで生成するキャラクターの数
        List<GameObject> availablePrefabs = new List<GameObject>(characterPrefabs); // 除外されていないプレファブのリスト
        
        GameObject wantedCharacter = null;
        int wantedIndex = Random.Range(0, availablePrefabs.Count);

        wantedCharacter = Instantiate(availablePrefabs[wantedIndex], RandomPosition(), Quaternion.identity, stage.transform);
        wantedCharacter.GetComponent<Character>().isCorrectAnswer = true;
        wantedSprite = wantedCharacter.GetComponent<SpriteRenderer>().sprite;
        
        wantedImage.sprite = wantedSprite;
        
        availablePrefabs.RemoveAt(wantedIndex); // 生成されたキャラクターをリストから削除
        
        // 残りのキャラクターを生成
        for (int i = 0; i < characterCount - 1; i++)
        {
            GameObject characterPrefab = availablePrefabs[Random.Range(0, availablePrefabs.Count)];
            if (characterPrefab != wantedCharacter)
            {
                Instantiate(characterPrefab, RandomPosition(), Quaternion.identity, stage.transform);
            }
        }
    }

    private void ClearStage()
    {
        foreach (Transform child in stage.transform)
        {
            Destroy(child.gameObject);
        }
    }

    private Vector3 RandomPosition()
    {
        float xMin = 0.1f, xMax = 0.9f;
        float yMin = 0.1f, yMax = 0.9f;
        Vector2 screenPosition = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));
        Vector3 worldPosition = Camera.main.ViewportToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, Camera.main.nearClipPlane));
        worldPosition.z = 0;
        return worldPosition;
    }


    void UpdateWantedImage()
    {
        wantedImage.sprite = wantedSprite;
    }
}
