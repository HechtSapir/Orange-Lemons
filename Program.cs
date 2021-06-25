using System;

namespace JB_Js_SapirHecht
{
    class Program
    {
        /* The function gets the lemons\orenges matrix.
         * The function returns a sorted array of the "lemons' length"
         * The lemons' length could be horizontally or vertically but not diagonally 
         */
        public static int[] magic(int[,] arr)
        {

            if (arr == null) return null;

            int[] counterArr = new int[arr.GetLength(0) * arr.GetLength(1) + 1];

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] == 1)
                    {
                        counterArr[DFS(arr, i, j)]++;
                    }
                }
            }

            // Calculating the collected data, and storing the final results in a result array.
            int resArrLength = getNumberOfLemons(counterArr);
            int[] resArr = new int[resArrLength];
            setLengthOfLemonsInResultsArray(counterArr, resArr);

            return resArr;
        }

        /* Gets an array (counerArr) where each index represents the length of a lemon, 
         * and the content of each cell counts the number of times the length was encountered.
         * Set this data sorted in the result array so that each cell will contain a lemon length
         */
        private static void setLengthOfLemonsInResultsArray(int[] counterArr, int[] resArr)
        {
            int k = 0;
            for (int i = 1; i < counterArr.Length; i++)
            {
                if (counterArr[i] > 0)
                {
                    for (int j = 0; j < counterArr[i]; j++)
                    {
                        resArr[k] = i;
                        k++;
                    }
                }
            }
        }

        /* Gets an array (counterArr) where each index represents the length of a lemon, 
         * and the content of each cell counts the number of times the length was encountered.
         * The function counts and returns the amount of lemons in all the cells
         */
        private static int getNumberOfLemons(int[] counterArr)
        {
            int lemonsNumber = 0;
            for (int i = 1; i < counterArr.Length; i++)
            {
                lemonsNumber += counterArr[i];
            }

            return lemonsNumber;
        }

        /* A DFS function that gets the lemons\oragnes matrix, and a root's location(i,j).
         * The function runs a dfs algorithm from the given root, and returns the size of it(the lemon's length).
         */
        private static int DFS(int[,] arr, int i, int j)
        {
            int count = 0;
            if (i >= 0 && j >= 0 && i < arr.GetLength(0) && j < arr.GetLength(1) && arr[i, j] == 1)
            {
                // Mark this cell as visited
                arr[i, j] = -1;

                count++;
                count += DFS(arr, i + 1, j);
                count += DFS(arr, i, j + 1);
                count += DFS(arr, i - 1, j);
                count += DFS(arr, i, j - 1);
            }

            return count;
        }

        public static void Main(string[] args)
        {
            int[,] arr1 = new int[4, 4] {
                                {1, 0, 0, 1},
                                {0, 0, 1, 0},
                                {1, 0, 1, 0},
                                {1, 0, 1, 0}
                            };
            int[,] arr2 = new int[4, 8] {
                                {0, 0, 0, 1, 0, 0, 0, 1},
                                {1, 1, 0, 0, 0, 0, 1, 0},
                                {0, 0, 0, 0, 1, 1, 0, 1},
                                {1, 1, 1, 0, 0, 0, 0, 0}
                            };
            int[,] arr3 = new int[5, 5] {
                                {0, 0, 0, 0, 1},
                                {0, 1, 1, 1, 0},
                                {0, 1, 0, 1, 0},
                                {0, 1, 1, 1, 0},
                                {1, 0, 0, 0, 0}
                            };

            int[] res = magic(arr1);
            for (int i = 0; i < res.Length; i++)
            {
                if (i < res.Length - 1)
                    Console.Write(res[i] + ", ");
                else
                    Console.WriteLine(res[i]);
            }

            res = magic(arr2);
            for (int i = 0; i < res.Length; i++)
            {
                if (i < res.Length - 1)
                    Console.Write(res[i] + ", ");
                else
                    Console.WriteLine(res[i]);
            }

            res = magic(arr3);
            for (int i = 0; i < res.Length; i++)
            {
                if (i < res.Length - 1)
                    Console.Write(res[i] + ", ");
                else
                    Console.WriteLine(res[i]);
            }
        }
    }
}


