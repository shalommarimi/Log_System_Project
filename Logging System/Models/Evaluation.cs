using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Logging_System.Models
{
    public class Evaluation
    {
        //The information




        [Display(Name = "Mentor's Name:")]
        [Required(ErrorMessage = "Ignore,Unless incorrect")]
        public string MentorName { get; set; }



        [Display(Name = "Company Name:")]
        public string CompanyName { get; set; }
        [Required(ErrorMessage = "Ignore,Unless incorrect")]




        [Display(Name = "Learner's Name:")]
        public string LearnerName { get; set; }




        [Display(Name = "Month of Evaluation")]
        [Required(ErrorMessage = "Ignore,Unless incorrect")]
        public string Months { get; set; }





        [Required(ErrorMessage = "Ignore Unless incorrect")]
        [Display(Name = "Trait 1:")]
        public string Trait01 { get; set; }



        [Required(ErrorMessage = "Select appropriate ratings")]
        [Display(Name = "Ratings:")]
        public string Rating1 { get; set; }




        [Required(ErrorMessage = "Ignore Unless incorrect")]
        [Display(Name = "Trait 2:")]
        public string Trait02 { get; set; }



        [Required(ErrorMessage = "Select appropriate ratings")]
        [Display(Name = "Ratings:")]
        public string Rating2 { get; set; }



        [Required(ErrorMessage = "Ignore Unless incorrect")]
        [Display(Name = "Trait 3:")]
        public string Trait03 { get; set; }



        [Required(ErrorMessage = "Select appropriate ratings")]
        [Display(Name = "Ratings:")]
        public string Rating3 { get; set; }



        [Required(ErrorMessage = "Ignore Unless incorrect")]
        [Display(Name = "Trait 4:")]
        public string Trait04 { get; set; }



        [Required(ErrorMessage = "Select appropriate ratings")]
        [Display(Name = "Ratings:")]
        public string Rating4 { get; set; }


        [Required(ErrorMessage = "Ignore Unless incorrect")]
        [Display(Name = "Trait 5:")]
        public string Trait05 { get; set; }



        [Required(ErrorMessage = "Select appropriate ratings")]
        [Display(Name = "Ratings:")]
        public string Rating5 { get; set; }

        [Required(ErrorMessage = "Select appropriate ratings")]
        [Display(Name = "FINAL JUDGEMRNT:")]
        public string final { get; set; }




        [Display(Name = "2. Please supply us with comments that further describe the environment at your workplace provider.")]
        public string Comments { get; set; }


        [Required]
        [Display(Name = "Learner's Signature:")]
        public string LearnerSignature { get; set; }

        [Display(Name = "Signature FontStyle")]
        public string fontStyle { get; set; }

        [DataType(DataType.Date)]
        //[Required]
        [Display(Name = "Date Learner Signed:")]
        [DisplayFormat(DataFormatString = "{0:DD-MM-YYYY}")]
        public DateTime? DateLearnerSigned { get; set; }


        //Allow preview
        [Display(Name = "Would you like to preview your Monthly Evaluation Form? (Tick if YES)")]
        public string Preview { get; set; }





        public string CreateEvaluation(Evaluation _evaluation)
        {


            string MEF = "Monthly Evaluation Form";
            Document document = new Document();
            document.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());


            DateTime Created = DateTime.Now;

            //Checking and Creating folder with name date
            string folderfilter;
            string day;
            string month;
            string months;
            string yaer;


            day = Created.Day.ToString();
            month = Created.ToString("MMMM");
            months = Created.ToString("MM");
            yaer = Created.Year.ToString();

            folderfilter = months + "-" + yaer;


            string path = HttpContext.Current.Server.MapPath("~/Monthly Evaluation Forms/" + folderfilter + "/");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }



            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(path + _evaluation.LearnerName + " " + MEF + ".pdf", FileMode.Create));



            document.Open();
            string paths = HttpContext.Current.Server.MapPath("~/Images/TalkIT.png");
            iTextSharp.text.Image PNG = iTextSharp.text.Image.GetInstance(paths);
            //iTextSharp.text.Image PNG = iTextSharp.text.Image.GetInstance("C:\\Users\\SMarimi\\Desktop\\Learners-Logging-System\\Learners--Logging-System\\Logging System\\Images\\TalkIT.png");
            PNG.Alignment = iTextSharp.text.Image.ALIGN_RIGHT;

            PNG.ScalePercent(46f);




            Font arial = FontFactory.GetFont("Arial", 12, BaseColor.BLACK);
            arial.SetStyle(Font.BOLD);

            Font arials = FontFactory.GetFont("Arial", 14, BaseColor.BLACK);
            arial.SetStyle(Font.BOLD);




            Paragraph info = new Paragraph();
            Paragraph infos = new Paragraph();
            Paragraph infoss = new Paragraph();
            Paragraph infosss = new Paragraph();
            Paragraph small = new Paragraph();
            Paragraph smallb = new Paragraph();
            Paragraph inforhead = new Paragraph();
            Paragraph head = new Paragraph();
            Paragraph link = new Paragraph();
            Paragraph sig1 = new Paragraph();
            Paragraph Datesig1 = new Paragraph();

            Paragraph sig2 = new Paragraph();
            Paragraph Datesig2 = new Paragraph();


            inforhead.SpacingBefore = 12;
            head.SpacingAfter = 14;
            // small.SpacingBefore = 10;

            iTextSharp.text.Font heads = iTextSharp.text.FontFactory.GetFont("Calibri(body)", 12, iTextSharp.text.Font.BOLD);
            heads.SetStyle(Font.UNDERLINE);



            //Sig2
            iTextSharp.text.Font sig12 = iTextSharp.text.FontFactory.GetFont("Brush Script Std", 14, iTextSharp.text.Font.UNDERLINE);
            sig2.Font = sig12;



            head.Font = heads;

            iTextSharp.text.Font contentFont = iTextSharp.text.FontFactory.GetFont("Arial", 13, iTextSharp.text.Font.NORMAL);
            info.Font = contentFont;





            iTextSharp.text.Font SignatureDate = iTextSharp.text.FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.UNDERLINE);
            Datesig1.Font = SignatureDate;



            iTextSharp.text.Font smallfont = iTextSharp.text.FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.ITALIC);
            small.Font = smallfont;

            iTextSharp.text.Font links = iTextSharp.text.FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.ITALIC, iTextSharp.text.BaseColor.BLUE);
            link.Font = links;



            iTextSharp.text.Font smallbold = iTextSharp.text.FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL);
            smallbold.SetStyle(Font.BOLD);
            smallb.Font = smallbold;

            iTextSharp.text.Font infohea = iTextSharp.text.FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.NORMAL);
            inforhead.Font = infohea;




            //For name
            iTextSharp.text.Font contentTop = iTextSharp.text.FontFactory.GetFont("Arial", 15, iTextSharp.text.Font.BOLD);
            // contentTop.SetStyle(Font.UNDERLINE);

            info.Font = contentFont;
            infos.Font = contentTop;

            string line = "           ";
            infos.SetLeading(0.0f, 2.0f);
            //string email1 = "Thembekile.Madlala@torque-it.com";
            //string email2 = "Violet.llale.Madlala@torque-it.com";
            info.Add(line + line + line + line + line + line + line + line + "MONTHLY EVALUATIONS  " + "\r\n");



            head.Add("WORKPLACE MONTHLY EVALAUTION FORM - LEARNER                                                                                                                                     " + "\r\n");

            small.Add("(Learners to complete this evaluation feedback form on a monthly basis; this will be put forward as part of your Portfolio of Evidence)Please fax it monthly to: 086 632 9687/ Violet.llale.Madlala@torque-it.com  copy to Project Manager ");

            inforhead.Add("Using the ratings below, please indicate how the workplace provider/mentor performed in relation to all the criteria, and then give an overall rating." + "\r\n");
            info.Add(line + "\r\n");
            infoss.Add(line + line + line + line + line + line + "\r\n");
            infos.Add("Mentor's Name: " + _evaluation.MentorName + line + line + line + line + line + "\r\n");
            info.Add(line + "\r\n");
            infoss.Add(line + line + line + line + line + line + line + line + line + "\r\n");

            infos.Add("Company Name: " + _evaluation.CompanyName + line + line + line + line + line + line + line + line + "\r\n");
            infos.Add("Learner's Name: " + _evaluation.LearnerName + line + line + line + line + line + line + line + "\r\n");
            infos.Add("Month of Evaluation: " + _evaluation.Months + line + line + line + line + line + line + line + line + line + "\r\n");
            infosss.Add(line + line + line + line + line + line + "\r\n");

            PdfPTable tabless = new PdfPTable(1);

            PdfPCell Cellss = new PdfPCell(new Phrase("Ratings:     " + "\r\n" + "                    Excellent - exceptional perfomance" + "\r\n" + "                    Average - good perfomance; proficient" + "\r\n" + "                    Below Average - inadequate perfomance" + "\r\n" + "                    Not Application - perfomance was not observed  ", new Font(arial)));

            tabless.WidthPercentage = 50;
            Cellss.HorizontalAlignment = 0;
            tabless.HorizontalAlignment = Element.ALIGN_LEFT;
            tabless.SpacingAfter = 40;
            tabless.SpacingBefore = 13;
            // tabless.WidthPercentage = 100;

            tabless.AddCell(Cellss);



            document.Add(info);
            document.Add(PNG);
            document.Add(head);
            document.Add(small);
            document.Add(link);
            document.Add(inforhead);
            document.Add(infoss);
            document.Add(infos);
            document.Add(infosss);
            document.Add(tabless);
            document.Add(smallb);




            PdfPTable table = new PdfPTable(5);
            table.SpacingBefore = 14;
            table.SpacingAfter = 13;
            table.WidthPercentage = 100;


            //String 
            string rateAS1 = "";
            string rateAS2 = "";
            string rateAS3 = "";
            string rateAS4 = "";
            string rateAS5 = "";

            string rateMS1 = "";
            string rateMS2 = "";
            string rateMS3 = "";
            string rateMS4 = "";
            string rateMS5 = "";

            string rateBS1 = "";
            string rateBS2 = "";
            string rateBS3 = "";
            string rateBS4 = "";
            string rateBS5 = "";

            string rateNA1 = "";
            string rateNA2 = "";
            string rateNA3 = "";
            string rateNA4 = "";
            string rateNA5 = "";

            string finalAS = "";
            string finalMS = "";
            string finalBS = "";
            string finalNA = "";
            string text = "                                                                                                     FINAL JUDGEMENT";

            if (_evaluation.Rating1 == "Above standard")
            {
                rateAS1 = "Excellent";
            }
            else if (_evaluation.Rating1 == "Meets standard")
            {
                rateMS1 = "Average";
            }
            else if (_evaluation.Rating1 == "Below standard")
            {
                rateBS1 = "Below Average";
            }
            else if (_evaluation.Rating1 == "N/A")
            {
                rateNA1 = "Not Applicable";
            }


            if (_evaluation.Rating2 == "Above standard")
            {
                rateAS2 = "Excellent";
            }
            else if (_evaluation.Rating2 == "Meets standard")
            {
                rateMS2 = "Average";
            }
            else if (_evaluation.Rating2 == "Below standard")
            {
                rateBS2 = "Below Average";
            }
            else if (_evaluation.Rating2 == "N/A")
            {
                rateNA2 = "Not Applicable";
            }


            if (_evaluation.Rating3 == "Above standard")
            {
                rateAS3 = "Excellent";
            }
            else if (_evaluation.Rating3 == "Meets standard")
            {
                rateMS3 = "Average";
            }
            else if (_evaluation.Rating3 == "Below standard")
            {
                rateBS3 = "Below Average";
            }
            else if (_evaluation.Rating3 == "N/A")
            {
                rateNA3 = "Not Applicable";
            }

            if (_evaluation.Rating4 == "Above standard")
            {
                rateAS4 = "Excellent";
            }
            else if (_evaluation.Rating4 == "Meets standard")
            {
                rateMS4 = "Average";
            }
            else if (_evaluation.Rating4 == "Below standard")
            {
                rateBS4 = "Below Average";
            }
            else if (_evaluation.Rating4 == "N/A")
            {
                rateNA4 = "Not Applicable";
            }


            if (_evaluation.Rating5 == "Above standard")
            {
                rateAS5 = "Excellent";
            }
            else if (_evaluation.Rating5 == "Meets standard")
            {
                rateMS5 = "Average";
            }
            else if (_evaluation.Rating5 == "Below standard")
            {
                rateBS5 = "Below Average";
            }
            else if (_evaluation.Rating5 == "N/A")
            {
                rateNA5 = "Not Applicable";
            }

            if (_evaluation.final == "Above standard")
            {
                finalAS = "Excellent";
            }
            else if (_evaluation.final == "Meets standard")
            {
                finalMS = "Average";
            }
            else if (_evaluation.final == "Below standard")
            {
                finalBS = "Below Average";
            }
            else if (_evaluation.final == "N/A")
            {
                finalNA = "Not Applicable";
            }


            float[] widths = new float[] { 65f, 11f, 11f, 11f, 11f };
            table.SetWidths(widths);


            PdfPCell Cell = new PdfPCell(new Phrase("1. Extended Application Traits", new Font(arial)));
            PdfPCell Cell1 = new PdfPCell(new Phrase("Above standard", new Font(arial)));
            PdfPCell Cell2 = new PdfPCell(new Phrase("Meets standard", new Font(arial)));
            PdfPCell Cell3 = new PdfPCell(new Phrase("Below standard", new Font(arial)));
            PdfPCell Cell4 = new PdfPCell(new Phrase("N/A", new Font(arial)));
            Cell.SetLeading(1.0f, 2.0f);
            Cell1.SetLeading(1.0f, 2.0f);
            Cell2.SetLeading(1.0f, 2.0f);
            Cell3.SetLeading(1.0f, 2.0f);
            Cell4.SetLeading(1.0f, 2.0f);



            Cell.HorizontalAlignment = 1;

            //Does not really have an effect
            Cell1.Rowspan = 1;
            Cell2.Rowspan = 1;
            Cell3.Rowspan = 1;
            Cell4.Rowspan = 1;

            table.AddCell(Cell).BackgroundColor = BaseColor.LIGHT_GRAY;
            table.AddCell(Cell1).BackgroundColor = BaseColor.LIGHT_GRAY;
            table.AddCell(Cell2).BackgroundColor = BaseColor.LIGHT_GRAY;
            table.AddCell(Cell3).BackgroundColor = BaseColor.LIGHT_GRAY;
            table.AddCell(Cell4).BackgroundColor = BaseColor.LIGHT_GRAY;




            //1st Row
            table.AddCell(_evaluation.Trait01);
            table.AddCell(rateAS1);
            table.AddCell(rateMS1);
            table.AddCell(rateBS1);
            table.AddCell(rateNA1);



            //2nd Row

            table.AddCell(_evaluation.Trait02);
            table.AddCell(rateAS2);
            table.AddCell(rateMS2);
            table.AddCell(rateBS2);
            table.AddCell(rateNA2);



            //3rd Row
            table.AddCell(_evaluation.Trait03);
            table.AddCell(rateAS3);
            table.AddCell(rateMS3);
            table.AddCell(rateBS3);
            table.AddCell(rateNA3);



            //4th Row

            table.AddCell(_evaluation.Trait04);
            table.AddCell(rateAS4);
            table.AddCell(rateMS4);
            table.AddCell(rateBS4);
            table.AddCell(rateNA4);



            //5th Row

            table.AddCell(_evaluation.Trait05);
            table.AddCell(rateAS5);
            table.AddCell(rateMS5);
            table.AddCell(rateBS5);
            table.AddCell(rateNA5);


            //6th Row

            table.AddCell(text);
            table.AddCell(finalAS);
            table.AddCell(finalMS);
            table.AddCell(finalBS);
            table.AddCell(finalNA);


            document.Add(table);


            Paragraph content = new Paragraph();
            content.Add("2. Please supply us with comments that further describe the environment at your workplace provider.");
            document.Add(content);

            PdfPTable tables = new PdfPTable(1);

            float[] widthss = new float[] { 200f };
            tables.SetWidths(widthss);

            PdfPCell Cells = new PdfPCell(new Phrase("", new Font(arial)));
            // Cells.Colspan = 2;
            Cells.Rowspan = 2;

            Cells.HorizontalAlignment = 1;
            tables.SpacingAfter = 9;
            tables.SpacingBefore = 13;
            tables.WidthPercentage = 100;

            tables.AddCell(Cells);
            if (String.IsNullOrEmpty(_evaluation.Comments))
            {
                _evaluation.Comments = "\r\n" + "\r\n" + "__________________________________________________________________________________________________________________" + "\r\n" + "\r\n" + "\r\n" + "__________________________________________________________________________________________________________________" + "\r\n" + "\r\n" + "\r\n" + "__________________________________________________________________________________________________________________" + "\r\n" + "\r\n" + "\r\n" + "__________________________________________________________________________________________________________________" + "\r\n" + "\r\n" + "\r\n" + "\r\n";
            }

            // string mentorName = "M.Huna";
            string date;
            DateTime Current = DateTime.Now;
            date = Current.DayOfYear.ToString();





            Chunk glue = new Chunk(new VerticalPositionMark());
            Paragraph p = new Paragraph();


            p.SetLeading(0.0f, 3.0f);
            p.SetLeading(0.0f, 3.0f);





            if (_evaluation.fontStyle == "Informal Roman")
            {

                Phrase f1 = new Phrase();

              
                //string font1 = Path.Combine("Fonts", "INFROMAN.TTF");
             //   string fontas = Path.GetDirectoryName("~/Fonts/INFROMAN.TTF");
                string fontas = System.Web.HttpContext.Current.Server.MapPath("~/Fonts/INFROMAN.TTF");

                BaseFont baseFont1 = BaseFont.CreateFont(fontas, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
              //  BaseFont baseFont1 = BaseFont.CreateFont("Fonts/INFROMAN.TTF", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                f1.Add(new Chunk(_evaluation.LearnerSignature, new Font(FontFactory.GetFont(fontas, BaseFont.IDENTITY_H, BaseFont.EMBEDDED, 16))));

                p.Add("Leaner's Signature: ");
                p.Add(f1);
                p.Add("  Date: " + _evaluation.DateLearnerSigned.Value.ToShortDateString());


                //Date Mentor Signed

                DateTime dt = DateTime.Now;
                string dates = dt.ToString("yyyy/mm/dd");
                //For Sig Monday - Mentor
                Phrase s1 = new Phrase();
                //string font = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "VLADIMIR.ttf");
                //string font = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "VLADIMIR.ttf");
                string font = System.Web.HttpContext.Current.Server.MapPath("~/Fonts/VLADIMIR.TTF");
                BaseFont baseFont = BaseFont.CreateFont(font, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                s1.Add(new Chunk("M.Huna", new Font(FontFactory.GetFont(font, BaseFont.IDENTITY_H, BaseFont.EMBEDDED, 16))));
                //table.AddCell(s1);

                p.Add(new Chunk(glue));
                p.Add("Mentor's Signature: ");
                p.Add(s1);
                //    p.Add(s1);
                p.Add("  Date: " + dates);
                tables.AddCell(_evaluation.Comments);

                document.Add(tables);
                document.Add(p);


            }
            else if (_evaluation.fontStyle == "Bradley Hand ITC")
            {
                Phrase f12 = new Phrase();
              
                string font1 = System.Web.HttpContext.Current.Server.MapPath("~/Fonts/BRADHITC.TTF");
            //    string font1 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "BRADHITC.TTF");
                BaseFont baseFont1 = BaseFont.CreateFont(font1, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                f12.Add(new Chunk(_evaluation.LearnerSignature, new Font(FontFactory.GetFont(font1, BaseFont.IDENTITY_H, BaseFont.EMBEDDED, 16))));

                p.Add("Leaner's Signature: ");
                p.Add(f12);
                p.Add("  Date: " + _evaluation.DateLearnerSigned.Value.ToShortDateString());


                //Date Mentor Signed

                DateTime dt = DateTime.Now;
                string dates = dt.ToString("yyyy/mm/dd");
                //For Sig Monday - Mentor
                Phrase s1 = new Phrase();
                //string font = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "VLADIMIR.ttf");
                string font = System.Web.HttpContext.Current.Server.MapPath("~/Fonts/VLADIMIR.TTF");
            //    string font = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "VLADIMIR.ttf");
                BaseFont baseFont = BaseFont.CreateFont(font, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                s1.Add(new Chunk("M.Huna", new Font(FontFactory.GetFont(font, BaseFont.IDENTITY_H, BaseFont.EMBEDDED, 16))));
                //table.AddCell(s1);

                p.Add(new Chunk(glue));
                p.Add("Mentor's Signature: ");
                p.Add(s1);
                //    p.Add(s1);
                p.Add("  Date: " + dates);
                tables.AddCell(_evaluation.Comments);

                document.Add(tables);
                document.Add(p);


            }
            else if (_evaluation.fontStyle == "Blackadder ITC")
            {
                Phrase f13 = new Phrase();
                //string font = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "VLADIMIR.ttf");
                string font1 = System.Web.HttpContext.Current.Server.MapPath("~/Fonts/ITCBLKAD.TTF");
             //   string font1 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ITCBLKAD.TTF");
                BaseFont baseFont1 = BaseFont.CreateFont(font1, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                f13.Add(new Chunk(_evaluation.LearnerSignature, new Font(FontFactory.GetFont(font1, BaseFont.IDENTITY_H, BaseFont.EMBEDDED, 16))));

                p.Add("Leaner's Signature: ");
                p.Add(f13);
                p.Add("  Date: " + _evaluation.DateLearnerSigned.Value.ToShortDateString());


                //Date Mentor Signed

                DateTime dt = DateTime.Now;
                string dates = dt.ToString("yyyy/mm/dd");
                //For Sig Monday - Mentor
                Phrase s1 = new Phrase();
                //string font = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "VLADIMIR.ttf");
               // string font = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "VLADIMIR.ttf");
                string font = System.Web.HttpContext.Current.Server.MapPath("~/Fonts/VLADIMIR.TTF");
                BaseFont baseFont = BaseFont.CreateFont(font, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                s1.Add(new Chunk("M.Huna", new Font(FontFactory.GetFont(font, BaseFont.IDENTITY_H, BaseFont.EMBEDDED, 16))));
                //table.AddCell(s1);

                p.Add(new Chunk(glue));
                p.Add("Mentor's Signature: ");
                p.Add(s1);
                //    p.Add(s1);
                p.Add("  Date: " + dates);
                tables.AddCell(_evaluation.Comments);

                document.Add(tables);
                document.Add(p);


            }
            else if (_evaluation.fontStyle == "Brush Script MT Italic")
            {
                Phrase f14 = new Phrase();
                //string font = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "VLADIMIR.ttf");
              //  string font1 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "BRUSHSCI.TTF");
                string font1 = System.Web.HttpContext.Current.Server.MapPath("~/Fonts/BRUSHSCI.TTF");
                BaseFont baseFont1 = BaseFont.CreateFont(font1, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                f14.Add(new Chunk(_evaluation.LearnerSignature, new Font(FontFactory.GetFont(font1, BaseFont.IDENTITY_H, BaseFont.EMBEDDED, 16))));

                p.Add("Leaner's Signature: ");
                p.Add(f14);
                p.Add("  Date: " + _evaluation.DateLearnerSigned.Value.ToShortDateString());


                //Date Mentor Signed

                DateTime dt = DateTime.Now;
                string dates = dt.ToString("yyyy/mm/dd");
                //For Sig Monday - Mentor
                Phrase s1 = new Phrase();
                //string font = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "VLADIMIR.ttf");
               // string font = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "VLADIMIR.ttf");
                string font = System.Web.HttpContext.Current.Server.MapPath("~/Fonts/VLADIMIR.TTF");
                BaseFont baseFont = BaseFont.CreateFont(font, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                s1.Add(new Chunk("M.Huna", new Font(FontFactory.GetFont(font, BaseFont.IDENTITY_H, BaseFont.EMBEDDED, 16))));
                //table.AddCell(s1);

                p.Add(new Chunk(glue));
                p.Add("Mentor's Signature: ");
                p.Add(s1);
                //    p.Add(s1);
                p.Add("  Date: " + dates);
                tables.AddCell(_evaluation.Comments);

                document.Add(tables);
                document.Add(p);


            }
            else if (_evaluation.fontStyle == "Edwardian Script ITC")
            {
                Phrase f1 = new Phrase();
                //string font = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "VLADIMIR.ttf");
               // string font1 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ITCEDSCR.TTF");
                string font1 = System.Web.HttpContext.Current.Server.MapPath("~/Fonts/ITCEDSCR.TTF");
                BaseFont baseFont1 = BaseFont.CreateFont(font1, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                f1.Add(new Chunk(_evaluation.LearnerSignature, new Font(FontFactory.GetFont(font1, BaseFont.IDENTITY_H, BaseFont.EMBEDDED, 16))));

                p.Add("Leaner's Signature: ");
                p.Add(f1);
                p.Add("  Date: " + _evaluation.DateLearnerSigned.Value.ToShortDateString());


                //Date Mentor Signed

                DateTime dt = DateTime.Now;
                string dates = dt.ToString("yyyy/mm/dd");
                //For Sig Monday - Mentor
                Phrase s1 = new Phrase();
                //string font = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "VLADIMIR.ttf");
               // string font = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "VLADIMIR.ttf");
                string font = System.Web.HttpContext.Current.Server.MapPath("~/Fonts/VLADIMIR.TTF");
                BaseFont baseFont = BaseFont.CreateFont(font, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                s1.Add(new Chunk("M.Huna", new Font(FontFactory.GetFont(font, BaseFont.IDENTITY_H, BaseFont.EMBEDDED, 16))));
                //table.AddCell(s1);

                p.Add(new Chunk(glue));
                p.Add("Mentor's Signature: ");
                p.Add(s1);
                //    p.Add(s1);
                p.Add("  Date: " + dates);
                tables.AddCell(_evaluation.Comments);

                document.Add(tables);
                document.Add(p);


            }
            else if (_evaluation.fontStyle == "Mistral")
            {
                Phrase f1 = new Phrase();
                //string font = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "VLADIMIR.ttf");
               // string font1 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "MISTRAL.TTF");
                string font1 = System.Web.HttpContext.Current.Server.MapPath("~/Fonts/MISTRAL.TTF");
                BaseFont baseFont1 = BaseFont.CreateFont(font1, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                f1.Add(new Chunk(_evaluation.LearnerSignature, new Font(FontFactory.GetFont(font1, BaseFont.IDENTITY_H, BaseFont.EMBEDDED, 16))));

                p.Add("Leaner's Signature: ");
                p.Add(f1);
                p.Add("  Date: " + _evaluation.DateLearnerSigned.Value.ToShortDateString());


                //Date Mentor Signed

                DateTime dt = DateTime.Now;
                string dates = dt.ToString("yyyy/mm/dd");
                //For Sig Monday - Mentor
                Phrase s1 = new Phrase();
                //string font = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "VLADIMIR.ttf");
                string font = System.Web.HttpContext.Current.Server.MapPath("~/Fonts/VLADIMIR.TTF");
                BaseFont baseFont = BaseFont.CreateFont(font, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                s1.Add(new Chunk("M.Huna", new Font(FontFactory.GetFont(font, BaseFont.IDENTITY_H, BaseFont.EMBEDDED, 16))));
                //table.AddCell(s1);

                p.Add(new Chunk(glue));
                p.Add("Mentor's Signature: ");
                p.Add(s1);
                //    p.Add(s1);
                p.Add("  Date: " + dates);
                tables.AddCell(_evaluation.Comments);

                document.Add(tables);
                document.Add(p);


            }
            else if (_evaluation.fontStyle == "Place Script MT")
            {
                Phrase f1 = new Phrase();
                //string font = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "VLADIMIR.ttf");
             //   string font1 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "PALSCRI.TTF");
                string font1 = System.Web.HttpContext.Current.Server.MapPath("~/Fonts/PALSCRI.TTF");
                BaseFont baseFont1 = BaseFont.CreateFont(font1, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                f1.Add(new Chunk(_evaluation.LearnerSignature, new Font(FontFactory.GetFont(font1, BaseFont.IDENTITY_H, BaseFont.EMBEDDED, 16))));

                p.Add("Leaner's Signature: ");
                p.Add(f1);
                p.Add("  Date: " + _evaluation.DateLearnerSigned.Value.ToShortDateString());


                //Date Mentor Signed

                DateTime dt = DateTime.Now;
                string dates = dt.ToString("yyyy/mm/dd");
                //For Sig Monday - Mentor
                Phrase s1 = new Phrase();
                //string font = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "VLADIMIR.ttf");
                string font = System.Web.HttpContext.Current.Server.MapPath("~/Fonts/VLADIMIR.TTF");
                BaseFont baseFont = BaseFont.CreateFont(font, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                s1.Add(new Chunk("M.Huna", new Font(FontFactory.GetFont(font, BaseFont.IDENTITY_H, BaseFont.EMBEDDED, 16))));
                //table.AddCell(s1);

                p.Add(new Chunk(glue));
                p.Add("Mentor's Signature: ");
                p.Add(s1);
                //    p.Add(s1);
                p.Add("  Date: " + dates);
                tables.AddCell(_evaluation.Comments);

                document.Add(tables);
                document.Add(p);


            }
            else if (_evaluation.fontStyle == "Chiller")
            {
                Phrase f1 = new Phrase();
                //string font = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "VLADIMIR.ttf");
               // string font1 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "CHILLER.TTF");
                string font1 = System.Web.HttpContext.Current.Server.MapPath("~/Fonts/CHILLER.TTF");
                BaseFont baseFont1 = BaseFont.CreateFont(font1, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                f1.Add(new Chunk(_evaluation.LearnerSignature, new Font(FontFactory.GetFont(font1, BaseFont.IDENTITY_H, BaseFont.EMBEDDED, 16))));

                p.Add("Leaner's Signature: ");
                p.Add(f1);
                p.Add("  Date: " + _evaluation.DateLearnerSigned.Value.ToShortDateString());


                //Date Mentor Signed

                DateTime dt = DateTime.Now;
                string dates = dt.ToString("yyyy/mm/dd");
                //For Sig Monday - Mentor
                Phrase s1 = new Phrase();
                //string font = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "VLADIMIR.ttf");
               // string font = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "VLADIMIR.ttf");
                string font = System.Web.HttpContext.Current.Server.MapPath("~/Fonts/VLADIMIR.TTF");
                BaseFont baseFont = BaseFont.CreateFont(font, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                s1.Add(new Chunk("M.Huna", new Font(FontFactory.GetFont(font, BaseFont.IDENTITY_H, BaseFont.EMBEDDED, 16))));
                //table.AddCell(s1);

                p.Add(new Chunk(glue));
                p.Add("Mentor's Signature: ");
                p.Add(s1);
                //    p.Add(s1);
                p.Add("  Date: " + dates);
                tables.AddCell(_evaluation.Comments);

                document.Add(tables);
                document.Add(p);


            }
            else if (_evaluation.fontStyle == "Curlz MT")
            {
                Phrase f1 = new Phrase();
                //string font = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "VLADIMIR.ttf");
               // string font1 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "CURLZ___.TTF");
                string font1 = System.Web.HttpContext.Current.Server.MapPath("~/Fonts/CURLZ___.TTF");
                BaseFont baseFont1 = BaseFont.CreateFont(font1, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                f1.Add(new Chunk(_evaluation.LearnerSignature, new Font(FontFactory.GetFont(font1, BaseFont.IDENTITY_H, BaseFont.EMBEDDED, 16))));

                p.Add("Leaner's Signature: ");
                p.Add(f1);
                p.Add("  Date: " + _evaluation.DateLearnerSigned.Value.ToShortDateString());


                //Date Mentor Signed

                DateTime dt = DateTime.Now;
                string dates = dt.ToString("yyyy/mm/dd");
                //For Sig Monday - Mentor
                Phrase s1 = new Phrase();
                //string font = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "VLADIMIR.ttf");
               // string font = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "VLADIMIR.ttf");
                string font = System.Web.HttpContext.Current.Server.MapPath("~/Fonts/VLADIMIR.TTF");
                BaseFont baseFont = BaseFont.CreateFont(font, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                s1.Add(new Chunk("M.Huna", new Font(FontFactory.GetFont(font, BaseFont.IDENTITY_H, BaseFont.EMBEDDED, 16))));
                //table.AddCell(s1);

                p.Add(new Chunk(glue));
                p.Add("Mentor's Signature: ");
                p.Add(s1);
                p.Add("  Date: " + dates);
                tables.AddCell(_evaluation.Comments);

                document.Add(tables);
                document.Add(p);


            }
            else if (_evaluation.fontStyle == "French Script MT")
            {
                Phrase f1 = new Phrase();
                //string font = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "VLADIMIR.ttf");
                //string font1 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "FRSCRIPT.TTF");
                string font1 = System.Web.HttpContext.Current.Server.MapPath("~/Fonts/FRSCRIPT.TTF");
                BaseFont baseFont1 = BaseFont.CreateFont(font1, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                f1.Add(new Chunk(_evaluation.LearnerSignature, new Font(FontFactory.GetFont(font1, BaseFont.IDENTITY_H, BaseFont.EMBEDDED, 16))));

                p.Add("Leaner's Signature: ");
                p.Add(f1);
                p.Add("  Date: " + _evaluation.DateLearnerSigned.Value.ToShortDateString());


                //Date Mentor Signed

                DateTime dt = DateTime.Now;
                string dates = dt.ToString("yyyy/mm/dd");
                //For Sig Monday - Mentor
                Phrase s1 = new Phrase();
                //string font = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "VLADIMIR.ttf");
              //  string font = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "VLADIMIR.ttf");
                string font = System.Web.HttpContext.Current.Server.MapPath("~/Fonts/VLADIMIR.TTF");
                BaseFont baseFont = BaseFont.CreateFont(font, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                s1.Add(new Chunk("M.Huna", new Font(FontFactory.GetFont(font, BaseFont.IDENTITY_H, BaseFont.EMBEDDED, 16))));
                //table.AddCell(s1);

                p.Add(new Chunk(glue));
                p.Add("Mentor's Signature: ");
                p.Add(s1);
                //    p.Add(s1);
                p.Add("  Date: " + dates);
                tables.AddCell(_evaluation.Comments);

                document.Add(tables);
                document.Add(p);


            }
            else if (_evaluation.fontStyle == "Rage Italic")
            {
                Phrase f1 = new Phrase();
                //string font = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "VLADIMIR.ttf");
          //      string font1 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "RAGE.TTF");
                string font1 = System.Web.HttpContext.Current.Server.MapPath("~/Fonts/RAGE.TTF");
                BaseFont baseFont1 = BaseFont.CreateFont(font1, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                f1.Add(new Chunk(_evaluation.LearnerSignature, new Font(FontFactory.GetFont(font1, BaseFont.IDENTITY_H, BaseFont.EMBEDDED, 16))));

                p.Add("Leaner's Signature: ");
                p.Add(f1);
                p.Add("  Date: " + _evaluation.DateLearnerSigned.Value.ToShortDateString());


                //Date Mentor Signed

                DateTime dt = DateTime.Now;
                string dates = dt.ToString("yyyy/mm/dd");
                //For Sig Monday - Mentor
                Phrase s1 = new Phrase();
                //string font = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "VLADIMIR.ttf");
               // string font = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "VLADIMIR.ttf");
                string font = System.Web.HttpContext.Current.Server.MapPath("~/Fonts/VLADIMIR.TTF");
                BaseFont baseFont = BaseFont.CreateFont(font, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                s1.Add(new Chunk("M.Huna", new Font(FontFactory.GetFont(font, BaseFont.IDENTITY_H, BaseFont.EMBEDDED, 16))));
                //table.AddCell(s1);

                p.Add(new Chunk(glue));
                p.Add("Mentor's Signature: ");
                p.Add(s1);
                //    p.Add(s1);
                p.Add("  Date: " + dates);
                tables.AddCell(_evaluation.Comments);

                document.Add(tables);
                document.Add(p);


            }
            else if (_evaluation.fontStyle == "Arial")
            {
                Phrase f1 = new Phrase();
                //string font = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "VLADIMIR.ttf");
              //  string font1 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIAL.TTF");
                string font1 = System.Web.HttpContext.Current.Server.MapPath("~/Fonts/ARIAL.TTF");
                BaseFont baseFont1 = BaseFont.CreateFont(font1, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                f1.Add(new Chunk(_evaluation.LearnerSignature, new Font(FontFactory.GetFont(font1, BaseFont.IDENTITY_H, BaseFont.EMBEDDED, 16))));

                p.Add("Leaner's Signature: ");
                p.Add(f1);
                p.Add("  Date: " + _evaluation.DateLearnerSigned.Value.ToShortDateString());


                //Date Mentor Signed

                DateTime dt = DateTime.Now;
                string dates = dt.ToString("yyyy/mm/dd");
                //For Sig Monday - Mentor
                Phrase s1 = new Phrase();
                //string font = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "VLADIMIR.ttf");
               // string font = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "VLADIMIR.ttf");
                string font = System.Web.HttpContext.Current.Server.MapPath("~/Fonts/VLADIMIR.TTF");
                BaseFont baseFont = BaseFont.CreateFont(font, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                s1.Add(new Chunk("M.Huna", new Font(FontFactory.GetFont(font, BaseFont.IDENTITY_H, BaseFont.EMBEDDED, 16))));
                //table.AddCell(s1);

                p.Add(new Chunk(glue));
                p.Add("Mentor's Signature: ");
                p.Add(s1);
                //    p.Add(s1);
                p.Add("  Date: " + dates);
                tables.AddCell(_evaluation.Comments);

                document.Add(tables);
                document.Add(p);


            }
            else
            {
                Phrase f1 = new Phrase();
                //string font = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "VLADIMIR.ttf");
               // string font1 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIAL.TTF");
                string font1 = System.Web.HttpContext.Current.Server.MapPath("~/Fonts/ARIAL.TTF");
                BaseFont baseFont1 = BaseFont.CreateFont(font1, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                f1.Add(new Chunk(_evaluation.LearnerSignature, new Font(FontFactory.GetFont(font1, BaseFont.IDENTITY_H, BaseFont.EMBEDDED, 16))));

                p.Add("Leaner's Signature: ");
                p.Add(f1);
                p.Add("  Date: " + _evaluation.DateLearnerSigned.Value.ToShortDateString());


                //Date Mentor Signed

                DateTime dt = DateTime.Now;
                string dates = dt.ToString("yyyy/mm/dd");
                //For Sig Monday - Mentor
                Phrase s1 = new Phrase();
                //string font = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "VLADIMIR.ttf");
               // string font = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "VLADIMIR.ttf");
                string font = System.Web.HttpContext.Current.Server.MapPath("~/Fonts/VLADIMIR.TTF");
                BaseFont baseFont = BaseFont.CreateFont(font, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                s1.Add(new Chunk("M.Huna", new Font(FontFactory.GetFont(font, BaseFont.IDENTITY_H, BaseFont.EMBEDDED, 16))));
                //table.AddCell(s1);

                p.Add(new Chunk(glue));
                p.Add("Mentor's Signature: ");
                p.Add(s1);
                //    p.Add(s1);
                p.Add("  Date: " + dates);
                tables.AddCell(_evaluation.Comments);

                document.Add(tables);
                document.Add(p);


            }

            document.Close();

            if (_evaluation.Preview == "Yes")
            {
                string pathss = HttpContext.Current.Server.MapPath("~/Monthly Evaluation Forms/" + folderfilter + "/");
                System.Diagnostics.Process.Start(pathss + _evaluation.LearnerName + " " + MEF + ".pdf");
            }


            try
            {


                return "Successfully Submitted Monthly Evaluation Form " + _evaluation.LearnerName;
            }
            catch (Exception es)
            {
                throw es;
            }
        }




    }
}