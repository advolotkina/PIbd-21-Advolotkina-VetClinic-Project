using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetClinicService.BindingModels;
using VetClinicService.Interfaces;
using VetClinicService.ViewModels;

namespace VetClinicService.ImplementationsDB
{
    public class ReportServiceDB: IReportService
    {
        private VetClinicDbContext context;

        public ReportServiceDB(VetClinicDbContext context)
        {
            this.context = context;
        }

        public List<ServiceViewModel> GetServicesList(ReportBindingModel model)
        {

            return context.Services
                .Select(
                rec => new ServiceViewModel
                {
                     ServiceName = rec.ServiceName,
                     Price = rec.Price,
                     ServiceDrugs = context.ServiceDrugs
                            .Where(recPR => recPR.Id == rec.Id)
                            .Select(
                                recPC => new ServiceDrugViewModel
                                {
                                    Id = recPC.Id,
                                    ServiceId = recPC.ServiceId,
                                    DrugId = recPC.DrugId,
                                    DrugName = recPC.Drug.DrugName,
                                    DrugPrice = recPC.Drug.Price,
                                    Count = recPC.Count
                                }
                            )
                            .ToList()
                }
                )
                .ToList();
        }

        public List<RequestViewModel> GetRequestsList(ReportBindingModel model)
        {
            return context.Requests
                .Where(rec => rec.DateCreate >= model.DateFrom && rec.DateCreate <= model.DateTo)
                .Select(rec => new RequestViewModel
                {
                    Id = rec.Id,
                    DateCreate = rec.DateCreate.ToString(),
                    Price = rec.Price,
                    RequestDrugs = context.RequestDrugs
                            .Where(recPR => recPR.RequestId == rec.Id)
                            .Select(
                                recPC => new RequestDrugViewModel
                                {
                                    Id = recPC.Id,
                                    RequestId = recPC.RequestId,
                                    DrugId = recPC.DrugId,
                                    DrugName = recPC.Drug.DrugName,
                                    Price = recPC.Drug.Price,
                                    Count = recPC.Count
                                }
                            )
                            .ToList()
                })
                .ToList();
        }

        public void SaveToFile(ReportBindingModel model)
        {
            //из ресрусов получаем шрифт для кирилицы
            if (!File.Exists("pt-sans.TTF"))
            {
                File.WriteAllBytes("pt-sans.TTF", Properties.Resources.pt_sans);
            }

            //открываем файл для работы
            FileStream fs = new FileStream(model.FileName, FileMode.OpenOrCreate, FileAccess.Write);

            //создаем документ, задаем границы, связываем документ и поток
            iTextSharp.text.Document doc = new iTextSharp.text.Document();
            doc.SetMargins(0.5f, 0.5f, 0.5f, 0.5f);
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);

            doc.Open();
            BaseFont baseFont = BaseFont.CreateFont("pt-sans.TTF", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);

            //вставляем заголовок
            var phraseTitle = new Phrase("Отчеты",
                new iTextSharp.text.Font(baseFont, 16, iTextSharp.text.Font.BOLD));
            iTextSharp.text.Paragraph paragraph = new iTextSharp.text.Paragraph(phraseTitle)
            {
                Alignment = Element.ALIGN_CENTER,
                SpacingAfter = 12
            };
            doc.Add(paragraph);

            var phrasePeriod = new Phrase("c " + model.DateFrom.Value.ToShortDateString() +
                                    " по " + model.DateTo.Value.ToShortDateString(),
                                    new iTextSharp.text.Font(baseFont, 14, iTextSharp.text.Font.BOLD));
            paragraph = new iTextSharp.text.Paragraph(phrasePeriod)
            {
                Alignment = Element.ALIGN_CENTER,
                SpacingAfter = 12
            };
            doc.Add(paragraph);


            var phraseOrders = new Phrase("Отчет по услугам",
                                    new iTextSharp.text.Font(baseFont, 14, iTextSharp.text.Font.BOLD));
            paragraph = new iTextSharp.text.Paragraph(phraseOrders)
            {
                Alignment = Element.ALIGN_CENTER,
                SpacingAfter = 12
            };
            doc.Add(paragraph);

            //вставляем таблицу, задаем количество столбцов, и ширину колонок
            PdfPTable table = new PdfPTable(2)
            {
                TotalWidth = 800F
            };
            //table.SetTotalWidth(new float[] { 160, 140});

            //вставляем шапку
            PdfPCell cell = new PdfPCell();
            var fontForCellBold = new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.BOLD);
            table.AddCell(new PdfPCell(new Phrase("Название услуги", fontForCellBold))
            {
                HorizontalAlignment = Element.ALIGN_CENTER
            });
            table.AddCell(new PdfPCell(new Phrase("Цена", fontForCellBold))
            {
                HorizontalAlignment = Element.ALIGN_CENTER
            });

