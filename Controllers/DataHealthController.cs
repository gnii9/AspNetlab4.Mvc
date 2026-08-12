using Microsoft.AspNetCore.Mvc;
using AspNetWeek2.Mvc.Data;
using AspNetWeek2.Mvc.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace AspNetWeek2.Mvc.Controllers
{
    public class DataHealthController : Controller
    {
        private readonly AppDbContext _context;

        public DataHealthController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = new DataHealthViewModel();

            // 1. Migration check
            var migrations = _context.Database.GetMigrations();
            var applied = _context.Database.GetAppliedMigrations();

            model.Items.Add(new DataHealthItemViewModel
            {
                Check = "Migration",
                Expected = "All applied",
                Actual = $"{applied.Count()} applied / {migrations.Count()} total",
                Status = applied.Count() == migrations.Count() ? "OK" : "Pending",
                Note = "Check EF Core migrations"
            });

            // 2. Database connection
            var canConnect = _context.Database.CanConnect();

            model.Items.Add(new DataHealthItemViewModel
            {
                Check = "Database Connection",
                Expected = "True",
                Actual = canConnect.ToString(),
                Status = canConnect ? "OK" : "Fail",
                Note = "DB connectivity"
            });

            // 3. No-tracking test
            var noTracking = _context.Books.AsNoTracking().FirstOrDefault();

            model.Items.Add(new DataHealthItemViewModel
            {
                Check = "No-Tracking Query",
                Expected = "Enabled",
                Actual = noTracking != null ? "Working" : "No data",
                Status = "OK",
                Note = "AsNoTracking() works"
            });

            // 4. Seed check (ví dụ: Users table)
            var hasData = _context.Books.Any();

            model.Items.Add(new DataHealthItemViewModel
            {
                Check = "Seed Data",
                Expected = "Has data",
                Actual = hasData ? "Data exists" : "Empty",
                Status = hasData ? "OK" : "Warning",
                Note = "Check database seed"
            });

            // 5. Transaction test (simple demo)
            try
            {
                using var tx = _context.Database.BeginTransaction();

                tx.Commit();

                model.Items.Add(new DataHealthItemViewModel
                {
                    Check = "Transaction",
                    Expected = "Commit OK",
                    Actual = "Success",
                    Status = "OK",
                    Note = "Transaction works"
                });
            }
            catch
            {
                model.Items.Add(new DataHealthItemViewModel
                {
                    Check = "Transaction",
                    Expected = "Commit OK",
                    Actual = "Failed",
                    Status = "Fail",
                    Note = "Transaction error"
                });
            }

            return View(model);
        }
    }
}