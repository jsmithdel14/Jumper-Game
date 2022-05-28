public class Player{

    string guess;
    int lives = 4;
    public Player(){

    }

    public string GetGuess(){
        Console.WriteLine("Enter a letter [a-z]");
        guess = Console.ReadLine();
        return guess;
    }
    public string ReturnGuess(){
        return guess;
    }
    public int GetLives(){
        return lives;
    }
    public int CheckLives(bool victory){
        if (victory == true){
            lives = lives;
            return lives;
            
        }
        else{
            lives = lives - 1;
            return lives;
        }
    }


}