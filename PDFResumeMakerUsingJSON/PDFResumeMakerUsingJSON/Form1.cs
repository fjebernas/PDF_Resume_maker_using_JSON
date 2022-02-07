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
        private readonly string _path = @"C:\Users\franc\source\repos\Assign#9PDFResumeMakerUsingJSON\PDFResumeMakerUsingJSON\PDFResumeMakerUsingJSON\json\DummyResume.json";
        private string des;

        public PDFResumeMakerUsingJSON()
        {
            InitializeComponent();
        }

        private void btnLoadJSON_Click(object sender, EventArgs e)
        {
			try
			{
				string jsonFromFile;
				using (var reader = new StreamReader(_path))
				{
					jsonFromFile = reader.ReadToEnd();
				}

                Resume myResume = JsonConvert.DeserializeObject<Resume>(jsonFromFile);

                des = "Name: " + myResume.Name + Environment.NewLine +
                                "Age: " + myResume.Age + Environment.NewLine +
                                "Course: " + myResume.Course + Environment.NewLine +
                                "Address: " + myResume.Address;

                textBox1.Text = des;


                //Resume myResume = new Resume
                //{
                //    Name = "Francis Joseph E. Bernas",
                //    Age = 25,
                //    Course = "Bachelor of Science in Computer Engineering",
                //    Address = "Manila, Philippines"
                //};

                //string jsonToWrite = JsonConvert.SerializeObject(myResume, Formatting.Indented);

                //textBox1.Text = jsonToWrite;


                //var customerFromJson = JsonConvert.DeserializeObject<Customer>(jsonFromFile);
            }
			catch (Exception ex)
			{
				// ignored
			}
		}

        private void btnGeneratePDF_Click(object sender, EventArgs e)
        {
            try
            {
                Document doc = new Document();
                PdfWriter.GetInstance(doc, new FileStream(@"C:\Users\franc\Desktop\Resume.pdf", FileMode.Create));
                doc.Open();
                Paragraph p = new Paragraph(des);
                doc.Add(p);
                doc.Close();
                MessageBox.Show("PDF successfully created");
            }
            catch (Exception ex)
            {
                // ignored
            }
        }
    }
}
