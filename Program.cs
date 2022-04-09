using System;

namespace Assignment_6B
{
    class Program
    {
        static void Main(string[] args)
        {
            //the maze given to us
            String[,] maze = new String[,]{
                {"_","X","_","X","X"},
                {"_","X","_","X","W"},
                {"_","_","_","X","_"},
                {"X","X","_","_","_"},
                {"_","_","_","X","X"},
            };


            bool running = true; //control variable to control the do-while

            int rowPos = 0; //set the inital position to 0,0
            int colPos = 0;

            maze[rowPos, colPos] = "O"; //initalize the starting piece to the 0,0
            do
            {
                printMaze(maze);
                Console.Write("Which direction do you want to move? ");
                String direction = Console.ReadLine();

                if (direction.Equals("Up")) //Which direction the user decides to go.
                {
                    rowPos--;
                    if (checkValidPosition(maze, rowPos, colPos))  //if it's a valid move.
                    {
                        maze[rowPos+1, colPos] = "_"; //Everytime the user moves, put the path back behind him, so we don't destroy the path as we go.
                    }
                    else //it's not a valid move, so "undo" the movement
                    {
                        Console.WriteLine("You can’t move there – it’s out of bounds");
                        rowPos++;
                    }
                }
                else if(direction.Equals("Down"))
                {
                    rowPos++;
                    if (checkValidPosition(maze, rowPos, colPos))  //if it's a valid move.
                    {
                        maze[rowPos - 1, colPos] = "_"; //Everytime the user moves, put the path back behind him, so we don't destroy the path as we go.
                    }
                    else //it's not a valid move, so "undo" the movement
                    {
                        Console.WriteLine("You can’t move there – it’s out of bounds");
                        rowPos--;
                    }
                }
                else if (direction.Equals("Left"))
                {
                    colPos--;
                    if (checkValidPosition(maze, rowPos, colPos))  //if it's a valid move.
                    {
                        maze[rowPos, colPos+1] = "_"; //Everytime the user moves, put the path back behind him, so we don't destroy the path as we go.
                    }
                    else //it's not a valid move, so "undo" the movement
                    {
                        Console.WriteLine("You can’t move there – it’s out of bounds");
                        colPos++ ;
                    }

                }
                else if(direction.Equals("Right")){
                    colPos++;
                    if (checkValidPosition(maze, rowPos, colPos))  //if it's a valid move.
                    {
                        maze[rowPos, colPos - 1] = "_"; //Everytime the user moves, put the path back behind him, so we don't destroy the path as we go.
                    }
                    else //it's not a valid move, so "undo" the movement
                    {
                        Console.WriteLine("You can’t move there – it’s out of bounds");
                        colPos--;
                    }
                }
                else
                {
                    Console.WriteLine("That’s not a valid direction!");
                }

                //Everytime after we move, lets check the game status.
                int gameStatus = checkGameStatus(maze, rowPos, colPos);
                if (gameStatus == 0) //The player has run into a wall
                {
                    Console.WriteLine("You hit a wall – Game Over!");
                    running = false;
                }
                else if (gameStatus == 2) //The player has won the game
                {
                    Console.WriteLine("You Win!");
                    running = false;
                }
                else //the player proceeds normally.
                {
                    maze[rowPos, colPos] = "O"; //move the piece.
                }


            } while (running);

        }

        //This method will print the menu for the user.
        public static void printMaze(String[,] maze)
        {
            for(int i = 0; i < maze.GetLength(1); i++)
            {
                for(int j = 0; j < maze.GetLength(0); j++)
                {
                    Console.Write(maze[i, j]);
                    Console.Write(".");
                }
                Console.WriteLine();
            }
        }

        //This method will check the current position and will return true if it's on the board, false if it's off the board.
        public static bool checkValidPosition(String[,] maze, int rowPos, int colPos)
        {
            if (rowPos < 0 || rowPos >= maze.GetLength(0)) //if the position is -1 or bigger than the maze size, return false.
            {
                return false;
            }else if (colPos < 0 || colPos >= maze.GetLength(1)) //if the position is -1 or bigger than the maze size, return false.
            {
                return false;
            }
            else
            {
                return true; //the position if valid.
            }
        }

        //This method will check the game status 0 = Lost, 1 = Player still playing the game, 2 = Player has won the game.
        public static int checkGameStatus(String[,] maze, int rowPos, int colPos)
        {
            if(maze[rowPos,colPos] == "X")
            {
                return 0; //Player ran into a wall and lost.
            }else if (maze[rowPos,colPos] == "W")
            {
                return 2; //Player hit the W and won.
            }
            else
            {
                return 1; //Neither won or lost.
            }
        }




    }
}
