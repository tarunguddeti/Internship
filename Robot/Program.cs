using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot
{
    class robo
    {
        public const int NORTH = 0;
        public const int EAST = 1;
        public const int SOUTH = 2;
        public const int WEST = 3;
        int[,] robot= new int[5,5];
        int x, y, direction;
        int cur_x, cur_y;
        bool robo_placed=false;
        
        
        
        public void place(int x,int y,string d)
        {
            // First initialize the array to all zeros to make sure there are no robots on the board
            for ( int f= 0; f < 5; f++)     
            {
                for ( int p = 0; p < 5; p++)
                    robot[f, p] = 0;
            }
            cur_x = x; // initialize the current x position of the robot for later tracking
            cur_y = y; // initilialize the current y position of the robot for later tracking
            //initialize the starting direction of the robot based on the user input
            if (d.Equals("NORTH"))
            {
                direction = 0;
                    }
            if (d.Equals("EAST"))
            {
                direction = 1;
                    }

            if (d.Equals("SOUTH"))
            {
                direction = 2;

                    }
            if (d.Equals("WEST"))
            {
                direction = 3;
                    }

            robot[y, x] = 1;
            robo_placed = true;
        }



        
        public void report()
        {
            int i, j;
            for (i = 4; i >= 0; i--)
                for (j = 0; j < 5; j++)
                {
                    if (robot[i,j] == 1)
                        Console.Write("{0} {1} ", j, i);
                }

            if (direction == NORTH)
                Console.WriteLine(" NORTH");
            else if (direction == EAST)
                Console.WriteLine(" EAST");
            else if (direction == SOUTH)
                Console.WriteLine(" SOUTH");
            else if (direction == WEST)
                Console.WriteLine(" WEST");
        }
       public void move()
        {
            if (direction == NORTH)
            {
                if (cur_y + 1 == 5)
                    Console.WriteLine("\n ROBO MAY FALL OFF THE BOARD COULD NOT MOVE !!\n");
                else
                {
                    robot[cur_y,cur_x] = 0;
                    robot[cur_y + 1,cur_x] = 1;
                    cur_y = cur_y + 1;
                    Console.WriteLine("MOVED SUCESSFULLY TRY THE DISPLAY OR REPORT OPTION TO CHECK THE CHANGE");
                }
            }
            if (direction == SOUTH)
            {
                if (cur_y - 1 == -1)
                    Console.WriteLine("\n ROBO MAY FALL OFF THE BOARD COULD NOT MOVE !!\n");
                else
                {
                    robot[cur_y,cur_x] = 0;
                    robot[cur_y - 1,cur_x] = 1;
                    cur_y = cur_y - 1;
                    Console.WriteLine("MOVED SUCESSFULLY TRY THE DISPLAY OR REPORT OPTION TO CHECK THE CHANGE");
                }
            }
            if (direction == EAST)
            {
                if (cur_x + 1 == 5)
                    Console.WriteLine("\n ROBO MAY FALL OFF THE BOARD COULD NOT MOVE !!\n");
                else
                {
                    robot[cur_y,cur_x] = 0;
                    robot[cur_y,cur_x + 1] = 1;
                    cur_x = cur_x + 1;
                    Console.WriteLine("MOVED SUCESSFULLY TRY THE DISPLAY OR REPORT OPTION TO CHECK THE CHANGE");
                }
            }
            if (direction == WEST)
            {
                if (cur_x - 1 == -1)
                    Console.WriteLine("\n ROBO MAY FALL OFF THE BOARD COULD NOT MOVE !!\n");
                else
                {
                    robot[cur_y,cur_x] = 0;
                    robot[cur_y,cur_x - 1] = 1;
                    cur_x = cur_x - 1;
                    Console.WriteLine("MOVED SUCESSFULLY TRY THE DISPLAY OR REPORT OPTION TO CHECK THE CHANGE");
                }
            }
        }

        public void change_direction(String d)
        {
            int dir;
            /*while (true)
            {
                Console.WriteLine("\nEnter 0 to turn left\n");
                Console.WriteLine("Enter 1 to turn right\n");
                dir = Convert.ToInt32(Console.ReadLine());
                
                if (dir == 0 || dir == 1)
                    break;
                else
                Console.WriteLine("\nplease enter valid option 0 -to turn left or 1 -to turn right\n");
                continue;
            }*/
            if (direction == NORTH)
            {
                if (d.Equals("LEFT"))
                {
                    direction = WEST;
                    Console.WriteLine("Turned the direction of the robot from current direction north to west");
                    Console.WriteLine("Try to move the robot now using the move option");
                }
                else if (d.Equals("RIGHT"))
                {
                    direction = EAST;

                    Console.WriteLine("Turned the direction of the robot from current direction north to east");
                    Console.WriteLine("Try to move the robot now using the move option");
                }
            }
            else if (direction == WEST)
            {
                if (d.Equals("LEFT"))
                {
                    direction = SOUTH;

                    Console.WriteLine("Turned the direction of the robot from current direction west to south");
                    Console.WriteLine("Try to move the robot now using the move option");
                }
                else if (d.Equals("RIGHT"))
                {
                    direction = NORTH;

                    Console.WriteLine("Turned the direction of the robot from current direction west to north");
                    Console.WriteLine("Try to move the robot now using the move option");
                }
            }
            else if (direction == SOUTH)
            {
                if (d.Equals("LEFT"))
                {
                    direction = EAST;

                    Console.WriteLine("Turned the direction of the robot from current direction south to east");
                    Console.WriteLine("Try to move the robot now using the move option");
                }
                else if (d.Equals("RIGHT"))
                {
                    direction = WEST;

                    Console.WriteLine("Turned the direction of the robot from current direction south to west");
                    Console.WriteLine("Try to move the robot now using the move option");
                }
            }
            else if (direction == EAST)
            {
                if (d.Equals("LEFT"))
                {
                    direction = NORTH;

                    Console.WriteLine("Turned the direction of the robot from current direction east to north");
                    Console.WriteLine("Try to move the robot now using the move option");
                }
                else if (d.Equals("RIGHT"))
                {
                    direction = SOUTH;

                    Console.WriteLine("Turned the direction of the robot from current direction east to south");
                    Console.WriteLine("Try to move the robot now using the move option");
                }
            }
        }

        public void display()
        {
            int k, l;
            for (k = 4; k >= 0; k--)
            {
                for (l = 0; l < 5; l++)
                {
                    Console.Write("{0}", robot[k,l]);
                }
                Console.WriteLine("\n");
            }
        }

        public bool validCommand(String c)
        {
            String[] valid_commands = { "PLACE", "MOVE", "LEFT", "RIGHT", "REPORT" };
            for(int i=0;i<valid_commands.Length;i++)
            {
                if (c.Equals(valid_commands[i]))
                {
                    return true;
                }
            }
            return false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //int choice;
            char[] delimitCharacters = { ' ', ',' };
            robo r = new robo();
            String input;
            while (true)
            {
                input = Console.ReadLine().ToUpper();
                
                String[] words = input.Split(delimitCharacters);

                bool b = r.validCommand(words[0]);
                if (b == true)
                {
                    
                    if (words[0].Equals("PLACE"))
                    {
                        if (words.Length < 4 || words.Length> 4)
                        {
                            Console.WriteLine("COMMAND DISCARDED NOT A VALID SYNTAX");
                        }
                        try
                        {
                            int x = Convert.ToInt32(words[1]);
                            int y = Convert.ToInt32(words[2]);
                            if (x < 0 || x > 4 || y < 0 || y > 4)
                            {
                                Console.WriteLine("COMMAND DISCARDED AS BOTH X AND Y SHOULD BE IN THE LIMITS FROM 0 TO 4");
                                continue;
                            }
                            if (words[3].Equals("NORTH") || words[3].Equals("EAST") || words[3].Equals("SOUTH") || words[3].Equals("WEST"))
                            {
                                r.place(x, y, words[3]);
                               // r.display();
                            }
                            else
                                Console.WriteLine("COMMAND DISCARDED AS THE DIRECTION SHOULD ONE OF NORTH SOUTH EAST OR WEST");
                        }catch(FormatException e)
                        {
                            Console.WriteLine("Please enter the x and y in correct format!!");
                        }

                     }
                    if (words[0].Equals("MOVE"))
                    {
                        r.move();
                        //r.display();
                    }
                    if(words[0].Equals("LEFT")|| words[0].Equals("RIGHT"))
                    {
                        r.change_direction(words[0]);
                        //r.display();
                    }
                }

                else
                    Console.WriteLine("COMMAND DISCARDED NOT A VALID COMMAND !");
                
                if (words[0].Equals("REPORT"))
                {
                    Environment.Exit(0);
                }
            }
            
          
         


        }
    }
}
