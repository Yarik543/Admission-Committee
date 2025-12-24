using Microsoft.AspNetCore.Mvc;
using AdmissionCommittee.Abstractions.Services;
using AdmissionCommittee.Domain.Entities;
using System.Threading.Tasks;

namespace AdmissionCommittee.Controllers
{
    public class ApplicantsController : Controller
    {
        private readonly IApplicantService _service;

        public ApplicantsController(IApplicantService service)
        {
            _service = service;
        }

        // GET: Applicants
        public async Task<IActionResult> Index()
        {
            var list = await _service.GetAllAsync();

            ViewBag.Total = list.Count;
            ViewBag.Passed = list.Count(a => (a.MathScore + a.RusScore + a.ITScore) > 150);

            return View(list);
        }

        // GET: Applicants/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Applicants/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Applicant applicant)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(applicant);
                return RedirectToAction(nameof(Index));
            }

            return View(applicant);
        }

        // GET: Applicants/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var applicant = await _service.GetByIdAsync(id);
            if (applicant == null)
            {
                return NotFound();
            }
            return View(applicant);
        }

        // POST: Applicants/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Applicant applicant)
        {
            if (id != applicant.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(applicant);
                return RedirectToAction(nameof(Index));
            }

            return View(applicant);
        }

        // GET: Applicants/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var applicant = await _service.GetByIdAsync(id);
            if (applicant == null)
            {
                return NotFound();
            }
            return View(applicant);
        }

        // POST: Applicants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _service.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}