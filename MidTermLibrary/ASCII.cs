﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MidTermLibrary
{
    public static class ASCII
    {
        public static void DisplayASCII()
        {
            while (true)
            {
                //Wait until the user presses enter
                int enter = Console.Read();
                if (enter != (int)ConsoleKey.Enter)
                {
                    continue;
                }

                else
                {
                    //Don't display any garbage input 
                    Console.Clear();
                    //Console.WriteLine("✰★");
                    //Console.WriteLine(Encoding.GetEncoding("✰★"));
                    byte[] bytes = File.ReadAllBytes("stars.txt");
                    string stars = Encoding.Unicode.GetString(bytes);
                    char star = '★';
                    int s = star;
                    string unicode = String.Format("★", (int)'★', (int)'★');
                    Console.WriteLine(s);
                    Console.WriteLine(unicode);
                    File.WriteAllBytes("stars.txt", bytes);
                    Console.WriteLine(stars);


                    Console.WriteLine(@"
                 __    __   ___ _        __  ___  ___ ___   ___      ______  ___       ______ __ __   ___      _     ____ ____  ____   ____ ____  __ __ 
                |  |__|  | /  _| |      /  ]/   \|   |   | /  _]    |      |/   \     |      |  |  | /  _]    | |   |    |    \|    \ /    |    \|  |  |
                |  |  |  |/  [_| |     /  /|     | _   _ |/  [_     |      |     |    |      |  |  |/  [_     | |    |  ||  o  |  D  |  o  |  D  |  |  |
                |  |  |  |    _| |___ /  / |  O  |  \_/  |    _]    |_|  |_|  O  |    |_|  |_|  _  |    _]    | |___ |  ||     |    /|     |    /|  ~  |
                |  `  '  |   [_|     /   \_|     |   |   |   [_       |  | |     |      |  | |  |  |   [_     |     ||  ||  O  |    \|  _  |    \|___, |
                 \      /|     |     \     |     |   |   |     |      |  | |     |      |  | |  |  |     |    |     ||  ||     |  .  |  |  |  .  |     |
                  \_/\_/ |_____|_____|\____|\___/|___|___|_____|      |__|  \___/       |__| |__|__|_____|    |_____|____|_____|__|\_|__|__|__|\_|____/ 
                                                                                                                                        
                ");

                    Console.WriteLine(@"                                                                                                                                                             
                                                                        ##%%#.                                                                                 
                                                                      ####%%#####%%(                                                                           
                                                                    #%#%%%%%%%%%%%%%%%##%%(                                                                    
                                                                  ,%#%%%%%%%%%%%%%%%%%%%%%%%##%%%*                                                             
                                                                /##%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%###%                                                      
                                                              *%#%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%###%&/                                               
                                                            ,%#%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%##%%*                                        
                                                           %#%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%###%%*                                 
                                                         %#%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%###%&(                          
                                                       %#%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%####&                       
                                                     %#%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%###%                        
                                                   %#%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%#%**                        
                                                 %#%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%##(*,*                        
                                               %##%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%#%,.,,,,                       
                                             ###%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%#%**.*..**                       
                                           /##%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%#%*.,. ,..,/#%#                   
                                         (%#%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%#%,..*  , .*.,###%                  
                                       /%#%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%##(*.*  *  .*.,(##%.                  
                                     .%#%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%#%,.., .,  *..*%%#%                    
                                    %#%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%#%**.*  *  .,.,#%#%.                     
                                  %#%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%###*.,. *.  *.,/%##(                       
                                %#%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%#%...*  *  ,..*%%#%                         
                              %#%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%##/*.*  *  .*.,/%##(                          
                            %#%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%##%,..*..,  *..*%%#%                            
                          %##%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%#%.,.*. *  ,,.,#%#%,                             
                        (##%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%##*.,..,.  *..*%%#%                               
                      *%#%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%#%...* .*  ,..,#%#%.                                
                    .%##%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%##/*.,. *. .*.,*%%#%                                  
                   %####%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%##%,..,..,  *..*%%#%                                    
                  %#%#%####%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%#%.,.*..*. .,.,(%##(                                     
                  %#%%***,,(%%###%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%##(*..,.,...*..*%%#%                                       
                  %/#**...,*,.,%%##%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%#%...*..*..,..,(%##/                                        
                  (#%%%**....*,...,*..,%%###%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%#%.*.*..*...,.,*%%#%                                          
                   #%%/**...**....**...,*,..%%###%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%###,..,..,..*..*%%#%.                                           
                   %#%%(,...**...,*....**....*,..#%###%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%#%.,.*..*...,.,/%##%                                             
                   *##((*,,*,....,*....*,...,*....**..(%%##%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%##/*..,.,...*..*%%#%.                                              
                    %#####%%#/*,**,....**...,*....**....*,.,%%##%%%%%%%%%%%%%%%%%%%%%%%%%%%#%,..*..*..*..,(%##(                                                
                          *%%##%%#/*,,*,....,*...,*....**....*,.,%%##%%%%%%%%%%%%%%%%%%%%#%.*.,..*...*.,*%%#%                                                  
                               *%%##%%%/*,,*,....,*....*,.  ,*.. .*,..%%##%%%%%%%%%%%%%##(,..*..,..*..,%%##/                                                   
                                    ,%%##%%%/*,,*,.....*,...*,.  ,*.  .*,..%%###%%%%%##%.,.*..*...,.,*%%#%                                                     
                                          (%###%%#*,,,*,....,*.  ,*.  .*,   **..#%###%.*.,,.,...*..*%%#%.                                                      
                                               %%##%%%#*,,,*,... ,*.. ,*.  .*.  .*,,.,..*..*..*..,/%%#%                                                        
                                                    %%###%%#*,,,*,... ,*.  ,,   ,*.,*.,..*...*.,*%%#%                                                          
                                                         %%##%%%(*,,,*,..  ,*. .*, *,*..*..*..,#%###                                                           
                                                              #%###%%#*,,.,*..  ,*..,,*..,,.,*%%#%                                                             
                                                                   #%##%%%#*,..**....*,.*.,*%%#%*                                                              
                                                                       .%%##%%%/*,.,*,*,,,*%%#%                                                                
                                                                            *%%##%%#**,**%%#%,                                                                 
                                                                                 .%%#######%                                                                   
                                                                                      /%&(      ");
                    break;
                }

            }
        }
    }
}
