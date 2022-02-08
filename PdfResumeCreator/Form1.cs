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

            Paragraph fullname = new Paragraph(finalJson.FullName);
            fullname.Alignment = Element.ALIGN_CENTER;
            pdfFile.Add(fullname);

            Paragraph address = new Paragraph(finalJson.Address);
            address.Alignment = Element.ALIGN_CENTER;
            pdfFile.Add(address);

            Paragraph number = new Paragraph(finalJson.Number);
            number.Alignment = Element.ALIGN_CENTER;
            pdfFile.Add(number);

            Paragraph email = new Paragraph(finalJson.Email);
            email.Alignment = Element.ALIGN_CENTER;
            pdfFile.Add(email);

            Paragraph age = new Paragraph(finalJson.Age);
            age.Alignment = Element.ALIGN_CENTER;
            pdfFile.Add(age);

            Paragraph divider = new Paragraph(finalJson.Divider);
            divider.Alignment = Element.ALIGN_CENTER;
            pdfFile.Add(divider);

            Paragraph educTitle = new Paragraph(finalJson.EducationTitle);
            educTitle.Alignment = Element.ALIGN_LEFT;
            pdfFile.Add(educTitle);

            pdfFile.Close();
        }
        public class datagather
        {
            public string FullName { get; set; }
            public string Age { get; set; }
            public string Address { get; set; }
            public string Email { get; set; }
            public string Divider { get; set; }
            public string Number { get; set; }
            public string EducationTitle { get; set; }
        }
    }
}
