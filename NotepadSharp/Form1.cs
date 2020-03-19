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
            saveFileDialog1.ShowDialog();
            
        }

        // the file name we enter in the dialog box is saved along with the text content in the textbox
        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string fileName = saveFileDialog1.FileName;
            File.WriteAllText(fileName,textBox1.Text);
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
            textBox1.Text= File.ReadAllText(fileName);
            FindForm().Text = openFileDialog1.SafeFileName + "- Notepad Sharp";

            // safe file name only mentions filename with an extension where as fileName mentions the entire path without extension.
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // toggle not happening on first click. As a workaround, first fire happens on load here.  
            toggleDarkMode();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void DarkMode_Click(object sender, EventArgs e)
        {
            toggleDarkMode();
        }

        private void toggleDarkMode()
        {
            if(textBox1.BackColor==Color.White)
            {
                textBox1.BackColor = Color.Black;
                textBox1.ForeColor = Color.White;
                DarkMode.Text = "Light Mode";
            }else
            {
                textBox1.BackColor = Color.White;
                textBox1.ForeColor = Color.Black;
                DarkMode.Text = "Dark Mode";
            }
        }
    }
}
