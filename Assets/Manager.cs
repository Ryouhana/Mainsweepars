using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    [SerializeField] Tile mTilePrefab;
    [SerializeField] Vector2Int mFieldSize = new Vector2Int(10, 10);
    [SerializeField] int mTotalBoomCount = 20;
    [SerializeField] GameObject mTilesRoot;
    [SerializeField] GameObject mGameOverImage;
    [SerializeField] GameObject mGameClearImage;

    Tile[] mTiles;
    Tile[] mBoomTiles;
    int mDiggedTileCount;

    private void Start()
    {
        GenerateTiles();
        SetBooms();
        SetCounts();
    }

    //タイルを設置
    void GenerateTiles()
    {
        Vector2 canvasCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);

        float x = (mFieldSize.x - 1f) / 2f;
        float y = (mFieldSize.y - 1f) / 2f;
        Vector2 leftUnderTilePos = canvasCenter - new Vector2(x, y) * 100f;

        mTiles = new Tile[mFieldSize.x * mFieldSize.y];

        for (int i = 0; i < mTiles.Length; i++)
        {
            Vector2 thisTilePos = leftUnderTilePos + new Vector2(i % mFieldSize.x, i / mFieldSize.x) * 100f;

            Tile tile = Instantiate(mTilePrefab, mTilesRoot.transform);
            tile.GetComponent<RectTransform>().position = thisTilePos;

            tile.Initialize(this, i);
            mTiles[i] = tile;
        }
    }

    //地雷を設置
    void SetBooms()
    {
        List<Tile> safeTiles = new List<Tile>(mTiles.Length);
        safeTiles.AddRange(mTiles);

        mBoomTiles = new Tile[mTotalBoomCount];

        for (int i = 0; i < mTotalBoomCount; i++)
        {
            int index = Random.Range(0, safeTiles.Count);
            Tile boomTile = safeTiles[index];

            mBoomTiles[i] = boomTile;
            safeTiles.RemoveAt(index);

            boomTile.SetBoom();
        }
    }

    void SetCounts()
    {
        int[] boomCountEach = new int[mTiles.Length];

        foreach (var tile in mBoomTiles)
        {
            int[] aroundTileIndices = GetAroundIndices(tile.Index);
            foreach (var aroundIndex in aroundTileIndices)
                boomCountEach[aroundIndex] = boomCountEach[aroundIndex] + 1;
        }

        for (int i = 0; i < boomCountEach.Length; i++)
        {
            int boomCount = boomCountEach[i];
            if (boomCount != 0 && mTiles[i].TileType != TileType.BOOM)
                mTiles[i].SetCount(boomCount);
        }
    }

    //隣のタイルを開く
    public void DigAround(int index)
    {
        foreach (var aroundTileIndex in GetAroundIndices(index))
            mTiles[aroundTileIndex].OnDigged();
    }

    int[] GetAroundIndices(int index)
    {
        List<int> result = new List<int>(8);

        int index0 = index - mFieldSize.x - 1;
        if (index0 >= 0 && index0 % mFieldSize.x != mFieldSize.x - 1)
            result.Add(index0);

        int index1 = index - mFieldSize.x;
        if (index1 >= 0)
            result.Add(index1);

        int index2 = index - mFieldSize.x + 1;
        if (index2 >= 0 && index2 % mFieldSize.x != 0)
            result.Add(index2);

        int index3 = index - 1;
        if (index3 >= 0 && index3 % mFieldSize.x != mFieldSize.x - 1)
            result.Add(index3);

        int index4 = index + 1;
        if (index4 % mFieldSize.x != 0)
            result.Add(index4);

        int index5 = index + mFieldSize.x - 1;
        if (index5 < mTiles.Length && index5 % mFieldSize.x != mFieldSize.x - 1)
            result.Add(index5);

        int index6 = index + mFieldSize.x;
        if (index6 < mTiles.Length)
            result.Add(index6);

        int index7 = index + mFieldSize.x + 1;
        if (index7 < mTiles.Length && index7 % mFieldSize.x != 0)
            result.Add(index7);

        return result.ToArray();
    }

    //ゲームオーバー
    public void GameOver()
    {
        mGameOverImage.SetActive(true);

        foreach (var tile in mTiles)
        {
            tile.GameOverCheck();
        }
    }

    public void CountDiggedTile()
    {
        mDiggedTileCount++;
        if (mDiggedTileCount == mFieldSize.x * mFieldSize.y - mTotalBoomCount)
            GameClear();
    }

    //ゲームクリア
    void GameClear()
    {
        mGameClearImage.SetActive(true);
    }
}