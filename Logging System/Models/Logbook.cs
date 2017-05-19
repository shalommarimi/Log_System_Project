using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.util;
using System.Drawing.Text;


namespace Logging_System.Models
{

    public class Logbook
    {
        

        //The information


        [Required(ErrorMessage = "Please ignore unless incorrect")]

        [Display(Name = "Learner's Name:")]
        public string LearnerName { get; set; }

        [Display(Name = "Mentor's Name:")]
        [Required(ErrorMessage = "Please ignore unless incorrect")]
        public string MentorName { get; set; }

        [Display(Name = "Mentors's Tel:")]
        [Required(ErrorMessage = "Please ignore unless incorrect")]
        public string MentorTel { get; set; }

        [Required(ErrorMessage = "Select appropriate")]
        [Display(Name = "Learnership Intake:")]
        public string Learnership { get; set; }
        [Required(ErrorMessage = "Select appropriate")]
        [Display(Name = "Company Name:")]
        public string CompanyName { get; set; }


        //Day One--Monday


        [DataType(DataType.Date)]

        [Display(Name = "Monday's Date:")]
        [Required(ErrorMessage = "Please verify Monday's Date")]
        [DisplayFormat(DataFormatString = "{MMMM dd, yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Day01 { get; set; }




        [Required]
        [Display(Name = "Task Completed:")]
        public string TaskDay01 { get; set; }


        [Required(ErrorMessage = "Please ignore unless incorrect")]
        [Display(Name = "Completed(Satisfactory)?:")]
        public string CompletedSatDay01 { get; set; }


        [Required(ErrorMessage = "Please ignore unless incorrect")]
        [Display(Name = "Time Taken(Hours):")]
        public string TimeTakenDay01 { get; set; }


        //[Required]
        [Display(Name = "Problems Experienced(If Any)")]
        public string ProblemsDay01 { get; set; }
        [Display(Name = "General Comments:")]

        //[Required]
        public string CommentsDay01 { get; set; }


        //Day 2 Tuesday

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please verify Tuesdays's Date")]
        [Display(Name = "Tuesday's Date:")]
        [DisplayFormat(DataFormatString = "{0:DD-MM-YYYY}", ApplyFormatInEditMode = true)]
        public DateTime? Day02 { get; set; }

        [Required]
        [Display(Name = "Task Completed:")]
        public string TaskDay02 { get; set; }


        [Required(ErrorMessage = "Please ignore unless incorrect")]
        [Display(Name = "Completed(Satisfaction)?:")]
        public string CompletedSatDay02 { get; set; }


        [Required(ErrorMessage = "Please ignore unless incorrect")]
        [Display(Name = "Time Taken(Hours):")]
        public string TimeTakenDay02 { get; set; }


        //[Required]
        [Display(Name = "Problems Experienced(If any)")]
        public string ProblemsDay02 { get; set; }
        [Display(Name = "General Comments:")]

        //[Required]
        public string CommentsDay02 { get; set; }

        //Day 03 Wednesday

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please verify Thursday's Date")]
        [Display(Name = "Wednesday's Date:")]
        [DisplayFormat(DataFormatString = "{0:DD-MM-YYYY}", ApplyFormatInEditMode = true)]
        public DateTime? Day03 { get; set; }

        [Required]
        [Display(Name = "Task Completed:")]
        public string TaskDay03 { get; set; }


        [Required(ErrorMessage = "Please ignore unless incorrect")]
        [Display(Name = "Completed(Satisfaction)?:")]
        public string CompletedSatDay03 { get; set; }


        [Required(ErrorMessage = "Please ignore unless incorrect")]
        [Display(Name = "Time Taken(Hours):")]
        public string TimeTakenDay03 { get; set; }


        //[Required]
        [Display(Name = "Problems Experienced(If any)")]
        public string ProblemsDay03 { get; set; }
        [Display(Name = "General Comments:")]

        //[Required]
        public string CommentsDay03 { get; set; }

        //Day 4 Thursday

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please verify Fridays's Date")]
        [Display(Name = "Thursday's Date:")]
        [DisplayFormat(DataFormatString = "{0:DD-MM-YYYY}", ApplyFormatInEditMode = true)]
        public DateTime? Day04 { get; set; }

        [Required]
        [Display(Name = "Task Completed:")]
        public string TaskDay04 { get; set; }


        [Required(ErrorMessage = "Please ignore unless incorrect")]
        [Display(Name = "Completed(Satisfaction)?:")]
        public string CompletedSatDay04 { get; set; }


        [Required(ErrorMessage = "Please ignore unless incorrect")]
        [Display(Name = "Time Taken(Hours):")]
        public string TimeTakenDay04 { get; set; }


        //[Required]
        [Display(Name = "Problems Experienced(If any)")]
        public string ProblemsDay04 { get; set; }
        [Display(Name = "General Comments:")]

        //[Required]
        public string CommentsDay04 { get; set; }

        //Day 5 Friday

        [DataType(DataType.Date)]
        [Required]
        [Display(Name = "Friday's Date:")]
        [DisplayFormat(DataFormatString = "{0:DD-MM-YYYY}", ApplyFormatInEditMode = true)]
        public DateTime? Day05 { get; set; }

        [Required]
        [Display(Name = "Task Completed:")]
        public string TaskDay05 { get; set; }


        [Required(ErrorMessage = "Please ignore unless incorrect")]
        [Display(Name = "Completed(Satisfaction)?:")]
        public string CompletedSatDay05 { get; set; }


        [Required(ErrorMessage = "Please ignore unless incorrect")]
        [Display(Name = "Time Taken(Hours):")]
        public string TimeTakenDay05 { get; set; }


        //[Required]
        [Display(Name = "Problems Experienced(If any)")]
        public string ProblemsDay05 { get; set; }
        [Display(Name = "General Comments:")]

        //[Required]
        public string CommentsDay05 { get; set; }




        [Required]
        [Display(Name = "Learner's Signature:")]
        public string LearnerSignature { get; set; }

        [Display(Name = "Signature FontSyle")]
        public string fontStyle { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please ignore unless incorrect")]
        [Display(Name = "Date Learner Signed:")]
        [DisplayFormat(DataFormatString = "{0:DD-MM-YYYY}", ApplyFormatInEditMode = true)]
        public DateTime? DateLearnerSigned { get; set; }


        // Allow preview
        [Display(Name = "Would you like to preview your Logbook? (Tick if YES)")]
        public string Preview { get; set; }


       


        public string CreateLogbook(Logbook _logbook)
        {




            string Date = DateLearnerSigned.ToString();
            string WL = "Weekly Logbook";

            Document document = new Document();
            document.SetPageSize(iTextSharp.text.PageSize.A4.Rotate());



            DateTime dt = DateTime.Now;
            while (dt.DayOfWeek != DayOfWeek.Friday) dt = dt.AddDays(1);
            string Week = dt.ToString("dd-MM-yyyy");//02-02-2017


            //M path

            string path = HttpContext.Current.Server.MapPath("~/WeeklyLogbooks/" + Week + "/");



            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }



            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(path + _logbook.LearnerName + " " + WL + ".pdf", FileMode.Create));



            document.Open();



            Font arial = FontFactory.GetFont("Arial", 12, BaseColor.BLACK);
            arial.SetStyle(Font.BOLD);





            Paragraph info = new Paragraph();
            Paragraph infos = new Paragraph();
            Paragraph small = new Paragraph();
            Paragraph smallb = new Paragraph();
            Paragraph inforhead = new Paragraph();
            Paragraph head = new Paragraph();
            Paragraph feet = new Paragraph();

            inforhead.SpacingBefore = 12;
            head.SpacingAfter = 14;
            small.SpacingBefore = 10;



            iTextSharp.text.Font contentFont = iTextSharp.text.FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL);
            info.Font = contentFont;

            iTextSharp.text.Font smallfont = iTextSharp.text.FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL);
            small.Font = smallfont;

            iTextSharp.text.Font heads = iTextSharp.text.FontFactory.GetFont("Calibri(body)", 12, iTextSharp.text.Font.BOLD);
            heads.SetStyle(Font.ITALIC);

            head.Font = heads;

            iTextSharp.text.Font smallbold = iTextSharp.text.FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL);
            smallbold.SetStyle(Font.BOLD);
            smallb.Font = smallbold;

            iTextSharp.text.Font infohea = iTextSharp.text.FontFactory.GetFont("Calibri(body)", 12, iTextSharp.text.Font.BOLD);
            infohea.SetStyle(Font.ITALIC);
            inforhead.Font = infohea;


            //White
            //White
            //White
            //White
            iTextSharp.text.Font headss = iTextSharp.text.FontFactory.GetFont("Calibri(body)", 12, iTextSharp.text.BaseColor.WHITE);
            headss.SetStyle(Font.ITALIC);





            //For name
            iTextSharp.text.Font contentTop = iTextSharp.text.FontFactory.GetFont("Arial", 13, iTextSharp.text.Font.ITALIC);
            contentTop.SetStyle(Font.BOLD);
            contentTop.SetStyle(Font.UNDERLINE);

            info.Font = contentFont;
            infos.Font = contentTop;
            string line = "           ";
            //info.Add("                                                           Learner Daily Log                                       " + "\r\n");
            info.Add(line);
            info.Add(line);
            info.Add(line + line + line + line + line + line + line + line + line + line + line + line + "Learner Daily Log  " + "\r\n");
            head.Add("LEARNER DAILY ACTIVITIES LOGBOOK  " + "\r\n");
            info.Add(line + "\r\n");
            infos.Add("Learner's Name: " + _logbook.LearnerName + "\r\n");
            info.Add(line + "\r\n");
            infos.Add("Mentor's Name and Tel: " + _logbook.MentorName + ": " + _logbook.MentorTel + "\r\n");
            info.Add(line + "\r\n");
            infos.Add("Learnership Intake: " + _logbook.Learnership + "\r\n");
            info.Add(line + "\r\n");
            infos.Add("Company Name: " + _logbook.CompanyName);
            inforhead.Add("Please refer to Workplace Task Maping for a breakdown of prescribed activities." + "\r\n");
            info.Add(line + "\r\n");
            info.Add(line + "\r\n");
            small.Add("This form must be completed everyday and signed off by both the Learner and respective Mentor." + "\r\n");
            small.Add("This form is intended for generic use.");

