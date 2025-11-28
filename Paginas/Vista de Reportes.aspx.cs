using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using OfficeOpenXml;
using Semana12.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Semana12.Paginas
{
    public partial class Vista_de_Reportes : System.Web.UI.Page
    {
        private Persona Persona = new Persona();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Persona> personas = new List<Persona>()
                {
                    new Persona {Id = 1, Name = "Allen",Age = 20},
                    new Persona {Id = 2, Name = "David",Age = 30},
                    new Persona {Id = 3, Name = "Lelia",Age = 68}
                };
                gvPersonas.DataSource = personas;
                gvPersonas.DataBind();
            }
        }
        public void btnGenerarPDF_Click(object sender, EventArgs e)
        {
            List<Persona> personas = new List<Persona>()
                {
                    new Persona {Id = 1, Name = "Allen",Age = 20},
                    new Persona {Id = 2, Name = "David",Age = 30},
                    new Persona {Id = 3, Name = "Lelia",Age = 68}
                };
            string ruta = Server.MapPath("~/Reportes/GeneratedReport.pdf");
            using (var writter = new PdfWriter(ruta))
            {
                using (var pdf = new PdfDocument(writter))
                {
                    var documento = new Document(pdf);
                    documento.Add(new Paragraph("Reporte de Personas"));
                    foreach (Persona persona in personas)
                    {
                        documento.Add(new Paragraph("ID: " + persona.Id));
                        documento.Add(new Paragraph("Nombre: " + persona.Name));
                        documento.Add(new Paragraph("Edad: " + persona.Age));
                    }
                    documento.Close();
                }
            }
            Response.ContentType = "application/pdf";
            Response.AppendHeader("Content-Disposition", "attachment; filename=Reporte.pdf");
            Response.TransmitFile(ruta);
            Response.End();

        }
        public void btnExcel_Click(object sender, EventArgs e)
        {
            List<Persona> personas = new List<Persona>()
                {
                    new Persona {Id = 1, Name = "Allen",Age = 20},
                    new Persona {Id = 2, Name = "David",Age = 30},
                    new Persona {Id = 3, Name = "Lelia",Age = 68}
                };
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                //Agregar hoja
                var hoja = excelPackage.Workbook.Worksheets.Add("Reporte");
                hoja.Cells[1, 1].Value = "ID";
                hoja.Cells[1, 2].Value = "Nombre";
                hoja.Cells[1, 3].Value = "Edad";
                for(int i = 0; i < personas.Count; i++)
                {
                    hoja.Cells[i + 2, 1].Value = personas[i].Id;
                    hoja.Cells[i + 2, 2].Value = personas[i].Name;
                    hoja.Cells[i + 2, 3].Value = personas[i].Age;
                    
                }
                Response.Clear();
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AppendHeader("Content-Disposition", "attachment; filename=Reporte.xlsx");
                Response.End();
            }
        }
    }
}