try
{
    // Create an instance of StreamReader to read from a file.
    // The using statement also closes the StreamReader.
    using (StreamReader sr = new StreamReader("e:/minesweeper.txt"))
    {
        string line;
        char[][] mines; // Mined./Unmined* positions
        char[][] pos; //Touchedx/Untouched. Positions

        if ((line = sr.ReadLine()) != null)
        {
            int N = Convert.ToInt32(line);
            mines = new char[N][];
            pos = new char[N][];

            //Reading the Data into Arrays
            for (int i = 0; i < N; i++)
            {
                line = sr.ReadLine();
                mines[i] = line.ToCharArray();
            }

            for (int i = 0; i < N; i++)
            {
                line = sr.ReadLine();
                pos[i] = line.ToCharArray();
            }

            Boolean MineTouched = false;

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    //Position Touched:
                    if (pos[i][j] == 'x')
                    {
                        //Mine not touched
                        if (mines[i][j] == '.')
                        {
                            pos[i][j] = '0';
                            for (int k = i-1; k <= i+1; k++)
                            {
                                for (int l = j-1; l <= j+1; l++)
                                {
                                    //Using TRY-CATCH to handle Array out of Bound Exception
                                    try
                                    {
                                        if (mines[k][l] == '*')
                                            pos[i][j]++;
                                    }
                                    catch (IndexOutOfRangeException e)
                                    {
                                        continue;
                                    }
                                }
                            }

                        }
                        //Mine touched
                        else
                        {
                            pos[i][j] = '*';
                            MineTouched = true;

                        }

                    }
                }
            }

            //If Mine is Touched:
            if (MineTouched)
            {
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        {
                            if (pos[i][j] == '.' && mines[i][j] == '*')
                                pos[i][j] = '*';
                        }
                    }
                }
            }

            //------------DISPLAYING OUTPUT
            foreach (char[] pos1 in pos)
            {
               foreach (char p in pos1)
                    Console.Write(p);
                Console.WriteLine();
            }



        }
    }
}
catch (Exception e)
{
    // Let the user know what went wrong.
    Console.WriteLine("The file could not be read:");
    Console.WriteLine(e.Message);
}


