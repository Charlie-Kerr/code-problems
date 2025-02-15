using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeProblems
{
    public class ValidSoduku : ICodeProblem
    {
        public Type Type => Type.MEDIUM;
        public List<string> Tags => new List<string> { "Array", "Hash Table", "Matrix" };
        public string? Link => "https://leetcode.com/problems/valid-sudoku/description/?envType=study-plan-v2&envId=top-interview-150";
        public string? Description => "Determine if a 9 x 9 Sudoku board is valid. Only the filled cells need to be validated according to the following rules:" +
            "\nEach row must contain the digits 1-9 without repetition." +
            "\nEach column must contain the digits 1-9 without repetition." +
            "\nEach of the nine 3 x 3 sub-boxes of the grid must contain the digits 1-9 without repetition." +
            "\nNote:\nA Sudoku board (partially filled) could be valid but is not necessarily solvable." +
            "\nOnly the filled cells need to be validated according to the mentioned rules.";
        public DateOnly Date => new DateOnly(2025, 02, 013);
        public class Solution()
        {
            public static bool IsValidSudoku(char[][] board)
            {
                HashSet<char> chars = new HashSet<char>();
                Dictionary<int, HashSet<char>> columns = new Dictionary<int, HashSet<char>>();
                Dictionary<int, HashSet<char>> subBoxes = new Dictionary<int, HashSet<char>>();
                int[] indicies = { 2, 5, 8 };
                int subIndex = 0;
                for (int i = 0; i < 9; i++)
                {
                    if (i < 3)
                    {
                        subBoxes.Add(i, new HashSet<char>());
                    }
                    columns.Add(i, new HashSet<char>());
                }
                for (int i = 0; i < board.Length; i++)
                {
                    chars.Clear();
                    for (int j = 0; j < board[i].Length; j++)
                    {
                        subIndex = (j == 0) ? 0 : j / 3;//sets the subBox index to 0,1 or 2 using j
                        if (board[i][j] != '.')
                        {
                            if (chars.Contains(board[i][j]) || columns[j].Contains(board[i][j]) || subBoxes[subIndex].Contains(board[i][j])) return false;
                            chars.Add(board[i][j]);
                            columns[j].Add(board[i][j]);
                            subBoxes[subIndex].Add(board[i][j]);
                        }
                        if (indicies.Contains(i) && indicies.Contains(j))
                        {
                            subBoxes[subIndex].Clear();
                        }
                    }
                }
                return true;
            }
        }
        [TestClass]
        public class Tests() 
        {
            [TestMethod]
            public void case1()
            {
                char[][] soduku = [['5', '3', '.', '.', '7', '.', '.', '.', '.' ],
                [ '6', '.', '.', '1', '9', '5', '.', '.', '.' ],
                ['.', '9', '8', '.', '.', '.', '.', '6', '.' ],
                [ '8', '.', '.', '.', '6', '.', '.', '.', '3' ],
                ['4', '.', '.', '8', '.', '3', '.', '.', '1' ],
                [ '7', '.', '.', '.', '2', '.', '.', '.', '6' ],
                [ '.', '6', '.', '.', '.', '.', '2', '8', '.' ],
                ['.', '.', '.', '4', '1', '9', '.', '.', '5' ],
                [ '.', '.', '.', '.', '8', '.', '.', '7', '9' ] ];
                Assert.IsTrue(Solution.IsValidSudoku(soduku));
            }
            [TestMethod]
            public void case2()
            {
                char[][] soduku = [['8', '3', '.', '.', '7', '.', '.', '.', '.'],
                ['6', '.', '.', '1', '9', '5', '.', '.', '.'],
                ['.', '9', '8', '.', '.', '.', '.', '6', '.'],
                ['8', '.', '.', '.', '6', '.', '.', '.', '3'],
                ['4', '.', '.', '8', '.', '3', '.', '.', '1'],
                ['7', '.', '.', '.', '2', '.', '.', '.', '6'],
                ['.', '6', '.', '.', '.', '.', '2', '8', '.'],
                ['.', '.', '.', '4', '1', '9', '.', '.', '5'],
                ['.', '.', '.', '.', '8', '.', '.', '7', '9']];
                Assert.IsFalse(Solution.IsValidSudoku(soduku));
            }
            [TestMethod]
            public void case3()
            {
                char[][] soduku = [['.','8','7','6','5','4','3','2','1'],
                ['2','.','.','.','.','.','.','.','.'],
                ['3','.','.','.','.','.','.','.','.'],
                ['4','.','.','.','.','.','.','.','.'],
                ['5','.','.','.','.','.','.','.','.'],
                ['6','.','.','.','.','.','.','.','.'],
                ['7','.','.','.','.','.','.','.','.'],
                ['8','.','.','.','.','.','.','.','.'],
                ['9','.','.','.','.','.','.','.','.']];
                Assert.IsTrue(Solution.IsValidSudoku(soduku));
            }
        }
    }
}