            smallb.Add("Please return to Torque IT at the follwing Fax number every friday:086 632 9687 or Thembekile.Madlala@torque-it.com and copy.");

            infos.Add(line + "\r\n");
            document.Add(info);
            document.Add(head);
            document.Add(infos);
            document.Add(small);
            document.Add(smallb);
            document.Add(inforhead);



            PdfPTable table = new PdfPTable(8);
            table.SpacingBefore = 14;
            // table.TotalWidth = 50;
            table.WidthPercentage = 100;



            //Checking which font was selected
           //Font selectedFont;

            Font arialsignature = FontFactory.GetFont("Bradley Hand ITC", 13, BaseColor.BLACK);
            arial.SetStyle(Font.BOLD);

            Font arialsignature1 = FontFactory.GetFont("Blackadder ITC", 13, BaseColor.BLACK);
            arial.SetStyle(Font.BOLD);

            Font arialsignature2 = FontFactory.GetFont("Brush Script Std", 13, BaseColor.BLACK);
            arial.SetStyle(Font.BOLD);

            Font arialsignature3 = FontFactory.GetFont("Buxton Sketch", 13, BaseColor.BLACK);
            arial.SetStyle(Font.BOLD);

            Font arialsignature4 = FontFactory.GetFont("Informal Roman", 13, BaseColor.BLACK);
            arial.SetStyle(Font.BOLD);

            Font arialsignature5 = FontFactory.GetFont("Matura MT Script Capitals", 13, BaseColor.BLACK);
            arial.SetStyle(Font.BOLD);


            PdfPCell Cell = new PdfPCell(new Phrase("Date", new Font(arial)));
            PdfPCell Cell1 = new PdfPCell(new Phrase("Task/s Completed", new Font(arial)));
            PdfPCell Cell2 = new PdfPCell(new Phrase("Completed to satidfaction Yes/No", new Font(arial)));
            PdfPCell Cell3 = new PdfPCell(new Phrase("Time Taken in Hours", new Font(arial)));
            PdfPCell Cell4 = new PdfPCell(new Phrase("Problems Experienced(if any)", new Font(arial)));
            PdfPCell Cell5 = new PdfPCell(new Phrase("General Comments", new Font(arial)));
            PdfPCell Cell6 = new PdfPCell(new Phrase("Learner's Signature", new Font(arialsignature3)));
            PdfPCell Cell7 = new PdfPCell(new Phrase("Mentor's Signature", new Font(arial)));




            Cell.Colspan = 1;
            Cell.HorizontalAlignment = 1;
            table.AddCell(Cell).BackgroundColor = BaseColor.LIGHT_GRAY;
            table.AddCell(Cell1).BackgroundColor = BaseColor.LIGHT_GRAY;
            table.AddCell(Cell2).BackgroundColor = BaseColor.LIGHT_GRAY;
            table.AddCell(Cell3).BackgroundColor = BaseColor.LIGHT_GRAY;
            table.AddCell(Cell4).BackgroundColor = BaseColor.LIGHT_GRAY;
            table.AddCell(Cell5).BackgroundColor = BaseColor.LIGHT_GRAY;
            table.AddCell(Cell6).BackgroundColor = BaseColor.LIGHT_GRAY;
            table.AddCell(Cell7).BackgroundColor = BaseColor.LIGHT_GRAY;


            //Checking wixh font was selected by User

