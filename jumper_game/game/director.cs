public class Director{
    bool gameEnd = false;
    
    Puzzle puzzle = new Puzzle();
    Player player = new Player();
    string secretWord;
    char letters;
    int counter = -1; 
    bool victory = false; 
    string playerGuess;
    int globalWL;
    char[] globalSA;
    char[] globalPA;
    char[] gLetters = new char[26];
    int multiples = 0;
    int number = 0;
    int lives = 4;
    public Director(){}

    public void StartGame(){
        while (gameEnd != true){
            Console.WriteLine("Let's play Jumper!");
            GetWord();
            while(gameEnd != true){
                counter = -1;
                CreateBoard();
                GetGuess();
                CheckVictory();
        }
        }
        
    }
    public void GetWord(){
        secretWord = puzzle.CreateWord();
        int wordLength = secretWord.Length;
        char[] secretArray = secretWord.ToCharArray();
        char[] printArray = new char[wordLength];
        
        globalWL = wordLength;
        globalSA = secretArray;
        globalPA = printArray;
        
        foreach (char letter in printArray){
            counter++;
            printArray[counter] = '-';
        }
    }
    public void GetGuess(){
        Console.WriteLine("");
        string playerGuess = player.GetGuess();
        //cheating below to help test
        Console.WriteLine($"You guessed {playerGuess}");

        char c = Convert.ToChar(playerGuess);
        if (gLetters.Contains(c) == false){
            bool letterFound = false; 
            gLetters[number] = c;
            number++;
            foreach(char letter in globalSA)
            { 
                counter++;
                if (letter == c)
                {
                    globalPA[counter] = c;
                    letterFound = true;
                    
                    multiples++;
                }
        
            }

            if (letterFound){
                bool win = true;
                lives = player.CheckLives(win);
            }
            else{
                    Console.WriteLine("Wrong Guess!");
                    bool win = false;
                    lives = player.CheckLives(win);} 
        }  
        
    }
    public void CreateBoard(){
        if (lives == 4){
            Console.WriteLine(globalPA);
            Console.WriteLine(" ___ ");
            Console.WriteLine("/___\\");
            Console.WriteLine("\\   /");
            Console.WriteLine(" \\ /");
            Console.WriteLine("  O");
            Console.WriteLine("/ | \\");
            Console.WriteLine(" / \\");
        }
        
        else if (lives == 3){
            Console.WriteLine(globalPA);
            Console.WriteLine("/___\\");
            Console.WriteLine("\\   /");
            Console.WriteLine(" \\ /");
            Console.WriteLine("  O");
            Console.WriteLine("/ | \\");
            Console.WriteLine(" / \\");}
        
        else if (lives == 2){
            Console.WriteLine(globalPA);
            Console.WriteLine("\\   /");
            Console.WriteLine(" \\ /");
            Console.WriteLine("  O");
            Console.WriteLine("/ | \\");
            Console.WriteLine(" / \\");}
        
        else if (lives == 1){
            Console.WriteLine(globalPA);
            Console.WriteLine(" \\ /");
            Console.WriteLine("  O");
            Console.WriteLine("/ | \\");
            Console.WriteLine(" / \\");}
        else if (lives == 0){
            Console.WriteLine(globalPA);
            Console.WriteLine("  x");
            Console.WriteLine("/ | \\");
            Console.WriteLine(" / \\");}
        
    }
    public void CheckVictory(){
        string progress = String.Concat(globalPA);
        if (progress == secretWord){
            CreateBoard();
            Console.WriteLine("You win");
            gameEnd = true;
            
            
               
        }
        else if (progress != secretWord && lives > 0){

            gameEnd = false;
            
        }
        else{
            CreateBoard();
            Console.WriteLine($"You lose, the word was {secretWord}");
            gameEnd = true;
        }
    }
}