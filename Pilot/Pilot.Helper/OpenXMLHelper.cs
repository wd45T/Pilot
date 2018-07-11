using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Pilot.Common.Model.TableOpenXML;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using A = DocumentFormat.OpenXml.Drawing;
using Pic = DocumentFormat.OpenXml.Drawing.Pictures;
using Wp = DocumentFormat.OpenXml.Drawing.Wordprocessing;


namespace PIK.BOP.IDP.Site.Helpers
{
    public class OpenXMLHelper
    {
        public Paragraph GenerateParagraph(string content, ParagraphProperties paragraphProperties = null)
        {
            Paragraph paragraph = new Paragraph();
            if (paragraphProperties == null)
                paragraphProperties = new ParagraphProperties();

            //ParagraphProperties paragraphProperties = new ParagraphProperties();
            //ContextualSpacing contextualSpacing = new ContextualSpacing() { Val = false };
            //Justification justification1 = new Justification() { Val = JustificationValues.Center };
            //ParagraphMarkRunProperties paragraphMarkRunProperties = new ParagraphMarkRunProperties();

            //paragraphProperties.Append(contextualSpacing);
            //paragraphProperties.Append(justification1);
            //paragraphProperties.Append(paragraphMarkRunProperties);

            Run run = new Run();

            RunProperties runProperties = new RunProperties();
            RightToLeftText rightToLeftText = new RightToLeftText() { Val = false };

            runProperties.Append(rightToLeftText);
            Text text = new Text();
            text.Text = content;

            run.Append(runProperties);
            run.Append(text);

            paragraph.Append(paragraphProperties);
            paragraph.Append(run);
            return paragraph;
        }

        public void AddImageToBody(WordprocessingDocument wordDoc, 
            string relationshipId, Int64Value cx, Int64Value cy, 
            string pictureName = null)
        {
            var element =
                 new Drawing(
                     new Wp.Inline(
                         new Wp.Extent() { Cx = cx, Cy = cy },
                         new Wp.EffectExtent()
                         {
                             LeftEdge = 0L,
                             TopEdge = 0L,
                             RightEdge = 0L,
                             BottomEdge = 0L
                         },
                         new Wp.DocProperties()
                         {
                             Id = 1U,
                             Name = pictureName
                         },
                         new Wp.NonVisualGraphicFrameDrawingProperties(
                             new A.GraphicFrameLocks() { NoChangeAspect = true }),
                         new A.Graphic(
                             new A.GraphicData(
                                 new Pic.Picture(
                                     new Pic.NonVisualPictureProperties(
                                         new Pic.NonVisualDrawingProperties()
                                         {
                                             Id = 0U,
                                             Name = $"{pictureName}.jpg"
                                         },
                                         new Pic.NonVisualPictureDrawingProperties()),
                                     new Pic.BlipFill(
                                         new A.Blip(
                                             new A.BlipExtensionList(
                                                 new A.BlipExtension()
                                                 {
                                                     Uri =
                                                        "{28A0092B-C50C-407E-A947-70E740481C1C}"
                                                 })
                                         )
                                         {
                                             Embed = relationshipId,
                                             CompressionState =
                                             A.BlipCompressionValues.Print
                                         },
                                         new A.Stretch(
                                             new A.FillRectangle())),
                                     new Pic.ShapeProperties(
                                         new A.Transform2D(
                                             new A.Offset() { X = 0L, Y = 0L },
                                             new A.Extents() { Cx = cx, Cy = cy }),
                                         new A.PresetGeometry(
                                             new A.AdjustValueList()
                                         )
                                         { Preset = A.ShapeTypeValues.Rectangle }))
                             )
                             { Uri = "http://schemas.openxmlformats.org/drawingml/2006/picture" })
                     )
                     {
                         DistanceFromTop = 0U,
                         DistanceFromBottom = 0U,
                         DistanceFromLeft = 114300U,
                         DistanceFromRight = 114300U,
                         EditId = "50D07946"
                     });
            wordDoc.MainDocumentPart.Document.Body.AppendChild(
                new Paragraph(new Run(element))
                {
                    ParagraphProperties = new ParagraphProperties { Justification = new Justification { Val = JustificationValues.Center } }
                });
        }

