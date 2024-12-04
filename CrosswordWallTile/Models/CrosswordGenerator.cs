/// <summary>
/// Generates a crossword grid based on provided words.
/// </summary>
public class CrosswordGenerator
{

    /// <summary>
    /// List of words to be used in the crossword generation.
    /// </summary>
    private List<string> words;

    /// <summary>
    /// 2D array representing the crossword grid.
    /// </summary>
    private char[,] grid;

    /// <summary>
    /// Size of the crossword grid.
    /// </summary>
    private int gridSize;

    /// <summary>
    /// Initializes a new instance of the <see cref="CrosswordGenerator"/> class.
    /// </summary>
    /// <param name="words">The list of words to be used in the crossword generation.</param>
    public CrosswordGenerator(List<string> words)
    {
        this.words = words;
        GenerateCrossword();
    }

    /// <summary>
    /// Generates the crossword grid by initializing the grid size, setting up the grid with spaces, and placing the words.
    /// </summary>
    private void GenerateCrossword()
    {
        gridSize = GetGridSize();
        grid = new char[gridSize, gridSize];

        // Initialize grid with spaces
        for (int i = 0; i < gridSize; i++)
            for (int j = 0; j < gridSize; j++)
                grid[i, j] = ' ';

        PlaceWords();
    }

    /// <summary>
    /// Determines the size of the crossword grid based on the length of the longest word.
    /// </summary>
    /// <returns>The size of the grid as an integer.</returns>
    private int GetGridSize()
    {
        int maxLength = 0;
        foreach (var word in words)
            if (word.Length > maxLength)
                maxLength = word.Length;
        return Math.Max(maxLength * 2, 10); // Ensures a minimum grid size
    }

    /// <summary>
    /// Places the words in the crossword grid.
    /// </summary>
    private void PlaceWords()
    {
        if (words.Count == 0)
            return;

        // Place the first word horizontally at the center
        string firstWord = words[0].ToUpper();
        int row = gridSize / 2;
        int colStart = (gridSize - firstWord.Length) / 2;
        for (int i = 0; i < firstWord.Length; i++)
            grid[row, colStart + i] = firstWord[i];

        // Place remaining words
        for (int w = 1; w < words.Count; w++)
        {
            string word = words[w].ToUpper();
            bool placed = false;

            // Attempt to place the word by finding intersecting letters
            for (int i = 0; i < word.Length && !placed; i++)
            {
                char c = word[i];
                for (int r = 0; r < gridSize && !placed; r++)
                {
                    for (int cIdx = 0; cIdx < gridSize && !placed; cIdx++)
                    {
                        if (grid[r, cIdx] == c)
                        {
                            if (CanPlaceVertically(word, i, r, cIdx))
                            {
                                PlaceVertically(word, i, r, cIdx);
                                placed = true;
                            }
                            else if (CanPlaceHorizontally(word, i, r, cIdx))
                            {
                                PlaceHorizontally(word, i, r, cIdx);
                                placed = true;
                            }
                        }
                    }
                }
            }
            // Word is skipped if it cannot be placed
        }
    }

    /// <summary>
    /// Checks if a word can be placed vertically in the grid.
    /// </summary>
    /// <param name="word">The word to be placed.</param>
    /// <param name="charIndex">The index of the character in the word that intersects with an existing character in the grid.</param>
    /// <param name="row">The row index of the intersecting character in the grid.</param>
    /// <param name="col">The column index of the intersecting character in the grid.</param>
    /// <returns>True if the word can be placed vertically, otherwise false.</returns>
    private bool CanPlaceVertically(string word, int charIndex, int row, int col)
    {
        int startRow = row - charIndex;
        if (startRow < 0 || startRow + word.Length > gridSize)
            return false;

        for (int i = 0; i < word.Length; i++)
        {
            int currentRow = startRow + i;
            char existingChar = grid[currentRow, col];
            if (existingChar != ' ' && existingChar != word[i])
                return false;
        }
        return true;
    }

    /// <summary>
    /// Places a word vertically in the grid.
    /// </summary>
    /// <param name="word">The word to be placed.</param>
    /// <param name="charIndex">The index of the character in the word that intersects with an existing character in the grid.</param>
    /// <param name="row">The row index of the intersecting character in the grid.</param>
    /// <param name="col">The column index of the intersecting character in the grid.</param>
    private void PlaceVertically(string word, int charIndex, int row, int col)
    {
        int startRow = row - charIndex;
        for (int i = 0; i < word.Length; i++)
            grid[startRow + i, col] = word[i];
    }

    /// <summary>
    /// Checks if a word can be placed horizontally in the grid.
    /// </summary>
    /// <param name="word">The word to be placed.</param>
    /// <param name="charIndex">The index of the character in the word that intersects with an existing character in the grid.</param>
    /// <param name="row">The row index of the intersecting character in the grid.</param>
    /// <param name="col">The column index of the intersecting character in the grid.</param>
    /// <returns>True if the word can be placed horizontally, otherwise false.</returns>
    private bool CanPlaceHorizontally(string word, int charIndex, int row, int col)
    {
        int startCol = col - charIndex;
        if (startCol < 0 || startCol + word.Length > gridSize)
            return false;

        for (int i = 0; i < word.Length; i++)
        {
            int currentCol = startCol + i;
            char existingChar = grid[row, currentCol];
            if (existingChar != ' ' && existingChar != word[i])
                return false;
        }
        return true;
    }

    /// <summary>
    /// Places a word horizontally in the grid.
    /// </summary>
    /// <param name="word">The word to be placed.</param>
    /// <param name="charIndex">The index of the character in the word that intersects with an existing character in the grid.</param>
    /// <param name="row">The row index of the intersecting character in the grid.</param>
    /// <param name="col">The column index of the intersecting character in the grid.</param>
    private void PlaceHorizontally(string word, int charIndex, int row, int col)
    {
        int startCol = col - charIndex;
        for (int i = 0; i < word.Length; i++)
            grid[row, startCol + i] = word[i];
    }

    /// <summary>
    /// Retrieves the generated crossword grid.
    /// </summary>
    /// <returns>A 2D array representing the crossword.</returns>
    public string[,] GetCrossword()
    {
        string[,] output = new string[gridSize, gridSize];
        for (int i = 0; i < gridSize; i++)
            for (int j = 0; j < gridSize; j++)
                output[i, j] = grid[i, j] == ' ' ? string.Empty : grid[i, j].ToString();
        return output;
    }
}
