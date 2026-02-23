using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rougelike
{
    public class ItemBehaviour
    {
        public List<Action<Button, GameForm>> methods = new List<Action<Button, GameForm>>();
        public void setup()
        {
            methods.Add(GekoTail);
        }


        public void GekoTail(Button button, GameForm gameForm)
        {
            if (!button.Name.Contains("Copy"))
            {
                int size = button.Size.Width;
                size = size / 2;
                gameForm.InitializeButton(button.Location.X, button.Location.Y, size, button.BackColor,clone: true);

            }

            
        }
    }
}