        /// <summary>
        /// Секция для разрыва страници А4 вертикально
        /// </summary>
        /// <returns></returns>
        public SectionProperties GenerateSectionPageBreak()
        {
            SectionProperties sectionProperties = new SectionProperties() { RsidR = "00761B6D" };
            PageSize pageSize = new PageSize() { Width = 11906U, Height = 16838U };
            PageMargin pageMargin = new PageMargin() { Top = 1134, Right = 850U, Bottom = 1134, Left = 1701U, Header = 708U, Footer = 708U, Gutter = 0U };
            Columns columns = new Columns() { Space = "708" };
            DocGrid docGrid = new DocGrid() { LinePitch = 360 };

            sectionProperties.Append(pageSize);
            sectionProperties.Append(pageMargin);
            sectionProperties.Append(columns);
            sectionProperties.Append(docGrid);
            return sectionProperties;
        }

        public Table CreateTable(TableData tableData)
        {
            Table table = new Table();
            TableProperties tblProp = new TableProperties(
                new TableProperties( new Justification { Val = JustificationValues.Center }),
                new TableBorders(
                    new TopBorder()
                    {
                        Val =
                        new EnumValue<BorderValues>(BorderValues.Single),
                        Size = 10
                    },
                    new BottomBorder()
                    {
                        Val =
                        new EnumValue<BorderValues>(BorderValues.Single),
                        Size = 10
                    },
                    new LeftBorder()
                    {
                        Val =
                        new EnumValue<BorderValues>(BorderValues.Single),
                        Size = 10
                    },
                    new RightBorder()
                    {
                        Val =
                        new EnumValue<BorderValues>(BorderValues.Single),
                        Size = 10
                    },
                    new InsideHorizontalBorder()
                    {
                        Val =
                        new EnumValue<BorderValues>(BorderValues.Single),
                        Size = 10
                    },
                    new InsideVerticalBorder()
                    {
                        Val =
                        new EnumValue<BorderValues>(BorderValues.Single),
                        Size = 10
                    }
                )
            );

            table.AppendChild(tblProp);

            var tableHeader = new TableRow();
            foreach (var cell in tableData.HeaderTable)
            {
                var tableCell = new TableCell();
                var paragraph = new Paragraph(
                    new Run(
                        new Text(cell))
                    {
                        RunProperties = new RunProperties()
                        {
                            Bold = new Bold()
                        }
                    },
                    new ParagraphProperties(
                        new Justification()
                        {
                            Val = JustificationValues.Center
                        })
                    );
                tableCell.Append(paragraph);
                tableHeader.Append(tableCell);
            }
            table.Append(tableHeader);

            foreach (var row in tableData.Rows)
            {
                var tableRow = new TableRow();
                foreach (var cell in row)
                {
                    var tableCell = new TableCell();
                    var paragraph = new Paragraph(new Run(new Text(cell)));
                    tableCell.Append(paragraph);
                    tableRow.Append(tableCell);
                }
                table.Append(tableRow);
            }

            return table;
        }

        public void AddTable(MainDocumentPart doc, int table_number, TableData tableData)
        {
            Table table = doc.Document.Body.Elements<Table>().ElementAt(table_number - 1);

            table.Append(new TableRow());
            
            foreach (var row in tableData.Rows)
            {
                var tableRow = new TableRow();
                foreach (var cell in row)
                {
                    var tableCell = new TableCell();
                    var paragraph = new Paragraph(new Run(new Text(cell)));
                    tableCell.Append(paragraph);
                    tableRow.Append(tableCell);
                }
                table.Append(tableRow);
            }

            table.RemoveChild(table.Elements<TableRow>().ElementAt(1));
        }
    }
}
