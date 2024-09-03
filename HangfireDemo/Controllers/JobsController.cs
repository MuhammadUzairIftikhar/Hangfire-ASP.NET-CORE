using Microsoft.AspNetCore.Mvc;
using Hangfire;

public class JobsController : Controller
{
    public IActionResult Index()
    {
        // Schedule a background job.
        BackgroundJob.Enqueue(() => Console.WriteLine("Hello from Hangfire!"));

        return View();
    }

    
}
