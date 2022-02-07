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

                textBox1.Text = "Name: " + myResume.Name + Environment.NewLine +
                                "Age: " + myResume.Age + Environment.NewLine +
                                "Course: " + myResume.Course + Environment.NewLine +
                                "Address: " + myResume.Address;

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
    }
}
