using UnityEngine;
using UnityEngine.UI;

public class Minesweeper : MonoBehaviour
{
    [SerializeField]
    private int _rows = 1;

    [SerializeField]
    private int _columns = 1;

    [SerializeField]
    private int _mineCount = 1;

    [SerializeField]
    private GridLayoutGroup _gridLayoutGroup = null;

    [SerializeField]
    private Cell _cellPrefab = null;

    private Cell[,] _cells;

    void Start()
    {
        _gridLayoutGroup.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        _gridLayoutGroup.constraintCount = _columns;

        // プレハブからセルを生成する
        var parent = _gridLayoutGroup.gameObject.transform;
        _cells = CreateCells(_rows, _columns, parent);

        // 地雷を設置する
        InitializeCells(_mineCount);
    }

    private void InitializeCells(int mineCount)
    {
        if (mineCount > _cells.Length)
        {
            Debug.LogError($"地雷数はセル数より少なく設定してください\n" +
                $"地雷数={mineCount}, セル数={_cells.Length}");
            return;
        }

        // すべてのセルの状態を None にする。
        ClearCells();
        HideCell(_rows, _columns);
        for (var i = 0; i < mineCount; i++)
        {
            var r = Random.Range(0, _rows);
            var c = Random.Range(0, _columns);
            var cell = _cells[r, c];

            // ランダムに選ばれたセルが地雷かどうか
            if (cell.CellState == CellState.Mine)
            {
                Debug.Log("重複したので再抽選");
                i--;
            }
            else { cell.CellState = CellState.Mine; }
        }

        // 地雷の数を数える
        for (var r = 0; r < _rows; r++)
        {
            for (var c = 0; c < _columns; c++)
            {
                var cell = _cells[r, c];
                cell.CellState = GetMineCount(r, c);
            }
        }
    }

    private void ClearCells()
    {
        foreach (var cell in _cells)
        {
            cell.CellState = CellState.None;
        }
    }

    private Cell[,] CreateCells(int rows, int columns, Transform parent)
    {
        var cells = new Cell[_rows, _columns];
        for (var r = 0; r < rows; r++)
        {
            for (var c = 0; c < columns; c++)
            {
                var cell = Instantiate(_cellPrefab);
                cell.transform.SetParent(parent);
                cells[r, c] = cell;
            }
        }
        return cells;
    }

    private CellState GetMineCount(int row, int column)
    {
        var cell = _cells[row, column];
        if (cell.CellState == CellState.Mine) { return CellState.Mine; }

        // 周囲のセルの地雷の数を数える
        var count = 0;

        var up = row - 1;
        var down = row + 1;
        var left = column - 1;
        var right = column + 1;

        if (IsMine(up, left)) { count++; } // 左上
        if (IsMine(up, column)) { count++; } // 上
        if (IsMine(up, right)) { count++; } // 右上
        if (IsMine(row, left)) { count++; } // 左
        if (IsMine(row, right)) { count++; } // 右
        if (IsMine(down, left)) { count++; } // 左下
        if (IsMine(down, column)) { count++; } // 下
        if (IsMine(down, right)) { count++; } // 右下

        return (CellState)count;
   
    }

    private bool IsMine(int row, int column)
    {
        if (row >= 0 && row < _rows && column >= 0 && column < _columns)
        {
            return _cells[row, column].CellState == CellState.Mine;
        }
        else
        {
            return false;
        }
    }
    private void HideCell(int row, int column)
    {
        var cell = _cells[row, column];
        cell.gameObject.SetActive(false);
    }

}
