using System;

namespace PuzzleWindows
{
    internal class PuzzleGameEngine
    {
        int[] theViewIndices;
        private int puzzleSize = 16;

        public PuzzleGameEngine()
        {
            //이미지 index 가져오자
            theViewIndices = new int[puzzleSize];
            for (int a = 0; a < puzzleSize; a++)
            {
                theViewIndices[a] = a;
            }

            //이미지 index 섞자
            int i, j;
            Random r = new Random();
            for (int n = 0; n < 100; n++)
            {
                i = r.Next(0, puzzleSize);
                j = r.Next(0, puzzleSize);
                Swap(i,j);
            }
        }

        private void Swap(int i1, int i2)
        {
            int temp;
            temp = theViewIndices[i1];
            theViewIndices[i1] = theViewIndices[i2];
            theViewIndices[i2] = temp;
        }

        internal int GetViewIndex(int index)
        {
            return theViewIndices[index];
        }
    }
}