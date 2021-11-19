using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum cell { NONE, X, O };
public struct gridPos { int row, col; }

public class Board
{
    cell[] cells;
    public Board()
    {
        cells = new cell[9];
        for (int i = 0; i < cells.Length; i++)
        {
            cells[i] = cell.NONE;
        }
    }

    public bool UpdateCell(int row, int col, bool isPlayer)
    {
        int index = row * 3 + col;
        cells[index] = isPlayer ? cell.X : cell.O;
        return isWinner(row, col, isPlayer);
    }

    bool isWinner(int row, int col, bool isPlayer)
    {
        cell mycell = isPlayer ? cell.X : cell.O;
        return isHorizontal(row, mycell) || isVertical(col, mycell) || isDiagonal(row * 3 + col, mycell);
    }

    bool isHorizontal(int row, cell mycell)
    {
        return MatchCell(row * 3, mycell) && MatchCell(row * 3 + 1, mycell) && MatchCell(row * 3 + 2, mycell);
    }

    bool isVertical(int col, cell mycell)
    {
        return MatchCell(col, mycell) && MatchCell(col + 3, mycell) && MatchCell(col + 6, mycell);
    }

    bool isDiagonal(int index, cell myCell)
    {
        if (index == 0 || index == 4 || index ==  8)
        {
            return MatchCell(0, myCell) && MatchCell(4, myCell) && MatchCell(8, myCell);
        }
        if(index == 2 || index == 4 || index == 6)
        {
            return MatchCell(2, myCell) && MatchCell(6, myCell) && MatchCell(4, myCell);
        }
        return false;
    }

    bool MatchCell(int index,cell mycell)
    {
        return cells[index] == mycell;
    }
}
