public class Puzzle{

    Random random = new Random();
    List<string> list = new List<string>{"apple","lemon","fruit","dodge","fight","superman","ogre","sword","pizza"};
    
    
    public Puzzle(){}

    public string CreateWord(){
        int index = random.Next(list.Count);
        return (list[index]);
        
    }


}