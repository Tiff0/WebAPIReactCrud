namespace WebAPIReactCrud.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Models;

    [Route("api/[controller]")]
    [ApiController]
    public class DonationCandidateController : Controller
    {
        private readonly DonationDbContext _context;

        public DonationCandidateController(DonationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        ///     Get all donation candidates.
        /// </summary>
        /// <returns> List.  </returns>
        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            var candidateList = await _context.DonationCandidates.ToListAsync();

            return Ok(candidateList);
        }

        /// <summary>
        ///     Get by Id.
        /// </summary>
        /// <param name="id"> Id. </param>
        /// <returns> Candidate. </returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<DonationCandidate>> Get(long id)
        {
            var donationCandidate = 
                await _context.DonationCandidates.FirstOrDefaultAsync(x => x.Id == id);

            if (donationCandidate == null)
            {
                return NotFound();
            }

            return Ok(donationCandidate);
        }

        /// <summary>
        ///     Edit donation candidate.
        /// </summary>
        /// <param name="id"> Id. </param>
        /// <param name="donationCandidate"> <see cref="DonationCandidate"/>. </param>
        /// <returns> <see cref="DonationCandidate"/>. </returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(long id, DonationCandidate donationCandidate)
        {
            donationCandidate.Id = id;

            _context.Entry(donationCandidate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.DonationCandidates.AnyAsync(x => x.Id == id))
                {
                    return NotFound();
                }

                // Logger to add.
                throw;
            }

            return NoContent();
        }

        /// <summary>
        ///     Create new <see cref="DonationCandidate"/>.
        /// </summary>
        /// <param name="donationCandidate"> Donation candidate. </param>
        /// <returns> Created candidate. </returns>
        [HttpPost]
        public async Task<ActionResult<DonationCandidate>> Create(DonationCandidate donationCandidate)
        {
            _context.DonationCandidates.Add(donationCandidate);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new {id = donationCandidate.Id});
        }

        /// <summary>
        ///     Delete donation candidate.
        /// </summary>
        /// <param name="id"> Id. </param>
        /// <returns> <see cref="DonationCandidate"/>. </returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<DonationCandidate>> Delete(long id)
        {
            var candidate = 
                await _context.DonationCandidates.FirstOrDefaultAsync(x => x.Id == id);

            if (candidate == null)
            {
                return NotFound();
            }

            _context.DonationCandidates.Remove(candidate);
            await _context.SaveChangesAsync();

            return Ok(candidate);
        }
    }
}