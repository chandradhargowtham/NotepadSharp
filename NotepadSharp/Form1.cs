using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace NotepadSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            
            InitializeComponent();
        }
        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // when save button is clicked, save file dialog is loaded.
        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter= "Text File|*.txt|HTML File|*.html";
            saveFileDialog1.Title = "Save File As";
            saveFileDialog1.ShowDialog();
            
        }

        // the file name we enter in the dialog box is saved along with the text content in the textbox
        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string fileName = saveFileDialog1.FileName;
            File.WriteAllText(fileName,richTextBox1.Text);
            FindForm().Text = saveFileDialog1.FileName + "- Notepad Sharp";
        }

        // When clicked on ok button, open file dialog is run
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
           // the file name we want to open is saved as a string.
           // the text area/typing area's text is filled with readAllText which returns a string.
            string fileName = openFileDialog1.FileName;
            richTextBox1.Text= File.ReadAllText(fileName);
            FindForm().Text = openFileDialog1.SafeFileName + "- Notepad Sharp";
            LineNumbersBox.Text = "Lines : " + (richTextBox1.Lines.Length).ToString();


            // safe file name only mentions filename with an extension where as fileName mentions the entire path without extension.
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // toggle not happening on first click. As a workaround, first fire happens on load here.  
            toggleDarkMode();
            richTextBox1.MaxLength = Int32.MaxValue;
            

        }
        // New button code
        private void button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            FindForm().Text = "Unsaved File" + "- Notepad Sharp";
            LineNumbersBox.Text = "Lines : " + (richTextBox1.Lines.Length).ToString();

        }

        private void DarkMode_Click(object sender, EventArgs e)
        {
            toggleDarkMode();
        }

        private void toggleDarkMode()
        {
            if(richTextBox1.BackColor==Color.White)
            {
                richTextBox1.BackColor = Color.Black;
                richTextBox1.ForeColor = Color.White;
                richTextBox1.SelectionBackColor = richTextBox1.BackColor;
                DarkMode.Text = "Light Mode";
            }else
            {
                richTextBox1.BackColor = Color.White;
                richTextBox1.ForeColor = Color.Black;
                richTextBox1.SelectionBackColor = richTextBox1.BackColor;
                DarkMode.Text = "Dark Mode";
            }
        }

        // opens fontDialog and gets the values from user, then textbox.font is assigned those values.
        private void fontStyle_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowDialog();
            richTextBox1.Font = fontDialog1.Font;
        }

        private void fontDialog1_Apply(object sender, EventArgs e)
        {
            
        }

        private void button4_Click_1(object sender, EventArgs e)
        {

        }

        private void MaxLength_Click(object sender, EventArgs e)
        {
            
            //richTextBox1.MaxLength =richTextBox1.MaxLength+2;
        }

        private void Find_Click(object sender, EventArgs e)
        {
            //richTextBox1.SelectionBackColor = Color.White;
            string find=(textBox2.Text.Length>1)?textBox2.Text:"";
            if(richTextBox1.Text.Contains(find))
            {
                Find.Text = "Found";
                string findSource = richTextBox1.Text;
                if (find.Length > 0)
                {
                    int start = findSource.IndexOf(find[0]);
                    int end = findSource.IndexOf(find[find.Length - 1]);
                    richTextBox1.Select(start, end + 1);

                    richTextBox1.SelectionBackColor = Color.Blue;
                }else
                {
                    richTextBox1.SelectionBackColor = richTextBox1.BackColor;
                }
            }
            else
            {
                
                Find.Text = "No Found";
               
                    richTextBox1.SelectionBackColor = richTextBox1.BackColor;
               
               
            }

            
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click_2(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged_1(object sender, EventArgs e)
        {
            
        }

        private void LineNumbers_Click(object sender, EventArgs e)
        {
            //LineNumbers.Text= richTextBox1.Lines.Length.ToString();
            for(int i =0; i< richTextBox1.Lines.Length;i++)
            {
                LineNumbersBox.Text = i.ToString();
            }
        }

        private void LineNumbers_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                for (int i = 0; i < richTextBox1.Lines.Length; i++)
                {
                    LineNumbersBox.Text = i.ToString();
                }
            }
        }

        
        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==(char)ConsoleKey.Enter)
            {
                // Buggy and unscrollable.. hence removed the feature .
                LineNumbersBox.Text = "";
                //for (int i = 1; i < richTextBox1.Lines.Length+1; i++)
                //{
                //    LineNumbersBox.Text += i.ToString() + "\n";
                //}
                LineNumbersBox.Text = "Lines : "+(richTextBox1.Lines.Length).ToString();
                

            }
        }

        private void LineNumbersBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void print_Click(object sender, EventArgs e)
        {
            printDialog1.PrintToFile = true;
            //printDialog1.ShowDialog();
            DialogResult d = printDialog1.ShowDialog();
            if (d == DialogResult.OK)
            {
                printDocument1.Print();
            }
            
        }
    }
}
