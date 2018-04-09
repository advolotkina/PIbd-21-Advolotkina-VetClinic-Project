using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetClinicModel;
using VetClinicService.BindingModels;
using VetClinicService.Interfaces;
using VetClinicService.ViewModels;

namespace VetClinicService.ImplementationsDB
{
    public class RequestServiceDB: IRequestService
    {
        private VetClinicDbContext context;

        public RequestServiceDB(VetClinicDbContext context)
        {
            this.context = context;
        }

        public List<RequestViewModel> GetList()
        {
            return context.Requests
                .Select(rec => new RequestViewModel
                {
                    Id = rec.Id,
                    AdminId = rec.AdminId,
                    Address = rec.Address,
                    Format = rec.Format,
                    DateCreate = rec.DateCreate.ToString(),
                    RequestDrugs = context.RequestDrugs
                            .Where(recPR => recPR.RequestId == rec.Id)
                            .Select(
                                recPC => new RequestDrugViewModel
                                {
                                    Id = recPC.Id,
                                    RequestId = recPC.RequestId,
                                    DrugId = recPC.DrugId,
                                    DrugName = recPC.Drug.DrugName,
                                    Count = recPC.Count
                                }
                            )
                            .ToList()
                })
                .ToList();
        }

        public RequestViewModel GetElement(int id)
        {
            Request request = context.Requests.FirstOrDefault(rec => rec.Id == id);
            if (request != null)
            {
                return new RequestViewModel
                {
                    Id = request.Id,
                    AdminId = request.AdminId,
                    Address = request.Address,
                    Format = request.Format,
                    DateCreate = request.DateCreate.ToString(),
                    RequestDrugs = context.RequestDrugs
                            .Where(recPC => recPC.RequestId == request.Id)
                            .Select(recPC => new RequestDrugViewModel
                            {
                                Id = recPC.Id,
                                RequestId = recPC.RequestId,
                                DrugId = recPC.DrugId,
                                DrugName = recPC.Drug.DrugName,
                                Count = recPC.Count
                            }
                            )
                            .ToList()
                };
            }
            throw new Exception("Заявка не найдена");
        }

        public void AddElement(RequestBindingModel model)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    Request request = context.Requests.FirstOrDefault(rec => rec.DateCreate == model.DateCreate);
                    if (request != null)
                        throw new Exception("Такой запрос уже существует");

                    request = new Request
                    {
                        AdminId = model.AdminId,
                        DateCreate = model.DateCreate
                    };
                    context.Requests.Add(request);
                    context.SaveChanges();

                    var groupDrugs = model.RequestDrugs
                        .GroupBy(rec => rec.DrugId)
                        .Select(rec => new
                        {
                            DrugId = rec.Key,
                            Count = rec.Sum(r => r.Count)
                        }
                        );

