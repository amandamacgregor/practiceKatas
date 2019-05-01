namespace PencilKata.Library
{
    public class Paper
    {
        public string Writing { get; set; }
        
        public int FirstOpenSpace { get; set; }

        public Paper(int lengthOfWriting)
        {
            Writing = new string(' ', lengthOfWriting);
        }

        public void Write(Pencil pencil, string input)
        {
            var currentWriting = Writing.ToCharArray();

            for (var i = 0; i < input.Length; i++)
            {
                if (pencil.PointDurability <= 0) break;
                
                pencil.Write(input[i]);
                currentWriting[FirstOpenSpace + i] = input[i];
            }

            FirstOpenSpace += input.Length;

            Writing = new string(currentWriting);
        }

        public void Erase(Eraser eraser, string inputString)
        {
            var currentWriting = Writing.ToCharArray();
            var indexToStartReplace = Writing.LastIndexOf(inputString) + 
                                      inputString.Length - 1;

            for (var i = inputString.Length; i > 0; i--)
            {
                if (eraser.Durability < 1) break;
                
                eraser.Erase(currentWriting[indexToStartReplace]);
                currentWriting[indexToStartReplace] = ' ';
                indexToStartReplace--;
            }
            
            Writing = new string(currentWriting);
        }

        public void Edit(Pencil pencil, Eraser eraser, string toErase, string replaceWith)
        {
            Erase(eraser, toErase);
            Write(pencil, replaceWith);
        }
    }
}