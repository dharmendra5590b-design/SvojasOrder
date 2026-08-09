using Common;
using Domain;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrderPdfService
    {
        public AppSetting _appSetting;
        

        // ---------------------------------------------------------------------
        // 1. Download the CAD image (needed both to embed in the PDF and to
        //    attach separately to the email). Returns null if it can't be
        //    fetched so a bad/missing URL never breaks the whole send.
        // ---------------------------------------------------------------------
        private async Task<byte[]?> DownloadCadImageAsync(string cadImageUrl)
        {
            if (string.IsNullOrWhiteSpace(cadImageUrl))
                return null;

            try
            {
                string uploadFolder = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot");
                uploadFolder = Path.Combine(uploadFolder, cadImageUrl);
                return await File.ReadAllBytesAsync(uploadFolder);
            }
            catch
            {
                return null;
            }
        }

        private static string GetImageExtension(string url)
        {
            try
            {
                var ext = System.IO.Path.GetExtension(new Uri(url).AbsolutePath).TrimStart('.');
                return string.IsNullOrWhiteSpace(ext) ? "jpg" : ext.ToLowerInvariant();
            }
            catch
            {
                return "jpg";
            }
        }

        // ---------------------------------------------------------------------
        // 2. Build the PDF
        // ---------------------------------------------------------------------
        public async Task<byte[]> GenerateOrderPdfAsync(DataSet ds)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            if (ds.Tables.Count < 2 || ds.Tables[0].Rows.Count == 0)
                throw new ArgumentException("Dataset must contain an order row (Table 0) and a specification table (Table 1).");

            var row = ds.Tables[0].Rows[0];

            var specLines = ds.Tables[1].Rows.Cast<DataRow>()
                .Select(r => Utility.GetVal(r, "Specification"))
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .ToList();

            var cadImageBytes = await DownloadCadImageAsync(Utility.GetVal(row, "CAD_Image_URL"));

            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(20);
                    page.DefaultTextStyle(x => x.FontSize(9).FontFamily("Arial"));

                    page.Content().Column(main =>
                    {
                        // ---- Top block: label/value grid (left) + CAD image (right) ----
                        main.Item().Row(top =>
                        {
                            top.RelativeItem(2).Border(1).Table(table =>
                            {
                                table.ColumnsDefinition(c =>
                                {
                                    c.RelativeColumn(1.3f); // label
                                    c.RelativeColumn(2f);   // value
                                });

                                void AddRow(string label, string value)
                                {
                                    table.Cell().Border(0.5f).Padding(3).Text(label).SemiBold();
                                    table.Cell().Border(0.5f).Padding(3).Text(value ?? string.Empty);
                                }

                                AddRow("Order Number", Utility.GetVal(row, "Order_Number"));
                                AddRow("Customer Name", Utility.GetVal(row, "Customer_Name"));
                                AddRow("Order Date", Utility.GetVal(row, "Order_DT"));
                                AddRow("Design", Utility.GetVal(row, "Design"));
                                AddRow("Quantity", Utility.GetVal(row, "Quantity"));
                                AddRow("Karat", Utility.GetVal(row, "Karat"));
                                AddRow("Design Type", Utility.GetVal(row, "Design_Type"));
                                AddRow("Gold Colour", Utility.GetVal(row, "Gold_Colour"));
                                AddRow("Size", Utility.GetVal(row, "Size"));
                                AddRow("Stone Name", Utility.GetVal(row, "Stone_Name"));
                                AddRow("Diamond Quality", Utility.GetVal(row, "Diamond_Quality"));
                                AddRow("Certificate Name", Utility.GetVal(row, "Cretificate_Name"));
                                AddRow("Colour Stone Name", Utility.GetVal(row, "Colour_Stone_Name"));
                            });

                            top.RelativeItem(2).Border(1).Height(220).AlignMiddle().AlignCenter().Element(e =>
                            {
                                if (cadImageBytes != null)
                                    e.Image(cadImageBytes).FitArea();
                                else
                                    e.Text("No CAD Image").FontColor(Colors.Grey.Medium);
                            });
                        });

                        // ---- Committed Date / Priority / weights grid (full width, 4 cols) ----
                        main.Item().Border(1).Table(table =>
                        {
                            table.ColumnsDefinition(c =>
                            {
                                c.RelativeColumn(1.3f);
                                c.RelativeColumn(1.7f);
                                c.RelativeColumn(1.3f);
                                c.RelativeColumn(1.7f);
                            });

                            void AddRow(string l1, string v1, string l2, string v2, bool highlightV2IfHigh = false)
                            {
                                table.Cell().Border(0.5f).Padding(3).Text(l1).SemiBold();
                                table.Cell().Border(0.5f).Padding(3).Text(v1 ?? string.Empty);
                                table.Cell().Border(0.5f).Padding(3).Text(l2).SemiBold();
                                table.Cell().Border(0.5f).Padding(3).Text(t =>
                                {
                                    if (highlightV2IfHigh && (v2 ?? "").Equals("High", StringComparison.OrdinalIgnoreCase))
                                        t.Span(v2).FontColor(Colors.Red.Medium);
                                    else
                                        t.Span(v2 ?? string.Empty);
                                });
                            }

                            AddRow("Committed Date", Utility.GetVal(row, "Committed_DT"), "Priority", Utility.GetVal(row, "Priority"), highlightV2IfHigh: true);
                            AddRow("Designer Net Weight", Utility.GetVal(row, "Designer_Net_Weight"), "Designer GR Weight", Utility.GetVal(row, "Designer_GR_Weight"));
                            AddRow("No. Of Diamonds", Utility.GetVal(row, "Designer_NoOf_Diamonds"), "Designer Diamond Weight", Utility.GetVal(row, "Designer_Diamond_Weight"));
                            AddRow("CLR PCS", Utility.GetVal(row, "Designer_CLR_PCS"), "CLR Weight", Utility.GetVal(row, "Designer_CLR_Weight"));
                            AddRow("OTH CLR PCS", Utility.GetVal(row, "Designer_OTHCLR_PCS"), "OTH CLR Weight", Utility.GetVal(row, "Designer_OTHCLR_Weight"));
                        });

                        main.Item().Height(10); // spacer

                        // ---- Specification block ----
                        main.Item().Border(1).Column(spec =>
                        {
                            spec.Item().Padding(3).Text("Specification:").Bold().Underline();

                            if (specLines.Count == 0)
                            {
                                spec.Item().Padding(3).Text(" ");
                            }
                            else
                            {
                                foreach (var line in specLines)
                                    spec.Item().BorderTop(0.5f).Padding(3).Text(line);
                            }
                        });
                    });
                });
            });

            return document.GeneratePdf();
        }

        // ---------------------------------------------------------------------
        // 3. Send the email with the PDF + the CAD image as two attachments
        // ---------------------------------------------------------------------
        public async Task SendOrderEmailAsync(DataSet ds, string toEmail)
        {
            var row = ds.Tables[0].Rows[0];
            var orderNumber = Utility.GetVal(row, "Order_Number");
            var customerName = Utility.GetVal(row, "Customer_Name");
            var cadUrl = Utility.GetVal(row, "CAD_Image_URL");

            var pdfBytes = await GenerateOrderPdfAsync(ds);
            var cadImageBytes = await DownloadCadImageAsync(cadUrl);

            var message = new MimeMessage();
            message.From.Add(MailboxAddress.Parse(_appSetting.FromEmail));
            message.To.Add(MailboxAddress.Parse(toEmail));
            message.Subject = $"Order Details - {orderNumber}";
            //File.WriteAllBytes(@"C:\Users\dharm\source\repos\test.pdf", pdfBytes);
            var builder = new BodyBuilder
            {
                HtmlBody = $@"<p>Hi,</p>
                          <p>Please find attached the order details and CAD image for Order No. <b>{orderNumber}</b>.</p>
                          <p>Regards,<br/>Team</p>"
            };

            builder.Attachments.Add($"Order_{orderNumber}.pdf", pdfBytes, new MimeKit.ContentType("application", "pdf"));

            if (cadImageBytes != null)
            {
                var ext = GetImageExtension(cadUrl);
                builder.Attachments.Add($"CAD_{orderNumber}.{ext}", cadImageBytes, new MimeKit.ContentType("image", ext));
            }

            message.Body = builder.ToMessageBody();

            using var client = new SmtpClient();
            await client.ConnectAsync(_appSetting.Host, _appSetting.Port, SecureSocketOptions.StartTls);
            await client.AuthenticateAsync(_appSetting.Username, _appSetting.Password);
            await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }
    }

}
