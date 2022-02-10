using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using System.IO;

namespace PdfResumeCreator
{
    public partial class Form1 : Form
    {
        string location = @"C:\Users\ASUNCION\source\repos\PdfResumeCreator\Converted.json";
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            string openJson = File.ReadAllText(location);
            datagather finalJson = JsonConvert.DeserializeObject<datagather>(openJson);
            Document pdfFile = new Document();
            PdfWriter.GetInstance(pdfFile, new FileStream(@"C:\Users\ASUNCION\source\repos\PdfResumeCreator\ASUNCION_JACOB.pdf", FileMode.Create));
            pdfFile.Open();

            LineSeparator separator = new LineSeparator(3f, 100f, BaseColor.BLACK, Element.ALIGN_CENTER, 1);

            Paragraph fullname = new Paragraph(finalJson.FullName);
            fullname.Alignment = Element.ALIGN_CENTER;
            pdfFile.Add(fullname);

            Paragraph address = new Paragraph(finalJson.Address);
            address.Alignment = Element.ALIGN_CENTER;
            pdfFile.Add(address);

            Paragraph number = new Paragraph(finalJson.Number);
            number.Alignment = Element.ALIGN_CENTER;
            pdfFile.Add(number);

            Paragraph email = new Paragraph(finalJson.Email + "\n\n");
            email.Alignment = Element.ALIGN_CENTER;
            pdfFile.Add(email);

            pdfFile.Add(separator);

            Paragraph careerTitle = new Paragraph(finalJson.CareerTitle + "\n");
            careerTitle.Font.Size = 18;
            careerTitle.Alignment = Element.ALIGN_LEFT;
            pdfFile.Add(careerTitle);

            Paragraph career = new Paragraph(finalJson.Career + "\n\n");
            career.IndentationLeft = 40;
            career.Alignment = Element.ALIGN_LEFT;
            pdfFile.Add(career);

            pdfFile.Add(separator);

            Paragraph educTitle = new Paragraph(finalJson.EducationTitle);
            educTitle.Font.Size = 18;
            educTitle.Alignment = Element.ALIGN_LEFT;
            pdfFile.Add(educTitle);

            Paragraph educ1 = new Paragraph(finalJson.Education1);
            educ1.IndentationLeft = 40;
            educ1.Alignment = Element.ALIGN_LEFT;
            pdfFile.Add(educ1);

            Paragraph educ2 = new Paragraph(finalJson.Education2 + "\n\n");
            educ2.IndentationLeft = 40;
            educ2.Alignment = Element.ALIGN_LEFT;
            pdfFile.Add(educ2);

            pdfFile.Add(separator);

            Paragraph workExpTitle = new Paragraph(finalJson.WorkExperienceTitle + "\n");
            workExpTitle.Font.Size = 18;
            workExpTitle.Alignment = Element.ALIGN_LEFT;
            pdfFile.Add(workExpTitle);

            Paragraph workExp1 = new Paragraph(finalJson.WorkExperience1 + "\n\n");
            workExp1.IndentationLeft = 40;
            workExp1.Alignment = Element.ALIGN_LEFT;
            pdfFile.Add(workExp1);

            pdfFile.Add(separator);

            Paragraph skillsTitle = new Paragraph(finalJson.SkillsTitle + "\n");
            skillsTitle.Font.Size = 18;
            skillsTitle.Alignment = Element.ALIGN_LEFT;
            pdfFile.Add(skillsTitle);

            Paragraph skill1 = new Paragraph(finalJson.Skill1);
            skill1.IndentationLeft = 40;
            skill1.Alignment = Element.ALIGN_LEFT;
            pdfFile.Add(skill1);

            Paragraph skill2 = new Paragraph(finalJson.Skill2);
            skill2.IndentationLeft = 40;
            skill2.Alignment = Element.ALIGN_LEFT;
            pdfFile.Add(skill2);

            Paragraph skill3 = new Paragraph(finalJson.Skill3 + "\n\n");
            skill3.IndentationLeft = 40;
            skill3.Alignment = Element.ALIGN_LEFT;
            pdfFile.Add(skill3);

            pdfFile.Add(separator);

            iTextSharp.text.Image signatureimg = iTextSharp.text.Image.GetInstance(finalJson.Signature);
            signatureimg.ScalePercent(5f);
            signatureimg.Alignment = iTextSharp.text.Image.UNDERLYING | iTextSharp.text.Image.ALIGN_RIGHT;
            signatureimg.IndentationRight = 50;
            pdfFile.Add(signatureimg);

            Paragraph fullname1 = new Paragraph(finalJson.FullName);
            fullname1.Alignment = Element.ALIGN_RIGHT;
            pdfFile.Add(fullname1);

            pdfFile.Close();

            MessageBox.Show("PDF has been created!");
        }
        public class datagather
        {
            public string FullName { get; set; }
            public string Address { get; set; }
            public string Email { get; set; }
            public string Number { get; set; }
            public string EducationTitle { get; set; }
            public string Education1 { get; set; }
            public string Education2 { get; set; }
            public string WorkExperienceTitle { get; set; }
            public string WorkExperience1 { get; set; }
            public string SkillsTitle { get; set; }
            public string Skill1 { get; set; }
            public string Skill2 { get; set; }
            public string Skill3 { get; set; }
            public string Signature { get; set; }
            public string CareerTitle { get; set; }
            public string Career { get; set; }

        }

    }
}
