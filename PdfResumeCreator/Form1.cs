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
            Paragraph fullname;
            pdfFile.Close();
        }
        public class datagather
        {
            public string FullName { get; set; }
        }
    }
}
