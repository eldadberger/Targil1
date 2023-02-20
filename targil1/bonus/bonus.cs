// See https://aka.ms/new-console-template for more information

const int BOARD_SIZE = 9;
const int SUB_GRID_SIZE = 3;
const int EMPTY_VALUE = -1;

(int, int) findNextPlaceToFill(int[,] board)
{
    int row = EMPTY_VALUE, col = EMPTY_VALUE;

    for (int i = 0; i < BOARD_SIZE; i++)
    {
        for (int j = 0; j < BOARD_SIZE; j++)
        {
            if (board[i, j] == EMPTY_VALUE)
            {
                row = i;
                col = j;

                return (row, col);
            }
        }
    }

    return (row, col);
}

bool IsValidMove(int[,] board, int row, int col, int num)
{
    for (int i = 0; i < BOARD_SIZE; i++)
    {
        if (board[row, i] == num)
        {
            return false;
        }
    }

    for (int j = 0; j < BOARD_SIZE; j++)
    {
        if (board[j, col] == num)
        {
            return false;
        }
    }

    int gridRow = (row / SUB_GRID_SIZE) * SUB_GRID_SIZE;
    int gridCol = (col / SUB_GRID_SIZE) * SUB_GRID_SIZE;
    for (int i = gridRow; i < gridRow + SUB_GRID_SIZE; i++)
    {
        for (int j = gridCol; j < gridCol + SUB_GRID_SIZE; j++)
        {
            if (board[i, j] == num)
            {
                return false;
            }
        }
    }

    return true;
}

bool canBeSolved(int[,] board)
{
    (int row, int col) = findNextPlaceToFill(board);

    if (row == EMPTY_VALUE) //the board is full
    {
        return true;
    }

    for (int num = 1; num <= BOARD_SIZE; num++)
    {
        if (IsValidMove(board, row, col, num))
        {
            board[row, col] = num;

            if (canBeSolved(board))
            {
                return true;
            }

            board[row, col] = EMPTY_VALUE;
        }
    }

    return false;
}



int[,] solved = new int[,] {
    { 5, 3, -1, -1, 7, -1, -1, -1, -1 },
    { 6, -1, -1, 1, 9, 5, -1, -1, -1 },
    { -1, 9, 8, -1, -1, -1, -1, 6, -1 },
    { 8, -1, -1, -1, 6, -1, -1, -1, 3 },
    { 4, -1, -1, 8, -1, 3, -1, -1, 1 },
    { 7, -1, -1, -1, 2, -1, -1, -1, 6 },
    { -1, 6, -1, -1, -1, -1, 2, 8, -1 },
    { -1, -1, -1, 4, 1, 9, -1, -1, 5 },
    { -1, -1, -1, -1, 8, -1, -1, 7, 9 }
};


int[,] unsolved = {
    { 5, 3, -1, -1, 7, -1, -1, -1, -1 },
    { 6, -1, -1, 1, 9, 5, -1, -1, -1 },
    { -1, 9, 8, -1, -1, -1, -1, 6, -1 },
    { 8, -1, -1, -1, 6, -1, -1, -1, 3 },
    { 4, -1, -1, 8, -1, 3, -1, -1, 1 },
    { 7, -1, -1, -1, 2, -1, -1, -1, 6 },
    { -1, 6, -1, -1, -1, -1, 2, 8, -1 },
    { -1, -1, -1, 4, 1, 9, -1, -1, 5 },
    { 9, -1, -1, -1, 8, -1, -1, 7, 9 }
};

Console.WriteLine(canBeSolved(unsolved));
