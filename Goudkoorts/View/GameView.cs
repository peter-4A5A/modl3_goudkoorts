using Goudkoorts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts.View
{
    public class GameView
    {
        private Game _game;
        public GameView(Game game)
        {
            _game = game;
        }

        public void Render()
        {
            Console.Clear();
            Console.WriteLine("Score: " + _game.Score);
            var gameMap = _game.Map;
            int index = gameMap.Count - 1;
            while(index >= 0)
            {
                string rowField = "";
                List<Field> row = gameMap[index];
                int secondIndex = 0;
                while (secondIndex < row.Count)
                {
                    Field column = row[secondIndex];
                    if (column == null)
                    {
                        rowField += " ";
                    }
                    else
                    {
                        rowField += column.FieldCharacter;
                    }
                    
                    secondIndex++;
                }
                Console.WriteLine(rowField);
                index--;
            }
        }
    }
}
