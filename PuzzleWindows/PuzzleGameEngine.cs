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
            for (int n = 0; n < 10000; n++)
            {
                i = r.Next(16);
                Change(i);
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

        internal void Change(int touchIndex)
        {
            //터치한 인덱스 상하좌우에 빈 인덱스 있는지 확인하자
            if(getEmptyIndex()/4 == touchIndex/4 && (getEmptyIndex() == touchIndex - 1 || getEmptyIndex() == touchIndex + 1) 
                || getEmptyIndex() == touchIndex - 4 || getEmptyIndex() == touchIndex + 4)
            {
                Swap(getEmptyIndex(), touchIndex);
            }
        }

        private int getEmptyIndex()
        {
            for(int i = 0; i < puzzleSize; i++)
            {
                if (theViewIndices[i] == puzzleSize - 1)
                {
                    return i;
                }   
            }
            return -1;
        }

        internal bool isEnd()
        {
            int count = 0;
            for(int i = 0; i < 16; i++)
            {
                if(theViewIndices[i] == i)
                {
                    count++;
                }
            }
            return count == puzzleSize;

        }
    }
}