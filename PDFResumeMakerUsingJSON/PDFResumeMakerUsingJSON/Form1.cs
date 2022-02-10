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
        private string name;        //for the pdf's file name

        private string fullName, contactNo, address, email, objective, college, collegeDetail1, collegeDetail2, highschool, elementary, skill1, skill2, skill3, skill4, notes;

        private bool isReadingJson = false;

        public PDFResumeMakerUsingJSON()
        {
            InitializeComponent();
        }

        private void btnLoadJSON_Click(object sender, EventArgs e)
        {
            foreach (TextBox tb in this.Controls.OfType<TextBox>())
            {
                tb.Text = "";
                tb.ReadOnly = true;
            }

            btnSaveToJSON.Visible = false;

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

                        name = myResume.FullName;

                        txtBxFullName.Text = myResume.FullName;
                        txtBxContactNo.Text = myResume.ContactNo;
                        txtBxAddress.Text = myResume.Address;
                        txtbxEmail.Text = myResume.Email;
                        txtBxObjective.Text = myResume.Objective;
                        txtBxEducation.Text = myResume.College + Environment.NewLine +
                                              "• " + myResume.CollegeDetail1 + Environment.NewLine +
                                              "• " + myResume.CollegeDetail2 + Environment.NewLine +
                                              myResume.Highschool + Environment.NewLine +
                                              myResume.Elementary;
                        txtBxSkills.Text = "• " + myResume.Skill1 + Environment.NewLine +
                                           "• " + myResume.Skill2 + Environment.NewLine +
                                           "• " + myResume.Skill3 + Environment.NewLine +
                                           "• " + myResume.Skill4;
                        txtBxNotes.Text = myResume.Closing;

                        fullName = myResume.FullName;
                        contactNo = myResume.ContactNo;
                        address = myResume.Address;
                        email = myResume.Email;
                        objective = myResume.Objective;
                        college = myResume.College;
                        collegeDetail1 = myResume.CollegeDetail1;
                        collegeDetail2 = myResume.CollegeDetail2;
                        highschool = myResume.Highschool;
                        elementary = myResume.Elementary;
                        skill1 = myResume.Skill1;
                        skill2 = myResume.Skill2;
                        skill3 = myResume.Skill3;
                        skill4 = myResume.Skill4;
                        notes = myResume.Closing;

                        isReadingJson = true;
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
            if(isReadingJson)
            {
                //FileStream destination = new FileStream(@"C:\Users\franc\Desktop\" + name + ".pdf", FileMode.Create);
                FileStream destination = new FileStream(@"C:\Users\franc\Desktop\lorem.pdf", FileMode.Create);

                BaseFont arial = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                iTextSharp.text.Font biggest = new iTextSharp.text.Font(arial, 28, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font big = new iTextSharp.text.Font(arial, 20, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font normal = new iTextSharp.text.Font(arial, 14, iTextSharp.text.Font.NORMAL);
                iTextSharp.text.Font small = new iTextSharp.text.Font(arial, 12, iTextSharp.text.Font.NORMAL);

                Document doc = new Document(PageSize.A4, 60, 75, 60, 75);
                PdfWriter writer = PdfWriter.GetInstance(doc, destination);
                doc.AddAuthor("Francis Bernas");
                doc.AddCreator("Francis Bernas");
                doc.AddKeywords("PDF Resume");
                doc.AddTitle("Resume - PDF creation using iTextSharp");

                doc.Open();

                Paragraph paragraph = new Paragraph();
                paragraph.Add(new Phrase(fullName + "\n" + "\n", biggest));
                paragraph.Add(new Phrase(address + "\n", normal));
                paragraph.Add(new Phrase(contactNo + "\n", normal));
                paragraph.Add(new Phrase(email + "\n" + "\n" + "\n" + "\n", normal));

                paragraph.Add(new Phrase("Objective" + "\n" + "\n", big));
                paragraph.Add(new Phrase(objective + "\n" + "\n" + "\n", normal));

                paragraph.Add(new Phrase("Education" + "\n" + "\n", big));
                paragraph.Add(new Phrase(college + "\n", normal));
                paragraph.Add(new Phrase("• " + collegeDetail1 + "\n", small));
                paragraph.Add(new Phrase("• " + collegeDetail2 + "\n" + "\n", small));
                paragraph.Add(new Phrase(highschool + "\n" + "\n", normal));
                paragraph.Add(new Phrase(elementary + "\n" + "\n" + "\n" + "\n", normal));

                paragraph.Add(new Phrase("Skills" + "\n" + "\n", big));
                paragraph.Add(new Phrase("• " + skill1 + "\n", normal));
                paragraph.Add(new Phrase("• " + skill2 + "\n", normal));
                paragraph.Add(new Phrase("• " + skill3 + "\n", normal));
                paragraph.Add(new Phrase("• " + skill4 + "\n" + "\n", normal));

                paragraph.Add(new Phrase(notes + "\n" + "\n" + "\n", normal));

                doc.Add(paragraph);
                //doc.Add(new Paragraph(content));
                doc.Close();
                writer.Close();
                destination.Close();
                MessageBox.Show("PDF successfully created");
            } else
            {
                MessageBox.Show("Load a JSON file first");
            }
            
        }

        private void btnWriteJSON_Click(object sender, EventArgs e)
        {
            foreach (TextBox tb in this.Controls.OfType<TextBox>())
            {
                tb.Text = "";
                tb.ReadOnly = false;
            }

            btnSaveToJSON.Visible = true;

            //Resume newResume = new Resume
            //{
            //    FullName = "Francis Joseph E. Bernas",
            //    Address = "Manila, Philippines",
            //    ContactNo = "09511929716",
            //    Email = "francis.3.6.joseph@gmail.com",
            //    Objective = "Software engineer with Bachelor’s degree in Computer Engineering and familiarity with several programming languages.Seeking for the position of a Programmer at Lorem Ipsum to utilize teamwork and leadership skills in coordinating the effort of programmers. Also, bringing exceptional skills in designing, coding, testing, and implementing customizations to exceed customer expectations.",
            //    College = "Polytechnic University of the Philippines",
            //    CollegeDetail1 = "Bachelor of Science in Computer Engineering",
            //    CollegeDetail2 = "Involved in building of a website for the accreditation of the college department",
            //    Highschool = "Jose Abad Santos High School",
            //    Elementary = "Isabelo delos Reyes Elementary School",
            //    Skill1 = "Proficient in C#, Python, HTML & CSS and Javascript",
            //    Skill2 = "Team player who can also work independently",
            //    Skill3 = "Able to contribue to building a positive team spirit",
            //    Skill4 = "Capable of working efficiently under load and stress",
            //    Closing = "Eager to learn to new skills and knowledge that will help the company and my career"
            //};

            //string jsonToWrite = JsonConvert.SerializeObject(newResume, Formatting.Indented);

            //txtBxObjective.Text = jsonToWrite;

            //var customerFromJson = JsonConvert.DeserializeObject<Customer>(jsonFromFile);
        }

        private void btnSaveToJSON_Click(object sender, EventArgs e)
        {
            Resume newResume = new Resume
            {
                FullName = txtBxFullName.Text,
                Address = txtBxAddress.Text,
                ContactNo = txtBxContactNo.Text,
                Email = txtbxEmail.Text,
                Objective = txtBxObjective.Text,
                College = txtBxEducation.Text,
                Skill1 = txtBxSkills.Text,
                Closing = txtBxNotes.Text
            };

            string jsonToWrite = JsonConvert.SerializeObject(newResume, Formatting.Indented);

            StreamWriter createJson;
            createJson = File.CreateText(@"C:\Users\franc\source\repos\Assign#9PDFResumeMakerUsingJSON\PDFResumeMakerUsingJSON\PDFResumeMakerUsingJSON\json\" + "newjson" + ".json");

            createJson.Write(jsonToWrite);
            createJson.Close();

            MessageBox.Show("New JSON file successfully created");

            foreach (TextBox tb in this.Controls.OfType<TextBox>())
            {
                tb.Text = "";
                tb.ReadOnly = true;
            }

            btnSaveToJSON.Visible = false;
        }
    }
}
