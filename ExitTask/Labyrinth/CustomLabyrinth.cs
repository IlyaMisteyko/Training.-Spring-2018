 using System;
using System.Collections.Generic;
using System.Linq;
 using System.Security.AccessControl;
 using System.Text;
using System.Threading.Tasks;

namespace Labyrinth
{
    public class CustomLabyrinth
    {
        private bool[,] field;

        private int currentPositionI;
        private int currentPositionJ;

        private int startI;
        private int startJ;

        private int finishI;
        private int finishJ;

        private int previousStepI;
        private int previousStepJ;


        public CustomLabyrinth()
        {
            CreateLabyrinth();
            startI = 0;
            startJ = 0;
            finishI = 11;
            finishJ = 11;
        }

        private void CreateLabyrinth()
        {
            field = new bool[11, 11];

            #region 1stColumn

            field[0, 0] = true;
            field[1, 0] = true;
            field[2, 0] = true;
            field[3, 0] = true;
            field[4, 0] = true;
            field[5, 0] = true;
            field[6, 0] = true;
            field[7, 0] = true;
            field[8, 0] = true;
            field[9, 0] = true;
            field[10, 0] = true;

            #endregion

            #region 2dColumn

            field[0, 1] = false;
            field[1, 1] = false;
            field[2, 1] = false;
            field[3, 1] = false;
            field[4, 1] = false;
            field[5, 1] = false;
            field[6, 1] = false;
            field[7, 1] = false;
            field[8, 1] = false;
            field[9, 1] = false;
            field[10, 1] = true;

            #endregion

            #region 3dColumn

            field[0, 2] = true;
            field[1, 2] = true;
            field[2, 2] = true;
            field[3, 2] = false;
            field[4, 2] = true;
            field[5, 2] = true;
            field[6, 2] = true;
            field[7, 2] = true;
            field[8, 2] = true;
            field[9, 2] = false;
            field[10, 2] = true;

            #endregion

            #region 4thColumn

            field[0, 3] = true;
            field[1, 3] = false;
            field[2, 3] = true;
            field[3, 3] = false;
            field[4, 3] = true;
            field[5, 3] = false;
            field[6, 3] = true;
            field[7, 3] = false;
            field[8, 3] = false;
            field[9, 3] = false;
            field[10, 3] = true;

            #endregion

            #region 5thColumn

            field[0, 4] = true;
            field[1, 4] = false;
            field[2, 4] = true;
            field[3, 4] = true;
            field[4, 4] = true;
            field[5, 4] = false;
            field[6, 4] = true;
            field[7, 4] = true;
            field[8, 4] = true;
            field[9, 4] = false;
            field[10, 4] = true;

            #endregion

            #region 6thColumn

            field[0, 5] = true;
            field[1, 5] = false;
            field[2, 5] = false;
            field[3, 5] = false;
            field[4, 5] = false;
            field[5, 5] = false;
            field[6, 5] = false;
            field[7, 5] = false;
            field[8, 5] = true;
            field[9, 5] = false;
            field[10, 5] = true;

            #endregion

            #region 7thColumn

            field[0, 6] = true;
            field[1, 6] = true;
            field[2, 6] = true;
            field[3, 6] = false;
            field[4, 6] = true;
            field[5, 6] = true;
            field[6, 6] = true;
            field[7, 6] = true;
            field[8, 6] = true;
            field[9, 6] = true;
            field[10, 6] = true;

            #endregion

            #region 8thColumn

            field[0, 7] = false;
            field[1, 7] = false;
            field[2, 7] = true;
            field[3, 7] = false;
            field[4, 7] = false;
            field[5, 7] = false;
            field[6, 7] = true;
            field[7, 7] = false;
            field[8, 7] = false;
            field[9, 7] = false;
            field[10, 7] = false;

            #endregion

            #region 9thColumn

            field[0, 8] = true;
            field[1, 8] = false;
            field[2, 8] = true;
            field[3, 8] = false;
            field[4, 8] = true;
            field[5, 8] = true;
            field[6, 8] = true;
            field[7, 8] = false;
            field[8, 8] = true;
            field[9, 8] = true;
            field[10, 8] = true;

            #endregion

            #region 10thColumn

            field[0, 9] = true;
            field[1, 9] = false;
            field[2, 9] = true;
            field[3, 9] = false;
            field[4, 9] = true;
            field[5, 9] = false;
            field[6, 9] = false;
            field[7, 9] = false;
            field[8, 9] = false;
            field[9, 9] = false;
            field[10, 9] = true;

            #endregion

            #region 11thColumn

            field[0, 10] = true;
            field[1, 10] = true;
            field[2, 10] = true;
            field[3, 10] = false;
            field[4, 10] = true;
            field[5, 10] = true;
            field[6, 10] = true;
            field[7, 10] = true;
            field[8, 10] = true;
            field[9, 10] = true;
            field[10, 10] = true;

            #endregion
        }
    
        public bool MoveUp(ref int i, int j)
        {
            if (i == field.GetLowerBound(0) || field[i - 1, j] == false)
            {
                return false;
            }

            previousStepI = i;
            i--;

            return true;
        }

        public bool MoveDown(ref int i, int j)
        {
            if (i == field.GetUpperBound(0)|| field[i + 1, j] == false)
            {
                return false;
            }

            previousStepI = i;
            i++; 

            return true;
        }

        public bool MoveRight(int i, ref int j)
        {
            if (j == field.GetUpperBound(0) || field[i, j + 1] == false)
            {
                return false;
            }

            previousStepJ = j;
            j++;

            return true;
        }

        public bool MoveLeft(int i, ref int j)
        {
            if (j == field.GetLowerBound(0) || field[i, j - 1] == false)
            {
                return false;
            }

            previousStepJ = j;
            j--;

            return true;
        }

        public void FindRoute()
        {
            currentPositionI = startI;
            currentPositionJ = startJ;
            previousStepI = startI;
            previousStepJ = startJ;
            FindRoute(currentPositionI, currentPositionJ);
        }

        private void FindRoute(int i, int j)
        {
            if (MoveUp(ref i, j) == true && i != previousStepI)
            {
                FindRoute(i, j);
            }

            if (MoveDown(ref i, j) == true &&  i!= previousStepI)
            {
                FindRoute(i, j);
            }

            if (MoveLeft(i, ref j) == true && j != previousStepJ)
            {
                FindRoute(i, j);
            }

            if (MoveRight(i, ref j) == true && j != previousStepJ)
            {
                FindRoute(i, j);
            }
        }
    }
}
