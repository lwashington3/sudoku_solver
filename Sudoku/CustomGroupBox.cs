using System.Drawing;
using System.Windows.Forms;

namespace Sudoku
{
    public class CustomGroupBox : GroupBox
    {
        public TextBox[][] Boxes { get; set; } = new TextBox[3][];
        public override Color BackColor { get => Boxes[0][0].BackColor;
            set 
            {
                foreach(TextBox[] row in Boxes)
                {
                    foreach(TextBox box in row)
                    {
                        box.BackColor = value;
                    }
                }
            }
        }

        public int BoxNumber { get; set; }

        public CustomGroupBox(int textBoxSize) : base()
        {
            for(int i = 0; i < 3; i++)
            {
                Boxes[i] = new TextBox[3];
                for (int j = 0; j < 3; j++)
                {
                    TextBox textBox = new TextBox() {
                        BorderStyle = BorderStyle.FixedSingle,
                        Location = new Point(i * textBoxSize, j * textBoxSize),
                        Multiline = true,
                        Size = new Size(textBoxSize, textBoxSize),
                    };
                    
                    Boxes[i][j] = textBox;
                }
            }
        }
    }
}
