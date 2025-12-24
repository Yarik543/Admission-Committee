using AdmissionCommittee.Abstractions.Services;
using AdmissionCommittee.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AdmissionCommittee.Web.Controllers;

public class ApplicantsController : Controller
{
    private readonly IApplicantService _service;

    public ApplicantsController(IApplicantService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var list = await _service.GetAllAsync();
        return View(list);
    }

    public IActionResult Create()
    {
        return View(new Applicant());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Applicant applicant)
    {
        if (!ModelState.IsValid)
            return View(applicant);

        await _service.AddAsync(applicant);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(Guid id)
    {
        var applicant = (await _service.GetAllAsync())
            .FirstOrDefault(a => a.Id == id);

        if (applicant == null)
            return NotFound();

        return View(applicant);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Applicant applicant)
    {
        if (!ModelState.IsValid)
            return View(applicant);

        await _service.UpdateAsync(applicant);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(Guid id)
    {
        await _service.RemoveAsync(id);
        return RedirectToAction(nameof(Index));
    }
}