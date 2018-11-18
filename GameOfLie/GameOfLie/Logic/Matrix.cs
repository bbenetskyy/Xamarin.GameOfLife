using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLie.Logic
{

    public class Matrix
    {
        public static bool[,] GenerateInitialState(int xLength, int yLength)
        {
            bool[,] initialState = new bool[xLength, yLength];
            var rnd = new Random();

            for (int x = 0; x < xLength; x++)
            {
                for (int y = 0; y < yLength; y++)
                {
                    initialState[x, y] = Convert.ToBoolean(rnd.Next(1, 100) % 2);
                }
            }
            return initialState;
        }

        public Matrix(bool[,] initialState)
        {
            _state = initialState;

            _xLength = initialState.GetLength(0);
            _yLength = initialState.GetLength(1);
        }

        public bool[,] Next()
        {
            bool[,] nextState = new bool[_xLength, _yLength];

            for (int x = 0; x < _xLength; x++)
            {
                for (int y = 0; y < _yLength; y++)
                {
                    nextState[x, y] = CalcNextState(x, y);
                }
            }

            _state = nextState;
            return nextState;
        }

        private bool CalcNextState(int x, int y)
        {
            var aliveN = 0;

            for (int i = Math.Max(x - 1, 0); i <= Math.Min(x + 1, _xLength - 1); i++)
            {
                for (int j = Math.Max(y - 1, 0); j <= Math.Min(y + 1, _yLength - 1); j++)
                {
                    aliveN += !(i == x && j == y) && _state[i, j] ? 1 : 0;
                }
            }

            return aliveN == 3 || (aliveN == 2 && _state[x, y]);
        }

        private bool[,] _state;
        private readonly int _xLength;
        private readonly int _yLength;
    }
}
