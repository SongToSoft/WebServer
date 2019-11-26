using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NLog;

namespace Server.Controllers
{
    public class HomeController : Controller
    {
        private Logger logger = LogManager.GetCurrentClassLogger();
        private EmployeeContext employeeContext;
 
        public HomeController(EmployeeContext context)
        {
            employeeContext = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await employeeContext.Staff.ToListAsync());
        }
 
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {
            logger.Debug("Create Employee Request");
            employeeContext.Staff.Add(employee);
            await employeeContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> GetDelete(int? id)
        {
            logger.Debug("Delete Employee Request over URL");
            return await Delete(id);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            logger.Debug("Delete Employee Request");
            if (id != null)
            {
                Employee employee = await employeeContext.Staff.FirstOrDefaultAsync(e => e.Id == id);
                if (employee != null)
                {
                    employeeContext.Staff.Remove(employee);
                    await employeeContext.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
    }
}