            if (_logbook.fontStyle == "Informal Roman")
            {
                Phrase f1 = new Phrase();
                string font1 = System.Web.HttpContext.Current.Server.MapPath("~/Fonts/INFROMAN.TTF");
                BaseFont baseFont1 = BaseFont.CreateFont(font1, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

                f1.Add(new Chunk(_logbook.LearnerSignature, new Font(FontFactory.GetFont(font1, BaseFont.IDENTITY_H, BaseFont.EMBEDDED, 16))));


                Phrase phrase = new Phrase();
                Phrase phrases = new Phrase();
                Phrase phrasess = new Phrase();
                Phrase phrasesss = new Phrase();
                Phrase phrasessss = new Phrase();

                //For Sig Monday - Mentor
                Phrase s1 = new Phrase();
                //string font = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "VLADIMIR.ttf");
              //  string font = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "VLADIMIR.ttf");
                string font = System.Web.HttpContext.Current.Server.MapPath("~/Fonts/VLADIMIR.TTF");
                BaseFont baseFont = BaseFont.CreateFont(font, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                s1.Add(new Chunk("M.Huna", new Font(FontFactory.GetFont(font, BaseFont.IDENTITY_H, BaseFont.EMBEDDED, 16))));
                //table.AddCell(s1);

                phrase.Add(new Chunk((_logbook.Day01.Value.ToShortDateString()), new Font()));
                phrase.Add(new Chunk(" Emmmm", new Font(Font.FontFamily.TIMES_ROMAN, 12, 0, BaseColor.WHITE)));
                table.AddCell(phrase);
                // table.AddCell(_logbook.Day01.Value.ToLongDateString() );
                //table.AddCell(Mondays);
                table.AddCell(_logbook.TaskDay01);
                table.AddCell(_logbook.CompletedSatDay01);
                table.AddCell(_logbook.TimeTakenDay01);
                table.AddCell(_logbook.ProblemsDay01);
                table.AddCell(_logbook.CommentsDay01);
                table.AddCell(f1);
                table.AddCell(s1);
                // table.AddCell("M.Huna");


                //2nd Row
                //table.AddCell(Tuesdays);
                phrases.Add(new Chunk((_logbook.Day02.Value.ToShortDateString()), new Font()));
                phrases.Add(new Chunk(" Emmmm", new Font(Font.FontFamily.TIMES_ROMAN, 12, 0, BaseColor.WHITE)));
                table.AddCell(phrases);
                table.AddCell(_logbook.TaskDay02);
                table.AddCell(_logbook.CompletedSatDay02);
                table.AddCell(_logbook.TimeTakenDay02);
                table.AddCell(_logbook.ProblemsDay02);
                table.AddCell(_logbook.CommentsDay02);
                table.AddCell(f1);
                table.AddCell(s1);

                //3rd Row



                //table.AddCell(Wednesdays);
                phrasess.Add(new Chunk((_logbook.Day03.Value.ToShortDateString()), new Font()));
                phrasess.Add(new Chunk(" Emmmm", new Font(Font.FontFamily.TIMES_ROMAN, 12, 0, BaseColor.WHITE)));
                table.AddCell(phrasess);
                table.AddCell(_logbook.TaskDay03);
                table.AddCell(_logbook.CompletedSatDay03);
                table.AddCell(_logbook.TimeTakenDay03);
                table.AddCell(_logbook.ProblemsDay03);
                table.AddCell(_logbook.CommentsDay03);
                table.AddCell(f1);
                table.AddCell(s1);

                //4th Row



                //table.AddCell(Thursdays);
                phrasesss.Add(new Chunk((_logbook.Day04.Value.ToShortDateString()), new Font()));
                phrasesss.Add(new Chunk(" Emmmm", new Font(Font.FontFamily.TIMES_ROMAN, 12, 0, BaseColor.WHITE)));
                table.AddCell(phrasesss);
                table.AddCell(_logbook.TaskDay04);
                table.AddCell(_logbook.CompletedSatDay04);
                table.AddCell(_logbook.TimeTakenDay04);
                table.AddCell(_logbook.ProblemsDay04);
                table.AddCell(_logbook.CommentsDay04);
                table.AddCell(f1);
                table.AddCell(s1);

                //5th Row


                //table.AddCell(Fridays);
                phrasessss.Add(new Chunk((_logbook.Day05.Value.ToShortDateString()), new Font()));
                phrasessss.Add(new Chunk(" Emmmm", new Font(Font.FontFamily.TIMES_ROMAN, 12, 0, BaseColor.WHITE)));
                table.AddCell(phrasessss);
                table.AddCell(_logbook.TaskDay05);
                table.AddCell(_logbook.CompletedSatDay05);
                table.AddCell(_logbook.TimeTakenDay05);
                table.AddCell(_logbook.ProblemsDay05);
                table.AddCell(_logbook.CommentsDay05);
                table.AddCell(f1);
                table.AddCell(s1);
            }
            else if (_logbook.fontStyle == "Bradley Hand ITC")
            {
                Phrase f2 = new Phrase();
                //string font = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "VLADIMIR.ttf");
                string font2 = System.Web.HttpContext.Current.Server.MapPath("~/Fonts/BRADHITC.TTF");
                BaseFont baseFont2 = BaseFont.CreateFont(font2, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

                f2.Add(new Chunk(_logbook.LearnerSignature, new Font(FontFactory.GetFont(font2, BaseFont.IDENTITY_H, BaseFont.EMBEDDED, 16))));


                Phrase phrase = new Phrase();
                Phrase phrases = new Phrase();
                Phrase phrasess = new Phrase();
                Phrase phrasesss = new Phrase();
                Phrase phrasessss = new Phrase();

                //For Sig Monday - Mentor
                Phrase s1 = new Phrase();
                //string font = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "VLADIMIR.ttf");
              //  string font = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "VLADIMIR.ttf");
                string font = System.Web.HttpContext.Current.Server.MapPath("~/Fonts/VLADIMIR.TTF");
                BaseFont baseFont = BaseFont.CreateFont(font, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                s1.Add(new Chunk("M.Huna", new Font(FontFactory.GetFont(font, BaseFont.IDENTITY_H, BaseFont.EMBEDDED, 16))));
                //table.AddCell(s1);

                phrase.Add(new Chunk((_logbook.Day01.Value.ToShortDateString()), new Font()));
                phrase.Add(new Chunk(" Emmmm", new Font(Font.FontFamily.TIMES_ROMAN, 12, 0, BaseColor.WHITE)));
                table.AddCell(phrase);
                // table.AddCell(_logbook.Day01.Value.ToLongDateString() );
                //table.AddCell(Mondays);
                table.AddCell(_logbook.TaskDay01);
                table.AddCell(_logbook.CompletedSatDay01);
                table.AddCell(_logbook.TimeTakenDay01);
                table.AddCell(_logbook.ProblemsDay01);
                table.AddCell(_logbook.CommentsDay01);
                table.AddCell(f2);
                table.AddCell(s1);
                // table.AddCell("M.Huna");


                //2nd Row
                //table.AddCell(Tuesdays);
                phrases.Add(new Chunk((_logbook.Day02.Value.ToShortDateString()), new Font()));
                phrases.Add(new Chunk(" Emmmm", new Font(Font.FontFamily.TIMES_ROMAN, 12, 0, BaseColor.WHITE)));
                table.AddCell(phrases);
                table.AddCell(_logbook.TaskDay02);
                table.AddCell(_logbook.CompletedSatDay02);
                table.AddCell(_logbook.TimeTakenDay02);
                table.AddCell(_logbook.ProblemsDay02);
                table.AddCell(_logbook.CommentsDay02);
                table.AddCell(f2);
                table.AddCell(s1);

                //3rd Row



                //table.AddCell(Wednesdays);
                phrasess.Add(new Chunk((_logbook.Day03.Value.ToShortDateString()), new Font()));
                phrasess.Add(new Chunk(" Emmmm", new Font(Font.FontFamily.TIMES_ROMAN, 12, 0, BaseColor.WHITE)));
                table.AddCell(phrasess);
                table.AddCell(_logbook.TaskDay03);
                table.AddCell(_logbook.CompletedSatDay03);
                table.AddCell(_logbook.TimeTakenDay03);
                table.AddCell(_logbook.ProblemsDay03);
                table.AddCell(_logbook.CommentsDay03);
                table.AddCell(f2);
                table.AddCell(s1);

                //4th Row



                //table.AddCell(Thursdays);
                phrasesss.Add(new Chunk((_logbook.Day04.Value.ToShortDateString()), new Font()));
                phrasesss.Add(new Chunk(" Emmmm", new Font(Font.FontFamily.TIMES_ROMAN, 12, 0, BaseColor.WHITE)));
                table.AddCell(phrasesss);
                table.AddCell(_logbook.TaskDay04);
                table.AddCell(_logbook.CompletedSatDay04);
                table.AddCell(_logbook.TimeTakenDay04);
                table.AddCell(_logbook.ProblemsDay04);
                table.AddCell(_logbook.CommentsDay04);
                table.AddCell(f2);
                table.AddCell(s1);

                //5th Row


                //table.AddCell(Fridays);
                phrasessss.Add(new Chunk((_logbook.Day05.Value.ToShortDateString()), new Font()));
                phrasessss.Add(new Chunk(" Emmmm", new Font(Font.FontFamily.TIMES_ROMAN, 12, 0, BaseColor.WHITE)));
                table.AddCell(phrasessss);
                table.AddCell(_logbook.TaskDay05);
                table.AddCell(_logbook.CompletedSatDay05);
                table.AddCell(_logbook.TimeTakenDay05);
                table.AddCell(_logbook.ProblemsDay05);
                table.AddCell(_logbook.CommentsDay05);
                table.AddCell(f2);
                table.AddCell(s1);
            }
            else if (_logbook.fontStyle == "Blackadder ITC")
            {
                Phrase f3 = new Phrase();
                //string font = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "VLADIMIR.ttf");
                string font3 = System.Web.HttpContext.Current.Server.MapPath("~/Fonts/ITCBLKAD.TTF");
                BaseFont baseFont3 = BaseFont.CreateFont(font3, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

                f3.Add(new Chunk(_logbook.LearnerSignature, new Font(FontFactory.GetFont(font3, BaseFont.IDENTITY_H, BaseFont.EMBEDDED, 16))));

                Phrase phrase = new Phrase();
                Phrase phrases = new Phrase();
                Phrase phrasess = new Phrase();
                Phrase phrasesss = new Phrase();
                Phrase phrasessss = new Phrase();

                //For Sig Monday - Mentor
                Phrase s1 = new Phrase();
                //string font = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "VLADIMIR.ttf");
             //  string font = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "VLADIMIR.ttf");
                string font = System.Web.HttpContext.Current.Server.MapPath("~/Fonts/VLADIMIR.TTF");
                BaseFont baseFont = BaseFont.CreateFont(font, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                s1.Add(new Chunk("M.Huna", new Font(FontFactory.GetFont(font, BaseFont.IDENTITY_H, BaseFont.EMBEDDED, 16))));
                //table.AddCell(s1);

                phrase.Add(new Chunk((_logbook.Day01.Value.ToShortDateString()), new Font()));
                phrase.Add(new Chunk(" Emmmm", new Font(Font.FontFamily.TIMES_ROMAN, 12, 0, BaseColor.WHITE)));
                table.AddCell(phrase);
                // table.AddCell(_logbook.Day01.Value.ToLongDateString() );
                //table.AddCell(Mondays);
                table.AddCell(_logbook.TaskDay01);
                table.AddCell(_logbook.CompletedSatDay01);
                table.AddCell(_logbook.TimeTakenDay01);
                table.AddCell(_logbook.ProblemsDay01);
                table.AddCell(_logbook.CommentsDay01);
                table.AddCell(f3);
                table.AddCell(s1);
                // table.AddCell("M.Huna");


                //2nd Row
                //table.AddCell(Tuesdays);
                phrases.Add(new Chunk((_logbook.Day02.Value.ToShortDateString()), new Font()));
                phrases.Add(new Chunk(" Emmmm", new Font(Font.FontFamily.TIMES_ROMAN, 12, 0, BaseColor.WHITE)));
                table.AddCell(phrases);
                table.AddCell(_logbook.TaskDay02);
                table.AddCell(_logbook.CompletedSatDay02);
                table.AddCell(_logbook.TimeTakenDay02);
                table.AddCell(_logbook.ProblemsDay02);
                table.AddCell(_logbook.CommentsDay02);
                table.AddCell(f3);
                table.AddCell(s1);

                //3rd Row



                //table.AddCell(Wednesdays);
                phrasess.Add(new Chunk((_logbook.Day03.Value.ToShortDateString()), new Font()));
                phrasess.Add(new Chunk(" Emmmm", new Font(Font.FontFamily.TIMES_ROMAN, 12, 0, BaseColor.WHITE)));
                table.AddCell(phrasess);
                table.AddCell(_logbook.TaskDay03);
                table.AddCell(_logbook.CompletedSatDay03);
                table.AddCell(_logbook.TimeTakenDay03);
                table.AddCell(_logbook.ProblemsDay03);
                table.AddCell(_logbook.CommentsDay03);
                table.AddCell(f3);
                table.AddCell(s1);

                //4th Row



                //table.AddCell(Thursdays);
                phrasesss.Add(new Chunk((_logbook.Day04.Value.ToShortDateString()), new Font()));
                phrasesss.Add(new Chunk(" Emmmm", new Font(Font.FontFamily.TIMES_ROMAN, 12, 0, BaseColor.WHITE)));
                table.AddCell(phrasesss);
                table.AddCell(_logbook.TaskDay04);
                table.AddCell(_logbook.CompletedSatDay04);
                table.AddCell(_logbook.TimeTakenDay04);
                table.AddCell(_logbook.ProblemsDay04);
                table.AddCell(_logbook.CommentsDay04);
                table.AddCell(f3);
                table.AddCell(s1);

                //5th Row


                //table.AddCell(Fridays);
                phrasessss.Add(new Chunk((_logbook.Day05.Value.ToShortDateString()), new Font()));
                phrasessss.Add(new Chunk(" Emmmm", new Font(Font.FontFamily.TIMES_ROMAN, 12, 0, BaseColor.WHITE)));
                table.AddCell(phrasessss);
                table.AddCell(_logbook.TaskDay05);
                table.AddCell(_logbook.CompletedSatDay05);
                table.AddCell(_logbook.TimeTakenDay05);
                table.AddCell(_logbook.ProblemsDay05);
                table.AddCell(_logbook.CommentsDay05);
                table.AddCell(f3);
                table.AddCell(s1);
            }
            else if (_logbook.fontStyle == "Brush Script MT Italic")
            {
                Phrase f4 = new Phrase();
                //string font = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "VLADIMIR.ttf");
                string font4 = System.Web.HttpContext.Current.Server.MapPath("~/Fonts/BRUSHSCI.TTF");
                BaseFont baseFont4 = BaseFont.CreateFont(font4, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

                f4.Add(new Chunk(_logbook.LearnerSignature, new Font(FontFactory.GetFont(font4, BaseFont.IDENTITY_H, BaseFont.EMBEDDED, 16))));


                Phrase phrase = new Phrase();
                Phrase phrases = new Phrase();
                Phrase phrasess = new Phrase();
                Phrase phrasesss = new Phrase();
                Phrase phrasessss = new Phrase();

                //For Sig Monday - Mentor
                Phrase s1 = new Phrase();
                //string font = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "VLADIMIR.ttf");
             //   string font = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "VLADIMIR.ttf");
                string font = System.Web.HttpContext.Current.Server.MapPath("~/Fonts/VLADIMIR.TTF");
                BaseFont baseFont = BaseFont.CreateFont(font, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                s1.Add(new Chunk("M.Huna", new Font(FontFactory.GetFont(font, BaseFont.IDENTITY_H, BaseFont.EMBEDDED, 16))));
                //table.AddCell(s1);

                phrase.Add(new Chunk((_logbook.Day01.Value.ToShortDateString()), new Font()));
                phrase.Add(new Chunk(" Emmmm", new Font(Font.FontFamily.TIMES_ROMAN, 12, 0, BaseColor.WHITE)));
                table.AddCell(phrase);
                // table.AddCell(_logbook.Day01.Value.ToLongDateString() );
                //table.AddCell(Mondays);
                table.AddCell(_logbook.TaskDay01);
                table.AddCell(_logbook.CompletedSatDay01);
                table.AddCell(_logbook.TimeTakenDay01);
                table.AddCell(_logbook.ProblemsDay01);
                table.AddCell(_logbook.CommentsDay01);
                table.AddCell(f4);
                table.AddCell(s1);
                // table.AddCell("M.Huna");


                //2nd Row
                //table.AddCell(Tuesdays);
                phrases.Add(new Chunk((_logbook.Day02.Value.ToShortDateString()), new Font()));
                phrases.Add(new Chunk(" Emmmm", new Font(Font.FontFamily.TIMES_ROMAN, 12, 0, BaseColor.WHITE)));
                table.AddCell(phrases);
                table.AddCell(_logbook.TaskDay02);
                table.AddCell(_logbook.CompletedSatDay02);
                table.AddCell(_logbook.TimeTakenDay02);
                table.AddCell(_logbook.ProblemsDay02);
                table.AddCell(_logbook.CommentsDay02);
                table.AddCell(f4);
                table.AddCell(s1);

                //3rd Row



                //table.AddCell(Wednesdays);
                phrasess.Add(new Chunk((_logbook.Day03.Value.ToShortDateString()), new Font()));
                phrasess.Add(new Chunk(" Emmmm", new Font(Font.FontFamily.TIMES_ROMAN, 12, 0, BaseColor.WHITE)));
                table.AddCell(phrasess);
                table.AddCell(_logbook.TaskDay03);
                table.AddCell(_logbook.CompletedSatDay03);
                table.AddCell(_logbook.TimeTakenDay03);
                table.AddCell(_logbook.ProblemsDay03);
                table.AddCell(_logbook.CommentsDay03);
                table.AddCell(f4);
                table.AddCell(s1);

                //4th Row



                //table.AddCell(Thursdays);
                phrasesss.Add(new Chunk((_logbook.Day04.Value.ToShortDateString()), new Font()));
                phrasesss.Add(new Chunk(" Emmmm", new Font(Font.FontFamily.TIMES_ROMAN, 12, 0, BaseColor.WHITE)));
                table.AddCell(phrasesss);
                table.AddCell(_logbook.TaskDay04);
                table.AddCell(_logbook.CompletedSatDay04);
                table.AddCell(_logbook.TimeTakenDay04);
                table.AddCell(_logbook.ProblemsDay04);
                table.AddCell(_logbook.CommentsDay04);
                table.AddCell(f4);
                table.AddCell(s1);

                //5th Row


                //table.AddCell(Fridays);
                phrasessss.Add(new Chunk((_logbook.Day05.Value.ToShortDateString()), new Font()));
                phrasessss.Add(new Chunk(" Emmmm", new Font(Font.FontFamily.TIMES_ROMAN, 12, 0, BaseColor.WHITE)));
                table.AddCell(phrasessss);
                table.AddCell(_logbook.TaskDay05);
                table.AddCell(_logbook.CompletedSatDay05);
                table.AddCell(_logbook.TimeTakenDay05);
                table.AddCell(_logbook.ProblemsDay05);
                table.AddCell(_logbook.CommentsDay05);
                table.AddCell(f4);
                table.AddCell(s1);
            }
            else if (_logbook.fontStyle == "Edwardian Script ITC")
            {
                Phrase f5 = new Phrase();


                string font5 = System.Web.HttpContext.Current.Server.MapPath("~/Fonts/ITCEDSCR.TTF");
                BaseFont baseFont5 = BaseFont.CreateFont(font5, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

                f5.Add(new Chunk(_logbook.LearnerSignature, new Font(FontFactory.GetFont(font5, BaseFont.IDENTITY_H, BaseFont.EMBEDDED, 16))));
                Phrase phrase = new Phrase();
                Phrase phrases = new Phrase();
                Phrase phrasess = new Phrase();
                Phrase phrasesss = new Phrase();
                Phrase phrasessss = new Phrase();

                //For Sig Monday - Mentor
                Phrase s1 = new Phrase();
                //string font = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "VLADIMIR.ttf");
               // string font = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "VLADIMIR.ttf");
                string font = System.Web.HttpContext.Current.Server.MapPath("~/Fonts/VLADIMIR.TTF");
                BaseFont baseFont = BaseFont.CreateFont(font, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                s1.Add(new Chunk("M.Huna", new Font(FontFactory.GetFont(font, BaseFont.IDENTITY_H, BaseFont.EMBEDDED, 16))));
                //table.AddCell(s1);

                phrase.Add(new Chunk((_logbook.Day01.Value.ToShortDateString()), new Font()));
                phrase.Add(new Chunk(" Emmmm", new Font(Font.FontFamily.TIMES_ROMAN, 12, 0, BaseColor.WHITE)));
                table.AddCell(phrase);
                // table.AddCell(_logbook.Day01.Value.ToLongDateString() );
                //table.AddCell(Mondays);
                table.AddCell(_logbook.TaskDay01);
                table.AddCell(_logbook.CompletedSatDay01);
                table.AddCell(_logbook.TimeTakenDay01);
                table.AddCell(_logbook.ProblemsDay01);
                table.AddCell(_logbook.CommentsDay01);
                table.AddCell(f5);
                table.AddCell(s1);
                // table.AddCell("M.Huna");


                //2nd Row
                //table.AddCell(Tuesdays);
                phrases.Add(new Chunk((_logbook.Day02.Value.ToShortDateString()), new Font()));
                phrases.Add(new Chunk(" Emmmm", new Font(Font.FontFamily.TIMES_ROMAN, 12, 0, BaseColor.WHITE)));
                table.AddCell(phrases);
                table.AddCell(_logbook.TaskDay02);
                table.AddCell(_logbook.CompletedSatDay02);
                table.AddCell(_logbook.TimeTakenDay02);
                table.AddCell(_logbook.ProblemsDay02);
                table.AddCell(_logbook.CommentsDay02);
                table.AddCell(f5);
                table.AddCell(s1);

                //3rd Row



                //table.AddCell(Wednesdays);
                phrasess.Add(new Chunk((_logbook.Day03.Value.ToShortDateString()), new Font()));
                phrasess.Add(new Chunk(" Emmmm", new Font(Font.FontFamily.TIMES_ROMAN, 12, 0, BaseColor.WHITE)));
                table.AddCell(phrasess);
                table.AddCell(_logbook.TaskDay03);
                table.AddCell(_logbook.CompletedSatDay03);
                table.AddCell(_logbook.TimeTakenDay03);
                table.AddCell(_logbook.ProblemsDay03);
                table.AddCell(_logbook.CommentsDay03);
                table.AddCell(f5);
                table.AddCell(s1);

                //4th Row



                //table.AddCell(Thursdays);
                phrasesss.Add(new Chunk((_logbook.Day04.Value.ToShortDateString()), new Font()));
                phrasesss.Add(new Chunk(" Emmmm", new Font(Font.FontFamily.TIMES_ROMAN, 12, 0, BaseColor.WHITE)));
                table.AddCell(phrasesss);
                table.AddCell(_logbook.TaskDay04);
                table.AddCell(_logbook.CompletedSatDay04);
                table.AddCell(_logbook.TimeTakenDay04);
                table.AddCell(_logbook.ProblemsDay04);
                table.AddCell(_logbook.CommentsDay04);
                table.AddCell(f5);
                table.AddCell(s1);

                //5th Row


                //table.AddCell(Fridays);
                phrasessss.Add(new Chunk((_logbook.Day05.Value.ToShortDateString()), new Font()));
                phrasessss.Add(new Chunk(" Emmmm", new Font(Font.FontFamily.TIMES_ROMAN, 12, 0, BaseColor.WHITE)));
                table.AddCell(phrasessss);
                table.AddCell(_logbook.TaskDay05);
                table.AddCell(_logbook.CompletedSatDay05);
                table.AddCell(_logbook.TimeTakenDay05);
                table.AddCell(_logbook.ProblemsDay05);
                table.AddCell(_logbook.CommentsDay05);
                table.AddCell(f5);
                table.AddCell(s1);
            }
            else if (_logbook.fontStyle == "Mistral")
            {
                Phrase f6 = new Phrase();
                //string font = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "VLADIMIR.ttf");
                string font6 = System.Web.HttpContext.Current.Server.MapPath("~/Fonts/MISTRAL.TTF");
                BaseFont baseFont6 = BaseFont.CreateFont(font6, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

                f6.Add(new Chunk(_logbook.LearnerSignature, new Font(FontFactory.GetFont(font6, BaseFont.IDENTITY_H, BaseFont.EMBEDDED, 16))));

                Phrase phrase = new Phrase();
                Phrase phrases = new Phrase();
                Phrase phrasess = new Phrase();
                Phrase phrasesss = new Phrase();
                Phrase phrasessss = new Phrase();

                //For Sig Monday - Mentor
                Phrase s1 = new Phrase();
                //string font = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "VLADIMIR.ttf");
              //  string font = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "VLADIMIR.ttf");
                string font = System.Web.HttpContext.Current.Server.MapPath("~/Fonts/VLADIMIR.TTF");
                BaseFont baseFont = BaseFont.CreateFont(font, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                s1.Add(new Chunk("M.Huna", new Font(FontFactory.GetFont(font, BaseFont.IDENTITY_H, BaseFont.EMBEDDED, 16))));
                //table.AddCell(s1);

                phrase.Add(new Chunk((_logbook.Day01.Value.ToShortDateString()), new Font()));
                phrase.Add(new Chunk(" Emmmm", new Font(Font.FontFamily.TIMES_ROMAN, 12, 0, BaseColor.WHITE)));
                table.AddCell(phrase);
                // table.AddCell(_logbook.Day01.Value.ToLongDateString() );
                //table.AddCell(Mondays);
                table.AddCell(_logbook.TaskDay01);
                table.AddCell(_logbook.CompletedSatDay01);
                table.AddCell(_logbook.TimeTakenDay01);
                table.AddCell(_logbook.ProblemsDay01);
                table.AddCell(_logbook.CommentsDay01);
                table.AddCell(f6);
                table.AddCell(s1);
                // table.AddCell("M.Huna");


                //2nd Row
                //table.AddCell(Tuesdays);
                phrases.Add(new Chunk((_logbook.Day02.Value.ToShortDateString()), new Font()));
                phrases.Add(new Chunk(" Emmmm", new Font(Font.FontFamily.TIMES_ROMAN, 12, 0, BaseColor.WHITE)));
                table.AddCell(phrases);
                table.AddCell(_logbook.TaskDay02);
                table.AddCell(_logbook.CompletedSatDay02);
                table.AddCell(_logbook.TimeTakenDay02);
                table.AddCell(_logbook.ProblemsDay02);
                table.AddCell(_logbook.CommentsDay02);
                table.AddCell(f6);
                table.AddCell(s1);

                //3rd Row



                //table.AddCell(Wednesdays);
                phrasess.Add(new Chunk((_logbook.Day03.Value.ToShortDateString()), new Font()));
                phrasess.Add(new Chunk(" Emmmm", new Font(Font.FontFamily.TIMES_ROMAN, 12, 0, BaseColor.WHITE)));
                table.AddCell(phrasess);
                table.AddCell(_logbook.TaskDay03);
                table.AddCell(_logbook.CompletedSatDay03);
                table.AddCell(_logbook.TimeTakenDay03);
                table.AddCell(_logbook.ProblemsDay03);
                table.AddCell(_logbook.CommentsDay03);
                table.AddCell(f6);
                table.AddCell(s1);

                //4th Row



                //table.AddCell(Thursdays);
                phrasesss.Add(new Chunk((_logbook.Day04.Value.ToShortDateString()), new Font()));
                phrasesss.Add(new Chunk(" Emmmm", new Font(Font.FontFamily.TIMES_ROMAN, 12, 0, BaseColor.WHITE)));
                table.AddCell(phrasesss);
                table.AddCell(_logbook.TaskDay04);
                table.AddCell(_logbook.CompletedSatDay04);
                table.AddCell(_logbook.TimeTakenDay04);
                table.AddCell(_logbook.ProblemsDay04);
                table.AddCell(_logbook.CommentsDay04);
                table.AddCell(f6);
                table.AddCell(s1);

                //5th Row


                //table.AddCell(Fridays);
                phrasessss.Add(new Chunk((_logbook.Day05.Value.ToShortDateString()), new Font()));
                phrasessss.Add(new Chunk(" Emmmm", new Font(Font.FontFamily.TIMES_ROMAN, 12, 0, BaseColor.WHITE)));
                table.AddCell(phrasessss);
                table.AddCell(_logbook.TaskDay05);
                table.AddCell(_logbook.CompletedSatDay05);
                table.AddCell(_logbook.TimeTakenDay05);
                table.AddCell(_logbook.ProblemsDay05);
                table.AddCell(_logbook.CommentsDay05);
                table.AddCell(f6);
                table.AddCell(s1);
            }
            else if (_logbook.fontStyle == "Place Script MT")
            {
                Phrase f7 = new Phrase();
                //string font = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "VLADIMIR.ttf");
                string font7 = System.Web.HttpContext.Current.Server.MapPath("~/Fonts/PALSCRI.TTF");
                BaseFont baseFont7 = BaseFont.CreateFont(font7, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

                f7.Add(new Chunk(_logbook.LearnerSignature, new Font(FontFactory.GetFont(font7, BaseFont.IDENTITY_H, BaseFont.EMBEDDED, 16))));

                Phrase phrase = new Phrase();
                Phrase phrases = new Phrase();
                Phrase phrasess = new Phrase();
                Phrase phrasesss = new Phrase();
                Phrase phrasessss = new Phrase();

                //For Sig Monday - Mentor
                Phrase s1 = new Phrase();
                //string font = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "VLADIMIR.ttf");
            //    string font = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "VLADIMIR.ttf");
                string font = System.Web.HttpContext.Current.Server.MapPath("~/Fonts/VLADIMIR.TTF");
                BaseFont baseFont = BaseFont.CreateFont(font, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                s1.Add(new Chunk("M.Huna", new Font(FontFactory.GetFont(font, BaseFont.IDENTITY_H, BaseFont.EMBEDDED, 16))));
                //table.AddCell(s1);

                phrase.Add(new Chunk((_logbook.Day01.Value.ToShortDateString()), new Font()));
                phrase.Add(new Chunk(" Emmmm", new Font(Font.FontFamily.TIMES_ROMAN, 12, 0, BaseColor.WHITE)));
                table.AddCell(phrase);
                // table.AddCell(_logbook.Day01.Value.ToLongDateString() );
                //table.AddCell(Mondays);
                table.AddCell(_logbook.TaskDay01);
                table.AddCell(_logbook.CompletedSatDay01);
                table.AddCell(_logbook.TimeTakenDay01);
                table.AddCell(_logbook.ProblemsDay01);
                table.AddCell(_logbook.CommentsDay01);
                table.AddCell(f7);
                table.AddCell(s1);
                // table.AddCell("M.Huna");


                //2nd Row
                //table.AddCell(Tuesdays);
                phrases.Add(new Chunk((_logbook.Day02.Value.ToShortDateString()), new Font()));
                phrases.Add(new Chunk(" Emmmm", new Font(Font.FontFamily.TIMES_ROMAN, 12, 0, BaseColor.WHITE)));
                table.AddCell(phrases);
                table.AddCell(_logbook.TaskDay02);
                table.AddCell(_logbook.CompletedSatDay02);
                table.AddCell(_logbook.TimeTakenDay02);
                table.AddCell(_logbook.ProblemsDay02);
                table.AddCell(_logbook.CommentsDay02);
                table.AddCell(f7);
                table.AddCell(s1);

                //3rd Row



                //table.AddCell(Wednesdays);
                phrasess.Add(new Chunk((_logbook.Day03.Value.ToShortDateString()), new Font()));
                phrasess.Add(new Chunk(" Emmmm", new Font(Font.FontFamily.TIMES_ROMAN, 12, 0, BaseColor.WHITE)));
                table.AddCell(phrasess);
                table.AddCell(_logbook.TaskDay03);
                table.AddCell(_logbook.CompletedSatDay03);
                table.AddCell(_logbook.TimeTakenDay03);
                table.AddCell(_logbook.ProblemsDay03);
                table.AddCell(_logbook.CommentsDay03);
                table.AddCell(f7);
                table.AddCell(s1);

                //4th Row



                //table.AddCell(Thursdays);
                phrasesss.Add(new Chunk((_logbook.Day04.Value.ToShortDateString()), new Font()));
                phrasesss.Add(new Chunk(" Emmmm", new Font(Font.FontFamily.TIMES_ROMAN, 12, 0, BaseColor.WHITE)));
                table.AddCell(phrasesss);
                table.AddCell(_logbook.TaskDay04);
                table.AddCell(_logbook.CompletedSatDay04);
                table.AddCell(_logbook.TimeTakenDay04);
                table.AddCell(_logbook.ProblemsDay04);
                table.AddCell(_logbook.CommentsDay04);
                table.AddCell(f7);
                table.AddCell(s1);

                //5th Row


                //table.AddCell(Fridays);
                phrasessss.Add(new Chunk((_logbook.Day05.Value.ToShortDateString()), new Font()));
                phrasessss.Add(new Chunk(" Emmmm", new Font(Font.FontFamily.TIMES_ROMAN, 12, 0, BaseColor.WHITE)));
                table.AddCell(phrasessss);
                table.AddCell(_logbook.TaskDay05);
                table.AddCell(_logbook.CompletedSatDay05);
                table.AddCell(_logbook.TimeTakenDay05);
                table.AddCell(_logbook.ProblemsDay05);
                table.AddCell(_logbook.CommentsDay05);
                table.AddCell(f7);
                table.AddCell(s1);
            }
            else if (_logbook.fontStyle == "Chiller")
            {
                Phrase f8 = new Phrase();
                //string font = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "VLADIMIR.ttf");
                string font8 = System.Web.HttpContext.Current.Server.MapPath("~/Fonts/CHILLER.TTF");
                BaseFont baseFont8 = BaseFont.CreateFont(font8, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

                f8.Add(new Chunk(_logbook.LearnerSignature, new Font(FontFactory.GetFont(font8, BaseFont.IDENTITY_H, BaseFont.EMBEDDED, 16))));

                Phrase phrase = new Phrase();
                Phrase phrases = new Phrase();
                Phrase phrasess = new Phrase();
                Phrase phrasesss = new Phrase();
                Phrase phrasessss = new Phrase();

                //For Sig Monday - Mentor
                Phrase s1 = new Phrase();
                //string font = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "VLADIMIR.ttf");
           //     string font = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "VLADIMIR.ttf");
                string font = System.Web.HttpContext.Current.Server.MapPath("~/Fonts/VLADIMIR.TTF");
                BaseFont baseFont = BaseFont.CreateFont(font, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                s1.Add(new Chunk("M.Huna", new Font(FontFactory.GetFont(font, BaseFont.IDENTITY_H, BaseFont.EMBEDDED, 16))));
                //table.AddCell(s1);

                phrase.Add(new Chunk((_logbook.Day01.Value.ToShortDateString()), new Font()));
                phrase.Add(new Chunk(" Emmmm", new Font(Font.FontFamily.TIMES_ROMAN, 12, 0, BaseColor.WHITE)));
                table.AddCell(phrase);
                // table.AddCell(_logbook.Day01.Value.ToLongDateString() );
                //table.AddCell(Mondays);
                table.AddCell(_logbook.TaskDay01);
                table.AddCell(_logbook.CompletedSatDay01);
                table.AddCell(_logbook.TimeTakenDay01);
                table.AddCell(_logbook.ProblemsDay01);
                table.AddCell(_logbook.CommentsDay01);
                table.AddCell(f8);
                table.AddCell(s1);
                // table.AddCell("M.Huna");


                //2nd Row
                //table.AddCell(Tuesdays);
                phrases.Add(new Chunk((_logbook.Day02.Value.ToShortDateString()), new Font()));
                phrases.Add(new Chunk(" Emmmm", new Font(Font.FontFamily.TIMES_ROMAN, 12, 0, BaseColor.WHITE)));
                table.AddCell(phrases);
                table.AddCell(_logbook.TaskDay02);
                table.AddCell(_logbook.CompletedSatDay02);
                table.AddCell(_logbook.TimeTakenDay02);
                table.AddCell(_logbook.ProblemsDay02);
                table.AddCell(_logbook.CommentsDay02);
                table.AddCell(f8);
                table.AddCell(s1);

                //3rd Row



                //table.AddCell(Wednesdays);
                phrasess.Add(new Chunk((_logbook.Day03.Value.ToShortDateString()), new Font()));
                phrasess.Add(new Chunk(" Emmmm", new Font(Font.FontFamily.TIMES_ROMAN, 12, 0, BaseColor.WHITE)));
                table.AddCell(phrasess);
                table.AddCell(_logbook.TaskDay03);
                table.AddCell(_logbook.CompletedSatDay03);
                table.AddCell(_logbook.TimeTakenDay03);
                table.AddCell(_logbook.ProblemsDay03);
                table.AddCell(_logbook.CommentsDay03);
                table.AddCell(f8);
                table.AddCell(s1);

                //4th Row



                //table.AddCell(Thursdays);
                phrasesss.Add(new Chunk((_logbook.Day04.Value.ToShortDateString()), new Font()));
                phrasesss.Add(new Chunk(" Emmmm", new Font(Font.FontFamily.TIMES_ROMAN, 12, 0, BaseColor.WHITE)));
                table.AddCell(phrasesss);
                table.AddCell(_logbook.TaskDay04);
                table.AddCell(_logbook.CompletedSatDay04);
                table.AddCell(_logbook.TimeTakenDay04);
                table.AddCell(_logbook.ProblemsDay04);
                table.AddCell(_logbook.CommentsDay04);
                table.AddCell(f8);
                table.AddCell(s1);

                //5th Row


                //table.AddCell(Fridays);
                phrasessss.Add(new Chunk((_logbook.Day05.Value.ToShortDateString()), new Font()));
                phrasessss.Add(new Chunk(" Emmmm", new Font(Font.FontFamily.TIMES_ROMAN, 12, 0, BaseColor.WHITE)));
                table.AddCell(phrasessss);
                table.AddCell(_logbook.TaskDay05);
                table.AddCell(_logbook.CompletedSatDay05);
                table.AddCell(_logbook.TimeTakenDay05);
                table.AddCell(_logbook.ProblemsDay05);
                table.AddCell(_logbook.CommentsDay05);
                table.AddCell(f8);
                table.AddCell(s1);
            }
            else if (_logbook.fontStyle == "Curlz MT")
            {
                Phrase f9 = new Phrase();
                //string font = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "VLADIMIR.ttf");
                string font9 = System.Web.HttpContext.Current.Server.MapPath("~/Fonts/CURLZ___.TTF");
                BaseFont baseFont9 = BaseFont.CreateFont(font9, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

                f9.Add(new Chunk(_logbook.LearnerSignature, new Font(FontFactory.GetFont(font9, BaseFont.IDENTITY_H, BaseFont.EMBEDDED, 16))));

                Phrase phrase = new Phrase();
                Phrase phrases = new Phrase();
                Phrase phrasess = new Phrase();
                Phrase phrasesss = new Phrase();
                Phrase phrasessss = new Phrase();

                //For Sig Monday - Mentor
                Phrase s1 = new Phrase();
                //string font = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "VLADIMIR.ttf");
           //     string font = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "VLADIMIR.ttf");
                string font = System.Web.HttpContext.Current.Server.MapPath("~/Fonts/VLADIMIR.TTF");
                BaseFont baseFont = BaseFont.CreateFont(font, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                s1.Add(new Chunk("M.Huna", new Font(FontFactory.GetFont(font, BaseFont.IDENTITY_H, BaseFont.EMBEDDED, 16))));
                //table.AddCell(s1);

                phrase.Add(new Chunk((_logbook.Day01.Value.ToShortDateString()), new Font()));
                phrase.Add(new Chunk(" Emmmm", new Font(Font.FontFamily.TIMES_ROMAN, 12, 0, BaseColor.WHITE)));
                table.AddCell(phrase);
                // table.AddCell(_logbook.Day01.Value.ToLongDateString() );
                //table.AddCell(Mondays);
                table.AddCell(_logbook.TaskDay01);
                table.AddCell(_logbook.CompletedSatDay01);
                table.AddCell(_logbook.TimeTakenDay01);
                table.AddCell(_logbook.ProblemsDay01);
                table.AddCell(_logbook.CommentsDay01);
                table.AddCell(f9);
                table.AddCell(s1);
                // table.AddCell("M.Huna");


                //2nd Row
                //table.AddCell(Tuesdays);
                phrases.Add(new Chunk((_logbook.Day02.Value.ToShortDateString()), new Font()));
                phrases.Add(new Chunk(" Emmmm", new Font(Font.FontFamily.TIMES_ROMAN, 12, 0, BaseColor.WHITE)));
                table.AddCell(phrases);
                table.AddCell(_logbook.TaskDay02);
                table.AddCell(_logbook.CompletedSatDay02);
                table.AddCell(_logbook.TimeTakenDay02);
                table.AddCell(_logbook.ProblemsDay02);
                table.AddCell(_logbook.CommentsDay02);
                table.AddCell(f9);
                table.AddCell(s1);

                //3rd Row



                //table.AddCell(Wednesdays);
                phrasess.Add(new Chunk((_logbook.Day03.Value.ToShortDateString()), new Font()));
                phrasess.Add(new Chunk(" Emmmm", new Font(Font.FontFamily.TIMES_ROMAN, 12, 0, BaseColor.WHITE)));
                table.AddCell(phrasess);
                table.AddCell(_logbook.TaskDay03);
                table.AddCell(_logbook.CompletedSatDay03);
                table.AddCell(_logbook.TimeTakenDay03);
                table.AddCell(_logbook.ProblemsDay03);
                table.AddCell(_logbook.CommentsDay03);
                table.AddCell(f9);
                table.AddCell(s1);

                //4th Row



                //table.AddCell(Thursdays);
                phrasesss.Add(new Chunk((_logbook.Day04.Value.ToShortDateString()), new Font()));
                phrasesss.Add(new Chunk(" Emmmm", new Font(Font.FontFamily.TIMES_ROMAN, 12, 0, BaseColor.WHITE)));
                table.AddCell(phrasesss);
                table.AddCell(_logbook.TaskDay04);
                table.AddCell(_logbook.CompletedSatDay04);
                table.AddCell(_logbook.TimeTakenDay04);
                table.AddCell(_logbook.ProblemsDay04);
                table.AddCell(_logbook.CommentsDay04);
                table.AddCell(f9);
                table.AddCell(s1);

                //5th Row


                //table.AddCell(Fridays);
                phrasessss.Add(new Chunk((_logbook.Day05.Value.ToShortDateString()), new Font()));
                phrasessss.Add(new Chunk(" Emmmm", new Font(Font.FontFamily.TIMES_ROMAN, 12, 0, BaseColor.WHITE)));
                table.AddCell(phrasessss);
                table.AddCell(_logbook.TaskDay05);
                table.AddCell(_logbook.CompletedSatDay05);
                table.AddCell(_logbook.TimeTakenDay05);
                table.AddCell(_logbook.ProblemsDay05);
                table.AddCell(_logbook.CommentsDay05);
                table.AddCell(f9);
                table.AddCell(s1);
            }
            else if (_logbook.fontStyle == "French Script MT")
            {
                Phrase f10 = new Phrase();
                //string font = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "VLADIMIR.ttf");
                string font10 = System.Web.HttpContext.Current.Server.MapPath("~/Fonts/FRSCRIPT.TTF");
                BaseFont baseFont10 = BaseFont.CreateFont(font10, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

                f10.Add(new Chunk(_logbook.LearnerSignature, new Font(FontFactory.GetFont(font10, BaseFont.IDENTITY_H, BaseFont.EMBEDDED, 16))));

                Phrase phrase = new Phrase();
                Phrase phrases = new Phrase();
                Phrase phrasess = new Phrase();
                Phrase phrasesss = new Phrase();
                Phrase phrasessss = new Phrase();

                //For Sig Monday - Mentor
                Phrase s1 = new Phrase();
                //string font = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "VLADIMIR.ttf");
              //  string font = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "VLADIMIR.ttf");
                string font = System.Web.HttpContext.Current.Server.MapPath("~/Fonts/VLADIMIR.TTF");
                BaseFont baseFont = BaseFont.CreateFont(font, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                s1.Add(new Chunk("M.Huna", new Font(FontFactory.GetFont(font, BaseFont.IDENTITY_H, BaseFont.EMBEDDED, 16))));
                //table.AddCell(s1);

                phrase.Add(new Chunk((_logbook.Day01.Value.ToShortDateString()), new Font()));
                phrase.Add(new Chunk(" Emmmm", new Font(Font.FontFamily.TIMES_ROMAN, 12, 0, BaseColor.WHITE)));
                table.AddCell(phrase);
                // table.AddCell(_logbook.Day01.Value.ToLongDateString() );
                //table.AddCell(Mondays);
                table.AddCell(_logbook.TaskDay01);
                table.AddCell(_logbook.CompletedSatDay01);
                table.AddCell(_logbook.TimeTakenDay01);
                table.AddCell(_logbook.ProblemsDay01);
                table.AddCell(_logbook.CommentsDay01);
                table.AddCell(f10);
                table.AddCell(s1);
                // table.AddCell("M.Huna");


                //2nd Row
                //table.AddCell(Tuesdays);
                phrases.Add(new Chunk((_logbook.Day02.Value.ToShortDateString()), new Font()));
                phrases.Add(new Chunk(" Emmmm", new Font(Font.FontFamily.TIMES_ROMAN, 12, 0, BaseColor.WHITE)));
                table.AddCell(phrases);
                table.AddCell(_logbook.TaskDay02);
                table.AddCell(_logbook.CompletedSatDay02);
                table.AddCell(_logbook.TimeTakenDay02);
                table.AddCell(_logbook.ProblemsDay02);
                table.AddCell(_logbook.CommentsDay02);
                table.AddCell(f10);
                table.AddCell(s1);

                //3rd Row



                //table.AddCell(Wednesdays);
                phrasess.Add(new Chunk((_logbook.Day03.Value.ToShortDateString()), new Font()));
                phrasess.Add(new Chunk(" Emmmm", new Font(Font.FontFamily.TIMES_ROMAN, 12, 0, BaseColor.WHITE)));
                table.AddCell(phrasess);
                table.AddCell(_logbook.TaskDay03);
                table.AddCell(_logbook.CompletedSatDay03);
                table.AddCell(_logbook.TimeTakenDay03);
                table.AddCell(_logbook.ProblemsDay03);
                table.AddCell(_logbook.CommentsDay03);
                table.AddCell(f10);
                table.AddCell(s1);

                //4th Row



                //table.AddCell(Thursdays);
                phrasesss.Add(new Chunk((_logbook.Day04.Value.ToShortDateString()), new Font()));
                phrasesss.Add(new Chunk(" Emmmm", new Font(Font.FontFamily.TIMES_ROMAN, 12, 0, BaseColor.WHITE)));
                table.AddCell(phrasesss);
                table.AddCell(_logbook.TaskDay04);
                table.AddCell(_logbook.CompletedSatDay04);
                table.AddCell(_logbook.TimeTakenDay04);
                table.AddCell(_logbook.ProblemsDay04);
                table.AddCell(_logbook.CommentsDay04);
                table.AddCell(f10);
                table.AddCell(s1);

                //5th Row


                //table.AddCell(Fridays);
                phrasessss.Add(new Chunk((_logbook.Day05.Value.ToShortDateString()), new Font()));
                phrasessss.Add(new Chunk(" Emmmm", new Font(Font.FontFamily.TIMES_ROMAN, 12, 0, BaseColor.WHITE)));
                table.AddCell(phrasessss);
                table.AddCell(_logbook.TaskDay05);
                table.AddCell(_logbook.CompletedSatDay05);
                table.AddCell(_logbook.TimeTakenDay05);
                table.AddCell(_logbook.ProblemsDay05);
                table.AddCell(_logbook.CommentsDay05);
                table.AddCell(f10);
                table.AddCell(s1);
            }
            else if (_logbook.fontStyle == "Rage Italic")
            {
                Phrase f11 = new Phrase();
                //string font = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "VLADIMIR.ttf");
                string font11 = System.Web.HttpContext.Current.Server.MapPath("~/Fonts/RAGE.TTF");
                BaseFont baseFont11 = BaseFont.CreateFont(font11, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

                f11.Add(new Chunk(_logbook.LearnerSignature, new Font(FontFactory.GetFont(font11, BaseFont.IDENTITY_H, BaseFont.EMBEDDED, 16))));

                Phrase phrase = new Phrase();
                Phrase phrases = new Phrase();
                Phrase phrasess = new Phrase();
                Phrase phrasesss = new Phrase();
                Phrase phrasessss = new Phrase();

                //For Sig Monday - Mentor
                Phrase s1 = new Phrase();
                //string font = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "VLADIMIR.ttf");
         //       string font = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "VLADIMIR.ttf");
                string font = System.Web.HttpContext.Current.Server.MapPath("~/Fonts/VLADIMIR.TTF");
                BaseFont baseFont = BaseFont.CreateFont(font, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                s1.Add(new Chunk("M.Huna", new Font(FontFactory.GetFont(font, BaseFont.IDENTITY_H, BaseFont.EMBEDDED, 16))));
                //table.AddCell(s1);

                phrase.Add(new Chunk((_logbook.Day01.Value.ToShortDateString()), new Font()));
                phrase.Add(new Chunk(" Emmmm", new Font(Font.FontFamily.TIMES_ROMAN, 12, 0, BaseColor.WHITE)));
                table.AddCell(phrase);
                // table.AddCell(_logbook.Day01.Value.ToLongDateString() );
                //table.AddCell(Mondays);
                table.AddCell(_logbook.TaskDay01);
                table.AddCell(_logbook.CompletedSatDay01);
                table.AddCell(_logbook.TimeTakenDay01);
                table.AddCell(_logbook.ProblemsDay01);
                table.AddCell(_logbook.CommentsDay01);
                table.AddCell(f11);
                table.AddCell(s1);
                // table.AddCell("M.Huna");


                //2nd Row
                //table.AddCell(Tuesdays);
                phrases.Add(new Chunk((_logbook.Day02.Value.ToShortDateString()), new Font()));
                phrases.Add(new Chunk(" Emmmm", new Font(Font.FontFamily.TIMES_ROMAN, 12, 0, BaseColor.WHITE)));
                table.AddCell(phrases);
                table.AddCell(_logbook.TaskDay02);
                table.AddCell(_logbook.CompletedSatDay02);
                table.AddCell(_logbook.TimeTakenDay02);
                table.AddCell(_logbook.ProblemsDay02);
                table.AddCell(_logbook.CommentsDay02);
                table.AddCell(f11);
                table.AddCell(s1);

                //3rd Row



                //table.AddCell(Wednesdays);
                phrasess.Add(new Chunk((_logbook.Day03.Value.ToShortDateString()), new Font()));
                phrasess.Add(new Chunk(" Emmmm", new Font(Font.FontFamily.TIMES_ROMAN, 12, 0, BaseColor.WHITE)));
                table.AddCell(phrasess);
                table.AddCell(_logbook.TaskDay03);
                table.AddCell(_logbook.CompletedSatDay03);
                table.AddCell(_logbook.TimeTakenDay03);
                table.AddCell(_logbook.ProblemsDay03);
                table.AddCell(_logbook.CommentsDay03);
                table.AddCell(f11);
                table.AddCell(s1);

                //4th Row



                //table.AddCell(Thursdays);
                phrasesss.Add(new Chunk((_logbook.Day04.Value.ToShortDateString()), new Font()));
                phrasesss.Add(new Chunk(" Emmmm", new Font(Font.FontFamily.TIMES_ROMAN, 12, 0, BaseColor.WHITE)));
                table.AddCell(phrasesss);
                table.AddCell(_logbook.TaskDay04);
                table.AddCell(_logbook.CompletedSatDay04);
                table.AddCell(_logbook.TimeTakenDay04);
                table.AddCell(_logbook.ProblemsDay04);
                table.AddCell(_logbook.CommentsDay04);
                table.AddCell(f11);
                table.AddCell(s1);

                //5th Row


                //table.AddCell(Fridays);
                phrasessss.Add(new Chunk((_logbook.Day05.Value.ToShortDateString()), new Font()));
                phrasessss.Add(new Chunk(" Emmmm", new Font(Font.FontFamily.TIMES_ROMAN, 12, 0, BaseColor.WHITE)));
                table.AddCell(phrasessss);
                table.AddCell(_logbook.TaskDay05);
                table.AddCell(_logbook.CompletedSatDay05);
                table.AddCell(_logbook.TimeTakenDay05);
                table.AddCell(_logbook.ProblemsDay05);
                table.AddCell(_logbook.CommentsDay05);
                table.AddCell(f11);
                table.AddCell(s1);
            }
            else if (_logbook.fontStyle == "Arial")
            {
                Phrase f111 = new Phrase();
                //string font = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "VLADIMIR.ttf");
                string font111 = System.Web.HttpContext.Current.Server.MapPath("~/Fonts/ARIAL.TTF");
                BaseFont baseFont11 = BaseFont.CreateFont(font111, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

                f111.Add(new Chunk(_logbook.LearnerSignature, new Font(FontFactory.GetFont(font111, BaseFont.IDENTITY_H, BaseFont.EMBEDDED, 16))));

                Phrase phrase = new Phrase();
                Phrase phrases = new Phrase();
                Phrase phrasess = new Phrase();
                Phrase phrasesss = new Phrase();
                Phrase phrasessss = new Phrase();

                //For Sig Monday - Mentor
                Phrase s1 = new Phrase();
                //string font = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "VLADIMIR.ttf");
              //  string font = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "VLADIMIR.ttf");
                string font = System.Web.HttpContext.Current.Server.MapPath("~/Fonts/VLADIMIR.TTF");
                BaseFont baseFont = BaseFont.CreateFont(font, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                s1.Add(new Chunk("M.Huna", new Font(FontFactory.GetFont(font, BaseFont.IDENTITY_H, BaseFont.EMBEDDED, 16))));
                //table.AddCell(s1);

                phrase.Add(new Chunk((_logbook.Day01.Value.ToShortDateString()), new Font()));
                phrase.Add(new Chunk(" Emmmm", new Font(Font.FontFamily.TIMES_ROMAN, 12, 0, BaseColor.WHITE)));
                table.AddCell(phrase);
                // table.AddCell(_logbook.Day01.Value.ToLongDateString() );
                //table.AddCell(Mondays);
                table.AddCell(_logbook.TaskDay01);
                table.AddCell(_logbook.CompletedSatDay01);
                table.AddCell(_logbook.TimeTakenDay01);
                table.AddCell(_logbook.ProblemsDay01);
                table.AddCell(_logbook.CommentsDay01);
                table.AddCell(f111);
                table.AddCell(s1);
                // table.AddCell("M.Huna");


                //2nd Row
                //table.AddCell(Tuesdays);
                phrases.Add(new Chunk((_logbook.Day02.Value.ToShortDateString()), new Font()));
                phrases.Add(new Chunk(" Emmmm", new Font(Font.FontFamily.TIMES_ROMAN, 12, 0, BaseColor.WHITE)));
                table.AddCell(phrases);
                table.AddCell(_logbook.TaskDay02);
                table.AddCell(_logbook.CompletedSatDay02);
                table.AddCell(_logbook.TimeTakenDay02);
                table.AddCell(_logbook.ProblemsDay02);
                table.AddCell(_logbook.CommentsDay02);
                table.AddCell(f111);
                table.AddCell(s1);

                //3rd Row



                //table.AddCell(Wednesdays);
                phrasess.Add(new Chunk((_logbook.Day03.Value.ToShortDateString()), new Font()));
                phrasess.Add(new Chunk(" Emmmm", new Font(Font.FontFamily.TIMES_ROMAN, 12, 0, BaseColor.WHITE)));
                table.AddCell(phrasess);
                table.AddCell(_logbook.TaskDay03);
                table.AddCell(_logbook.CompletedSatDay03);
                table.AddCell(_logbook.TimeTakenDay03);
                table.AddCell(_logbook.ProblemsDay03);
                table.AddCell(_logbook.CommentsDay03);
                table.AddCell(f111);
                table.AddCell(s1);

                //4th Row



                //table.AddCell(Thursdays);
                phrasesss.Add(new Chunk((_logbook.Day04.Value.ToShortDateString()), new Font()));
                phrasesss.Add(new Chunk(" Emmmm", new Font(Font.FontFamily.TIMES_ROMAN, 12, 0, BaseColor.WHITE)));
                table.AddCell(phrasesss);
                table.AddCell(_logbook.TaskDay04);
                table.AddCell(_logbook.CompletedSatDay04);
                table.AddCell(_logbook.TimeTakenDay04);
                table.AddCell(_logbook.ProblemsDay04);
                table.AddCell(_logbook.CommentsDay04);
                table.AddCell(f111);
                table.AddCell(s1);

                //5th Row


                //table.AddCell(Fridays);
                phrasessss.Add(new Chunk((_logbook.Day05.Value.ToShortDateString()), new Font()));
                phrasessss.Add(new Chunk(" Emmmm", new Font(Font.FontFamily.TIMES_ROMAN, 12, 0, BaseColor.WHITE)));
                table.AddCell(phrasessss);
                table.AddCell(_logbook.TaskDay05);
                table.AddCell(_logbook.CompletedSatDay05);
                table.AddCell(_logbook.TimeTakenDay05);
                table.AddCell(_logbook.ProblemsDay05);
                table.AddCell(_logbook.CommentsDay05);
                table.AddCell(f111);
                table.AddCell(s1);
            }
            else
            {
                Phrase f111 = new Phrase();
                //string font = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "VLADIMIR.ttf");
                string font111 = System.Web.HttpContext.Current.Server.MapPath("~/Fonts/ARIAL.TTF");
                BaseFont baseFont11 = BaseFont.CreateFont(font111, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

                f111.Add(new Chunk(_logbook.LearnerSignature, new Font(FontFactory.GetFont(font111, BaseFont.IDENTITY_H, BaseFont.EMBEDDED, 16))));

                Phrase phrase = new Phrase();
                Phrase phrases = new Phrase();
                Phrase phrasess = new Phrase();
                Phrase phrasesss = new Phrase();
                Phrase phrasessss = new Phrase();

                //For Sig Monday - Mentor
                Phrase s1 = new Phrase();
                //string font = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "VLADIMIR.ttf");
              //  string font = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "VLADIMIR.ttf");
                string font = System.Web.HttpContext.Current.Server.MapPath("~/Fonts/VLADIMIR.TTF");
                BaseFont baseFont = BaseFont.CreateFont(font, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                s1.Add(new Chunk("M.Huna", new Font(FontFactory.GetFont(font, BaseFont.IDENTITY_H, BaseFont.EMBEDDED, 16))));
                //table.AddCell(s1);

                phrase.Add(new Chunk((_logbook.Day01.Value.ToShortDateString()), new Font()));
                phrase.Add(new Chunk(" Emmmm", new Font(Font.FontFamily.TIMES_ROMAN, 12, 0, BaseColor.WHITE)));
                table.AddCell(phrase);
                // table.AddCell(_logbook.Day01.Value.ToLongDateString() );
                //table.AddCell(Mondays);
                table.AddCell(_logbook.TaskDay01);
                table.AddCell(_logbook.CompletedSatDay01);
                table.AddCell(_logbook.TimeTakenDay01);
                table.AddCell(_logbook.ProblemsDay01);
                table.AddCell(_logbook.CommentsDay01);
                table.AddCell(f111);
                table.AddCell(s1);
                // table.AddCell("M.Huna");


                //2nd Row
                //table.AddCell(Tuesdays);
                phrases.Add(new Chunk((_logbook.Day02.Value.ToShortDateString()), new Font()));
                phrases.Add(new Chunk(" Emmmm", new Font(Font.FontFamily.TIMES_ROMAN, 12, 0, BaseColor.WHITE)));
                table.AddCell(phrases);
                table.AddCell(_logbook.TaskDay02);
                table.AddCell(_logbook.CompletedSatDay02);
                table.AddCell(_logbook.TimeTakenDay02);
                table.AddCell(_logbook.ProblemsDay02);
                table.AddCell(_logbook.CommentsDay02);
                table.AddCell(f111);
                table.AddCell(s1);

                //3rd Row



                //table.AddCell(Wednesdays);
                phrasess.Add(new Chunk((_logbook.Day03.Value.ToShortDateString()), new Font()));
                phrasess.Add(new Chunk(" Emmmm", new Font(Font.FontFamily.TIMES_ROMAN, 12, 0, BaseColor.WHITE)));
                table.AddCell(phrasess);
                table.AddCell(_logbook.TaskDay03);
                table.AddCell(_logbook.CompletedSatDay03);
                table.AddCell(_logbook.TimeTakenDay03);
                table.AddCell(_logbook.ProblemsDay03);
                table.AddCell(_logbook.CommentsDay03);
                table.AddCell(f111);
                table.AddCell(s1);

                //4th Row



                //table.AddCell(Thursdays);
                phrasesss.Add(new Chunk((_logbook.Day04.Value.ToShortDateString()), new Font()));
                phrasesss.Add(new Chunk(" Emmmm", new Font(Font.FontFamily.TIMES_ROMAN, 12, 0, BaseColor.WHITE)));
                table.AddCell(phrasesss);
                table.AddCell(_logbook.TaskDay04);
                table.AddCell(_logbook.CompletedSatDay04);
                table.AddCell(_logbook.TimeTakenDay04);
                table.AddCell(_logbook.ProblemsDay04);
                table.AddCell(_logbook.CommentsDay04);
                table.AddCell(f111);
                table.AddCell(s1);

                //5th Row


                //table.AddCell(Fridays);
                phrasessss.Add(new Chunk((_logbook.Day05.Value.ToShortDateString()), new Font()));
                phrasessss.Add(new Chunk(" Emmmm", new Font(Font.FontFamily.TIMES_ROMAN, 12, 0, BaseColor.WHITE)));
                table.AddCell(phrasessss);
                table.AddCell(_logbook.TaskDay05);
                table.AddCell(_logbook.CompletedSatDay05);
                table.AddCell(_logbook.TimeTakenDay05);
                table.AddCell(_logbook.ProblemsDay05);
                table.AddCell(_logbook.CommentsDay05);
                table.AddCell(f111);
                table.AddCell(s1);

            }



            info.Add("Prepared by the Torque Career Campus");
            info.Add(line + "\r\n");
            document.Add(table);




            document.Close();

            if (_logbook.Preview == "Yes")
            {
                string pathss = HttpContext.Current.Server.MapPath("~/WeeklyLogbooks/" + Week + "/");
                System.Diagnostics.Process.Start(pathss + _logbook.LearnerName + " " + WL + ".pdf");


             }


            try
            {


                return "Successfully Submitted Logbook " + _logbook.LearnerName;
            }
            catch (Exception es)
            {
                throw es;
            }
        }




    }
}