            //заполняем таблицу
            var list = GetServicesList(model);
            var fontForCells = new iTextSharp.text.Font(baseFont, 10);
            for (int i = 0; i < list.Count; i++)
            {
                cell = new PdfPCell(new Phrase(list[i].ServiceName, fontForCells));
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase(list[i].Price.ToString(), fontForCells));
                table.AddCell(cell);
                cell = new PdfPCell(new Phrase("Использующиеся медикаменты", fontForCells));
                table.AddCell(cell);
                var drugsUsed = list[i].ServiceDrugs;
                Console.WriteLine(drugsUsed.Count);
                foreach(var drugUsed in drugsUsed)
                {
                    cell = new PdfPCell(new Phrase(drugUsed.DrugName + " " + drugUsed.DrugPrice, fontForCells));
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase(" "));
                    table.AddCell(cell);
                }
                cell = new PdfPCell(new Phrase(" "));
                table.AddCell(cell);
            }

            //вставляем итого
            var phraseOrdersSum = new Phrase("Итого: " + list.Sum(rec => rec.Price).ToString(),
                                    new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.BOLD));
            paragraph = new iTextSharp.text.Paragraph(phraseOrdersSum)
            {
                Alignment = Element.ALIGN_CENTER,
                SpacingAfter = 12
            };
            doc.Add(paragraph);
            

            //вставляем таблицу
            doc.Add(table);

            //Отчет по заявкам
            var phraseRequests = new Phrase("Отчет по заявкам",
                                    new iTextSharp.text.Font(baseFont, 14, iTextSharp.text.Font.BOLD));
            paragraph = new iTextSharp.text.Paragraph(phraseRequests)
            {
                Alignment = Element.ALIGN_CENTER,
                SpacingAfter = 12
            };
            doc.Add(paragraph);

            //вставляем таблицу, задаем количество столбцов, и ширину колонок
            PdfPTable tableRequests = new PdfPTable(2)
            {
                TotalWidth = 800F
            };
            //table.SetTotalWidth(new float[] { 160, 140, 160 });

            //вставляем шапку
            PdfPCell cellRequest = new PdfPCell();
            tableRequests.AddCell(new PdfPCell(new Phrase("Дата", fontForCellBold))
            {
                HorizontalAlignment = Element.ALIGN_CENTER
            });
            tableRequests.AddCell(new PdfPCell(new Phrase("Цена", fontForCellBold))
            {
                HorizontalAlignment = Element.ALIGN_CENTER
            });

            //заполняем таблицу
            var listRequest = GetRequestsList(model);
            for (int i = 0; i < listRequest.Count; i++)
            {
                cellRequest = new PdfPCell(new Phrase(listRequest[i].DateCreate, fontForCells));
                tableRequests.AddCell(cellRequest);
                cellRequest = new PdfPCell(new Phrase(listRequest[i].Price.ToString(), fontForCells));
                tableRequests.AddCell(cellRequest);
                cell = new PdfPCell(new Phrase("Использующиеся медикаменты", fontForCells));
                table.AddCell(cell);
                var drugsUsed = listRequest[i].RequestDrugs;
                foreach (var drugUsed in drugsUsed)
                {
                    cell = new PdfPCell(new Phrase(drugUsed.DrugName + " " + drugUsed.Price, fontForCells));
                    table.AddCell(cell);
                    cell = new PdfPCell(new Phrase(" "));
                    table.AddCell(cell);
                }
                cell = new PdfPCell(new Phrase(" "));
                table.AddCell(cell);
            }

            //вставляем итого
            var phraseRequestsSum = new Phrase("Итого: " + listRequest.Sum(rec => rec.Price).ToString(),
                                    new Font(baseFont, 10, Font.BOLD));
            paragraph = new iTextSharp.text.Paragraph(phraseRequestsSum)
            {
                Alignment = Element.ALIGN_CENTER,
                SpacingAfter = 12
            };
            doc.Add(paragraph);

            cellRequest = new PdfPCell(new Phrase("Итого:", fontForCellBold))
            {
                HorizontalAlignment = Element.ALIGN_RIGHT,
                Colspan = 4,
                Border = 0
            };
            tableRequests.AddCell(cellRequest);
            cellRequest = new PdfPCell(new Phrase(listRequest.Sum(rec => rec.Price).ToString(), fontForCellBold))
            {
                HorizontalAlignment = Element.ALIGN_RIGHT,
                Border = 0
            };
            tableRequests.AddCell(cellRequest);
            cellRequest = new PdfPCell(new Phrase("", fontForCellBold))
            {
                Border = 0
            };
            tableRequests.AddCell(cellRequest);
            //вставляем таблицу
            doc.Add(tableRequests);

            doc.Close();
        }
    }
}
