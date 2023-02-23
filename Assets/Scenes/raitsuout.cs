using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class raitsuout : MonoBehaviour, IPointerClickHandler
{
    private GameObject[,] _cells;

    private void Start()
    {
        _cells = new GameObject[5, 5];
        for (var r = 0; r < _cells.GetLength(0); r++)
        {
            for (var c = 0; c < _cells.GetLength(1); c++)
            {
                var cell = new GameObject($"Cell({r}, {c})");
                cell.transform.parent = transform;
                cell.AddComponent<Image>();
                _cells[r, c] = cell;
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_isGameOver) { return; }

        var cell = eventData.pointerCurrentRaycast.gameObject;
        if (CellIndex(cell, out var r, out var c))
        {
            if (Input.GetKey(KeyCode.LeftShift)) { SwitchedColor(r, c); } // デバッグ用
            else { SwitchCell(r, c); }

            if (GetJudgement()) { GameOver(); }
        }
    }

    private bool _isGameOver;
    private void GameOver()
    {
       
        _isGameOver = true;
        Debug.Log("ゲーム終了");
    }

    private bool GetJudgement()
    {
        foreach (var cell in _cells)
        {
            var image = cell.GetComponent<Image>();
            if (image.color != Color.black)
            {
                return false;
            }
        }
        return true;
    }

    private bool CellIndex(GameObject cell, out int row, out int column)
    {
        for (var r = 0; r < _cells.GetLength(0); r++)
        {
            for (var c = 0; c < _cells.GetLength(1); c++)
            {
                if (_cells[r, c] == cell)
                {
                    row = r;
                    column = c;
                    return true;
                }
            }
        }

        row = column = -1;
        return false;
    }
    private bool SwitchedColor(int r, int c)
    {
        var rows = _cells.GetLength(0);
        var columns = _cells.GetLength(1);
        if (r < 0 || r >= rows || c < 0 || c >= columns) { return false; }

        var image = _cells[r, c].GetComponent<Image>();
        image.color = image.color == Color.black
            ? Color.white : Color.black;
        return true;
    }

    private void SwitchCell(int r, int c)
    {
        SwitchedColor(r, c);
        SwitchedColor(r - 1, c);
        SwitchedColor(r + 1, c);
        SwitchedColor(r, c - 1);
        SwitchedColor(r, c + 1);
    }
}