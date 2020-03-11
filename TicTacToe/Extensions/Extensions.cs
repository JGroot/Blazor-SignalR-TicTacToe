using System;

namespace TicTacToe.Extensions
{
    public static class Extensions
    {
        public static bool isEven(this int number)
        {
            if (number % 2 == 0)
                return true;

            return false;
        }

        public static bool IsX(this string str)
        {
            if (str == "X")
                return true;

            return false;
        }

        public static bool IsO(this string str)
        {
            if (str == "O")
                return true;

            return false;
        }

       
        // 0 1 2
        // 3 4 5
        // 6 7 8

        public static bool ShouldSetUpperLeft(this string[] array)
        {
            if (!string.IsNullOrEmpty(array[0]) || array[0].IsX())
                return false;

            bool cond1 = array[1].IsX() && array[2].IsX();
            bool cond2 = array[3].IsX() && array[6].IsX();
            bool cond3 = array[4].IsX() && array[8].IsX();
            bool cond4 = array[1].IsO() && array[2].IsO();
            bool cond5 = array[3].IsO() && array[6].IsO();
            bool cond6 = array[4].IsO() && array[8].IsO();

            if (cond1 || cond2 || cond3 || cond4 || cond5 || cond6)
                return true;

            return false;
        }

        // 0 1 2
        // 3 4 5
        // 6 7 8
        public static bool ShouldSetUpperMiddle(this string[] array)
        {
            if (!string.IsNullOrEmpty(array[1]) || array[1].IsX())
                return false;

            bool cond1 = array[0].IsX() && array[2].IsX();
            bool cond2 = array[4].IsX() && array[7].IsX();
            bool cond4 = array[0].IsO() && array[2].IsO();
            bool cond5 = array[4].IsO() && array[7].IsO();

            if (cond1 || cond2 || cond4 || cond5)
                return true;

            return false;
        }

        // 0 1 2
        // 3 4 5
        // 6 7 8
        public static bool ShouldSetUpperRight(this string[] array)
        {
            if (!string.IsNullOrEmpty(array[2]) || array[2].IsX())
                return false;

            bool cond1 = array[0].IsX() && array[1].IsX();
            bool cond2 = array[4].IsX() && array[6].IsX();
            bool cond3 = array[5].IsX() && array[8].IsX();
            bool cond4 = array[0].IsO() && array[1].IsO();
            bool cond5 = array[4].IsO() && array[6].IsO();
            bool cond6 = array[5].IsO() && array[8].IsO();

            if (cond1 || cond2 || cond3 || cond4 || cond5 || cond6)
                return true;

            return false;
        }

        // 0 1 2
        // 3 4 5
        // 6 7 8
        public static bool ShouldSetLeftMiddle(this string[] array)
        {
            if (!string.IsNullOrEmpty(array[3]) || array[3].IsX())
                return false;

            bool cond1 = array[0].IsX() && array[6].IsX();
            bool cond2 = array[4].IsX() && array[5].IsX();
            bool cond3 = array[0].IsO() && array[6].IsO();
            bool cond4 = array[4].IsO() && array[5].IsO();

            if (cond1 || cond2 || cond3 || cond4)
                return true;

            return false;
        }

        // 0 1 2
        // 3 4 5
        // 6 7 8
        public static bool ShouldSetMiddle(this string[] array)
        {
            if (!string.IsNullOrEmpty(array[4]) || array[4].IsX())
                return false;

            bool cond1 = array[0].IsX() && array[8].IsX();
            bool cond2 = array[1].IsX() && array[7].IsX();
            bool cond3 = array[2].IsX() && array[6].IsX();
            bool cond4 = array[3].IsX() && array[4].IsX();
            bool cond5 = array[0].IsO() && array[8].IsO();
            bool cond6 = array[1].IsO() && array[7].IsO();
            bool cond7 = array[2].IsO() && array[6].IsO();
            bool cond8 = array[3].IsO() && array[4].IsO();

            if (cond1 || cond2 || cond3 || cond4 || cond5 || cond6 || cond7 || cond8)
                return true;

            return false;
        }

        // 0 1 2
        // 3 4 5
        // 6 7 8
        public static bool ShouldSetRightMiddle(this string[] array)
        {
            if (!string.IsNullOrEmpty(array[5]) || array[5].IsX())
                return false;

            bool cond1 = array[2].IsX() && array[8].IsX();
            bool cond2 = array[3].IsX() && array[4].IsX();
            bool cond3 = array[2].IsO() && array[8].IsO();
            bool cond4 = array[3].IsO() && array[4].IsO();

            if (cond1 || cond2 || cond3 || cond4)
                return true;

            return false;
        }

