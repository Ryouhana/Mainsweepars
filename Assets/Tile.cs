using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum TileType { EMPTY, BOOM, COUNT }
public class Tile : MonoBehaviour
{
    enum MarkState { NO_MARK, FLAG, QUESTION }
    public TileType TileType { get { return mTileType; } }
    public int Index { get { return mIndex; } }

    Manager mManager;
    TileType mTileType = TileType.EMPTY;
    MarkState mMarkState = MarkState.NO_MARK;
    int mIndex;
    bool mIsDigged = false;

    [SerializeField] GameObject mCover;
    [SerializeField] GameObject mFlag;
    [SerializeField] GameObject mRedBG;
    [SerializeField] GameObject mRedCross;
    [SerializeField] TextMeshProUGUI mCount;
    [SerializeField] GameObject mBoom;
    [SerializeField] Color[] mCountCols = new Color[8];

    public void Initialize(Manager manager, int index)
    {
        mManager = manager;
        mIndex = index;
    }

    //�^�C�����@��
    public void OnDigged()
    {
        if (mIsDigged || mMarkState == MarkState.FLAG)
            return;

        

        mIsDigged = true;

        mCover.SetActive(false);

        switch (mTileType)
        {
            case TileType.EMPTY:
                //�}�l�[�W���[�ɗאڃ^�C�����@���Ă��炤 
                mManager.DigAround(mIndex);
                mManager.CountDiggedTile();
                break;
            case TileType.BOOM:
                //�}�l�[�W���[�ɃQ�[���I�[�o�[���������Ă��炤
                mRedBG.SetActive(true);
                mManager.GameOver();
                break;
            case TileType.COUNT:
                mManager.CountDiggedTile();
                break;
        }
    }

    //����̒n������ݒ�/�\��
    public void SetCount(int count)
    {
        mTileType = TileType.COUNT;

        //�J�E���g��ݒ肵�ĕ\��
        mCount.gameObject.SetActive(true);
        mCount.text = count.ToString();

        //�����ɂ���āA�����̐F��ς���
        mCount.color = mCountCols[count - 1];

    }

    public void SetBoom()
    {
        mTileType = TileType.BOOM;
        mBoom.SetActive(true);
    }

    //�}�[�N��t����
    public void SetMark()
    {
        if (mIsDigged)
            return;

        switch (mMarkState)
        {
            case MarkState.NO_MARK:
                mFlag.SetActive(true);
                break;
            case MarkState.FLAG:
                mFlag.SetActive(false);
              
                break;
            case MarkState.QUESTION:
             
                break;
            default:
                break;
        }

        mMarkState++;
        int markStateLength = System.Enum.GetNames(typeof(MarkState)).Length;
        if ((int)mMarkState == markStateLength)
            mMarkState -= markStateLength;
    }

    public void GameOverCheck()
    {
        if (mMarkState == MarkState.FLAG && mTileType != TileType.BOOM)
            mRedCross.SetActive(true);
        else if (mMarkState != MarkState.FLAG && mTileType == TileType.BOOM)
            mCover.SetActive(false);
    }
}