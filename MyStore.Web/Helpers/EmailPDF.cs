using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using MyStore.Web.Data.Entities;

namespace MyStore.Web.Helpers
{
    public class EmailPDF
    {
        
            public byte[] PdfGenerate(Order order, string email)
            {
                var html = BuildEmailContent(order, email);

                byte[] bytes = null;

                StringReader sr = new StringReader(html.ToString());

                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
                    pdfDoc.Open();

                    htmlparser.Parse(sr);
                    pdfDoc.Close();

                    bytes = memoryStream.ToArray();
                    memoryStream.Close();
                }
                return bytes;
            }

            protected StringBuilder BuildEmailContent(Order order, string email)
            {
                StringBuilder stringBuilder = new StringBuilder();
               
                stringBuilder.Append("<header class='clearfix'>");
                stringBuilder.Append("<h1>FURNITURE</h1>");
                stringBuilder.Append("<div id='company' class='clearfix'>");
                stringBuilder.Append("<div><h2>My Store</h2></div>");
                stringBuilder.Append("<div>1800-280 Lisboa</div>");
                stringBuilder.Append("<div>21 125 124 8</div>");
                stringBuilder.Append("<div><a href='mailto:yourvet.info@gmail.com'>info@furniture.com</a></div>");
                stringBuilder.Append("</div>");
                stringBuilder.Append("<div id='project'>");
                stringBuilder.Append($"<div><span>Client:</span>{order.User.Name}</div>");
                stringBuilder.Append($"<div><span>VAT:</span>{order.User.VAT}</div>");
                stringBuilder.Append($"<div><span>Date:</span> {DateTime.UtcNow.ToLocalTime().ToLongDateString()}</div>");
                stringBuilder.Append("</div>");
                stringBuilder.Append("</header>");
                stringBuilder.Append("<main>");
                stringBuilder.Append("<table>");
                stringBuilder.Append("<thead>");
                stringBuilder.Append("<tr>");
                stringBuilder.Append("<th class='service'><strong>Product</strong></th>");
                stringBuilder.Append("<th>Price</th>");
                stringBuilder.Append("<th>Quantity</th>");
                stringBuilder.Append("<th>Total</th>");
                stringBuilder.Append("</tr>");
                stringBuilder.Append("</thead>");
                stringBuilder.Append("<tbody>");
                foreach (var item in order.Items)
                {
                    stringBuilder.Append("<tr>");
                    stringBuilder.Append($"<td class='service'>{item.Product.Name}</td>");
                    stringBuilder.Append($"<td class='unit'>{item.Product.Price}</td>");
                    stringBuilder.Append($"<td class='qty'>{item.Quantity}</td>");
                    stringBuilder.Append($"<td class='total'>{item.Value}</td>");
                    stringBuilder.Append("</tr>");
                }

                stringBuilder.Append("<tr>");
                stringBuilder.Append("<td colspan='4' class='grand total'>TOTAL</td>");
                stringBuilder.Append($"<td class='grand total'>{order.Value}</td>");
                stringBuilder.Append("</tr>");
                stringBuilder.Append("</tbody>");
                stringBuilder.Append("</table>");
                stringBuilder.Append("<div id='notices'>");

                stringBuilder.Append("</main>");
                stringBuilder.Append("<footer>");
                stringBuilder.Append("Email send by FURNITURE");
                stringBuilder.Append("</footer>");

                return stringBuilder;
            }
        }
    
}