        // 0 1 2
        // 3 4 5
        // 6 7 8
        public static bool ShouldSetLowerLeft(this string[] array)
        {
            if (!string.IsNullOrEmpty(array[6]) || array[6].IsX())
                return false;

            bool cond1 = array[0].IsX() && array[3].IsX();
            bool cond2 = array[2].IsX() && array[4].IsX();
            bool cond3 = array[7].IsX() && array[8].IsX();
            bool cond4 = array[0].IsO() && array[3].IsO();
            bool cond5 = array[2].IsO() && array[4].IsO();
            bool cond6 = array[7].IsO() && array[8].IsO();

            if (cond1 || cond2 || cond3 || cond4 || cond5 || cond6)
                return true;

            return false;
        }

        // 0 1 2
        // 3 4 5
        // 6 7 8
        public static bool ShouldSetLowerMiddle(this string[] array)
        {
            if (!string.IsNullOrEmpty(array[7]) || array[7].IsX())
                return false;

            bool cond1 = array[1].IsX() && array[4].IsX();
            bool cond2 = array[6].IsX() && array[8].IsX();
            bool cond3 = array[1].IsO() && array[4].IsO();
            bool cond4 = array[6].IsO() && array[8].IsO();

            if (cond1 || cond2 || cond3 || cond4)
                return true;

            return false;
        }

        // 0 1 2
        // 3 4 5
        // 6 7 8
        public static bool ShouldSetLowerRight(this string[] array)
        {
            if (!string.IsNullOrEmpty(array[8]) || array[8].IsX())
                return false;

            bool cond1 = array[0].IsX() && array[4].IsX();
            bool cond2 = array[2].IsX() && array[5].IsX();
            bool cond3 = array[6].IsX() && array[7].IsX();
            bool cond4 = array[0].IsO() && array[4].IsO();
            bool cond5 = array[2].IsO() && array[5].IsO();
            bool cond6 = array[6].IsO() && array[7].IsO();

            if (cond1 || cond2 || cond3 || cond4 || cond5 || cond6)
                return true;

            return false;
        }

        // 0 1 2
        // 3 4 5
        // 6 7 8
        public static bool OWins(this string[] array)
        {
            bool cond1 = array[0].IsO() && array[1].IsO() && array[2].IsO();
            bool cond2 = array[3].IsO() && array[4].IsO() && array[5].IsO();
            bool cond3 = array[6].IsO() && array[7].IsO() && array[8].IsO();
            bool cond4 = array[0].IsO() && array[3].IsO() && array[6].IsO();
            bool cond5 = array[1].IsO() && array[4].IsO() && array[7].IsO();
            bool cond6 = array[2].IsO() && array[5].IsO() && array[8].IsO();
            bool cond7 = array[0].IsO() && array[4].IsO() && array[8].IsO();
            bool cond8 = array[2].IsO() && array[4].IsO() && array[6].IsO();

            if (cond1 || cond2 || cond3 || cond4 || cond5 || cond6 || cond7 || cond8)
                return true;

            return false;
        }

        // 0 1 2
        // 3 4 5
        // 6 7 8
        public static bool XWins(this string[] array)
        {
            bool cond1 = array[0].IsX() && array[1].IsX() && array[2].IsX();
            bool cond2 = array[3].IsX() && array[4].IsX() && array[5].IsX();
            bool cond3 = array[6].IsX() && array[7].IsX() && array[8].IsX();
            bool cond4 = array[0].IsX() && array[3].IsX() && array[6].IsX();
            bool cond5 = array[1].IsX() && array[4].IsX() && array[7].IsX();
            bool cond6 = array[2].IsX() && array[5].IsX() && array[8].IsX();
            bool cond7 = array[0].IsX() && array[4].IsX() && array[8].IsX();
            bool cond8 = array[2].IsX() && array[4].IsX() && array[6].IsX();

            if (cond1 || cond2 || cond3 || cond4 || cond5 || cond6 || cond7 || cond8)
                return true;

            return false;
        }

        // 0 1 2
        // 3 4 5
        // 6 7 8
        public static bool CatGame(this string[] array)
        {
            var firstempty = Array.IndexOf(array, string.Empty);
            if (firstempty < 0)
                return true;

            return false;
        }
    }
}
