namespace PencilKata.Library
{
    public class Paper
    {
        public string Writing { get; set; }
        
        public int FirstOpenSpace { get; set; }

        public int LastErasedSpot { get; set; }

        private char[] _currentWriting;

        public Paper(int lengthOfWriting)
        {
            Writing = new string(' ', lengthOfWriting);
        }

        public void Write(IFiniteWritingTool pencil, string input)
        {
            _currentWriting = Writing.ToCharArray();

            LoopThroughInput(pencil, input);

            FirstOpenSpace += input.Length;

            Writing = new string(_currentWriting);
        }

        

        public void Erase(Eraser eraser, string inputString)
        {
            var currentWriting = Writing.ToCharArray();
            var indexToStartReplace = Writing.LastIndexOf(inputString) + 
                                      inputString.Length - 1;

            var lastErasedSpot = Writing.LastIndexOf(inputString) + inputString.Length;

            for (var i = inputString.Length; i > 0; i--)
            {
                if (eraser.Durability < 1) break;
                
                eraser.Use(currentWriting[indexToStartReplace]);
                currentWriting[indexToStartReplace] = ' ';
                lastErasedSpot--;
                indexToStartReplace--;
            }

            LastErasedSpot = lastErasedSpot;
            
            Writing = new string(currentWriting);
        }
        
        private void LoopThroughInput(IFiniteWritingTool tool, string input)
        {
            for (var i = 0; i < input.Length; i++)
            {
                if (tool.Durability <= 0) break;

                tool.Use(input[i]);
                _currentWriting[FirstOpenSpace + i] = input[i];
            }
        }

        public void Edit(Pencil pencil, string replaceWith)
        {
            _currentWriting = Writing.ToCharArray();

            for (var i = 0; i < replaceWith.Length; i++)
            {
                if (pencil.Durability <= 0) break;
                
                pencil.Use(replaceWith[i]);
                InsertOrReplace(replaceWith,i, LastErasedSpot);
            }
            
            Writing = new string(_currentWriting);
        }

        private void InsertOrReplace(string replaceWith, int indexOfInput, int startPoint)
        {
            var replacementChar = '@';

            if (char.IsWhiteSpace(_currentWriting[startPoint + indexOfInput]))
            {
                replacementChar = replaceWith[indexOfInput];
            }

            _currentWriting[startPoint + indexOfInput] = replacementChar;
        }
    }
}