using Event.Data;
using Event.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;

namespace Event.Pages.Admin
{
    public class GroupDetailsModel : PageModel
    {
        private readonly EventDbContext _dbContext;


        public GroupDetailsModel(EventDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Group GroupDetails { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            GroupDetails = await _dbContext.Groups.Where(_ => _.Id == id).Include(_ => _.GroupUsers).Include(_ => _.GroupProjects).FirstOrDefaultAsync();
            return Page();
        }



        public IActionResult OnGetExport(int id)
        {
            var group = _dbContext.Groups
                .Where(g => g.Id == id)
                .Include(g => g.GroupUsers)
                .Include(g => g.GroupProjects)
                .FirstOrDefault();

            if (group == null)
            {
                return NotFound();
            }
            // Create a new Excel package
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using var package = new ExcelPackage();
            var worksheet = package.Workbook.Worksheets.Add("GroupDetails");
            worksheet.View.RightToLeft = true;
            worksheet.Cells.Style.Font.Name = "B Mitra";
            worksheet.Cells.Style.Font.Charset = 178;
            worksheet.Row(1).Height = 25;
            worksheet.Cells["B1,J1,O1,U1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            worksheet.Cells["A2:AH2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            worksheet.Cells["A2:AH2"].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            worksheet.Cells["A2:AH2"].Style.Font.Name = "B Mitra";
            worksheet.Cells["A2:AH2"].Style.Font.Charset = 178;
            worksheet.Cells["A2:AH2"].Style.Font.Size = 10;
            worksheet.Cells["A3:AH3"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            worksheet.Cells["A3:AH3"].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
            worksheet.Cells["A3:AH3"].Style.Font.Name = "B Mitra";
            worksheet.Cells["A3:AH3"].Style.Font.Charset = 178;
            worksheet.Cells["A3:AH3"].Style.Font.Size = 10;


            worksheet.Column(1).Width = 20; 
            worksheet.Cells["A1"].Value = "ردیف";
            worksheet.Cells["A1"].Style.Font.Size = 12;
            worksheet.Cells["A1"].Style.Font.Bold = true;
            worksheet.Cells["A1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            worksheet.Cells["A1"].Style.Fill.BackgroundColor.SetColor(Color.LightGray);

            worksheet.Cells["A2"].Value = "ردیف";
            worksheet.Cells["A3"].Value = "*";

            // Add Group Details Title
            worksheet.Cells["B1:I1"].Merge = true;
            worksheet.Cells["B1"].Value = "مشخصات تیم";
            worksheet.Cells["B1"].Style.Font.Size = 12;
            worksheet.Cells["B1"].Style.Font.Bold = true;
            worksheet.Cells["B1:I1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            worksheet.Cells["B1:I1"].Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
            

            // Add Group Details Data
            worksheet.Cells["B2"].Value = "نام تیم";
            worksheet.Cells["B3"].Value = group.GroupTeamName;
            worksheet.Cells["C2"].Value = "نام و نام خانوادگی مدیر تیم";
            worksheet.Cells["C3"].Value = group.GroupName;
            worksheet.Cells["D2"].Value = "ایمیل";
            worksheet.Cells["D3"].Value = group.GroupEmail;
            worksheet.Cells["E2"].Value = "شماره تماس";
            worksheet.Cells["E3"].Value = group.GroupPhone;
            worksheet.Cells["F2"].Value = "رشته تحصیلی";
            worksheet.Cells["F3"].Value = group.GroupFieldStudy;
            worksheet.Cells["G2"].Value = "آخرین مدرک تحصیلی";
            worksheet.Cells["G3"].Value = group.GroupLastDegree;
            worksheet.Cells["H2"].Value = "دانشگاه محل تحصیل";
            worksheet.Cells["H3"].Value = group.GroupCityOfStudy;
            worksheet.Cells["I2"].Value = "آدرس";
            worksheet.Cells["I3"].Value = group.GroupAdress;


            // Add Group Users Title
            var groupUsersTitleRow = 1;
            worksheet.Cells["J1:N1"].Merge = true;
            worksheet.Cells["J1:N1"].Value = "اعضای تیم";
            worksheet.Cells["J1"].Style.Font.Size = 12;
            worksheet.Cells["J1"].Style.Font.Bold = true;
            worksheet.Cells["J1:N1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            worksheet.Cells["J1:N1"].Style.Fill.BackgroundColor.SetColor(Color.LightPink);

            // Add Group Users Data
            var userDataRowResualt = 3;
            foreach (var user in group.GroupUsers)
            {
                worksheet.Cells["J2"].Value = "نام و نام خانوادگی";
                worksheet.Cells[$"J{userDataRowResualt}"].Value = user.GroupUserName;
                worksheet.Cells["K2"].Value = "مدرک تحصیلی";
                worksheet.Cells[$"K{userDataRowResualt}"].Value = user.GroupUserDegree;
                worksheet.Cells["L2"].Value = "دانشگاه محل تحصیل";
                worksheet.Cells[$"L{userDataRowResualt}"].Value = user.GroupUserCityOfStudy;
                worksheet.Cells["M2"].Value = "شغل کنونی";
                worksheet.Cells[$"M{userDataRowResualt}"].Value = user.GroupUserJob;
                worksheet.Cells["N2"].Value = "شماره تماس";
                worksheet.Cells[$"N{userDataRowResualt}"].Value = user.GroupUserPhone;
                // Add more user data fields as needed...
                userDataRowResualt++;
            }

            // Add Group Projects Title

            worksheet.Cells["O1:T1"].Merge = true;
            worksheet.Cells["O1"].Value = "سوابق تحقیقاتی مسئول واحد و همکاران";
            worksheet.Cells["O1"].Style.Font.Size = 12;
            worksheet.Cells["O1"].Style.Font.Bold = true;
            worksheet.Cells["O1:T1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            worksheet.Cells["O1:T1"].Style.Fill.BackgroundColor.SetColor(Color.LightSeaGreen);

            // Add Group Projects Data
            var projectDataRow = 3;
            foreach (var project in group.GroupProjects)
            {
                worksheet.Cells["O2"].Value = "عنوان طرح یا فعالیت";
                worksheet.Cells[$"O{projectDataRow}"].Value = project.GroupPrTitle;
                worksheet.Cells["P2"].Value = "زمان اجرا";
                worksheet.Cells[$"P{projectDataRow}"].Value = project.GroupPrTime;

                worksheet.Cells["Q2"].Value = "اعتبار(ریال)";
                worksheet.Cells[$"Q{projectDataRow}"].Value = project.GroupPrPrice;
                worksheet.Cells["R2"].Value = "کارفرما";
                worksheet.Cells[$"R{projectDataRow}"].Value = project.GroupPrJobLeader;
                worksheet.Cells["S2"].Value = "مجری/مجریان";
                worksheet.Cells[$"S{projectDataRow}"].Value = project.GroupPrSeller;
                worksheet.Cells["T2"].Value = "وضعیت(پایان یافته یا در حال اجرا)";
                worksheet.Cells[$"T{projectDataRow}"].Value = project.GroupPrStatus;
                // Add more project data fields as needed...
                projectDataRow++;
            }

            worksheet.Cells["U1:AH1"].Merge = true;
            worksheet.Cells["U1"].Value = "ایده محوری";
            worksheet.Cells["U1"].Style.Font.Size = 12;
            worksheet.Cells["U1"].Style.Font.Bold = true;
            worksheet.Cells["U1:AH1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            worksheet.Cells["U1:AH1"].Style.Fill.BackgroundColor.SetColor(Color.FromArgb(1,228, 223, 236));
            
            worksheet.Cells["U2"].Value = "در صورتی که پیشتر در قالب شرکت یا هسته در یکی از\nمراکز رشد کشور مستقر بوده‌اید، می‌بایست سوابق خود را\nدر این قسمت ذکر کنید.";
            worksheet.Cells["U3"].Value = group.GroupGrowHistory;
            worksheet.Cells["V2"].Value = "عنوان ایده محوری";
            worksheet.Cells["V3"].Value = group.GroupIdeaTitle;
            worksheet.Cells["W2"].Value = "محور مرتبط";
            worksheet.Cells["W3"].Value = group.GroupRelatedTitle;
            worksheet.Cells["X2"].Value = "حوزه جغرافیایی اجرای ایده";
            worksheet.Cells["X3"].Value = group.GroupGeographicalArea;
            worksheet.Cells["Y2"].Value = "مدت زمان پیش‌بینی شده برای اجرا";
            worksheet.Cells["Y3"].Value = group.GroupDurationOfRun;
            worksheet.Cells["Z2"].Value = "جامعه هدف و ذینفعان";
            worksheet.Cells["Z3"].Value = group.GroupTargetSociety;
            worksheet.Cells["AA2"].Value = "آیا ایده شما دارای ارتباط با بقیه محورهای رویداد یا\nاثربخشی بر آنها است؟ درصورت پاسخ آری، توضیح\nدهید";
            worksheet.Cells["AA3"].Value = group.GroupHaveConnectionToOther;
            worksheet.Cells["AB2"].Value = "آیا ایده محوری مبتنی بر نتایج پایان‌نامه متقاضی یا\nاعضای تیم یا تحت مالکیت مادی یا معنوی سازمان\nحامی یا سرمایه‌گذار می‌باشد؟ دقیقاً توضیح دهید";
            worksheet.Cells["AB3"].Value = group.GroupIntellectualProperty;
            worksheet.Cells["AC2"].Value = "موضوع ایده یا طرح و اهداف اصلی آن را بنویسید.\nاز ارائه‌ی اطلاعات کلی و پراکنده و چندشاخه و\nفاقد قابلیت ارزیابی پرهیز کنید.در مورد نوآورانه بودن ایده/ زمینه کاری آن توضیح دهید.";
            worksheet.Cells["AC3"].Value = group.GroupInnovativenessOfTheIdea;
            worksheet.Cells["AD2"].Value = "میزان پیشرفت طرح در عناوین زیر را شرح دهید\n( تعریف ایده و طراحی محصول  تدوین دانش فنی\nنمونه سازی تدوین طرح تجاری تولید نیمه صنعتی بازاریابی و جذب مشارکت مالی)";
            worksheet.Cells["AD3"].Value = group.GroupProjectProgress;
            worksheet.Cells["AE2"].Value = "توجیه فنی و اقتصادی و امکان‌پذیری ایده خود را بیان\n‌نمایید. ارائه‌ی اطلاعات دقیق در این بخش (شامل\nپیش‌بینی هزینه‌ها و درآمدها، حجم بازار هدف\n(مصرف‌کنندگان و مشتریان خصوصی یا دولتی)، قیمت\nتمام‌شده‌ی محصول یا خدمت و مقایسه با\nنمونه‌های داخلی و خارجی، کانال‌های توزیع، هزینه‌ی\nدستیابی به مشتری، مدل درآمدزایی، نقطه‌ی سربه‌سر\nو ...) اهمیت زیادی در پذیرش شما دارد.";
            worksheet.Cells["AE3"].Value = group.GroupFinishedPrice;
            worksheet.Cells["AF2"].Value = "رقبای شما در بازار چه کسانی هستند؟ نقاط قوت و\nضعف رقبا از نظر شما چیست و وجه تمایز و شاخص\nاصلی که شما را از رقبای دیگر متمایز می‌کند چه خواهد بود";
            worksheet.Cells["AF3"].Value = group.GroupCompetitorsInMarket;
            worksheet.Cells["AG2"].Value = "چالش‌ها و خطراتی که کسب‌وکار شما را مورد تهدید\nقرار می‌دهد و استراتژی شما برای غلبه بر\nآن‌ها چیست؟";
            worksheet.Cells["AG3"].Value = group.GroupChallengesAndRisks;
            worksheet.Cells["AH2"].Value = "چناچه پیوست دارید آپلود نمایید";
            worksheet.Cells["AH3"].Value = group.GroupFile;

            // Auto-fit columns for better visibility
            worksheet.Cells.AutoFitColumns();
            worksheet.Column(9).AutoFit(30);
            worksheet.Column(1).AutoFit(4);
            worksheet.Column(21).Width = 40;
            worksheet.Column(23).Width = 40;
            worksheet.Column(27).Width = 40;
            worksheet.Column(28).Width = 40;
            worksheet.Column(29).Width = 40;
            worksheet.Column(30).Width = 40;
            worksheet.Column(32).Width = 40;
            worksheet.Column(33).Width = 40;
            worksheet.Column(31).Width = 40;
            

            worksheet.Cells["U2,AA2,AB2,AC2,AD2,AF2,AG2,AE2"].Style.WrapText = true;
            worksheet.Cells["AE2"].Style.ShrinkToFit = true;
            worksheet.Row(2).Height = 55;
            worksheet.Cells["I3,U3,V3,W3,AA3,AB3,AC3,AD3,AE3,AF3,AG3"].Style.WrapText = true;
            worksheet.Cells["I3,U3,V3,W3,AA3,AB3,AC3,AD3,AE3,AF3,AG3"].Style.ShrinkToFit = true;
            worksheet.Row(3).Height = 65;



            // Set response headers for downloading the Excel file
            var fileName = $"Group_{group.Id}_Details.xlsx";
            Response.Headers.Add("content-disposition", $"attachment; filename={fileName}");
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            // Write the Excel package to the response stream
            Response.Body.WriteAsync(package.GetAsByteArray());

            return new EmptyResult();
        }



    }
}


