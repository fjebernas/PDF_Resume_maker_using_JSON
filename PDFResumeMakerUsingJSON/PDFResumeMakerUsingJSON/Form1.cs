using iTextSharp.text;
using iTextSharp.text.pdf;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDFResumeMakerUsingJSON
{
    public partial class PDFResumeMakerUsingJSON : Form
    {
        private string _path;       //path of json file
        private string content;     //for the pdf's content
        private string name;        //for the pdf's file name

        public PDFResumeMakerUsingJSON()
        {
            InitializeComponent();
        }

        private void btnLoadJSON_Click(object sender, EventArgs e)
        {
			try
			{
                string jsonFromFile;

                OpenFileDialog openFileDialog = new OpenFileDialog();
                DialogResult result = openFileDialog.ShowDialog();      // Show the dialog.
                if (result == DialogResult.OK)                          // Test result.
                {
                    _path = openFileDialog.FileName;
                    try
                    {
                        jsonFromFile = File.ReadAllText(_path);
                        Resume myResume = JsonConvert.DeserializeObject<Resume>(jsonFromFile);

                        content = "Name: " + myResume.Name + Environment.NewLine +
                              "Age: " + myResume.Age + Environment.NewLine +
                              "Course: " + myResume.Course + Environment.NewLine +
                              "School: " + myResume.School + Environment.NewLine +
                              "Address: " + myResume.Address + Environment.NewLine +
                              "Objective: " + myResume.Objective + Environment.NewLine +
                              "Skills: " + myResume.Skills;

                        name = myResume.Name;
                        displayTxtBox.Text = content;
                    }
                    catch (IOException)
                    {
                        // ignored
                    }
                }
            }
            catch (Exception)
			{
				// ignored
			}
		}

        private void btnGeneratePDF_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream destination = new FileStream(@"C:\Users\franc\Desktop\" + name + ".pdf", FileMode.Create);

                Document doc = new Document(PageSize.A4, 25, 25, 30, 30);
                PdfWriter writer = PdfWriter.GetInstance(doc, destination);
                doc.AddAuthor("Francis Bernas");
                doc.AddCreator("Francis Bernas");
                doc.AddKeywords("PDF Resume");
                doc.AddTitle("Resume - PDF creation using iTextSharp");

                doc.Open();
                doc.Add(new Paragraph(content));
                doc.Close();
                writer.Close();
                destination.Close();
                MessageBox.Show("PDF successfully created");
            }
            catch (Exception)
            {
                MessageBox.Show("Load a JSON file first");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Resume newResume = new Resume
            {
                Name = "Francis Joseph E. Bernas",
                Age = 25,
                Course = "Bachelor of Science in Computer Engineering",
                School = "Polytechnic University of the Philippines",
                Address = "Manila, Philippines",
                Objective = "To find a job where I can use my programming skills",
                Skills = "C#, Python, HTML & CSS and JavaScript"
            };

            string jsonToWrite = JsonConvert.SerializeObject(newResume, Formatting.Indented);

            displayTxtBox.Text = jsonToWrite;


            //var customerFromJson = JsonConvert.DeserializeObject<Customer>(jsonFromFile);
        }
    }
}
