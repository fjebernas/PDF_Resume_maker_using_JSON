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
        private string name;        //for the pdf and json file name

        private string fullName, contactNo, address, email, objective, college, collegeDetail1, collegeDetail2, highschool, elementary, skill1, skill2, skill3, skill4, notes;

        private bool isReadingJson = false;

        public PDFResumeMakerUsingJSON()
        {
            InitializeComponent();
        }

        private void btnLoadJSON_Click(object sender, EventArgs e)
        {
            foreach (TextBox tb in this.panelFields.Controls.OfType<TextBox>())
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

                        //name = myResume.FullName;
                        string[] nameParts = SplitFullNameIntoNameAndSurname(myResume.FullName);
                        nameParts[0] = nameParts[0].Replace(" ", "-");
                        nameParts[1] = nameParts[1].ToUpper();
                        name = nameParts[1] + "_" + nameParts[0];

                        txtBxFullName.Text = myResume.FullName;
                        txtBxContactNo.Text = myResume.ContactNo;
                        txtBxAddress.Text = myResume.Address;
                        txtbxEmail.Text = myResume.Email;

                        txtBxObjective.Text = myResume.Objective;

                        txtBxCollege.Text = myResume.College;
                        txtBxDegree.Text = "• " + myResume.CollegeDetail1;
                        txtBxAchievements.Text = "• " + myResume.CollegeDetail2;

                        txtBxSkillOne.Text = "• " + myResume.Skill1;
                        txtBxSkillTwo.Text = "• " + myResume.Skill2;
                        txtBxSkillThree.Text = "• " + myResume.Skill3;

                        txtBxNotes.Text = myResume.Closing;

                        fullName = myResume.FullName;
                        contactNo = myResume.ContactNo;
                        address = myResume.Address;
                        email = myResume.Email;

                        objective = myResume.Objective;

                        college = myResume.College;
                        collegeDetail1 = myResume.CollegeDetail1;
                        collegeDetail2 = myResume.CollegeDetail2;

                        skill1 = myResume.Skill1;
                        skill2 = myResume.Skill2;
                        skill3 = myResume.Skill3;

                        notes = myResume.Closing;

                        panelPlaceholder.Visible = false;
                        panelFields.Visible = true;

                        btnCancel.Visible = false;

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
                FileStream destination = new FileStream(@"C:\Users\franc\source\repos\Assign#9PDFResumeMakerUsingJSON\PDFResumeMakerUsingJSON\PDFResumeMakerUsingJSON\created-pdfs\" + name + ".pdf", FileMode.Create);
                //FileStream destination = new FileStream(@"C:\Users\franc\Desktop\lorem.pdf", FileMode.Create);

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
                paragraph.Add(new Phrase("• " + collegeDetail2 + "\n" + "\n" + "\n" + "\n", small));

                paragraph.Add(new Phrase("Skills" + "\n" + "\n", big));
                paragraph.Add(new Phrase("• " + skill1 + "\n", normal));
                paragraph.Add(new Phrase("• " + skill2 + "\n", normal));
                paragraph.Add(new Phrase("• " + skill3 + "\n" + "\n", normal));

                paragraph.Add(new Phrase(notes + "\n" + "\n" + "\n", normal));

                doc.Add(paragraph);
                //doc.Add(new Paragraph(content));
                doc.Close();
                writer.Close();
                destination.Close();
                MessageBox.Show("PDF successfully created", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                foreach (TextBox tb in this.panelFields.Controls.OfType<TextBox>())
                {
                    tb.Text = "";
                    tb.ReadOnly = true;
                }

                panelPlaceholder.Visible = true;
                panelFields.Visible = false;

                isReadingJson = false;
            } 
            else
            {
                MessageBox.Show("Load a JSON file first", "Attention!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void btnWriteJSON_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please fill out the fields", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnCancel.Visible = true;

            panelPlaceholder.Visible = false;
            panelFields.Visible = true;

            foreach (TextBox tb in this.panelFields.Controls.OfType<TextBox>())
            {
                tb.Text = "";
                tb.ReadOnly = false;
            }

            btnSaveToJSON.Visible = true;
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
                College = txtBxCollege.Text,
                CollegeDetail1 = txtBxDegree.Text,
                CollegeDetail2 = txtBxAchievements.Text,
                Skill1 = txtBxSkillOne.Text,
                Skill2 = txtBxSkillTwo.Text,
                Skill3 = txtBxSkillThree.Text,
                Closing = txtBxNotes.Text
            };

            string[] nameParts = SplitFullNameIntoNameAndSurname(newResume.FullName);
            nameParts[0] = nameParts[0].Replace(" ", "-");
            nameParts[1] = nameParts[1].ToUpper();
            name = nameParts[1] + "_" + nameParts[0];

            string jsonToWrite = JsonConvert.SerializeObject(newResume, Formatting.Indented);

            StreamWriter createJson;
            createJson = File.CreateText(@"C:\Users\franc\source\repos\Assign#9PDFResumeMakerUsingJSON\PDFResumeMakerUsingJSON\PDFResumeMakerUsingJSON\json\" + name + ".json");

            createJson.Write(jsonToWrite);
            createJson.Close();

            MessageBox.Show("New JSON file successfully created", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            foreach (TextBox tb in this.panelFields.Controls.OfType<TextBox>())
            {
                tb.Text = "";
                tb.ReadOnly = true;
            }

            btnSaveToJSON.Visible = false;

            panelPlaceholder.Visible = true;
            panelFields.Visible = false;

            btnCancel.Visible = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            foreach (TextBox tb in this.panelFields.Controls.OfType<TextBox>())
            {
                tb.Text = "";
                tb.ReadOnly = true;
            }

            panelPlaceholder.Visible = true;
            panelFields.Visible = false;

            btnCancel.Visible = false;
            btnSaveToJSON.Visible = false;
        }


        private void btn_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.FromArgb(7, 6, 23);
            //btn.Font = new System.Drawing.Font(btn.Font, FontStyle.Bold);
            btn.Font = new System.Drawing.Font("Century Gothic", 13);
        }

        private void btn_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.FromArgb(9, 18, 53);
            //btn.Font = new System.Drawing.Font(btn.Font, FontStyle.Regular);
            btn.Font = new System.Drawing.Font("Century Gothic", 11);
        }

        public static string[] SplitFullNameIntoNameAndSurname(string pFullName)
        {
            string[] NameSurname = new string[2];
            string[] NameSurnameTemp = pFullName.Split(' ');
            for (int i = 0; i < NameSurnameTemp.Length; i++)
            {
                if (i < NameSurnameTemp.Length - 1)
                {
                    if (!string.IsNullOrEmpty(NameSurname[0]))
                        NameSurname[0] += " " + NameSurnameTemp[i];
                    else
                        NameSurname[0] += NameSurnameTemp[i];
                }
                else
                    NameSurname[1] = NameSurnameTemp[i];
            }
            return NameSurname;
        }
    }
}