                    foreach (var groupDrug in groupDrugs)
                    {
                        context.RequestDrugs.Add(
                            new RequestDrug
                            {
                                RequestId = request.Id,
                                DrugId = groupDrug.DrugId,
                                Count = groupDrug.Count
                            }
                        );
                        context.SaveChanges();
                    }
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public void SaveRequestToXlsFile(RequestViewModel model, string fileName)
        {
            var excel = new Application();
            try
            {
                if (File.Exists(fileName))
                {
                    excel.Workbooks.Open(fileName, Type.Missing, Type.Missing, Type.Missing,
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                        Type.Missing);
                }
                else
                {
                    excel.SheetsInNewWorkbook = 1;
                    excel.Workbooks.Add(Type.Missing);
                    excel.Workbooks[1].SaveAs(fileName, XlFileFormat.xlExcel8, Type.Missing,
                        Type.Missing, false, false, XlSaveAsAccessMode.xlNoChange, Type.Missing,
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                }

                Sheets excelsheets = excel.Workbooks[1].Worksheets;

                var excelworksheet = (Worksheet)excelsheets.get_Item(1);

                excelworksheet.Cells.Clear();

                excelworksheet.PageSetup.Orientation = XlPageOrientation.xlLandscape;
                excelworksheet.PageSetup.CenterHorizontally = true;
                excelworksheet.PageSetup.CenterVertically = true;

                Range excelcells = excelworksheet.get_Range("A1", "B1");
                excelcells.Merge(Type.Missing);

                excelcells.Font.Bold = true;
                excelcells.Value2 = "Заявка на медикаменты";
                excelcells.RowHeight = 25;
                excelcells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                excelcells.VerticalAlignment = XlVAlign.xlVAlignCenter;
                excelcells.Font.Name = "Times New Roman";
                excelcells.Font.Size = 14;

                excelcells = excelworksheet.get_Range("A2", "B2");
                excelcells.Merge(Type.Missing);

                excelcells.Font.Bold = true;
                excelcells.Value2 = "на " + model.DateCreate;
                excelcells.RowHeight = 25;
                excelcells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                excelcells.VerticalAlignment = XlVAlign.xlVAlignCenter;
                excelcells.Font.Name = "Times New Roman";
                excelcells.Font.Size = 14;

                excelcells = excelworksheet.get_Range("B1", "B1");
                excelcells = excelcells.get_Offset(3, -1);
                excelcells.ColumnWidth = 15;
                excelcells.Value2 = "Медикамент";
                excelcells.RowHeight = 25;
                excelcells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                excelcells.VerticalAlignment = XlVAlign.xlVAlignCenter;
                excelcells.Font.Name = "Times New Roman";
                excelcells.Font.Size = 12;

                excelcells = excelcells.get_Offset(0, 1);
                excelcells.ColumnWidth = 15;
                excelcells.Value2 = "Количество";
                excelcells.RowHeight = 25;
                excelcells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                excelcells.VerticalAlignment = XlVAlign.xlVAlignCenter;
                excelcells.Font.Name = "Times New Roman";
                excelcells.Font.Size = 12;
                

                //var dict = model.RequestDrugs;
                //if (dict != null)
                //{
                //    excelcells = excelworksheet.get_Range("A4", "A4");
                //}
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                excel.Quit();
            }
        }

        public void SaveRequestToDocFile(RequestViewModel model, string filename)
        {
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }

            var winword = new Microsoft.Office.Interop.Word.Application();
            try
            {
                object missing = System.Reflection.Missing.Value;

                Microsoft.Office.Interop.Word.Document document = winword.Documents.Add(ref missing, ref missing, ref missing, ref missing);

                var paragraph = document.Paragraphs.Add(missing);
                var range = paragraph.Range;

                var font = range.Font;
                font.Size = 16;
                font.Name = "Times New Roman";
                font.Bold = 1;

                range.Text = "Заявка на медикаменты на " + model.DateCreate;

                range.InsertParagraphAfter();

                var requestDrugs = model.RequestDrugs;
                var paragraphTable = document.Paragraphs.Add(Type.Missing);
                var rangeTable = paragraphTable.Range;
                var table = document.Tables.Add(rangeTable, requestDrugs.Count + 1, 4, ref missing, ref missing);

                font = table.Range.Font;
                font.Size = 14;
                font.Name = "Times New Roman";

                var paragraphTableFormat = table.Range.ParagraphFormat;
                paragraphTableFormat.LineSpacingRule = Microsoft.Office.Interop.Word.WdLineSpacing.wdLineSpaceSingle;
                paragraphTableFormat.SpaceAfter = 0;
                paragraphTableFormat.SpaceBefore = 0;

                table.Cell(1, 1).Range.Text = "Продукт";
                table.Cell(1, 2).Range.Text = "Количество";
                table.Cell(1, 3).Range.Text = "Цена";
                table.Cell(1, 4).Range.Text = "Цена за продукт";

                double totalSum = 0;

                for (int i = 0; i < requestDrugs.Count; ++i)
                {
                    double productSum = requestDrugs[i].Count * requestDrugs[i].ProductPrice;
                    totalSum += productSum;

                    table.Cell(i + 2, 1).Range.Text = requestDrugs[i].ProductName;
                    table.Cell(i + 2, 2).Range.Text = requestDrugs[i].Count.ToString();
                    table.Cell(i + 2, 3).Range.Text = requestDrugs[i].ProductPrice.ToString();
                    table.Cell(i + 2, 4).Range.Text = productSum.ToString();
                }

                table.Borders.InsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleInset;
                table.Borders.OutsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;

                paragraph = document.Paragraphs.Add(missing);
                range = paragraph.Range;

                range.Text = "Итого: " + totalSum.ToString();

                font = range.Font;
                font.Size = 16;
                font.Name = "Times New Roman";
                font.Bold = 1;

                var paragraphFormat = range.ParagraphFormat;
                paragraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;
                paragraphFormat.LineSpacingRule = Microsoft.Office.Interop.Word.WdLineSpacing.wdLineSpaceSingle;
                paragraphFormat.SpaceAfter = 10;
                paragraphFormat.SpaceBefore = 0;

                paragraphFormat = range.ParagraphFormat;
                paragraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphRight;
                paragraphFormat.LineSpacingRule = Microsoft.Office.Interop.Word.WdLineSpacing.wdLineSpaceSingle;
                paragraphFormat.SpaceAfter = 10;
                paragraphFormat.SpaceBefore = 10;

                range.InsertParagraphAfter();

                object fileFormat = Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatXMLDocument;
                document.SaveAs(filename, ref fileFormat, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing);
                document.Close(ref missing, ref missing, ref missing);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                winword.Quit();
            }
        }
    }
}
