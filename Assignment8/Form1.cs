using System.CodeDom;
using System.Collections;
using System.Diagnostics;
using System.Drawing.Text;

namespace Assignment8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ArrayList fileNamesArr = giveFileNames(checkBox1, checkBox2);
            ArrayList nameArr = readTheFile(fileNamesArr);
            textBox2.Text = checkTheName(nameArr, textBox1);
        }

        private String checkTheName(ArrayList nameArr, TextBox userInput)
        {
            String userInputedName = userInput.Text;
            Debug.WriteLine(userInputedName, nameArr.Count);
            Debug.WriteLine(nameArr.Count);
            if (nameArr.Contains(userInputedName))
            {
                return "Yes";
            }
            else
            {
                return "No";
            }
        }

        private ArrayList readTheFile(ArrayList fileNames)
        {
            ArrayList namesArr = new ArrayList();  

            foreach (string name in fileNames)
            {
                StreamReader reader = new StreamReader(name);

                String lines = "";

                while((lines = reader.ReadLine()) != null)
                {
                    namesArr.Add(lines);
                }

            }

            return namesArr;
        }

        private ArrayList giveFileNames(CheckBox firstCheckBox, CheckBox secondCheckBox)
        {
            ArrayList fileNames = new ArrayList();

            String ROOT_FILE_PATH = "C:/Users/pavel/source/repos/Assignment8/Assignment8/resources/text_files/";

            if (firstCheckBox.Checked)
            {

                fileNames.Add(ROOT_FILE_PATH + "female.txt");

                return fileNames;
            }
            else if (secondCheckBox.Checked)
            {
                fileNames.Add(ROOT_FILE_PATH + "male.txt");

                return fileNames;
            }
            else if(firstCheckBox.Checked && secondCheckBox.Checked)
            {
                fileNames.Add(ROOT_FILE_PATH + "female.txt");
                fileNames.Add(ROOT_FILE_PATH + "male.txt");

                return fileNames;
            }
            else
            {
                textBox1.Text = "You haven't selected name gender";
                return new ArrayList();
            }
        }
    }
}